<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPackForScrap
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPackForScrap))
        Me.lbBefore = New System.Windows.Forms.Label
        Me.lbNowPack = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.lbTotal = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.TxtSbarcode = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtCartonID = New System.Windows.Forms.TextBox
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label24 = New System.Windows.Forms.Label
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip
        Me.toolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolUsename = New System.Windows.Forms.ToolStripStatusLabel
        Me.toolExit = New System.Windows.Forms.ToolStripButton
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolOption = New System.Windows.Forms.ToolStripButton
        Me.toolScanSet = New System.Windows.Forms.ToolStripButton
        Me.ToolReplace = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Label32 = New System.Windows.Forms.Label
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TxtMO = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusStrip1.SuspendLayout()
        Me.menuStrip1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbBefore
        '
        Me.lbBefore.AutoSize = True
        Me.lbBefore.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbBefore.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbBefore.Location = New System.Drawing.Point(1127, 75)
        Me.lbBefore.Name = "lbBefore"
        Me.lbBefore.Size = New System.Drawing.Size(30, 32)
        Me.lbBefore.TabIndex = 163
        Me.lbBefore.Text = "0"
        Me.lbBefore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbNowPack
        '
        Me.lbNowPack.AutoSize = True
        Me.lbNowPack.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNowPack.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbNowPack.Location = New System.Drawing.Point(784, 121)
        Me.lbNowPack.Name = "lbNowPack"
        Me.lbNowPack.Size = New System.Drawing.Size(30, 32)
        Me.lbNowPack.TabIndex = 161
        Me.lbNowPack.Text = "0"
        Me.lbNowPack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label29.Location = New System.Drawing.Point(583, 121)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(218, 32)
        Me.Label29.TabIndex = 160
        Me.Label29.Text = "当前扫描数量："
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbTotal
        '
        Me.lbTotal.AutoSize = True
        Me.lbTotal.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotal.ForeColor = System.Drawing.Color.DarkCyan
        Me.lbTotal.Location = New System.Drawing.Point(784, 75)
        Me.lbTotal.Name = "lbTotal"
        Me.lbTotal.Size = New System.Drawing.Size(30, 32)
        Me.lbTotal.TabIndex = 159
        Me.lbTotal.Text = "0"
        Me.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(581, 75)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(189, 32)
        Me.Label27.TabIndex = 158
        Me.Label27.Text = "可装箱数量："
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(93, 214)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(113, 29)
        Me.Label26.TabIndex = 157
        Me.Label26.Text = "提示信息"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtSbarcode
        '
        Me.TxtSbarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSbarcode.Location = New System.Drawing.Point(138, 175)
        Me.TxtSbarcode.Name = "TxtSbarcode"
        Me.TxtSbarcode.Size = New System.Drawing.Size(421, 21)
        Me.TxtSbarcode.TabIndex = 156
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(40, 175)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(89, 12)
        Me.Label25.TabIndex = 155
        Me.Label25.Text = "产品条码序号："
        '
        'TxtCartonID
        '
        Me.TxtCartonID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCartonID.Location = New System.Drawing.Point(138, 80)
        Me.TxtCartonID.Name = "TxtCartonID"
        Me.TxtCartonID.Size = New System.Drawing.Size(421, 21)
        Me.TxtCartonID.TabIndex = 154
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column12, Me.Column13, Me.Column14, Me.Column15})
        Me.DataGridView2.Location = New System.Drawing.Point(4, 274)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersWidth = 4
        Me.DataGridView2.RowTemplate.Height = 23
        Me.DataGridView2.Size = New System.Drawing.Size(1197, 447)
        Me.DataGridView2.TabIndex = 152
        '
        'Column12
        '
        Me.Column12.HeaderText = "外箱条码序号"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.HeaderText = "产品条码序号"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.HeaderText = "扫描人员"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column15
        '
        Me.Column15.HeaderText = "扫描时间"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(40, 86)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(89, 12)
        Me.Label24.TabIndex = 153
        Me.Label24.Text = "外箱条码序号："
        '
        'statusStrip1
        '
        Me.statusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel2, Me.toolStripStatusLabel1, Me.ToolUsename})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 724)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(1201, 22)
        Me.statusStrip1.TabIndex = 149
        Me.statusStrip1.Text = "statusStrip1"
        '
        'toolStripStatusLabel2
        '
        Me.toolStripStatusLabel2.Name = "toolStripStatusLabel2"
        Me.toolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'toolStripStatusLabel1
        '
        Me.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.toolStripStatusLabel1.Image = CType(resources.GetObject("toolStripStatusLabel1.Image"), System.Drawing.Image)
        Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
        Me.toolStripStatusLabel1.Size = New System.Drawing.Size(75, 17)
        Me.toolStripStatusLabel1.Text = "扫描人员:"
        '
        'ToolUsename
        '
        Me.ToolUsename.Name = "ToolUsename"
        Me.ToolUsename.Size = New System.Drawing.Size(44, 17)
        Me.ToolUsename.Text = "欧翔峰"
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(68, 22)
        Me.toolExit.Text = "退出(&X)"
        '
        'toolStripMenuItem1
        '
        Me.toolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
        Me.toolStripMenuItem1.Size = New System.Drawing.Size(59, 21)
        Me.toolStripMenuItem1.Text = "系统(&S)"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(140, 22)
        Me.ToolStripButton1.Text = "产品条码重码校验(C)"
        '
        'menuStrip1
        '
        Me.menuStrip1.BackColor = System.Drawing.Color.Gray
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2, Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5, Me.toolStripMenuItem6})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(1201, 25)
        Me.menuStrip1.TabIndex = 151
        Me.menuStrip1.Text = "menuStrip1"
        '
        'toolStripMenuItem2
        '
        Me.toolStripMenuItem2.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
        Me.toolStripMenuItem2.Size = New System.Drawing.Size(58, 21)
        Me.toolStripMenuItem2.Text = "文件(&F)"
        '
        'toolStripMenuItem3
        '
        Me.toolStripMenuItem3.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
        Me.toolStripMenuItem3.Size = New System.Drawing.Size(60, 21)
        Me.toolStripMenuItem3.Text = "查看(&V)"
        '
        'toolStripMenuItem4
        '
        Me.toolStripMenuItem4.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem4.Name = "toolStripMenuItem4"
        Me.toolStripMenuItem4.Size = New System.Drawing.Size(59, 21)
        Me.toolStripMenuItem4.Text = "工具(&T)"
        '
        'toolStripMenuItem5
        '
        Me.toolStripMenuItem5.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem5.Name = "toolStripMenuItem5"
        Me.toolStripMenuItem5.Size = New System.Drawing.Size(64, 21)
        Me.toolStripMenuItem5.Text = "窗口(&W)"
        '
        'toolStripMenuItem6
        '
        Me.toolStripMenuItem6.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem6.Name = "toolStripMenuItem6"
        Me.toolStripMenuItem6.Size = New System.Drawing.Size(61, 21)
        Me.toolStripMenuItem6.Text = "帮助(&H)"
        '
        'ToolOption
        '
        Me.ToolOption.Image = CType(resources.GetObject("ToolOption.Image"), System.Drawing.Image)
        Me.ToolOption.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolOption.Name = "ToolOption"
        Me.ToolOption.Size = New System.Drawing.Size(94, 22)
        Me.ToolOption.Text = "参数设置(&O)"
        '
        'toolScanSet
        '
        Me.toolScanSet.Image = CType(resources.GetObject("toolScanSet.Image"), System.Drawing.Image)
        Me.toolScanSet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolScanSet.Name = "toolScanSet"
        Me.toolScanSet.Size = New System.Drawing.Size(97, 22)
        Me.toolScanSet.Text = "混装检测(&F1)"
        '
        'ToolReplace
        '
        Me.ToolReplace.Image = CType(resources.GetObject("ToolReplace.Image"), System.Drawing.Image)
        Me.ToolReplace.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolReplace.Name = "ToolReplace"
        Me.ToolReplace.Size = New System.Drawing.Size(140, 22)
        Me.ToolReplace.Text = "产品条码替换打印(R)"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label32.Location = New System.Drawing.Point(896, 75)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(247, 32)
        Me.Label32.TabIndex = 162
        Me.Label32.Text = "扫描前已装数量："
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator1, Me.toolScanSet, Me.ToolOption, Me.ToolReplace, Me.ToolStripButton1, Me.toolExit, Me.ToolStripSeparator3})
        Me.toolStrip1.Location = New System.Drawing.Point(4, 30)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1259, 25)
        Me.toolStrip1.TabIndex = 150
        Me.toolStrip1.Text = "toolStrip1"
        '
        'TxtMO
        '
        Me.TxtMO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMO.Enabled = False
        Me.TxtMO.Location = New System.Drawing.Point(138, 132)
        Me.TxtMO.Name = "TxtMO"
        Me.TxtMO.ReadOnly = True
        Me.TxtMO.Size = New System.Drawing.Size(421, 21)
        Me.TxtMO.TabIndex = 164
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(88, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 165
        Me.Label1.Text = "工单："
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "外箱条码序号"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "产品条码序号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "扫描人员"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "扫描时间"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'FrmPackForScrap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1201, 746)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtMO)
        Me.Controls.Add(Me.lbBefore)
        Me.Controls.Add(Me.lbNowPack)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.lbTotal)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.TxtSbarcode)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.TxtCartonID)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "FrmPackForScrap"
        Me.Text = "报废品包装扫描作业"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lbBefore As System.Windows.Forms.Label
    Private WithEvents lbNowPack As System.Windows.Forms.Label
    Private WithEvents Label29 As System.Windows.Forms.Label
    Private WithEvents lbTotal As System.Windows.Forms.Label
    Private WithEvents Label27 As System.Windows.Forms.Label
    Private WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TxtSbarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtCartonID As System.Windows.Forms.TextBox
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents toolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolUsename As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolOption As System.Windows.Forms.ToolStripButton
    Private WithEvents toolScanSet As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolReplace As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents Label32 As System.Windows.Forms.Label
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TxtMO As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
