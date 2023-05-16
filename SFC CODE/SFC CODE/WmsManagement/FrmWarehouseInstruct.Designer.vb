<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWarehouseInstruct
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWarehouseInstruct))
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImport = New System.Windows.Forms.ToolStripButton()
        Me.toolGetDeliver = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbInstructPrint = New System.Windows.Forms.ToolStripButton()
        Me.toolCargoPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.dtpDeliverDate = New System.Windows.Forms.DateTimePicker()
        Me.txtOutwhid = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.splitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.dgvWHsInstruct = New System.Windows.Forms.DataGridView()
        Me.Outwhid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvWHsDeliver = New System.Windows.Forms.DataGridView()
        Me.CarType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProNo2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unit2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lkFile = New System.Windows.Forms.LinkLabel()
        Me.ToolBt.SuspendLayout()
        Me.splitContainer2.Panel1.SuspendLayout()
        Me.splitContainer2.Panel2.SuspendLayout()
        Me.splitContainer2.SuspendLayout()
        CType(Me.dgvWHsInstruct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvWHsDeliver, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator7, Me.toolQuery, Me.toolStripSeparator1, Me.btnImport, Me.toolGetDeliver, Me.ToolStripSeparator4, Me.tsbInstructPrint, Me.toolCargoPrint, Me.ToolStripSeparator5, Me.toolDelete, Me.ToolStripSeparator2, Me.btnExit, Me.ToolStripSeparator3})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1136, 30)
        Me.ToolBt.TabIndex = 137
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 30)
        '
        'toolQuery
        '
        Me.toolQuery.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(95, 27)
        Me.toolQuery.Text = "查  询(&F)"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 30)
        '
        'btnImport
        '
        Me.btnImport.Image = CType(resources.GetObject("btnImport.Image"), System.Drawing.Image)
        Me.btnImport.ImageTransparentColor = System.Drawing.Color.White
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(141, 27)
        Me.btnImport.Text = "导入出货清单(&I)"
        Me.btnImport.ToolTipText = "导入出货清单"
        '
        'toolGetDeliver
        '
        Me.toolGetDeliver.ForeColor = System.Drawing.Color.Black
        Me.toolGetDeliver.Image = CType(resources.GetObject("toolGetDeliver.Image"), System.Drawing.Image)
        Me.toolGetDeliver.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolGetDeliver.Name = "toolGetDeliver"
        Me.toolGetDeliver.Size = New System.Drawing.Size(149, 27)
        Me.toolGetDeliver.Tag = "NO"
        Me.toolGetDeliver.Text = "生成送货清单(&O)"
        Me.toolGetDeliver.ToolTipText = "生成出货指示单(&O)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 30)
        '
        'tsbInstructPrint
        '
        Me.tsbInstructPrint.Image = CType(resources.GetObject("tsbInstructPrint.Image"), System.Drawing.Image)
        Me.tsbInstructPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbInstructPrint.Name = "tsbInstructPrint"
        Me.tsbInstructPrint.Size = New System.Drawing.Size(162, 27)
        Me.tsbInstructPrint.Tag = "NO"
        Me.tsbInstructPrint.Text = "导出出货指示单(&P)"
        '
        'toolCargoPrint
        '
        Me.toolCargoPrint.Image = CType(resources.GetObject("toolCargoPrint.Image"), System.Drawing.Image)
        Me.toolCargoPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCargoPrint.Name = "toolCargoPrint"
        Me.toolCargoPrint.Size = New System.Drawing.Size(145, 27)
        Me.toolCargoPrint.Tag = "NO"
        Me.toolCargoPrint.Text = "导出送货清单(&S)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 30)
        '
        'toolDelete
        '
        Me.toolDelete.Image = CType(resources.GetObject("toolDelete.Image"), System.Drawing.Image)
        Me.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolDelete.Name = "toolDelete"
        Me.toolDelete.Size = New System.Drawing.Size(142, 27)
        Me.toolDelete.Text = "删除出货指示单"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 30)
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.White
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(87, 27)
        Me.btnExit.Text = "退 出(&X)"
        Me.btnExit.ToolTipText = "退出"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 30)
        '
        'dtpDeliverDate
        '
        Me.dtpDeliverDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpDeliverDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDeliverDate.Location = New System.Drawing.Point(370, 34)
        Me.dtpDeliverDate.Name = "dtpDeliverDate"
        Me.dtpDeliverDate.Size = New System.Drawing.Size(148, 21)
        Me.dtpDeliverDate.TabIndex = 146
        '
        'txtOutwhid
        '
        Me.txtOutwhid.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtOutwhid.Location = New System.Drawing.Point(640, 33)
        Me.txtOutwhid.Name = "txtOutwhid"
        Me.txtOutwhid.Size = New System.Drawing.Size(188, 26)
        Me.txtOutwhid.TabIndex = 141
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(577, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 143
        Me.Label3.Text = "出货单号："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(299, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 144
        Me.Label2.Text = "送货日期："
        '
        'txtProNo
        '
        Me.txtProNo.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtProNo.Location = New System.Drawing.Point(83, 33)
        Me.txtProNo.Name = "txtProNo"
        Me.txtProNo.Size = New System.Drawing.Size(205, 26)
        Me.txtProNo.TabIndex = 142
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 145
        Me.Label1.Text = "线束型号："
        '
        'splitContainer2
        '
        Me.splitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitContainer2.Location = New System.Drawing.Point(2, 65)
        Me.splitContainer2.Name = "splitContainer2"
        '
        'splitContainer2.Panel1
        '
        Me.splitContainer2.Panel1.Controls.Add(Me.dgvWHsInstruct)
        '
        'splitContainer2.Panel2
        '
        Me.splitContainer2.Panel2.Controls.Add(Me.dgvWHsDeliver)
        Me.splitContainer2.Size = New System.Drawing.Size(1134, 337)
        Me.splitContainer2.SplitterDistance = 446
        Me.splitContainer2.TabIndex = 147
        '
        'dgvWHsInstruct
        '
        Me.dgvWHsInstruct.AllowUserToAddRows = False
        Me.dgvWHsInstruct.AllowUserToDeleteRows = False
        Me.dgvWHsInstruct.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvWHsInstruct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWHsInstruct.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Outwhid, Me.ProNo, Me.Qty})
        Me.dgvWHsInstruct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvWHsInstruct.Location = New System.Drawing.Point(0, 0)
        Me.dgvWHsInstruct.MultiSelect = False
        Me.dgvWHsInstruct.Name = "dgvWHsInstruct"
        Me.dgvWHsInstruct.ReadOnly = True
        Me.dgvWHsInstruct.RowTemplate.Height = 23
        Me.dgvWHsInstruct.Size = New System.Drawing.Size(446, 337)
        Me.dgvWHsInstruct.TabIndex = 157
        '
        'Outwhid
        '
        Me.Outwhid.DataPropertyName = "Outwhid"
        Me.Outwhid.HeaderText = "出货单号"
        Me.Outwhid.Name = "Outwhid"
        Me.Outwhid.ReadOnly = True
        Me.Outwhid.Width = 150
        '
        'ProNo
        '
        Me.ProNo.DataPropertyName = "ProNo"
        Me.ProNo.FillWeight = 110.0!
        Me.ProNo.HeaderText = "线束型号"
        Me.ProNo.Name = "ProNo"
        Me.ProNo.ReadOnly = True
        Me.ProNo.Width = 120
        '
        'Qty
        '
        Me.Qty.DataPropertyName = "Qty"
        Me.Qty.FillWeight = 80.0!
        Me.Qty.HeaderText = "数量"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        Me.Qty.Width = 80
        '
        'dgvWHsDeliver
        '
        Me.dgvWHsDeliver.AllowUserToAddRows = False
        Me.dgvWHsDeliver.AllowUserToDeleteRows = False
        Me.dgvWHsDeliver.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvWHsDeliver.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWHsDeliver.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CarType, Me.LineName, Me.ProNo2, Me.Code, Me.Unit2, Me.Qty2, Me.LotNo})
        Me.dgvWHsDeliver.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvWHsDeliver.Location = New System.Drawing.Point(0, 0)
        Me.dgvWHsDeliver.Name = "dgvWHsDeliver"
        Me.dgvWHsDeliver.ReadOnly = True
        Me.dgvWHsDeliver.RowHeadersVisible = False
        Me.dgvWHsDeliver.RowTemplate.Height = 23
        Me.dgvWHsDeliver.Size = New System.Drawing.Size(684, 337)
        Me.dgvWHsDeliver.TabIndex = 157
        '
        'CarType
        '
        Me.CarType.DataPropertyName = "CarType"
        Me.CarType.HeaderText = "车型"
        Me.CarType.Name = "CarType"
        Me.CarType.ReadOnly = True
        Me.CarType.Width = 70
        '
        'LineName
        '
        Me.LineName.DataPropertyName = "LineName"
        Me.LineName.HeaderText = "线束名称"
        Me.LineName.Name = "LineName"
        Me.LineName.ReadOnly = True
        Me.LineName.Width = 90
        '
        'ProNo2
        '
        Me.ProNo2.DataPropertyName = "ProNo"
        Me.ProNo2.HeaderText = "线束型号"
        Me.ProNo2.Name = "ProNo2"
        Me.ProNo2.ReadOnly = True
        Me.ProNo2.Width = 90
        '
        'Code
        '
        Me.Code.DataPropertyName = "Code"
        Me.Code.HeaderText = "简码"
        Me.Code.Name = "Code"
        Me.Code.ReadOnly = True
        Me.Code.Width = 60
        '
        'Unit2
        '
        Me.Unit2.DataPropertyName = "Unit"
        Me.Unit2.HeaderText = "单位"
        Me.Unit2.Name = "Unit2"
        Me.Unit2.ReadOnly = True
        Me.Unit2.Width = 60
        '
        'Qty2
        '
        Me.Qty2.DataPropertyName = "Qty"
        Me.Qty2.HeaderText = "数量"
        Me.Qty2.Name = "Qty2"
        Me.Qty2.ReadOnly = True
        Me.Qty2.Width = 80
        '
        'LotNo
        '
        Me.LotNo.DataPropertyName = "LotNo"
        Me.LotNo.HeaderText = "批次"
        Me.LotNo.Name = "LotNo"
        Me.LotNo.ReadOnly = True
        '
        'lkFile
        '
        Me.lkFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lkFile.AutoSize = True
        Me.lkFile.Location = New System.Drawing.Point(993, 9)
        Me.lkFile.Name = "lkFile"
        Me.lkFile.Size = New System.Drawing.Size(77, 12)
        Me.lkFile.TabIndex = 148
        Me.lkFile.TabStop = True
        Me.lkFile.Text = "查看导入格式"
        '
        'FrmWarehouseInstruct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1136, 402)
        Me.Controls.Add(Me.lkFile)
        Me.Controls.Add(Me.splitContainer2)
        Me.Controls.Add(Me.dtpDeliverDate)
        Me.Controls.Add(Me.txtOutwhid)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtProNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmWarehouseInstruct"
        Me.Text = "出货指示单生成送货单"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.splitContainer2.Panel1.ResumeLayout(False)
        Me.splitContainer2.Panel2.ResumeLayout(False)
        Me.splitContainer2.ResumeLayout(False)
        CType(Me.dgvWHsInstruct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvWHsDeliver, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbInstructPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCargoPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dtpDeliverDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtOutwhid As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents splitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvWHsInstruct As System.Windows.Forms.DataGridView
    Friend WithEvents Outwhid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvWHsDeliver As System.Windows.Forms.DataGridView
    Friend WithEvents WireType2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents toolGetDeliver As System.Windows.Forms.ToolStripButton
    Friend WithEvents CarType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProNo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unit2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lkFile As System.Windows.Forms.LinkLabel
    Friend WithEvents toolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
End Class
