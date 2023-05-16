<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHWASNCheck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHWASNCheck))
        Me.txtOldASNQRCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNewASNQRCode = New System.Windows.Forms.TextBox()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolScanSet = New System.Windows.Forms.ToolStripButton()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtOldASNQRCode
        '
        Me.txtOldASNQRCode.Location = New System.Drawing.Point(115, 61)
        Me.txtOldASNQRCode.Multiline = True
        Me.txtOldASNQRCode.Name = "txtOldASNQRCode"
        Me.txtOldASNQRCode.Size = New System.Drawing.Size(650, 79)
        Me.txtOldASNQRCode.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "旧ASN条码二维码:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 187)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "新ASN条码二维码:"
        '
        'txtNewASNQRCode
        '
        Me.txtNewASNQRCode.Location = New System.Drawing.Point(115, 158)
        Me.txtNewASNQRCode.Multiline = True
        Me.txtNewASNQRCode.Name = "txtNewASNQRCode"
        Me.txtNewASNQRCode.Size = New System.Drawing.Size(650, 79)
        Me.txtNewASNQRCode.TabIndex = 2
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMsg.Location = New System.Drawing.Point(109, 292)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(131, 32)
        Me.lblMsg.TabIndex = 143
        Me.lblMsg.Text = "提示信息"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator1, Me.toolScanSet, Me.toolExit, Me.ToolStripSeparator3})
        Me.toolStrip1.Location = New System.Drawing.Point(-1, 2)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(851, 33)
        Me.toolStrip1.TabIndex = 144
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 33)
        '
        'toolScanSet
        '
        Me.toolScanSet.Image = CType(resources.GetObject("toolScanSet.Image"), System.Drawing.Image)
        Me.toolScanSet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolScanSet.Name = "toolScanSet"
        Me.toolScanSet.Size = New System.Drawing.Size(97, 30)
        Me.toolScanSet.Text = "清除界面(&F1)"
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(67, 30)
        Me.toolExit.Text = "退出(&X)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 33)
        '
        'FrmHWASNCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 385)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNewASNQRCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtOldASNQRCode)
        Me.Name = "FrmHWASNCheck"
        Me.Text = "华为补打ASN条码校验"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOldASNQRCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNewASNQRCode As System.Windows.Forms.TextBox
    Private WithEvents lblMsg As System.Windows.Forms.Label
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolScanSet As System.Windows.Forms.ToolStripButton
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
End Class
