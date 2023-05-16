<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPictureCut
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
        Me.panel = New System.Windows.Forms.Panel()
        Me.picArea = New System.Windows.Forms.PictureBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.track = New System.Windows.Forms.TrackBar()
        Me.maxPic = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panel.SuspendLayout()
        CType(Me.picArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.track, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel
        '
        Me.panel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel.Controls.Add(Me.picArea)
        Me.panel.Location = New System.Drawing.Point(0, 0)
        Me.panel.Name = "panel"
        Me.panel.Size = New System.Drawing.Size(530, 390)
        Me.panel.TabIndex = 0
        '
        'picArea
        '
        Me.picArea.BackColor = System.Drawing.Color.LightSeaGreen
        Me.picArea.Location = New System.Drawing.Point(5, 5)
        Me.picArea.Name = "picArea"
        Me.picArea.Size = New System.Drawing.Size(512, 374)
        Me.picArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picArea.TabIndex = 0
        Me.picArea.TabStop = False
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(19, 396)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnLoad.TabIndex = 1
        Me.btnLoad.Text = "上传图片"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'track
        '
        Me.track.Location = New System.Drawing.Point(166, 394)
        Me.track.Maximum = 20
        Me.track.Name = "track"
        Me.track.Size = New System.Drawing.Size(150, 45)
        Me.track.TabIndex = 2
        '
        'maxPic
        '
        Me.maxPic.AutoSize = True
        Me.maxPic.Location = New System.Drawing.Point(336, 400)
        Me.maxPic.Name = "maxPic"
        Me.maxPic.Size = New System.Drawing.Size(72, 16)
        Me.maxPic.TabIndex = 3
        Me.maxPic.Text = "显示最佳"
        Me.maxPic.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(425, 396)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "确认裁剪"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(115, 400)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "选框大小"
        '
        'FrmPictureCut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(529, 422)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.maxPic)
        Me.Controls.Add(Me.track)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmPictureCut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "裁剪图片"
        Me.panel.ResumeLayout(False)
        CType(Me.picArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.track, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panel As System.Windows.Forms.Panel
    Friend WithEvents picArea As System.Windows.Forms.PictureBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents track As System.Windows.Forms.TrackBar
    Friend WithEvents maxPic As System.Windows.Forms.CheckBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
