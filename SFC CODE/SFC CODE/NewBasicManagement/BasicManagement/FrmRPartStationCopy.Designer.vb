<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRPartStationCopy
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPartId = New System.Windows.Forms.TextBox()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPartId = New System.Windows.Forms.Label()
        Me.dgvPartId = New System.Windows.Forms.DataGridView()
        Me.TAvcPart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAvcPart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CusID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvPartId, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "新料号："
        '
        'txtPartId
        '
        Me.txtPartId.Location = New System.Drawing.Point(64, 12)
        Me.txtPartId.Name = "txtPartId"
        Me.txtPartId.Size = New System.Drawing.Size(214, 21)
        Me.txtPartId.TabIndex = 1
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(369, 12)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(75, 23)
        Me.btnCopy.TabIndex = 19
        Me.btnCopy.Text = "复制"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.Red
        Me.lblMessage.Location = New System.Drawing.Point(282, 45)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(119, 14)
        Me.lblMessage.TabIndex = 21
        Me.lblMessage.Text = "复制料号不成功！"
        Me.lblMessage.Visible = False
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(288, 12)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(75, 23)
        Me.btnQuery.TabIndex = 22
        Me.btnQuery.Text = "查询"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "旧料号："
        '
        'lblPartId
        '
        Me.lblPartId.AutoSize = True
        Me.lblPartId.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblPartId.Location = New System.Drawing.Point(65, 44)
        Me.lblPartId.Name = "lblPartId"
        Me.lblPartId.Size = New System.Drawing.Size(49, 14)
        Me.lblPartId.TabIndex = 24
        Me.lblPartId.Text = "Label3"
        '
        'dgvPartId
        '
        Me.dgvPartId.AllowUserToAddRows = False
        Me.dgvPartId.AllowUserToDeleteRows = False
        Me.dgvPartId.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPartId.BackgroundColor = System.Drawing.Color.White
        Me.dgvPartId.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartId.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TAvcPart, Me.PAvcPart, Me.CusID})
        Me.dgvPartId.Location = New System.Drawing.Point(2, 67)
        Me.dgvPartId.Name = "dgvPartId"
        Me.dgvPartId.ReadOnly = True
        Me.dgvPartId.RowTemplate.Height = 23
        Me.dgvPartId.Size = New System.Drawing.Size(470, 260)
        Me.dgvPartId.TabIndex = 25
        '
        'TAvcPart
        '
        Me.TAvcPart.DataPropertyName = "TAvcPart"
        Me.TAvcPart.HeaderText = "料号"
        Me.TAvcPart.Name = "TAvcPart"
        Me.TAvcPart.ReadOnly = True
        Me.TAvcPart.Width = 150
        '
        'PAvcPart
        '
        Me.PAvcPart.DataPropertyName = "PAvcPart"
        Me.PAvcPart.HeaderText = "父料号"
        Me.PAvcPart.Name = "PAvcPart"
        Me.PAvcPart.ReadOnly = True
        Me.PAvcPart.Width = 150
        '
        'CusID
        '
        Me.CusID.DataPropertyName = "CusID"
        Me.CusID.HeaderText = "客户代码"
        Me.CusID.Name = "CusID"
        Me.CusID.ReadOnly = True
        '
        'FrmRPartStationCopy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 330)
        Me.Controls.Add(Me.dgvPartId)
        Me.Controls.Add(Me.lblPartId)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.txtPartId)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRPartStationCopy"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "复制料号"
        CType(Me.dgvPartId, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPartId As System.Windows.Forms.TextBox
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPartId As System.Windows.Forms.Label
    Friend WithEvents dgvPartId As System.Windows.Forms.DataGridView
    Friend WithEvents TAvcPart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAvcPart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CusID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
