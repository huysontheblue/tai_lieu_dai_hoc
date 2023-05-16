<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmShippingQCCheck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmShippingQCCheck))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolInit = New System.Windows.Forms.ToolStripButton()
        Me.ToolTurn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolConfirm = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolWarehouseConfirm = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolEditCheckQty = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolRework = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExit = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPartNO = New System.Windows.Forms.TextBox()
        Me.ckbCartonSame = New System.Windows.Forms.CheckBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCustDeliveryNO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.txtShippingNO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.dgvShipping = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SelectAll = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Outwhid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Avcoutid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Partid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cusid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustDeliveryNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Shipqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShipCheckQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CartonCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Saddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckNote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WarehouseCheckStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WarehouseCheckNote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WarehouseCheckUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WarehouseCheckTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvShippingDetail = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.CartonID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HWCartonId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HWPartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HWQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HWShippingNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CartonOutqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusFlagText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolLblCount = New System.Windows.Forms.ToolStripStatusLabel()
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
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvShipping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvShippingDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolInit, Me.ToolTurn, Me.ToolStripSeparator1, Me.ToolDelete, Me.ToolStripSeparator4, Me.ToolConfirm, Me.ToolStripSeparator6, Me.ToolWarehouseConfirm, Me.ToolStripSeparator3, Me.ToolEditCheckQty, Me.ToolStripSeparator5, Me.ToolQuery, Me.ToolStripSeparator2, Me.ToolExport, Me.ToolStripSeparator8, Me.ToolRework, Me.ToolStripSeparator7, Me.ToolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 3)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.toolStrip1.Size = New System.Drawing.Size(1406, 25)
        Me.toolStrip1.TabIndex = 118
        Me.toolStrip1.Text = "toolStrip1"
        '
        'ToolInit
        '
        Me.ToolInit.Image = CType(resources.GetObject("ToolInit.Image"), System.Drawing.Image)
        Me.ToolInit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolInit.Name = "ToolInit"
        Me.ToolInit.Size = New System.Drawing.Size(64, 22)
        Me.ToolInit.Text = "重置(&I)"
        '
        'ToolTurn
        '
        Me.ToolTurn.Image = CType(resources.GetObject("ToolTurn.Image"), System.Drawing.Image)
        Me.ToolTurn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolTurn.Name = "ToolTurn"
        Me.ToolTurn.Size = New System.Drawing.Size(67, 22)
        Me.ToolTurn.Text = "驳回(&S)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolDelete
        '
        Me.ToolDelete.Image = CType(resources.GetObject("ToolDelete.Image"), System.Drawing.Image)
        Me.ToolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolDelete.Name = "ToolDelete"
        Me.ToolDelete.Size = New System.Drawing.Size(81, 22)
        Me.ToolDelete.Tag = "NO"
        Me.ToolDelete.Text = "删除箱(&D)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolConfirm
        '
        Me.ToolConfirm.Image = CType(resources.GetObject("ToolConfirm.Image"), System.Drawing.Image)
        Me.ToolConfirm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolConfirm.Name = "ToolConfirm"
        Me.ToolConfirm.Size = New System.Drawing.Size(67, 22)
        Me.ToolConfirm.Text = "确认(&S)"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolWarehouseConfirm
        '
        Me.ToolWarehouseConfirm.Image = CType(resources.GetObject("ToolWarehouseConfirm.Image"), System.Drawing.Image)
        Me.ToolWarehouseConfirm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolWarehouseConfirm.Name = "ToolWarehouseConfirm"
        Me.ToolWarehouseConfirm.Size = New System.Drawing.Size(91, 22)
        Me.ToolWarehouseConfirm.Text = "仓库确认(&S)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolEditCheckQty
        '
        Me.ToolEditCheckQty.Image = Global.WmsManagement.My.Resources.Resources.edit
        Me.ToolEditCheckQty.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEditCheckQty.Name = "ToolEditCheckQty"
        Me.ToolEditCheckQty.Size = New System.Drawing.Size(115, 22)
        Me.ToolEditCheckQty.Text = "出货数量调整(&S)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolQuery
        '
        Me.ToolQuery.ForeColor = System.Drawing.Color.Black
        Me.ToolQuery.Image = CType(resources.GetObject("ToolQuery.Image"), System.Drawing.Image)
        Me.ToolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolQuery.Name = "ToolQuery"
        Me.ToolQuery.Size = New System.Drawing.Size(74, 22)
        Me.ToolQuery.Text = "查 询(&Q)"
        Me.ToolQuery.ToolTipText = "查 詢"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolExport
        '
        Me.ToolExport.Image = CType(resources.GetObject("ToolExport.Image"), System.Drawing.Image)
        Me.ToolExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolExport.Name = "ToolExport"
        Me.ToolExport.Size = New System.Drawing.Size(96, 22)
        Me.ToolExport.Text = "汇出Excel(&E)"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'ToolRework
        '
        Me.ToolRework.Image = Global.WmsManagement.My.Resources.Resources.back
        Me.ToolRework.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolRework.Name = "ToolRework"
        Me.ToolRework.Size = New System.Drawing.Size(91, 22)
        Me.ToolRework.Text = "整批退货(&S)"
        Me.ToolRework.ToolTipText = "整批退货(S)"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolExit
        '
        Me.ToolExit.ForeColor = System.Drawing.Color.Black
        Me.ToolExit.Image = CType(resources.GetObject("ToolExit.Image"), System.Drawing.Image)
        Me.ToolExit.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolExit.Name = "ToolExit"
        Me.ToolExit.Size = New System.Drawing.Size(72, 22)
        Me.ToolExit.Text = "退 出(&X)"
        Me.ToolExit.ToolTipText = "退 出"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 29)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtPartNO)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ckbCartonSame)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblMessage)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCustDeliveryNO)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtNote)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtpStartDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtpEndDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtShippingNO)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1092, 464)
        Me.SplitContainer1.SplitterDistance = 81
        Me.SplitContainer1.TabIndex = 120
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(273, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 221
        Me.Label6.Text = "料号："
        '
        'txtPartNO
        '
        Me.txtPartNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPartNO.Location = New System.Drawing.Point(315, 53)
        Me.txtPartNO.MaxLength = 20
        Me.txtPartNO.Name = "txtPartNO"
        Me.txtPartNO.Size = New System.Drawing.Size(137, 21)
        Me.txtPartNO.TabIndex = 220
        '
        'ckbCartonSame
        '
        Me.ckbCartonSame.AutoSize = True
        Me.ckbCartonSame.Location = New System.Drawing.Point(713, 54)
        Me.ckbCartonSame.Name = "ckbCartonSame"
        Me.ckbCartonSame.Size = New System.Drawing.Size(108, 16)
        Me.ckbCartonSame.TabIndex = 219
        Me.ckbCartonSame.Text = "扫描箱是否相同"
        Me.ckbCartonSame.UseVisualStyleBackColor = True
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(718, 20)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(0, 19)
        Me.lblMessage.TabIndex = 218
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 217
        Me.Label5.Text = "送货单号："
        '
        'txtCustDeliveryNO
        '
        Me.txtCustDeliveryNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustDeliveryNO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCustDeliveryNO.Location = New System.Drawing.Point(82, 53)
        Me.txtCustDeliveryNO.MaxLength = 20
        Me.txtCustDeliveryNO.Name = "txtCustDeliveryNO"
        Me.txtCustDeliveryNO.Size = New System.Drawing.Size(136, 21)
        Me.txtCustDeliveryNO.TabIndex = 216
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(517, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 215
        Me.Label2.Text = "备注："
        '
        'txtNote
        '
        Me.txtNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNote.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtNote.Location = New System.Drawing.Point(559, 51)
        Me.txtNote.MaxLength = 20
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(137, 21)
        Me.txtNote.TabIndex = 214
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 213
        Me.Label1.Text = "出货单号："
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(560, 17)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(136, 21)
        Me.dtpStartDate.TabIndex = 212
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(493, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 211
        Me.Label4.Text = "结束日期："
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(316, 17)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(136, 21)
        Me.dtpEndDate.TabIndex = 210
        '
        'txtShippingNO
        '
        Me.txtShippingNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShippingNO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtShippingNO.Location = New System.Drawing.Point(82, 17)
        Me.txtShippingNO.MaxLength = 20
        Me.txtShippingNO.Name = "txtShippingNO"
        Me.txtShippingNO.Size = New System.Drawing.Size(136, 21)
        Me.txtShippingNO.TabIndex = 208
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(249, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 209
        Me.Label3.Text = "开始日期："
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.CheckBox1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgvShipping)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgvShippingDetail)
        Me.SplitContainer2.Size = New System.Drawing.Size(1092, 379)
        Me.SplitContainer2.SplitterDistance = 150
        Me.SplitContainer2.TabIndex = 0
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(64, 6)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 3
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'dgvShipping
        '
        Me.dgvShipping.AllowUserToAddRows = False
        Me.dgvShipping.AllowUserToDeleteRows = False
        Me.dgvShipping.AllowUserToOrderColumns = True
        Me.dgvShipping.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvShipping.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvShipping.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvShipping.ColumnHeadersHeight = 25
        Me.dgvShipping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvShipping.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectAll, Me.Outwhid, Me.Avcoutid, Me.Partid, Me.Cusid, Me.CustDeliveryNO, Me.Shipqty, Me.ShipCheckQty, Me.CartonCount, Me.Saddress, Me.CheckStatus, Me.CheckNote, Me.CheckUserId, Me.CheckTime, Me.WarehouseCheckStatus, Me.WarehouseCheckNote, Me.WarehouseCheckUserId, Me.WarehouseCheckTime})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvShipping.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvShipping.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvShipping.EnableHeadersVisualStyles = False
        Me.dgvShipping.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvShipping.Location = New System.Drawing.Point(0, 0)
        Me.dgvShipping.Name = "dgvShipping"
        Me.dgvShipping.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvShipping.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvShipping.RowHeadersWidth = 45
        Me.dgvShipping.RowTemplate.Height = 23
        Me.dgvShipping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvShipping.Size = New System.Drawing.Size(1090, 148)
        Me.dgvShipping.TabIndex = 2
        '
        'SelectAll
        '
        Me.SelectAll.HeaderText = ""
        Me.SelectAll.Name = "SelectAll"
        Me.SelectAll.ReadOnly = True
        Me.SelectAll.Width = 50
        '
        'Outwhid
        '
        Me.Outwhid.HeaderText = "Outwhid"
        Me.Outwhid.Name = "Outwhid"
        Me.Outwhid.ReadOnly = True
        Me.Outwhid.Visible = False
        '
        'Avcoutid
        '
        Me.Avcoutid.DataPropertyName = "Avcoutid"
        Me.Avcoutid.HeaderText = "出货单号"
        Me.Avcoutid.Name = "Avcoutid"
        Me.Avcoutid.ReadOnly = True
        '
        'Partid
        '
        Me.Partid.DataPropertyName = "Partid"
        Me.Partid.HeaderText = "料号"
        Me.Partid.Name = "Partid"
        Me.Partid.ReadOnly = True
        '
        'Cusid
        '
        Me.Cusid.DataPropertyName = "Cusid"
        Me.Cusid.HeaderText = "客户名称"
        Me.Cusid.Name = "Cusid"
        Me.Cusid.ReadOnly = True
        '
        'CustDeliveryNO
        '
        Me.CustDeliveryNO.DataPropertyName = "CustDeliveryNO"
        Me.CustDeliveryNO.HeaderText = "客户送货单号"
        Me.CustDeliveryNO.Name = "CustDeliveryNO"
        Me.CustDeliveryNO.ReadOnly = True
        '
        'Shipqty
        '
        Me.Shipqty.DataPropertyName = "Shipqty"
        Me.Shipqty.HeaderText = "送货数量"
        Me.Shipqty.Name = "Shipqty"
        Me.Shipqty.ReadOnly = True
        '
        'ShipCheckQty
        '
        Me.ShipCheckQty.DataPropertyName = "ShipCheckQty"
        Me.ShipCheckQty.HeaderText = "出货检查数量"
        Me.ShipCheckQty.Name = "ShipCheckQty"
        Me.ShipCheckQty.ReadOnly = True
        '
        'CartonCount
        '
        Me.CartonCount.DataPropertyName = "CartonCount"
        Me.CartonCount.HeaderText = "箱数"
        Me.CartonCount.Name = "CartonCount"
        Me.CartonCount.ReadOnly = True
        '
        'Saddress
        '
        Me.Saddress.DataPropertyName = "Saddress"
        Me.Saddress.HeaderText = "送货地址"
        Me.Saddress.Name = "Saddress"
        Me.Saddress.ReadOnly = True
        '
        'CheckStatus
        '
        Me.CheckStatus.DataPropertyName = "CheckStatus"
        Me.CheckStatus.HeaderText = "品质审核状态"
        Me.CheckStatus.Name = "CheckStatus"
        Me.CheckStatus.ReadOnly = True
        '
        'CheckNote
        '
        Me.CheckNote.DataPropertyName = "CheckNote"
        Me.CheckNote.HeaderText = "审核备注"
        Me.CheckNote.Name = "CheckNote"
        Me.CheckNote.ReadOnly = True
        '
        'CheckUserId
        '
        Me.CheckUserId.DataPropertyName = "CheckUserId"
        Me.CheckUserId.HeaderText = "审核用户"
        Me.CheckUserId.Name = "CheckUserId"
        Me.CheckUserId.ReadOnly = True
        '
        'CheckTime
        '
        Me.CheckTime.DataPropertyName = "CheckTime"
        Me.CheckTime.HeaderText = "审核时间"
        Me.CheckTime.Name = "CheckTime"
        Me.CheckTime.ReadOnly = True
        '
        'WarehouseCheckStatus
        '
        Me.WarehouseCheckStatus.DataPropertyName = "WarehouseCheckStatus"
        Me.WarehouseCheckStatus.HeaderText = "仓库审核状态"
        Me.WarehouseCheckStatus.Name = "WarehouseCheckStatus"
        Me.WarehouseCheckStatus.ReadOnly = True
        '
        'WarehouseCheckNote
        '
        Me.WarehouseCheckNote.DataPropertyName = "WarehouseCheckNote"
        Me.WarehouseCheckNote.HeaderText = "审核备注"
        Me.WarehouseCheckNote.Name = "WarehouseCheckNote"
        Me.WarehouseCheckNote.ReadOnly = True
        '
        'WarehouseCheckUserId
        '
        Me.WarehouseCheckUserId.DataPropertyName = "WarehouseCheckUserId"
        Me.WarehouseCheckUserId.HeaderText = "审核用户"
        Me.WarehouseCheckUserId.Name = "WarehouseCheckUserId"
        Me.WarehouseCheckUserId.ReadOnly = True
        '
        'WarehouseCheckTime
        '
        Me.WarehouseCheckTime.DataPropertyName = "WarehouseCheckTime"
        Me.WarehouseCheckTime.HeaderText = "审核时间"
        Me.WarehouseCheckTime.Name = "WarehouseCheckTime"
        Me.WarehouseCheckTime.ReadOnly = True
        '
        'dgvShippingDetail
        '
        Me.dgvShippingDetail.AllowUserToAddRows = False
        Me.dgvShippingDetail.AllowUserToDeleteRows = False
        Me.dgvShippingDetail.AllowUserToOrderColumns = True
        Me.dgvShippingDetail.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvShippingDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvShippingDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvShippingDetail.ColumnHeadersHeight = 25
        Me.dgvShippingDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvShippingDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CartonID, Me.HWCartonId, Me.HWPartId, Me.HWQty, Me.HWShippingNO, Me.colPartId, Me.CartonOutqty, Me.UserID, Me.Intime, Me.StatusFlagText})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvShippingDetail.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvShippingDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvShippingDetail.EnableHeadersVisualStyles = False
        Me.dgvShippingDetail.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvShippingDetail.Location = New System.Drawing.Point(0, 0)
        Me.dgvShippingDetail.Name = "dgvShippingDetail"
        Me.dgvShippingDetail.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvShippingDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvShippingDetail.RowHeadersWidth = 45
        Me.dgvShippingDetail.RowTemplate.Height = 23
        Me.dgvShippingDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvShippingDetail.Size = New System.Drawing.Size(1090, 223)
        Me.dgvShippingDetail.TabIndex = 2
        '
        'CartonID
        '
        Me.CartonID.HeaderText = "箱号"
        Me.CartonID.Name = "CartonID"
        Me.CartonID.ReadOnly = True
        Me.CartonID.Width = 250
        '
        'HWCartonId
        '
        Me.HWCartonId.HeaderText = "客户箱号"
        Me.HWCartonId.Name = "HWCartonId"
        Me.HWCartonId.ReadOnly = True
        '
        'HWPartId
        '
        Me.HWPartId.HeaderText = "客户料号"
        Me.HWPartId.Name = "HWPartId"
        Me.HWPartId.ReadOnly = True
        '
        'HWQty
        '
        Me.HWQty.HeaderText = "客户数量"
        Me.HWQty.Name = "HWQty"
        Me.HWQty.ReadOnly = True
        '
        'HWShippingNO
        '
        Me.HWShippingNO.HeaderText = "客户单号"
        Me.HWShippingNO.Name = "HWShippingNO"
        Me.HWShippingNO.ReadOnly = True
        '
        'colPartId
        '
        Me.colPartId.HeaderText = "料号"
        Me.colPartId.Name = "colPartId"
        Me.colPartId.ReadOnly = True
        '
        'CartonOutqty
        '
        Me.CartonOutqty.HeaderText = "数量"
        Me.CartonOutqty.Name = "CartonOutqty"
        Me.CartonOutqty.ReadOnly = True
        '
        'UserID
        '
        Me.UserID.HeaderText = "扫描用户"
        Me.UserID.Name = "UserID"
        Me.UserID.ReadOnly = True
        '
        'Intime
        '
        Me.Intime.HeaderText = "扫描时间"
        Me.Intime.Name = "Intime"
        Me.Intime.ReadOnly = True
        '
        'StatusFlagText
        '
        Me.StatusFlagText.HeaderText = "状态"
        Me.StatusFlagText.Name = "StatusFlagText"
        Me.StatusFlagText.ReadOnly = True
        Me.StatusFlagText.Width = 80
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolLblCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 496)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1092, 22)
        Me.StatusStrip1.TabIndex = 129
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel1.Text = "记录笔数："
        '
        'ToolLblCount
        '
        Me.ToolLblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolLblCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ToolLblCount.LinkColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ToolLblCount.Name = "ToolLblCount"
        Me.ToolLblCount.Size = New System.Drawing.Size(15, 17)
        Me.ToolLblCount.Text = "0"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Outwhid"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Avcoutid"
        Me.DataGridViewTextBoxColumn2.HeaderText = "出货单号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Partid"
        Me.DataGridViewTextBoxColumn3.HeaderText = "料号"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Cusid"
        Me.DataGridViewTextBoxColumn4.HeaderText = "参数代码"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "CustDeliveryNO"
        Me.DataGridViewTextBoxColumn5.HeaderText = "参数名称"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Shipqty"
        Me.DataGridViewTextBoxColumn6.HeaderText = "参数值"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "ShipCheckQty"
        Me.DataGridViewTextBoxColumn7.HeaderText = "送货地址"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "CartonCount"
        Me.DataGridViewTextBoxColumn8.HeaderText = "品质审核状态"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Saddress"
        Me.DataGridViewTextBoxColumn9.HeaderText = "审核备注"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "CheckStatus"
        Me.DataGridViewTextBoxColumn10.HeaderText = "审核用户"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "CheckNote"
        Me.DataGridViewTextBoxColumn11.HeaderText = "审核时间"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "WarehouseCheckStatus"
        Me.DataGridViewTextBoxColumn12.HeaderText = "箱号"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "WarehouseCheckNote"
        Me.DataGridViewTextBoxColumn13.HeaderText = "客户箱号"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "WarehouseCheckUserId"
        Me.DataGridViewTextBoxColumn14.HeaderText = "客户料号"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "WarehouseCheckTime"
        Me.DataGridViewTextBoxColumn15.HeaderText = "客户数量"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "WarehouseCheckUserId"
        Me.DataGridViewTextBoxColumn16.HeaderText = "客户单号"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Width = 250
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "WarehouseCheckTime"
        Me.DataGridViewTextBoxColumn17.HeaderText = "数量"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.HeaderText = "扫描用户"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Width = 250
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.HeaderText = "扫描时间"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.HeaderText = "客户单号"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.HeaderText = "数量"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.HeaderText = "扫描用户"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.HeaderText = "扫描时间"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.HeaderText = "扫描用户"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.HeaderText = "扫描时间"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.HeaderText = "状态"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.Width = 80
        '
        'FrmShippingQCCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1092, 518)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "FrmShippingQCCheck"
        Me.ShowIcon = False
        Me.Text = "出货品质确认"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvShipping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvShippingDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents ToolInit As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolTurn As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolConfirm As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtShippingNO As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolLblCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvShipping As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents dgvShippingDetail As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCustDeliveryNO As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents ckbCartonSame As System.Windows.Forms.CheckBox
    Private WithEvents ToolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPartNO As System.Windows.Forms.TextBox
    Private WithEvents ToolWarehouseConfirm As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ToolEditCheckQty As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ToolRework As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents SelectAll As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Outwhid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Avcoutid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cusid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustDeliveryNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Shipqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipCheckQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CartonCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Saddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckNote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WarehouseCheckStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WarehouseCheckNote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WarehouseCheckUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WarehouseCheckTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CartonID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HWCartonId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HWPartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HWQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HWShippingNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CartonOutqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Intime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusFlagText As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
