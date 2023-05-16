<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLineMOQuery
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
        Me.dgvQuery = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Moid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MoQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Line = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnQuery = New DevComponents.DotNetBar.ButtonX()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnDetermine = New DevComponents.DotNetBar.ButtonX()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtmoid = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.CboLine = New System.Windows.Forms.ComboBox()
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvQuery
        '
        Me.dgvQuery.AllowUserToAddRows = False
        Me.dgvQuery.AllowUserToDeleteRows = False
        Me.dgvQuery.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvQuery.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvQuery.ColumnHeadersHeight = 28
        Me.dgvQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Moid, Me.PartId, Me.MoQty, Me.Line})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvQuery.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvQuery.EnableHeadersVisualStyles = False
        Me.dgvQuery.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvQuery.Location = New System.Drawing.Point(4, 81)
        Me.dgvQuery.Name = "dgvQuery"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvQuery.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvQuery.RowHeadersWidth = 15
        Me.dgvQuery.RowTemplate.Height = 28
        Me.dgvQuery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvQuery.Size = New System.Drawing.Size(428, 345)
        Me.dgvQuery.TabIndex = 17
        '
        'Moid
        '
        Me.Moid.HeaderText = "工单"
        Me.Moid.Name = "Moid"
        Me.Moid.ReadOnly = True
        '
        'PartId
        '
        Me.PartId.HeaderText = "料号"
        Me.PartId.Name = "PartId"
        Me.PartId.ReadOnly = True
        '
        'MoQty
        '
        Me.MoQty.HeaderText = "数量"
        Me.MoQty.Name = "MoQty"
        Me.MoQty.ReadOnly = True
        '
        'Line
        '
        Me.Line.HeaderText = "时间"
        Me.Line.Name = "Line"
        '
        'btnQuery
        '
        Me.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnQuery.FocusCuesEnabled = False
        Me.btnQuery.Location = New System.Drawing.Point(316, 31)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(75, 23)
        Me.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnQuery.TabIndex = 16
        Me.btnQuery.Text = "查  询"
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
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "工单"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 150
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "料号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 120
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "数量"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 50
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "线别"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'txtmoid
        '
        '
        '
        '
        Me.txtmoid.Border.Class = "TextBoxBorder"
        Me.txtmoid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtmoid.Location = New System.Drawing.Point(93, 48)
        Me.txtmoid.Name = "txtmoid"
        Me.txtmoid.Size = New System.Drawing.Size(157, 21)
        Me.txtmoid.TabIndex = 26
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(41, 48)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(49, 23)
        Me.LabelX1.TabIndex = 27
        Me.LabelX1.Text = "工单:"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(41, 17)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(48, 23)
        Me.LabelX2.TabIndex = 29
        Me.LabelX2.Text = "线别:"
        '
        'CboLine
        '
        Me.CboLine.FormattingEnabled = True
        Me.CboLine.Location = New System.Drawing.Point(93, 17)
        Me.CboLine.Name = "CboLine"
        Me.CboLine.Size = New System.Drawing.Size(157, 20)
        Me.CboLine.TabIndex = 30
        '
        'FrmLineMOQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 479)
        Me.Controls.Add(Me.CboLine)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.txtmoid)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.dgvQuery)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDetermine)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLineMOQuery"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "线别查询工单"
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvQuery As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnQuery As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDetermine As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MoQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Line As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtmoid As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CboLine As System.Windows.Forms.ComboBox
End Class
