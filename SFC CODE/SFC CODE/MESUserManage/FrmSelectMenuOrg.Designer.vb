<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelectMenuOrg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelectMenuOrg))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnExit = New System.Windows.Forms.ToolStripButton()
        Me.GroupBoxMenu = New System.Windows.Forms.GroupBox()
        Me.RbUnFilter = New System.Windows.Forms.RadioButton()
        Me.RbFilter = New System.Windows.Forms.RadioButton()
        Me.tvMenu = New System.Windows.Forms.TreeView()
        Me.TxtTkey = New System.Windows.Forms.TextBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.TxtTtext = New System.Windows.Forms.TextBox()
        Me.BtnYes = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblMsg = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblRecord = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBoxMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
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
        Me.GroupBoxMenu.Controls.Add(Me.LblRecord)
        Me.GroupBoxMenu.Controls.Add(Me.RbUnFilter)
        Me.GroupBoxMenu.Controls.Add(Me.RbFilter)
        Me.GroupBoxMenu.Controls.Add(Me.tvMenu)
        Me.GroupBoxMenu.Location = New System.Drawing.Point(12, 28)
        Me.GroupBoxMenu.Name = "GroupBoxMenu"
        Me.GroupBoxMenu.Size = New System.Drawing.Size(566, 266)
        Me.GroupBoxMenu.TabIndex = 19
        Me.GroupBoxMenu.TabStop = False
        '
        'RbUnFilter
        '
        Me.RbUnFilter.AutoSize = True
        Me.RbUnFilter.Checked = True
        Me.RbUnFilter.Location = New System.Drawing.Point(6, 13)
        Me.RbUnFilter.Name = "RbUnFilter"
        Me.RbUnFilter.Size = New System.Drawing.Size(47, 16)
        Me.RbUnFilter.TabIndex = 1
        Me.RbUnFilter.TabStop = True
        Me.RbUnFilter.Text = "全部"
        Me.RbUnFilter.UseVisualStyleBackColor = True
        '
        'RbFilter
        '
        Me.RbFilter.AutoSize = True
        Me.RbFilter.Location = New System.Drawing.Point(64, 13)
        Me.RbFilter.Name = "RbFilter"
        Me.RbFilter.Size = New System.Drawing.Size(47, 16)
        Me.RbFilter.TabIndex = 0
        Me.RbFilter.Text = "过滤"
        Me.RbFilter.UseVisualStyleBackColor = True
        '
        'tvMenu
        '
        Me.tvMenu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvMenu.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvMenu.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tvMenu.ItemHeight = 18
        Me.tvMenu.Location = New System.Drawing.Point(6, 35)
        Me.tvMenu.Name = "tvMenu"
        Me.tvMenu.Size = New System.Drawing.Size(554, 225)
        Me.tvMenu.TabIndex = 2
        '
        'TxtTkey
        '
        Me.TxtTkey.Location = New System.Drawing.Point(11, 20)
        Me.TxtTkey.Name = "TxtTkey"
        Me.TxtTkey.ReadOnly = True
        Me.TxtTkey.Size = New System.Drawing.Size(100, 21)
        Me.TxtTkey.TabIndex = 2
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Location = New System.Drawing.Point(485, 18)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "关闭"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'TxtTtext
        '
        Me.TxtTtext.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTtext.Location = New System.Drawing.Point(117, 20)
        Me.TxtTtext.Name = "TxtTtext"
        Me.TxtTtext.ReadOnly = True
        Me.TxtTtext.Size = New System.Drawing.Size(281, 21)
        Me.TxtTtext.TabIndex = 3
        '
        'BtnYes
        '
        Me.BtnYes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnYes.Location = New System.Drawing.Point(404, 18)
        Me.BtnYes.Name = "BtnYes"
        Me.BtnYes.Size = New System.Drawing.Size(75, 23)
        Me.BtnYes.TabIndex = 0
        Me.BtnYes.Text = "确定"
        Me.BtnYes.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TxtTkey)
        Me.GroupBox1.Controls.Add(Me.BtnCancel)
        Me.GroupBox1.Controls.Add(Me.TxtTtext)
        Me.GroupBox1.Controls.Add(Me.BtnYes)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 300)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(566, 57)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "选中节点"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblMsg})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 362)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(584, 22)
        Me.StatusStrip1.TabIndex = 21
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblMsg
        '
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(329, 17)
        Me.LblMsg.Text = "过滤=过滤掉菜单中已存在的；菜单修改时不过滤当前记录。"
        '
        'LblRecord
        '
        Me.LblRecord.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblRecord.AutoSize = True
        Me.LblRecord.BackColor = System.Drawing.Color.Black
        Me.LblRecord.ForeColor = System.Drawing.Color.Lime
        Me.LblRecord.Location = New System.Drawing.Point(468, 15)
        Me.LblRecord.Name = "LblRecord"
        Me.LblRecord.Size = New System.Drawing.Size(89, 12)
        Me.LblRecord.TabIndex = 3
        Me.LblRecord.Text = "记录总数：0000"
        '
        'FrmSelectMenuOrg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 384)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBoxMenu)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmSelectMenuOrg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FrmSelectMenuOrg"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBoxMenu.ResumeLayout(False)
        Me.GroupBoxMenu.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBoxMenu As System.Windows.Forms.GroupBox
    Friend WithEvents tvMenu As System.Windows.Forms.TreeView
    Friend WithEvents TxtTkey As System.Windows.Forms.TextBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents TxtTtext As System.Windows.Forms.TextBox
    Friend WithEvents BtnYes As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbUnFilter As System.Windows.Forms.RadioButton
    Friend WithEvents RbFilter As System.Windows.Forms.RadioButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents LblMsg As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LblRecord As System.Windows.Forms.Label
End Class
