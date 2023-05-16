<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRePrint
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
        Me.label5 = New System.Windows.Forms.Label()
        Me.txtPrintedTimes = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.txtReprintTime = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.txtRePrintSN = New System.Windows.Forms.TextBox()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.button2 = New System.Windows.Forms.Button()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.txtPWD = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(64, 113)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(71, 12)
        Me.label5.TabIndex = 25
        Me.label5.Text = "已打印次数:"
        '
        'txtPrintedTimes
        '
        Me.txtPrintedTimes.Location = New System.Drawing.Point(148, 110)
        Me.txtPrintedTimes.Name = "txtPrintedTimes"
        Me.txtPrintedTimes.ReadOnly = True
        Me.txtPrintedTimes.Size = New System.Drawing.Size(167, 21)
        Me.txtPrintedTimes.TabIndex = 24
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(64, 75)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(83, 12)
        Me.label4.TabIndex = 23
        Me.label4.Text = "上次打印时间:"
        '
        'txtReprintTime
        '
        Me.txtReprintTime.Location = New System.Drawing.Point(148, 72)
        Me.txtReprintTime.Name = "txtReprintTime"
        Me.txtReprintTime.ReadOnly = True
        Me.txtReprintTime.Size = New System.Drawing.Size(167, 21)
        Me.txtReprintTime.TabIndex = 22
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(84, 36)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(59, 12)
        Me.label3.TabIndex = 21
        Me.label3.Text = "重打条码:"
        '
        'txtRePrintSN
        '
        Me.txtRePrintSN.Location = New System.Drawing.Point(148, 32)
        Me.txtRePrintSN.Name = "txtRePrintSN"
        Me.txtRePrintSN.ReadOnly = True
        Me.txtRePrintSN.Size = New System.Drawing.Size(167, 21)
        Me.txtRePrintSN.TabIndex = 20
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Location = New System.Drawing.Point(178, 256)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(41, 12)
        Me.lblMsg.TabIndex = 19
        Me.lblMsg.Text = "lblMsg"
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(217, 299)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(75, 23)
        Me.button2.TabIndex = 18
        Me.button2.Text = "取消"
        Me.button2.UseVisualStyleBackColor = True
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(86, 299)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirm.TabIndex = 17
        Me.btnConfirm.Text = "确定"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'txtPWD
        '
        Me.txtPWD.Location = New System.Drawing.Point(148, 190)
        Me.txtPWD.Name = "txtPWD"
        Me.txtPWD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPWD.Size = New System.Drawing.Size(167, 21)
        Me.txtPWD.TabIndex = 16
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(84, 199)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(59, 12)
        Me.label2.TabIndex = 15
        Me.label2.Text = "解锁密码:"
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(148, 147)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(167, 21)
        Me.txtUserID.TabIndex = 14
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(89, 150)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(35, 12)
        Me.label1.TabIndex = 13
        Me.label1.Text = "工号:"
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(148, 232)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(167, 21)
        Me.txtRemark.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(84, 241)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 12)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "备注:"
        '
        'FrmRePrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 334)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.txtPrintedTimes)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.txtReprintTime)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.txtRePrintSN)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.txtPWD)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.label1)
        Me.Name = "FrmRePrint"
        Me.Text = "条码重新打印"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents txtPrintedTimes As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents txtReprintTime As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents txtRePrintSN As System.Windows.Forms.TextBox
    Private WithEvents lblMsg As System.Windows.Forms.Label
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents btnConfirm As System.Windows.Forms.Button
    Private WithEvents txtPWD As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents txtUserID As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents txtRemark As System.Windows.Forms.TextBox
    Private WithEvents Label6 As System.Windows.Forms.Label
End Class
