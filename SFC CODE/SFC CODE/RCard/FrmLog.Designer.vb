<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLog
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtPartID = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvRCardChangeLog = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StationName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OldModifyTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OldValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserNameAfter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NewModifyTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NewValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvRCardChangeLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPartID
        '
        Me.txtPartID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartID.Location = New System.Drawing.Point(-156, 37)
        Me.txtPartID.MaxLength = 50
        Me.txtPartID.Name = "txtPartID"
        Me.txtPartID.Size = New System.Drawing.Size(10, 21)
        Me.txtPartID.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(-216, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "料号："
        '
        'dgvRCardChangeLog
        '
        Me.dgvRCardChangeLog.AllowUserToAddRows = False
        Me.dgvRCardChangeLog.AllowUserToDeleteRows = False
        Me.dgvRCardChangeLog.AllowUserToOrderColumns = True
        Me.dgvRCardChangeLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRCardChangeLog.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvRCardChangeLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.PartID, Me.StationName, Me.type, Me.UserName, Me.OldModifyTime, Me.OldValue, Me.UserNameAfter, Me.NewModifyTime, Me.NewValue})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRCardChangeLog.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvRCardChangeLog.EnableHeadersVisualStyles = False
        Me.dgvRCardChangeLog.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvRCardChangeLog.Location = New System.Drawing.Point(60, 107)
        Me.dgvRCardChangeLog.Name = "dgvRCardChangeLog"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRCardChangeLog.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvRCardChangeLog.RowHeadersWidth = 4
        Me.dgvRCardChangeLog.RowTemplate.Height = 23
        Me.dgvRCardChangeLog.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.[Default]
        Me.dgvRCardChangeLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvRCardChangeLog.Size = New System.Drawing.Size(535, 294)
        Me.dgvRCardChangeLog.TabIndex = 27
        '
        'ID
        '
        Me.ID.HeaderText = "编号"
        Me.ID.Name = "ID"
        '
        'PartID
        '
        Me.PartID.HeaderText = "成品料号"
        Me.PartID.Name = "PartID"
        '
        'StationName
        '
        Me.StationName.HeaderText = "工站名"
        Me.StationName.Name = "StationName"
        '
        'type
        '
        Me.type.HeaderText = "变更类型"
        Me.type.Name = "type"
        '
        'UserName
        '
        Me.UserName.HeaderText = "修改前人"
        Me.UserName.Name = "UserName"
        '
        'OldModifyTime
        '
        Me.OldModifyTime.HeaderText = "修改前时间"
        Me.OldModifyTime.Name = "OldModifyTime"
        '
        'OldValue
        '
        Me.OldValue.HeaderText = "修改前内容"
        Me.OldValue.Name = "OldValue"
        '
        'UserNameAfter
        '
        Me.UserNameAfter.HeaderText = "修改后人"
        Me.UserNameAfter.Name = "UserNameAfter"
        '
        'NewModifyTime
        '
        Me.NewModifyTime.HeaderText = "修改后时间"
        Me.NewModifyTime.Name = "NewModifyTime"
        '
        'NewValue
        '
        Me.NewValue.HeaderText = "修改后内容"
        Me.NewValue.Name = "NewValue"
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Location = New System.Drawing.Point(205, 35)
        Me.TextBox1.MaxLength = 50
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(178, 21)
        Me.TextBox1.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(145, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "料号："
        '
        'FrmLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 473)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPartID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgvRCardChangeLog)
        Me.Name = "FrmLog"
        Me.Text = "FrmLog"
        CType(Me.dgvRCardChangeLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPartID As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvRCardChangeLog As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StationName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OldModifyTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OldValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserNameAfter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NewModifyTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NewValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
