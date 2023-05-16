<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImport))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolImport = New System.Windows.Forms.ToolStripComboBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboQueryType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DtEnd = New System.Windows.Forms.DateTimePicker()
        Me.DtStar = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.UserinfDg = New System.Windows.Forms.DataGridView()
        Me.ToolNew = New System.Windows.Forms.ToolStripButton()
        Me.toolDelete = New System.Windows.Forms.ToolStripButton()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.toolLoadMoBan = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.UserinfDg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNew, Me.toolDelete, Me.ToolStripSeparator6, Me.toolQuery, Me.ToolStripSeparator7, Me.toolExit, Me.toolLoadMoBan, Me.toolImport})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(927, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'toolImport
        '
        Me.toolImport.Name = "toolImport"
        Me.toolImport.Size = New System.Drawing.Size(130, 25)
        Me.toolImport.Tag = ""
        Me.toolImport.Visible = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboQueryType)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DtEnd)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DtStar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.UserinfDg)
        Me.SplitContainer1.Size = New System.Drawing.Size(927, 396)
        Me.SplitContainer1.SplitterDistance = 40
        Me.SplitContainer1.TabIndex = 4
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(277, 9)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(175, 21)
        Me.TextBox1.TabIndex = 152
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(206, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 151
        Me.Label1.Text = "出货单号："
        '
        'cboQueryType
        '
        Me.cboQueryType.BackColor = System.Drawing.Color.White
        Me.cboQueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboQueryType.FormattingEnabled = True
        Me.cboQueryType.Location = New System.Drawing.Point(79, 10)
        Me.cboQueryType.Name = "cboQueryType"
        Me.cboQueryType.Size = New System.Drawing.Size(119, 20)
        Me.cboQueryType.TabIndex = 149
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 150
        Me.Label4.Text = "查询类型："
        '
        'DtEnd
        '
        Me.DtEnd.CustomFormat = "yyyy/MM/dd"
        Me.DtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtEnd.Location = New System.Drawing.Point(723, 7)
        Me.DtEnd.Name = "DtEnd"
        Me.DtEnd.Size = New System.Drawing.Size(169, 21)
        Me.DtEnd.TabIndex = 92
        Me.DtEnd.Value = New Date(2014, 6, 20, 0, 0, 0, 0)
        '
        'DtStar
        '
        Me.DtStar.CustomFormat = "yyyy/MM/dd"
        Me.DtStar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtStar.Location = New System.Drawing.Point(546, 7)
        Me.DtStar.Name = "DtStar"
        Me.DtStar.Size = New System.Drawing.Size(155, 21)
        Me.DtStar.TabIndex = 91
        Me.DtStar.Value = New Date(2007, 5, 23, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(482, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 93
        Me.Label6.Text = "起始时间："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(704, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 12)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = "至 "
        '
        'UserinfDg
        '
        Me.UserinfDg.AllowUserToAddRows = False
        Me.UserinfDg.AllowUserToDeleteRows = False
        Me.UserinfDg.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.UserinfDg.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.UserinfDg.BackgroundColor = System.Drawing.Color.White
        Me.UserinfDg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.UserinfDg.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.UserinfDg.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UserinfDg.DefaultCellStyle = DataGridViewCellStyle3
        Me.UserinfDg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UserinfDg.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.UserinfDg.EnableHeadersVisualStyles = False
        Me.UserinfDg.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.UserinfDg.Location = New System.Drawing.Point(0, 0)
        Me.UserinfDg.MultiSelect = False
        Me.UserinfDg.Name = "UserinfDg"
        Me.UserinfDg.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.UserinfDg.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.UserinfDg.RowHeadersWidth = 4
        Me.UserinfDg.RowTemplate.Height = 24
        Me.UserinfDg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.UserinfDg.ShowEditingIcon = False
        Me.UserinfDg.Size = New System.Drawing.Size(927, 352)
        Me.UserinfDg.TabIndex = 114
        Me.UserinfDg.TabStop = False
        '
        'ToolNew
        '
        Me.ToolNew.Image = CType(resources.GetObject("ToolNew.Image"), System.Drawing.Image)
        Me.ToolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolNew.Name = "ToolNew"
        Me.ToolNew.Size = New System.Drawing.Size(70, 22)
        Me.ToolNew.Text = "新增(&N)"
        '
        'toolDelete
        '
        Me.toolDelete.Image = CType(resources.GetObject("toolDelete.Image"), System.Drawing.Image)
        Me.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolDelete.Name = "toolDelete"
        Me.toolDelete.Size = New System.Drawing.Size(73, 22)
        Me.toolDelete.Text = "作 废(&D)"
        '
        'toolQuery
        '
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(70, 22)
        Me.toolQuery.Text = "查 询(&F)"
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(52, 22)
        Me.toolExit.Text = "退出"
        '
        'toolLoadMoBan
        '
        Me.toolLoadMoBan.Image = CType(resources.GetObject("toolLoadMoBan.Image"), System.Drawing.Image)
        Me.toolLoadMoBan.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolLoadMoBan.Name = "toolLoadMoBan"
        Me.toolLoadMoBan.Size = New System.Drawing.Size(136, 22)
        Me.toolLoadMoBan.Text = "下载出货单导入模板"
        '
        'FrmImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 421)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmImport"
        Me.Text = "出货单导入"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.UserinfDg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImport As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtStar As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboQueryType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents UserinfDg As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents toolLoadMoBan As System.Windows.Forms.ToolStripButton
End Class
