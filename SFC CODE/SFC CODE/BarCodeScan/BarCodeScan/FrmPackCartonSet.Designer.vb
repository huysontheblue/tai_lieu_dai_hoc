<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPackCartonSet
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPackCartonSet))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CobPalletStyle = New System.Windows.Forms.ComboBox()
        Me.LabelLine = New System.Windows.Forms.Label()
        Me.CobLine = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DtpSet = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CboMoid = New System.Windows.Forms.ComboBox()
        Me.CboSupport = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DtpDate = New System.Windows.Forms.DateTimePicker()
        Me.DtpTime = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.GbMessage = New System.Windows.Forms.GroupBox()
        Me.LblMoType = New System.Windows.Forms.Label()
        Me.TxtMoQty = New ULControls.textBoxUL()
        Me.TxtAvcPart = New ULControls.textBoxUL()
        Me.TxtBarcodeLen = New ULControls.textBoxUL()
        Me.TxtMoType = New ULControls.textBoxUL()
        Me.TxtCustomerPart = New ULControls.textBoxUL()
        Me.TxtDeptName = New ULControls.textBoxUL()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BnConFrm = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GbMessage.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.CobPalletStyle)
        Me.GroupBox2.Controls.Add(Me.LabelLine)
        Me.GroupBox2.Controls.Add(Me.CobLine)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.DtpSet)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.CboMoid)
        Me.GroupBox2.Controls.Add(Me.CboSupport)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.DtpDate)
        Me.GroupBox2.Controls.Add(Me.DtpTime)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(446, 125)
        Me.GroupBox2.TabIndex = 98
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "掃描信息設置"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "裝棧方式："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CobPalletStyle
        '
        Me.CobPalletStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobPalletStyle.FormattingEnabled = True
        Me.CobPalletStyle.Location = New System.Drawing.Point(80, 97)
        Me.CobPalletStyle.Name = "CobPalletStyle"
        Me.CobPalletStyle.Size = New System.Drawing.Size(140, 20)
        Me.CobPalletStyle.TabIndex = 82
        '
        'LabelLine
        '
        Me.LabelLine.AutoSize = True
        Me.LabelLine.Location = New System.Drawing.Point(13, 73)
        Me.LabelLine.Name = "LabelLine"
        Me.LabelLine.Size = New System.Drawing.Size(65, 12)
        Me.LabelLine.TabIndex = 74
        Me.LabelLine.Text = "線別編號："
        Me.LabelLine.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CobLine
        '
        Me.CobLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobLine.FormattingEnabled = True
        Me.CobLine.Location = New System.Drawing.Point(80, 70)
        Me.CobLine.Name = "CobLine"
        Me.CobLine.Size = New System.Drawing.Size(140, 20)
        Me.CobLine.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(229, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 72
        Me.Label11.Text = "條碼日期："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DtpSet
        '
        Me.DtpSet.Location = New System.Drawing.Point(298, 17)
        Me.DtpSet.Name = "DtpSet"
        Me.DtpSet.Size = New System.Drawing.Size(140, 21)
        Me.DtpSet.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(14, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 12)
        Me.Label15.TabIndex = 68
        Me.Label15.Text = "客戶名稱："
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(13, 46)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 12)
        Me.Label23.TabIndex = 48
        Me.Label23.Text = "工單編號："
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CboMoid
        '
        Me.CboMoid.FormattingEnabled = True
        Me.CboMoid.Location = New System.Drawing.Point(80, 43)
        Me.CboMoid.Name = "CboMoid"
        Me.CboMoid.Size = New System.Drawing.Size(140, 20)
        Me.CboMoid.TabIndex = 2
        '
        'CboSupport
        '
        Me.CboSupport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSupport.FormattingEnabled = True
        Me.CboSupport.Location = New System.Drawing.Point(80, 17)
        Me.CboSupport.Name = "CboSupport"
        Me.CboSupport.Size = New System.Drawing.Size(140, 20)
        Me.CboSupport.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(229, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "開始時間："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DtpDate
        '
        Me.DtpDate.Location = New System.Drawing.Point(298, 43)
        Me.DtpDate.Name = "DtpDate"
        Me.DtpDate.Size = New System.Drawing.Size(140, 21)
        Me.DtpDate.TabIndex = 6
        '
        'DtpTime
        '
        Me.DtpTime.CustomFormat = "HH:mm:ss"
        Me.DtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpTime.Location = New System.Drawing.Point(298, 70)
        Me.DtpTime.Name = "DtpTime"
        Me.DtpTime.ShowUpDown = True
        Me.DtpTime.Size = New System.Drawing.Size(140, 21)
        Me.DtpTime.TabIndex = 7
        Me.DtpTime.Value = New Date(2007, 1, 12, 2, 12, 0, 0)
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(187, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 12)
        Me.Label18.TabIndex = 92
        Me.Label18.Text = "客戶料號："
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(187, 50)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(65, 12)
        Me.Label34.TabIndex = 94
        Me.Label34.Text = "條碼長度："
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(17, 22)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(65, 12)
        Me.Label29.TabIndex = 86
        Me.Label29.Text = "部門名稱："
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GbMessage
        '
        Me.GbMessage.Controls.Add(Me.BnConFrm)
        Me.GbMessage.Controls.Add(Me.Button1)
        Me.GbMessage.Controls.Add(Me.LblMoType)
        Me.GbMessage.Controls.Add(Me.TxtMoQty)
        Me.GbMessage.Controls.Add(Me.TxtAvcPart)
        Me.GbMessage.Controls.Add(Me.TxtBarcodeLen)
        Me.GbMessage.Controls.Add(Me.TxtMoType)
        Me.GbMessage.Controls.Add(Me.TxtCustomerPart)
        Me.GbMessage.Controls.Add(Me.TxtDeptName)
        Me.GbMessage.Controls.Add(Me.Label18)
        Me.GbMessage.Controls.Add(Me.Label34)
        Me.GbMessage.Controls.Add(Me.Label29)
        Me.GbMessage.Controls.Add(Me.Label20)
        Me.GbMessage.Controls.Add(Me.Label4)
        Me.GbMessage.Controls.Add(Me.Label31)
        Me.GbMessage.Location = New System.Drawing.Point(3, 130)
        Me.GbMessage.Name = "GbMessage"
        Me.GbMessage.Size = New System.Drawing.Size(446, 116)
        Me.GbMessage.TabIndex = 97
        Me.GbMessage.TabStop = False
        Me.GbMessage.Text = "工單對應信息"
        '
        'LblMoType
        '
        Me.LblMoType.AutoSize = True
        Me.LblMoType.Location = New System.Drawing.Point(370, 13)
        Me.LblMoType.Name = "LblMoType"
        Me.LblMoType.Size = New System.Drawing.Size(0, 12)
        Me.LblMoType.TabIndex = 106
        Me.LblMoType.Visible = False
        '
        'TxtMoQty
        '
        Me.TxtMoQty.BackColor = System.Drawing.SystemColors.Control
        Me.TxtMoQty.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtMoQty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMoQty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.TxtMoQty.HotColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtMoQty.Location = New System.Drawing.Point(247, 70)
        Me.TxtMoQty.Name = "TxtMoQty"
        Me.TxtMoQty.ReadOnly = True
        Me.TxtMoQty.Size = New System.Drawing.Size(105, 14)
        Me.TxtMoQty.TabIndex = 105
        '
        'TxtAvcPart
        '
        Me.TxtAvcPart.BackColor = System.Drawing.SystemColors.Control
        Me.TxtAvcPart.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtAvcPart.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAvcPart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.TxtAvcPart.HotColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtAvcPart.Location = New System.Drawing.Point(77, 71)
        Me.TxtAvcPart.Name = "TxtAvcPart"
        Me.TxtAvcPart.ReadOnly = True
        Me.TxtAvcPart.Size = New System.Drawing.Size(105, 14)
        Me.TxtAvcPart.TabIndex = 104
        '
        'TxtBarcodeLen
        '
        Me.TxtBarcodeLen.BackColor = System.Drawing.SystemColors.Control
        Me.TxtBarcodeLen.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtBarcodeLen.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBarcodeLen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.TxtBarcodeLen.HotColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtBarcodeLen.Location = New System.Drawing.Point(247, 45)
        Me.TxtBarcodeLen.Name = "TxtBarcodeLen"
        Me.TxtBarcodeLen.ReadOnly = True
        Me.TxtBarcodeLen.Size = New System.Drawing.Size(105, 14)
        Me.TxtBarcodeLen.TabIndex = 103
        '
        'TxtMoType
        '
        Me.TxtMoType.BackColor = System.Drawing.SystemColors.Control
        Me.TxtMoType.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtMoType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMoType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.TxtMoType.HotColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtMoType.Location = New System.Drawing.Point(79, 45)
        Me.TxtMoType.Name = "TxtMoType"
        Me.TxtMoType.ReadOnly = True
        Me.TxtMoType.Size = New System.Drawing.Size(105, 14)
        Me.TxtMoType.TabIndex = 102
        '
        'TxtCustomerPart
        '
        Me.TxtCustomerPart.BackColor = System.Drawing.SystemColors.Control
        Me.TxtCustomerPart.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtCustomerPart.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCustomerPart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.TxtCustomerPart.HotColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtCustomerPart.Location = New System.Drawing.Point(247, 19)
        Me.TxtCustomerPart.Name = "TxtCustomerPart"
        Me.TxtCustomerPart.ReadOnly = True
        Me.TxtCustomerPart.Size = New System.Drawing.Size(105, 14)
        Me.TxtCustomerPart.TabIndex = 101
        '
        'TxtDeptName
        '
        Me.TxtDeptName.BackColor = System.Drawing.SystemColors.Control
        Me.TxtDeptName.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtDeptName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDeptName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.TxtDeptName.HotColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtDeptName.Location = New System.Drawing.Point(79, 18)
        Me.TxtDeptName.Name = "TxtDeptName"
        Me.TxtDeptName.ReadOnly = True
        Me.TxtDeptName.Size = New System.Drawing.Size(105, 14)
        Me.TxtDeptName.TabIndex = 100
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(17, 48)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 12)
        Me.Label20.TabIndex = 88
        Me.Label20.Text = "工單類型："
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(187, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "工單數量："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(17, 75)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(65, 12)
        Me.Label31.TabIndex = 90
        Me.Label31.Text = "AVC  P/N："
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(372, 60)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(69, 24)
        Me.Button1.TabIndex = 107
        Me.Button1.Text = "确定(&O)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BnConFrm
        '
        Me.BnConFrm.Location = New System.Drawing.Point(372, 22)
        Me.BnConFrm.Name = "BnConFrm"
        Me.BnConFrm.Size = New System.Drawing.Size(69, 24)
        Me.BnConFrm.TabIndex = 108
        Me.BnConFrm.Text = "确定(&O)"
        Me.BnConFrm.UseVisualStyleBackColor = True
        '
        'FrmPackCartonSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 249)
        Me.Controls.Add(Me.GbMessage)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPackCartonSet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "包裝站掃描資料設置"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GbMessage.ResumeLayout(False)
        Me.GbMessage.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelLine As System.Windows.Forms.Label
    Friend WithEvents CobLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DtpSet As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents CboMoid As System.Windows.Forms.ComboBox
    Friend WithEvents CboSupport As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents GbMessage As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TxtDeptName As ULControls.textBoxUL
    Friend WithEvents TxtMoQty As ULControls.textBoxUL
    Friend WithEvents TxtAvcPart As ULControls.textBoxUL
    Friend WithEvents TxtBarcodeLen As ULControls.textBoxUL
    Friend WithEvents TxtMoType As ULControls.textBoxUL
    Friend WithEvents TxtCustomerPart As ULControls.textBoxUL
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CobPalletStyle As System.Windows.Forms.ComboBox
    Friend WithEvents LblMoType As System.Windows.Forms.Label
    Friend WithEvents BnConFrm As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
