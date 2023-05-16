<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStandardJobSchedulingAddMain
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
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPartID = New System.Windows.Forms.TextBox()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtECN_No = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lklblFilePath = New System.Windows.Forms.LinkLabel()
        Me.btnUploadFile = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'BtnOK
        '
        Me.BtnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnOK.Location = New System.Drawing.Point(45, 280)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(75, 23)
        Me.BtnOK.TabIndex = 0
        Me.BtnOK.Text = "提交"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Location = New System.Drawing.Point(402, 280)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "机种:"
        '
        'txtPartID
        '
        Me.txtPartID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartID.Location = New System.Drawing.Point(84, 23)
        Me.txtPartID.Name = "txtPartID"
        Me.txtPartID.Size = New System.Drawing.Size(303, 21)
        Me.txtPartID.TabIndex = 3
        '
        'txtVersion
        '
        Me.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVersion.Location = New System.Drawing.Point(431, 23)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(46, 21)
        Me.txtVersion.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(393, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "版本:"
        '
        'txtECN_No
        '
        Me.txtECN_No.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtECN_No.Location = New System.Drawing.Point(84, 50)
        Me.txtECN_No.Name = "txtECN_No"
        Me.txtECN_No.ReadOnly = True
        Me.txtECN_No.Size = New System.Drawing.Size(393, 21)
        Me.txtECN_No.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "ENC编号:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(43, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "附件:"
        '
        'lklblFilePath
        '
        Me.lklblFilePath.AutoSize = True
        Me.lklblFilePath.LinkArea = New System.Windows.Forms.LinkArea(0, 1)
        Me.lklblFilePath.Location = New System.Drawing.Point(85, 90)
        Me.lklblFilePath.Name = "lklblFilePath"
        Me.lklblFilePath.Size = New System.Drawing.Size(11, 12)
        Me.lklblFilePath.TabIndex = 9
        Me.lklblFilePath.TabStop = True
        Me.lklblFilePath.Text = " "
        '
        'btnUploadFile
        '
        Me.btnUploadFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUploadFile.Location = New System.Drawing.Point(351, 79)
        Me.btnUploadFile.Name = "btnUploadFile"
        Me.btnUploadFile.Size = New System.Drawing.Size(126, 23)
        Me.btnUploadFile.TabIndex = 10
        Me.btnUploadFile.Text = "上传附件(图纸图片)"
        Me.btnUploadFile.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(43, 175)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "描述:"
        '
        'txtRemark
        '
        Me.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemark.Location = New System.Drawing.Point(84, 108)
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(393, 159)
        Me.txtRemark.TabIndex = 12
        '
        'FrmStandardJobSchedulingAddMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 311)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnUploadFile)
        Me.Controls.Add(Me.lklblFilePath)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtECN_No)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtVersion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPartID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.BtnOK)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmStandardJobSchedulingAddMain"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "新增"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPartID As System.Windows.Forms.TextBox
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtECN_No As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lklblFilePath As System.Windows.Forms.LinkLabel
    Friend WithEvents btnUploadFile As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
End Class
