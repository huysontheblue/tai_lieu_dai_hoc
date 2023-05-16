<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTestStationHandle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTestStationHandle))
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolScanSet = New System.Windows.Forms.ToolStripButton()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NEWSN = New ULControls.textBoxUL()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.replace = New System.Windows.Forms.CheckBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.ChkUnbox = New System.Windows.Forms.CheckBox()
        Me.TxtBarCode = New ULControls.textBoxUL()
        Me.LblBarName = New System.Windows.Forms.Label()
        Me.CboStation = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboGroup = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tips = New System.Windows.Forms.Label()
        Me.toolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.toolStrip1.Location = New System.Drawing.Point(0, 1)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1267, 25)
        Me.toolStrip1.TabIndex = 131
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolScanSet
        '
        Me.toolScanSet.Image = CType(resources.GetObject("toolScanSet.Image"), System.Drawing.Image)
        Me.toolScanSet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolScanSet.Name = "toolScanSet"
        Me.toolScanSet.Size = New System.Drawing.Size(97, 22)
        Me.toolScanSet.Text = "扫描解锁(&F1)"
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(68, 22)
        Me.toolExit.Text = "退出(&X)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Tips)
        Me.GroupBox1.Controls.Add(Me.NEWSN)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.replace)
        Me.GroupBox1.Controls.Add(Me.lblMessage)
        Me.GroupBox1.Controls.Add(Me.ChkUnbox)
        Me.GroupBox1.Controls.Add(Me.TxtBarCode)
        Me.GroupBox1.Controls.Add(Me.LblBarName)
        Me.GroupBox1.Controls.Add(Me.CboStation)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboGroup)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1267, 135)
        Me.GroupBox1.TabIndex = 132
        Me.GroupBox1.TabStop = False
        '
        'NEWSN
        '
        Me.NEWSN.BackColor = System.Drawing.Color.White
        Me.NEWSN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NEWSN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NEWSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.NEWSN.Enabled = False
        Me.NEWSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.NEWSN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NEWSN.HotColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.NEWSN.Location = New System.Drawing.Point(136, 101)
        Me.NEWSN.Name = "NEWSN"
        Me.NEWSN.Size = New System.Drawing.Size(243, 14)
        Me.NEWSN.TabIndex = 117
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(29, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 18)
        Me.Label3.TabIndex = 116
        Me.Label3.Text = "替换新条码:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'replace
        '
        Me.replace.AutoSize = True
        Me.replace.Location = New System.Drawing.Point(498, 70)
        Me.replace.Name = "replace"
        Me.replace.Size = New System.Drawing.Size(72, 16)
        Me.replace.TabIndex = 115
        Me.replace.Text = "是否替换"
        Me.replace.UseVisualStyleBackColor = True
        '
        'lblMessage
        '
        Me.lblMessage.Location = New System.Drawing.Point(576, 64)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(603, 23)
        Me.lblMessage.TabIndex = 114
        '
        'ChkUnbox
        '
        Me.ChkUnbox.AutoSize = True
        Me.ChkUnbox.Location = New System.Drawing.Point(407, 71)
        Me.ChkUnbox.Name = "ChkUnbox"
        Me.ChkUnbox.Size = New System.Drawing.Size(72, 16)
        Me.ChkUnbox.TabIndex = 113
        Me.ChkUnbox.Text = "是否拆箱"
        Me.ChkUnbox.UseVisualStyleBackColor = True
        '
        'TxtBarCode
        '
        Me.TxtBarCode.BackColor = System.Drawing.Color.White
        Me.TxtBarCode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtBarCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBarCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBarCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TxtBarCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtBarCode.HotColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtBarCode.Location = New System.Drawing.Point(136, 69)
        Me.TxtBarCode.Name = "TxtBarCode"
        Me.TxtBarCode.Size = New System.Drawing.Size(243, 14)
        Me.TxtBarCode.TabIndex = 112
        '
        'LblBarName
        '
        Me.LblBarName.AutoSize = True
        Me.LblBarName.BackColor = System.Drawing.Color.White
        Me.LblBarName.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBarName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblBarName.Location = New System.Drawing.Point(12, 70)
        Me.LblBarName.Name = "LblBarName"
        Me.LblBarName.Size = New System.Drawing.Size(114, 18)
        Me.LblBarName.TabIndex = 111
        Me.LblBarName.Text = "产品条码序号:"
        Me.LblBarName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CboStation
        '
        Me.CboStation.DisplayMember = "Text"
        Me.CboStation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CboStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboStation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CboStation.FormattingEnabled = True
        Me.CboStation.ItemHeight = 15
        Me.CboStation.Location = New System.Drawing.Point(319, 24)
        Me.CboStation.Name = "CboStation"
        Me.CboStation.Size = New System.Drawing.Size(170, 21)
        Me.CboStation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CboStation.TabIndex = 110
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(276, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "站点:"
        '
        'cboGroup
        '
        Me.cboGroup.DisplayMember = "Text"
        Me.cboGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboGroup.FormattingEnabled = True
        Me.cboGroup.ItemHeight = 15
        Me.cboGroup.Location = New System.Drawing.Point(69, 24)
        Me.cboGroup.Name = "cboGroup"
        Me.cboGroup.Size = New System.Drawing.Size(170, 21)
        Me.cboGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboGroup.TabIndex = 110
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "站点群组:"
        '
        'Tips
        '
        Me.Tips.AutoSize = True
        Me.Tips.BackColor = System.Drawing.Color.Transparent
        Me.Tips.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Tips.ForeColor = System.Drawing.Color.Lime
        Me.Tips.Location = New System.Drawing.Point(404, 102)
        Me.Tips.Name = "Tips"
        Me.Tips.Size = New System.Drawing.Size(0, 19)
        Me.Tips.TabIndex = 118
        '
        'FrmTestStationHandle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1267, 549)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "FrmTestStationHandle"
        Me.Text = "测试站跳站"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolScanSet As System.Windows.Forms.ToolStripButton
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents CboStation As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChkUnbox As System.Windows.Forms.CheckBox
    Friend WithEvents TxtBarCode As ULControls.textBoxUL
    Friend WithEvents LblBarName As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents NEWSN As ULControls.textBoxUL
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents replace As System.Windows.Forms.CheckBox
    Private WithEvents cboGroup As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Tips As System.Windows.Forms.Label
End Class
