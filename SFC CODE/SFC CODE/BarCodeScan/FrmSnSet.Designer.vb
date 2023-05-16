<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSnSet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSnSet))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BnConFrm = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblLine = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabCust = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.LabSnLen = New System.Windows.Forms.Label()
        Me.LabMoqty = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.LabPartid = New System.Windows.Forms.Label()
        Me.LabMtype = New System.Windows.Forms.Label()
        Me.LabDept = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label2)
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
        Me.GroupBox2.Location = New System.Drawing.Point(0, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(449, 103)
        Me.GroupBox2.TabIndex = 94
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "扫描信息设置"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(243, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "线别编号："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CobLine
        '
        Me.CobLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobLine.FormattingEnabled = True
        Me.CobLine.Location = New System.Drawing.Point(320, 68)
        Me.CobLine.Name = "CobLine"
        Me.CobLine.Size = New System.Drawing.Size(111, 20)
        Me.CobLine.TabIndex = 73
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 72
        Me.Label11.Text = "日期设置："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DtpSet
        '
        Me.DtpSet.Location = New System.Drawing.Point(89, 68)
        Me.DtpSet.Name = "DtpSet"
        Me.DtpSet.Size = New System.Drawing.Size(118, 21)
        Me.DtpSet.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(14, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 12)
        Me.Label15.TabIndex = 68
        Me.Label15.Text = "客户名称："
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(13, 46)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 12)
        Me.Label23.TabIndex = 48
        Me.Label23.Text = "工单编号："
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CboMoid
        '
        Me.CboMoid.FormattingEnabled = True
        Me.CboMoid.Location = New System.Drawing.Point(89, 42)
        Me.CboMoid.Name = "CboMoid"
        Me.CboMoid.Size = New System.Drawing.Size(118, 20)
        Me.CboMoid.TabIndex = 2
        '
        'CboSupport
        '
        Me.CboSupport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboSupport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboSupport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSupport.FormattingEnabled = True
        Me.CboSupport.Location = New System.Drawing.Point(89, 16)
        Me.CboSupport.Name = "CboSupport"
        Me.CboSupport.Size = New System.Drawing.Size(118, 20)
        Me.CboSupport.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(243, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "开始时间："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DtpDate
        '
        Me.DtpDate.Location = New System.Drawing.Point(320, 13)
        Me.DtpDate.Name = "DtpDate"
        Me.DtpDate.Size = New System.Drawing.Size(111, 21)
        Me.DtpDate.TabIndex = 6
        '
        'DtpTime
        '
        Me.DtpTime.CustomFormat = "HH:mm:ss"
        Me.DtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpTime.Location = New System.Drawing.Point(320, 41)
        Me.DtpTime.Name = "DtpTime"
        Me.DtpTime.ShowUpDown = True
        Me.DtpTime.Size = New System.Drawing.Size(111, 21)
        Me.DtpTime.TabIndex = 7
        Me.DtpTime.Value = New Date(2007, 1, 12, 2, 12, 0, 0)
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(368, 54)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "退  出(&E)"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BnConFrm
        '
        Me.BnConFrm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BnConFrm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BnConFrm.Location = New System.Drawing.Point(368, 22)
        Me.BnConFrm.Name = "BnConFrm"
        Me.BnConFrm.Size = New System.Drawing.Size(63, 23)
        Me.BnConFrm.TabIndex = 8
        Me.BnConFrm.Text = "确  认(&O)"
        Me.BnConFrm.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BnConFrm.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.LblLine)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.LabCust)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.BnConFrm)
        Me.GroupBox1.Controls.Add(Me.LabSnLen)
        Me.GroupBox1.Controls.Add(Me.LabMoqty)
        Me.GroupBox1.Controls.Add(Me.Label34)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.LabPartid)
        Me.GroupBox1.Controls.Add(Me.LabMtype)
        Me.GroupBox1.Controls.Add(Me.LabDept)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 110)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(449, 119)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "工单信息"
        '
        'LblLine
        '
        Me.LblLine.AutoSize = True
        Me.LblLine.ForeColor = System.Drawing.Color.Maroon
        Me.LblLine.Location = New System.Drawing.Point(78, 99)
        Me.LblLine.Name = "LblLine"
        Me.LblLine.Size = New System.Drawing.Size(11, 12)
        Me.LblLine.TabIndex = 2
        Me.LblLine.Text = "#"
        Me.LblLine.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "工单线别："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabCust
        '
        Me.LabCust.AutoSize = True
        Me.LabCust.ForeColor = System.Drawing.Color.Blue
        Me.LabCust.Location = New System.Drawing.Point(258, 23)
        Me.LabCust.Name = "LabCust"
        Me.LabCust.Size = New System.Drawing.Size(0, 12)
        Me.LabCust.TabIndex = 97
        Me.LabCust.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(187, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 12)
        Me.Label18.TabIndex = 92
        Me.Label18.Text = "客户料号："
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabSnLen
        '
        Me.LabSnLen.AutoSize = True
        Me.LabSnLen.ForeColor = System.Drawing.Color.Blue
        Me.LabSnLen.Location = New System.Drawing.Point(258, 50)
        Me.LabSnLen.Name = "LabSnLen"
        Me.LabSnLen.Size = New System.Drawing.Size(0, 12)
        Me.LabSnLen.TabIndex = 95
        Me.LabSnLen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabMoqty
        '
        Me.LabMoqty.AutoSize = True
        Me.LabMoqty.ForeColor = System.Drawing.Color.Blue
        Me.LabMoqty.Location = New System.Drawing.Point(258, 75)
        Me.LabMoqty.Name = "LabMoqty"
        Me.LabMoqty.Size = New System.Drawing.Size(0, 12)
        Me.LabMoqty.TabIndex = 93
        Me.LabMoqty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(187, 50)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(65, 12)
        Me.Label34.TabIndex = 94
        Me.Label34.Text = "条码长度："
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(17, 22)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(65, 12)
        Me.Label29.TabIndex = 86
        Me.Label29.Text = "部门名称："
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabPartid
        '
        Me.LabPartid.AutoSize = True
        Me.LabPartid.ForeColor = System.Drawing.Color.Blue
        Me.LabPartid.Location = New System.Drawing.Point(88, 75)
        Me.LabPartid.Name = "LabPartid"
        Me.LabPartid.Size = New System.Drawing.Size(0, 12)
        Me.LabPartid.TabIndex = 91
        Me.LabPartid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabMtype
        '
        Me.LabMtype.AutoSize = True
        Me.LabMtype.ForeColor = System.Drawing.Color.Blue
        Me.LabMtype.Location = New System.Drawing.Point(88, 49)
        Me.LabMtype.Name = "LabMtype"
        Me.LabMtype.Size = New System.Drawing.Size(0, 12)
        Me.LabMtype.TabIndex = 89
        Me.LabMtype.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabDept
        '
        Me.LabDept.AutoSize = True
        Me.LabDept.ForeColor = System.Drawing.Color.Blue
        Me.LabDept.Location = New System.Drawing.Point(88, 23)
        Me.LabDept.Name = "LabDept"
        Me.LabDept.Size = New System.Drawing.Size(0, 12)
        Me.LabDept.TabIndex = 87
        Me.LabDept.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(17, 47)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 12)
        Me.Label20.TabIndex = 88
        Me.Label20.Text = "工单类型："
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(187, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "工单数量："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(17, 74)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(65, 12)
        Me.Label31.TabIndex = 90
        Me.Label31.Text = "料件编号："
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmSnSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.Button1
        Me.ClientSize = New System.Drawing.Size(453, 234)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmSnSet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "条码打印检测设置"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DtpSet As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents CboMoid As System.Windows.Forms.ComboBox
    Friend WithEvents CboSupport As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LabCust As System.Windows.Forms.Label
    Friend WithEvents BnConFrm As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents LabSnLen As System.Windows.Forms.Label
    Friend WithEvents LabMoqty As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents LabPartid As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents LabMtype As System.Windows.Forms.Label
    Friend WithEvents LabDept As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents LblLine As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CobLine As System.Windows.Forms.ComboBox
End Class
