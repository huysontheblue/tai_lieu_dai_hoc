<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOnlineMoreCartonPrint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOnlineMoreCartonPrint))
        Me.txtWeightFou = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TxtPassWordFou = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtBarcodeFou = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtBarcodeTre = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtBarcodeTwo = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtBarcodeOne = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnOk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtWeightFou
        '
        Me.txtWeightFou.Location = New System.Drawing.Point(104, 13)
        Me.txtWeightFou.MaxLength = 10
        Me.txtWeightFou.Name = "txtWeightFou"
        Me.txtWeightFou.Size = New System.Drawing.Size(149, 21)
        Me.txtWeightFou.TabIndex = 86
        Me.txtWeightFou.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(47, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 12)
        Me.Label18.TabIndex = 87
        Me.Label18.Text = "整箱重量:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtPassWordFou
        '
        Me.TxtPassWordFou.AcceptsReturn = True
        Me.TxtPassWordFou.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPassWordFou.Location = New System.Drawing.Point(104, 149)
        Me.TxtPassWordFou.MaxLength = 40
        Me.TxtPassWordFou.Name = "TxtPassWordFou"
        Me.TxtPassWordFou.Size = New System.Drawing.Size(209, 21)
        Me.TxtPassWordFou.TabIndex = 96
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(39, 152)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 12)
        Me.Label17.TabIndex = 97
        Me.Label17.Text = "解锁密码:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBarcodeFou
        '
        Me.txtBarcodeFou.AcceptsReturn = True
        Me.txtBarcodeFou.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarcodeFou.Location = New System.Drawing.Point(104, 122)
        Me.txtBarcodeFou.MaxLength = 40
        Me.txtBarcodeFou.Name = "txtBarcodeFou"
        Me.txtBarcodeFou.Size = New System.Drawing.Size(209, 21)
        Me.txtBarcodeFou.TabIndex = 94
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(14, 125)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 12)
        Me.Label16.TabIndex = 95
        Me.Label16.Text = "第四箱产品条码:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBarcodeTre
        '
        Me.txtBarcodeTre.AcceptsReturn = True
        Me.txtBarcodeTre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarcodeTre.Location = New System.Drawing.Point(104, 95)
        Me.txtBarcodeTre.MaxLength = 40
        Me.txtBarcodeTre.Name = "txtBarcodeTre"
        Me.txtBarcodeTre.Size = New System.Drawing.Size(209, 21)
        Me.txtBarcodeTre.TabIndex = 92
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(14, 98)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(95, 12)
        Me.Label15.TabIndex = 93
        Me.Label15.Text = "第三箱产品条码:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBarcodeTwo
        '
        Me.txtBarcodeTwo.AcceptsReturn = True
        Me.txtBarcodeTwo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarcodeTwo.Location = New System.Drawing.Point(104, 68)
        Me.txtBarcodeTwo.MaxLength = 40
        Me.txtBarcodeTwo.Name = "txtBarcodeTwo"
        Me.txtBarcodeTwo.Size = New System.Drawing.Size(209, 21)
        Me.txtBarcodeTwo.TabIndex = 90
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 71)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(95, 12)
        Me.Label14.TabIndex = 91
        Me.Label14.Text = "第二箱产品条码:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBarcodeOne
        '
        Me.txtBarcodeOne.AcceptsReturn = True
        Me.txtBarcodeOne.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarcodeOne.Location = New System.Drawing.Point(104, 41)
        Me.txtBarcodeOne.MaxLength = 40
        Me.txtBarcodeOne.Name = "txtBarcodeOne"
        Me.txtBarcodeOne.Size = New System.Drawing.Size(209, 21)
        Me.txtBarcodeOne.TabIndex = 88
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 44)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 12)
        Me.Label13.TabIndex = 89
        Me.Label13.Text = "第一箱产品条码:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(259, 18)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(17, 12)
        Me.Label19.TabIndex = 98
        Me.Label19.Text = "KG"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnCancel
        '
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancel.Location = New System.Drawing.Point(198, 186)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(66, 23)
        Me.BtnCancel.TabIndex = 100
        Me.BtnCancel.Text = "取 消"
        Me.BtnCancel.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        Me.BtnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOk.Location = New System.Drawing.Point(39, 186)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(66, 23)
        Me.BtnOk.TabIndex = 99
        Me.BtnOk.Text = "确 定"
        Me.BtnOk.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'FrmOnlineMoreCartonPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 220)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TxtPassWordFou)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtBarcodeFou)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtBarcodeTre)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtBarcodeTwo)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtBarcodeOne)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtWeightFou)
        Me.Controls.Add(Me.Label18)
        Me.Name = "FrmOnlineMoreCartonPrint"
        Me.Text = "在线多内盒打印外箱"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtWeightFou As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtPassWordFou As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtBarcodeFou As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtBarcodeTre As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtBarcodeTwo As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtBarcodeOne As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnOk As System.Windows.Forms.Button
End Class
