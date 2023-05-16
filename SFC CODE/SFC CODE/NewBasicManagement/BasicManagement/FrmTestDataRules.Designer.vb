<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTestDataRules
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTestDataRules))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolAdd = New System.Windows.Forms.ToolStripButton()
        Me.toolEdit = New System.Windows.Forms.ToolStripButton()
        Me.toolDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.toolBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtcompletecross = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txttestcount = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtprogroup = New System.Windows.Forms.TextBox()
        Me.txtstationseq = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcheckfuction = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.chkUsey = New System.Windows.Forms.CheckBox()
        Me.cbbdatabase = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSelectSql = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtKeyIndex = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtKeyFileld = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DgList = New System.Windows.Forms.DataGridView()
        Me.txtSaveTableName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDocumentType = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTestTypeName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTestTypeid = New System.Windows.Forms.TextBox()
        Me.lable1 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TestTypeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TestTypeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocumentType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SelectSql = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaveTableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KeyFileld = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KeyIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StationSEQ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Productgroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.checkfunction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CompleteProcess = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolStrip1
        '
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAdd, Me.toolEdit, Me.toolDelete, Me.ToolStripSeparator1, Me.toolSave, Me.toolBack, Me.ToolStripSeparator2, Me.toolQuery, Me.toolStripSeparator4, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1275, 25)
        Me.toolStrip1.TabIndex = 131
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolAdd
        '
        Me.toolAdd.Image = CType(resources.GetObject("toolAdd.Image"), System.Drawing.Image)
        Me.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAdd.Name = "toolAdd"
        Me.toolAdd.Size = New System.Drawing.Size(74, 22)
        Me.toolAdd.Tag = "NO"
        Me.toolAdd.Text = "新 增(&N)"
        '
        'toolEdit
        '
        Me.toolEdit.Image = CType(resources.GetObject("toolEdit.Image"), System.Drawing.Image)
        Me.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEdit.Name = "toolEdit"
        Me.toolEdit.Size = New System.Drawing.Size(71, 22)
        Me.toolEdit.Tag = "NO"
        Me.toolEdit.Text = "修 改(&E)"
        '
        'toolDelete
        '
        Me.toolDelete.Image = CType(resources.GetObject("toolDelete.Image"), System.Drawing.Image)
        Me.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolDelete.Name = "toolDelete"
        Me.toolDelete.Size = New System.Drawing.Size(73, 22)
        Me.toolDelete.Tag = "NO"
        Me.toolDelete.Text = "作 废(&D)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolSave
        '
        Me.toolSave.Image = CType(resources.GetObject("toolSave.Image"), System.Drawing.Image)
        Me.toolSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(73, 22)
        Me.toolSave.Tag = ""
        Me.toolSave.Text = "保 存(&S)"
        '
        'toolBack
        '
        Me.toolBack.Image = CType(resources.GetObject("toolBack.Image"), System.Drawing.Image)
        Me.toolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBack.Name = "toolBack"
        Me.toolBack.Size = New System.Drawing.Size(72, 22)
        Me.toolBack.Tag = ""
        Me.toolBack.Text = "返 回(&B)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(72, 22)
        Me.toolExit.Text = "退 出(&X)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.StatusStrip1)
        Me.GroupBox1.Controls.Add(Me.txtcompletecross)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txttestcount)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtprogroup)
        Me.GroupBox1.Controls.Add(Me.txtstationseq)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtcheckfuction)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.LblMsg)
        Me.GroupBox1.Controls.Add(Me.chkUsey)
        Me.GroupBox1.Controls.Add(Me.cbbdatabase)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtSelectSql)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtKeyIndex)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtKeyFileld)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.DgList)
        Me.GroupBox1.Controls.Add(Me.txtSaveTableName)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtDocumentType)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtTestTypeName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtTestTypeid)
        Me.GroupBox1.Controls.Add(Me.lable1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1275, 434)
        Me.GroupBox1.TabIndex = 132
        Me.GroupBox1.TabStop = False
        '
        'txtcompletecross
        '
        Me.txtcompletecross.Location = New System.Drawing.Point(901, 76)
        Me.txtcompletecross.Name = "txtcompletecross"
        Me.txtcompletecross.Size = New System.Drawing.Size(217, 21)
        Me.txtcompletecross.TabIndex = 174
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(830, 82)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 12)
        Me.Label12.TabIndex = 173
        Me.Label12.Text = "执行函数："
        '
        'txttestcount
        '
        Me.txttestcount.Location = New System.Drawing.Point(736, 76)
        Me.txttestcount.Name = "txttestcount"
        Me.txttestcount.Size = New System.Drawing.Size(75, 21)
        Me.txttestcount.TabIndex = 172
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(651, 82)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 12)
        Me.Label11.TabIndex = 171
        Me.Label11.Text = "最大测试次数："
        '
        'txtprogroup
        '
        Me.txtprogroup.Location = New System.Drawing.Point(556, 76)
        Me.txtprogroup.Name = "txtprogroup"
        Me.txtprogroup.Size = New System.Drawing.Size(75, 21)
        Me.txtprogroup.TabIndex = 170
        '
        'txtstationseq
        '
        Me.txtstationseq.Location = New System.Drawing.Point(334, 76)
        Me.txtstationseq.Name = "txtstationseq"
        Me.txtstationseq.Size = New System.Drawing.Size(165, 21)
        Me.txtstationseq.TabIndex = 168
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(509, 82)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 12)
        Me.Label10.TabIndex = 169
        Me.Label10.Text = "群组："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(263, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 167
        Me.Label3.Text = "站点顺序："
        '
        'txtcheckfuction
        '
        Me.txtcheckfuction.Location = New System.Drawing.Point(73, 76)
        Me.txtcheckfuction.Name = "txtcheckfuction"
        Me.txtcheckfuction.Size = New System.Drawing.Size(165, 21)
        Me.txtcheckfuction.TabIndex = 166
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 165
        Me.Label2.Text = "检查函数："
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblMsg.Location = New System.Drawing.Point(1132, 71)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(20, 17)
        Me.LblMsg.TabIndex = 164
        Me.LblMsg.Text = "..."
        '
        'chkUsey
        '
        Me.chkUsey.AutoSize = True
        Me.chkUsey.Checked = True
        Me.chkUsey.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUsey.Location = New System.Drawing.Point(1135, 50)
        Me.chkUsey.Name = "chkUsey"
        Me.chkUsey.Size = New System.Drawing.Size(72, 16)
        Me.chkUsey.TabIndex = 163
        Me.chkUsey.Text = "是否有效"
        Me.chkUsey.UseVisualStyleBackColor = True
        '
        'cbbdatabase
        '
        Me.cbbdatabase.FormattingEnabled = True
        Me.cbbdatabase.Location = New System.Drawing.Point(963, 17)
        Me.cbbdatabase.Name = "cbbdatabase"
        Me.cbbdatabase.Size = New System.Drawing.Size(155, 20)
        Me.cbbdatabase.TabIndex = 159
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(904, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 158
        Me.Label9.Text = "数据库："
        '
        'txtSelectSql
        '
        Me.txtSelectSql.Location = New System.Drawing.Point(567, 44)
        Me.txtSelectSql.Multiline = True
        Me.txtSelectSql.Name = "txtSelectSql"
        Me.txtSelectSql.Size = New System.Drawing.Size(551, 21)
        Me.txtSelectSql.TabIndex = 157
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(509, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 12)
        Me.Label8.TabIndex = 156
        Me.Label8.Text = "查询sql："
        '
        'txtKeyIndex
        '
        Me.txtKeyIndex.Location = New System.Drawing.Point(334, 44)
        Me.txtKeyIndex.Name = "txtKeyIndex"
        Me.txtKeyIndex.Size = New System.Drawing.Size(165, 21)
        Me.txtKeyIndex.TabIndex = 155
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(251, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 12)
        Me.Label7.TabIndex = 154
        Me.Label7.Text = "主键栏位位置："
        '
        'txtKeyFileld
        '
        Me.txtKeyFileld.Location = New System.Drawing.Point(73, 44)
        Me.txtKeyFileld.Name = "txtKeyFileld"
        Me.txtKeyFileld.Size = New System.Drawing.Size(165, 21)
        Me.txtKeyFileld.TabIndex = 153
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(2, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 152
        Me.Label6.Text = "主键栏位："
        '
        'DgList
        '
        Me.DgList.AllowUserToAddRows = False
        Me.DgList.AllowUserToDeleteRows = False
        Me.DgList.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        Me.DgList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgList.BackgroundColor = System.Drawing.Color.White
        Me.DgList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.DgList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TestTypeID, Me.TestTypeName, Me.DocumentType, Me.SelectSql, Me.SaveTableName, Me.KeyFileld, Me.KeyIndex, Me.StationSEQ, Me.Productgroup, Me.checkfunction, Me.CompleteProcess, Me.Usey, Me.Column10, Me.Column11})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgList.DefaultCellStyle = DataGridViewCellStyle7
        Me.DgList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DgList.GridColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.DgList.Location = New System.Drawing.Point(4, 103)
        Me.DgList.MultiSelect = False
        Me.DgList.Name = "DgList"
        Me.DgList.ReadOnly = True
        Me.DgList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgList.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DgList.RowHeadersWidth = 45
        Me.DgList.RowTemplate.Height = 24
        Me.DgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgList.ShowEditingIcon = False
        Me.DgList.Size = New System.Drawing.Size(1269, 302)
        Me.DgList.TabIndex = 151
        Me.DgList.TabStop = False
        '
        'txtSaveTableName
        '
        Me.txtSaveTableName.Location = New System.Drawing.Point(655, 16)
        Me.txtSaveTableName.Name = "txtSaveTableName"
        Me.txtSaveTableName.Size = New System.Drawing.Size(193, 21)
        Me.txtSaveTableName.TabIndex = 150
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(598, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 149
        Me.Label5.Text = "保存表："
        '
        'txtDocumentType
        '
        Me.txtDocumentType.Location = New System.Drawing.Point(507, 15)
        Me.txtDocumentType.Name = "txtDocumentType"
        Me.txtDocumentType.Size = New System.Drawing.Size(61, 21)
        Me.txtDocumentType.TabIndex = 148
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(423, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 12)
        Me.Label4.TabIndex = 147
        Me.Label4.Text = "采集文件类型："
        '
        'txtTestTypeName
        '
        Me.txtTestTypeName.Location = New System.Drawing.Point(249, 15)
        Me.txtTestTypeName.Name = "txtTestTypeName"
        Me.txtTestTypeName.Size = New System.Drawing.Size(165, 21)
        Me.txtTestTypeName.TabIndex = 142
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(164, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 12)
        Me.Label1.TabIndex = 141
        Me.Label1.Text = "测试站点名称："
        '
        'txtTestTypeid
        '
        Me.txtTestTypeid.Location = New System.Drawing.Point(73, 15)
        Me.txtTestTypeid.Name = "txtTestTypeid"
        Me.txtTestTypeid.Size = New System.Drawing.Size(75, 21)
        Me.txtTestTypeid.TabIndex = 140
        '
        'lable1
        '
        Me.lable1.AutoSize = True
        Me.lable1.Location = New System.Drawing.Point(12, 20)
        Me.lable1.Name = "lable1"
        Me.lable1.Size = New System.Drawing.Size(65, 12)
        Me.lable1.TabIndex = 139
        Me.lable1.Text = "测试站点："
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "TestTypeID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "测试站点"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "TestTypeName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "测试站点名称"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "NetSavePath"
        Me.DataGridViewTextBoxColumn3.HeaderText = "服务器采集路径"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "NetMovePath"
        Me.DataGridViewTextBoxColumn4.HeaderText = "转移路径"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "DocumentType"
        Me.DataGridViewTextBoxColumn5.HeaderText = "采集文件类型"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "SelectSql"
        Me.DataGridViewTextBoxColumn6.HeaderText = "查询sql"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "SaveTableName"
        Me.DataGridViewTextBoxColumn7.HeaderText = "默认保存表"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Usey"
        Me.DataGridViewTextBoxColumn8.HeaderText = "是否有效"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "KeyFileld"
        Me.DataGridViewTextBoxColumn9.HeaderText = "主键栏位"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "KeyIndex"
        Me.DataGridViewTextBoxColumn10.HeaderText = "主键栏位位置"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Userid"
        Me.DataGridViewTextBoxColumn11.HeaderText = "创建人"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Intime"
        Me.DataGridViewTextBoxColumn12.HeaderText = "创建时间"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.ToolCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 409)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1269, 22)
        Me.StatusStrip1.TabIndex = 175
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
        'TestTypeID
        '
        Me.TestTypeID.DataPropertyName = "TestTypeID"
        Me.TestTypeID.HeaderText = "测试站点"
        Me.TestTypeID.Name = "TestTypeID"
        Me.TestTypeID.ReadOnly = True
        Me.TestTypeID.Width = 77
        '
        'TestTypeName
        '
        Me.TestTypeName.DataPropertyName = "TestTypeName"
        Me.TestTypeName.HeaderText = "测试站点名称"
        Me.TestTypeName.Name = "TestTypeName"
        Me.TestTypeName.ReadOnly = True
        Me.TestTypeName.Width = 77
        '
        'DocumentType
        '
        Me.DocumentType.DataPropertyName = "DocumentType"
        Me.DocumentType.HeaderText = "采集文件类型"
        Me.DocumentType.Name = "DocumentType"
        Me.DocumentType.ReadOnly = True
        Me.DocumentType.Width = 78
        '
        'SelectSql
        '
        Me.SelectSql.DataPropertyName = "SelectSql"
        Me.SelectSql.HeaderText = "查询sql"
        Me.SelectSql.Name = "SelectSql"
        Me.SelectSql.ReadOnly = True
        Me.SelectSql.Width = 77
        '
        'SaveTableName
        '
        Me.SaveTableName.DataPropertyName = "SaveTableName"
        Me.SaveTableName.HeaderText = "保存表"
        Me.SaveTableName.Name = "SaveTableName"
        Me.SaveTableName.ReadOnly = True
        Me.SaveTableName.Width = 77
        '
        'KeyFileld
        '
        Me.KeyFileld.DataPropertyName = "KeyFileld"
        Me.KeyFileld.HeaderText = "主键"
        Me.KeyFileld.Name = "KeyFileld"
        Me.KeyFileld.ReadOnly = True
        Me.KeyFileld.Width = 78
        '
        'KeyIndex
        '
        Me.KeyIndex.DataPropertyName = "KeyIndex"
        Me.KeyIndex.HeaderText = "主键栏位位置"
        Me.KeyIndex.Name = "KeyIndex"
        Me.KeyIndex.ReadOnly = True
        Me.KeyIndex.Width = 77
        '
        'StationSEQ
        '
        Me.StationSEQ.DataPropertyName = "StationSEQ"
        Me.StationSEQ.HeaderText = "站点顺序"
        Me.StationSEQ.Name = "StationSEQ"
        Me.StationSEQ.ReadOnly = True
        Me.StationSEQ.Width = 77
        '
        'Productgroup
        '
        Me.Productgroup.DataPropertyName = "ProductGroup"
        Me.Productgroup.HeaderText = "群组"
        Me.Productgroup.Name = "Productgroup"
        Me.Productgroup.ReadOnly = True
        Me.Productgroup.Width = 77
        '
        'checkfunction
        '
        Me.checkfunction.DataPropertyName = "CheckFunction"
        Me.checkfunction.HeaderText = "检查函数"
        Me.checkfunction.Name = "checkfunction"
        Me.checkfunction.ReadOnly = True
        Me.checkfunction.Width = 77
        '
        'CompleteProcess
        '
        Me.CompleteProcess.DataPropertyName = "CompleteProcess"
        Me.CompleteProcess.HeaderText = "执行函数"
        Me.CompleteProcess.Name = "CompleteProcess"
        Me.CompleteProcess.ReadOnly = True
        Me.CompleteProcess.Width = 78
        '
        'Usey
        '
        Me.Usey.DataPropertyName = "Usey"
        Me.Usey.HeaderText = "是否有效"
        Me.Usey.Name = "Usey"
        Me.Usey.ReadOnly = True
        Me.Usey.Width = 77
        '
        'Column10
        '
        Me.Column10.DataPropertyName = "Userid"
        Me.Column10.HeaderText = "创建人"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 77
        '
        'Column11
        '
        Me.Column11.DataPropertyName = "Intime"
        Me.Column11.HeaderText = "创建时间"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 77
        '
        'FrmTestDataRules
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1275, 459)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "FrmTestDataRules"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "测试工站数据配置"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEdit As System.Windows.Forms.ToolStripButton
    Private WithEvents toolDelete As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolBack As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lable1 As System.Windows.Forms.Label
    Friend WithEvents txtTestTypeid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTestTypeName As System.Windows.Forms.TextBox
    Friend WithEvents txtSaveTableName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDocumentType As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtKeyIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtKeyFileld As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSelectSql As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DgList As System.Windows.Forms.DataGridView
    Friend WithEvents cbbdatabase As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkUsey As System.Windows.Forms.CheckBox
    Friend WithEvents LblMsg As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtstationseq As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcheckfuction As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtcompletecross As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txttestcount As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtprogroup As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TestTypeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TestTypeName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocumentType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectSql As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaveTableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KeyFileld As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KeyIndex As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StationSEQ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Productgroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents checkfunction As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CompleteProcess As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
