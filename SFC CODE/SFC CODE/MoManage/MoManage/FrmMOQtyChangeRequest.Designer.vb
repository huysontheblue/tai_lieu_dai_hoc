<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMOQtyChangeRequest
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
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtMOID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBeforeQty = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAddQty = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAfterQty = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(124, 270)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "确定"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(324, 270)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtMOID
        '
        Me.txtMOID.Location = New System.Drawing.Point(140, 36)
        Me.txtMOID.Name = "txtMOID"
        Me.txtMOID.ReadOnly = True
        Me.txtMOID.Size = New System.Drawing.Size(279, 21)
        Me.txtMOID.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(80, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "工单号："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "当期工单数量："
        '
        'txtBeforeQty
        '
        Me.txtBeforeQty.Location = New System.Drawing.Point(140, 76)
        Me.txtBeforeQty.Name = "txtBeforeQty"
        Me.txtBeforeQty.ReadOnly = True
        Me.txtBeforeQty.Size = New System.Drawing.Size(75, 21)
        Me.txtBeforeQty.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(48, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "工单调整数量："
        '
        'txtAddQty
        '
        Me.txtAddQty.Location = New System.Drawing.Point(140, 120)
        Me.txtAddQty.Name = "txtAddQty"
        Me.txtAddQty.Size = New System.Drawing.Size(279, 21)
        Me.txtAddQty.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(237, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "调整后工单数量："
        '
        'txtAfterQty
        '
        Me.txtAfterQty.Location = New System.Drawing.Point(344, 76)
        Me.txtAfterQty.Name = "txtAfterQty"
        Me.txtAfterQty.ReadOnly = True
        Me.txtAfterQty.Size = New System.Drawing.Size(75, 21)
        Me.txtAfterQty.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(48, 164)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 12)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "工单调整原因："
        '
        'txtReason
        '
        Me.txtReason.Location = New System.Drawing.Point(140, 160)
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(279, 54)
        Me.txtReason.TabIndex = 10
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Location = New System.Drawing.Point(138, 232)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(41, 12)
        Me.lblMsg.TabIndex = 12
        Me.lblMsg.Text = "......"
        '
        'FrmMOQtyChangeRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 305)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtReason)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtAfterQty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAddQty)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBeforeQty)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMOID)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Name = "FrmMOQtyChangeRequest"
        Me.Text = "工单补数申请"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtMOID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBeforeQty As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAddQty As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAfterQty As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
End Class
