<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBomQuery_
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
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtPartNo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnQuery = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvECNList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ExpandableSplitter1 = New DevComponents.DotNetBar.ExpandableSplitter()
        Me.trBomList = New DevComponents.AdvTree.AdvTree()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.classification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.names = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sop_ver = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sop_gen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.create_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.modified_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.states = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Modified_on = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.state = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnClassification = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.part_create_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvECNList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trBomList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menuStrip1
        '
        Me.menuStrip1.BackColor = System.Drawing.Color.Gray
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2, Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5, Me.toolStripMenuItem6})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(1021, 25)
        Me.menuStrip1.TabIndex = 142
        Me.menuStrip1.Text = "menuStrip1"
        '
        'toolStripMenuItem1
        '
        Me.toolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
        Me.toolStripMenuItem1.Size = New System.Drawing.Size(59, 21)
        Me.toolStripMenuItem1.Text = "系统(&S)"
        '
        'toolStripMenuItem2
        '
        Me.toolStripMenuItem2.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
        Me.toolStripMenuItem2.Size = New System.Drawing.Size(58, 21)
        Me.toolStripMenuItem2.Text = "文件(&F)"
        '
        'toolStripMenuItem3
        '
        Me.toolStripMenuItem3.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
        Me.toolStripMenuItem3.Size = New System.Drawing.Size(60, 21)
        Me.toolStripMenuItem3.Text = "查看(&V)"
        '
        'toolStripMenuItem4
        '
        Me.toolStripMenuItem4.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem4.Name = "toolStripMenuItem4"
        Me.toolStripMenuItem4.Size = New System.Drawing.Size(59, 21)
        Me.toolStripMenuItem4.Text = "工具(&T)"
        '
        'toolStripMenuItem5
        '
        Me.toolStripMenuItem5.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem5.Name = "toolStripMenuItem5"
        Me.toolStripMenuItem5.Size = New System.Drawing.Size(64, 21)
        Me.toolStripMenuItem5.Text = "窗口(&W)"
        '
        'toolStripMenuItem6
        '
        Me.toolStripMenuItem6.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem6.Name = "toolStripMenuItem6"
        Me.toolStripMenuItem6.Size = New System.Drawing.Size(61, 21)
        Me.toolStripMenuItem6.Text = "帮助(&H)"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(22, 45)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 143
        Me.LabelX1.Text = "料号"
        '
        'txtPartNo
        '
        '
        '
        '
        Me.txtPartNo.Border.Class = "TextBoxBorder"
        Me.txtPartNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPartNo.Location = New System.Drawing.Point(68, 45)
        Me.txtPartNo.Name = "txtPartNo"
        Me.txtPartNo.Size = New System.Drawing.Size(155, 21)
        Me.txtPartNo.TabIndex = 144
        '
        'btnQuery
        '
        Me.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnQuery.Location = New System.Drawing.Point(258, 42)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(60, 25)
        Me.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.btnQuery.TabIndex = 145
        Me.btnQuery.Text = "查 询"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvECNList)
        Me.Panel1.Controls.Add(Me.ExpandableSplitter1)
        Me.Panel1.Controls.Add(Me.trBomList)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1021, 449)
        Me.Panel1.TabIndex = 146
        '
        'dgvECNList
        '
        Me.dgvECNList.AllowUserToAddRows = False
        Me.dgvECNList.AllowUserToDeleteRows = False
        Me.dgvECNList.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvECNList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvECNList.ColumnHeadersHeight = 28
        Me.dgvECNList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvECNList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.classification, Me.item_number, Me.names, Me.sop_ver, Me.sop_gen, Me.create_name, Me.modified_name, Me.states, Me.Modified_on, Me.state, Me.btnClassification, Me.part_create_name})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvECNList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvECNList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvECNList.EnableHeadersVisualStyles = False
        Me.dgvECNList.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvECNList.Location = New System.Drawing.Point(229, 0)
        Me.dgvECNList.Name = "dgvECNList"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvECNList.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvECNList.RowHeadersWidth = 15
        Me.dgvECNList.RowTemplate.Height = 25
        Me.dgvECNList.Size = New System.Drawing.Size(792, 449)
        Me.dgvECNList.TabIndex = 2
        '
        'ExpandableSplitter1
        '
        Me.ExpandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandableSplitter1.ExpandableControl = Me.trBomList
        Me.ExpandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExpandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ExpandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.ExpandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
        Me.ExpandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.ExpandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExpandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter1.Location = New System.Drawing.Point(223, 0)
        Me.ExpandableSplitter1.Name = "ExpandableSplitter1"
        Me.ExpandableSplitter1.Size = New System.Drawing.Size(6, 449)
        Me.ExpandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
        Me.ExpandableSplitter1.TabIndex = 1
        Me.ExpandableSplitter1.TabStop = False
        '
        'trBomList
        '
        Me.trBomList.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.trBomList.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.trBomList.BackgroundStyle.Class = "TreeBorderKey"
        Me.trBomList.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.trBomList.Dock = System.Windows.Forms.DockStyle.Left
        Me.trBomList.Location = New System.Drawing.Point(0, 0)
        Me.trBomList.Name = "trBomList"
        Me.trBomList.NodesConnector = Me.NodeConnector1
        Me.trBomList.NodeStyle = Me.ElementStyle1
        Me.trBomList.PathSeparator = ";"
        Me.trBomList.Size = New System.Drawing.Size(223, 449)
        Me.trBomList.Styles.Add(Me.ElementStyle1)
        Me.trBomList.TabIndex = 0
        Me.trBomList.Text = "AdvTree1"
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle1
        '
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Location = New System.Drawing.Point(385, 17)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(624, 25)
        Me.lblMessage.TabIndex = 147
        '
        'classification
        '
        Me.classification.DataPropertyName = "classification"
        Me.classification.HeaderText = "类别"
        Me.classification.Name = "classification"
        Me.classification.ReadOnly = True
        Me.classification.Width = 150
        '
        'item_number
        '
        Me.item_number.DataPropertyName = "item_number"
        Me.item_number.HeaderText = "文件号"
        Me.item_number.Name = "item_number"
        Me.item_number.ReadOnly = True
        Me.item_number.Width = 150
        '
        'names
        '
        Me.names.DataPropertyName = "name"
        Me.names.FillWeight = 250.0!
        Me.names.HeaderText = "文件名称"
        Me.names.Name = "names"
        Me.names.ReadOnly = True
        Me.names.Width = 150
        '
        'sop_ver
        '
        Me.sop_ver.DataPropertyName = "sop_ver"
        Me.sop_ver.HeaderText = "版本"
        Me.sop_ver.Name = "sop_ver"
        Me.sop_ver.ReadOnly = True
        Me.sop_ver.Width = 60
        '
        'sop_gen
        '
        Me.sop_gen.DataPropertyName = "sop_gen"
        Me.sop_gen.HeaderText = "版次"
        Me.sop_gen.Name = "sop_gen"
        Me.sop_gen.ReadOnly = True
        Me.sop_gen.Width = 60
        '
        'create_name
        '
        Me.create_name.DataPropertyName = "create_name"
        Me.create_name.HeaderText = "创建人"
        Me.create_name.Name = "create_name"
        '
        'modified_name
        '
        Me.modified_name.DataPropertyName = "modified_name"
        Me.modified_name.HeaderText = "修改人"
        Me.modified_name.Name = "modified_name"
        '
        'states
        '
        Me.states.HeaderText = "ECN码"
        Me.states.Name = "states"
        Me.states.ReadOnly = True
        '
        'Modified_on
        '
        Me.Modified_on.DataPropertyName = "release_date"
        Me.Modified_on.HeaderText = "发行日期"
        Me.Modified_on.Name = "Modified_on"
        Me.Modified_on.ReadOnly = True
        Me.Modified_on.Width = 200
        '
        'state
        '
        Me.state.DataPropertyName = "state"
        Me.state.HeaderText = "状态"
        Me.state.Name = "state"
        Me.state.ReadOnly = True
        '
        'btnClassification
        '
        Me.btnClassification.HeaderText = ""
        Me.btnClassification.Name = "btnClassification"
        Me.btnClassification.Text = "文件预览"
        '
        'part_create_name
        '
        Me.part_create_name.DataPropertyName = "part_create_name"
        Me.part_create_name.HeaderText = "料号创建人"
        Me.part_create_name.Name = "part_create_name"
        '
        'FrmBomQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1021, 494)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.txtPartNo)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Name = "FrmBomQuery"
        Me.ShowIcon = False
        Me.Text = "图纸查询"
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvECNList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trBomList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtPartNo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnQuery As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvECNList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ExpandableSplitter1 As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents trBomList As DevComponents.AdvTree.AdvTree
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents classification As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents item_number As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents names As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sop_ver As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sop_gen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents create_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents modified_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents states As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Modified_on As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents state As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnClassification As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents part_create_name As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
