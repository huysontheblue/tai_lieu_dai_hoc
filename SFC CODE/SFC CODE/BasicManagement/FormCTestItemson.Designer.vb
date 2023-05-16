<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCTestItemson
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.combHasValue = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.LabTypeName = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.editCode = New System.Windows.Forms.TextBox()
        Me.LabCode = New System.Windows.Forms.Label()
        Me.editDesc = New System.Windows.Forms.TextBox()
        Me.editName = New System.Windows.Forms.TextBox()
        Me.LabName = New System.Windows.Forms.Label()
        Me.LabDesc = New System.Windows.Forms.Label()
        Me.panelControl = New System.Windows.Forms.Panel()
        Me.panel2.SuspendLayout()
        Me.panelControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnOK.Location = New System.Drawing.Point(180, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "确定"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'panel2
        '
        Me.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panel2.Controls.Add(Me.btnCancel)
        Me.panel2.Controls.Add(Me.btnOK)
        Me.panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panel2.Location = New System.Drawing.Point(0, 166)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(367, 33)
        Me.panel2.TabIndex = 3
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancel.Location = New System.Drawing.Point(278, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'combHasValue
        '
        Me.combHasValue.BackColor = System.Drawing.Color.White
        Me.combHasValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combHasValue.FormattingEnabled = True
        Me.combHasValue.Items.AddRange(New Object() {"Y", "N"})
        Me.combHasValue.Location = New System.Drawing.Point(156, 126)
        Me.combHasValue.Name = "combHasValue"
        Me.combHasValue.Size = New System.Drawing.Size(117, 20)
        Me.combHasValue.TabIndex = 4
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.Color.Transparent
        Me.label2.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.label2.Location = New System.Drawing.Point(29, 126)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(72, 13)
        Me.label2.TabIndex = 5
        Me.label2.Text = "测试默认值"
        '
        'LabTypeName
        '
        Me.LabTypeName.AutoSize = True
        Me.LabTypeName.BackColor = System.Drawing.Color.Transparent
        Me.LabTypeName.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.LabTypeName.ForeColor = System.Drawing.Color.Maroon
        Me.LabTypeName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabTypeName.Location = New System.Drawing.Point(153, 18)
        Me.LabTypeName.Name = "LabTypeName"
        Me.LabTypeName.Size = New System.Drawing.Size(28, 13)
        Me.LabTypeName.TabIndex = 10
        Me.LabTypeName.Text = "N/A"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.Color.Transparent
        Me.label1.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.label1.Location = New System.Drawing.Point(29, 18)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(85, 13)
        Me.label1.TabIndex = 9
        Me.label1.Text = "测试大项名称"
        '
        'editCode
        '
        Me.editCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.editCode.Location = New System.Drawing.Point(156, 39)
        Me.editCode.Name = "editCode"
        Me.editCode.Size = New System.Drawing.Size(166, 21)
        Me.editCode.TabIndex = 0
        '
        'LabCode
        '
        Me.LabCode.AutoSize = True
        Me.LabCode.BackColor = System.Drawing.Color.Transparent
        Me.LabCode.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.LabCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabCode.Location = New System.Drawing.Point(29, 42)
        Me.LabCode.Name = "LabCode"
        Me.LabCode.Size = New System.Drawing.Size(85, 13)
        Me.LabCode.TabIndex = 5
        Me.LabCode.Text = "测试小项代码"
        '
        'editDesc
        '
        Me.editDesc.Location = New System.Drawing.Point(156, 91)
        Me.editDesc.Name = "editDesc"
        Me.editDesc.Size = New System.Drawing.Size(166, 21)
        Me.editDesc.TabIndex = 2
        '
        'editName
        '
        Me.editName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.editName.Location = New System.Drawing.Point(156, 65)
        Me.editName.Name = "editName"
        Me.editName.Size = New System.Drawing.Size(166, 21)
        Me.editName.TabIndex = 1
        '
        'LabName
        '
        Me.LabName.AutoSize = True
        Me.LabName.BackColor = System.Drawing.Color.Transparent
        Me.LabName.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.LabName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabName.Location = New System.Drawing.Point(29, 68)
        Me.LabName.Name = "LabName"
        Me.LabName.Size = New System.Drawing.Size(85, 13)
        Me.LabName.TabIndex = 1
        Me.LabName.Text = "测试小项名称"
        '
        'LabDesc
        '
        Me.LabDesc.AutoSize = True
        Me.LabDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabDesc.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.LabDesc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabDesc.Location = New System.Drawing.Point(29, 94)
        Me.LabDesc.Name = "LabDesc"
        Me.LabDesc.Size = New System.Drawing.Size(85, 13)
        Me.LabDesc.TabIndex = 4
        Me.LabDesc.Text = "测试小项描述"
        '
        'panelControl
        '
        Me.panelControl.AutoScroll = True
        Me.panelControl.BackColor = System.Drawing.Color.Transparent
        Me.panelControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelControl.Controls.Add(Me.label2)
        Me.panelControl.Controls.Add(Me.label1)
        Me.panelControl.Controls.Add(Me.LabCode)
        Me.panelControl.Controls.Add(Me.LabName)
        Me.panelControl.Controls.Add(Me.LabDesc)
        Me.panelControl.Controls.Add(Me.combHasValue)
        Me.panelControl.Controls.Add(Me.LabTypeName)
        Me.panelControl.Controls.Add(Me.editCode)
        Me.panelControl.Controls.Add(Me.editDesc)
        Me.panelControl.Controls.Add(Me.editName)
        Me.panelControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelControl.Location = New System.Drawing.Point(0, 0)
        Me.panelControl.Name = "panelControl"
        Me.panelControl.Size = New System.Drawing.Size(367, 199)
        Me.panelControl.TabIndex = 2
        '
        'FormCTestItemson
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 199)
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.panelControl)
        Me.Name = "FormCTestItemson"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "测试项目子项维护"
        Me.panel2.ResumeLayout(False)
        Me.panelControl.ResumeLayout(False)
        Me.panelControl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnOK As System.Windows.Forms.Button
    Private WithEvents panel2 As System.Windows.Forms.Panel
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents combHasValue As System.Windows.Forms.ComboBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents LabTypeName As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents editCode As System.Windows.Forms.TextBox
    Private WithEvents LabCode As System.Windows.Forms.Label
    Private WithEvents editDesc As System.Windows.Forms.TextBox
    Private WithEvents editName As System.Windows.Forms.TextBox
    Private WithEvents LabName As System.Windows.Forms.Label
    Private WithEvents LabDesc As System.Windows.Forms.Label
    Private WithEvents panelControl As System.Windows.Forms.Panel
End Class
