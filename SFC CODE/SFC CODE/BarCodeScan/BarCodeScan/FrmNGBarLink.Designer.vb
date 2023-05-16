<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNGBarLink
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
        Me.lblMOID = New System.Windows.Forms.Label()
        Me.lblPartID = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblStationID = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblSNStyle = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.txtNGBarCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnLink = New System.Windows.Forms.Button()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(92, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "工单号:"
        '
        'lblMOID
        '
        Me.lblMOID.AutoSize = True
        Me.lblMOID.Location = New System.Drawing.Point(146, 53)
        Me.lblMOID.Name = "lblMOID"
        Me.lblMOID.Size = New System.Drawing.Size(29, 12)
        Me.lblMOID.TabIndex = 1
        Me.lblMOID.Text = "moid"
        '
        'lblPartID
        '
        Me.lblPartID.AutoSize = True
        Me.lblPartID.Location = New System.Drawing.Point(296, 53)
        Me.lblPartID.Name = "lblPartID"
        Me.lblPartID.Size = New System.Drawing.Size(41, 12)
        Me.lblPartID.TabIndex = 3
        Me.lblPartID.Text = "partid"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(242, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "料件编码:"
        '
        'lblStationID
        '
        Me.lblStationID.AutoSize = True
        Me.lblStationID.Location = New System.Drawing.Point(146, 80)
        Me.lblStationID.Name = "lblStationID"
        Me.lblStationID.Size = New System.Drawing.Size(59, 12)
        Me.lblStationID.TabIndex = 5
        Me.lblStationID.Text = "stationid"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(102, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "工站:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(68, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 12)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "产品SN样式:"
        '
        'lblSNStyle
        '
        Me.lblSNStyle.AutoSize = True
        Me.lblSNStyle.Location = New System.Drawing.Point(145, 116)
        Me.lblSNStyle.Name = "lblSNStyle"
        Me.lblSNStyle.Size = New System.Drawing.Size(71, 12)
        Me.lblSNStyle.TabIndex = 7
        Me.lblSNStyle.Text = "XXX-XX-XXXX"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(66, 158)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 12)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "产品SN条码:"
        '
        'txtSN
        '
        Me.txtSN.Location = New System.Drawing.Point(148, 155)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(210, 21)
        Me.txtSN.TabIndex = 9
        '
        'txtNGBarCode
        '
        Me.txtNGBarCode.Location = New System.Drawing.Point(148, 196)
        Me.txtNGBarCode.Name = "txtNGBarCode"
        Me.txtNGBarCode.Size = New System.Drawing.Size(210, 21)
        Me.txtNGBarCode.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(74, 199)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 12)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "不良条码:"
        '
        'btnLink
        '
        Me.btnLink.Location = New System.Drawing.Point(169, 275)
        Me.btnLink.Name = "btnLink"
        Me.btnLink.Size = New System.Drawing.Size(116, 35)
        Me.btnLink.TabIndex = 12
        Me.btnLink.Text = "关联"
        Me.btnLink.UseVisualStyleBackColor = True
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Location = New System.Drawing.Point(53, 247)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(23, 12)
        Me.lblMsg.TabIndex = 13
        Me.lblMsg.Text = "Msg"
        '
        'FrmNGBarLink
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(588, 343)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.btnLink)
        Me.Controls.Add(Me.txtNGBarCode)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtSN)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblSNStyle)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblStationID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblPartID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblMOID)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmNGBarLink"
        Me.Text = "产品条码和不良条码关联"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblMOID As System.Windows.Forms.Label
    Friend WithEvents lblPartID As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblStationID As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblSNStyle As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents txtNGBarCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnLink As System.Windows.Forms.Button
    Friend WithEvents lblMsg As System.Windows.Forms.Label
End Class
