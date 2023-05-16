<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCheckPartid
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
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.TAvcPart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAvcPart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CusID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Userid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.Partid = New System.Windows.Forms.TextBox()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel2.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TAvcPart, Me.PAvcPart, Me.CusID, Me.Userid})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvData.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData.Location = New System.Drawing.Point(0, 39)
        Me.dgvData.MultiSelect = False
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvData.RowHeadersWidth = 25
        Me.dgvData.RowTemplate.Height = 24
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvData.Size = New System.Drawing.Size(429, 365)
        Me.dgvData.TabIndex = 4
        '
        'TAvcPart
        '
        Me.TAvcPart.DataPropertyName = "TAvcPart"
        Me.TAvcPart.HeaderText = "料号"
        Me.TAvcPart.Name = "TAvcPart"
        Me.TAvcPart.ReadOnly = True
        '
        'PAvcPart
        '
        Me.PAvcPart.DataPropertyName = "PAvcPart"
        Me.PAvcPart.HeaderText = "上级料号"
        Me.PAvcPart.Name = "PAvcPart"
        Me.PAvcPart.ReadOnly = True
        '
        'CusID
        '
        Me.CusID.DataPropertyName = "CusID"
        Me.CusID.HeaderText = "客户代码"
        Me.CusID.Name = "CusID"
        Me.CusID.ReadOnly = True
        '
        'Userid
        '
        Me.Userid.DataPropertyName = "Userid"
        Me.Userid.HeaderText = "维护人"
        Me.Userid.Name = "Userid"
        Me.Userid.ReadOnly = True
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnOK.Location = New System.Drawing.Point(241, 6)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancel.Location = New System.Drawing.Point(337, 6)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'panel2
        '
        Me.panel2.Controls.Add(Me.Label2)
        Me.panel2.Controls.Add(Me.Partid)
        Me.panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel2.Location = New System.Drawing.Point(0, 0)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(429, 39)
        Me.panel2.TabIndex = 3
        '
        'Partid
        '
        Me.Partid.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Partid.Location = New System.Drawing.Point(57, 8)
        Me.Partid.Name = "Partid"
        Me.Partid.Size = New System.Drawing.Size(355, 21)
        Me.Partid.TabIndex = 2
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.btnOK)
        Me.panel1.Controls.Add(Me.btnCancel)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panel1.Location = New System.Drawing.Point(0, 404)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(429, 40)
        Me.panel1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "料号"
        '
        'FormCheckPartid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 444)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.panel1)
        Me.Name = "FormCheckPartid"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "料号"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        Me.panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents dgvData As DataGridView
    Private WithEvents btnOK As Button
    Private WithEvents btnCancel As Button
    Private WithEvents panel2 As Panel
    Private WithEvents panel1 As Panel
    Private WithEvents Partid As TextBox
    Friend WithEvents TAvcPart As DataGridViewTextBoxColumn
    Friend WithEvents PAvcPart As DataGridViewTextBoxColumn
    Friend WithEvents CusID As DataGridViewTextBoxColumn
    Friend WithEvents Userid As DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
