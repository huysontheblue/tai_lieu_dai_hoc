<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQueryAppUseStatusDetail
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
        Dim PageDataGridPager2 As Pager.PageDataGridPager = New Pager.PageDataGridPager
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmQueryAppUseStatusDetail))
        Me.dgvResult = New System.Windows.Forms.DataGridView
        Me.dgvSeq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvApId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvApName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvUser = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvUserName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvUseTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PagerPaging = New Pager.PagerPaging
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolExit = New System.Windows.Forms.ToolStripButton
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dgvResultUsers = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvTotalCount = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.dgvResultUse = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtUserId = New System.Windows.Forms.TextBox
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvResultUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvResultUse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvResult
        '
        Me.dgvResult.AllowUserToAddRows = False
        Me.dgvResult.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSeq, Me.dgvApId, Me.dgvApName, Me.dgvUser, Me.dgvUserName, Me.dgvUseTime})
        Me.dgvResult.Location = New System.Drawing.Point(0, 0)
        Me.dgvResult.Name = "dgvResult"
        Me.dgvResult.ReadOnly = True
        Me.dgvResult.RowHeadersVisible = False
        Me.dgvResult.RowTemplate.Height = 23
        Me.dgvResult.Size = New System.Drawing.Size(861, 283)
        Me.dgvResult.TabIndex = 0
        '
        'dgvSeq
        '
        Me.dgvSeq.HeaderText = "序号"
        Me.dgvSeq.Name = "dgvSeq"
        Me.dgvSeq.ReadOnly = True
        '
        'dgvApId
        '
        Me.dgvApId.HeaderText = "APID"
        Me.dgvApId.Name = "dgvApId"
        Me.dgvApId.ReadOnly = True
        '
        'dgvApName
        '
        Me.dgvApName.HeaderText = "程序名称"
        Me.dgvApName.Name = "dgvApName"
        Me.dgvApName.ReadOnly = True
        '
        'dgvUser
        '
        Me.dgvUser.DataPropertyName = "使用者工号"
        Me.dgvUser.HeaderText = "使用者工号"
        Me.dgvUser.Name = "dgvUser"
        Me.dgvUser.ReadOnly = True
        '
        'dgvUserName
        '
        Me.dgvUserName.HeaderText = "使用者姓名"
        Me.dgvUserName.Name = "dgvUserName"
        Me.dgvUserName.ReadOnly = True
        '
        'dgvUseTime
        '
        Me.dgvUseTime.DataPropertyName = "使用时间"
        Me.dgvUseTime.HeaderText = "使用时间"
        Me.dgvUseTime.Name = "dgvUseTime"
        Me.dgvUseTime.ReadOnly = True
        '
        'PagerPaging
        '
        Me.PagerPaging.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.PagerPaging.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PagerPaging.Location = New System.Drawing.Point(33, 367)
        Me.PagerPaging.Name = "PagerPaging"
        PageDataGridPager2.DataGrid = Nothing
        'PageDataGridPager2.PageNumber = 1
        PageDataGridPager2.PageSize = 10
        PageDataGridPager2.PageSizes = New Integer() {10, 20, 50, 100, 500, 1000}
        'PageDataGridPager2.RecordCount = 0
        PageDataGridPager2.Sort = ""
        Me.PagerPaging.PagerGrid = PageDataGridPager2
        Me.PagerPaging.Size = New System.Drawing.Size(767, 29)
        Me.PagerPaging.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator3, Me.ToolExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(869, 24)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 150
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(36, 21)
        Me.ToolStripButton2.Text = "刷新"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 24)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(76, 21)
        Me.ToolStripButton1.Text = "汇出明细"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 24)
        '
        'ToolExit
        '
        Me.ToolExit.Image = CType(resources.GetObject("ToolExit.Image"), System.Drawing.Image)
        Me.ToolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolExit.Name = "ToolExit"
        Me.ToolExit.Size = New System.Drawing.Size(68, 21)
        Me.ToolExit.Text = "退    出"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(0, 56)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(869, 309)
        Me.TabControl1.TabIndex = 151
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvResult)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(861, 283)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "程序使用次数明细"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvResultUsers)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(861, 283)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "程序使用者明细"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvResultUsers
        '
        Me.dgvResultUsers.AllowUserToAddRows = False
        Me.dgvResultUsers.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvResultUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultUsers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.dgvTotalCount})
        Me.dgvResultUsers.Location = New System.Drawing.Point(0, 0)
        Me.dgvResultUsers.Name = "dgvResultUsers"
        Me.dgvResultUsers.RowHeadersVisible = False
        Me.dgvResultUsers.RowTemplate.Height = 23
        Me.dgvResultUsers.Size = New System.Drawing.Size(861, 283)
        Me.dgvResultUsers.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "序号"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "APID"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "程序名称"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "使用者工号"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "使用者姓名"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'dgvTotalCount
        '
        Me.dgvTotalCount.DataPropertyName = "使用次数"
        Me.dgvTotalCount.HeaderText = "使用次数"
        Me.dgvTotalCount.Name = "dgvTotalCount"
        Me.dgvTotalCount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTotalCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvResultUse)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(861, 283)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "程序使用者使用明细"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgvResultUse
        '
        Me.dgvResultUse.AllowUserToAddRows = False
        Me.dgvResultUse.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvResultUse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultUse.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11})
        Me.dgvResultUse.Location = New System.Drawing.Point(0, 0)
        Me.dgvResultUse.Name = "dgvResultUse"
        Me.dgvResultUse.RowHeadersVisible = False
        Me.dgvResultUse.RowTemplate.Height = 23
        Me.dgvResultUse.Size = New System.Drawing.Size(861, 283)
        Me.dgvResultUse.TabIndex = 2
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "序号"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "APID"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "程序姓名"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "使用者工号"
        Me.DataGridViewTextBoxColumn9.HeaderText = "使用者工号"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "使用者姓名"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "使用时间"
        Me.DataGridViewTextBoxColumn11.HeaderText = "使用时间"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 12)
        Me.Label1.TabIndex = 152
        Me.Label1.Text = "使用者编号:"
        '
        'txtUserId
        '
        Me.txtUserId.Location = New System.Drawing.Point(85, 30)
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.Size = New System.Drawing.Size(204, 21)
        Me.txtUserId.TabIndex = 153
        '
        'FrmQueryAppUseStatusDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 402)
        Me.Controls.Add(Me.txtUserId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PagerPaging)
        Me.Name = "FrmQueryAppUseStatusDetail"
        Me.Text = "系统使用状况详情"
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvResultUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvResultUse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvResult As System.Windows.Forms.DataGridView
    Friend WithEvents PagerPaging As Pager.PagerPaging
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvResultUsers As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dgvResultUse As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUserId As System.Windows.Forms.TextBox
    Friend WithEvents dgvSeq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvApId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvApName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvUserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvUseTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvTotalCount As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
