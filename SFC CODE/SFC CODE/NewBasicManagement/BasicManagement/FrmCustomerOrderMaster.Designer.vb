<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCustomerOrderMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCustomerOrderMaster))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAgain = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnModify = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnUndo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAddRow = New System.Windows.Forms.ToolStripButton()
        Me.btnSaveRow = New System.Windows.Forms.ToolStripButton()
        Me.btnDeleteRow = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtContractOrder = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.dgvCustomerOrder = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.CustomerOrderID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeliveryCustomerId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeliveryCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModifiedVersion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContractDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerOrderNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TerminalCustomerOrderNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModifyUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModifyTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.dgvCustomerOrderItem = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.CustomerOrderItemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerPartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductSpecifications = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SKUQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Titlemini = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvCustomerOrderDetail = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.CustomerOrderDetailID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FNSKU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExportingCountries = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShippingMethod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRDimensions = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerDelivery = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.ExportQuantity = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.PrinteQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackingQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StorageQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShipmentsQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusFlagText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DCreateUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DCreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DModifyUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DModifyTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.dtpStartTime = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.dtpEndTime = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
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
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolBt.SuspendLayout()
        CType(Me.dgvCustomerOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvCustomerOrderItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCustomerOrderDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpStartTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpEndTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btnNew, Me.ToolStripSeparator10, Me.btnAgain, Me.ToolStripSeparator4, Me.btnModify, Me.ToolStripSeparator5, Me.btnSave, Me.ToolStripSeparator2, Me.btnUndo, Me.ToolStripSeparator6, Me.btnDelete, Me.ToolStripSeparator9, Me.btnRefresh, Me.ToolStripSeparator3, Me.btnAddRow, Me.btnSaveRow, Me.btnDeleteRow, Me.ToolStripSeparator8, Me.btnImport, Me.ToolStripSeparator7, Me.btnExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1041, 23)
        Me.ToolBt.TabIndex = 154
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(74, 20)
        Me.btnNew.Tag = ""
        Me.btnNew.Text = "新 增(&N)"
        Me.btnNew.ToolTipText = "新增"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 23)
        '
        'btnAgain
        '
        Me.btnAgain.ForeColor = System.Drawing.Color.Black
        Me.btnAgain.Image = CType(resources.GetObject("btnAgain.Image"), System.Drawing.Image)
        Me.btnAgain.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAgain.Name = "btnAgain"
        Me.btnAgain.Size = New System.Drawing.Size(92, 20)
        Me.btnAgain.Tag = "NO"
        Me.btnAgain.Text = "重新下载(&A)"
        Me.btnAgain.ToolTipText = "重 新"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'btnModify
        '
        Me.btnModify.Image = CType(resources.GetObject("btnModify.Image"), System.Drawing.Image)
        Me.btnModify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(71, 20)
        Me.btnModify.Tag = ""
        Me.btnModify.Text = "修 改(&E)"
        Me.btnModify.ToolTipText = "修 改"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 23)
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(71, 20)
        Me.btnSave.Text = "保 存(&S)"
        Me.btnSave.ToolTipText = "保存"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'btnUndo
        '
        Me.btnUndo.Image = CType(resources.GetObject("btnUndo.Image"), System.Drawing.Image)
        Me.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(68, 20)
        Me.btnUndo.Text = "返回(&C)"
        Me.btnUndo.ToolTipText = "返回"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 23)
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(69, 20)
        Me.btnDelete.Text = "删除(&D)"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 23)
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 20)
        Me.btnRefresh.Text = "刷 新(&R)"
        Me.btnRefresh.ToolTipText = "刷新"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'btnAddRow
        '
        Me.btnAddRow.Image = Global.BasicManagement.My.Resources.Resources.add
        Me.btnAddRow.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnAddRow.Name = "btnAddRow"
        Me.btnAddRow.Size = New System.Drawing.Size(76, 20)
        Me.btnAddRow.Text = "新增行(&I)"
        Me.btnAddRow.ToolTipText = "新增行"
        '
        'btnSaveRow
        '
        Me.btnSaveRow.Image = CType(resources.GetObject("btnSaveRow.Image"), System.Drawing.Image)
        Me.btnSaveRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSaveRow.Name = "btnSaveRow"
        Me.btnSaveRow.Size = New System.Drawing.Size(79, 20)
        Me.btnSaveRow.Text = "保存行(&S)"
        Me.btnSaveRow.ToolTipText = "保存行"
        '
        'btnDeleteRow
        '
        Me.btnDeleteRow.Image = Global.BasicManagement.My.Resources.Resources.delete
        Me.btnDeleteRow.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnDeleteRow.Name = "btnDeleteRow"
        Me.btnDeleteRow.Size = New System.Drawing.Size(81, 20)
        Me.btnDeleteRow.Text = "删除行(&D)"
        Me.btnDeleteRow.ToolTipText = "删除行"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 23)
        '
        'btnImport
        '
        Me.btnImport.Image = Global.BasicManagement.My.Resources.Resources.hourglass_add
        Me.btnImport.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(71, 20)
        Me.btnImport.Text = "导 入(&E)"
        Me.btnImport.ToolTipText = "导入"
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
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(20, 47)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(95, 23)
        Me.LabelX1.TabIndex = 155
        Me.LabelX1.Text = "合约订单单号:"
        '
        'txtContractOrder
        '
        '
        '
        '
        Me.txtContractOrder.Border.Class = "TextBoxBorder"
        Me.txtContractOrder.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtContractOrder.Location = New System.Drawing.Point(106, 48)
        Me.txtContractOrder.Name = "txtContractOrder"
        Me.txtContractOrder.Size = New System.Drawing.Size(165, 21)
        Me.txtContractOrder.TabIndex = 156
        '
        'dgvCustomerOrder
        '
        Me.dgvCustomerOrder.AllowUserToAddRows = False
        Me.dgvCustomerOrder.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCustomerOrder.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCustomerOrder.ColumnHeadersHeight = 28
        Me.dgvCustomerOrder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerOrderID, Me.OrderNO, Me.DeliveryCustomerId, Me.DeliveryCustomerName, Me.ModifiedVersion, Me.ContractDate, Me.CustomerOrderNO, Me.TerminalCustomerOrderNO, Me.CreateUserId, Me.CreateTime, Me.ModifyUserId, Me.ModifyTime})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCustomerOrder.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCustomerOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCustomerOrder.EnableHeadersVisualStyles = False
        Me.dgvCustomerOrder.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvCustomerOrder.Location = New System.Drawing.Point(0, 0)
        Me.dgvCustomerOrder.MultiSelect = False
        Me.dgvCustomerOrder.Name = "dgvCustomerOrder"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCustomerOrder.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCustomerOrder.RowHeadersWidth = 15
        Me.dgvCustomerOrder.RowTemplate.Height = 23
        Me.dgvCustomerOrder.Size = New System.Drawing.Size(1041, 143)
        Me.dgvCustomerOrder.TabIndex = 160
        '
        'CustomerOrderID
        '
        Me.CustomerOrderID.DataPropertyName = "CustomerOrderID"
        Me.CustomerOrderID.HeaderText = "CustomerOrderID"
        Me.CustomerOrderID.Name = "CustomerOrderID"
        Me.CustomerOrderID.ReadOnly = True
        Me.CustomerOrderID.Visible = False
        '
        'OrderNO
        '
        Me.OrderNO.DataPropertyName = "OrderNO"
        Me.OrderNO.HeaderText = "合约单号"
        Me.OrderNO.Name = "OrderNO"
        Me.OrderNO.ReadOnly = True
        '
        'DeliveryCustomerId
        '
        Me.DeliveryCustomerId.DataPropertyName = "DeliveryCustomerId"
        Me.DeliveryCustomerId.HeaderText = "送货客户编号"
        Me.DeliveryCustomerId.Name = "DeliveryCustomerId"
        Me.DeliveryCustomerId.ReadOnly = True
        '
        'DeliveryCustomerName
        '
        Me.DeliveryCustomerName.DataPropertyName = "DeliveryCustomerName"
        Me.DeliveryCustomerName.HeaderText = "送货客户名称"
        Me.DeliveryCustomerName.Name = "DeliveryCustomerName"
        Me.DeliveryCustomerName.ReadOnly = True
        '
        'ModifiedVersion
        '
        Me.ModifiedVersion.DataPropertyName = "ModifiedVersion"
        Me.ModifiedVersion.HeaderText = "版本"
        Me.ModifiedVersion.Name = "ModifiedVersion"
        Me.ModifiedVersion.ReadOnly = True
        '
        'ContractDate
        '
        Me.ContractDate.DataPropertyName = "ContractDate"
        Me.ContractDate.HeaderText = "合约日期"
        Me.ContractDate.Name = "ContractDate"
        Me.ContractDate.ReadOnly = True
        '
        'CustomerOrderNO
        '
        Me.CustomerOrderNO.DataPropertyName = "CustomerOrderNO"
        Me.CustomerOrderNO.HeaderText = "客户订单号"
        Me.CustomerOrderNO.Name = "CustomerOrderNO"
        Me.CustomerOrderNO.ReadOnly = True
        '
        'TerminalCustomerOrderNO
        '
        Me.TerminalCustomerOrderNO.DataPropertyName = "TerminalCustomerOrderNO"
        Me.TerminalCustomerOrderNO.HeaderText = "终端客户订单号"
        Me.TerminalCustomerOrderNO.Name = "TerminalCustomerOrderNO"
        Me.TerminalCustomerOrderNO.ReadOnly = True
        '
        'CreateUserId
        '
        Me.CreateUserId.DataPropertyName = "CreateUserId"
        Me.CreateUserId.HeaderText = "创建人"
        Me.CreateUserId.Name = "CreateUserId"
        Me.CreateUserId.ReadOnly = True
        '
        'CreateTime
        '
        Me.CreateTime.DataPropertyName = "CreateTime"
        Me.CreateTime.HeaderText = "创建时间"
        Me.CreateTime.Name = "CreateTime"
        Me.CreateTime.ReadOnly = True
        '
        'ModifyUserId
        '
        Me.ModifyUserId.DataPropertyName = "ModifyUserId"
        Me.ModifyUserId.HeaderText = "修改人"
        Me.ModifyUserId.Name = "ModifyUserId"
        Me.ModifyUserId.ReadOnly = True
        '
        'ModifyTime
        '
        Me.ModifyTime.DataPropertyName = "ModifyTime"
        Me.ModifyTime.HeaderText = "修改时间"
        Me.ModifyTime.Name = "ModifyTime"
        Me.ModifyTime.ReadOnly = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 95)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvCustomerOrder)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.Size = New System.Drawing.Size(1041, 440)
        Me.SplitContainer1.SplitterDistance = 143
        Me.SplitContainer1.TabIndex = 161
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgvCustomerOrderItem)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgvCustomerOrderDetail)
        Me.SplitContainer2.Size = New System.Drawing.Size(1041, 293)
        Me.SplitContainer2.SplitterDistance = 404
        Me.SplitContainer2.TabIndex = 0
        '
        'dgvCustomerOrderItem
        '
        Me.dgvCustomerOrderItem.AllowUserToAddRows = False
        Me.dgvCustomerOrderItem.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCustomerOrderItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvCustomerOrderItem.ColumnHeadersHeight = 28
        Me.dgvCustomerOrderItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerOrderItemID, Me.ItemNO, Me.PartId, Me.CustomerPartId, Me.ProductSpecifications, Me.Quantity, Me.Unit, Me.SKUQuantity, Me.Titlemini})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCustomerOrderItem.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCustomerOrderItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCustomerOrderItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvCustomerOrderItem.EnableHeadersVisualStyles = False
        Me.dgvCustomerOrderItem.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvCustomerOrderItem.Location = New System.Drawing.Point(0, 0)
        Me.dgvCustomerOrderItem.MultiSelect = False
        Me.dgvCustomerOrderItem.Name = "dgvCustomerOrderItem"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCustomerOrderItem.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvCustomerOrderItem.RowHeadersWidth = 15
        Me.dgvCustomerOrderItem.RowTemplate.Height = 23
        Me.dgvCustomerOrderItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCustomerOrderItem.Size = New System.Drawing.Size(404, 293)
        Me.dgvCustomerOrderItem.TabIndex = 162
        '
        'CustomerOrderItemID
        '
        Me.CustomerOrderItemID.DataPropertyName = "CustomerOrderItemID"
        Me.CustomerOrderItemID.HeaderText = "CustomerOrderItemID"
        Me.CustomerOrderItemID.Name = "CustomerOrderItemID"
        Me.CustomerOrderItemID.ReadOnly = True
        Me.CustomerOrderItemID.Visible = False
        '
        'ItemNO
        '
        Me.ItemNO.DataPropertyName = "ItemNO"
        Me.ItemNO.HeaderText = "项次"
        Me.ItemNO.Name = "ItemNO"
        Me.ItemNO.ReadOnly = True
        Me.ItemNO.Width = 30
        '
        'PartId
        '
        Me.PartId.DataPropertyName = "PartId"
        Me.PartId.HeaderText = "产品编号"
        Me.PartId.Name = "PartId"
        Me.PartId.ReadOnly = True
        '
        'CustomerPartId
        '
        Me.CustomerPartId.DataPropertyName = "CustomerPartId"
        Me.CustomerPartId.HeaderText = "终端客户产品编号"
        Me.CustomerPartId.Name = "CustomerPartId"
        Me.CustomerPartId.ReadOnly = True
        Me.CustomerPartId.Width = 70
        '
        'ProductSpecifications
        '
        Me.ProductSpecifications.DataPropertyName = "ProductSpecifications"
        Me.ProductSpecifications.HeaderText = "产品规格"
        Me.ProductSpecifications.Name = "ProductSpecifications"
        Me.ProductSpecifications.ReadOnly = True
        '
        'Quantity
        '
        Me.Quantity.DataPropertyName = "Quantity"
        Me.Quantity.HeaderText = "数量"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = True
        Me.Quantity.Width = 50
        '
        'Unit
        '
        Me.Unit.DataPropertyName = "Unit"
        Me.Unit.HeaderText = "单位"
        Me.Unit.Name = "Unit"
        Me.Unit.ReadOnly = True
        Me.Unit.Width = 50
        '
        'SKUQuantity
        '
        Me.SKUQuantity.DataPropertyName = "SKUQuantity"
        Me.SKUQuantity.HeaderText = "SKU数量"
        Me.SKUQuantity.Name = "SKUQuantity"
        Me.SKUQuantity.ReadOnly = True
        Me.SKUQuantity.Width = 50
        '
        'Titlemini
        '
        Me.Titlemini.DataPropertyName = "Titlemini"
        Me.Titlemini.HeaderText = "Title_mini"
        Me.Titlemini.Name = "Titlemini"
        Me.Titlemini.ReadOnly = True
        Me.Titlemini.Width = 150
        '
        'dgvCustomerOrderDetail
        '
        Me.dgvCustomerOrderDetail.AllowUserToAddRows = False
        Me.dgvCustomerOrderDetail.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCustomerOrderDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvCustomerOrderDetail.ColumnHeadersHeight = 28
        Me.dgvCustomerOrderDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerOrderDetailID, Me.FNSKU, Me.ExportingCountries, Me.ShippingMethod, Me.PRDimensions, Me.CustomerDelivery, Me.ExportQuantity, Me.PrinteQuantity, Me.PackingQuantity, Me.StorageQuantity, Me.ShipmentsQuantity, Me.StatusFlagText, Me.DCreateUserId, Me.DCreateTime, Me.DModifyUserId, Me.DModifyTime})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCustomerOrderDetail.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvCustomerOrderDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCustomerOrderDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvCustomerOrderDetail.EnableHeadersVisualStyles = False
        Me.dgvCustomerOrderDetail.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvCustomerOrderDetail.Location = New System.Drawing.Point(0, 0)
        Me.dgvCustomerOrderDetail.MultiSelect = False
        Me.dgvCustomerOrderDetail.Name = "dgvCustomerOrderDetail"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCustomerOrderDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvCustomerOrderDetail.RowHeadersWidth = 15
        Me.dgvCustomerOrderDetail.RowTemplate.Height = 23
        Me.dgvCustomerOrderDetail.Size = New System.Drawing.Size(633, 293)
        Me.dgvCustomerOrderDetail.TabIndex = 0
        '
        'CustomerOrderDetailID
        '
        Me.CustomerOrderDetailID.DataPropertyName = "CustomerOrderDetailID"
        Me.CustomerOrderDetailID.HeaderText = "CustomerOrderDetailID"
        Me.CustomerOrderDetailID.Name = "CustomerOrderDetailID"
        Me.CustomerOrderDetailID.ReadOnly = True
        Me.CustomerOrderDetailID.Visible = False
        '
        'FNSKU
        '
        Me.FNSKU.DataPropertyName = "FNSKU"
        Me.FNSKU.HeaderText = "FNSKU"
        Me.FNSKU.Name = "FNSKU"
        '
        'ExportingCountries
        '
        Me.ExportingCountries.DataPropertyName = "ExportingCountries"
        Me.ExportingCountries.HeaderText = "出口国家"
        Me.ExportingCountries.Name = "ExportingCountries"
        Me.ExportingCountries.Width = 70
        '
        'ShippingMethod
        '
        Me.ShippingMethod.DataPropertyName = "ShippingMethod"
        Me.ShippingMethod.HeaderText = "交货方式"
        Me.ShippingMethod.Name = "ShippingMethod"
        Me.ShippingMethod.Width = 70
        '
        'PRDimensions
        '
        Me.PRDimensions.DataPropertyName = "PRDimensions"
        Me.PRDimensions.HeaderText = "PR维度"
        Me.PRDimensions.Name = "PRDimensions"
        '
        'CustomerDelivery
        '
        '
        '
        '
        Me.CustomerDelivery.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.CustomerDelivery.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CustomerDelivery.ButtonDropDown.Visible = True
        Me.CustomerDelivery.CustomFormat = "yyyy-MM-dd"
        Me.CustomerDelivery.DataPropertyName = "CustomerDelivery"
        Me.CustomerDelivery.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.CustomerDelivery.HeaderText = "客户交期"
        Me.CustomerDelivery.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.CustomerDelivery.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.CustomerDelivery.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CustomerDelivery.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.CustomerDelivery.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CustomerDelivery.MonthCalendar.DisplayMonth = New Date(2016, 6, 1, 0, 0, 0, 0)
        Me.CustomerDelivery.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.CustomerDelivery.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.CustomerDelivery.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CustomerDelivery.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.CustomerDelivery.Name = "CustomerDelivery"
        Me.CustomerDelivery.ShowUpDown = True
        Me.CustomerDelivery.Width = 120
        '
        'ExportQuantity
        '
        '
        '
        '
        Me.ExportQuantity.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.ExportQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ExportQuantity.DataPropertyName = "ExportQuantity"
        Me.ExportQuantity.HeaderText = "交货数量"
        Me.ExportQuantity.MinValue = 0
        Me.ExportQuantity.Name = "ExportQuantity"
        '
        'PrinteQuantity
        '
        Me.PrinteQuantity.DataPropertyName = "PrinteQuantity"
        Me.PrinteQuantity.HeaderText = "打印数"
        Me.PrinteQuantity.Name = "PrinteQuantity"
        Me.PrinteQuantity.ReadOnly = True
        Me.PrinteQuantity.Width = 60
        '
        'PackingQuantity
        '
        Me.PackingQuantity.DataPropertyName = "PackingQuantity"
        Me.PackingQuantity.HeaderText = "包装数"
        Me.PackingQuantity.Name = "PackingQuantity"
        Me.PackingQuantity.ReadOnly = True
        Me.PackingQuantity.Width = 60
        '
        'StorageQuantity
        '
        Me.StorageQuantity.DataPropertyName = "StorageQuantity"
        Me.StorageQuantity.HeaderText = "入库数"
        Me.StorageQuantity.Name = "StorageQuantity"
        Me.StorageQuantity.ReadOnly = True
        Me.StorageQuantity.Width = 60
        '
        'ShipmentsQuantity
        '
        Me.ShipmentsQuantity.DataPropertyName = "ShipmentsQuantity"
        Me.ShipmentsQuantity.HeaderText = "出货数"
        Me.ShipmentsQuantity.Name = "ShipmentsQuantity"
        Me.ShipmentsQuantity.ReadOnly = True
        Me.ShipmentsQuantity.Width = 60
        '
        'StatusFlagText
        '
        Me.StatusFlagText.DataPropertyName = "StatusFlagText"
        Me.StatusFlagText.HeaderText = "状态"
        Me.StatusFlagText.Name = "StatusFlagText"
        Me.StatusFlagText.ReadOnly = True
        Me.StatusFlagText.Width = 80
        '
        'DCreateUserId
        '
        Me.DCreateUserId.DataPropertyName = "CreateUserId"
        Me.DCreateUserId.HeaderText = "创建人"
        Me.DCreateUserId.Name = "DCreateUserId"
        Me.DCreateUserId.ReadOnly = True
        Me.DCreateUserId.Width = 80
        '
        'DCreateTime
        '
        Me.DCreateTime.DataPropertyName = "CreateTime"
        Me.DCreateTime.HeaderText = "创建时间"
        Me.DCreateTime.Name = "DCreateTime"
        Me.DCreateTime.ReadOnly = True
        Me.DCreateTime.Width = 80
        '
        'DModifyUserId
        '
        Me.DModifyUserId.DataPropertyName = "ModifyUserId"
        Me.DModifyUserId.HeaderText = "修改人"
        Me.DModifyUserId.Name = "DModifyUserId"
        Me.DModifyUserId.ReadOnly = True
        Me.DModifyUserId.Width = 80
        '
        'DModifyTime
        '
        Me.DModifyTime.DataPropertyName = "ModifyTime"
        Me.DModifyTime.HeaderText = "修改时间"
        Me.DModifyTime.Name = "DModifyTime"
        Me.DModifyTime.ReadOnly = True
        Me.DModifyTime.Width = 80
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.ForeColor = System.Drawing.Color.Red
        Me.lblMessage.Location = New System.Drawing.Point(774, 62)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(454, 23)
        Me.lblMessage.TabIndex = 162
        '
        'dtpStartTime
        '
        '
        '
        '
        Me.dtpStartTime.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpStartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpStartTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpStartTime.ButtonDropDown.Visible = True
        Me.dtpStartTime.CustomFormat = "yyyy-MM-dd"
        Me.dtpStartTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpStartTime.IsPopupCalendarOpen = False
        Me.dtpStartTime.Location = New System.Drawing.Point(373, 48)
        '
        '
        '
        Me.dtpStartTime.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpStartTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpStartTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpStartTime.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpStartTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpStartTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpStartTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpStartTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpStartTime.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.dtpStartTime.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpStartTime.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpStartTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpStartTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpStartTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpStartTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpStartTime.MonthCalendar.TodayButtonVisible = True
        Me.dtpStartTime.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpStartTime.Name = "dtpStartTime"
        Me.dtpStartTime.Size = New System.Drawing.Size(134, 21)
        Me.dtpStartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpStartTime.TabIndex = 167
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(309, 48)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(95, 23)
        Me.LabelX2.TabIndex = 168
        Me.LabelX2.Text = "开始日期:"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(546, 48)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(95, 23)
        Me.LabelX3.TabIndex = 169
        Me.LabelX3.Text = "结束日期:"
        '
        'dtpEndTime
        '
        '
        '
        '
        Me.dtpEndTime.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpEndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEndTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpEndTime.ButtonDropDown.Visible = True
        Me.dtpEndTime.CustomFormat = "yyyy-MM-dd"
        Me.dtpEndTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpEndTime.IsPopupCalendarOpen = False
        Me.dtpEndTime.Location = New System.Drawing.Point(608, 48)
        '
        '
        '
        Me.dtpEndTime.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpEndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEndTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpEndTime.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpEndTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpEndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEndTime.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.dtpEndTime.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpEndTime.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpEndTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpEndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEndTime.MonthCalendar.TodayButtonVisible = True
        Me.dtpEndTime.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpEndTime.Name = "dtpEndTime"
        Me.dtpEndTime.Size = New System.Drawing.Size(134, 21)
        Me.dtpEndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpEndTime.TabIndex = 170
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "CustomerOrderID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "CustomerOrderID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "OrderNO"
        Me.DataGridViewTextBoxColumn2.HeaderText = "合约单号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "DeliveryCustomerId"
        Me.DataGridViewTextBoxColumn3.HeaderText = "送货客户编号"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "DeliveryCustomerName"
        Me.DataGridViewTextBoxColumn4.HeaderText = "送货客户名称"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "ModifiedVersion"
        Me.DataGridViewTextBoxColumn5.HeaderText = "版本"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "ContractDate"
        Me.DataGridViewTextBoxColumn6.HeaderText = "合约日期"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "CustomerOrderNO"
        Me.DataGridViewTextBoxColumn7.HeaderText = "客户订单号"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "TerminalCustomerOrderNO"
        Me.DataGridViewTextBoxColumn8.HeaderText = "终端客户订单号"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "CreateUserId"
        Me.DataGridViewTextBoxColumn9.HeaderText = "创建人"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "CreateTime"
        Me.DataGridViewTextBoxColumn10.HeaderText = "创建时间"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "ModifyUserId"
        Me.DataGridViewTextBoxColumn11.HeaderText = "修改人"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "ModifyTime"
        Me.DataGridViewTextBoxColumn12.HeaderText = "修改时间"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "CustomerOrderItemID"
        Me.DataGridViewTextBoxColumn13.HeaderText = "CustomerOrderItemID"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "ItemNO"
        Me.DataGridViewTextBoxColumn14.HeaderText = "项次"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 30
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "PartId"
        Me.DataGridViewTextBoxColumn15.HeaderText = "产品编号"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "CustomerPartId"
        Me.DataGridViewTextBoxColumn16.HeaderText = "终端客户产品编号"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Width = 70
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "ProductSpecifications"
        Me.DataGridViewTextBoxColumn17.HeaderText = "产品规格"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "Quantity"
        Me.DataGridViewTextBoxColumn18.HeaderText = "数量"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Width = 50
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "Unit"
        Me.DataGridViewTextBoxColumn19.HeaderText = "单位"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Width = 50
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "Titlemini"
        Me.DataGridViewTextBoxColumn20.HeaderText = "Title_mini"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Width = 150
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "Titlemini"
        Me.DataGridViewTextBoxColumn21.HeaderText = "CustomerOrderDetailID"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Visible = False
        Me.DataGridViewTextBoxColumn21.Width = 150
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "CustomerOrderDetailIDCustomerOrderDetailID"
        Me.DataGridViewTextBoxColumn22.HeaderText = "FNSKU"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.Visible = False
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "FNSKU"
        Me.DataGridViewTextBoxColumn23.HeaderText = "出口国家"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        Me.DataGridViewTextBoxColumn23.Width = 70
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "ExportingCountries"
        Me.DataGridViewTextBoxColumn24.HeaderText = "交货方式"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        Me.DataGridViewTextBoxColumn24.Width = 70
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "ShippingMethod"
        Me.DataGridViewTextBoxColumn25.HeaderText = "PR维度"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        Me.DataGridViewTextBoxColumn25.Width = 70
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "PRDimensions"
        Me.DataGridViewTextBoxColumn26.HeaderText = "交货数量"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        Me.DataGridViewTextBoxColumn26.Width = 60
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "PrinteQuantity"
        Me.DataGridViewTextBoxColumn27.HeaderText = "打印数"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.ReadOnly = True
        Me.DataGridViewTextBoxColumn27.Width = 60
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "PackingQuantity"
        Me.DataGridViewTextBoxColumn28.HeaderText = "包装数"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.ReadOnly = True
        Me.DataGridViewTextBoxColumn28.Width = 60
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "StorageQuantity"
        Me.DataGridViewTextBoxColumn29.HeaderText = "入库数"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.ReadOnly = True
        Me.DataGridViewTextBoxColumn29.Width = 60
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "ShipmentsQuantity"
        Me.DataGridViewTextBoxColumn30.HeaderText = "出货数"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.ReadOnly = True
        Me.DataGridViewTextBoxColumn30.Width = 60
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "StatusFlagText"
        Me.DataGridViewTextBoxColumn31.HeaderText = "状态"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        Me.DataGridViewTextBoxColumn31.ReadOnly = True
        Me.DataGridViewTextBoxColumn31.Width = 80
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.DataPropertyName = "CreateUserId"
        Me.DataGridViewTextBoxColumn32.HeaderText = "创建人"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        Me.DataGridViewTextBoxColumn32.ReadOnly = True
        Me.DataGridViewTextBoxColumn32.Width = 80
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "CreateTime"
        Me.DataGridViewTextBoxColumn33.HeaderText = "创建时间"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.ReadOnly = True
        Me.DataGridViewTextBoxColumn33.Width = 80
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.DataPropertyName = "ModifyUserId"
        Me.DataGridViewTextBoxColumn34.HeaderText = "修改人"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        Me.DataGridViewTextBoxColumn34.ReadOnly = True
        Me.DataGridViewTextBoxColumn34.Width = 80
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.DataPropertyName = "ModifyTime"
        Me.DataGridViewTextBoxColumn35.HeaderText = "修改时间"
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        Me.DataGridViewTextBoxColumn35.ReadOnly = True
        Me.DataGridViewTextBoxColumn35.Width = 80
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.HeaderText = "修改时间"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        Me.DataGridViewTextBoxColumn36.ReadOnly = True
        Me.DataGridViewTextBoxColumn36.Width = 80
        '
        'FrmCustomerOrderMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1041, 535)
        Me.Controls.Add(Me.dtpEndTime)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.dtpStartTime)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.txtContractOrder)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.ToolBt)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.LabelX2)
        Me.Name = "FrmCustomerOrderMaster"
        Me.ShowIcon = False
        Me.Text = "合约订单管理"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        CType(Me.dgvCustomerOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvCustomerOrderItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCustomerOrderDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpStartTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpEndTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnModify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDeleteRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtContractOrder As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents dgvCustomerOrder As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvCustomerOrderDetail As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents dgvCustomerOrderItem As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAddRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents CustomerOrderID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeliveryCustomerId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeliveryCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModifiedVersion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContractDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerOrderNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TerminalCustomerOrderNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModifyUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModifyTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnAgain As System.Windows.Forms.ToolStripButton
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
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn35 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnSaveRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtpStartTime As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpEndTime As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents CustomerOrderItemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductSpecifications As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SKUQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Titlemini As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerOrderDetailID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FNSKU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExportingCountries As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingMethod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRDimensions As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerDelivery As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents ExportQuantity As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents PrinteQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackingQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StorageQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentsQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusFlagText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DCreateUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DCreateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DModifyUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DModifyTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
