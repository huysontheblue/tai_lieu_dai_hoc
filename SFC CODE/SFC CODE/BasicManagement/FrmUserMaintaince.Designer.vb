<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUserMaintaince
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUserMaintaince))
        Dim PageDataGridPager1 As Pager.PageDataGridPager = New Pager.PageDataGridPager()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolRollback = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolDownLoad = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TollExit = New System.Windows.Forms.ToolStripButton()
        Me.uxUserGroup = New System.Windows.Forms.GroupBox()
        Me.cboLine = New System.Windows.Forms.ComboBox()
        Me.cboDept = New System.Windows.Forms.ComboBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.txtUserId = New System.Windows.Forms.TextBox()
        Me.uxUserLine = New System.Windows.Forms.Label()
        Me.lblUserDept = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblUserId = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUserIdLoad = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvUserInfo = New System.Windows.Forms.DataGridView()
        Me.cboLineLoad = New System.Windows.Forms.ComboBox()
        Me.cboDeptLoad = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PagerPaging = New Pager.PagerPaging()
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.ToolBt.SuspendLayout()
        Me.uxUserGroup.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvUserInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNew, Me.ToolEdit, Me.ToolStripSeparator6, Me.ToolRollback, Me.ToolStripSeparator7, Me.ToolDownLoad, Me.ToolStripSeparator2, Me.ToolSave, Me.ToolStripSeparator1, Me.ToolQuery, Me.ToolRefresh, Me.ToolStripSeparator3, Me.TollExit})
        Me.ToolBt.Location = New System.Drawing.Point(1, 4)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(966, 25)
        Me.ToolBt.TabIndex = 15
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolNew
        '
        Me.ToolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolNew.Name = "ToolNew"
        Me.ToolNew.Size = New System.Drawing.Size(51, 22)
        Me.ToolNew.Text = "新增(&N)"
        '
        'ToolEdit
        '
        Me.ToolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEdit.Name = "ToolEdit"
        Me.ToolEdit.Size = New System.Drawing.Size(51, 22)
        Me.ToolEdit.Text = "编辑(&E)"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolRollback
        '
        Me.ToolRollback.Image = CType(resources.GetObject("ToolRollback.Image"), System.Drawing.Image)
        Me.ToolRollback.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolRollback.Name = "ToolRollback"
        Me.ToolRollback.Size = New System.Drawing.Size(67, 22)
        Me.ToolRollback.Text = "返回(&C)"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolDownLoad
        '
        Me.ToolDownLoad.Image = CType(resources.GetObject("ToolDownLoad.Image"), System.Drawing.Image)
        Me.ToolDownLoad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolDownLoad.Name = "ToolDownLoad"
        Me.ToolDownLoad.Size = New System.Drawing.Size(133, 22)
        Me.ToolDownLoad.Text = "ERP员工查询下载(L)"
        Me.ToolDownLoad.ToolTipText = "ERP员工查詢下載"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolSave
        '
        Me.ToolSave.Image = CType(resources.GetObject("ToolSave.Image"), System.Drawing.Image)
        Me.ToolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolSave.Name = "ToolSave"
        Me.ToolSave.Size = New System.Drawing.Size(67, 22)
        Me.ToolSave.Text = "保存(&S)"
        Me.ToolSave.ToolTipText = "保存"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolQuery
        '
        Me.ToolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolQuery.Name = "ToolQuery"
        Me.ToolQuery.Size = New System.Drawing.Size(51, 22)
        Me.ToolQuery.Text = "查询(&Q)"
        '
        'ToolRefresh
        '
        Me.ToolRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolRefresh.Name = "ToolRefresh"
        Me.ToolRefresh.Size = New System.Drawing.Size(51, 22)
        Me.ToolRefresh.Text = "刷新(&R)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'TollExit
        '
        Me.TollExit.ImageTransparentColor = System.Drawing.Color.White
        Me.TollExit.Name = "TollExit"
        Me.TollExit.Size = New System.Drawing.Size(51, 22)
        Me.TollExit.Text = "退出(&X)"
        Me.TollExit.ToolTipText = "退出"
        '
        'uxUserGroup
        '
        Me.uxUserGroup.Controls.Add(Me.cboLine)
        Me.uxUserGroup.Controls.Add(Me.cboDept)
        Me.uxUserGroup.Controls.Add(Me.txtUserName)
        Me.uxUserGroup.Controls.Add(Me.txtUserId)
        Me.uxUserGroup.Controls.Add(Me.uxUserLine)
        Me.uxUserGroup.Controls.Add(Me.lblUserDept)
        Me.uxUserGroup.Controls.Add(Me.lblUserName)
        Me.uxUserGroup.Controls.Add(Me.lblUserId)
        Me.uxUserGroup.Location = New System.Drawing.Point(1, 33)
        Me.uxUserGroup.Name = "uxUserGroup"
        Me.uxUserGroup.Size = New System.Drawing.Size(966, 51)
        Me.uxUserGroup.TabIndex = 16
        Me.uxUserGroup.TabStop = False
        Me.uxUserGroup.Text = "员工维护"
        '
        'cboLine
        '
        Me.cboLine.FormattingEnabled = True
        Me.cboLine.Location = New System.Drawing.Point(720, 20)
        Me.cboLine.Name = "cboLine"
        Me.cboLine.Size = New System.Drawing.Size(147, 20)
        Me.cboLine.TabIndex = 7
        '
        'cboDept
        '
        Me.cboDept.FormattingEnabled = True
        Me.cboDept.Location = New System.Drawing.Point(481, 19)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(165, 20)
        Me.cboDept.TabIndex = 6
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(287, 19)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(127, 21)
        Me.txtUserName.TabIndex = 5
        '
        'txtUserId
        '
        Me.txtUserId.Location = New System.Drawing.Point(69, 18)
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.Size = New System.Drawing.Size(127, 21)
        Me.txtUserId.TabIndex = 4
        '
        'uxUserLine
        '
        Me.uxUserLine.AutoSize = True
        Me.uxUserLine.Location = New System.Drawing.Point(685, 23)
        Me.uxUserLine.Name = "uxUserLine"
        Me.uxUserLine.Size = New System.Drawing.Size(35, 12)
        Me.uxUserLine.TabIndex = 3
        Me.uxUserLine.Text = "线别:"
        '
        'lblUserDept
        '
        Me.lblUserDept.AutoSize = True
        Me.lblUserDept.Location = New System.Drawing.Point(448, 22)
        Me.lblUserDept.Name = "lblUserDept"
        Me.lblUserDept.Size = New System.Drawing.Size(35, 12)
        Me.lblUserDept.TabIndex = 2
        Me.lblUserDept.Text = "部门:"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(230, 22)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(59, 12)
        Me.lblUserName.TabIndex = 1
        Me.lblUserName.Text = "员工姓名:"
        '
        'lblUserId
        '
        Me.lblUserId.AutoSize = True
        Me.lblUserId.Location = New System.Drawing.Point(12, 21)
        Me.lblUserId.Name = "lblUserId"
        Me.lblUserId.Size = New System.Drawing.Size(59, 12)
        Me.lblUserId.TabIndex = 0
        Me.lblUserId.Text = "员工工号:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblMsg)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtUserIdLoad)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.dgvUserInfo)
        Me.GroupBox2.Controls.Add(Me.cboLineLoad)
        Me.GroupBox2.Controls.Add(Me.cboDeptLoad)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(1, 90)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(966, 408)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "员工下载"
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(685, 23)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(0, 12)
        Me.lblMsg.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(466, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "员工工号:"
        '
        'txtUserIdLoad
        '
        Me.txtUserIdLoad.Location = New System.Drawing.Point(529, 18)
        Me.txtUserIdLoad.Name = "txtUserIdLoad"
        Me.txtUserIdLoad.Size = New System.Drawing.Size(139, 21)
        Me.txtUserIdLoad.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(456, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 12)
        Me.Label3.TabIndex = 13
        '
        'dgvUserInfo
        '
        Me.dgvUserInfo.AllowUserToAddRows = False
        Me.dgvUserInfo.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgvUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUserInfo.Location = New System.Drawing.Point(7, 52)
        Me.dgvUserInfo.Name = "dgvUserInfo"
        Me.dgvUserInfo.ReadOnly = True
        Me.dgvUserInfo.RowTemplate.Height = 23
        Me.dgvUserInfo.Size = New System.Drawing.Size(953, 350)
        Me.dgvUserInfo.TabIndex = 12
        '
        'cboLineLoad
        '
        Me.cboLineLoad.FormattingEnabled = True
        Me.cboLineLoad.Location = New System.Drawing.Point(280, 21)
        Me.cboLineLoad.Name = "cboLineLoad"
        Me.cboLineLoad.Size = New System.Drawing.Size(147, 20)
        Me.cboLineLoad.TabIndex = 11
        '
        'cboDeptLoad
        '
        Me.cboDeptLoad.FormattingEnabled = True
        Me.cboDeptLoad.Location = New System.Drawing.Point(41, 20)
        Me.cboDeptLoad.Name = "cboDeptLoad"
        Me.cboDeptLoad.Size = New System.Drawing.Size(165, 20)
        Me.cboDeptLoad.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(245, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "线别:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "部门:"
        '
        'PagerPaging
        '
        Me.PagerPaging.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.PagerPaging.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PagerPaging.Location = New System.Drawing.Point(132, 500)
        Me.PagerPaging.Name = "PagerPaging"
        PageDataGridPager1.DataGrid = Nothing
        PageDataGridPager1.PageSize = 10
        PageDataGridPager1.PageSizes = New Integer() {10, 20, 50, 100, 500, 1000}
        PageDataGridPager1.Sort = "创建时间 DESC,部门编号 DESC"
        PageDataGridPager1.x7155dda3b72cd3e5 = 1
        PageDataGridPager1.x744ea7fab69a66e7 = 0
        Me.PagerPaging.PagerGrid = PageDataGridPager1
        Me.PagerPaging.Size = New System.Drawing.Size(767, 29)
        Me.PagerPaging.TabIndex = 18
        '
        'lblRecord
        '
        Me.lblRecord.AutoSize = True
        Me.lblRecord.ForeColor = System.Drawing.Color.Red
        Me.lblRecord.Location = New System.Drawing.Point(13, 512)
        Me.lblRecord.Name = "lblRecord"
        Me.lblRecord.Size = New System.Drawing.Size(35, 12)
        Me.lblRecord.TabIndex = 19
        Me.lblRecord.Text = "共0笔"
        Me.lblRecord.Visible = False
        '
        'FrmUserMaintaince
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(965, 533)
        Me.Controls.Add(Me.lblRecord)
        Me.Controls.Add(Me.PagerPaging)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.uxUserGroup)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmUserMaintaince"
        Me.Text = "员工信息维护"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.uxUserGroup.ResumeLayout(False)
        Me.uxUserGroup.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvUserInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolRollback As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolDownLoad As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TollExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents uxUserGroup As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblUserDept As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblUserId As System.Windows.Forms.Label
    Friend WithEvents txtUserId As System.Windows.Forms.TextBox
    Friend WithEvents uxUserLine As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents cboDept As System.Windows.Forms.ComboBox
    Friend WithEvents cboLine As System.Windows.Forms.ComboBox
    Friend WithEvents dgvUserInfo As System.Windows.Forms.DataGridView
    Friend WithEvents cboLineLoad As System.Windows.Forms.ComboBox
    Friend WithEvents cboDeptLoad As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PagerPaging As Pager.PagerPaging
    Friend WithEvents lblRecord As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUserIdLoad As System.Windows.Forms.TextBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
End Class
