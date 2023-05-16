<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHWPackCheckLog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHWPackCheckLog))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolAdd = New System.Windows.Forms.ToolStripButton()
        Me.toolEdit = New System.Windows.Forms.ToolStripButton()
        Me.toolAbandon = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolBack = New System.Windows.Forms.ToolStripButton()
        Me.FileRefresh = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.dgvPackCheckLog = New System.Windows.Forms.DataGridView()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        CType(Me.dgvPackCheckLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.toolStrip1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvPackCheckLog)
        Me.SplitContainer1.Size = New System.Drawing.Size(659, 435)
        Me.SplitContainer1.SplitterDistance = 25
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 0
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAdd, Me.toolEdit, Me.toolAbandon, Me.ToolStripSeparator1, Me.toolBack, Me.FileRefresh, Me.toolStripSeparator4, Me.toolExport, Me.ToolStripSeparator2, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(-224, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(874, 25)
        Me.toolStrip1.TabIndex = 19
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolAdd
        '
        Me.toolAdd.Image = CType(resources.GetObject("toolAdd.Image"), System.Drawing.Image)
        Me.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAdd.Name = "toolAdd"
        Me.toolAdd.Size = New System.Drawing.Size(73, 22)
        Me.toolAdd.Tag = "NO"
        Me.toolAdd.Text = "新 增(&N)"
        '
        'toolEdit
        '
        Me.toolEdit.Image = CType(resources.GetObject("toolEdit.Image"), System.Drawing.Image)
        Me.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEdit.Name = "toolEdit"
        Me.toolEdit.Size = New System.Drawing.Size(73, 22)
        Me.toolEdit.Tag = "NO"
        Me.toolEdit.Text = "修 改(&E)"
        '
        'toolAbandon
        '
        Me.toolAbandon.Image = CType(resources.GetObject("toolAbandon.Image"), System.Drawing.Image)
        Me.toolAbandon.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAbandon.Name = "toolAbandon"
        Me.toolAbandon.Size = New System.Drawing.Size(73, 22)
        Me.toolAbandon.Tag = "NO"
        Me.toolAbandon.Text = "作 废(&D)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolBack
        '
        Me.toolBack.Image = CType(resources.GetObject("toolBack.Image"), System.Drawing.Image)
        Me.toolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBack.Name = "toolBack"
        Me.toolBack.Size = New System.Drawing.Size(73, 22)
        Me.toolBack.Tag = ""
        Me.toolBack.Text = "返 回(&B)"
        '
        'FileRefresh
        '
        Me.FileRefresh.Image = CType(resources.GetObject("FileRefresh.Image"), System.Drawing.Image)
        Me.FileRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.FileRefresh.Name = "FileRefresh"
        Me.FileRefresh.Size = New System.Drawing.Size(73, 22)
        Me.FileRefresh.Text = "刷 新(&R)"
        Me.FileRefresh.ToolTipText = "刷新"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'toolExport
        '
        Me.toolExport.Image = CType(resources.GetObject("toolExport.Image"), System.Drawing.Image)
        Me.toolExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExport.Name = "toolExport"
        Me.toolExport.Size = New System.Drawing.Size(67, 22)
        Me.toolExport.Text = "汇   出"
        Me.toolExport.ToolTipText = "汇   入(只对工治具)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(73, 22)
        Me.toolExit.Text = "退 出(&X)"
        '
        'dgvPackCheckLog
        '
        Me.dgvPackCheckLog.AllowUserToAddRows = False
        Me.dgvPackCheckLog.BackgroundColor = System.Drawing.Color.White
        Me.dgvPackCheckLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPackCheckLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPackCheckLog.Location = New System.Drawing.Point(0, 0)
        Me.dgvPackCheckLog.Name = "dgvPackCheckLog"
        Me.dgvPackCheckLog.RowTemplate.Height = 23
        Me.dgvPackCheckLog.Size = New System.Drawing.Size(659, 409)
        Me.dgvPackCheckLog.TabIndex = 0
        '
        'FrmHWPackCheckLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 435)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmHWPackCheckLog"
        Me.Text = "华为直提检查明细"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        CType(Me.dgvPackCheckLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEdit As System.Windows.Forms.ToolStripButton
    Private WithEvents toolAbandon As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents FileRefresh As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvPackCheckLog As System.Windows.Forms.DataGridView
End Class
