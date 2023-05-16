<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOnlineSopNew
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
        Me.txtSopName = New System.Windows.Forms.TextBox()
        Me.txtVerNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDocId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.RichTextBox()
        Me.btnHeaderSave = New System.Windows.Forms.Button()
        Me.btnHeaderCancel = New System.Windows.Forms.Button()
        Me.txtShape = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPartName = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SOP名称"
        '
        'txtSopName
        '
        Me.txtSopName.Location = New System.Drawing.Point(94, 22)
        Me.txtSopName.Name = "txtSopName"
        Me.txtSopName.Size = New System.Drawing.Size(342, 21)
        Me.txtSopName.TabIndex = 1
        '
        'txtVerNo
        '
        Me.txtVerNo.Location = New System.Drawing.Point(94, 156)
        Me.txtVerNo.Name = "txtVerNo"
        Me.txtVerNo.Size = New System.Drawing.Size(100, 21)
        Me.txtVerNo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "版本"
        '
        'txtDocId
        '
        Me.txtDocId.BackColor = System.Drawing.Color.Khaki
        Me.txtDocId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDocId.Location = New System.Drawing.Point(287, 156)
        Me.txtDocId.Name = "txtDocId"
        Me.txtDocId.ReadOnly = True
        Me.txtDocId.Size = New System.Drawing.Size(149, 21)
        Me.txtDocId.TabIndex = 5
        Me.txtDocId.Text = "DOC..."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(219, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "文件编号"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(41, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "备注"
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(94, 194)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(342, 96)
        Me.txtRemark.TabIndex = 8
        Me.txtRemark.Text = ""
        '
        'btnHeaderSave
        '
        Me.btnHeaderSave.Location = New System.Drawing.Point(140, 309)
        Me.btnHeaderSave.Name = "btnHeaderSave"
        Me.btnHeaderSave.Size = New System.Drawing.Size(75, 23)
        Me.btnHeaderSave.TabIndex = 9
        Me.btnHeaderSave.Text = "保存(&S)"
        Me.btnHeaderSave.UseVisualStyleBackColor = True
        '
        'btnHeaderCancel
        '
        Me.btnHeaderCancel.Location = New System.Drawing.Point(256, 309)
        Me.btnHeaderCancel.Name = "btnHeaderCancel"
        Me.btnHeaderCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnHeaderCancel.TabIndex = 10
        Me.btnHeaderCancel.Text = "取消(&C)"
        Me.btnHeaderCancel.UseVisualStyleBackColor = True
        '
        'txtShape
        '
        Me.txtShape.Location = New System.Drawing.Point(94, 62)
        Me.txtShape.Name = "txtShape"
        Me.txtShape.Size = New System.Drawing.Size(342, 21)
        Me.txtShape.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "形态"
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(41, 294)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(0, 12)
        Me.lblMsg.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(41, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "描述"
        '
        'txtPartName
        '
        Me.txtPartName.Location = New System.Drawing.Point(94, 99)
        Me.txtPartName.Name = "txtPartName"
        Me.txtPartName.Size = New System.Drawing.Size(342, 42)
        Me.txtPartName.TabIndex = 15
        Me.txtPartName.Text = ""
        '
        'FrmOnlineSopNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 341)
        Me.Controls.Add(Me.txtPartName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtShape)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.btnHeaderCancel)
        Me.Controls.Add(Me.btnHeaderSave)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDocId)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtVerNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSopName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmOnlineSopNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "在线SOP制作"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSopName As System.Windows.Forms.TextBox
    Friend WithEvents txtVerNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDocId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.RichTextBox
    Friend WithEvents btnHeaderSave As System.Windows.Forms.Button
    Friend WithEvents btnHeaderCancel As System.Windows.Forms.Button
    Friend WithEvents txtShape As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPartName As System.Windows.Forms.RichTextBox
End Class
