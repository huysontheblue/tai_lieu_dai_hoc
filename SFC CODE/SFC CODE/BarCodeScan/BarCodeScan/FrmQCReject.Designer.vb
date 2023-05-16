<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQCReject
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmQCReject))
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAccepted = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSelect = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolScrap = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtPartNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMoid = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCid = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvMain = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dgvDetail = New System.Windows.Forms.DataGridView()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbCheckQty = New System.Windows.Forms.Label()
        Me.lbDefectQty = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lbNgQty = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbOKQty = New System.Windows.Forms.Label()
        Me.lbCount = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSelectOk = New System.Windows.Forms.Button()
        Me.cbbReStationId = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolBt.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btnAccepted, Me.ToolStripSeparator2, Me.btnSelect, Me.ToolStripSeparator3, Me.ToolStripSeparator4, Me.toolScrap, Me.btnSearch, Me.ToolStripSeparator7, Me.btnExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(829, 23)
        Me.ToolBt.TabIndex = 48
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'btnAccepted
        '
        Me.btnAccepted.Image = Global.BarCodeScan.My.Resources.Resources.Tick
        Me.btnAccepted.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAccepted.Name = "btnAccepted"
        Me.btnAccepted.Size = New System.Drawing.Size(70, 20)
        Me.btnAccepted.Tag = "特采"
        Me.btnAccepted.Text = "特采(&N)"
        Me.btnAccepted.ToolTipText = "新增批号"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'btnSelect
        '
        Me.btnSelect.Image = CType(resources.GetObject("btnSelect.Image"), System.Drawing.Image)
        Me.btnSelect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(52, 20)
        Me.btnSelect.Text = "挑选"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'toolScrap
        '
        Me.toolScrap.Image = CType(resources.GetObject("toolScrap.Image"), System.Drawing.Image)
        Me.toolScrap.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolScrap.Name = "toolScrap"
        Me.toolScrap.Size = New System.Drawing.Size(52, 20)
        Me.toolScrap.Text = "报废"
        '
        'btnSearch
        '
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(70, 20)
        Me.btnSearch.Text = "查 找(&F)"
        Me.btnSearch.ToolTipText = "查找"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 23)
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.White
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 20)
        Me.btnExit.Text = "退 出(&X)"
        Me.btnExit.ToolTipText = "退出"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.txtPartNo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtMoid)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtCid)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(829, 62)
        Me.Panel1.TabIndex = 49
        '
        'txtPartNo
        '
        Me.txtPartNo.Location = New System.Drawing.Point(531, 20)
        Me.txtPartNo.Name = "txtPartNo"
        Me.txtPartNo.Size = New System.Drawing.Size(127, 21)
        Me.txtPartNo.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(470, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "料件编号："
        '
        'txtMoid
        '
        Me.txtMoid.Location = New System.Drawing.Point(313, 20)
        Me.txtMoid.Name = "txtMoid"
        Me.txtMoid.Size = New System.Drawing.Size(127, 21)
        Me.txtMoid.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(253, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "工单编号："
        '
        'txtCid
        '
        Me.txtCid.Location = New System.Drawing.Point(71, 20)
        Me.txtCid.Name = "txtCid"
        Me.txtCid.Size = New System.Drawing.Size(127, 21)
        Me.txtCid.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "批次号："
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvMain)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 85)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(829, 149)
        Me.Panel2.TabIndex = 50
        '
        'dgvMain
        '
        Me.dgvMain.AllowUserToAddRows = False
        Me.dgvMain.AllowUserToDeleteRows = False
        Me.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMain.Location = New System.Drawing.Point(0, 0)
        Me.dgvMain.Name = "dgvMain"
        Me.dgvMain.ReadOnly = True
        Me.dgvMain.RowHeadersVisible = False
        Me.dgvMain.RowTemplate.Height = 23
        Me.dgvMain.Size = New System.Drawing.Size(829, 149)
        Me.dgvMain.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "CId"
        Me.Column1.HeaderText = "批次号"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 180
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Moid"
        Me.Column2.HeaderText = "工单编号"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "PartNo"
        Me.Column3.HeaderText = "料件编码"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "CreateUserId"
        Me.Column4.HeaderText = "操作人"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column5.DataPropertyName = "CreateTime"
        Me.Column5.HeaderText = "操作时间"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.dgvDetail)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 234)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(829, 235)
        Me.Panel3.TabIndex = 51
        '
        'dgvDetail
        '
        Me.dgvDetail.AllowUserToAddRows = False
        Me.dgvDetail.AllowUserToDeleteRows = False
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Column7, Me.DataGridViewTextBoxColumn3, Me.Column6})
        Me.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetail.Location = New System.Drawing.Point(200, 0)
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.RowHeadersVisible = False
        Me.dgvDetail.RowTemplate.Height = 23
        Me.dgvDetail.Size = New System.Drawing.Size(629, 208)
        Me.dgvDetail.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.Control
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.lbCheckQty)
        Me.Panel5.Controls.Add(Me.lbDefectQty)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Controls.Add(Me.lbNgQty)
        Me.Panel5.Controls.Add(Me.Label13)
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.lbOKQty)
        Me.Panel5.Controls.Add(Me.lbCount)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(200, 208)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(629, 27)
        Me.Panel5.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(137, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "批次数："
        '
        'lbCheckQty
        '
        Me.lbCheckQty.AutoSize = True
        Me.lbCheckQty.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbCheckQty.ForeColor = System.Drawing.Color.Black
        Me.lbCheckQty.Location = New System.Drawing.Point(196, 7)
        Me.lbCheckQty.Name = "lbCheckQty"
        Me.lbCheckQty.Size = New System.Drawing.Size(16, 16)
        Me.lbCheckQty.TabIndex = 15
        Me.lbCheckQty.Text = "0"
        '
        'lbDefectQty
        '
        Me.lbDefectQty.AutoSize = True
        Me.lbDefectQty.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbDefectQty.ForeColor = System.Drawing.Color.Blue
        Me.lbDefectQty.Location = New System.Drawing.Point(572, 6)
        Me.lbDefectQty.Name = "lbDefectQty"
        Me.lbDefectQty.Size = New System.Drawing.Size(48, 16)
        Me.lbDefectQty.TabIndex = 13
        Me.lbDefectQty.Text = "0/0/0"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(468, 8)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 12)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "主缺/次缺/重缺："
        '
        'lbNgQty
        '
        Me.lbNgQty.AutoSize = True
        Me.lbNgQty.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbNgQty.ForeColor = System.Drawing.Color.Red
        Me.lbNgQty.Location = New System.Drawing.Point(418, 6)
        Me.lbNgQty.Name = "lbNgQty"
        Me.lbNgQty.Size = New System.Drawing.Size(16, 16)
        Me.lbNgQty.TabIndex = 11
        Me.lbNgQty.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(359, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "不良数："
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(259, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 12)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "良品数："
        '
        'lbOKQty
        '
        Me.lbOKQty.AutoSize = True
        Me.lbOKQty.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbOKQty.ForeColor = System.Drawing.Color.Blue
        Me.lbOKQty.Location = New System.Drawing.Point(318, 7)
        Me.lbOKQty.Name = "lbOKQty"
        Me.lbOKQty.Size = New System.Drawing.Size(16, 16)
        Me.lbOKQty.TabIndex = 9
        Me.lbOKQty.Text = "0"
        '
        'lbCount
        '
        Me.lbCount.AutoSize = True
        Me.lbCount.ForeColor = System.Drawing.Color.Blue
        Me.lbCount.Location = New System.Drawing.Point(71, 8)
        Me.lbCount.Name = "lbCount"
        Me.lbCount.Size = New System.Drawing.Size(0, 12)
        Me.lbCount.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "记录笔数:"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Control
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.btnSelectOk)
        Me.Panel4.Controls.Add(Me.cbbReStationId)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(200, 235)
        Me.Panel4.TabIndex = 1
        '
        'btnSelectOk
        '
        Me.btnSelectOk.Enabled = False
        Me.btnSelectOk.Location = New System.Drawing.Point(14, 91)
        Me.btnSelectOk.Name = "btnSelectOk"
        Me.btnSelectOk.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectOk.TabIndex = 2
        Me.btnSelectOk.Text = "确定挑选"
        Me.btnSelectOk.UseVisualStyleBackColor = True
        '
        'cbbReStationId
        '
        Me.cbbReStationId.Enabled = False
        Me.cbbReStationId.FormattingEnabled = True
        Me.cbbReStationId.Location = New System.Drawing.Point(14, 47)
        Me.cbbReStationId.Name = "cbbReStationId"
        Me.cbbReStationId.Size = New System.Drawing.Size(166, 20)
        Me.cbbReStationId.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(149, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "返回工站：（仅挑选可用）"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FalseValue = "False"
        Me.DataGridViewTextBoxColumn1.HeaderText = "选择"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn1.TrueValue = "True"
        Me.DataGridViewTextBoxColumn1.Width = 70
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ppid"
        Me.DataGridViewTextBoxColumn2.HeaderText = "产品条码"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 180
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "Cartonid"
        Me.Column7.HeaderText = "箱号"
        Me.Column7.Name = "Column7"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "CreateTime"
        Me.DataGridViewTextBoxColumn3.HeaderText = "拒收时间"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column6.DataPropertyName = "SelStatus"
        Me.Column6.HeaderText = "状态"
        Me.Column6.Name = "Column6"
        '
        'FrmQCReject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 469)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmQCReject"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "品质拒收区"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnAccepted As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSelect As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolScrap As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtPartNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMoid As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents dgvMain As System.Windows.Forms.DataGridView
    Friend WithEvents dgvDetail As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents cbbReStationId As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSelectOk As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lbCount As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbDefectQty As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lbNgQty As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbOKQty As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbCheckQty As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
