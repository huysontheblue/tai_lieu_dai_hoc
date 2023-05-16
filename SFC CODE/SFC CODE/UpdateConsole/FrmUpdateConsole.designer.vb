<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUpdateConsole
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUpdateConsole))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.dgvUpdateContent = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.ColIsMust = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.btnInstallAll = New System.Windows.Forms.Button()
        Me.chkBoxSelectAll = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VisibleUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.btnCheckUpdate = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblClientUser = New System.Windows.Forms.Label()
        Me.lblClientLine = New System.Windows.Forms.Label()
        Me.lblReleasedVersionName = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvUpdateContent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(3, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "更新列表"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.dgvUpdateContent)
        Me.Panel4.Location = New System.Drawing.Point(0, 175)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(600, 193)
        Me.Panel4.TabIndex = 4
        '
        'dgvUpdateContent
        '
        Me.dgvUpdateContent.AllowUserToAddRows = False
        Me.dgvUpdateContent.AllowUserToDeleteRows = False
        Me.dgvUpdateContent.AllowUserToResizeColumns = False
        Me.dgvUpdateContent.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvUpdateContent.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvUpdateContent.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.dgvUpdateContent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvUpdateContent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvUpdateContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUpdateContent.ColumnHeadersVisible = False
        Me.dgvUpdateContent.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.ColIsMust})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvUpdateContent.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvUpdateContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUpdateContent.Location = New System.Drawing.Point(0, 0)
        Me.dgvUpdateContent.Name = "dgvUpdateContent"
        Me.dgvUpdateContent.ReadOnly = True
        Me.dgvUpdateContent.RowHeadersVisible = False
        Me.dgvUpdateContent.RowTemplate.Height = 23
        Me.dgvUpdateContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUpdateContent.Size = New System.Drawing.Size(600, 193)
        Me.dgvUpdateContent.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.FalseValue = ""
        Me.Column1.Frozen = True
        Me.Column1.HeaderText = "选择"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.TrueValue = ""
        Me.Column1.Width = 33
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Name"
        Me.Column2.Frozen = True
        Me.Column2.HeaderText = "更新项名称"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 115
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "LocationVersion"
        Me.Column3.Frozen = True
        Me.Column3.HeaderText = "本地版本"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "NewVersion"
        Me.Column4.Frozen = True
        Me.Column4.HeaderText = "最新版本"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "PublishDate"
        Me.Column5.Frozen = True
        Me.Column5.HeaderText = "发布时间"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 105
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "Description"
        Me.Column6.Frozen = True
        Me.Column6.HeaderText = "更新说明"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 149
        '
        'ColIsMust
        '
        Me.ColIsMust.DataPropertyName = "IsMust"
        Me.ColIsMust.Frozen = True
        Me.ColIsMust.HeaderText = "是否必须更新项"
        Me.ColIsMust.Name = "ColIsMust"
        Me.ColIsMust.ReadOnly = True
        Me.ColIsMust.Visible = False
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(113, 127)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(0, 12)
        Me.lblMsg.TabIndex = 5
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(0, 144)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(600, 30)
        Me.Panel3.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(454, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 21)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "更新说明"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(348, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 21)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "发布时间"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(244, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 21)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "最新版本"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(146, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 21)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "本地版本"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(31, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 21)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "更新项名称"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.CheckBox2)
        Me.Panel2.Controls.Add(Me.btnInstallAll)
        Me.Panel2.Controls.Add(Me.chkBoxSelectAll)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 370)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(600, 30)
        Me.Panel2.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(121, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(197, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "注：以红底标识的为系统必须更新项"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Enabled = False
        Me.CheckBox2.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CheckBox2.ForeColor = System.Drawing.Color.White
        Me.CheckBox2.Location = New System.Drawing.Point(345, 4)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(159, 21)
        Me.CheckBox2.TabIndex = 2
        Me.CheckBox2.Text = "下次启动后自动进行更新"
        Me.CheckBox2.UseVisualStyleBackColor = False
        Me.CheckBox2.Visible = False
        '
        'btnInstallAll
        '
        Me.btnInstallAll.BackColor = System.Drawing.Color.Green
        Me.btnInstallAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInstallAll.FlatAppearance.BorderSize = 0
        Me.btnInstallAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnInstallAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInstallAll.Font = New System.Drawing.Font("微软雅黑", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnInstallAll.ForeColor = System.Drawing.Color.White
        Me.btnInstallAll.Location = New System.Drawing.Point(510, 0)
        Me.btnInstallAll.Name = "btnInstallAll"
        Me.btnInstallAll.Size = New System.Drawing.Size(90, 30)
        Me.btnInstallAll.TabIndex = 1
        Me.btnInstallAll.Text = "一键安装"
        Me.btnInstallAll.UseVisualStyleBackColor = False
        '
        'chkBoxSelectAll
        '
        Me.chkBoxSelectAll.AutoSize = True
        Me.chkBoxSelectAll.BackColor = System.Drawing.Color.Transparent
        Me.chkBoxSelectAll.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.chkBoxSelectAll.ForeColor = System.Drawing.Color.White
        Me.chkBoxSelectAll.Location = New System.Drawing.Point(8, 4)
        Me.chkBoxSelectAll.Name = "chkBoxSelectAll"
        Me.chkBoxSelectAll.Size = New System.Drawing.Size(80, 21)
        Me.chkBoxSelectAll.TabIndex = 0
        Me.chkBoxSelectAll.Text = "全选/取消"
        Me.chkBoxSelectAll.UseVisualStyleBackColor = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VisibleUpdateToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(137, 48)
        '
        'VisibleUpdateToolStripMenuItem
        '
        Me.VisibleUpdateToolStripMenuItem.Name = "VisibleUpdateToolStripMenuItem"
        Me.VisibleUpdateToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.VisibleUpdateToolStripMenuItem.Tag = "更新控制台"
        Me.VisibleUpdateToolStripMenuItem.Text = "更新控制台"
        Me.VisibleUpdateToolStripMenuItem.ToolTipText = "更新控制台"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ExitToolStripMenuItem.Tag = "退出"
        Me.ExitToolStripMenuItem.Text = "退出"
        Me.ExitToolStripMenuItem.ToolTipText = "退出"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipTitle = "MES更行控制台"
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "MES更新控制台"
        Me.NotifyIcon1.Visible = True
        '
        'btnCheckUpdate
        '
        Me.btnCheckUpdate.BackColor = System.Drawing.Color.Green
        Me.btnCheckUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCheckUpdate.FlatAppearance.BorderSize = 0
        Me.btnCheckUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCheckUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheckUpdate.Font = New System.Drawing.Font("微软雅黑", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnCheckUpdate.ForeColor = System.Drawing.Color.White
        Me.btnCheckUpdate.Location = New System.Drawing.Point(510, 114)
        Me.btnCheckUpdate.Name = "btnCheckUpdate"
        Me.btnCheckUpdate.Size = New System.Drawing.Size(90, 30)
        Me.btnCheckUpdate.TabIndex = 3
        Me.btnCheckUpdate.Text = "检查更新"
        Me.btnCheckUpdate.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(600, 89)
        Me.Panel1.TabIndex = 0
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.UpdateConsole.My.Resources.Resources.close
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(578, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(20, 20)
        Me.Button3.TabIndex = 1
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.UpdateConsole.My.Resources.Resources.minus
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(549, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(20, 20)
        Me.Button2.TabIndex = 0
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(168, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 21)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "产线："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(7, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 21)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "使用者:"
        '
        'lblClientUser
        '
        Me.lblClientUser.AutoSize = True
        Me.lblClientUser.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblClientUser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.lblClientUser.Location = New System.Drawing.Point(74, 92)
        Me.lblClientUser.Name = "lblClientUser"
        Me.lblClientUser.Size = New System.Drawing.Size(0, 21)
        Me.lblClientUser.TabIndex = 8
        '
        'lblClientLine
        '
        Me.lblClientLine.AutoSize = True
        Me.lblClientLine.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblClientLine.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.lblClientLine.Location = New System.Drawing.Point(224, 92)
        Me.lblClientLine.Name = "lblClientLine"
        Me.lblClientLine.Size = New System.Drawing.Size(0, 21)
        Me.lblClientLine.TabIndex = 9
        '
        'lblReleasedVersionName
        '
        Me.lblReleasedVersionName.AutoSize = True
        Me.lblReleasedVersionName.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblReleasedVersionName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.lblReleasedVersionName.Location = New System.Drawing.Point(368, 92)
        Me.lblReleasedVersionName.Name = "lblReleasedVersionName"
        Me.lblReleasedVersionName.Size = New System.Drawing.Size(0, 21)
        Me.lblReleasedVersionName.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(310, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 21)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "版本："
        '
        'FrmUpdateConsole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(600, 400)
        Me.Controls.Add(Me.lblReleasedVersionName)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblClientLine)
        Me.Controls.Add(Me.lblClientUser)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnCheckUpdate)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmUpdateConsole"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MES小助手"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.Panel4.ResumeLayout(False)
        CType(Me.dgvUpdateContent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkBoxSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents btnInstallAll As System.Windows.Forms.Button
    Friend WithEvents dgvUpdateContent As System.Windows.Forms.DataGridView
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents VisibleUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents ColIsMust As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCheckUpdate As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblClientUser As System.Windows.Forms.Label
    Friend WithEvents lblClientLine As System.Windows.Forms.Label
    Friend WithEvents lblReleasedVersionName As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
