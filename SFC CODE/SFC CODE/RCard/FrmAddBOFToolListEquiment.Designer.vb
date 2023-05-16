<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAddBOFToolListEquiment
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
        Me.cmbEquimentType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEquimentName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDemandQty = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.txtCapacity = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFixtureNumber = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtPartID = New System.Windows.Forms.TextBox()
        Me.txtStationName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmbEquimentType
        '
        Me.cmbEquimentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEquimentType.FormattingEnabled = True
        Me.cmbEquimentType.Items.AddRange(New Object() {"治具", "设备"})
        Me.cmbEquimentType.Location = New System.Drawing.Point(72, 36)
        Me.cmbEquimentType.Name = "cmbEquimentType"
        Me.cmbEquimentType.Size = New System.Drawing.Size(121, 20)
        Me.cmbEquimentType.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "装备类型:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "装备&治具名称:"
        '
        'txtEquimentName
        '
        Me.txtEquimentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEquimentName.Location = New System.Drawing.Point(299, 35)
        Me.txtEquimentName.Name = "txtEquimentName"
        Me.txtEquimentName.Size = New System.Drawing.Size(459, 21)
        Me.txtEquimentName.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "需求数量:"
        '
        'txtDemandQty
        '
        Me.txtDemandQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDemandQty.Location = New System.Drawing.Point(72, 80)
        Me.txtDemandQty.Name = "txtDemandQty"
        Me.txtDemandQty.Size = New System.Drawing.Size(121, 21)
        Me.txtDemandQty.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(199, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "价格:"
        '
        'txtPrice
        '
        Me.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice.Location = New System.Drawing.Point(240, 80)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(92, 21)
        Me.txtPrice.TabIndex = 7
        '
        'txtCapacity
        '
        Me.txtCapacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCapacity.Location = New System.Drawing.Point(390, 80)
        Me.txtCapacity.Name = "txtCapacity"
        Me.txtCapacity.Size = New System.Drawing.Size(84, 21)
        Me.txtCapacity.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(336, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "产能(H):"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(482, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "治具料号:"
        '
        'txtFixtureNumber
        '
        Me.txtFixtureNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFixtureNumber.Location = New System.Drawing.Point(547, 80)
        Me.txtFixtureNumber.Name = "txtFixtureNumber"
        Me.txtFixtureNumber.Size = New System.Drawing.Size(211, 21)
        Me.txtFixtureNumber.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 12)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "备    注:"
        '
        'txtRemark
        '
        Me.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemark.Location = New System.Drawing.Point(72, 116)
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(686, 59)
        Me.txtRemark.TabIndex = 13
        '
        'btnSubmit
        '
        Me.btnSubmit.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnSubmit.Location = New System.Drawing.Point(645, 184)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(113, 65)
        Me.btnSubmit.TabIndex = 14
        Me.btnSubmit.Text = "提交"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(37, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 12)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "料号:"
        '
        'TxtPartID
        '
        Me.TxtPartID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPartID.Location = New System.Drawing.Point(72, 7)
        Me.TxtPartID.Name = "TxtPartID"
        Me.TxtPartID.ReadOnly = True
        Me.TxtPartID.Size = New System.Drawing.Size(229, 21)
        Me.TxtPartID.TabIndex = 16
        '
        'txtStationName
        '
        Me.txtStationName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStationName.Location = New System.Drawing.Point(372, 7)
        Me.txtStationName.Name = "txtStationName"
        Me.txtStationName.ReadOnly = True
        Me.txtStationName.Size = New System.Drawing.Size(386, 21)
        Me.txtStationName.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(307, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 12)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "工站名称:"
        '
        'FrmAddBOFToolListEquiment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 261)
        Me.Controls.Add(Me.txtStationName)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtPartID)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtFixtureNumber)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCapacity)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDemandQty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEquimentName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbEquimentType)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddBOFToolListEquiment"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "编辑设备&工治具资料"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbEquimentType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEquimentName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDemandQty As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtCapacity As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFixtureNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtPartID As System.Windows.Forms.TextBox
    Friend WithEvents txtStationName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
