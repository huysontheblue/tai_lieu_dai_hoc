<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCheckSmall
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
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.ITEM_Small_Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEM_Small_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEM_Small_Usid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEM_Small_Time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.editValue = New System.Windows.Forms.TextBox()
        Me.combField = New System.Windows.Forms.ComboBox()
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
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ITEM_Small_Code, Me.ITEM_Small_Name, Me.ITEM_Small_Usid, Me.ITEM_Small_Time})
        Me.dgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData.Location = New System.Drawing.Point(0, 47)
        Me.dgvData.MultiSelect = False
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowHeadersWidth = 25
        Me.dgvData.RowTemplate.Height = 24
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvData.Size = New System.Drawing.Size(436, 444)
        Me.dgvData.TabIndex = 7
        '
        'ITEM_Small_Code
        '
        Me.ITEM_Small_Code.DataPropertyName = "ITEM_Small_Code"
        Me.ITEM_Small_Code.HeaderText = "测试小项代码"
        Me.ITEM_Small_Code.Name = "ITEM_Small_Code"
        Me.ITEM_Small_Code.ReadOnly = True
        '
        'ITEM_Small_Name
        '
        Me.ITEM_Small_Name.DataPropertyName = "ITEM_Small_Name"
        Me.ITEM_Small_Name.HeaderText = "测试小项名称"
        Me.ITEM_Small_Name.Name = "ITEM_Small_Name"
        Me.ITEM_Small_Name.ReadOnly = True
        '
        'ITEM_Small_Usid
        '
        Me.ITEM_Small_Usid.DataPropertyName = "ITEM_Small_Usid"
        Me.ITEM_Small_Usid.HeaderText = "维护人"
        Me.ITEM_Small_Usid.Name = "ITEM_Small_Usid"
        Me.ITEM_Small_Usid.ReadOnly = True
        '
        'ITEM_Small_Time
        '
        Me.ITEM_Small_Time.DataPropertyName = "ITEM_Small_Time"
        Me.ITEM_Small_Time.HeaderText = "维护时间"
        Me.ITEM_Small_Time.Name = "ITEM_Small_Time"
        Me.ITEM_Small_Time.ReadOnly = True
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnOK.Location = New System.Drawing.Point(259, 5)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "确认"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancel.Location = New System.Drawing.Point(349, 6)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'panel2
        '
        Me.panel2.Controls.Add(Me.Label2)
        Me.panel2.Controls.Add(Me.editValue)
        Me.panel2.Controls.Add(Me.combField)
        Me.panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel2.Location = New System.Drawing.Point(0, 0)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(436, 47)
        Me.panel2.TabIndex = 6
        '
        'editValue
        '
        Me.editValue.Location = New System.Drawing.Point(212, 13)
        Me.editValue.Name = "editValue"
        Me.editValue.Size = New System.Drawing.Size(162, 21)
        Me.editValue.TabIndex = 0
        '
        'combField
        '
        Me.combField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combField.FormattingEnabled = True
        Me.combField.Items.AddRange(New Object() {"测试小项代码", "测试小项名称"})
        Me.combField.Location = New System.Drawing.Point(75, 14)
        Me.combField.Name = "combField"
        Me.combField.Size = New System.Drawing.Size(125, 20)
        Me.combField.TabIndex = 1
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.btnOK)
        Me.panel1.Controls.Add(Me.btnCancel)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panel1.Location = New System.Drawing.Point(0, 491)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(436, 40)
        Me.panel1.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "筛选条件"
        '
        'FormCheckSmall
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 531)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.panel1)
        Me.Name = "FormCheckSmall"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "测试小项筛选"
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
    Private WithEvents editValue As TextBox
    Private WithEvents combField As ComboBox
    Private WithEvents panel1 As Panel
    Friend WithEvents ITEM_Small_Code As DataGridViewTextBoxColumn
    Friend WithEvents ITEM_Small_Name As DataGridViewTextBoxColumn
    Friend WithEvents ITEM_Small_Usid As DataGridViewTextBoxColumn
    Friend WithEvents ITEM_Small_Time As DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
