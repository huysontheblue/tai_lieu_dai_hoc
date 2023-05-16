<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCSamplingPlanDate
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
        Me.panelControl = New System.Windows.Forms.Panel()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.editName = New System.Windows.Forms.TextBox()
        Me.LabName = New System.Windows.Forms.Label()
        Me.LabDesc = New System.Windows.Forms.Label()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.panelControl.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelControl
        '
        Me.panelControl.AutoScroll = True
        Me.panelControl.BackColor = System.Drawing.Color.Transparent
        Me.panelControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelControl.Controls.Add(Me.ComboBox4)
        Me.panelControl.Controls.Add(Me.Label6)
        Me.panelControl.Controls.Add(Me.ComboBox3)
        Me.panelControl.Controls.Add(Me.Label5)
        Me.panelControl.Controls.Add(Me.ComboBox2)
        Me.panelControl.Controls.Add(Me.ComboBox1)
        Me.panelControl.Controls.Add(Me.Label4)
        Me.panelControl.Controls.Add(Me.TextBox3)
        Me.panelControl.Controls.Add(Me.Label3)
        Me.panelControl.Controls.Add(Me.TextBox2)
        Me.panelControl.Controls.Add(Me.Label2)
        Me.panelControl.Controls.Add(Me.TextBox1)
        Me.panelControl.Controls.Add(Me.Label1)
        Me.panelControl.Controls.Add(Me.editName)
        Me.panelControl.Controls.Add(Me.LabName)
        Me.panelControl.Controls.Add(Me.LabDesc)
        Me.panelControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelControl.Location = New System.Drawing.Point(0, 0)
        Me.panelControl.Name = "panelControl"
        Me.panelControl.Size = New System.Drawing.Size(378, 398)
        Me.panelControl.TabIndex = 4
        '
        'ComboBox4
        '
        Me.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Items.AddRange(New Object() {"正常", "加严", "减量"})
        Me.ComboBox4.Location = New System.Drawing.Point(144, 360)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(142, 20)
        Me.ComboBox4.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(12, 363)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 17)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "下一检验程度："
        '
        'ComboBox3
        '
        Me.ComboBox3.BackColor = System.Drawing.Color.White
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"正常", "加严", "减量"})
        Me.ComboBox3.Location = New System.Drawing.Point(144, 310)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(142, 20)
        Me.ComboBox3.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(12, 313)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "检验程度："
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Y", "N"})
        Me.ComboBox2.Location = New System.Drawing.Point(144, 260)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(142, 20)
        Me.ComboBox2.TabIndex = 14
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"QTY", "%"})
        Me.ComboBox1.Location = New System.Drawing.Point(144, 60)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(142, 20)
        Me.ComboBox1.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(12, 263)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "是否默认："
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(144, 210)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(142, 21)
        Me.TextBox3.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(12, 213)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 18)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "判退批次数："
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(144, 160)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(142, 21)
        Me.TextBox2.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(12, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 18)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "连续检验批："
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(144, 110)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(142, 21)
        Me.TextBox1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 38)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "功能检验比例(基数为已送检小批量)："
        '
        'editName
        '
        Me.editName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.editName.Location = New System.Drawing.Point(144, 10)
        Me.editName.Name = "editName"
        Me.editName.Size = New System.Drawing.Size(142, 21)
        Me.editName.TabIndex = 0
        '
        'LabName
        '
        Me.LabName.BackColor = System.Drawing.Color.Transparent
        Me.LabName.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.LabName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabName.Location = New System.Drawing.Point(12, 13)
        Me.LabName.Name = "LabName"
        Me.LabName.Size = New System.Drawing.Size(72, 13)
        Me.LabName.TabIndex = 1
        Me.LabName.Text = "配置数："
        '
        'LabDesc
        '
        Me.LabDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabDesc.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.LabDesc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabDesc.Location = New System.Drawing.Point(12, 63)
        Me.LabDesc.Name = "LabDesc"
        Me.LabDesc.Size = New System.Drawing.Size(98, 13)
        Me.LabDesc.TabIndex = 4
        Me.LabDesc.Text = "配置单位："
        '
        'panel2
        '
        Me.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panel2.Controls.Add(Me.btnCancel)
        Me.panel2.Controls.Add(Me.btnOK)
        Me.panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panel2.Location = New System.Drawing.Point(0, 398)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(378, 33)
        Me.panel2.TabIndex = 5
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancel.Location = New System.Drawing.Point(292, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnOK.Location = New System.Drawing.Point(211, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'FrmCSamplingPlanDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 431)
        Me.Controls.Add(Me.panelControl)
        Me.Controls.Add(Me.panel2)
        Me.Name = "FrmCSamplingPlanDate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmCSamplingPlanDate"
        Me.panelControl.ResumeLayout(False)
        Me.panelControl.PerformLayout()
        Me.panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panelControl As System.Windows.Forms.Panel
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents TextBox3 As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents TextBox2 As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents TextBox1 As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents editName As System.Windows.Forms.TextBox
    Private WithEvents LabName As System.Windows.Forms.Label
    Private WithEvents LabDesc As System.Windows.Forms.Label
    Private WithEvents panel2 As System.Windows.Forms.Panel
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Private WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Private WithEvents Label5 As System.Windows.Forms.Label
End Class
