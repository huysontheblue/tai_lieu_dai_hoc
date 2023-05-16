<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChildPrintMoNum
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
        Me.txtMotherMoid = New System.Windows.Forms.TextBox()
        Me.txtMotherBarcode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPrintNum = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "母工单："
        '
        'txtMotherMoid
        '
        Me.txtMotherMoid.Location = New System.Drawing.Point(102, 23)
        Me.txtMotherMoid.Name = "txtMotherMoid"
        Me.txtMotherMoid.Size = New System.Drawing.Size(260, 21)
        Me.txtMotherMoid.TabIndex = 1
        '
        'txtMotherBarcode
        '
        Me.txtMotherBarcode.Location = New System.Drawing.Point(102, 61)
        Me.txtMotherBarcode.Name = "txtMotherBarcode"
        Me.txtMotherBarcode.Size = New System.Drawing.Size(260, 21)
        Me.txtMotherBarcode.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "母工单条码："
        '
        'txtPrintNum
        '
        Me.txtPrintNum.Location = New System.Drawing.Point(102, 97)
        Me.txtPrintNum.Name = "txtPrintNum"
        Me.txtPrintNum.Size = New System.Drawing.Size(109, 21)
        Me.txtPrintNum.TabIndex = 5
        Me.txtPrintNum.Text = "1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "打印数量："
        '
        'BtnOk
        '
        Me.BtnOk.Location = New System.Drawing.Point(89, 145)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(73, 29)
        Me.BtnOk.TabIndex = 6
        Me.BtnOk.Text = "确定打印"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(210, 145)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(73, 29)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "取消打印"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'FrmChildPrintMoNum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(374, 205)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.txtPrintNum)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMotherBarcode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMotherMoid)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmChildPrintMoNum"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "打印母工单条码"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMotherMoid As System.Windows.Forms.TextBox
    Friend WithEvents txtMotherBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPrintNum As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
