<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCheckCarton
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
        Me.BnCancel = New System.Windows.Forms.Button()
        Me.TxtBarcode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.mtxtMOid = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CboSupport = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkIsSystemPrint = New System.Windows.Forms.CheckBox()
        Me.txtCartonId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkIsSame = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'BnCancel
        '
        Me.BnCancel.Location = New System.Drawing.Point(149, 220)
        Me.BnCancel.Name = "BnCancel"
        Me.BnCancel.Size = New System.Drawing.Size(118, 35)
        Me.BnCancel.TabIndex = 75
        Me.BnCancel.Text = "关闭"
        Me.BnCancel.UseVisualStyleBackColor = True
        '
        'TxtBarcode
        '
        Me.TxtBarcode.Location = New System.Drawing.Point(149, 92)
        Me.TxtBarcode.MaxLength = 100
        Me.TxtBarcode.Name = "TxtBarcode"
        Me.TxtBarcode.Size = New System.Drawing.Size(191, 21)
        Me.TxtBarcode.TabIndex = 72
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(77, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 12)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "扫描箱条码:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(77, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "工单:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMessage.Location = New System.Drawing.Point(58, 139)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(322, 80)
        Me.lblMessage.TabIndex = 87
        Me.lblMessage.Text = "PASS"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxtMOid
        '
        '
        '
        '
        Me.mtxtMOid.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtMOid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtMOid.ButtonCustom.Image = Global.BarCodeScan.My.Resources.Resources.query
        Me.mtxtMOid.ButtonCustom.Visible = True
        Me.mtxtMOid.Location = New System.Drawing.Point(149, 36)
        Me.mtxtMOid.Name = "mtxtMOid"
        Me.mtxtMOid.ReadOnly = True
        Me.mtxtMOid.Size = New System.Drawing.Size(191, 21)
        Me.mtxtMOid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtMOid.TabIndex = 108
        Me.mtxtMOid.Text = ""
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(76, 13)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 12)
        Me.Label15.TabIndex = 140
        Me.Label15.Text = "客户名称："
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CboSupport
        '
        Me.CboSupport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboSupport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboSupport.BackColor = System.Drawing.Color.White
        Me.CboSupport.FormattingEnabled = True
        Me.CboSupport.Location = New System.Drawing.Point(149, 10)
        Me.CboSupport.Name = "CboSupport"
        Me.CboSupport.Size = New System.Drawing.Size(191, 20)
        Me.CboSupport.TabIndex = 141
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(64, 122)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 12)
        Me.Label11.TabIndex = 142
        Me.Label11.Text = "是否系统打印"
        '
        'chkIsSystemPrint
        '
        Me.chkIsSystemPrint.AutoSize = True
        Me.chkIsSystemPrint.Location = New System.Drawing.Point(149, 122)
        Me.chkIsSystemPrint.Name = "chkIsSystemPrint"
        Me.chkIsSystemPrint.Size = New System.Drawing.Size(15, 14)
        Me.chkIsSystemPrint.TabIndex = 143
        Me.chkIsSystemPrint.UseVisualStyleBackColor = True
        '
        'txtCartonId
        '
        Me.txtCartonId.Location = New System.Drawing.Point(149, 65)
        Me.txtCartonId.MaxLength = 100
        Me.txtCartonId.Name = "txtCartonId"
        Me.txtCartonId.Size = New System.Drawing.Size(191, 21)
        Me.txtCartonId.TabIndex = 72
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(77, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "是否相同:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkIsSame
        '
        Me.chkIsSame.AutoSize = True
        Me.chkIsSame.Checked = True
        Me.chkIsSame.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsSame.Location = New System.Drawing.Point(65, 68)
        Me.chkIsSame.Name = "chkIsSame"
        Me.chkIsSame.Size = New System.Drawing.Size(15, 14)
        Me.chkIsSame.TabIndex = 143
        Me.chkIsSame.UseVisualStyleBackColor = True
        '
        'FrmCheckCarton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 267)
        Me.Controls.Add(Me.chkIsSame)
        Me.Controls.Add(Me.chkIsSystemPrint)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.CboSupport)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.mtxtMOid)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.BnCancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCartonId)
        Me.Controls.Add(Me.TxtBarcode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "FrmCheckCarton"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "检查打印的箱是否正确"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BnCancel As System.Windows.Forms.Button
    Friend WithEvents TxtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents mtxtMOid As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CboSupport As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkIsSystemPrint As System.Windows.Forms.CheckBox
    Friend WithEvents txtCartonId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkIsSame As System.Windows.Forms.CheckBox
End Class
