<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEquipmentQuery
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
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.btnQuery = New DevComponents.DotNetBar.ButtonX()
        Me.txtHardWarePartNumber = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnDetermine = New DevComponents.DotNetBar.ButtonX()
        Me.chkSelect = New System.Windows.Forms.CheckBox()
        Me.dgvQuery = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.HardWarePartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartNumberFormat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(11, 435)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(179, 23)
        Me.lblMessage.TabIndex = 20
        '
        'btnQuery
        '
        Me.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnQuery.Location = New System.Drawing.Point(273, 15)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(69, 23)
        Me.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnQuery.TabIndex = 16
        Me.btnQuery.Text = "查  询"
        '
        'txtHardWarePartNumber
        '
        '
        '
        '
        Me.txtHardWarePartNumber.Border.Class = "TextBoxBorder"
        Me.txtHardWarePartNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHardWarePartNumber.Location = New System.Drawing.Point(78, 15)
        Me.txtHardWarePartNumber.Name = "txtHardWarePartNumber"
        Me.txtHardWarePartNumber.Size = New System.Drawing.Size(171, 21)
        Me.txtHardWarePartNumber.TabIndex = 14
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(11, 15)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 15
        Me.LabelX1.Text = "五金料号:"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(334, 435)
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
        Me.btnDetermine.Location = New System.Drawing.Point(196, 435)
        Me.btnDetermine.Name = "btnDetermine"
        Me.btnDetermine.Size = New System.Drawing.Size(75, 23)
        Me.btnDetermine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDetermine.TabIndex = 18
        Me.btnDetermine.Text = "确  定"
        '
        'chkSelect
        '
        Me.chkSelect.AutoSize = True
        Me.chkSelect.Location = New System.Drawing.Point(361, 20)
        Me.chkSelect.Name = "chkSelect"
        Me.chkSelect.Size = New System.Drawing.Size(48, 16)
        Me.chkSelect.TabIndex = 21
        Me.chkSelect.Text = "全选"
        Me.chkSelect.UseVisualStyleBackColor = True
        '
        'dgvQuery
        '
        Me.dgvQuery.AllowUserToAddRows = False
        Me.dgvQuery.AllowUserToDeleteRows = False
        Me.dgvQuery.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvQuery.ColumnHeadersHeight = 28
        Me.dgvQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.HardWarePartNumber, Me.PartNumber, Me.PartNumberFormat})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvQuery.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvQuery.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvQuery.Location = New System.Drawing.Point(1, 50)
        Me.dgvQuery.Name = "dgvQuery"
        Me.dgvQuery.RowHeadersWidth = 15
        Me.dgvQuery.RowTemplate.Height = 28
        Me.dgvQuery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvQuery.Size = New System.Drawing.Size(428, 372)
        Me.dgvQuery.TabIndex = 40
        '
        'HardWarePartNumber
        '
        Me.HardWarePartNumber.DataPropertyName = "HardWarePartNumber"
        Me.HardWarePartNumber.HeaderText = "五金料号"
        Me.HardWarePartNumber.Name = "HardWarePartNumber"
        Me.HardWarePartNumber.ReadOnly = True
        '
        'PartNumber
        '
        Me.PartNumber.DataPropertyName = "PartNumber"
        Me.PartNumber.HeaderText = "设备料号"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.ReadOnly = True
        Me.PartNumber.Width = 160
        '
        'PartNumberFormat
        '
        Me.PartNumberFormat.DataPropertyName = "PartNumberFormat"
        Me.PartNumberFormat.HeaderText = "设备规格"
        Me.PartNumberFormat.Name = "PartNumberFormat"
        Me.PartNumberFormat.ReadOnly = True
        Me.PartNumberFormat.Width = 150
        '
        'FrmEquipmentQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 472)
        Me.Controls.Add(Me.dgvQuery)
        Me.Controls.Add(Me.chkSelect)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.txtHardWarePartNumber)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDetermine)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEquipmentQuery"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "设备选择"
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnQuery As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtHardWarePartNumber As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDetermine As DevComponents.DotNetBar.ButtonX
    Friend WithEvents chkSelect As System.Windows.Forms.CheckBox
    Friend WithEvents dgvQuery As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents HardWarePartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberFormat As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
