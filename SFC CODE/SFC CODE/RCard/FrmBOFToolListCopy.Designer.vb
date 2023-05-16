<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBOFToolListCopy
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
        Me.txtOldPartID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNewPartID = New System.Windows.Forms.TextBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtOldPartID
        '
        Me.txtOldPartID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOldPartID.Location = New System.Drawing.Point(62, 11)
        Me.txtOldPartID.Name = "txtOldPartID"
        Me.txtOldPartID.ReadOnly = True
        Me.txtOldPartID.Size = New System.Drawing.Size(231, 21)
        Me.txtOldPartID.TabIndex = 0
        Me.txtOldPartID.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "旧料号:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "新料号:"
        '
        'txtNewPartID
        '
        Me.txtNewPartID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNewPartID.Location = New System.Drawing.Point(62, 41)
        Me.txtNewPartID.Name = "txtNewPartID"
        Me.txtNewPartID.Size = New System.Drawing.Size(231, 21)
        Me.txtNewPartID.TabIndex = 1
        '
        'btnSubmit
        '
        Me.btnSubmit.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnSubmit.Location = New System.Drawing.Point(370, 36)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(77, 34)
        Me.btnSubmit.TabIndex = 4
        Me.btnSubmit.Text = "提交"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(300, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "新料号版本:"
        '
        'txtVersion
        '
        Me.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVersion.Location = New System.Drawing.Point(370, 11)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(77, 21)
        Me.txtVersion.TabIndex = 6
        '
        'FrmBOFToolListCopy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 74)
        Me.Controls.Add(Me.txtVersion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNewPartID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtOldPartID)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBOFToolListCopy"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BOF流程复制"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOldPartID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNewPartID As System.Windows.Forms.TextBox
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
End Class
