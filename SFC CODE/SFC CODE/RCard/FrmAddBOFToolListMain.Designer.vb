<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAddBOFToolListMain
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnSubmit = New System.Windows.Forms.Button()
        Me.txtCustName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.txtShape = New System.Windows.Forms.TextBox()
        Me.txtPIEName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFEName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDocID = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFETargetDate = New System.Windows.Forms.DateTimePicker()
        Me.BtnSelectFE = New System.Windows.Forms.Button()
        Me.rdoBtnN = New System.Windows.Forms.RadioButton()
        Me.rdoBtnY = New System.Windows.Forms.RadioButton()
        Me.txtPartID = New System.Windows.Forms.TextBox()
        Me.btnFile = New System.Windows.Forms.Button()
        Me.txtFIlePath = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.OpenFileDialog3 = New System.Windows.Forms.OpenFileDialog()
        Me.txtPDName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtEquName = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnSelectEquDuty = New System.Windows.Forms.Button()
        Me.btnSelectPDDuty = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "料号:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(188, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "客户:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(416, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "版本:"
        '
        'txtVersion
        '
        Me.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVersion.Location = New System.Drawing.Point(449, 3)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(56, 21)
        Me.txtVersion.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 164)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "形态:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 215)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "PIE:"
        '
        'BtnSubmit
        '
        Me.BtnSubmit.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.BtnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnSubmit.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BtnSubmit.Location = New System.Drawing.Point(504, 346)
        Me.BtnSubmit.Name = "BtnSubmit"
        Me.BtnSubmit.Size = New System.Drawing.Size(86, 32)
        Me.BtnSubmit.TabIndex = 12
        Me.BtnSubmit.Text = "提交"
        Me.BtnSubmit.UseVisualStyleBackColor = False
        '
        'txtCustName
        '
        Me.txtCustName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustName.Location = New System.Drawing.Point(219, 3)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.Size = New System.Drawing.Size(191, 21)
        Me.txtCustName.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 12)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "品名:"
        '
        'txtProductName
        '
        Me.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductName.Location = New System.Drawing.Point(35, 29)
        Me.txtProductName.Multiline = True
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.Size = New System.Drawing.Size(556, 56)
        Me.txtProductName.TabIndex = 3
        '
        'txtShape
        '
        Me.txtShape.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShape.Location = New System.Drawing.Point(35, 149)
        Me.txtShape.Multiline = True
        Me.txtShape.Name = "txtShape"
        Me.txtShape.Size = New System.Drawing.Size(556, 53)
        Me.txtShape.TabIndex = 5
        '
        'txtPIEName
        '
        Me.txtPIEName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPIEName.Location = New System.Drawing.Point(36, 210)
        Me.txtPIEName.Name = "txtPIEName"
        Me.txtPIEName.ReadOnly = True
        Me.txtPIEName.Size = New System.Drawing.Size(78, 21)
        Me.txtPIEName.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(288, 218)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 12)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "FE:"
        '
        'txtFEName
        '
        Me.txtFEName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFEName.Location = New System.Drawing.Point(329, 211)
        Me.txtFEName.Name = "txtFEName"
        Me.txtFEName.ReadOnly = True
        Me.txtFEName.Size = New System.Drawing.Size(158, 21)
        Me.txtFEName.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(521, 2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 24)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "输入料号再按回车键带出料号相关信息"
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Location = New System.Drawing.Point(36, 91)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(555, 53)
        Me.txtDescription.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 106)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 12)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "规格:"
        '
        'txtDocID
        '
        Me.txtDocID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocID.Location = New System.Drawing.Point(69, 279)
        Me.txtDocID.Name = "txtDocID"
        Me.txtDocID.ReadOnly = True
        Me.txtDocID.Size = New System.Drawing.Size(154, 21)
        Me.txtDocID.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 283)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 12)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "文件编号:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(327, 283)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 12)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "FE完成日期:"
        '
        'dtpFETargetDate
        '
        Me.dtpFETargetDate.CustomFormat = " "
        Me.dtpFETargetDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFETargetDate.Location = New System.Drawing.Point(404, 279)
        Me.dtpFETargetDate.Name = "dtpFETargetDate"
        Me.dtpFETargetDate.Size = New System.Drawing.Size(186, 21)
        Me.dtpFETargetDate.TabIndex = 27
        '
        'BtnSelectFE
        '
        Me.BtnSelectFE.Location = New System.Drawing.Point(516, 207)
        Me.BtnSelectFE.Name = "BtnSelectFE"
        Me.BtnSelectFE.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectFE.TabIndex = 28
        Me.BtnSelectFE.Text = "选择FE"
        Me.BtnSelectFE.UseVisualStyleBackColor = True
        '
        'rdoBtnN
        '
        Me.rdoBtnN.AutoSize = True
        Me.rdoBtnN.Checked = True
        Me.rdoBtnN.Location = New System.Drawing.Point(69, 361)
        Me.rdoBtnN.Name = "rdoBtnN"
        Me.rdoBtnN.Size = New System.Drawing.Size(59, 16)
        Me.rdoBtnN.TabIndex = 156
        Me.rdoBtnN.TabStop = True
        Me.rdoBtnN.Text = "一般件"
        Me.rdoBtnN.UseVisualStyleBackColor = True
        '
        'rdoBtnY
        '
        Me.rdoBtnY.AutoSize = True
        Me.rdoBtnY.Location = New System.Drawing.Point(14, 361)
        Me.rdoBtnY.Name = "rdoBtnY"
        Me.rdoBtnY.Size = New System.Drawing.Size(59, 16)
        Me.rdoBtnY.TabIndex = 155
        Me.rdoBtnY.Text = "加急件"
        Me.rdoBtnY.UseVisualStyleBackColor = True
        '
        'txtPartID
        '
        Me.txtPartID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartID.Location = New System.Drawing.Point(35, 2)
        Me.txtPartID.Name = "txtPartID"
        Me.txtPartID.Size = New System.Drawing.Size(147, 21)
        Me.txtPartID.TabIndex = 0
        '
        'btnFile
        '
        Me.btnFile.Location = New System.Drawing.Point(323, 323)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(75, 23)
        Me.btnFile.TabIndex = 309
        Me.btnFile.Text = "浏览"
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'txtFIlePath
        '
        Me.txtFIlePath.Location = New System.Drawing.Point(106, 323)
        Me.txtFIlePath.Name = "txtFIlePath"
        Me.txtFIlePath.Size = New System.Drawing.Size(207, 21)
        Me.txtFIlePath.TabIndex = 308
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 327)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 12)
        Me.Label12.TabIndex = 307
        Me.Label12.Text = "开治具相关文件："
        '
        'OpenFileDialog3
        '
        Me.OpenFileDialog3.FileName = "OpenFileDialog3"
        '
        'txtPDName
        '
        Me.txtPDName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPDName.Location = New System.Drawing.Point(329, 238)
        Me.txtPDName.Name = "txtPDName"
        Me.txtPDName.ReadOnly = True
        Me.txtPDName.Size = New System.Drawing.Size(158, 21)
        Me.txtPDName.TabIndex = 310
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(278, 242)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 12)
        Me.Label13.TabIndex = 313
        Me.Label13.Text = "制造:"
        '
        'txtEquName
        '
        Me.txtEquName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEquName.Location = New System.Drawing.Point(36, 239)
        Me.txtEquName.Name = "txtEquName"
        Me.txtEquName.ReadOnly = True
        Me.txtEquName.Size = New System.Drawing.Size(78, 21)
        Me.txtEquName.TabIndex = 312
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 244)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 12)
        Me.Label14.TabIndex = 311
        Me.Label14.Text = "生技:"
        '
        'btnSelectEquDuty
        '
        Me.btnSelectEquDuty.Location = New System.Drawing.Point(120, 238)
        Me.btnSelectEquDuty.Name = "btnSelectEquDuty"
        Me.btnSelectEquDuty.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectEquDuty.TabIndex = 314
        Me.btnSelectEquDuty.Text = "选择..."
        Me.btnSelectEquDuty.UseVisualStyleBackColor = True
        '
        'btnSelectPDDuty
        '
        Me.btnSelectPDDuty.Location = New System.Drawing.Point(515, 237)
        Me.btnSelectPDDuty.Name = "btnSelectPDDuty"
        Me.btnSelectPDDuty.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectPDDuty.TabIndex = 315
        Me.btnSelectPDDuty.Text = "选择..."
        Me.btnSelectPDDuty.UseVisualStyleBackColor = True
        '
        'FrmAddBOFToolListMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 383)
        Me.Controls.Add(Me.btnSelectPDDuty)
        Me.Controls.Add(Me.btnSelectEquDuty)
        Me.Controls.Add(Me.txtPDName)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtEquName)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btnFile)
        Me.Controls.Add(Me.txtFIlePath)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.rdoBtnN)
        Me.Controls.Add(Me.rdoBtnY)
        Me.Controls.Add(Me.BtnSelectFE)
        Me.Controls.Add(Me.dtpFETargetDate)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtDocID)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtFEName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPIEName)
        Me.Controls.Add(Me.txtShape)
        Me.Controls.Add(Me.txtProductName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCustName)
        Me.Controls.Add(Me.BtnSubmit)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtVersion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPartID)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddBOFToolListMain"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "编辑BOF清单主档"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnSubmit As System.Windows.Forms.Button
    Friend WithEvents txtCustName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtProductName As System.Windows.Forms.TextBox
    Friend WithEvents txtShape As System.Windows.Forms.TextBox
    Friend WithEvents txtPIEName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFEName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDocID As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpFETargetDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnSelectFE As System.Windows.Forms.Button
    Friend WithEvents rdoBtnN As System.Windows.Forms.RadioButton
    Friend WithEvents rdoBtnY As System.Windows.Forms.RadioButton
    Friend WithEvents txtPartID As System.Windows.Forms.TextBox
    Friend WithEvents btnFile As System.Windows.Forms.Button
    Friend WithEvents txtFIlePath As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog3 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtPDName As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtEquName As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnSelectEquDuty As System.Windows.Forms.Button
    Friend WithEvents btnSelectPDDuty As System.Windows.Forms.Button
End Class
