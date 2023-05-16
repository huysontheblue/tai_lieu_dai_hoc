<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelectMenuTree
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelectMenuTree))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnExit = New System.Windows.Forms.ToolStripButton()
        Me.GroupBoxMenu = New System.Windows.Forms.GroupBox()
        Me.tvMenu = New System.Windows.Forms.TreeView()
        Me.BtnYes = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.TxtTkey = New System.Windows.Forms.TextBox()
        Me.TxtTtext = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBoxMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnRefresh, Me.ToolStripSeparator1, Me.BtnExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(584, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip2"
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Image = CType(resources.GetObject("BtnRefresh.Image"), System.Drawing.Image)
        Me.BtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(68, 22)
        Me.BtnRefresh.Text = "刷新(&R)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BtnExit
        '
        Me.BtnExit.Image = CType(resources.GetObject("BtnExit.Image"), System.Drawing.Image)
        Me.BtnExit.ImageTransparentColor = System.Drawing.Color.White
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(68, 22)
        Me.BtnExit.Text = "关闭(&X)"
        Me.BtnExit.ToolTipText = "退出"
        '
        'GroupBoxMenu
        '
        Me.GroupBoxMenu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxMenu.Controls.Add(Me.tvMenu)
        Me.GroupBoxMenu.Location = New System.Drawing.Point(12, 28)
        Me.GroupBoxMenu.Name = "GroupBoxMenu"
        Me.GroupBoxMenu.Size = New System.Drawing.Size(560, 287)
        Me.GroupBoxMenu.TabIndex = 10
        Me.GroupBoxMenu.TabStop = False
        Me.GroupBoxMenu.Text = "系统菜单列表"
        '
        'tvMenu
        '
        Me.tvMenu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvMenu.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvMenu.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tvMenu.ItemHeight = 18
        Me.tvMenu.Location = New System.Drawing.Point(6, 20)
        Me.tvMenu.Name = "tvMenu"
        Me.tvMenu.Size = New System.Drawing.Size(548, 261)
        Me.tvMenu.TabIndex = 0
        '
        'BtnYes
        '
        Me.BtnYes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnYes.Location = New System.Drawing.Point(398, 18)
        Me.BtnYes.Name = "BtnYes"
        Me.BtnYes.Size = New System.Drawing.Size(75, 23)
        Me.BtnYes.TabIndex = 0
        Me.BtnYes.Text = "确定"
        Me.BtnYes.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Location = New System.Drawing.Point(479, 18)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "关闭"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'TxtTkey
        '
        Me.TxtTkey.Location = New System.Drawing.Point(11, 20)
        Me.TxtTkey.Name = "TxtTkey"
        Me.TxtTkey.ReadOnly = True
        Me.TxtTkey.Size = New System.Drawing.Size(100, 21)
        Me.TxtTkey.TabIndex = 13
        '
        'TxtTtext
        '
        Me.TxtTtext.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTtext.Location = New System.Drawing.Point(117, 20)
        Me.TxtTtext.Name = "TxtTtext"
        Me.TxtTtext.ReadOnly = True
        Me.TxtTtext.Size = New System.Drawing.Size(275, 21)
        Me.TxtTtext.TabIndex = 14
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TxtTkey)
        Me.GroupBox1.Controls.Add(Me.BtnCancel)
        Me.GroupBox1.Controls.Add(Me.TxtTtext)
        Me.GroupBox1.Controls.Add(Me.BtnYes)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 321)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 57)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "选中节点"
        '
        'FrmSelectMenuTree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 384)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBoxMenu)
        Me.Controls.Add(Me.ToolStrip1)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "FrmSelectMenuTree"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "选择父菜单"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBoxMenu.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBoxMenu As System.Windows.Forms.GroupBox
    Friend WithEvents tvMenu As System.Windows.Forms.TreeView
    Friend WithEvents BtnYes As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents TxtTtext As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtTkey As System.Windows.Forms.TextBox
End Class
