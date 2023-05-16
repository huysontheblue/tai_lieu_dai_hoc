<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHWHLTestResultDetail
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
        Me.DgDataDetail = New System.Windows.Forms.DataGridView()
        CType(Me.DgDataDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgDataDetail
        '
        Me.DgDataDetail.AllowUserToAddRows = False
        Me.DgDataDetail.AllowUserToDeleteRows = False
        Me.DgDataDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgDataDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgDataDetail.Location = New System.Drawing.Point(0, 0)
        Me.DgDataDetail.Name = "DgDataDetail"
        Me.DgDataDetail.ReadOnly = True
        Me.DgDataDetail.RowTemplate.Height = 23
        Me.DgDataDetail.Size = New System.Drawing.Size(686, 323)
        Me.DgDataDetail.TabIndex = 0
        '
        'FrmHWHLTestResultDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 323)
        Me.Controls.Add(Me.DgDataDetail)
        Me.Name = "FrmHWHLTestResultDetail"
        Me.Text = "测试记录"
        CType(Me.DgDataDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgDataDetail As System.Windows.Forms.DataGridView
End Class
