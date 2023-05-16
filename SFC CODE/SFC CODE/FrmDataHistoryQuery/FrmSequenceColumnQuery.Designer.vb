<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSequenceColumnQuery
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
        Me.dgvQuery = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.RowNumId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COLUMNNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TYPENAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnQuery = New DevComponents.DotNetBar.ButtonX()
        Me.txtSequenceColumn = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnDetermine = New DevComponents.DotNetBar.ButtonX()
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvQuery
        '
        Me.dgvQuery.AllowUserToAddRows = False
        Me.dgvQuery.AllowUserToDeleteRows = False
        Me.dgvQuery.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvQuery.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvQuery.ColumnHeadersHeight = 28
        Me.dgvQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RowNumId, Me.COLUMNNAME, Me.TYPENAME, Me.TableName})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvQuery.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvQuery.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvQuery.Location = New System.Drawing.Point(1, 46)
        Me.dgvQuery.Name = "dgvQuery"
        Me.dgvQuery.RowHeadersWidth = 15
        Me.dgvQuery.RowTemplate.Height = 26
        Me.dgvQuery.Size = New System.Drawing.Size(396, 400)
        Me.dgvQuery.TabIndex = 57
        '
        'RowNumId
        '
        Me.RowNumId.DataPropertyName = "RowNumId"
        Me.RowNumId.HeaderText = "行号"
        Me.RowNumId.Name = "RowNumId"
        Me.RowNumId.ReadOnly = True
        Me.RowNumId.Width = 40
        '
        'COLUMNNAME
        '
        Me.COLUMNNAME.DataPropertyName = "COLUMNNAME"
        Me.COLUMNNAME.HeaderText = "列名"
        Me.COLUMNNAME.Name = "COLUMNNAME"
        Me.COLUMNNAME.ReadOnly = True
        Me.COLUMNNAME.Width = 150
        '
        'TYPENAME
        '
        Me.TYPENAME.DataPropertyName = "TYPENAME"
        Me.TYPENAME.HeaderText = "数据类型"
        Me.TYPENAME.Name = "TYPENAME"
        Me.TYPENAME.ReadOnly = True
        '
        'TableName
        '
        Me.TableName.DataPropertyName = "TABLENAME"
        Me.TableName.HeaderText = "表名称"
        Me.TableName.Name = "TableName"
        Me.TableName.ReadOnly = True
        Me.TableName.Width = 150
        '
        'btnQuery
        '
        Me.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnQuery.Location = New System.Drawing.Point(321, 11)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(57, 23)
        Me.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.btnQuery.TabIndex = 56
        Me.btnQuery.Text = "查  询"
        '
        'txtSequenceColumn
        '
        '
        '
        '
        Me.txtSequenceColumn.Border.Class = "TextBoxBorder"
        Me.txtSequenceColumn.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSequenceColumn.Location = New System.Drawing.Point(75, 13)
        Me.txtSequenceColumn.Name = "txtSequenceColumn"
        Me.txtSequenceColumn.Size = New System.Drawing.Size(219, 21)
        Me.txtSequenceColumn.TabIndex = 55
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(19, 13)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(82, 23)
        Me.LabelX4.TabIndex = 54
        Me.LabelX4.Text = "列名称"
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(1, 459)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(226, 23)
        Me.lblMessage.TabIndex = 60
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(321, 459)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(64, 23)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.btnCancel.TabIndex = 59
        Me.btnCancel.Text = "取 消"
        '
        'btnDetermine
        '
        Me.btnDetermine.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDetermine.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDetermine.Location = New System.Drawing.Point(225, 459)
        Me.btnDetermine.Name = "btnDetermine"
        Me.btnDetermine.Size = New System.Drawing.Size(64, 23)
        Me.btnDetermine.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.btnDetermine.TabIndex = 58
        Me.btnDetermine.Text = "确 定"
        '
        'FrmSequenceColumnQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 495)
        Me.Controls.Add(Me.dgvQuery)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.txtSequenceColumn)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDetermine)
        Me.Controls.Add(Me.lblMessage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSequenceColumnQuery"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "排序l列选择"
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvQuery As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnQuery As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtSequenceColumn As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDetermine As DevComponents.DotNetBar.ButtonX
    Friend WithEvents RowNumId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COLUMNNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TYPENAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
