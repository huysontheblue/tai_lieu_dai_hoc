<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSampleDoc
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
        Me.dgvDoc = New System.Windows.Forms.DataGridView()
        Me.SampleNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Path = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDoc
        '
        Me.dgvDoc.AllowUserToAddRows = False
        Me.dgvDoc.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDoc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SampleNo, Me.type, Me.Path})
        Me.dgvDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDoc.Location = New System.Drawing.Point(0, 0)
        Me.dgvDoc.Name = "dgvDoc"
        Me.dgvDoc.RowHeadersVisible = False
        Me.dgvDoc.RowTemplate.Height = 23
        Me.dgvDoc.Size = New System.Drawing.Size(614, 322)
        Me.dgvDoc.TabIndex = 0
        '
        'SampleNo
        '
        Me.SampleNo.DataPropertyName = "SampleNo"
        Me.SampleNo.HeaderText = "样品单号"
        Me.SampleNo.Name = "SampleNo"
        '
        'type
        '
        Me.type.DataPropertyName = "type"
        Me.type.HeaderText = "文件类型"
        Me.type.Name = "type"
        '
        'Path
        '
        Me.Path.DataPropertyName = "Path"
        Me.Path.HeaderText = "路径"
        Me.Path.Name = "Path"
        '
        'FrmSampleDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 322)
        Me.Controls.Add(Me.dgvDoc)
        Me.Name = "FrmSampleDoc"
        Me.Text = "文档信息"
        CType(Me.dgvDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvDoc As System.Windows.Forms.DataGridView
    Friend WithEvents SampleNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Path As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
