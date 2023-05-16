<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWareHouseIn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWareHouseIn))
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtOutwhid = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCarton = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvReturn = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolBasic = New System.Windows.Forms.ToolStripButton()
        Me.toolInDetail = New System.Windows.Forms.ToolStripButton()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.CartonID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WireType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.moid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolBt.SuspendLayout()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        CType(Me.dgvReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolBasic, Me.ToolStripSeparator7, Me.toolInDetail, Me.ToolStripSeparator1, Me.btnExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1113, 23)
        Me.ToolBt.TabIndex = 138
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 23)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.IsSplitterFixed = True
        Me.splitContainer1.Location = New System.Drawing.Point(0, 23)
        Me.splitContainer1.Name = "splitContainer1"
        Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.txtOutwhid)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.splitContainer1.Panel1.Controls.Add(Me.lblResult)
        Me.splitContainer1.Panel1.Controls.Add(Me.lblLocation)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.splitContainer1.Panel1.Controls.Add(Me.txtCarton)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.dgvReturn)
        Me.splitContainer1.Size = New System.Drawing.Size(1113, 374)
        Me.splitContainer1.SplitterDistance = 57
        Me.splitContainer1.TabIndex = 139
        '
        'txtOutwhid
        '
        Me.txtOutwhid.Enabled = False
        Me.txtOutwhid.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtOutwhid.Location = New System.Drawing.Point(804, 9)
        Me.txtOutwhid.Name = "txtOutwhid"
        Me.txtOutwhid.ReadOnly = True
        Me.txtOutwhid.Size = New System.Drawing.Size(151, 26)
        Me.txtOutwhid.TabIndex = 221
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(733, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 222
        Me.Label3.Text = "出货单号："
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.ForeColor = System.Drawing.Color.Green
        Me.lblResult.Location = New System.Drawing.Point(70, 39)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(11, 12)
        Me.lblResult.TabIndex = 220
        Me.lblResult.Text = "-"
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Location = New System.Drawing.Point(590, 16)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(0, 12)
        Me.lblLocation.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(543, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "库位："
        '
        'txtCarton
        '
        Me.txtCarton.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtCarton.Location = New System.Drawing.Point(72, 9)
        Me.txtCarton.Name = "txtCarton"
        Me.txtCarton.Size = New System.Drawing.Size(465, 26)
        Me.txtCarton.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "箱号："
        '
        'dgvReturn
        '
        Me.dgvReturn.AllowUserToAddRows = False
        Me.dgvReturn.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvReturn.ColumnHeadersHeight = 28
        Me.dgvReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvReturn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CartonID, Me.WireType, Me.moid, Me.Qty, Me.Location, Me.UserId, Me.Intime})
        Me.dgvReturn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReturn.Location = New System.Drawing.Point(0, 0)
        Me.dgvReturn.Name = "dgvReturn"
        Me.dgvReturn.ReadOnly = True
        Me.dgvReturn.RowTemplate.Height = 23
        Me.dgvReturn.Size = New System.Drawing.Size(1113, 313)
        Me.dgvReturn.TabIndex = 138
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "CartonID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "箱号"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 120
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "PartId"
        Me.DataGridViewTextBoxColumn2.HeaderText = "料号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 90
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "CarType"
        Me.DataGridViewTextBoxColumn3.HeaderText = "车型"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "LineName"
        Me.DataGridViewTextBoxColumn4.HeaderText = "线束名称"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "WireType"
        Me.DataGridViewTextBoxColumn5.HeaderText = "线束型号"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 70
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Code"
        Me.DataGridViewTextBoxColumn6.HeaderText = "简码"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 70
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Unit"
        Me.DataGridViewTextBoxColumn7.HeaderText = "单位"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 80
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "LotNo"
        Me.DataGridViewTextBoxColumn8.HeaderText = "批次"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 90
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "设变号"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "库存位置"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "用户名"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 70
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "操作时间"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'ToolBasic
        '
        Me.ToolBasic.Image = CType(resources.GetObject("ToolBasic.Image"), System.Drawing.Image)
        Me.ToolBasic.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolBasic.Name = "ToolBasic"
        Me.ToolBasic.Size = New System.Drawing.Size(92, 20)
        Me.ToolBasic.Text = "设定库位(&B)"
        '
        'toolInDetail
        '
        Me.toolInDetail.Image = CType(resources.GetObject("toolInDetail.Image"), System.Drawing.Image)
        Me.toolInDetail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolInDetail.Name = "toolInDetail"
        Me.toolInDetail.Size = New System.Drawing.Size(100, 20)
        Me.toolInDetail.Text = "成品入库明细"
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
        'CartonID
        '
        Me.CartonID.DataPropertyName = "CartonID"
        Me.CartonID.HeaderText = "箱号"
        Me.CartonID.Name = "CartonID"
        Me.CartonID.ReadOnly = True
        Me.CartonID.Width = 300
        '
        'WireType
        '
        Me.WireType.DataPropertyName = "WireType"
        Me.WireType.HeaderText = "料号"
        Me.WireType.Name = "WireType"
        Me.WireType.ReadOnly = True
        Me.WireType.Width = 90
        '
        'moid
        '
        Me.moid.DataPropertyName = "moid"
        Me.moid.HeaderText = "工单号"
        Me.moid.Name = "moid"
        Me.moid.ReadOnly = True
        '
        'Qty
        '
        Me.Qty.DataPropertyName = "Qty"
        Me.Qty.HeaderText = "数量"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        Me.Qty.Width = 80
        '
        'Location
        '
        Me.Location.HeaderText = "库存位置"
        Me.Location.Name = "Location"
        Me.Location.ReadOnly = True
        '
        'UserId
        '
        Me.UserId.HeaderText = "用户名"
        Me.UserId.Name = "UserId"
        Me.UserId.ReadOnly = True
        Me.UserId.Width = 70
        '
        'Intime
        '
        Me.Intime.HeaderText = "操作时间"
        Me.Intime.Name = "Intime"
        Me.Intime.ReadOnly = True
        Me.Intime.Width = 120
        '
        'FrmWareHouseIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1113, 397)
        Me.Controls.Add(Me.splitContainer1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmWareHouseIn"
        Me.Text = "成品入库"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel1.PerformLayout()
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.ResumeLayout(False)
        CType(Me.dgvReturn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCarton As System.Windows.Forms.TextBox
    Friend WithEvents dgvReturn As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents ToolBasic As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents toolInDetail As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtOutwhid As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CartonID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WireType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents moid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Intime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
