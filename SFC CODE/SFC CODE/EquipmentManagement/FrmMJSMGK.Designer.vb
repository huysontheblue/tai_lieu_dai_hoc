<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMJSMGK
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMouid = New System.Windows.Forms.TextBox()
        Me.txtMouidNum = New System.Windows.Forms.TextBox()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "模具编号:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(279, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "使用次数:"
        '
        'txtMouid
        '
        Me.txtMouid.Location = New System.Drawing.Point(72, 13)
        Me.txtMouid.Name = "txtMouid"
        Me.txtMouid.Size = New System.Drawing.Size(201, 21)
        Me.txtMouid.TabIndex = 2
        '
        'txtMouidNum
        '
        Me.txtMouidNum.Location = New System.Drawing.Point(344, 13)
        Me.txtMouidNum.Name = "txtMouidNum"
        Me.txtMouidNum.Size = New System.Drawing.Size(100, 21)
        Me.txtMouidNum.TabIndex = 4
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(456, 11)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(75, 23)
        Me.BtnOK.TabIndex = 5
        Me.BtnOK.Text = "确定"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'FrmMJSMGK
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 54)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.txtMouidNum)
        Me.Controls.Add(Me.txtMouid)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMJSMGK"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "模具寿命管制"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMouid As System.Windows.Forms.TextBox
    Friend WithEvents txtMouidNum As System.Windows.Forms.TextBox
    Friend WithEvents BtnOK As System.Windows.Forms.Button
End Class
