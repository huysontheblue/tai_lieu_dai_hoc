<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWareHouseOut
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWareHouseOut))
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.toolCargoOutDetail = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblNeedQty = New System.Windows.Forms.Label()
        Me.lbNeedPackQty = New System.Windows.Forms.Label()
        Me.lblWaitQty = New System.Windows.Forms.Label()
        Me.lblAlreadyQty = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.txtOutwhid = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCarton = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvWHsOutD = New System.Windows.Forms.DataGridView()
        Me.CartonID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Version = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ToolBt.SuspendLayout()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        CType(Me.dgvWHsOutD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolQuery, Me.toolCargoOutDetail, Me.ToolStripSeparator7, Me.btnExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1019, 23)
        Me.ToolBt.TabIndex = 139
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'toolQuery
        '
        Me.toolQuery.Font = New System.Drawing.Font("微软雅黑", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(85, 20)
        Me.toolQuery.Text = "查  询(&F)"
        '
        'toolCargoOutDetail
        '
        Me.toolCargoOutDetail.Image = CType(resources.GetObject("toolCargoOutDetail.Image"), System.Drawing.Image)
        Me.toolCargoOutDetail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCargoOutDetail.Name = "toolCargoOutDetail"
        Me.toolCargoOutDetail.Size = New System.Drawing.Size(100, 20)
        Me.toolCargoOutDetail.Text = "成品出库明细"
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
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitContainer1.IsSplitterFixed = True
        Me.splitContainer1.Location = New System.Drawing.Point(0, 23)
        Me.splitContainer1.Name = "splitContainer1"
        Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.lblNeedQty)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label12)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.splitContainer1.Panel1.Controls.Add(Me.lbNeedPackQty)
        Me.splitContainer1.Panel1.Controls.Add(Me.lblWaitQty)
        Me.splitContainer1.Panel1.Controls.Add(Me.lblAlreadyQty)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.splitContainer1.Panel1.Controls.Add(Me.lblResult)
        Me.splitContainer1.Panel1.Controls.Add(Me.txtOutwhid)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.splitContainer1.Panel1.Controls.Add(Me.txtCarton)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.dgvWHsOutD)
        Me.splitContainer1.Size = New System.Drawing.Size(1019, 397)
        Me.splitContainer1.SplitterDistance = 100
        Me.splitContainer1.TabIndex = 140
        '
        'lblNeedQty
        '
        Me.lblNeedQty.AutoSize = True
        Me.lblNeedQty.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblNeedQty.ForeColor = System.Drawing.Color.Blue
        Me.lblNeedQty.Location = New System.Drawing.Point(649, 44)
        Me.lblNeedQty.Name = "lblNeedQty"
        Me.lblNeedQty.Size = New System.Drawing.Size(12, 12)
        Me.lblNeedQty.TabIndex = 224
        Me.lblNeedQty.Text = "0"
        '
        'lbNeedPackQty
        '
        Me.lbNeedPackQty.AutoSize = True
        Me.lbNeedPackQty.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbNeedPackQty.ForeColor = System.Drawing.Color.SeaGreen
        Me.lbNeedPackQty.Location = New System.Drawing.Point(853, 44)
        Me.lbNeedPackQty.Name = "lbNeedPackQty"
        Me.lbNeedPackQty.Size = New System.Drawing.Size(12, 12)
        Me.lbNeedPackQty.TabIndex = 224
        Me.lbNeedPackQty.Text = "0"
        Me.lbNeedPackQty.Visible = False
        '
        'lblWaitQty
        '
        Me.lblWaitQty.AutoSize = True
        Me.lblWaitQty.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblWaitQty.ForeColor = System.Drawing.Color.Red
        Me.lblWaitQty.Location = New System.Drawing.Point(649, 70)
        Me.lblWaitQty.Name = "lblWaitQty"
        Me.lblWaitQty.Size = New System.Drawing.Size(12, 12)
        Me.lblWaitQty.TabIndex = 223
        Me.lblWaitQty.Text = "0"
        '
        'lblAlreadyQty
        '
        Me.lblAlreadyQty.AutoSize = True
        Me.lblAlreadyQty.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblAlreadyQty.ForeColor = System.Drawing.Color.Green
        Me.lblAlreadyQty.Location = New System.Drawing.Point(750, 43)
        Me.lblAlreadyQty.Name = "lblAlreadyQty"
        Me.lblAlreadyQty.Size = New System.Drawing.Size(12, 12)
        Me.lblAlreadyQty.TabIndex = 223
        Me.lblAlreadyQty.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(587, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 12)
        Me.Label5.TabIndex = 222
        Me.Label5.Text = "需求数量:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(587, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 12)
        Me.Label4.TabIndex = 221
        Me.Label4.Text = "待出数量:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.SeaGreen
        Me.Label7.Location = New System.Drawing.Point(779, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 12)
        Me.Label7.TabIndex = 222
        Me.Label7.Text = "需求整箱数:"
        Me.Label7.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Green
        Me.Label8.Location = New System.Drawing.Point(688, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 12)
        Me.Label8.TabIndex = 221
        Me.Label8.Text = "已出数量:"
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Font = New System.Drawing.Font("宋体", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblResult.ForeColor = System.Drawing.Color.Green
        Me.lblResult.Location = New System.Drawing.Point(347, 16)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(19, 19)
        Me.lblResult.TabIndex = 220
        Me.lblResult.Text = "-"
        '
        'txtOutwhid
        '
        Me.txtOutwhid.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtOutwhid.Location = New System.Drawing.Point(106, 9)
        Me.txtOutwhid.Name = "txtOutwhid"
        Me.txtOutwhid.Size = New System.Drawing.Size(201, 26)
        Me.txtOutwhid.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(59, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "箱号："
        '
        'txtCarton
        '
        Me.txtCarton.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtCarton.Location = New System.Drawing.Point(106, 55)
        Me.txtCarton.Name = "txtCarton"
        Me.txtCarton.Size = New System.Drawing.Size(458, 26)
        Me.txtCarton.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "出货单号："
        '
        'dgvWHsOutD
        '
        Me.dgvWHsOutD.AllowUserToAddRows = False
        Me.dgvWHsOutD.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvWHsOutD.ColumnHeadersHeight = 28
        Me.dgvWHsOutD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvWHsOutD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CartonID, Me.ProNo, Me.LotNo, Me.Version, Me.Qty, Me.Location, Me.UserId, Me.Intime})
        Me.dgvWHsOutD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvWHsOutD.Location = New System.Drawing.Point(0, 0)
        Me.dgvWHsOutD.Name = "dgvWHsOutD"
        Me.dgvWHsOutD.ReadOnly = True
        Me.dgvWHsOutD.RowTemplate.Height = 23
        Me.dgvWHsOutD.Size = New System.Drawing.Size(1019, 293)
        Me.dgvWHsOutD.TabIndex = 138
        '
        'CartonID
        '
        Me.CartonID.DataPropertyName = "CartonID"
        Me.CartonID.HeaderText = "箱号"
        Me.CartonID.Name = "CartonID"
        Me.CartonID.ReadOnly = True
        Me.CartonID.Width = 300
        '
        'ProNo
        '
        Me.ProNo.DataPropertyName = "ProNo"
        Me.ProNo.HeaderText = "线束型号"
        Me.ProNo.Name = "ProNo"
        Me.ProNo.ReadOnly = True
        Me.ProNo.Width = 90
        '
        'LotNo
        '
        Me.LotNo.DataPropertyName = "LotNo"
        Me.LotNo.HeaderText = "批次"
        Me.LotNo.Name = "LotNo"
        Me.LotNo.ReadOnly = True
        Me.LotNo.Width = 90
        '
        'Version
        '
        Me.Version.DataPropertyName = "Version"
        Me.Version.HeaderText = "设变号"
        Me.Version.Name = "Version"
        Me.Version.ReadOnly = True
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
        Me.Location.DataPropertyName = "Location"
        Me.Location.HeaderText = "库存位置"
        Me.Location.Name = "Location"
        Me.Location.ReadOnly = True
        '
        'UserId
        '
        Me.UserId.DataPropertyName = "UserId"
        Me.UserId.HeaderText = "用户名"
        Me.UserId.Name = "UserId"
        Me.UserId.ReadOnly = True
        Me.UserId.Width = 70
        '
        'Intime
        '
        Me.Intime.DataPropertyName = "Intime"
        Me.Intime.HeaderText = "操作时间"
        Me.Intime.Name = "Intime"
        Me.Intime.ReadOnly = True
        Me.Intime.Width = 120
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SeaGreen
        Me.Label2.Location = New System.Drawing.Point(779, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 222
        Me.Label2.Text = "已出整箱数:"
        Me.Label2.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.SeaGreen
        Me.Label6.Location = New System.Drawing.Point(853, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 12)
        Me.Label6.TabIndex = 224
        Me.Label6.Text = "0"
        Me.Label6.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.SeaGreen
        Me.Label9.Location = New System.Drawing.Point(871, 43)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 12)
        Me.Label9.TabIndex = 222
        Me.Label9.Text = "需求零箱数:"
        Me.Label9.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.SeaGreen
        Me.Label10.Location = New System.Drawing.Point(871, 69)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 12)
        Me.Label10.TabIndex = 222
        Me.Label10.Text = "已出零箱数:"
        Me.Label10.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.SeaGreen
        Me.Label11.Location = New System.Drawing.Point(945, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 12)
        Me.Label11.TabIndex = 224
        Me.Label11.Text = "0"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.SeaGreen
        Me.Label12.Location = New System.Drawing.Point(945, 70)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(12, 12)
        Me.Label12.TabIndex = 224
        Me.Label12.Text = "0"
        Me.Label12.Visible = False
        '
        'FrmWareHouseOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 420)
        Me.Controls.Add(Me.splitContainer1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmWareHouseOut"
        Me.Text = "成品出库"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel1.PerformLayout()
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.ResumeLayout(False)
        CType(Me.dgvWHsOutD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents txtCarton As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvWHsOutD As System.Windows.Forms.DataGridView
    Friend WithEvents txtOutwhid As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents toolCargoOutDetail As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbNeedPackQty As System.Windows.Forms.Label
    Friend WithEvents lblAlreadyQty As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblNeedQty As System.Windows.Forms.Label
    Friend WithEvents lblWaitQty As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents CartonID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Version As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Intime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
