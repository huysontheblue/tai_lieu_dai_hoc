<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMOQuery
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
        Me.MOId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MoQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnQuery = New DevComponents.DotNetBar.ButtonX()
        Me.txtSupplierCode = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnDetermine = New DevComponents.DotNetBar.ButtonX()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbCustomer = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboQueryLine = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvQuery
        '
        Me.dgvQuery.AllowUserToAddRows = False
        Me.dgvQuery.AllowUserToDeleteRows = False
        Me.dgvQuery.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvQuery.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvQuery.ColumnHeadersHeight = 28
        Me.dgvQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MOId, Me.PartId, Me.MoQty, Me.Remark})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvQuery.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvQuery.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvQuery.Location = New System.Drawing.Point(4, 106)
        Me.dgvQuery.Name = "dgvQuery"
        Me.dgvQuery.RowHeadersWidth = 15
        Me.dgvQuery.RowTemplate.Height = 28
        Me.dgvQuery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvQuery.Size = New System.Drawing.Size(428, 319)
        Me.dgvQuery.TabIndex = 17
        '
        'MOId
        '
        Me.MOId.DataPropertyName = "MOId"
        Me.MOId.HeaderText = "工单"
        Me.MOId.Name = "MOId"
        Me.MOId.ReadOnly = True
        Me.MOId.Width = 150
        '
        'PartId
        '
        Me.PartId.DataPropertyName = "PartId"
        Me.PartId.HeaderText = "料号"
        Me.PartId.Name = "PartId"
        Me.PartId.ReadOnly = True
        Me.PartId.Width = 120
        '
        'MoQty
        '
        Me.MoQty.DataPropertyName = "MoQty"
        Me.MoQty.HeaderText = "数量"
        Me.MoQty.Name = "MoQty"
        Me.MoQty.ReadOnly = True
        Me.MoQty.Width = 50
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "说明"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        Me.Remark.Width = 150
        '
        'btnQuery
        '
        Me.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnQuery.Location = New System.Drawing.Point(317, 40)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(75, 23)
        Me.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnQuery.TabIndex = 16
        Me.btnQuery.Text = "查  询"
        '
        'txtSupplierCode
        '
        '
        '
        '
        Me.txtSupplierCode.Border.Class = "TextBoxBorder"
        Me.txtSupplierCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSupplierCode.Location = New System.Drawing.Point(84, 64)
        Me.txtSupplierCode.Name = "txtSupplierCode"
        Me.txtSupplierCode.Size = New System.Drawing.Size(140, 21)
        Me.txtSupplierCode.TabIndex = 14
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
        'lblMessage
        '
        Me.lblMessage.Location = New System.Drawing.Point(12, 441)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(200, 23)
        Me.lblMessage.TabIndex = 136
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 12)
        Me.Label15.TabIndex = 138
        Me.Label15.Text = "客户名称："
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCustomer
        '
        Me.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCustomer.BackColor = System.Drawing.Color.White
        Me.cmbCustomer.FormattingEnabled = True
        Me.cmbCustomer.Location = New System.Drawing.Point(84, 12)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(140, 20)
        Me.cmbCustomer.TabIndex = 137
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 139
        Me.Label1.Text = "工单："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboQueryLine
        '
        Me.cboQueryLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboQueryLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboQueryLine.FormattingEnabled = True
        Me.cboQueryLine.Location = New System.Drawing.Point(84, 38)
        Me.cboQueryLine.Name = "cboQueryLine"
        Me.cboQueryLine.Size = New System.Drawing.Size(140, 20)
        Me.cboQueryLine.TabIndex = 140
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(35, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = "线别："
        '
        'FrmMOQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 479)
        Me.Controls.Add(Me.cboQueryLine)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmbCustomer)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvQuery)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.txtSupplierCode)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDetermine)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMOQuery"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "工单查询"
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvQuery As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnQuery As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtSupplierCode As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDetermine As DevComponents.DotNetBar.ButtonX
    Friend WithEvents MOId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MoQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboQueryLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
