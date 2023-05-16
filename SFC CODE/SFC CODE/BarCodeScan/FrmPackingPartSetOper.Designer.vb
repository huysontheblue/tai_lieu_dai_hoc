<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPackingPartSetOper
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
        Me.LabLPartID = New System.Windows.Forms.Label()
        Me.TxtLPartID = New System.Windows.Forms.TextBox()
        Me.LabCartonStyle = New System.Windows.Forms.Label()
        Me.CbbCartonStyle = New System.Windows.Forms.ComboBox()
        Me.TxtCartonQtyI = New System.Windows.Forms.TextBox()
        Me.LabCartonQtyI = New System.Windows.Forms.Label()
        Me.ChkIsAutoGenerateCarton = New System.Windows.Forms.CheckBox()
        Me.ChkIsScanQRCode = New System.Windows.Forms.CheckBox()
        Me.LabQRCodeStyle = New System.Windows.Forms.Label()
        Me.LabPECartonStyle = New System.Windows.Forms.Label()
        Me.ChkIsScanPECarton = New System.Windows.Forms.CheckBox()
        Me.CbbQRCodeStyle = New System.Windows.Forms.ComboBox()
        Me.CbbPECartonStyle = New System.Windows.Forms.ComboBox()
        Me.TxtPECartonQtyI = New System.Windows.Forms.TextBox()
        Me.LabPECartonQtyI = New System.Windows.Forms.Label()
        Me.CbbPpidStyle = New System.Windows.Forms.ComboBox()
        Me.LabPpidStyle = New System.Windows.Forms.Label()
        Me.ChkIsFixed = New System.Windows.Forms.CheckBox()
        Me.TxtPpidQtyI = New System.Windows.Forms.TextBox()
        Me.LabPpidQtyI = New System.Windows.Forms.Label()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.ChkIsScanCustProAndQtyI = New System.Windows.Forms.CheckBox()
        Me.ChkIsSystemPrintPpID = New System.Windows.Forms.CheckBox()
        Me.ChkIsSystemPrintPECarton = New System.Windows.Forms.CheckBox()
        Me.ChkIsSystemPrintQRCode = New System.Windows.Forms.CheckBox()
        Me.ChkIsSystemPrintCarton = New System.Windows.Forms.CheckBox()
        Me.ChkIsScanFixedCarton = New System.Windows.Forms.CheckBox()
        Me.txtPCode = New System.Windows.Forms.TextBox()
        Me.chkIsCheckPCode = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'LabLPartID
        '
        Me.LabLPartID.AutoSize = True
        Me.LabLPartID.Location = New System.Drawing.Point(42, 16)
        Me.LabLPartID.Name = "LabLPartID"
        Me.LabLPartID.Size = New System.Drawing.Size(68, 17)
        Me.LabLPartID.TabIndex = 0
        Me.LabLPartID.Text = "料件编号："
        '
        'TxtLPartID
        '
        Me.TxtLPartID.Location = New System.Drawing.Point(112, 13)
        Me.TxtLPartID.Name = "TxtLPartID"
        Me.TxtLPartID.Size = New System.Drawing.Size(154, 23)
        Me.TxtLPartID.TabIndex = 1
        '
        'LabCartonStyle
        '
        Me.LabCartonStyle.AutoSize = True
        Me.LabCartonStyle.Location = New System.Drawing.Point(374, 61)
        Me.LabCartonStyle.Name = "LabCartonStyle"
        Me.LabCartonStyle.Size = New System.Drawing.Size(128, 17)
        Me.LabCartonStyle.TabIndex = 2
        Me.LabCartonStyle.Text = "外箱条码类型和项次："
        '
        'CbbCartonStyle
        '
        Me.CbbCartonStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbbCartonStyle.FormattingEnabled = True
        Me.CbbCartonStyle.Location = New System.Drawing.Point(505, 57)
        Me.CbbCartonStyle.Name = "CbbCartonStyle"
        Me.CbbCartonStyle.Size = New System.Drawing.Size(134, 25)
        Me.CbbCartonStyle.TabIndex = 3
        '
        'TxtCartonQtyI
        '
        Me.TxtCartonQtyI.Location = New System.Drawing.Point(764, 59)
        Me.TxtCartonQtyI.Name = "TxtCartonQtyI"
        Me.TxtCartonQtyI.Size = New System.Drawing.Size(100, 23)
        Me.TxtCartonQtyI.TabIndex = 5
        '
        'LabCartonQtyI
        '
        Me.LabCartonQtyI.AutoSize = True
        Me.LabCartonQtyI.Location = New System.Drawing.Point(694, 62)
        Me.LabCartonQtyI.Name = "LabCartonQtyI"
        Me.LabCartonQtyI.Size = New System.Drawing.Size(68, 17)
        Me.LabCartonQtyI.TabIndex = 4
        Me.LabCartonQtyI.Text = "装箱数量："
        '
        'ChkIsAutoGenerateCarton
        '
        Me.ChkIsAutoGenerateCarton.AutoSize = True
        Me.ChkIsAutoGenerateCarton.Location = New System.Drawing.Point(218, 61)
        Me.ChkIsAutoGenerateCarton.Name = "ChkIsAutoGenerateCarton"
        Me.ChkIsAutoGenerateCarton.Size = New System.Drawing.Size(123, 21)
        Me.ChkIsAutoGenerateCarton.TabIndex = 6
        Me.ChkIsAutoGenerateCarton.Text = "是否自动产生外箱"
        Me.ChkIsAutoGenerateCarton.UseVisualStyleBackColor = True
        '
        'ChkIsScanQRCode
        '
        Me.ChkIsScanQRCode.AutoSize = True
        Me.ChkIsScanQRCode.Location = New System.Drawing.Point(218, 152)
        Me.ChkIsScanQRCode.Name = "ChkIsScanQRCode"
        Me.ChkIsScanQRCode.Size = New System.Drawing.Size(127, 21)
        Me.ChkIsScanQRCode.TabIndex = 7
        Me.ChkIsScanQRCode.Text = "是否扫描QRCODE"
        Me.ChkIsScanQRCode.UseVisualStyleBackColor = True
        '
        'LabQRCodeStyle
        '
        Me.LabQRCodeStyle.AutoSize = True
        Me.LabQRCodeStyle.Location = New System.Drawing.Point(380, 154)
        Me.LabQRCodeStyle.Name = "LabQRCodeStyle"
        Me.LabQRCodeStyle.Size = New System.Drawing.Size(122, 17)
        Me.LabQRCodeStyle.TabIndex = 8
        Me.LabQRCodeStyle.Text = "QR条码类型和项次："
        '
        'LabPECartonStyle
        '
        Me.LabPECartonStyle.AutoSize = True
        Me.LabPECartonStyle.Location = New System.Drawing.Point(372, 204)
        Me.LabPECartonStyle.Name = "LabPECartonStyle"
        Me.LabPECartonStyle.Size = New System.Drawing.Size(130, 17)
        Me.LabPECartonStyle.TabIndex = 11
        Me.LabPECartonStyle.Text = "PE袋条码类型和项次："
        '
        'ChkIsScanPECarton
        '
        Me.ChkIsScanPECarton.AutoSize = True
        Me.ChkIsScanPECarton.Location = New System.Drawing.Point(218, 203)
        Me.ChkIsScanPECarton.Name = "ChkIsScanPECarton"
        Me.ChkIsScanPECarton.Size = New System.Drawing.Size(125, 21)
        Me.ChkIsScanPECarton.TabIndex = 10
        Me.ChkIsScanPECarton.Text = "是否扫描PE袋条码"
        Me.ChkIsScanPECarton.UseVisualStyleBackColor = True
        '
        'CbbQRCodeStyle
        '
        Me.CbbQRCodeStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbbQRCodeStyle.FormattingEnabled = True
        Me.CbbQRCodeStyle.Location = New System.Drawing.Point(505, 150)
        Me.CbbQRCodeStyle.Name = "CbbQRCodeStyle"
        Me.CbbQRCodeStyle.Size = New System.Drawing.Size(134, 25)
        Me.CbbQRCodeStyle.TabIndex = 13
        '
        'CbbPECartonStyle
        '
        Me.CbbPECartonStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbbPECartonStyle.FormattingEnabled = True
        Me.CbbPECartonStyle.Location = New System.Drawing.Point(505, 200)
        Me.CbbPECartonStyle.Name = "CbbPECartonStyle"
        Me.CbbPECartonStyle.Size = New System.Drawing.Size(134, 25)
        Me.CbbPECartonStyle.TabIndex = 14
        '
        'TxtPECartonQtyI
        '
        Me.TxtPECartonQtyI.Location = New System.Drawing.Point(764, 201)
        Me.TxtPECartonQtyI.Name = "TxtPECartonQtyI"
        Me.TxtPECartonQtyI.Size = New System.Drawing.Size(100, 23)
        Me.TxtPECartonQtyI.TabIndex = 16
        '
        'LabPECartonQtyI
        '
        Me.LabPECartonQtyI.AutoSize = True
        Me.LabPECartonQtyI.Location = New System.Drawing.Point(668, 204)
        Me.LabPECartonQtyI.Name = "LabPECartonQtyI"
        Me.LabPECartonQtyI.Size = New System.Drawing.Size(94, 17)
        Me.LabPECartonQtyI.TabIndex = 15
        Me.LabPECartonQtyI.Text = "PE袋包装数量："
        '
        'CbbPpidStyle
        '
        Me.CbbPpidStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbbPpidStyle.FormattingEnabled = True
        Me.CbbPpidStyle.Location = New System.Drawing.Point(505, 255)
        Me.CbbPpidStyle.Name = "CbbPpidStyle"
        Me.CbbPpidStyle.Size = New System.Drawing.Size(134, 25)
        Me.CbbPpidStyle.TabIndex = 19
        '
        'LabPpidStyle
        '
        Me.LabPpidStyle.AutoSize = True
        Me.LabPpidStyle.Location = New System.Drawing.Point(374, 259)
        Me.LabPpidStyle.Name = "LabPpidStyle"
        Me.LabPpidStyle.Size = New System.Drawing.Size(128, 17)
        Me.LabPpidStyle.TabIndex = 18
        Me.LabPpidStyle.Text = "产品条码类型和项次："
        '
        'ChkIsFixed
        '
        Me.ChkIsFixed.AutoSize = True
        Me.ChkIsFixed.Location = New System.Drawing.Point(218, 259)
        Me.ChkIsFixed.Name = "ChkIsFixed"
        Me.ChkIsFixed.Size = New System.Drawing.Size(87, 21)
        Me.ChkIsFixed.TabIndex = 17
        Me.ChkIsFixed.Text = "是否固定码"
        Me.ChkIsFixed.UseVisualStyleBackColor = True
        '
        'TxtPpidQtyI
        '
        Me.TxtPpidQtyI.Location = New System.Drawing.Point(765, 257)
        Me.TxtPpidQtyI.Name = "TxtPpidQtyI"
        Me.TxtPpidQtyI.Size = New System.Drawing.Size(100, 23)
        Me.TxtPpidQtyI.TabIndex = 21
        Me.TxtPpidQtyI.Text = "1"
        '
        'LabPpidQtyI
        '
        Me.LabPpidQtyI.AutoSize = True
        Me.LabPpidQtyI.Location = New System.Drawing.Point(694, 260)
        Me.LabPpidQtyI.Name = "LabPpidQtyI"
        Me.LabPpidQtyI.Size = New System.Drawing.Size(68, 17)
        Me.LabPpidQtyI.TabIndex = 20
        Me.LabPpidQtyI.Text = "产品数量："
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(658, 321)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(75, 23)
        Me.BtnOK.TabIndex = 22
        Me.BtnOK.Text = "确认新增"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(777, 321)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 23
        Me.BtnCancel.Text = "取消"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'ChkIsScanCustProAndQtyI
        '
        Me.ChkIsScanCustProAndQtyI.AutoSize = True
        Me.ChkIsScanCustProAndQtyI.Location = New System.Drawing.Point(336, 16)
        Me.ChkIsScanCustProAndQtyI.Name = "ChkIsScanCustProAndQtyI"
        Me.ChkIsScanCustProAndQtyI.Size = New System.Drawing.Size(183, 21)
        Me.ChkIsScanCustProAndQtyI.TabIndex = 24
        Me.ChkIsScanCustProAndQtyI.Text = "是否扫描客户料号及装箱数量"
        Me.ChkIsScanCustProAndQtyI.UseVisualStyleBackColor = True
        '
        'ChkIsSystemPrintPpID
        '
        Me.ChkIsSystemPrintPpID.AutoSize = True
        Me.ChkIsSystemPrintPpID.Location = New System.Drawing.Point(45, 259)
        Me.ChkIsSystemPrintPpID.Name = "ChkIsSystemPrintPpID"
        Me.ChkIsSystemPrintPpID.Size = New System.Drawing.Size(147, 21)
        Me.ChkIsSystemPrintPpID.TabIndex = 28
        Me.ChkIsSystemPrintPpID.Text = "是否系统打印产品条码"
        Me.ChkIsSystemPrintPpID.UseVisualStyleBackColor = True
        '
        'ChkIsSystemPrintPECarton
        '
        Me.ChkIsSystemPrintPECarton.AutoSize = True
        Me.ChkIsSystemPrintPECarton.Location = New System.Drawing.Point(45, 203)
        Me.ChkIsSystemPrintPECarton.Name = "ChkIsSystemPrintPECarton"
        Me.ChkIsSystemPrintPECarton.Size = New System.Drawing.Size(149, 21)
        Me.ChkIsSystemPrintPECarton.TabIndex = 27
        Me.ChkIsSystemPrintPECarton.Text = "是否系统打印PE袋条码"
        Me.ChkIsSystemPrintPECarton.UseVisualStyleBackColor = True
        '
        'ChkIsSystemPrintQRCode
        '
        Me.ChkIsSystemPrintQRCode.AutoSize = True
        Me.ChkIsSystemPrintQRCode.Location = New System.Drawing.Point(45, 152)
        Me.ChkIsSystemPrintQRCode.Name = "ChkIsSystemPrintQRCode"
        Me.ChkIsSystemPrintQRCode.Size = New System.Drawing.Size(141, 21)
        Me.ChkIsSystemPrintQRCode.TabIndex = 26
        Me.ChkIsSystemPrintQRCode.Text = "是否系统打印QR条码"
        Me.ChkIsSystemPrintQRCode.UseVisualStyleBackColor = True
        '
        'ChkIsSystemPrintCarton
        '
        Me.ChkIsSystemPrintCarton.AutoSize = True
        Me.ChkIsSystemPrintCarton.Location = New System.Drawing.Point(45, 61)
        Me.ChkIsSystemPrintCarton.Name = "ChkIsSystemPrintCarton"
        Me.ChkIsSystemPrintCarton.Size = New System.Drawing.Size(147, 21)
        Me.ChkIsSystemPrintCarton.TabIndex = 25
        Me.ChkIsSystemPrintCarton.Text = "是否系统打印外箱条码"
        Me.ChkIsSystemPrintCarton.UseVisualStyleBackColor = True
        '
        'ChkIsScanFixedCarton
        '
        Me.ChkIsScanFixedCarton.AutoSize = True
        Me.ChkIsScanFixedCarton.Location = New System.Drawing.Point(218, 103)
        Me.ChkIsScanFixedCarton.Name = "ChkIsScanFixedCarton"
        Me.ChkIsScanFixedCarton.Size = New System.Drawing.Size(123, 21)
        Me.ChkIsScanFixedCarton.TabIndex = 29
        Me.ChkIsScanFixedCarton.Text = "是否扫描固定外箱"
        Me.ChkIsScanFixedCarton.UseVisualStyleBackColor = True
        '
        'txtPCode
        '
        Me.txtPCode.Enabled = False
        Me.txtPCode.Location = New System.Drawing.Point(147, 306)
        Me.txtPCode.Name = "txtPCode"
        Me.txtPCode.Size = New System.Drawing.Size(355, 23)
        Me.txtPCode.TabIndex = 33
        '
        'chkIsCheckPCode
        '
        Me.chkIsCheckPCode.AutoSize = True
        Me.chkIsCheckPCode.Location = New System.Drawing.Point(45, 311)
        Me.chkIsCheckPCode.Name = "chkIsCheckPCode"
        Me.chkIsCheckPCode.Size = New System.Drawing.Size(96, 21)
        Me.chkIsCheckPCode.TabIndex = 32
        Me.chkIsCheckPCode.Text = "CheckCode:"
        Me.chkIsCheckPCode.UseVisualStyleBackColor = True
        '
        'FrmPackingPartSetOper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 373)
        Me.Controls.Add(Me.txtPCode)
        Me.Controls.Add(Me.chkIsCheckPCode)
        Me.Controls.Add(Me.ChkIsScanFixedCarton)
        Me.Controls.Add(Me.ChkIsSystemPrintPpID)
        Me.Controls.Add(Me.ChkIsSystemPrintPECarton)
        Me.Controls.Add(Me.ChkIsSystemPrintQRCode)
        Me.Controls.Add(Me.ChkIsSystemPrintCarton)
        Me.Controls.Add(Me.ChkIsScanCustProAndQtyI)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.TxtPpidQtyI)
        Me.Controls.Add(Me.LabPpidQtyI)
        Me.Controls.Add(Me.CbbPpidStyle)
        Me.Controls.Add(Me.LabPpidStyle)
        Me.Controls.Add(Me.ChkIsFixed)
        Me.Controls.Add(Me.TxtPECartonQtyI)
        Me.Controls.Add(Me.LabPECartonQtyI)
        Me.Controls.Add(Me.CbbPECartonStyle)
        Me.Controls.Add(Me.CbbQRCodeStyle)
        Me.Controls.Add(Me.LabPECartonStyle)
        Me.Controls.Add(Me.ChkIsScanPECarton)
        Me.Controls.Add(Me.LabQRCodeStyle)
        Me.Controls.Add(Me.ChkIsScanQRCode)
        Me.Controls.Add(Me.ChkIsAutoGenerateCarton)
        Me.Controls.Add(Me.TxtCartonQtyI)
        Me.Controls.Add(Me.LabCartonQtyI)
        Me.Controls.Add(Me.CbbCartonStyle)
        Me.Controls.Add(Me.LabCartonStyle)
        Me.Controls.Add(Me.TxtLPartID)
        Me.Controls.Add(Me.LabLPartID)
        Me.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPackingPartSetOper"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "新增料件扫描参数"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabLPartID As System.Windows.Forms.Label
    Friend WithEvents TxtLPartID As System.Windows.Forms.TextBox
    Friend WithEvents LabCartonStyle As System.Windows.Forms.Label
    Friend WithEvents CbbCartonStyle As System.Windows.Forms.ComboBox
    Friend WithEvents TxtCartonQtyI As System.Windows.Forms.TextBox
    Friend WithEvents LabCartonQtyI As System.Windows.Forms.Label
    Friend WithEvents ChkIsAutoGenerateCarton As System.Windows.Forms.CheckBox
    Friend WithEvents ChkIsScanQRCode As System.Windows.Forms.CheckBox
    Friend WithEvents LabQRCodeStyle As System.Windows.Forms.Label
    Friend WithEvents LabPECartonStyle As System.Windows.Forms.Label
    Friend WithEvents ChkIsScanPECarton As System.Windows.Forms.CheckBox
    Friend WithEvents CbbQRCodeStyle As System.Windows.Forms.ComboBox
    Friend WithEvents CbbPECartonStyle As System.Windows.Forms.ComboBox
    Friend WithEvents TxtPECartonQtyI As System.Windows.Forms.TextBox
    Friend WithEvents LabPECartonQtyI As System.Windows.Forms.Label
    Friend WithEvents CbbPpidStyle As System.Windows.Forms.ComboBox
    Friend WithEvents LabPpidStyle As System.Windows.Forms.Label
    Friend WithEvents ChkIsFixed As System.Windows.Forms.CheckBox
    Friend WithEvents TxtPpidQtyI As System.Windows.Forms.TextBox
    Friend WithEvents LabPpidQtyI As System.Windows.Forms.Label
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents ChkIsScanCustProAndQtyI As System.Windows.Forms.CheckBox
    Friend WithEvents ChkIsSystemPrintPpID As System.Windows.Forms.CheckBox
    Friend WithEvents ChkIsSystemPrintPECarton As System.Windows.Forms.CheckBox
    Friend WithEvents ChkIsSystemPrintQRCode As System.Windows.Forms.CheckBox
    Friend WithEvents ChkIsSystemPrintCarton As System.Windows.Forms.CheckBox
    Friend WithEvents ChkIsScanFixedCarton As System.Windows.Forms.CheckBox
    Friend WithEvents txtPCode As System.Windows.Forms.TextBox
    Friend WithEvents chkIsCheckPCode As System.Windows.Forms.CheckBox
End Class
