<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCutCardBodyEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCutCardBodyEdit))
        Me.iiStationSQ = New DevComponents.Editors.IntegerInput()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPartNumber = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtProcessStandard = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEquipment = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboStation = New System.Windows.Forms.ComboBox()
        Me.BtnSelectSta = New System.Windows.Forms.Button()
        Me.btnGetProcessStandard = New System.Windows.Forms.Button()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.iiWoringHours = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSopFilePath = New System.Windows.Forms.TextBox()
        Me.txtStationid = New TextBoxUL.TextBoxUL()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtLeftProcessStandard = New System.Windows.Forms.TextBox()
        Me.txtRightProcessStandard = New System.Windows.Forms.TextBox()
        Me.txtLCLVale = New System.Windows.Forms.TextBox()
        CType(Me.iiStationSQ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'iiStationSQ
        '
        '
        '
        '
        Me.iiStationSQ.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iiStationSQ.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iiStationSQ.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iiStationSQ.Location = New System.Drawing.Point(205, 47)
        Me.iiStationSQ.Name = "iiStationSQ"
        Me.iiStationSQ.ShowUpDown = True
        Me.iiStationSQ.Size = New System.Drawing.Size(67, 21)
        Me.iiStationSQ.TabIndex = 5
        Me.iiStationSQ.Value = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(140, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 12)
        Me.Label11.TabIndex = 82
        Me.Label11.Text = "工站序号:"
        '
        'txtPartNumber
        '
        Me.txtPartNumber.Enabled = False
        Me.txtPartNumber.ForeColor = System.Drawing.Color.Blue
        Me.txtPartNumber.Location = New System.Drawing.Point(47, 18)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Size = New System.Drawing.Size(225, 21)
        Me.txtPartNumber.TabIndex = 1
        Me.txtPartNumber.Tag = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "料号:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(659, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "工艺标准:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(689, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 12)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "SOP:"
        '
        'txtProcessStandard
        '
        Me.txtProcessStandard.Location = New System.Drawing.Point(723, 15)
        Me.txtProcessStandard.Name = "txtProcessStandard"
        Me.txtProcessStandard.Size = New System.Drawing.Size(243, 21)
        Me.txtProcessStandard.TabIndex = 3
        Me.txtProcessStandard.Tag = "工艺标准"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(294, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "设备/治具:"
        '
        'txtEquipment
        '
        Me.txtEquipment.Enabled = False
        Me.txtEquipment.Location = New System.Drawing.Point(365, 46)
        Me.txtEquipment.Name = "txtEquipment"
        Me.txtEquipment.Size = New System.Drawing.Size(272, 21)
        Me.txtEquipment.TabIndex = 6
        Me.txtEquipment.Tag = "设备/治具"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 12)
        Me.Label6.TabIndex = 72
        Me.Label6.Text = "工时:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(324, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 12)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "工站:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboStation)
        Me.GroupBox1.Controls.Add(Me.BtnSelectSta)
        Me.GroupBox1.Controls.Add(Me.btnGetProcessStandard)
        Me.GroupBox1.Controls.Add(Me.txtRemark)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.iiWoringHours)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.iiStationSQ)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtEquipment)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtProcessStandard)
        Me.GroupBox1.Controls.Add(Me.txtPartNumber)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtSopFilePath)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1090, 100)
        Me.GroupBox1.TabIndex = 85
        Me.GroupBox1.TabStop = False
        '
        'cboStation
        '
        Me.cboStation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStation.FormattingEnabled = True
        Me.cboStation.Location = New System.Drawing.Point(365, 17)
        Me.cboStation.Name = "cboStation"
        Me.cboStation.Size = New System.Drawing.Size(236, 20)
        Me.cboStation.TabIndex = 96
        '
        'BtnSelectSta
        '
        Me.BtnSelectSta.BackgroundImage = CType(resources.GetObject("BtnSelectSta.BackgroundImage"), System.Drawing.Image)
        Me.BtnSelectSta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnSelectSta.Location = New System.Drawing.Point(607, 18)
        Me.BtnSelectSta.Name = "BtnSelectSta"
        Me.BtnSelectSta.Size = New System.Drawing.Size(30, 23)
        Me.BtnSelectSta.TabIndex = 94
        Me.BtnSelectSta.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnSelectSta.UseVisualStyleBackColor = True
        '
        'btnGetProcessStandard
        '
        Me.btnGetProcessStandard.Location = New System.Drawing.Point(981, 15)
        Me.btnGetProcessStandard.Name = "btnGetProcessStandard"
        Me.btnGetProcessStandard.Size = New System.Drawing.Size(94, 23)
        Me.btnGetProcessStandard.TabIndex = 92
        Me.btnGetProcessStandard.Text = "获取工艺标准"
        Me.btnGetProcessStandard.UseVisualStyleBackColor = True
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(47, 75)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(373, 21)
        Me.txtRemark.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 12)
        Me.Label12.TabIndex = 91
        Me.Label12.Text = "备注:"
        '
        'iiWoringHours
        '
        Me.iiWoringHours.Location = New System.Drawing.Point(47, 49)
        Me.iiWoringHours.Name = "iiWoringHours"
        Me.iiWoringHours.Size = New System.Drawing.Size(87, 21)
        Me.iiWoringHours.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(646, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 12)
        Me.Label10.TabIndex = 89
        Me.Label10.Text = "*"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(278, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 12)
        Me.Label9.TabIndex = 88
        Me.Label9.Text = "*"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(123, 61)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 12)
        Me.Label8.TabIndex = 87
        Me.Label8.Text = "*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(278, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 12)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "*"
        '
        'txtSopFilePath
        '
        Me.txtSopFilePath.ForeColor = System.Drawing.Color.Blue
        Me.txtSopFilePath.Location = New System.Drawing.Point(723, 46)
        Me.txtSopFilePath.Name = "txtSopFilePath"
        Me.txtSopFilePath.ReadOnly = True
        Me.txtSopFilePath.Size = New System.Drawing.Size(243, 21)
        Me.txtSopFilePath.TabIndex = 7
        Me.txtSopFilePath.Tag = "Sop"
        '
        'txtStationid
        '
        Me.txtStationid.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtStationid.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList
        Me.txtStationid.BackColor = System.Drawing.Color.White
        Me.txtStationid.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.txtStationid.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtStationid.ForeColor = System.Drawing.Color.Black
        Me.txtStationid.HotColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.txtStationid.Location = New System.Drawing.Point(125, 111)
        Me.txtStationid.Name = "txtStationid"
        Me.txtStationid.Size = New System.Drawing.Size(59, 22)
        Me.txtStationid.TabIndex = 93
        Me.txtStationid.TabStop = False
        Me.txtStationid.Visible = False
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(25, 111)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(47, 12)
        Me.lblMsg.TabIndex = 86
        Me.lblMsg.Text = "lblMsg"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(852, 106)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "取 消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(759, 106)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 9
        Me.btnOK.Text = "确 定(&O)"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "(*.jpg,*.gif,*.bmp,*.png,*.jpeg)|*.JPG;*.GIF;*.BMP;*.PNG;*.JPEG"
        '
        'txtLeftProcessStandard
        '
        Me.txtLeftProcessStandard.Location = New System.Drawing.Point(228, 111)
        Me.txtLeftProcessStandard.Name = "txtLeftProcessStandard"
        Me.txtLeftProcessStandard.Size = New System.Drawing.Size(26, 21)
        Me.txtLeftProcessStandard.TabIndex = 94
        Me.txtLeftProcessStandard.Visible = False
        '
        'txtRightProcessStandard
        '
        Me.txtRightProcessStandard.Location = New System.Drawing.Point(271, 111)
        Me.txtRightProcessStandard.Name = "txtRightProcessStandard"
        Me.txtRightProcessStandard.Size = New System.Drawing.Size(18, 21)
        Me.txtRightProcessStandard.TabIndex = 95
        Me.txtRightProcessStandard.Visible = False
        '
        'txtLCLVale
        '
        Me.txtLCLVale.Location = New System.Drawing.Point(306, 112)
        Me.txtLCLVale.Name = "txtLCLVale"
        Me.txtLCLVale.Size = New System.Drawing.Size(26, 21)
        Me.txtLCLVale.TabIndex = 96
        Me.txtLCLVale.Visible = False
        '
        'FrmCutCardBodyEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1090, 141)
        Me.Controls.Add(Me.txtLCLVale)
        Me.Controls.Add(Me.txtRightProcessStandard)
        Me.Controls.Add(Me.txtLeftProcessStandard)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.txtStationid)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmCutCardBodyEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "编辑裁线工艺流程"
        CType(Me.iiStationSQ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents iiStationSQ As DevComponents.Editors.IntegerInput
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtProcessStandard As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEquipment As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents iiWoringHours As System.Windows.Forms.TextBox
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnGetProcessStandard As System.Windows.Forms.Button
    Friend WithEvents txtSopFilePath As System.Windows.Forms.TextBox
    Private WithEvents BtnSelectSta As System.Windows.Forms.Button
    Private WithEvents txtStationid As TextBoxUL.TextBoxUL
    Friend WithEvents cboStation As System.Windows.Forms.ComboBox
    Friend WithEvents txtLeftProcessStandard As System.Windows.Forms.TextBox
    Friend WithEvents txtRightProcessStandard As System.Windows.Forms.TextBox
    Friend WithEvents txtLCLVale As System.Windows.Forms.TextBox
End Class
