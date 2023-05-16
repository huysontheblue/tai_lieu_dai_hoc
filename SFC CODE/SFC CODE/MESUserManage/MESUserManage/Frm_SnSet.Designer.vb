<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SnSet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SnSet))
        Me.ComboBox_PackedId = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox_MinNum = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TextBox_PartId = New System.Windows.Forms.TextBox()
        Me.MinNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Delete = New System.Windows.Forms.ToolStripButton()
        Me.Save = New System.Windows.Forms.ToolStripButton()
        Me.EditFile = New System.Windows.Forms.ToolStripButton()
        Me.NewFile = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.toolBack = New System.Windows.Forms.ToolStripButton()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.DataRefresh = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.ToolBt.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox_PackedId
        '
        Me.ComboBox_PackedId.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboBox_PackedId.FormattingEnabled = True
        Me.ComboBox_PackedId.Items.AddRange(New Object() {"S--產品條碼", "C--小箱袋條碼", "P--大箱袋條碼"})
        Me.ComboBox_PackedId.Location = New System.Drawing.Point(88, 40)
        Me.ComboBox_PackedId.Name = "ComboBox_PackedId"
        Me.ComboBox_PackedId.Size = New System.Drawing.Size(140, 20)
        Me.ComboBox_PackedId.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "条码类型："
        '
        'TextBox_MinNum
        '
        Me.TextBox_MinNum.Location = New System.Drawing.Point(88, 66)
        Me.TextBox_MinNum.Name = "TextBox_MinNum"
        Me.TextBox_MinNum.Size = New System.Drawing.Size(140, 21)
        Me.TextBox_MinNum.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "起始序号："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "料件编号："
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ComboBox_PackedId)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.TextBox_MinNum)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.TextBox_PartId)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(925, 100)
        Me.Panel3.TabIndex = 0
        '
        'TextBox_PartId
        '
        Me.TextBox_PartId.Location = New System.Drawing.Point(88, 12)
        Me.TextBox_PartId.Name = "TextBox_PartId"
        Me.TextBox_PartId.Size = New System.Drawing.Size(140, 21)
        Me.TextBox_PartId.TabIndex = 1
        '
        'MinNum
        '
        Me.MinNum.DataPropertyName = "Min_Num"
        Me.MinNum.HeaderText = "起始序号"
        Me.MinNum.Name = "MinNum"
        Me.MinNum.ReadOnly = True
        Me.MinNum.Width = 150
        '
        'PackId
        '
        Me.PackId.DataPropertyName = "PackId"
        Me.PackId.HeaderText = "条码类型"
        Me.PackId.Name = "PackId"
        Me.PackId.ReadOnly = True
        Me.PackId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PackId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PackId.Width = 150
        '
        'PartId
        '
        Me.PartId.DataPropertyName = "PartId"
        Me.PartId.HeaderText = "料件编号"
        Me.PartId.Name = "PartId"
        Me.PartId.ReadOnly = True
        Me.PartId.Width = 150
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.DataGridView1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 100)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(925, 328)
        Me.Panel4.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartId, Me.PackId, Me.MinNum})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(925, 328)
        Me.DataGridView1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 31)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(925, 428)
        Me.Panel2.TabIndex = 3
        '
        'ExitFrom
        '
        Me.ExitFrom.Image = CType(resources.GetObject("ExitFrom.Image"), System.Drawing.Image)
        Me.ExitFrom.ImageTransparentColor = System.Drawing.Color.White
        Me.ExitFrom.Name = "ExitFrom"
        Me.ExitFrom.Size = New System.Drawing.Size(52, 28)
        Me.ExitFrom.Text = "退出"
        Me.ExitFrom.ToolTipText = "退出"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'Delete
        '
        Me.Delete.Image = CType(resources.GetObject("Delete.Image"), System.Drawing.Image)
        Me.Delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(52, 28)
        Me.Delete.Text = "刪除"
        Me.Delete.ToolTipText = "刪除"
        '
        'Save
        '
        Me.Save.Image = CType(resources.GetObject("Save.Image"), System.Drawing.Image)
        Me.Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(52, 28)
        Me.Save.Text = "保存"
        Me.Save.ToolTipText = "保存"
        '
        'EditFile
        '
        Me.EditFile.Image = CType(resources.GetObject("EditFile.Image"), System.Drawing.Image)
        Me.EditFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditFile.Name = "EditFile"
        Me.EditFile.Size = New System.Drawing.Size(52, 28)
        Me.EditFile.Text = "修改"
        Me.EditFile.ToolTipText = "修改"
        '
        'NewFile
        '
        Me.NewFile.Image = CType(resources.GetObject("NewFile.Image"), System.Drawing.Image)
        Me.NewFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewFile.Name = "NewFile"
        Me.NewFile.Size = New System.Drawing.Size(52, 28)
        Me.NewFile.Text = "新增"
        Me.NewFile.ToolTipText = "新增"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'ToolBt
        '
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.NewFile, Me.EditFile, Me.Save, Me.Delete, Me.ToolStripSeparator2, Me.toolBack, Me.toolQuery, Me.DataRefresh, Me.toolStripSeparator4, Me.ExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(925, 31)
        Me.ToolBt.TabIndex = 12
        Me.ToolBt.Text = "ToolStrip1"
        '
        'toolBack
        '
        Me.toolBack.Image = CType(resources.GetObject("toolBack.Image"), System.Drawing.Image)
        Me.toolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBack.Name = "toolBack"
        Me.toolBack.Size = New System.Drawing.Size(72, 28)
        Me.toolBack.Tag = ""
        Me.toolBack.Text = "返 回(&B)"
        '
        'toolQuery
        '
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(76, 28)
        Me.toolQuery.Text = "查  询(&F)"
        '
        'DataRefresh
        '
        Me.DataRefresh.Image = CType(resources.GetObject("DataRefresh.Image"), System.Drawing.Image)
        Me.DataRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.DataRefresh.Name = "DataRefresh"
        Me.DataRefresh.Size = New System.Drawing.Size(52, 28)
        Me.DataRefresh.Text = "刷新"
        Me.DataRefresh.ToolTipText = "刷新"
        Me.DataRefresh.Visible = False
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolBt)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(925, 31)
        Me.Panel1.TabIndex = 2
        '
        'Frm_SnSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 459)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_SnSet"
        Me.Text = "条码起始序号设置"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBox_PackedId As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox_MinNum As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TextBox_PartId As System.Windows.Forms.TextBox
    Friend WithEvents MinNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents EditFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents NewFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents toolBack As System.Windows.Forms.ToolStripButton
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataRefresh As System.Windows.Forms.ToolStripButton
End Class
