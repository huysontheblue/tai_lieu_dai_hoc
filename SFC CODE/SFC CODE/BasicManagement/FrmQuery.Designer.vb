<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQuery
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
        Me.btnQuery = New DevComponents.DotNetBar.ButtonX()
        Me.txtCode = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvQuery.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvQuery.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvQuery.Location = New System.Drawing.Point(4, 53)
        Me.dgvQuery.Name = "dgvQuery"
        Me.dgvQuery.RowHeadersWidth = 15
        Me.dgvQuery.RowTemplate.Height = 28
        Me.dgvQuery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvQuery.Size = New System.Drawing.Size(428, 372)
        Me.dgvQuery.TabIndex = 17
        '
        'btnQuery
        '
        Me.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnQuery.Location = New System.Drawing.Point(321, 17)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(75, 23)
        Me.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnQuery.TabIndex = 16
        Me.btnQuery.Text = "查  询"
        '
        'txtCode
        '
        '
        '
        '
        Me.txtCode.Border.Class = "TextBoxBorder"
        Me.txtCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCode.Location = New System.Drawing.Point(59, 18)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(232, 21)
        Me.txtCode.TabIndex = 14
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(14, 18)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 15
        Me.LabelX1.Text = "编号:"
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(14, 441)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(202, 23)
        Me.lblMessage.TabIndex = 20
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(337, 441)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "取  消"
        '
        'btnDetermine
        '
        Me.btnDetermine.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDetermine.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDetermine.Location = New System.Drawing.Point(222, 441)
        Me.btnDetermine.Name = "btnDetermine"
        Me.btnDetermine.Size = New System.Drawing.Size(75, 23)
        Me.btnDetermine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDetermine.TabIndex = 18
        Me.btnDetermine.Text = "确  定"
        '
        'FrmQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 479)
        Me.Controls.Add(Me.dgvQuery)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDetermine)
        Me.Controls.Add(Me.LabelX1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmQuery"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "查询"
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvQuery As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnQuery As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtCode As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDetermine As DevComponents.DotNetBar.ButtonX
End Class
