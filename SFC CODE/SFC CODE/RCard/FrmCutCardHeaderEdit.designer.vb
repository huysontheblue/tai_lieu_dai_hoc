<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCutCardHeaderEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCutCardHeaderEdit))
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtStdLabors = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CobSeries = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CobCust = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtShape = New System.Windows.Forms.TextBox()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDrawingPath = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFinishSize = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDrawingVer = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCheckBom = New System.Windows.Forms.Button()
        Me.txtPartNumber = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.lblId = New System.Windows.Forms.Label()
        Me.lblPartId = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(513, 167)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "确 定(&O)"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(607, 167)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "取 消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(38, 167)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(47, 12)
        Me.lblMsg.TabIndex = 3
        Me.lblMsg.Text = "lblMsg"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtStdLabors)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.CobSeries)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.CobCust)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtShape)
        Me.GroupBox1.Controls.Add(Me.btnUpload)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtDrawingPath)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFinishSize)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtDrawingVer)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnCheckBom)
        Me.GroupBox1.Controls.Add(Me.txtPartNumber)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(869, 141)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'txtStdLabors
        '
        Me.txtStdLabors.Location = New System.Drawing.Point(90, 106)
        Me.txtStdLabors.Name = "txtStdLabors"
        Me.txtStdLabors.Size = New System.Drawing.Size(121, 21)
        Me.txtStdLabors.TabIndex = 95
        Me.txtStdLabors.Tag = "版本"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 109)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 12)
        Me.Label12.TabIndex = 96
        Me.Label12.Text = "标准拍配人力:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(806, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 12)
        Me.Label11.TabIndex = 94
        Me.Label11.Text = "*"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(597, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 12)
        Me.Label10.TabIndex = 93
        Me.Label10.Text = "*"
        '
        'CobSeries
        '
        Me.CobSeries.FormattingEnabled = True
        Me.CobSeries.Location = New System.Drawing.Point(679, 17)
        Me.CobSeries.Name = "CobSeries"
        Me.CobSeries.Size = New System.Drawing.Size(121, 20)
        Me.CobSeries.TabIndex = 92
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(632, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 12)
        Me.Label9.TabIndex = 91
        Me.Label9.Text = "系列别:"
        '
        'CobCust
        '
        Me.CobCust.FormattingEnabled = True
        Me.CobCust.Location = New System.Drawing.Point(466, 18)
        Me.CobCust.Name = "CobCust"
        Me.CobCust.Size = New System.Drawing.Size(121, 20)
        Me.CobCust.TabIndex = 90
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(400, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "客户名称:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(804, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 12)
        Me.Label8.TabIndex = 88
        Me.Label8.Text = "*"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(595, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 12)
        Me.Label7.TabIndex = 87
        Me.Label7.Text = "*"
        '
        'txtShape
        '
        Me.txtShape.Location = New System.Drawing.Point(523, 100)
        Me.txtShape.Name = "txtShape"
        Me.txtShape.Size = New System.Drawing.Size(277, 21)
        Me.txtShape.TabIndex = 5
        Me.txtShape.Tag = "图号"
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(302, 59)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(64, 23)
        Me.btnUpload.TabIndex = 4
        Me.btnUpload.Text = "上传..."
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(480, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "形态:"
        '
        'txtDrawingPath
        '
        Me.txtDrawingPath.Location = New System.Drawing.Point(89, 61)
        Me.txtDrawingPath.Name = "txtDrawingPath"
        Me.txtDrawingPath.ReadOnly = True
        Me.txtDrawingPath.Size = New System.Drawing.Size(199, 21)
        Me.txtDrawingPath.TabIndex = 24
        Me.txtDrawingPath.Tag = "客户图纸"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "客户图纸:"
        '
        'txtFinishSize
        '
        Me.txtFinishSize.Location = New System.Drawing.Point(688, 59)
        Me.txtFinishSize.Name = "txtFinishSize"
        Me.txtFinishSize.Size = New System.Drawing.Size(110, 21)
        Me.txtFinishSize.TabIndex = 3
        Me.txtFinishSize.Tag = "版本"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(623, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "成品尺寸:"
        '
        'txtDrawingVer
        '
        Me.txtDrawingVer.Location = New System.Drawing.Point(464, 59)
        Me.txtDrawingVer.Name = "txtDrawingVer"
        Me.txtDrawingVer.Size = New System.Drawing.Size(121, 21)
        Me.txtDrawingVer.TabIndex = 2
        Me.txtDrawingVer.Tag = "版本"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(422, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "版本:"
        '
        'btnCheckBom
        '
        Me.btnCheckBom.Location = New System.Drawing.Point(302, 15)
        Me.btnCheckBom.Name = "btnCheckBom"
        Me.btnCheckBom.Size = New System.Drawing.Size(66, 23)
        Me.btnCheckBom.TabIndex = 1
        Me.btnCheckBom.Text = "检查BOM"
        Me.btnCheckBom.UseVisualStyleBackColor = True
        '
        'txtPartNumber
        '
        Me.txtPartNumber.Location = New System.Drawing.Point(89, 17)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Size = New System.Drawing.Size(199, 21)
        Me.txtPartNumber.TabIndex = 0
        Me.txtPartNumber.Tag = "料件编号"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "料件编号:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "(*.jpg,*.gif,*.bmp,*.png,*.jpeg)|*.JPG;*.GIF;*.BMP;*.PNG;*.JPEG"
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(253, 167)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(35, 12)
        Me.lblId.TabIndex = 22
        Me.lblId.Text = "lblId"
        Me.lblId.Visible = False
        '
        'lblPartId
        '
        Me.lblPartId.AutoSize = True
        Me.lblPartId.Location = New System.Drawing.Point(333, 167)
        Me.lblPartId.Name = "lblPartId"
        Me.lblPartId.Size = New System.Drawing.Size(59, 12)
        Me.lblPartId.TabIndex = 23
        Me.lblPartId.Text = "lblPartId"
        Me.lblPartId.Visible = False
        '
        'FrmRunCardCutHeaderEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 207)
        Me.Controls.Add(Me.lblPartId)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmRunCardCutHeaderEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "新增裁线卡"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents txtDrawingPath As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDrawingVer As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCheckBom As System.Windows.Forms.Button
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtShape As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents lblPartId As System.Windows.Forms.Label
    Friend WithEvents txtFinishSize As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CobCust As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CobSeries As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtStdLabors As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
