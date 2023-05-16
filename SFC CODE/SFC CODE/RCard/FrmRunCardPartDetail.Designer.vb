<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRunCardPartDetail
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRunCardPartDetail))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvBomPart = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bom_Select = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Bom_PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bom_Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bom_Description1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bom_Flag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvEquipmentPart = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.EQ_Select = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.EQ_PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EQ_Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EQ_Description1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EQ_Flag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtFindRule = New System.Windows.Forms.TextBox()
        Me.txtFindBand = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFindPn = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvBomPart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEquipmentPart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvBomPart)
        Me.GroupBox2.Controls.Add(Me.dgvEquipmentPart)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1031, 418)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'dgvBomPart
        '
        Me.dgvBomPart.AllowUserToAddRows = False
        Me.dgvBomPart.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvBomPart.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBomPart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvBomPart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBomPart.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBomPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBomPart.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Bom_Select, Me.Bom_PartNumber, Me.Bom_Description, Me.Bom_Description1, Me.Bom_Flag})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBomPart.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBomPart.EnableHeadersVisualStyles = False
        Me.dgvBomPart.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvBomPart.Location = New System.Drawing.Point(3, 61)
        Me.dgvBomPart.Name = "dgvBomPart"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBomPart.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvBomPart.RowHeadersVisible = False
        Me.dgvBomPart.RowHeadersWidth = 20
        Me.dgvBomPart.RowTemplate.Height = 23
        Me.dgvBomPart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvBomPart.Size = New System.Drawing.Size(559, 354)
        Me.dgvBomPart.TabIndex = 7
        '
        'Bom_Select
        '
        Me.Bom_Select.FalseValue = "N"
        Me.Bom_Select.HeaderText = "选择"
        Me.Bom_Select.Name = "Bom_Select"
        Me.Bom_Select.TrueValue = "Y"
        Me.Bom_Select.Width = 35
        '
        'Bom_PartNumber
        '
        Me.Bom_PartNumber.HeaderText = "料件编号"
        Me.Bom_PartNumber.Name = "Bom_PartNumber"
        Me.Bom_PartNumber.Width = 120
        '
        'Bom_Description
        '
        Me.Bom_Description.HeaderText = "品名"
        Me.Bom_Description.Name = "Bom_Description"
        Me.Bom_Description.Width = 200
        '
        'Bom_Description1
        '
        Me.Bom_Description1.HeaderText = "规格"
        Me.Bom_Description1.Name = "Bom_Description1"
        Me.Bom_Description1.Width = 200
        '
        'Bom_Flag
        '
        Me.Bom_Flag.HeaderText = "Flag"
        Me.Bom_Flag.Name = "Bom_Flag"
        Me.Bom_Flag.Visible = False
        Me.Bom_Flag.Width = 54
        '
        'dgvEquipmentPart
        '
        Me.dgvEquipmentPart.AllowUserToAddRows = False
        Me.dgvEquipmentPart.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvEquipmentPart.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvEquipmentPart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEquipmentPart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEquipmentPart.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvEquipmentPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEquipmentPart.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EQ_Select, Me.EQ_PartNumber, Me.EQ_Description, Me.EQ_Description1, Me.EQ_Flag})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEquipmentPart.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvEquipmentPart.EnableHeadersVisualStyles = False
        Me.dgvEquipmentPart.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvEquipmentPart.Location = New System.Drawing.Point(562, 61)
        Me.dgvEquipmentPart.Name = "dgvEquipmentPart"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEquipmentPart.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvEquipmentPart.RowHeadersVisible = False
        Me.dgvEquipmentPart.RowHeadersWidth = 20
        Me.dgvEquipmentPart.RowTemplate.Height = 23
        Me.dgvEquipmentPart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvEquipmentPart.Size = New System.Drawing.Size(466, 354)
        Me.dgvEquipmentPart.TabIndex = 6
        '
        'EQ_Select
        '
        Me.EQ_Select.FalseValue = "N"
        Me.EQ_Select.HeaderText = "选择"
        Me.EQ_Select.Name = "EQ_Select"
        Me.EQ_Select.TrueValue = "Y"
        Me.EQ_Select.Width = 35
        '
        'EQ_PartNumber
        '
        Me.EQ_PartNumber.HeaderText = "料件编号"
        Me.EQ_PartNumber.Name = "EQ_PartNumber"
        Me.EQ_PartNumber.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EQ_PartNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EQ_PartNumber.Width = 130
        '
        'EQ_Description
        '
        Me.EQ_Description.HeaderText = "品名"
        Me.EQ_Description.Name = "EQ_Description"
        Me.EQ_Description.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EQ_Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'EQ_Description1
        '
        Me.EQ_Description1.HeaderText = "规格"
        Me.EQ_Description1.Name = "EQ_Description1"
        Me.EQ_Description1.Width = 195
        '
        'EQ_Flag
        '
        Me.EQ_Flag.HeaderText = "Flag"
        Me.EQ_Flag.Name = "EQ_Flag"
        Me.EQ_Flag.Visible = False
        Me.EQ_Flag.Width = 54
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.txtFindRule)
        Me.Panel1.Controls.Add(Me.txtFindBand)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtFindPn)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1025, 44)
        Me.Panel1.TabIndex = 5
        '
        'txtFindRule
        '
        Me.txtFindRule.Location = New System.Drawing.Point(875, 20)
        Me.txtFindRule.Name = "txtFindRule"
        Me.txtFindRule.Size = New System.Drawing.Size(71, 21)
        Me.txtFindRule.TabIndex = 2
        '
        'txtFindBand
        '
        Me.txtFindBand.Location = New System.Drawing.Point(751, 20)
        Me.txtFindBand.Name = "txtFindBand"
        Me.txtFindBand.Size = New System.Drawing.Size(89, 21)
        Me.txtFindBand.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(572, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "筛选:"
        '
        'txtFindPn
        '
        Me.txtFindPn.Location = New System.Drawing.Point(615, 20)
        Me.txtFindPn.Name = "txtFindPn"
        Me.txtFindPn.Size = New System.Drawing.Size(91, 21)
        Me.txtFindPn.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(568, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox2.TabIndex = 11
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(4, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(602, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 12)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "请选择治具料件"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(30, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "请选择BOM料件"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(394, 424)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "确 定(&O)"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(538, 424)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "取 消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "料件ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "料件编号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "品名"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Flag"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "料件ID"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "料件编号"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "品名"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Flag"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'FrmRunCardPartDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1031, 451)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmRunCardPartDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "料件列表"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvBomPart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEquipmentPart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvBomPart As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents dgvEquipmentPart As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtFindPn As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFindRule As System.Windows.Forms.TextBox
    Friend WithEvents txtFindBand As System.Windows.Forms.TextBox
    Friend WithEvents Bom_Select As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Bom_PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bom_Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bom_Description1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bom_Flag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EQ_Select As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents EQ_PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EQ_Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EQ_Description1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EQ_Flag As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
