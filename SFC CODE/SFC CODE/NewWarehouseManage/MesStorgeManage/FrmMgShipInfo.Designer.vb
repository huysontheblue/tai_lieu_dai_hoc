<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMgShipInfo
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMgShipInfo))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtModify = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtDrop = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DGItem = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComboPart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCout = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtItem = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtQty = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtPartNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.BtDNew = New System.Windows.Forms.ToolStripButton()
        Me.BtDEdit = New System.Windows.Forms.ToolStripButton()
        Me.BtDDel = New System.Windows.Forms.ToolStripButton()
        Me.BtDConfirm = New System.Windows.Forms.ToolStripButton()
        Me.BtDReturn = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkCreate = New System.Windows.Forms.CheckBox()
        Me.TxtCusID = New System.Windows.Forms.TextBox()
        Me.TxtInvoice = New System.Windows.Forms.TextBox()
        Me.CobFacory = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CobAddress = New System.Windows.Forms.ComboBox()
        Me.BtLoad = New System.Windows.Forms.Button()
        Me.CobInvoice = New System.Windows.Forms.ComboBox()
        Me.CobCust = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolLblCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtNew, Me.ToolStripSeparator1, Me.BtModify, Me.ToolStripSeparator5, Me.BtDrop, Me.ToolStripSeparator3, Me.BtSave, Me.ToolStripSeparator4, Me.BtCancel, Me.ToolStripSeparator2, Me.BtBack, Me.ToolStripLabel1, Me.ToolStripLabel2, Me.ToolStripLabel4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1001, 25)
        Me.ToolStrip1.TabIndex = 14
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtNew
        '
        Me.BtNew.Image = CType(resources.GetObject("BtNew.Image"), System.Drawing.Image)
        Me.BtNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtNew.Name = "BtNew"
        Me.BtNew.Size = New System.Drawing.Size(74, 22)
        Me.BtNew.Text = "新 增(&N)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BtModify
        '
        Me.BtModify.Image = CType(resources.GetObject("BtModify.Image"), System.Drawing.Image)
        Me.BtModify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtModify.Name = "BtModify"
        Me.BtModify.Size = New System.Drawing.Size(71, 22)
        Me.BtModify.Text = "修 改(&E)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'BtDrop
        '
        Me.BtDrop.Image = CType(resources.GetObject("BtDrop.Image"), System.Drawing.Image)
        Me.BtDrop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtDrop.Name = "BtDrop"
        Me.BtDrop.Size = New System.Drawing.Size(73, 22)
        Me.BtDrop.Text = "刪 除(&D)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BtSave
        '
        Me.BtSave.Image = CType(resources.GetObject("BtSave.Image"), System.Drawing.Image)
        Me.BtSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtSave.Name = "BtSave"
        Me.BtSave.Size = New System.Drawing.Size(71, 22)
        Me.BtSave.Text = "保 存(&S)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'BtCancel
        '
        Me.BtCancel.Image = CType(resources.GetObject("BtCancel.Image"), System.Drawing.Image)
        Me.BtCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(72, 22)
        Me.BtCancel.Text = "返 回(&C)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BtBack
        '
        Me.BtBack.ForeColor = System.Drawing.Color.Black
        Me.BtBack.Image = CType(resources.GetObject("BtBack.Image"), System.Drawing.Image)
        Me.BtBack.ImageTransparentColor = System.Drawing.Color.White
        Me.BtBack.Name = "BtBack"
        Me.BtBack.Size = New System.Drawing.Size(72, 22)
        Me.BtBack.Text = "退 出(&X)"
        Me.BtBack.ToolTipText = "退 出"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(0, 22)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(0, 22)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(16, 22)
        Me.ToolStripLabel4.Text = "  "
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.DGItem)
        Me.GroupBox2.Controls.Add(Me.TxtItem)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TxtQty)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TxtPartNo)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.ToolStrip2)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox2.Location = New System.Drawing.Point(4, 174)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(997, 364)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "出货明细"
        '
        'DGItem
        '
        Me.DGItem.AllowUserToAddRows = False
        Me.DGItem.AllowUserToDeleteRows = False
        Me.DGItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGItem.BackgroundColor = System.Drawing.Color.White
        Me.DGItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.ComboPart, Me.ColCout, Me.Column7, Me.Column8})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGItem.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGItem.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.DGItem.Location = New System.Drawing.Point(3, 88)
        Me.DGItem.Name = "DGItem"
        Me.DGItem.ReadOnly = True
        Me.DGItem.RowHeadersWidth = 4
        Me.DGItem.RowTemplate.Height = 23
        Me.DGItem.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.[Default]
        Me.DGItem.Size = New System.Drawing.Size(991, 276)
        Me.DGItem.TabIndex = 14
        '
        'Column4
        '
        Me.Column4.HeaderText = "项次"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'ComboPart
        '
        Me.ComboPart.HeaderText = "料件编号"
        Me.ComboPart.Name = "ComboPart"
        Me.ComboPart.ReadOnly = True
        '
        'ColCout
        '
        Me.ColCout.HeaderText = "出货数量"
        Me.ColCout.Name = "ColCout"
        Me.ColCout.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "操作时间"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "操作人员"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'TxtItem
        '
        Me.TxtItem.Location = New System.Drawing.Point(51, 50)
        Me.TxtItem.Name = "TxtItem"
        Me.TxtItem.Size = New System.Drawing.Size(45, 21)
        Me.TxtItem.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 12)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "项次:"
        '
        'TxtQty
        '
        Me.TxtQty.Location = New System.Drawing.Point(387, 50)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(106, 21)
        Me.TxtQty.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(325, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "出货数量:"
        '
        'TxtPartNo
        '
        Me.TxtPartNo.Location = New System.Drawing.Point(162, 50)
        Me.TxtPartNo.Name = "TxtPartNo"
        Me.TxtPartNo.Size = New System.Drawing.Size(149, 21)
        Me.TxtPartNo.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(102, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "料件编号:"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtDNew, Me.BtDEdit, Me.BtDDel, Me.BtDConfirm, Me.BtDReturn})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 17)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip2.Size = New System.Drawing.Size(991, 25)
        Me.ToolStrip2.TabIndex = 7
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'BtDNew
        '
        Me.BtDNew.ForeColor = System.Drawing.Color.Black
        Me.BtDNew.Image = CType(resources.GetObject("BtDNew.Image"), System.Drawing.Image)
        Me.BtDNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtDNew.Name = "BtDNew"
        Me.BtDNew.Size = New System.Drawing.Size(56, 22)
        Me.BtDNew.Text = "新 增"
        '
        'BtDEdit
        '
        Me.BtDEdit.ForeColor = System.Drawing.Color.Black
        Me.BtDEdit.Image = CType(resources.GetObject("BtDEdit.Image"), System.Drawing.Image)
        Me.BtDEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtDEdit.Name = "BtDEdit"
        Me.BtDEdit.Size = New System.Drawing.Size(56, 22)
        Me.BtDEdit.Text = "修 改"
        '
        'BtDDel
        '
        Me.BtDDel.ForeColor = System.Drawing.Color.Black
        Me.BtDDel.Image = CType(resources.GetObject("BtDDel.Image"), System.Drawing.Image)
        Me.BtDDel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtDDel.Name = "BtDDel"
        Me.BtDDel.Size = New System.Drawing.Size(56, 22)
        Me.BtDDel.Text = "刪 除"
        '
        'BtDConfirm
        '
        Me.BtDConfirm.ForeColor = System.Drawing.Color.Black
        Me.BtDConfirm.Image = CType(resources.GetObject("BtDConfirm.Image"), System.Drawing.Image)
        Me.BtDConfirm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtDConfirm.Name = "BtDConfirm"
        Me.BtDConfirm.Size = New System.Drawing.Size(56, 22)
        Me.BtDConfirm.Text = "確 定"
        '
        'BtDReturn
        '
        Me.BtDReturn.ForeColor = System.Drawing.Color.Black
        Me.BtDReturn.Image = CType(resources.GetObject("BtDReturn.Image"), System.Drawing.Image)
        Me.BtDReturn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtDReturn.Name = "BtDReturn"
        Me.BtDReturn.Size = New System.Drawing.Size(56, 22)
        Me.BtDReturn.Text = "返 回"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chkCreate)
        Me.GroupBox1.Controls.Add(Me.TxtCusID)
        Me.GroupBox1.Controls.Add(Me.TxtInvoice)
        Me.GroupBox1.Controls.Add(Me.CobFacory)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CobAddress)
        Me.GroupBox1.Controls.Add(Me.BtLoad)
        Me.GroupBox1.Controls.Add(Me.CobInvoice)
        Me.GroupBox1.Controls.Add(Me.CobCust)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox1.Location = New System.Drawing.Point(4, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(993, 137)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "基本资料"
        '
        'chkCreate
        '
        Me.chkCreate.AutoSize = True
        Me.chkCreate.Location = New System.Drawing.Point(235, 17)
        Me.chkCreate.Name = "chkCreate"
        Me.chkCreate.Size = New System.Drawing.Size(246, 16)
        Me.chkCreate.TabIndex = 2
        Me.chkCreate.Text = "自动生成(用于无Invoice號的出貨需求。)"
        Me.chkCreate.UseVisualStyleBackColor = True
        '
        'TxtCusID
        '
        Me.TxtCusID.Location = New System.Drawing.Point(384, 104)
        Me.TxtCusID.Name = "TxtCusID"
        Me.TxtCusID.Size = New System.Drawing.Size(124, 21)
        Me.TxtCusID.TabIndex = 100
        Me.TxtCusID.TabStop = False
        '
        'TxtInvoice
        '
        Me.TxtInvoice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtInvoice.Location = New System.Drawing.Point(79, 15)
        Me.TxtInvoice.Name = "TxtInvoice"
        Me.TxtInvoice.Size = New System.Drawing.Size(140, 21)
        Me.TxtInvoice.TabIndex = 1
        '
        'CobFacory
        '
        Me.CobFacory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobFacory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CobFacory.FormattingEnabled = True
        Me.CobFacory.Location = New System.Drawing.Point(79, 45)
        Me.CobFacory.Name = "CobFacory"
        Me.CobFacory.Size = New System.Drawing.Size(83, 23)
        Me.CobFacory.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "工厂别:"
        '
        'CobAddress
        '
        Me.CobAddress.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CobAddress.FormattingEnabled = True
        Me.CobAddress.Location = New System.Drawing.Point(79, 103)
        Me.CobAddress.Name = "CobAddress"
        Me.CobAddress.Size = New System.Drawing.Size(300, 23)
        Me.CobAddress.TabIndex = 5
        '
        'BtLoad
        '
        Me.BtLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtLoad.Location = New System.Drawing.Point(285, 103)
        Me.BtLoad.Name = "BtLoad"
        Me.BtLoad.Size = New System.Drawing.Size(67, 21)
        Me.BtLoad.TabIndex = 2
        Me.BtLoad.Text = "Load"
        Me.BtLoad.UseVisualStyleBackColor = True
        Me.BtLoad.Visible = False
        '
        'CobInvoice
        '
        Me.CobInvoice.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CobInvoice.FormattingEnabled = True
        Me.CobInvoice.Location = New System.Drawing.Point(79, 14)
        Me.CobInvoice.Name = "CobInvoice"
        Me.CobInvoice.Size = New System.Drawing.Size(140, 23)
        Me.CobInvoice.TabIndex = 1
        '
        'CobCust
        '
        Me.CobCust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobCust.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CobCust.FormattingEnabled = True
        Me.CobCust.Location = New System.Drawing.Point(79, 74)
        Me.CobCust.Name = "CobCust"
        Me.CobCust.Size = New System.Drawing.Size(136, 23)
        Me.CobCust.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "客户地址:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "客户名称:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Invoice No："
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolLblCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 541)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1001, 22)
        Me.StatusStrip1.TabIndex = 121
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(59, 17)
        Me.ToolStripStatusLabel1.Text = "记录笔数:"
        '
        'ToolLblCount
        '
        Me.ToolLblCount.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolLblCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ToolLblCount.LinkColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ToolLblCount.Name = "ToolLblCount"
        Me.ToolLblCount.Size = New System.Drawing.Size(12, 17)
        Me.ToolLblCount.Text = "0"
        '
        'FrmMgShipInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1001, 563)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMgShipInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "单据维护"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DGItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtModify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtDrop As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCusID As System.Windows.Forms.TextBox
    Friend WithEvents TxtInvoice As System.Windows.Forms.TextBox
    Friend WithEvents CobFacory As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CobAddress As System.Windows.Forms.ComboBox
    Friend WithEvents BtLoad As System.Windows.Forms.Button
    Friend WithEvents CobInvoice As System.Windows.Forms.ComboBox
    Friend WithEvents CobCust As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkCreate As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtDNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtDDel As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtDEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtPartNo As System.Windows.Forms.TextBox
    Friend WithEvents TxtItem As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtDConfirm As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtDReturn As System.Windows.Forms.ToolStripButton
    Friend WithEvents DGItem As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComboPart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCout As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolLblCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtBack As System.Windows.Forms.ToolStripButton
End Class
