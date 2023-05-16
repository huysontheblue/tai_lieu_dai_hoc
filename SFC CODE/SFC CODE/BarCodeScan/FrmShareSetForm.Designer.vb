<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmShareSetForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmShareSetForm))
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupShow = New System.Windows.Forms.GroupBox()
        Me.ButConfirm = New System.Windows.Forms.Button()
        Me.ButCancel = New System.Windows.Forms.Button()
        Me.TxtMoQty = New ULControls.textBoxUL()
        Me.TxtAvcPart = New ULControls.textBoxUL()
        Me.TxtCustomPart = New ULControls.textBoxUL()
        Me.TxtMotype = New ULControls.textBoxUL()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.LblMoType = New System.Windows.Forms.Label()
        Me.DtpTime = New System.Windows.Forms.DateTimePicker()
        Me.DtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CboSupport = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DtpSet = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CobLine = New System.Windows.Forms.ComboBox()
        Me.LabelLine = New System.Windows.Forms.Label()
        Me.CobSitId = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.mtxtMOid = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.TxtProductLot = New ULControls.textBoxUL()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCustType = New System.Windows.Forms.ComboBox()
        Me.TreePart = New System.Windows.Forms.TreeView()
        Me.GroupShow.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(188, 25)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 12)
        Me.Label18.TabIndex = 92
        Me.Label18.Text = "客户料号："
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupShow
        '
        Me.GroupShow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupShow.Controls.Add(Me.ButConfirm)
        Me.GroupShow.Controls.Add(Me.ButCancel)
        Me.GroupShow.Controls.Add(Me.TxtMoQty)
        Me.GroupShow.Controls.Add(Me.TxtAvcPart)
        Me.GroupShow.Controls.Add(Me.TxtCustomPart)
        Me.GroupShow.Controls.Add(Me.TxtMotype)
        Me.GroupShow.Controls.Add(Me.Label18)
        Me.GroupShow.Controls.Add(Me.Label20)
        Me.GroupShow.Controls.Add(Me.Label4)
        Me.GroupShow.Controls.Add(Me.Label31)
        Me.GroupShow.Location = New System.Drawing.Point(4, 294)
        Me.GroupShow.Name = "GroupShow"
        Me.GroupShow.Size = New System.Drawing.Size(516, 76)
        Me.GroupShow.TabIndex = 99
        Me.GroupShow.TabStop = False
        Me.GroupShow.Text = "工单资料信息"
        '
        'ButConfirm
        '
        Me.ButConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButConfirm.Location = New System.Drawing.Point(372, 21)
        Me.ButConfirm.Name = "ButConfirm"
        Me.ButConfirm.Size = New System.Drawing.Size(66, 21)
        Me.ButConfirm.TabIndex = 103
        Me.ButConfirm.Text = "确认"
        Me.ButConfirm.UseVisualStyleBackColor = True
        '
        'ButCancel
        '
        Me.ButCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButCancel.Location = New System.Drawing.Point(372, 48)
        Me.ButCancel.Name = "ButCancel"
        Me.ButCancel.Size = New System.Drawing.Size(66, 23)
        Me.ButCancel.TabIndex = 102
        Me.ButCancel.Text = "取消"
        Me.ButCancel.UseVisualStyleBackColor = True
        '
        'TxtMoQty
        '
        Me.TxtMoQty.BackColor = System.Drawing.Color.White
        Me.TxtMoQty.BorderColor = System.Drawing.Color.FromArgb(CType(CType(104, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.TxtMoQty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMoQty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtMoQty.HotColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtMoQty.Location = New System.Drawing.Point(259, 47)
        Me.TxtMoQty.Name = "TxtMoQty"
        Me.TxtMoQty.ReadOnly = True
        Me.TxtMoQty.Size = New System.Drawing.Size(101, 14)
        Me.TxtMoQty.TabIndex = 100
        '
        'TxtAvcPart
        '
        Me.TxtAvcPart.BackColor = System.Drawing.Color.White
        Me.TxtAvcPart.BorderColor = System.Drawing.Color.FromArgb(CType(CType(104, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.TxtAvcPart.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAvcPart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtAvcPart.HotColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtAvcPart.Location = New System.Drawing.Point(78, 47)
        Me.TxtAvcPart.Name = "TxtAvcPart"
        Me.TxtAvcPart.ReadOnly = True
        Me.TxtAvcPart.Size = New System.Drawing.Size(101, 14)
        Me.TxtAvcPart.TabIndex = 99
        '
        'TxtCustomPart
        '
        Me.TxtCustomPart.BackColor = System.Drawing.Color.White
        Me.TxtCustomPart.BorderColor = System.Drawing.Color.FromArgb(CType(CType(104, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.TxtCustomPart.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCustomPart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtCustomPart.HotColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtCustomPart.Location = New System.Drawing.Point(259, 22)
        Me.TxtCustomPart.Name = "TxtCustomPart"
        Me.TxtCustomPart.ReadOnly = True
        Me.TxtCustomPart.Size = New System.Drawing.Size(101, 14)
        Me.TxtCustomPart.TabIndex = 98
        '
        'TxtMotype
        '
        Me.TxtMotype.BackColor = System.Drawing.Color.White
        Me.TxtMotype.BorderColor = System.Drawing.Color.FromArgb(CType(CType(104, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.TxtMotype.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMotype.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtMotype.HotColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtMotype.Location = New System.Drawing.Point(78, 21)
        Me.TxtMotype.Name = "TxtMotype"
        Me.TxtMotype.ReadOnly = True
        Me.TxtMotype.Size = New System.Drawing.Size(101, 14)
        Me.TxtMotype.TabIndex = 97
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(15, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 12)
        Me.Label20.TabIndex = 88
        Me.Label20.Text = "工单类型："
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(188, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "工单数量："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(15, 50)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(65, 12)
        Me.Label31.TabIndex = 90
        Me.Label31.Text = "料件编号："
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblMoType
        '
        Me.LblMoType.AutoSize = True
        Me.LblMoType.ForeColor = System.Drawing.SystemColors.Desktop
        Me.LblMoType.Location = New System.Drawing.Point(228, 44)
        Me.LblMoType.Name = "LblMoType"
        Me.LblMoType.Size = New System.Drawing.Size(59, 12)
        Me.LblMoType.TabIndex = 77
        Me.LblMoType.Text = "LblMoType"
        '
        'DtpTime
        '
        Me.DtpTime.CustomFormat = "HH:mm:ss"
        Me.DtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpTime.Location = New System.Drawing.Point(299, 95)
        Me.DtpTime.Name = "DtpTime"
        Me.DtpTime.ShowUpDown = True
        Me.DtpTime.Size = New System.Drawing.Size(180, 21)
        Me.DtpTime.TabIndex = 7
        Me.DtpTime.Value = New Date(2007, 1, 12, 2, 12, 0, 0)
        '
        'DtpDate
        '
        Me.DtpDate.Location = New System.Drawing.Point(299, 67)
        Me.DtpDate.Name = "DtpDate"
        Me.DtpDate.Size = New System.Drawing.Size(180, 21)
        Me.DtpDate.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(228, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "开始时间："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CboSupport
        '
        Me.CboSupport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboSupport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboSupport.BackColor = System.Drawing.Color.White
        Me.CboSupport.FormattingEnabled = True
        Me.CboSupport.Location = New System.Drawing.Point(80, 41)
        Me.CboSupport.Name = "CboSupport"
        Me.CboSupport.Size = New System.Drawing.Size(140, 20)
        Me.CboSupport.TabIndex = 1
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(9, 17)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 12)
        Me.Label23.TabIndex = 48
        Me.Label23.Text = "工单编号："
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 45)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 12)
        Me.Label15.TabIndex = 68
        Me.Label15.Text = "客户名称："
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DtpSet
        '
        Me.DtpSet.Location = New System.Drawing.Point(299, 39)
        Me.DtpSet.Name = "DtpSet"
        Me.DtpSet.Size = New System.Drawing.Size(180, 21)
        Me.DtpSet.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(228, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 72
        Me.Label11.Text = "条码日期："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CobLine
        '
        Me.CobLine.BackColor = System.Drawing.Color.White
        Me.CobLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobLine.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CobLine.FormattingEnabled = True
        Me.CobLine.Location = New System.Drawing.Point(80, 71)
        Me.CobLine.Name = "CobLine"
        Me.CobLine.Size = New System.Drawing.Size(140, 20)
        Me.CobLine.TabIndex = 3
        '
        'LabelLine
        '
        Me.LabelLine.AutoSize = True
        Me.LabelLine.Location = New System.Drawing.Point(9, 74)
        Me.LabelLine.Name = "LabelLine"
        Me.LabelLine.Size = New System.Drawing.Size(65, 12)
        Me.LabelLine.TabIndex = 76
        Me.LabelLine.Text = "线别编号："
        Me.LabelLine.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CobSitId
        '
        Me.CobSitId.BackColor = System.Drawing.Color.White
        Me.CobSitId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobSitId.FormattingEnabled = True
        Me.CobSitId.Location = New System.Drawing.Point(299, 14)
        Me.CobSitId.Name = "CobSitId"
        Me.CobSitId.Size = New System.Drawing.Size(180, 20)
        Me.CobSitId.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(228, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "站点编号："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.mtxtMOid)
        Me.GroupBox2.Controls.Add(Me.TxtProductLot)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.CobSitId)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.LabelLine)
        Me.GroupBox2.Controls.Add(Me.cboCustType)
        Me.GroupBox2.Controls.Add(Me.CobLine)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.DtpSet)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.CboSupport)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.DtpDate)
        Me.GroupBox2.Controls.Add(Me.DtpTime)
        Me.GroupBox2.Controls.Add(Me.LblMoType)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(517, 149)
        Me.GroupBox2.TabIndex = 98
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "扫描信息设置"
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
        Me.mtxtMOid.Location = New System.Drawing.Point(80, 13)
        Me.mtxtMOid.Name = "mtxtMOid"
        Me.mtxtMOid.ReadOnly = True
        Me.mtxtMOid.Size = New System.Drawing.Size(142, 21)
        Me.mtxtMOid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtMOid.TabIndex = 108
        Me.mtxtMOid.Text = ""
        '
        'TxtProductLot
        '
        Me.TxtProductLot.BackColor = System.Drawing.Color.White
        Me.TxtProductLot.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtProductLot.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtProductLot.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.TxtProductLot.HotColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtProductLot.Location = New System.Drawing.Point(79, 98)
        Me.TxtProductLot.Name = "TxtProductLot"
        Me.TxtProductLot.ReadOnly = True
        Me.TxtProductLot.Size = New System.Drawing.Size(140, 14)
        Me.TxtProductLot.TabIndex = 106
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "生产批次："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "来料类型："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCustType
        '
        Me.cboCustType.BackColor = System.Drawing.Color.White
        Me.cboCustType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCustType.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboCustType.FormattingEnabled = True
        Me.cboCustType.Location = New System.Drawing.Point(79, 123)
        Me.cboCustType.Name = "cboCustType"
        Me.cboCustType.Size = New System.Drawing.Size(140, 20)
        Me.cboCustType.TabIndex = 3
        '
        'TreePart
        '
        Me.TreePart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreePart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreePart.CheckBoxes = True
        Me.TreePart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TreePart.Location = New System.Drawing.Point(4, 158)
        Me.TreePart.Name = "TreePart"
        Me.TreePart.Size = New System.Drawing.Size(516, 130)
        Me.TreePart.TabIndex = 100
        '
        'FrmShareSetForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(519, 375)
        Me.Controls.Add(Me.TreePart)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmShareSetForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "扫描资料设置界面"
        Me.GroupShow.ResumeLayout(False)
        Me.GroupShow.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupShow As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TxtCustomPart As ULControls.textBoxUL
    Friend WithEvents TxtMotype As ULControls.textBoxUL
    Friend WithEvents TxtMoQty As ULControls.textBoxUL
    Friend WithEvents TxtAvcPart As ULControls.textBoxUL
    Friend WithEvents LblMoType As System.Windows.Forms.Label
    Friend WithEvents DtpTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CboSupport As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DtpSet As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CobLine As System.Windows.Forms.ComboBox
    Friend WithEvents LabelLine As System.Windows.Forms.Label
    Friend WithEvents CobSitId As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TreePart As System.Windows.Forms.TreeView
    Friend WithEvents TxtProductLot As ULControls.textBoxUL
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButConfirm As System.Windows.Forms.Button
    Friend WithEvents ButCancel As System.Windows.Forms.Button
    Friend WithEvents mtxtMOid As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCustType As System.Windows.Forms.ComboBox
End Class
