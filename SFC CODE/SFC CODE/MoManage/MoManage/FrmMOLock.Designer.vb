<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMOLock
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
        Me.txtMOID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLock = New System.Windows.Forms.Button()
        Me.btnUnLock = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBeforeMOState = New System.Windows.Forms.TextBox()
        Me.lblLock_UnlockTitle = New System.Windows.Forms.Label()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtMOID
        '
        Me.txtMOID.Location = New System.Drawing.Point(102, 45)
        Me.txtMOID.Name = "txtMOID"
        Me.txtMOID.ReadOnly = True
        Me.txtMOID.Size = New System.Drawing.Size(238, 21)
        Me.txtMOID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "工单编号:"
        '
        'btnLock
        '
        Me.btnLock.Location = New System.Drawing.Point(49, 244)
        Me.btnLock.Name = "btnLock"
        Me.btnLock.Size = New System.Drawing.Size(75, 23)
        Me.btnLock.TabIndex = 2
        Me.btnLock.Text = "锁定"
        Me.btnLock.UseVisualStyleBackColor = True
        '
        'btnUnLock
        '
        Me.btnUnLock.Location = New System.Drawing.Point(164, 244)
        Me.btnUnLock.Name = "btnUnLock"
        Me.btnUnLock.Size = New System.Drawing.Size(75, 23)
        Me.btnUnLock.TabIndex = 3
        Me.btnUnLock.Text = "解锁"
        Me.btnUnLock.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(286, 244)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "当前工单状态:"
        '
        'txtBeforeMOState
        '
        Me.txtBeforeMOState.Location = New System.Drawing.Point(102, 104)
        Me.txtBeforeMOState.Name = "txtBeforeMOState"
        Me.txtBeforeMOState.ReadOnly = True
        Me.txtBeforeMOState.Size = New System.Drawing.Size(238, 21)
        Me.txtBeforeMOState.TabIndex = 5
        '
        'lblLock_UnlockTitle
        '
        Me.lblLock_UnlockTitle.AutoSize = True
        Me.lblLock_UnlockTitle.Location = New System.Drawing.Point(51, 152)
        Me.lblLock_UnlockTitle.Name = "lblLock_UnlockTitle"
        Me.lblLock_UnlockTitle.Size = New System.Drawing.Size(35, 12)
        Me.lblLock_UnlockTitle.TabIndex = 8
        Me.lblLock_UnlockTitle.Text = "原因:"
        '
        'txtReason
        '
        Me.txtReason.Location = New System.Drawing.Point(102, 148)
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(238, 69)
        Me.txtReason.TabIndex = 7
        '
        'FrmMOLock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 313)
        Me.Controls.Add(Me.lblLock_UnlockTitle)
        Me.Controls.Add(Me.txtReason)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBeforeMOState)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnUnLock)
        Me.Controls.Add(Me.btnLock)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMOID)
        Me.Name = "FrmMOLock"
        Me.Text = "工单锁定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMOID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLock As System.Windows.Forms.Button
    Friend WithEvents btnUnLock As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBeforeMOState As System.Windows.Forms.TextBox
    Friend WithEvents lblLock_UnlockTitle As System.Windows.Forms.Label
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
End Class
