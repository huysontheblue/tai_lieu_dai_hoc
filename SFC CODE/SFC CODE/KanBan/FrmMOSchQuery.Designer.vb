<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMOSchQuery
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMOSchQuery))
        Me.txtMultiMO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DtEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgMOSchDetail = New System.Windows.Forms.DataGridView()
        Me.DtStar = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.txtPartNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbbLine = New System.Windows.Forms.ComboBox()
        Me.cbbDept = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.DgMoData = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ToolCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbDetail = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExit = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.MOID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dqc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lineid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.leadername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Station = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OutQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Moqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NGQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NgRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgMOSchDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.DgMoData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.menuStrip1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtMultiMO
        '
        Me.txtMultiMO.Location = New System.Drawing.Point(538, 7)
        Me.txtMultiMO.MaxLength = 9999
        Me.txtMultiMO.Multiline = True
        Me.txtMultiMO.Name = "txtMultiMO"
        Me.txtMultiMO.Size = New System.Drawing.Size(138, 52)
        Me.txtMultiMO.TabIndex = 202
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(477, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 203
        Me.Label3.Text = "工单编号："
        '
        'DtEnd
        '
        Me.DtEnd.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.DtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtEnd.Location = New System.Drawing.Point(305, 7)
        Me.DtEnd.Name = "DtEnd"
        Me.DtEnd.Size = New System.Drawing.Size(138, 21)
        Me.DtEnd.TabIndex = 198
        Me.DtEnd.Value = New Date(2007, 5, 23, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(268, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 199
        Me.Label5.Text = "至"
        '
        'dgMOSchDetail
        '
        Me.dgMOSchDetail.AllowUserToAddRows = False
        Me.dgMOSchDetail.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgMOSchDetail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgMOSchDetail.BackgroundColor = System.Drawing.Color.White
        Me.dgMOSchDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgMOSchDetail.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgMOSchDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMOSchDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMOSchDetail.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgMOSchDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgMOSchDetail.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.dgMOSchDetail.Location = New System.Drawing.Point(0, 21)
        Me.dgMOSchDetail.MultiSelect = False
        Me.dgMOSchDetail.Name = "dgMOSchDetail"
        Me.dgMOSchDetail.ReadOnly = True
        Me.dgMOSchDetail.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMOSchDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgMOSchDetail.RowHeadersWidth = 4
        Me.dgMOSchDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgMOSchDetail.RowTemplate.Height = 24
        Me.dgMOSchDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgMOSchDetail.ShowEditingIcon = False
        Me.dgMOSchDetail.Size = New System.Drawing.Size(1235, 158)
        Me.dgMOSchDetail.TabIndex = 173
        Me.dgMOSchDetail.TabStop = False
        '
        'DtStar
        '
        Me.DtStar.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.DtStar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtStar.Location = New System.Drawing.Point(97, 7)
        Me.DtStar.Name = "DtStar"
        Me.DtStar.Size = New System.Drawing.Size(138, 21)
        Me.DtStar.TabIndex = 190
        Me.DtStar.Value = New Date(2007, 5, 23, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(35, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 192
        Me.Label6.Text = "起始时间："
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblInfo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblMsg)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtPartNo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbbLine)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbbDept)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMultiMO)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DtEnd)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DtStar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1235, 431)
        Me.SplitContainer1.SplitterDistance = 81
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 196
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.ForeColor = System.Drawing.Color.Red
        Me.lblInfo.Location = New System.Drawing.Point(721, 44)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(11, 12)
        Me.lblInfo.TabIndex = 218
        Me.lblInfo.Text = "-"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(720, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 12)
        Me.Label8.TabIndex = 217
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Location = New System.Drawing.Point(916, 44)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(0, 12)
        Me.lblMsg.TabIndex = 216
        '
        'txtPartNo
        '
        Me.txtPartNo.Location = New System.Drawing.Point(759, 8)
        Me.txtPartNo.MaxLength = 50
        Me.txtPartNo.Name = "txtPartNo"
        Me.txtPartNo.Size = New System.Drawing.Size(138, 21)
        Me.txtPartNo.TabIndex = 214
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(698, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 215
        Me.Label2.Text = "料件编号："
        '
        'cbbLine
        '
        Me.cbbLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbbLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbbLine.FormattingEnabled = True
        Me.cbbLine.Location = New System.Drawing.Point(305, 37)
        Me.cbbLine.Name = "cbbLine"
        Me.cbbLine.Size = New System.Drawing.Size(138, 20)
        Me.cbbLine.TabIndex = 213
        '
        'cbbDept
        '
        Me.cbbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbDept.FormattingEnabled = True
        Me.cbbDept.Location = New System.Drawing.Point(97, 37)
        Me.cbbDept.Name = "cbbDept"
        Me.cbbDept.Size = New System.Drawing.Size(138, 20)
        Me.cbbDept.TabIndex = 212
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 211
        Me.Label4.Text = "生产部门："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(268, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 210
        Me.Label1.Text = "线别："
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.DgMoData)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label7)
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgMOSchDetail)
        Me.SplitContainer2.Size = New System.Drawing.Size(1235, 349)
        Me.SplitContainer2.SplitterDistance = 156
        Me.SplitContainer2.TabIndex = 0
        '
        'DgMoData
        '
        Me.DgMoData.AllowUserToAddRows = False
        Me.DgMoData.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue
        Me.DgMoData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgMoData.BackgroundColor = System.Drawing.Color.White
        Me.DgMoData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgMoData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.DgMoData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle6.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgMoData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgMoData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MOID, Me.PartID, Me.dqc, Me.Lineid, Me.leadername, Me.Column1, Me.Station, Me.InQty, Me.OutQty, Me.Moqty, Me.NGQty, Me.NgRate, Me.Column3, Me.Column2})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgMoData.DefaultCellStyle = DataGridViewCellStyle7
        Me.DgMoData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgMoData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DgMoData.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.DgMoData.Location = New System.Drawing.Point(0, 0)
        Me.DgMoData.MultiSelect = False
        Me.DgMoData.Name = "DgMoData"
        Me.DgMoData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgMoData.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DgMoData.RowHeadersWidth = 4
        Me.DgMoData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgMoData.RowTemplate.Height = 24
        Me.DgMoData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgMoData.ShowEditingIcon = False
        Me.DgMoData.Size = New System.Drawing.Size(1235, 156)
        Me.DgMoData.TabIndex = 173
        Me.DgMoData.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(119, 12)
        Me.Label7.TabIndex = 174
        Me.Label7.Text = "该工单明细内容如下:"
        '
        'ToolCount
        '
        Me.ToolCount.BackColor = System.Drawing.SystemColors.Control
        Me.ToolCount.Name = "ToolCount"
        Me.ToolCount.Size = New System.Drawing.Size(15, 17)
        Me.ToolCount.Text = "0"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(59, 17)
        Me.ToolStripStatusLabel1.Text = "記錄筆數:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1235, 22)
        Me.StatusStrip1.TabIndex = 195
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'menuStrip1
        '
        Me.menuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.menuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2, Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5, Me.toolStripMenuItem6})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(1235, 25)
        Me.menuStrip1.TabIndex = 197
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
        'toolStrip1
        '
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolQuery, Me.ToolStripSeparator1, Me.ToolExcel, Me.ToolStripSeparator3, Me.tsbDetail, Me.ToolStripSeparator2, Me.ToolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1235, 29)
        Me.toolStrip1.TabIndex = 223
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolQuery
        '
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(76, 26)
        Me.toolQuery.Text = "查  询(&F)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'ToolExcel
        '
        Me.ToolExcel.Image = CType(resources.GetObject("ToolExcel.Image"), System.Drawing.Image)
        Me.ToolExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolExcel.Name = "ToolExcel"
        Me.ToolExcel.Size = New System.Drawing.Size(76, 26)
        Me.ToolExcel.Text = "汇出统计"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbDetail
        '
        Me.tsbDetail.Image = CType(resources.GetObject("tsbDetail.Image"), System.Drawing.Image)
        Me.tsbDetail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDetail.Name = "tsbDetail"
        Me.tsbDetail.Size = New System.Drawing.Size(76, 26)
        Me.tsbDetail.Text = "汇出明细"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'ToolExit
        '
        Me.ToolExit.Image = CType(resources.GetObject("ToolExit.Image"), System.Drawing.Image)
        Me.ToolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolExit.Name = "ToolExit"
        Me.ToolExit.Size = New System.Drawing.Size(72, 26)
        Me.ToolExit.Text = "退 出(&X)"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.MenuStrip2)
        Me.SplitContainer3.Panel1.Controls.Add(Me.toolStrip1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer3.Size = New System.Drawing.Size(1235, 489)
        Me.SplitContainer3.SplitterDistance = 57
        Me.SplitContainer3.SplitterWidth = 1
        Me.SplitContainer3.TabIndex = 224
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem7, Me.ToolStripMenuItem8, Me.ToolStripMenuItem9, Me.ToolStripMenuItem10, Me.ToolStripMenuItem11, Me.ToolStripMenuItem12})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(1235, 25)
        Me.MenuStrip2.TabIndex = 224
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(59, 21)
        Me.ToolStripMenuItem7.Text = "系统(&S)"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(58, 21)
        Me.ToolStripMenuItem8.Text = "文件(&F)"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(60, 21)
        Me.ToolStripMenuItem9.Text = "查看(&V)"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(59, 21)
        Me.ToolStripMenuItem10.Text = "工具(&T)"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(64, 21)
        Me.ToolStripMenuItem11.Text = "窗口(&W)"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(61, 21)
        Me.ToolStripMenuItem12.Text = "帮助(&H)"
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.StatusStrip1)
        Me.ToolStripContainer1.BottomToolStripPanelVisible = False
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.AutoScroll = True
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.SplitContainer3)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(1235, 489)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(1235, 489)
        Me.ToolStripContainer1.TabIndex = 225
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.menuStrip1)
        Me.ToolStripContainer1.TopToolStripPanelVisible = False
        '
        'MOID
        '
        Me.MOID.DataPropertyName = "Moid"
        Me.MOID.HeaderText = "工单编号"
        Me.MOID.Name = "MOID"
        Me.MOID.ReadOnly = True
        Me.MOID.Width = 120
        '
        'PartID
        '
        Me.PartID.DataPropertyName = "PartID"
        Me.PartID.HeaderText = "料件编号"
        Me.PartID.Name = "PartID"
        Me.PartID.ReadOnly = True
        '
        'dqc
        '
        Me.dqc.DataPropertyName = "dqc"
        Me.dqc.HeaderText = "生产部门"
        Me.dqc.Name = "dqc"
        Me.dqc.ReadOnly = True
        '
        'Lineid
        '
        Me.Lineid.DataPropertyName = "Lineid"
        Me.Lineid.HeaderText = "线别"
        Me.Lineid.Name = "Lineid"
        Me.Lineid.ReadOnly = True
        '
        'leadername
        '
        Me.leadername.DataPropertyName = "leadername"
        Me.leadername.HeaderText = "线长"
        Me.leadername.Name = "leadername"
        Me.leadername.ReadOnly = True
        Me.leadername.Width = 80
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "telphone"
        Me.Column1.HeaderText = "线长电话"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Station
        '
        Me.Station.DataPropertyName = "Station"
        Me.Station.HeaderText = "工站名称"
        Me.Station.Name = "Station"
        Me.Station.ReadOnly = True
        Me.Station.Width = 120
        '
        'InQty
        '
        Me.InQty.DataPropertyName = "InQty"
        Me.InQty.HeaderText = "投入数量"
        Me.InQty.Name = "InQty"
        Me.InQty.ReadOnly = True
        '
        'OutQty
        '
        Me.OutQty.DataPropertyName = "OutQty"
        Me.OutQty.HeaderText = "产出数量"
        Me.OutQty.Name = "OutQty"
        Me.OutQty.ReadOnly = True
        '
        'Moqty
        '
        Me.Moqty.DataPropertyName = "MoQty"
        Me.Moqty.HeaderText = "计划数量"
        Me.Moqty.Name = "Moqty"
        Me.Moqty.ReadOnly = True
        '
        'NGQty
        '
        Me.NGQty.DataPropertyName = "NGQty"
        Me.NGQty.HeaderText = "不良数量"
        Me.NGQty.Name = "NGQty"
        Me.NGQty.ReadOnly = True
        '
        'NgRate
        '
        Me.NgRate.DataPropertyName = "NgRate"
        Me.NgRate.HeaderText = "不良率"
        Me.NgRate.Name = "NgRate"
        Me.NgRate.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "ScheFinishDate"
        Me.Column3.HeaderText = "工单预计交货日期"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "leaderid"
        Me.Column2.HeaderText = "线长工号"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        '
        'FrmMOSchQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1235, 489)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "FrmMOSchQuery"
        Me.Text = "工单生产进度查询"
        CType(Me.dgMOSchDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.DgMoData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtMultiMO As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgMOSchDetail As System.Windows.Forms.DataGridView
    Friend WithEvents DtStar As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents DgMoData As System.Windows.Forms.DataGridView
    Friend WithEvents ToolCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents txtPartNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbbLine As System.Windows.Forms.ComboBox
    Friend WithEvents cbbDept As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExcel As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbDetail As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ToolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Private WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Private WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem12 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MOID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dqc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lineid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents leadername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Station As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NGQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NgRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
