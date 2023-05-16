<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSampleDocHis
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
        Me.dgvDocList = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Path = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDocList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDocList
        '
        Me.dgvDocList.AllowUserToAddRows = False
        Me.dgvDocList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDocList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Path, Me.Column2, Me.UserName})
        Me.dgvDocList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDocList.Location = New System.Drawing.Point(0, 0)
        Me.dgvDocList.Name = "dgvDocList"
        Me.dgvDocList.RowTemplate.Height = 23
        Me.dgvDocList.Size = New System.Drawing.Size(461, 273)
        Me.dgvDocList.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "type"
        Me.Column1.HeaderText = "文件类型"
        Me.Column1.Name = "Column1"
        '
        'Path
        '
        Me.Path.DataPropertyName = "path"
        Me.Path.HeaderText = "文件路径"
        Me.Path.Name = "Path"
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Intime"
        Me.Column2.HeaderText = "上传时间"
        Me.Column2.Name = "Column2"
        '
        'UserName
        '
        Me.UserName.DataPropertyName = "UserName"
        Me.UserName.HeaderText = "上传人"
        Me.UserName.Name = "UserName"
        '
        'FrmSampleDocHis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 273)
        Me.Controls.Add(Me.dgvDocList)
        Me.Name = "FrmSampleDocHis"
        Me.Text = "文档上传历史记录"
        CType(Me.dgvDocList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvDocList As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Path As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
