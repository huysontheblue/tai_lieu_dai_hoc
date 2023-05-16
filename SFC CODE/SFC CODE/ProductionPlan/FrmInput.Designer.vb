<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInput
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
        Me.Btnupload = New System.Windows.Forms.Button()
        Me.cboQueryType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Btnupload
        '
        Me.Btnupload.Location = New System.Drawing.Point(311, 40)
        Me.Btnupload.Name = "Btnupload"
        Me.Btnupload.Size = New System.Drawing.Size(75, 23)
        Me.Btnupload.TabIndex = 156
        Me.Btnupload.Text = "上传"
        Me.Btnupload.UseVisualStyleBackColor = True
        '
        'cboQueryType
        '
        Me.cboQueryType.BackColor = System.Drawing.Color.White
        Me.cboQueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboQueryType.FormattingEnabled = True
        Me.cboQueryType.Location = New System.Drawing.Point(96, 42)
        Me.cboQueryType.Name = "cboQueryType"
        Me.cboQueryType.Size = New System.Drawing.Size(149, 20)
        Me.cboQueryType.TabIndex = 154
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 155
        Me.Label4.Text = "上传类型："
        '
        'FrmInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 122)
        Me.Controls.Add(Me.Btnupload)
        Me.Controls.Add(Me.cboQueryType)
        Me.Controls.Add(Me.Label4)
        Me.Name = "FrmInput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "导入"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btnupload As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents cboQueryType As System.Windows.Forms.ComboBox
End Class
