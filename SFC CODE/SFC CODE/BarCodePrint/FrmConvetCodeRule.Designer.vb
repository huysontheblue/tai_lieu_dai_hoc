<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConvetCodeRule
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
        Me.txtCodeRuleId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumberNo = New System.Windows.Forms.TextBox()
        Me.lbResult = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "编码原则:"
        '
        'txtCodeRuleId
        '
        Me.txtCodeRuleId.Location = New System.Drawing.Point(100, 32)
        Me.txtCodeRuleId.Name = "txtCodeRuleId"
        Me.txtCodeRuleId.Size = New System.Drawing.Size(100, 21)
        Me.txtCodeRuleId.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "流水码:"
        '
        'txtNumberNo
        '
        Me.txtNumberNo.Location = New System.Drawing.Point(100, 82)
        Me.txtNumberNo.Name = "txtNumberNo"
        Me.txtNumberNo.Size = New System.Drawing.Size(100, 21)
        Me.txtNumberNo.TabIndex = 3
        '
        'lbResult
        '
        Me.lbResult.AutoSize = True
        Me.lbResult.ForeColor = System.Drawing.Color.Red
        Me.lbResult.Location = New System.Drawing.Point(35, 190)
        Me.lbResult.Name = "lbResult"
        Me.lbResult.Size = New System.Drawing.Size(53, 12)
        Me.lbResult.TabIndex = 4
        Me.lbResult.Text = "提示信息"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(85, 155)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 5
        Me.btnOk.Text = "确定"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(100, 119)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ReadOnly = True
        Me.txtResult.Size = New System.Drawing.Size(100, 21)
        Me.txtResult.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "最终结果"
        '
        'FrmConvetCodeRule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(249, 211)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.lbResult)
        Me.Controls.Add(Me.txtNumberNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodeRuleId)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmConvetCodeRule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "编码原则流水转换器"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodeRuleId As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumberNo As System.Windows.Forms.TextBox
    Friend WithEvents lbResult As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
