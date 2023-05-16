<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQueryInfo
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvQuery = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SortName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SortDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnQuery = New DevComponents.DotNetBar.ButtonX()
        Me.txtCode = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnDetermine = New DevComponents.DotNetBar.ButtonX()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSQL = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonX()
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvQuery
        '
        Me.dgvQuery.AllowUserToAddRows = False
        Me.dgvQuery.AllowUserToDeleteRows = False
        Me.dgvQuery.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvQuery.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvQuery.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvQuery.ColumnHeadersHeight = 25
        Me.dgvQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SortName, Me.SortDesc})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvQuery.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvQuery.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvQuery.Location = New System.Drawing.Point(0, 69)
        Me.dgvQuery.Name = "dgvQuery"
        Me.dgvQuery.ReadOnly = True
        Me.dgvQuery.RowHeadersVisible = False
        Me.dgvQuery.RowHeadersWidth = 5
        Me.dgvQuery.RowTemplate.Height = 23
        Me.dgvQuery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvQuery.Size = New System.Drawing.Size(716, 354)
        Me.dgvQuery.TabIndex = 24
        '
        'SortName
        '
        Me.SortName.DataPropertyName = "SortName"
        Me.SortName.HeaderText = "查询名称"
        Me.SortName.Name = "SortName"
        Me.SortName.ReadOnly = True
        Me.SortName.Width = 150
        '
        'SortDesc
        '
        Me.SortDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.SortDesc.DataPropertyName = "SortDesc"
        Me.SortDesc.HeaderText = "查询SQL"
        Me.SortDesc.Name = "SortDesc"
        Me.SortDesc.ReadOnly = True
        '
        'btnQuery
        '
        Me.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnQuery.Location = New System.Drawing.Point(535, 22)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(75, 23)
        Me.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnQuery.TabIndex = 23
        Me.btnQuery.Text = "查  询"
        '
        'txtCode
        '
        '
        '
        '
        Me.txtCode.Border.Class = "TextBoxBorder"
        Me.txtCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCode.Location = New System.Drawing.Point(45, 37)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(111, 21)
        Me.txtCode.TabIndex = 21
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(22, 439)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(202, 23)
        Me.lblMessage.TabIndex = 27
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(345, 439)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 26
        Me.btnCancel.Text = "取  消"
        '
        'btnDetermine
        '
        Me.btnDetermine.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDetermine.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDetermine.Location = New System.Drawing.Point(230, 439)
        Me.btnDetermine.Name = "btnDetermine"
        Me.btnDetermine.Size = New System.Drawing.Size(75, 23)
        Me.btnDetermine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDetermine.TabIndex = 25
        Me.btnDetermine.Text = "确  定"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "项次"
        Me.DataGridViewTextBoxColumn1.HeaderText = "项次"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "料号"
        Me.DataGridViewTextBoxColumn2.HeaderText = "料号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "数量"
        Me.DataGridViewTextBoxColumn3.HeaderText = "数量"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "采购单"
        Me.DataGridViewTextBoxColumn4.HeaderText = "采购单"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"查询-名称关键字", "添加-SQL语句"})
        Me.ComboBox1.Location = New System.Drawing.Point(12, 11)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(144, 20)
        Me.ComboBox1.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "名称"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(176, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 12)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "SQL"
        '
        'txtSQL
        '
        '
        '
        '
        Me.txtSQL.Border.Class = "TextBoxBorder"
        Me.txtSQL.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSQL.Location = New System.Drawing.Point(209, 11)
        Me.txtSQL.Multiline = True
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSQL.Size = New System.Drawing.Size(320, 47)
        Me.txtSQL.TabIndex = 31
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDelete.Location = New System.Drawing.Point(616, 22)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDelete.TabIndex = 33
        Me.btnDelete.Text = "删除"
        '
        'FrmQueryInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 474)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSQL)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.dgvQuery)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDetermine)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmQueryInfo"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "常用SQL语句查询"
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvQuery As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnQuery As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtCode As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDetermine As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SortName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SortDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSQL As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonX
End Class
