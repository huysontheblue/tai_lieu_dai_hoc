<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductitemAddson
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Serialnumber = New System.Windows.Forms.TextBox()
        Me.fomSmall = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.fomPartid = New System.Windows.Forms.Label()
        Me.editCode = New System.Windows.Forms.TextBox()
        Me.editName = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.panelControl.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelControl
        '
        Me.panelControl.AutoScroll = True
        Me.panelControl.BackColor = System.Drawing.Color.Transparent
        Me.panelControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelControl.Controls.Add(Me.Label1)
        Me.panelControl.Controls.Add(Me.Label3)
        Me.panelControl.Controls.Add(Me.Label6)
        Me.panelControl.Controls.Add(Me.Label5)
        Me.panelControl.Controls.Add(Me.Label4)
        Me.panelControl.Controls.Add(Me.Serialnumber)
        Me.panelControl.Controls.Add(Me.fomSmall)
        Me.panelControl.Controls.Add(Me.Button1)
        Me.panelControl.Controls.Add(Me.fomPartid)
        Me.panelControl.Controls.Add(Me.editCode)
        Me.panelControl.Controls.Add(Me.editName)
        Me.panelControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelControl.Location = New System.Drawing.Point(0, 0)
        Me.panelControl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panelControl.Name = "panelControl"
        Me.panelControl.Size = New System.Drawing.Size(585, 274)
        Me.panelControl.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 208)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 18)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "排序索引"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 27)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 18)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "料号"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(40, 154)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 18)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "测试小项名称"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(40, 108)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 18)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "测试小项代码"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 69)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 18)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "测试大项代码"
        '
        'Serialnumber
        '
        Me.Serialnumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Serialnumber.Location = New System.Drawing.Point(234, 204)
        Me.Serialnumber.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Serialnumber.Name = "Serialnumber"
        Me.Serialnumber.Size = New System.Drawing.Size(247, 28)
        Me.Serialnumber.TabIndex = 14
        '
        'fomSmall
        '
        Me.fomSmall.AutoSize = True
        Me.fomSmall.BackColor = System.Drawing.Color.Transparent
        Me.fomSmall.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.fomSmall.ForeColor = System.Drawing.Color.Maroon
        Me.fomSmall.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.fomSmall.Location = New System.Drawing.Point(230, 68)
        Me.fomSmall.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.fomSmall.Name = "fomSmall"
        Me.fomSmall.Size = New System.Drawing.Size(42, 20)
        Me.fomSmall.TabIndex = 13
        Me.fomSmall.Text = "N/A"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(492, 100)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(62, 34)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "....."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'fomPartid
        '
        Me.fomPartid.AutoSize = True
        Me.fomPartid.BackColor = System.Drawing.Color.Transparent
        Me.fomPartid.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.fomPartid.ForeColor = System.Drawing.Color.Maroon
        Me.fomPartid.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.fomPartid.Location = New System.Drawing.Point(230, 27)
        Me.fomPartid.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.fomPartid.Name = "fomPartid"
        Me.fomPartid.Size = New System.Drawing.Size(42, 20)
        Me.fomPartid.TabIndex = 10
        Me.fomPartid.Text = "N/A"
        '
        'editCode
        '
        Me.editCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.editCode.Enabled = False
        Me.editCode.Location = New System.Drawing.Point(234, 104)
        Me.editCode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.editCode.Name = "editCode"
        Me.editCode.Size = New System.Drawing.Size(247, 28)
        Me.editCode.TabIndex = 0
        '
        'editName
        '
        Me.editName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.editName.Enabled = False
        Me.editName.Location = New System.Drawing.Point(234, 150)
        Me.editName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.editName.Name = "editName"
        Me.editName.Size = New System.Drawing.Size(247, 28)
        Me.editName.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnOK.Location = New System.Drawing.Point(270, 4)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(112, 38)
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
        Me.panel2.Location = New System.Drawing.Point(0, 274)
        Me.panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(585, 48)
        Me.panel2.TabIndex = 7
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancel.Location = New System.Drawing.Point(417, 4)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(112, 38)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'FormProductitemAddson
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 322)
        Me.Controls.Add(Me.panelControl)
        Me.Controls.Add(Me.panel2)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormProductitemAddson"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "产品测试项目小项维护"
        Me.panelControl.ResumeLayout(False)
        Me.panelControl.PerformLayout()
        Me.panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents panelControl As Panel
    Private WithEvents fomSmall As Label
    Friend WithEvents Button1 As Button
    Private WithEvents fomPartid As Label
    Private WithEvents btnOK As Button
    Private WithEvents panel2 As Panel
    Private WithEvents btnCancel As Button
    Public WithEvents editCode As TextBox
    Public WithEvents editName As TextBox
    Public WithEvents Serialnumber As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
End Class
