<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPartMacAddress
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPartMacAddress))
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewFile = New System.Windows.Forms.ToolStripButton()
        Me.EditFile = New System.Windows.Forms.ToolStripButton()
        Me.Delete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.Save = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.UnDo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.Search = New System.Windows.Forms.ToolStripButton()
        Me.FileRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolImport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.TxtTavcPart = New System.Windows.Forms.TextBox()
        Me.LelTpart = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMacMax = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMacMin = New System.Windows.Forms.TextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkUse = New System.Windows.Forms.CheckBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.dgvMac = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PARTID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MacStartNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MacEndNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsedMaxMac = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalMacCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemainMacCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USEY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USERNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CREATETIME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolBt.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvMac, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.NewFile, Me.EditFile, Me.Delete, Me.ToolStripSeparator5, Me.Save, Me.ToolStripSeparator2, Me.UnDo, Me.ToolStripSeparator6, Me.Search, Me.FileRefresh, Me.ToolStripSeparator7, Me.toolImport, Me.ToolStripSeparator3, Me.ExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(825, 25)
        Me.ToolBt.TabIndex = 131
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'NewFile
        '
        Me.NewFile.Image = CType(resources.GetObject("NewFile.Image"), System.Drawing.Image)
        Me.NewFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewFile.Name = "NewFile"
        Me.NewFile.Size = New System.Drawing.Size(74, 22)
        Me.NewFile.Text = "新 增(&N)"
        Me.NewFile.ToolTipText = "新增"
        '
        'EditFile
        '
        Me.EditFile.Image = CType(resources.GetObject("EditFile.Image"), System.Drawing.Image)
        Me.EditFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditFile.Name = "EditFile"
        Me.EditFile.Size = New System.Drawing.Size(71, 22)
        Me.EditFile.Text = "修 改(&E)"
        '
        'Delete
        '
        Me.Delete.Image = CType(resources.GetObject("Delete.Image"), System.Drawing.Image)
        Me.Delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(69, 22)
        Me.Delete.Text = "作废(&D)"
        Me.Delete.ToolTipText = "刪除"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'Save
        '
        Me.Save.Enabled = False
        Me.Save.Image = CType(resources.GetObject("Save.Image"), System.Drawing.Image)
        Me.Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(71, 22)
        Me.Save.Text = "保 存(&S)"
        Me.Save.ToolTipText = "保存"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'UnDo
        '
        Me.UnDo.Enabled = False
        Me.UnDo.Image = CType(resources.GetObject("UnDo.Image"), System.Drawing.Image)
        Me.UnDo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UnDo.Name = "UnDo"
        Me.UnDo.Size = New System.Drawing.Size(68, 22)
        Me.UnDo.Text = "返回(&C)"
        Me.UnDo.ToolTipText = "返回"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'Search
        '
        Me.Search.Image = CType(resources.GetObject("Search.Image"), System.Drawing.Image)
        Me.Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(70, 22)
        Me.Search.Text = "查 找(&F)"
        Me.Search.ToolTipText = "查找"
        '
        'FileRefresh
        '
        Me.FileRefresh.Image = CType(resources.GetObject("FileRefresh.Image"), System.Drawing.Image)
        Me.FileRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.FileRefresh.Name = "FileRefresh"
        Me.FileRefresh.Size = New System.Drawing.Size(72, 22)
        Me.FileRefresh.Text = "刷 新(&R)"
        Me.FileRefresh.ToolTipText = "刷新"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'toolImport
        '
        Me.toolImport.Image = CType(resources.GetObject("toolImport.Image"), System.Drawing.Image)
        Me.toolImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImport.Name = "toolImport"
        Me.toolImport.Size = New System.Drawing.Size(64, 22)
        Me.toolImport.Text = "汇   出"
        Me.toolImport.ToolTipText = "汇   入(只对工治具)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ExitFrom
        '
        Me.ExitFrom.Image = CType(resources.GetObject("ExitFrom.Image"), System.Drawing.Image)
        Me.ExitFrom.ImageTransparentColor = System.Drawing.Color.White
        Me.ExitFrom.Name = "ExitFrom"
        Me.ExitFrom.Size = New System.Drawing.Size(72, 22)
        Me.ExitFrom.Text = "退 出(&X)"
        Me.ExitFrom.ToolTipText = "退出"
        '
        'TxtTavcPart
        '
        Me.TxtTavcPart.Enabled = False
        Me.TxtTavcPart.Location = New System.Drawing.Point(73, 44)
        Me.TxtTavcPart.Name = "TxtTavcPart"
        Me.TxtTavcPart.Size = New System.Drawing.Size(162, 21)
        Me.TxtTavcPart.TabIndex = 132
        '
        'LelTpart
        '
        Me.LelTpart.AutoSize = True
        Me.LelTpart.Location = New System.Drawing.Point(5, 19)
        Me.LelTpart.Name = "LelTpart"
        Me.LelTpart.Size = New System.Drawing.Size(65, 12)
        Me.LelTpart.TabIndex = 133
        Me.LelTpart.Text = "料件编号："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(254, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "结束值："
        '
        'txtMacMax
        '
        Me.txtMacMax.Enabled = False
        Me.txtMacMax.Location = New System.Drawing.Point(309, 43)
        Me.txtMacMax.Name = "txtMacMax"
        Me.txtMacMax.Size = New System.Drawing.Size(162, 21)
        Me.txtMacMax.TabIndex = 132
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "起始值："
        '
        'txtMacMin
        '
        Me.txtMacMin.Enabled = False
        Me.txtMacMin.Location = New System.Drawing.Point(73, 71)
        Me.txtMacMin.Name = "txtMacMin"
        Me.txtMacMin.Size = New System.Drawing.Size(162, 21)
        Me.txtMacMin.TabIndex = 132
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 28)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkUse)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMacMax)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LelTpart)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblID)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvMac)
        Me.SplitContainer1.Size = New System.Drawing.Size(825, 541)
        Me.SplitContainer1.SplitterDistance = 80
        Me.SplitContainer1.TabIndex = 134
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(242, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "是否生效："
        '
        'chkUse
        '
        Me.chkUse.AutoSize = True
        Me.chkUse.Location = New System.Drawing.Point(309, 17)
        Me.chkUse.Name = "chkUse"
        Me.chkUse.Size = New System.Drawing.Size(15, 14)
        Me.chkUse.TabIndex = 1
        Me.chkUse.UseVisualStyleBackColor = True
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(380, 88)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(0, 12)
        Me.lblID.TabIndex = 0
        Me.lblID.Visible = False
        '
        'dgvMac
        '
        Me.dgvMac.AllowUserToAddRows = False
        Me.dgvMac.BackgroundColor = System.Drawing.Color.White
        Me.dgvMac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMac.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.PARTID, Me.MacStartNo, Me.MacEndNo, Me.UsedMaxMac, Me.TotalMacCount, Me.RemainMacCount, Me.USEY, Me.USERNAME, Me.CREATETIME})
        Me.dgvMac.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMac.Location = New System.Drawing.Point(0, 0)
        Me.dgvMac.Name = "dgvMac"
        Me.dgvMac.RowTemplate.Height = 23
        Me.dgvMac.Size = New System.Drawing.Size(825, 457)
        Me.dgvMac.TabIndex = 0
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'PARTID
        '
        Me.PARTID.HeaderText = "料号"
        Me.PARTID.Name = "PARTID"
        Me.PARTID.ReadOnly = True
        '
        'MacStartNo
        '
        Me.MacStartNo.HeaderText = "起始值"
        Me.MacStartNo.Name = "MacStartNo"
        Me.MacStartNo.ReadOnly = True
        '
        'MacEndNo
        '
        Me.MacEndNo.HeaderText = "结束值"
        Me.MacEndNo.Name = "MacEndNo"
        Me.MacEndNo.ReadOnly = True
        '
        'UsedMaxMac
        '
        Me.UsedMaxMac.HeaderText = "最大MAC"
        Me.UsedMaxMac.Name = "UsedMaxMac"
        Me.UsedMaxMac.ReadOnly = True
        '
        'TotalMacCount
        '
        Me.TotalMacCount.HeaderText = "MAC总数量"
        Me.TotalMacCount.Name = "TotalMacCount"
        '
        'RemainMacCount
        '
        Me.RemainMacCount.HeaderText = "MAC剩余数量"
        Me.RemainMacCount.Name = "RemainMacCount"
        '
        'USEY
        '
        Me.USEY.HeaderText = "是否生效"
        Me.USEY.Name = "USEY"
        Me.USEY.ReadOnly = True
        '
        'USERNAME
        '
        Me.USERNAME.HeaderText = "维护人"
        Me.USERNAME.Name = "USERNAME"
        Me.USERNAME.ReadOnly = True
        '
        'CREATETIME
        '
        Me.CREATETIME.HeaderText = "时间"
        Me.CREATETIME.Name = "CREATETIME"
        Me.CREATETIME.ReadOnly = True
        '
        'FrmPartMacAddress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 499)
        Me.Controls.Add(Me.txtMacMin)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtTavcPart)
        Me.Controls.Add(Me.ToolBt)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmPartMacAddress"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "客户供应MAC地址范围维护"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvMac, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents EditFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents Delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UnDo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents FileRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxtTavcPart As System.Windows.Forms.TextBox
    Friend WithEvents LelTpart As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMacMax As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMacMin As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvMac As System.Windows.Forms.DataGridView
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents chkUse As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PARTID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MacStartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MacEndNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsedMaxMac As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalMacCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemainMacCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USEY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USERNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CREATETIME As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
