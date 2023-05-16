<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRYPONumber
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRYPONumber))
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolImport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.dataGrid = New System.Windows.Forms.DataGridView()
        Me.RYShippOrder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RYPartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ZeroNineBarCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtHWPONumber = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsbLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lkFile = New System.Windows.Forms.LinkLabel()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toolStrip1.SuspendLayout()
        CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolStrip1
        '
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.toolQuery, Me.ToolStripSeparator2, Me.toolImport, Me.ToolStripSeparator3, Me.toolDelete, Me.ToolStripSeparator4, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1046, 26)
        Me.toolStrip1.TabIndex = 129
        Me.toolStrip1.TabStop = True
        Me.toolStrip1.Text = "toolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 26)
        '
        'toolQuery
        '
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(76, 23)
        Me.toolQuery.Text = "查  询(&F)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 26)
        '
        'toolImport
        '
        Me.toolImport.Image = CType(resources.GetObject("toolImport.Image"), System.Drawing.Image)
        Me.toolImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImport.Name = "toolImport"
        Me.toolImport.Size = New System.Drawing.Size(64, 23)
        Me.toolImport.Text = "汇   入"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 26)
        '
        'toolDelete
        '
        Me.toolDelete.Image = CType(resources.GetObject("toolDelete.Image"), System.Drawing.Image)
        Me.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolDelete.Name = "toolDelete"
        Me.toolDelete.Size = New System.Drawing.Size(73, 23)
        Me.toolDelete.Tag = "删 除"
        Me.toolDelete.Text = "删 除(&D)"
        Me.toolDelete.ToolTipText = "刪除"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 26)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(72, 23)
        Me.toolExit.Text = "退 出(&X)"
        '
        'dataGrid
        '
        Me.dataGrid.AllowUserToAddRows = False
        Me.dataGrid.AllowUserToDeleteRows = False
        Me.dataGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RYShippOrder, Me.RYPartID, Me.TotalQty, Me.Qty, Me.ZeroNineBarCode, Me.UserID, Me.Intime})
        Me.dataGrid.Location = New System.Drawing.Point(0, 0)
        Me.dataGrid.Name = "dataGrid"
        Me.dataGrid.ReadOnly = True
        Me.dataGrid.RowTemplate.Height = 23
        Me.dataGrid.Size = New System.Drawing.Size(1046, 344)
        Me.dataGrid.TabIndex = 131
        '
        'RYShippOrder
        '
        Me.RYShippOrder.HeaderText = "荣耀PO单号"
        Me.RYShippOrder.Name = "RYShippOrder"
        Me.RYShippOrder.ReadOnly = True
        '
        'RYPartID
        '
        Me.RYPartID.HeaderText = "荣耀料号"
        Me.RYPartID.Name = "RYPartID"
        Me.RYPartID.ReadOnly = True
        '
        'TotalQty
        '
        Me.TotalQty.HeaderText = "荣耀单总数量"
        Me.TotalQty.Name = "TotalQty"
        Me.TotalQty.ReadOnly = True
        '
        'Qty
        '
        Me.Qty.HeaderText = "箱数"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        '
        'ZeroNineBarCode
        '
        Me.ZeroNineBarCode.HeaderText = "09条码"
        Me.ZeroNineBarCode.Name = "ZeroNineBarCode"
        Me.ZeroNineBarCode.ReadOnly = True
        '
        'UserID
        '
        Me.UserID.HeaderText = "导入用户"
        Me.UserID.Name = "UserID"
        Me.UserID.ReadOnly = True
        '
        'Intime
        '
        Me.Intime.HeaderText = "导入时间"
        Me.Intime.Name = "Intime"
        Me.Intime.ReadOnly = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 26)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1MinSize = 40
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.StatusStrip1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dataGrid)
        Me.SplitContainer1.Size = New System.Drawing.Size(1046, 415)
        Me.SplitContainer1.SplitterDistance = 42
        Me.SplitContainer1.TabIndex = 132
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtHWPONumber)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1046, 42)
        Me.GroupBox1.TabIndex = 130
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 12)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "RY.PO单号："
        '
        'txtHWPONumber
        '
        Me.txtHWPONumber.AcceptsReturn = True
        Me.txtHWPONumber.Location = New System.Drawing.Point(101, 13)
        Me.txtHWPONumber.MaxLength = 20
        Me.txtHWPONumber.Name = "txtHWPONumber"
        Me.txtHWPONumber.Size = New System.Drawing.Size(146, 21)
        Me.txtHWPONumber.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 347)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1046, 22)
        Me.StatusStrip1.TabIndex = 132
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsbLabel1
        '
        Me.tsbLabel1.Name = "tsbLabel1"
        Me.tsbLabel1.Size = New System.Drawing.Size(32, 17)
        Me.tsbLabel1.Text = "行数"
        '
        'lkFile
        '
        Me.lkFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lkFile.AutoSize = True
        Me.lkFile.Location = New System.Drawing.Point(796, 32)
        Me.lkFile.Name = "lkFile"
        Me.lkFile.Size = New System.Drawing.Size(77, 12)
        Me.lkFile.TabIndex = 240
        Me.lkFile.TabStop = True
        Me.lkFile.Text = "查看导入格式"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "HWPO单号"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "HW箱号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 150
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "华为料号"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "华为单总数量"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "华为箱数量"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'FrmRYPONumber
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1046, 441)
        Me.Controls.Add(Me.lkFile)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "FrmRYPONumber"
        Me.Text = "FrmRYPONumber"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolImport As System.Windows.Forms.ToolStripButton
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lkFile As System.Windows.Forms.LinkLabel
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsbLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents toolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtHWPONumber As Windows.Forms.TextBox
    Friend WithEvents RYShippOrder As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RYPartID As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalQty As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ZeroNineBarCode As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserID As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Intime As Windows.Forms.DataGridViewTextBoxColumn
End Class
