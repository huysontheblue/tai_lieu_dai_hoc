<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStandardJobSchedulingAddDetails
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
        Me.cmbStationType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSWorkingHours = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUndulationTime = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtOutPut = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEquiment = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBalancePerson = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBalanceHours = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtBalanceQty = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtOrderBy = New System.Windows.Forms.TextBox()
        Me.txtStationName = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "工站类型:"
        '
        'cmbStationType
        '
        Me.cmbStationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStationType.FormattingEnabled = True
        Me.cmbStationType.Items.AddRange(New Object() {"流程工站", "线外工站"})
        Me.cmbStationType.Location = New System.Drawing.Point(103, 10)
        Me.cmbStationType.Name = "cmbStationType"
        Me.cmbStationType.Size = New System.Drawing.Size(96, 20)
        Me.cmbStationType.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(382, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "工站名称:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "标准工时(S):"
        '
        'txtSWorkingHours
        '
        Me.txtSWorkingHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSWorkingHours.Location = New System.Drawing.Point(103, 39)
        Me.txtSWorkingHours.Name = "txtSWorkingHours"
        Me.txtSWorkingHours.Size = New System.Drawing.Size(96, 21)
        Me.txtSWorkingHours.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(216, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "波动时间(S):"
        '
        'txtUndulationTime
        '
        Me.txtUndulationTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUndulationTime.Location = New System.Drawing.Point(295, 37)
        Me.txtUndulationTime.Name = "txtUndulationTime"
        Me.txtUndulationTime.Size = New System.Drawing.Size(81, 21)
        Me.txtUndulationTime.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "产量(Pcs/H):"
        '
        'txtOutPut
        '
        Me.txtOutPut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOutPut.Location = New System.Drawing.Point(103, 76)
        Me.txtOutPut.Name = "txtOutPut"
        Me.txtOutPut.ReadOnly = True
        Me.txtOutPut.Size = New System.Drawing.Size(96, 21)
        Me.txtOutPut.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(376, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "设备/治具:"
        '
        'txtEquiment
        '
        Me.txtEquiment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEquiment.Location = New System.Drawing.Point(441, 35)
        Me.txtEquiment.Name = "txtEquiment"
        Me.txtEquiment.Size = New System.Drawing.Size(292, 21)
        Me.txtEquiment.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(204, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 12)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "设备/治具数量:"
        '
        'txtQty
        '
        Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty.Location = New System.Drawing.Point(295, 76)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(81, 21)
        Me.txtQty.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(234, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 12)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "平衡人力:"
        '
        'txtBalancePerson
        '
        Me.txtBalancePerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalancePerson.Location = New System.Drawing.Point(295, 114)
        Me.txtBalancePerson.Name = "txtBalancePerson"
        Me.txtBalancePerson.Size = New System.Drawing.Size(81, 21)
        Me.txtBalancePerson.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(380, 119)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 12)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "平衡工时(S):"
        '
        'txtBalanceHours
        '
        Me.txtBalanceHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalanceHours.Location = New System.Drawing.Point(460, 114)
        Me.txtBalanceHours.Name = "txtBalanceHours"
        Me.txtBalanceHours.ReadOnly = True
        Me.txtBalanceHours.Size = New System.Drawing.Size(79, 21)
        Me.txtBalanceHours.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(-1, 119)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 12)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "平衡产量(PCS/H):"
        '
        'txtBalanceQty
        '
        Me.txtBalanceQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalanceQty.Location = New System.Drawing.Point(103, 114)
        Me.txtBalanceQty.Name = "txtBalanceQty"
        Me.txtBalanceQty.ReadOnly = True
        Me.txtBalanceQty.Size = New System.Drawing.Size(96, 21)
        Me.txtBalanceQty.TabIndex = 19
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 159)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 12)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "制程重点与建议:"
        '
        'txtRemark
        '
        Me.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemark.Location = New System.Drawing.Point(103, 157)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(630, 21)
        Me.txtRemark.TabIndex = 21
        '
        'BtnOK
        '
        Me.BtnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnOK.Location = New System.Drawing.Point(252, 199)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(75, 23)
        Me.BtnOK.TabIndex = 22
        Me.BtnOK.Text = "提交"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCancel.Location = New System.Drawing.Point(422, 199)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 23
        Me.BtnCancel.Text = "取消"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(234, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 12)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "工站序号:"
        '
        'txtOrderBy
        '
        Me.txtOrderBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrderBy.Location = New System.Drawing.Point(295, 10)
        Me.txtOrderBy.Name = "txtOrderBy"
        Me.txtOrderBy.Size = New System.Drawing.Size(81, 21)
        Me.txtOrderBy.TabIndex = 25
        '
        'txtStationName
        '
        Me.txtStationName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStationName.Location = New System.Drawing.Point(441, 10)
        Me.txtStationName.Name = "txtStationName"
        Me.txtStationName.Size = New System.Drawing.Size(292, 21)
        Me.txtStationName.TabIndex = 26
        '
        'FrmStandardJobSchedulingAddDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 237)
        Me.Controls.Add(Me.txtStationName)
        Me.Controls.Add(Me.txtOrderBy)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtBalanceQty)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtBalanceHours)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtBalancePerson)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtEquiment)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtOutPut)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtUndulationTime)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSWorkingHours)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbStationType)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmStandardJobSchedulingAddDetails"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "新增工站"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbStationType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSWorkingHours As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUndulationTime As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtOutPut As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEquiment As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBalancePerson As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtBalanceHours As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBalanceQty As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtOrderBy As System.Windows.Forms.TextBox
    Friend WithEvents txtStationName As System.Windows.Forms.TextBox
End Class
