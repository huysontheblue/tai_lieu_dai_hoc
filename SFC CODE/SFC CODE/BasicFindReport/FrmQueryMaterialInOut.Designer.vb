<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQueryMaterialInOut
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmQueryMaterialInOut))
        Me.DgMoData = New System.Windows.Forms.DataGridView()
        Me.DtEnd = New System.Windows.Forms.DateTimePicker()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.DtStar = New System.Windows.Forms.DateTimePicker()
        Me.ToolExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolExit = New System.Windows.Forms.ToolStripButton()
        Me.CobMaterial = New System.Windows.Forms.ComboBox()
        Me.CobLotid = New System.Windows.Forms.ComboBox()
        Me.CobCarton = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GbCondition = New System.Windows.Forms.GroupBox()
        Me.cbOut = New System.Windows.Forms.CheckBox()
        Me.cbIn = New System.Windows.Forms.CheckBox()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtpStar = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CobUser = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolReflsh = New System.Windows.Forms.ToolStripButton()
        Me.MenuItemNone = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuItemDetail = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuItemAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        CType(Me.DgMoData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GbCondition.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgMoData
        '
        Me.DgMoData.AllowUserToAddRows = False
        Me.DgMoData.AllowUserToDeleteRows = False
        Me.DgMoData.AllowUserToOrderColumns = True
        Me.DgMoData.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.DgMoData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgMoData.BackgroundColor = System.Drawing.Color.White
        Me.DgMoData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgMoData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgMoData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgMoData.ColumnHeadersHeight = 24
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgMoData.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgMoData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgMoData.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.DgMoData.Location = New System.Drawing.Point(3, 17)
        Me.DgMoData.MultiSelect = False
        Me.DgMoData.Name = "DgMoData"
        Me.DgMoData.ReadOnly = True
        Me.DgMoData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgMoData.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgMoData.RowHeadersVisible = False
        Me.DgMoData.RowHeadersWidth = 12
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.DgMoData.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgMoData.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DgMoData.RowTemplate.Height = 24
        Me.DgMoData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgMoData.ShowEditingIcon = False
        Me.DgMoData.Size = New System.Drawing.Size(1014, 351)
        Me.DgMoData.TabIndex = 147
        Me.DgMoData.TabStop = False
        '
        'DtEnd
        '
        Me.DtEnd.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.DtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtEnd.Location = New System.Drawing.Point(324, 10)
        Me.DtEnd.Name = "DtEnd"
        Me.DtEnd.Size = New System.Drawing.Size(176, 21)
        Me.DtEnd.TabIndex = 2
        Me.DtEnd.Value = New Date(2014, 6, 20, 0, 0, 0, 0)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 24)
        '
        'DtStar
        '
        Me.DtStar.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.DtStar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtStar.Location = New System.Drawing.Point(108, 10)
        Me.DtStar.Name = "DtStar"
        Me.DtStar.Size = New System.Drawing.Size(164, 21)
        Me.DtStar.TabIndex = 1
        Me.DtStar.Value = New Date(2007, 5, 23, 0, 0, 0, 0)
        '
        'ToolExcel
        '
        Me.ToolExcel.Image = CType(resources.GetObject("ToolExcel.Image"), System.Drawing.Image)
        Me.ToolExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolExcel.Name = "ToolExcel"
        Me.ToolExcel.Size = New System.Drawing.Size(64, 21)
        Me.ToolExcel.Text = "汇   出"
        '
        'ToolExit
        '
        Me.ToolExit.Image = CType(resources.GetObject("ToolExit.Image"), System.Drawing.Image)
        Me.ToolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolExit.Name = "ToolExit"
        Me.ToolExit.Size = New System.Drawing.Size(68, 21)
        Me.ToolExit.Text = "退    出"
        '
        'CobMaterial
        '
        Me.CobMaterial.FormattingEnabled = True
        Me.CobMaterial.Location = New System.Drawing.Point(338, 80)
        Me.CobMaterial.Name = "CobMaterial"
        Me.CobMaterial.Size = New System.Drawing.Size(162, 20)
        Me.CobMaterial.TabIndex = 6
        '
        'CobLotid
        '
        Me.CobLotid.FormattingEnabled = True
        Me.CobLotid.Location = New System.Drawing.Point(84, 118)
        Me.CobLotid.Name = "CobLotid"
        Me.CobLotid.Size = New System.Drawing.Size(164, 20)
        Me.CobLotid.TabIndex = 5
        '
        'CobCarton
        '
        Me.CobCarton.FormattingEnabled = True
        Me.CobCarton.Location = New System.Drawing.Point(84, 82)
        Me.CobCarton.Name = "CobCarton"
        Me.CobCarton.Size = New System.Drawing.Size(164, 20)
        Me.CobCarton.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.DgMoData)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(12, 187)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1020, 371)
        Me.GroupBox1.TabIndex = 152
        Me.GroupBox1.TabStop = False
        '
        'GbCondition
        '
        Me.GbCondition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbCondition.Controls.Add(Me.cbOut)
        Me.GbCondition.Controls.Add(Me.cbIn)
        Me.GbCondition.Controls.Add(Me.dtpEnd)
        Me.GbCondition.Controls.Add(Me.dtpStar)
        Me.GbCondition.Controls.Add(Me.Label8)
        Me.GbCondition.Controls.Add(Me.Label7)
        Me.GbCondition.Controls.Add(Me.Label2)
        Me.GbCondition.Controls.Add(Me.CobUser)
        Me.GbCondition.Controls.Add(Me.DtEnd)
        Me.GbCondition.Controls.Add(Me.DtStar)
        Me.GbCondition.Controls.Add(Me.CobMaterial)
        Me.GbCondition.Controls.Add(Me.CobLotid)
        Me.GbCondition.Controls.Add(Me.CobCarton)
        Me.GbCondition.Controls.Add(Me.Label4)
        Me.GbCondition.Controls.Add(Me.Label5)
        Me.GbCondition.Controls.Add(Me.Label3)
        Me.GbCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GbCondition.Location = New System.Drawing.Point(12, 29)
        Me.GbCondition.Name = "GbCondition"
        Me.GbCondition.Size = New System.Drawing.Size(1020, 152)
        Me.GbCondition.TabIndex = 149
        Me.GbCondition.TabStop = False
        '
        'cbOut
        '
        Me.cbOut.AutoSize = True
        Me.cbOut.Location = New System.Drawing.Point(7, 49)
        Me.cbOut.Name = "cbOut"
        Me.cbOut.Size = New System.Drawing.Size(96, 16)
        Me.cbOut.TabIndex = 108
        Me.cbOut.Text = "出库起始时间"
        Me.cbOut.UseVisualStyleBackColor = True
        '
        'cbIn
        '
        Me.cbIn.AutoSize = True
        Me.cbIn.Checked = True
        Me.cbIn.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbIn.Location = New System.Drawing.Point(6, 15)
        Me.cbIn.Name = "cbIn"
        Me.cbIn.Size = New System.Drawing.Size(96, 16)
        Me.cbIn.TabIndex = 107
        Me.cbIn.Text = "入库起始时间"
        Me.cbIn.UseVisualStyleBackColor = True
        '
        'dtpEnd
        '
        Me.dtpEnd.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.dtpEnd.Enabled = False
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEnd.Location = New System.Drawing.Point(324, 47)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(176, 21)
        Me.dtpEnd.TabIndex = 104
        Me.dtpEnd.Value = New Date(2014, 6, 20, 0, 0, 0, 0)
        '
        'dtpStar
        '
        Me.dtpStar.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.dtpStar.Enabled = False
        Me.dtpStar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStar.Location = New System.Drawing.Point(109, 48)
        Me.dtpStar.Name = "dtpStar"
        Me.dtpStar.Size = New System.Drawing.Size(164, 21)
        Me.dtpStar.TabIndex = 103
        Me.dtpStar.Value = New Date(2007, 5, 23, 0, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(290, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 12)
        Me.Label8.TabIndex = 106
        Me.Label8.Text = "至 "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(254, 121)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 12)
        Me.Label7.TabIndex = 102
        Me.Label7.Text = "入库/出库人："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "来料批次："
        '
        'CobUser
        '
        Me.CobUser.FormattingEnabled = True
        Me.CobUser.Location = New System.Drawing.Point(338, 118)
        Me.CobUser.Name = "CobUser"
        Me.CobUser.Size = New System.Drawing.Size(162, 20)
        Me.CobUser.TabIndex = 99
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 93
        Me.Label4.Text = "送货单号："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(271, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "料件编号："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(288, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 12)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "至 "
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 24)
        '
        'ToolReflsh
        '
        Me.ToolReflsh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToolReflsh.Image = CType(resources.GetObject("ToolReflsh.Image"), System.Drawing.Image)
        Me.ToolReflsh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolReflsh.Name = "ToolReflsh"
        Me.ToolReflsh.Size = New System.Drawing.Size(63, 21)
        Me.ToolReflsh.Text = "刷    新"
        '
        'MenuItemNone
        '
        Me.MenuItemNone.Name = "MenuItemNone"
        Me.MenuItemNone.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.MenuItemNone.Size = New System.Drawing.Size(191, 22)
        Me.MenuItemNone.Text = "全不選"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel1.Text = "记录笔数："
        '
        'MenuItemDetail
        '
        Me.MenuItemDetail.Name = "MenuItemDetail"
        Me.MenuItemDetail.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.MenuItemDetail.Size = New System.Drawing.Size(191, 22)
        Me.MenuItemDetail.Text = "顯示詳細 "
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 24)
        '
        'ToolCount
        '
        Me.ToolCount.BackColor = System.Drawing.SystemColors.Control
        Me.ToolCount.Name = "ToolCount"
        Me.ToolCount.Size = New System.Drawing.Size(15, 17)
        Me.ToolCount.Text = "0"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 561)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1044, 22)
        Me.StatusStrip1.TabIndex = 150
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemAll, Me.MenuItemNone, Me.MenuItemDetail})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(192, 70)
        '
        'MenuItemAll
        '
        Me.MenuItemAll.Name = "MenuItemAll"
        Me.MenuItemAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.MenuItemAll.Size = New System.Drawing.Size(191, 22)
        Me.MenuItemAll.Text = "全選"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ToolReflsh, Me.ToolStripSeparator2, Me.ToolExcel, Me.ToolStripSeparator3, Me.ToolExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1032, 24)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 148
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'FrmQueryMaterialInOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 583)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GbCondition)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmQueryMaterialInOut"
        Me.Text = "原材料批次入库出库查询"
        CType(Me.DgMoData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GbCondition.ResumeLayout(False)
        Me.GbCondition.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgMoData As System.Windows.Forms.DataGridView
    Friend WithEvents DtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DtStar As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents CobMaterial As System.Windows.Forms.ComboBox
    Friend WithEvents CobLotid As System.Windows.Forms.ComboBox
    Friend WithEvents CobCarton As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GbCondition As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolReflsh As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuItemNone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuItemDetail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuItemAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CobUser As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStar As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbIn As System.Windows.Forms.CheckBox
    Friend WithEvents cbOut As System.Windows.Forms.CheckBox
End Class
