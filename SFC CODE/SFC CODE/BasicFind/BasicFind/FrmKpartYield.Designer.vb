<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKpartYield
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKpartYield))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolReflsh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolExcel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolExit = New System.Windows.Forms.ToolStripButton
        Me.DgMoData = New System.Windows.Forms.DataGridView
        Me.ColIqty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColOqty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColNqty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColYield = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DtEnd = New System.Windows.Forms.DateTimePicker
        Me.DtStar = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtIqty = New System.Windows.Forms.TextBox
        Me.TxtOqty = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtNqty = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtYield = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.DgOK = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.menuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DgMoData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DgOK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menuStrip1
        '
        Me.menuStrip1.BackColor = System.Drawing.Color.Gray
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2, Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5, Me.toolStripMenuItem6})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(978, 25)
        Me.menuStrip1.TabIndex = 143
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
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 462)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(978, 22)
        Me.StatusStrip1.TabIndex = 142
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel1.Text = "记录笔数："
        '
        'ToolCount
        '
        Me.ToolCount.BackColor = System.Drawing.SystemColors.Control
        Me.ToolCount.Name = "ToolCount"
        Me.ToolCount.Size = New System.Drawing.Size(15, 17)
        Me.ToolCount.Text = "0"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ToolReflsh, Me.ToolStripSeparator2, Me.ToolExcel, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator4, Me.ToolStripButton3, Me.ToolStripSeparator3, Me.ToolExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 27)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(978, 25)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 141
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolReflsh
        '
        Me.ToolReflsh.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToolReflsh.Image = CType(resources.GetObject("ToolReflsh.Image"), System.Drawing.Image)
        Me.ToolReflsh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolReflsh.Name = "ToolReflsh"
        Me.ToolReflsh.Size = New System.Drawing.Size(61, 22)
        Me.ToolReflsh.Text = "刷    新"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolExcel
        '
        Me.ToolExcel.Image = CType(resources.GetObject("ToolExcel.Image"), System.Drawing.Image)
        Me.ToolExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolExcel.Name = "ToolExcel"
        Me.ToolExcel.Size = New System.Drawing.Size(52, 22)
        Me.ToolExcel.Text = "汇出"
        Me.ToolExcel.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(61, 22)
        Me.ToolStripButton1.Text = "修    改"
        Me.ToolStripButton1.ToolTipText = "修    改"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Enabled = False
        Me.ToolStripButton2.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(61, 22)
        Me.ToolStripButton2.Text = "取    消"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Enabled = False
        Me.ToolStripButton3.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(61, 22)
        Me.ToolStripButton3.Text = "保    存"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolExit
        '
        Me.ToolExit.Image = CType(resources.GetObject("ToolExit.Image"), System.Drawing.Image)
        Me.ToolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolExit.Name = "ToolExit"
        Me.ToolExit.Size = New System.Drawing.Size(68, 22)
        Me.ToolExit.Text = "退    出"
        '
        'DgMoData
        '
        Me.DgMoData.AllowUserToAddRows = False
        Me.DgMoData.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.DgMoData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgMoData.BackgroundColor = System.Drawing.Color.White
        Me.DgMoData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgMoData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.DgMoData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgMoData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgMoData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgMoData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColIqty, Me.ColOqty, Me.ColNqty, Me.ColYield})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgMoData.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgMoData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgMoData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DgMoData.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.DgMoData.Location = New System.Drawing.Point(0, 0)
        Me.DgMoData.MultiSelect = False
        Me.DgMoData.Name = "DgMoData"
        Me.DgMoData.ReadOnly = True
        Me.DgMoData.RowHeadersWidth = 4
        Me.DgMoData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgMoData.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DgMoData.RowTemplate.Height = 24
        Me.DgMoData.RowTemplate.ReadOnly = True
        Me.DgMoData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgMoData.ShowEditingIcon = False
        Me.DgMoData.Size = New System.Drawing.Size(419, 285)
        Me.DgMoData.TabIndex = 144
        '
        'ColIqty
        '
        Me.ColIqty.HeaderText = "投入数量"
        Me.ColIqty.Name = "ColIqty"
        Me.ColIqty.ReadOnly = True
        '
        'ColOqty
        '
        Me.ColOqty.HeaderText = "产出数量"
        Me.ColOqty.Name = "ColOqty"
        Me.ColOqty.ReadOnly = True
        '
        'ColNqty
        '
        Me.ColNqty.HeaderText = "不良品数量"
        Me.ColNqty.Name = "ColNqty"
        Me.ColNqty.ReadOnly = True
        '
        'ColYield
        '
        Me.ColYield.HeaderText = "投入产出率"
        Me.ColYield.Name = "ColYield"
        Me.ColYield.ReadOnly = True
        '
        'DtEnd
        '
        Me.DtEnd.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.DtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtEnd.Location = New System.Drawing.Point(289, 85)
        Me.DtEnd.Name = "DtEnd"
        Me.DtEnd.Size = New System.Drawing.Size(165, 21)
        Me.DtEnd.TabIndex = 146
        Me.DtEnd.Value = New Date(2007, 5, 22, 0, 0, 0, 0)
        '
        'DtStar
        '
        Me.DtStar.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.DtStar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtStar.Location = New System.Drawing.Point(87, 85)
        Me.DtStar.Name = "DtStar"
        Me.DtStar.Size = New System.Drawing.Size(168, 21)
        Me.DtStar.TabIndex = 145
        Me.DtStar.Value = New Date(2007, 5, 22, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(22, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 147
        Me.Label6.Text = "起止时间："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "投入数量："
        '
        'TxtIqty
        '
        Me.TxtIqty.Enabled = False
        Me.TxtIqty.Location = New System.Drawing.Point(87, 120)
        Me.TxtIqty.Name = "TxtIqty"
        Me.TxtIqty.Size = New System.Drawing.Size(168, 21)
        Me.TxtIqty.TabIndex = 149
        '
        'TxtOqty
        '
        Me.TxtOqty.Enabled = False
        Me.TxtOqty.Location = New System.Drawing.Point(341, 121)
        Me.TxtOqty.Name = "TxtOqty"
        Me.TxtOqty.Size = New System.Drawing.Size(168, 21)
        Me.TxtOqty.TabIndex = 151
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(276, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 150
        Me.Label2.Text = "产出数量："
        '
        'TxtNqty
        '
        Me.TxtNqty.Enabled = False
        Me.TxtNqty.Location = New System.Drawing.Point(599, 120)
        Me.TxtNqty.Name = "TxtNqty"
        Me.TxtNqty.Size = New System.Drawing.Size(168, 21)
        Me.TxtNqty.TabIndex = 153
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(534, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 152
        Me.Label3.Text = "不良品数："
        '
        'TxtYield
        '
        Me.TxtYield.Enabled = False
        Me.TxtYield.Location = New System.Drawing.Point(87, 147)
        Me.TxtYield.Name = "TxtYield"
        Me.TxtYield.Size = New System.Drawing.Size(168, 21)
        Me.TxtYield.TabIndex = 155
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 12)
        Me.Label4.TabIndex = 154
        Me.Label4.Text = "投入产出率："
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 174)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DgMoData)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgOK)
        Me.SplitContainer1.Size = New System.Drawing.Size(978, 285)
        Me.SplitContainer1.SplitterDistance = 419
        Me.SplitContainer1.TabIndex = 156
        '
        'DgOK
        '
        Me.DgOK.AllowUserToAddRows = False
        Me.DgOK.AllowUserToDeleteRows = False
        Me.DgOK.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue
        Me.DgOK.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DgOK.BackgroundColor = System.Drawing.Color.White
        Me.DgOK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgOK.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.DgOK.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle5.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgOK.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DgOK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgOK.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgOK.DefaultCellStyle = DataGridViewCellStyle6
        Me.DgOK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgOK.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DgOK.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.DgOK.Location = New System.Drawing.Point(0, 0)
        Me.DgOK.MultiSelect = False
        Me.DgOK.Name = "DgOK"
        Me.DgOK.ReadOnly = True
        Me.DgOK.RowHeadersWidth = 4
        Me.DgOK.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgOK.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DgOK.RowTemplate.Height = 24
        Me.DgOK.RowTemplate.ReadOnly = True
        Me.DgOK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgOK.ShowEditingIcon = False
        Me.DgOK.Size = New System.Drawing.Size(555, 285)
        Me.DgOK.TabIndex = 145
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "投入数量"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "产出数量"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "不良品数量"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "投入产出率"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'FrmKpartYield
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 484)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TxtYield)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtNqty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtOqty)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtIqty)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DtEnd)
        Me.Controls.Add(Me.DtStar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmKpartYield"
        Me.Text = "关键物料生产状况报表"
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DgMoData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DgOK, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolReflsh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents DgMoData As System.Windows.Forms.DataGridView
    Friend WithEvents DtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtStar As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtIqty As System.Windows.Forms.TextBox
    Friend WithEvents TxtOqty As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtNqty As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtYield As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ColIqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColYield As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DgOK As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
