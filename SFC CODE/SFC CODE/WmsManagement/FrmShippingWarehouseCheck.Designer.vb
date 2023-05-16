<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmShippingWarehouseCheck
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
        Me.txtAvcoutid = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.txtCustDeliveryNO = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtSaddress = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.txtWarehouseCheckNote = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rBtnPass = New System.Windows.Forms.RadioButton()
        Me.rBtnReject = New System.Windows.Forms.RadioButton()
        Me.btnDefine = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAvcoutid
        '
        '
        '
        '
        Me.txtAvcoutid.Border.Class = "TextBoxBorder"
        Me.txtAvcoutid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAvcoutid.Location = New System.Drawing.Point(101, 12)
        Me.txtAvcoutid.Name = "txtAvcoutid"
        Me.txtAvcoutid.ReadOnly = True
        Me.txtAvcoutid.Size = New System.Drawing.Size(220, 21)
        Me.txtAvcoutid.TabIndex = 38
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(29, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(82, 23)
        Me.LabelX2.TabIndex = 37
        Me.LabelX2.Text = "出货单号"
        '
        'txtCustDeliveryNO
        '
        '
        '
        '
        Me.txtCustDeliveryNO.Border.Class = "TextBoxBorder"
        Me.txtCustDeliveryNO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCustDeliveryNO.Location = New System.Drawing.Point(101, 55)
        Me.txtCustDeliveryNO.Name = "txtCustDeliveryNO"
        Me.txtCustDeliveryNO.ReadOnly = True
        Me.txtCustDeliveryNO.Size = New System.Drawing.Size(220, 21)
        Me.txtCustDeliveryNO.TabIndex = 40
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(29, 55)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(82, 23)
        Me.LabelX1.TabIndex = 39
        Me.LabelX1.Text = "客户单号"
        '
        'txtSaddress
        '
        '
        '
        '
        Me.txtSaddress.Border.Class = "TextBoxBorder"
        Me.txtSaddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSaddress.Location = New System.Drawing.Point(101, 98)
        Me.txtSaddress.Name = "txtSaddress"
        Me.txtSaddress.Size = New System.Drawing.Size(220, 21)
        Me.txtSaddress.TabIndex = 42
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(29, 98)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(82, 23)
        Me.LabelX3.TabIndex = 41
        Me.LabelX3.Text = "出货地址"
        '
        'txtWarehouseCheckNote
        '
        '
        '
        '
        Me.txtWarehouseCheckNote.Border.Class = "TextBoxBorder"
        Me.txtWarehouseCheckNote.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtWarehouseCheckNote.Location = New System.Drawing.Point(101, 141)
        Me.txtWarehouseCheckNote.Name = "txtWarehouseCheckNote"
        Me.txtWarehouseCheckNote.Size = New System.Drawing.Size(220, 21)
        Me.txtWarehouseCheckNote.TabIndex = 44
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(29, 141)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(82, 23)
        Me.LabelX4.TabIndex = 43
        Me.LabelX4.Text = "审核说明"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rBtnReject)
        Me.Panel1.Controls.Add(Me.rBtnPass)
        Me.Panel1.Location = New System.Drawing.Point(29, 171)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(292, 35)
        Me.Panel1.TabIndex = 45
        '
        'rBtnPass
        '
        Me.rBtnPass.AutoSize = True
        Me.rBtnPass.Checked = True
        Me.rBtnPass.Location = New System.Drawing.Point(136, 9)
        Me.rBtnPass.Name = "rBtnPass"
        Me.rBtnPass.Size = New System.Drawing.Size(47, 16)
        Me.rBtnPass.TabIndex = 0
        Me.rBtnPass.TabStop = True
        Me.rBtnPass.Text = "通过"
        Me.rBtnPass.UseVisualStyleBackColor = True
        '
        'rBtnReject
        '
        Me.rBtnReject.AutoSize = True
        Me.rBtnReject.Location = New System.Drawing.Point(225, 9)
        Me.rBtnReject.Name = "rBtnReject"
        Me.rBtnReject.Size = New System.Drawing.Size(47, 16)
        Me.rBtnReject.TabIndex = 1
        Me.rBtnReject.Text = "驳回"
        Me.rBtnReject.UseVisualStyleBackColor = True
        '
        'btnDefine
        '
        Me.btnDefine.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDefine.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDefine.Location = New System.Drawing.Point(142, 219)
        Me.btnDefine.Name = "btnDefine"
        Me.btnDefine.Size = New System.Drawing.Size(60, 23)
        Me.btnDefine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDefine.TabIndex = 46
        Me.btnDefine.Text = "确定"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(261, 219)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(60, 23)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 47
        Me.btnCancel.Text = "取消"
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Location = New System.Drawing.Point(2, 219)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(134, 23)
        Me.lblMessage.TabIndex = 48
        '
        'FrmShippingWarehouseCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(347, 260)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDefine)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtWarehouseCheckNote)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.txtSaddress)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.txtCustDeliveryNO)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.txtAvcoutid)
        Me.Controls.Add(Me.LabelX2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmShippingWarehouseCheck"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "仓库出货确认"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtAvcoutid As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCustDeliveryNO As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtSaddress As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtWarehouseCheckNote As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rBtnReject As System.Windows.Forms.RadioButton
    Friend WithEvents rBtnPass As System.Windows.Forms.RadioButton
    Friend WithEvents btnDefine As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
End Class
