<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCOMSet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCOMSet))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rblXN = New System.Windows.Forms.RadioButton()
        Me.rdoMachine2 = New System.Windows.Forms.RadioButton()
        Me.rdoMachine1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCOMValue = New System.Windows.Forms.ComboBox()
        Me.TxtBaudRate = New System.Windows.Forms.TextBox()
        Me.TxtStopByte = New System.Windows.Forms.TextBox()
        Me.TxtDataByte = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.lblSetOther = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnCancelMod = New System.Windows.Forms.Button()
        Me.btnConfirmMod = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtCheckByte = New System.Windows.Forms.ComboBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(4, 3)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(987, 602)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.btnCancel)
        Me.TabPage1.Controls.Add(Me.btnConfirm)
        Me.TabPage1.Controls.Add(Me.lblSetOther)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(979, 570)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "COM口设置"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.rblXN)
        Me.GroupBox2.Controls.Add(Me.rdoMachine2)
        Me.GroupBox2.Controls.Add(Me.rdoMachine1)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 156)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(963, 138)
        Me.GroupBox2.TabIndex = 223
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "机台 设置"
        '
        'rblXN
        '
        Me.rblXN.AutoSize = True
        Me.rblXN.Location = New System.Drawing.Point(505, 62)
        Me.rblXN.Margin = New System.Windows.Forms.Padding(4)
        Me.rblXN.Name = "rblXN"
        Me.rblXN.Size = New System.Drawing.Size(195, 22)
        Me.rblXN.TabIndex = 1
        Me.rblXN.TabStop = True
        Me.rblXN.Text = "兴宁PLC机台(专用）"
        Me.rblXN.UseVisualStyleBackColor = True
        '
        'rdoMachine2
        '
        Me.rdoMachine2.AutoSize = True
        Me.rdoMachine2.Location = New System.Drawing.Point(337, 62)
        Me.rdoMachine2.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoMachine2.Name = "rdoMachine2"
        Me.rdoMachine2.Size = New System.Drawing.Size(123, 22)
        Me.rdoMachine2.TabIndex = 1
        Me.rdoMachine2.TabStop = True
        Me.rdoMachine2.Text = "自定义机台"
        Me.rdoMachine2.UseVisualStyleBackColor = True
        '
        'rdoMachine1
        '
        Me.rdoMachine1.AutoSize = True
        Me.rdoMachine1.Location = New System.Drawing.Point(61, 62)
        Me.rdoMachine1.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoMachine1.Name = "rdoMachine1"
        Me.rdoMachine1.Size = New System.Drawing.Size(231, 22)
        Me.rdoMachine1.TabIndex = 1
        Me.rdoMachine1.TabStop = True
        Me.rdoMachine1.Text = "东莞自动扫描机（锁定）"
        Me.rdoMachine1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TxtCheckByte)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtCOMValue)
        Me.GroupBox1.Controls.Add(Me.TxtBaudRate)
        Me.GroupBox1.Controls.Add(Me.TxtStopByte)
        Me.GroupBox1.Controls.Add(Me.TxtDataByte)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(963, 138)
        Me.GroupBox1.TabIndex = 222
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "通信信息设置"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(609, 32)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 18)
        Me.Label8.TabIndex = 215
        Me.Label8.Text = "停止位："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(305, 95)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 18)
        Me.Label7.TabIndex = 214
        Me.Label7.Text = "数据位："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 95)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 18)
        Me.Label6.TabIndex = 213
        Me.Label6.Text = "校验位："
        '
        'txtCOMValue
        '
        Me.txtCOMValue.AutoCompleteCustomSource.AddRange(New String() {"COM0", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9"})
        Me.txtCOMValue.ForeColor = System.Drawing.Color.Maroon
        Me.txtCOMValue.FormattingEnabled = True
        Me.txtCOMValue.Items.AddRange(New Object() {"COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9"})
        Me.txtCOMValue.Location = New System.Drawing.Point(109, 28)
        Me.txtCOMValue.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCOMValue.Name = "txtCOMValue"
        Me.txtCOMValue.Size = New System.Drawing.Size(168, 26)
        Me.txtCOMValue.TabIndex = 0
        '
        'TxtBaudRate
        '
        Me.TxtBaudRate.BackColor = System.Drawing.Color.White
        Me.TxtBaudRate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtBaudRate.Location = New System.Drawing.Point(390, 28)
        Me.TxtBaudRate.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtBaudRate.Name = "TxtBaudRate"
        Me.TxtBaudRate.Size = New System.Drawing.Size(168, 28)
        Me.TxtBaudRate.TabIndex = 1
        '
        'TxtStopByte
        '
        Me.TxtStopByte.BackColor = System.Drawing.Color.White
        Me.TxtStopByte.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtStopByte.Location = New System.Drawing.Point(694, 28)
        Me.TxtStopByte.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtStopByte.Name = "TxtStopByte"
        Me.TxtStopByte.Size = New System.Drawing.Size(160, 28)
        Me.TxtStopByte.TabIndex = 2
        '
        'TxtDataByte
        '
        Me.TxtDataByte.BackColor = System.Drawing.Color.White
        Me.TxtDataByte.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtDataByte.Location = New System.Drawing.Point(390, 90)
        Me.TxtDataByte.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDataByte.Name = "TxtDataByte"
        Me.TxtDataByte.Size = New System.Drawing.Size(168, 28)
        Me.TxtDataByte.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(305, 32)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 18)
        Me.Label5.TabIndex = 206
        Me.Label5.Text = "波特率："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 32)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 18)
        Me.Label4.TabIndex = 205
        Me.Label4.Text = "通信端口："
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(539, 405)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(228, 92)
        Me.btnCancel.TabIndex = 221
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(199, 405)
        Me.btnConfirm.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(228, 92)
        Me.btnConfirm.TabIndex = 220
        Me.btnConfirm.Text = "确定"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'lblSetOther
        '
        Me.lblSetOther.AutoSize = True
        Me.lblSetOther.Location = New System.Drawing.Point(586, 342)
        Me.lblSetOther.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSetOther.Name = "lblSetOther"
        Me.lblSetOther.Size = New System.Drawing.Size(116, 18)
        Me.lblSetOther.TabIndex = 219
        Me.lblSetOther.Text = "|38400|0|8|1"
        Me.lblSetOther.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(96, 342)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(305, 18)
        Me.Label2.TabIndex = 218
        Me.Label2.Text = "COM口格式：COM1，COM2...,COM10..."
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.btnCancelMod)
        Me.TabPage2.Controls.Add(Me.btnConfirmMod)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Size = New System.Drawing.Size(979, 570)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Modbus设置"
        '
        'btnCancelMod
        '
        Me.btnCancelMod.Location = New System.Drawing.Point(405, 260)
        Me.btnCancelMod.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelMod.Name = "btnCancelMod"
        Me.btnCancelMod.Size = New System.Drawing.Size(228, 92)
        Me.btnCancelMod.TabIndex = 225
        Me.btnCancelMod.Text = "取消"
        Me.btnCancelMod.UseVisualStyleBackColor = True
        '
        'btnConfirmMod
        '
        Me.btnConfirmMod.Location = New System.Drawing.Point(66, 260)
        Me.btnConfirmMod.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConfirmMod.Name = "btnConfirmMod"
        Me.btnConfirmMod.Size = New System.Drawing.Size(228, 92)
        Me.btnConfirmMod.TabIndex = 224
        Me.btnConfirmMod.Text = "确定"
        Me.btnConfirmMod.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtIP)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 9)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(882, 138)
        Me.GroupBox3.TabIndex = 223
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "通信信息设置"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(358, 44)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(206, 18)
        Me.Label1.TabIndex = 219
        Me.Label1.Text = "格式：192.168.10.2|502"
        '
        'txtIP
        '
        Me.txtIP.BackColor = System.Drawing.Color.White
        Me.txtIP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtIP.Location = New System.Drawing.Point(116, 30)
        Me.txtIP.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(168, 28)
        Me.txtIP.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 34)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 18)
        Me.Label11.TabIndex = 205
        Me.Label11.Text = "机 台 IP："
        '
        'TxtCheckByte
        '
        Me.TxtCheckByte.AutoCompleteCustomSource.AddRange(New String() {"COM0", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9"})
        Me.TxtCheckByte.ForeColor = System.Drawing.Color.Maroon
        Me.TxtCheckByte.FormattingEnabled = True
        Me.TxtCheckByte.Items.AddRange(New Object() {"0-无NONE", "1-奇ODD", "2-偶EVEN"})
        Me.TxtCheckByte.Location = New System.Drawing.Point(109, 90)
        Me.TxtCheckByte.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCheckByte.Name = "TxtCheckByte"
        Me.TxtCheckByte.Size = New System.Drawing.Size(168, 26)
        Me.TxtCheckByte.TabIndex = 216
        '
        'FrmCOMSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(993, 603)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "FrmCOMSet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "COM口设置"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoMachine2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoMachine1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCOMValue As System.Windows.Forms.ComboBox
    Friend WithEvents TxtBaudRate As System.Windows.Forms.TextBox
    Friend WithEvents TxtStopByte As System.Windows.Forms.TextBox
    Friend WithEvents TxtDataByte As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents lblSetOther As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnCancelMod As System.Windows.Forms.Button
    Friend WithEvents btnConfirmMod As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIP As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents rblXN As System.Windows.Forms.RadioButton
    Friend WithEvents TxtCheckByte As System.Windows.Forms.ComboBox
End Class
