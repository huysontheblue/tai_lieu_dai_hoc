<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBOFToolListSearch
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
        Me.txtPartID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCustName = New System.Windows.Forms.TextBox()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtShape = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.txtPIEName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFEName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDocID = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.BtnConfirm = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.cmbFESchedule = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "料号:"
        '
        'txtPartID
        '
        Me.txtPartID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartID.Location = New System.Drawing.Point(54, 15)
        Me.txtPartID.Name = "txtPartID"
        Me.txtPartID.Size = New System.Drawing.Size(164, 21)
        Me.txtPartID.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(248, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "客户:"
        '
        'txtCustName
        '
        Me.txtCustName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustName.Location = New System.Drawing.Point(282, 15)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.Size = New System.Drawing.Size(164, 21)
        Me.txtCustName.TabIndex = 3
        '
        'txtProductName
        '
        Me.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductName.Location = New System.Drawing.Point(54, 48)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.Size = New System.Drawing.Size(392, 21)
        Me.txtProductName.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "品名:"
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Location = New System.Drawing.Point(54, 88)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(392, 21)
        Me.txtDescription.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "规格:"
        '
        'txtShape
        '
        Me.txtShape.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShape.Location = New System.Drawing.Point(54, 131)
        Me.txtShape.Name = "txtShape"
        Me.txtShape.Size = New System.Drawing.Size(164, 21)
        Me.txtShape.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "形态:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 12)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "状态:"
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(54, 165)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(164, 20)
        Me.cmbStatus.TabIndex = 11
        '
        'txtPIEName
        '
        Me.txtPIEName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPIEName.Location = New System.Drawing.Point(282, 164)
        Me.txtPIEName.Name = "txtPIEName"
        Me.txtPIEName.Size = New System.Drawing.Size(164, 21)
        Me.txtPIEName.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(254, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 12)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "PIE:"
        '
        'txtFEName
        '
        Me.txtFEName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFEName.Location = New System.Drawing.Point(54, 201)
        Me.txtFEName.Name = "txtFEName"
        Me.txtFEName.Size = New System.Drawing.Size(164, 21)
        Me.txtFEName.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(28, 204)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 12)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "F E:"
        '
        'txtDocID
        '
        Me.txtDocID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocID.Location = New System.Drawing.Point(282, 201)
        Me.txtDocID.Name = "txtDocID"
        Me.txtDocID.Size = New System.Drawing.Size(164, 21)
        Me.txtDocID.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(224, 203)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 12)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "文件编号:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(22, 244)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 12)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "时间:"
        '
        'dtpStart
        '
        Me.dtpStart.CustomFormat = " "
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStart.Location = New System.Drawing.Point(54, 239)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(164, 21)
        Me.dtpStart.TabIndex = 19
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(241, 244)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(17, 12)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "～"
        '
        'dtpEnd
        '
        Me.dtpEnd.CustomFormat = " "
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEnd.Location = New System.Drawing.Point(282, 238)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(164, 21)
        Me.dtpEnd.TabIndex = 21
        '
        'BtnConfirm
        '
        Me.BtnConfirm.Location = New System.Drawing.Point(182, 295)
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Size = New System.Drawing.Size(94, 57)
        Me.BtnConfirm.TabIndex = 22
        Me.BtnConfirm.Text = "查询"
        Me.BtnConfirm.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(346, 295)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(94, 57)
        Me.BtnCancel.TabIndex = 23
        Me.BtnCancel.Text = "取消"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'cmbFESchedule
        '
        Me.cmbFESchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFESchedule.FormattingEnabled = True
        Me.cmbFESchedule.Items.AddRange(New Object() {"请选择", "已完成", "进行中"})
        Me.cmbFESchedule.Location = New System.Drawing.Point(282, 132)
        Me.cmbFESchedule.Name = "cmbFESchedule"
        Me.cmbFESchedule.Size = New System.Drawing.Size(164, 20)
        Me.cmbFESchedule.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(224, 135)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 12)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "治具进度:"
        '
        'FrmBOFToolListSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 368)
        Me.Controls.Add(Me.cmbFESchedule)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnConfirm)
        Me.Controls.Add(Me.dtpEnd)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dtpStart)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtDocID)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtFEName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPIEName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtShape)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtProductName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCustName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPartID)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBOFToolListSearch"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BOF清单查询"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPartID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCustName As System.Windows.Forms.TextBox
    Friend WithEvents txtProductName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtShape As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtPIEName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFEName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDocID As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnConfirm As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents cmbFESchedule As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
