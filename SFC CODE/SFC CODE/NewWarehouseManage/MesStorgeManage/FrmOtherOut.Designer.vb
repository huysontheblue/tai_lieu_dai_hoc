<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOtherOut
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOtherOut))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CobFacory = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkCreate = New System.Windows.Forms.CheckBox()
        Me.TxtInvoice = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.DGItem = New System.Windows.Forms.DataGridView()
        Me.ComboPart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCout = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.BtDNew = New System.Windows.Forms.ToolStripButton()
        Me.BtDEdit = New System.Windows.Forms.ToolStripButton()
        Me.BtDDel = New System.Windows.Forms.ToolStripButton()
        Me.BtDSave = New System.Windows.Forms.ToolStripButton()
        Me.BtDReturn = New System.Windows.Forms.ToolStripButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtPartNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtQty = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolLblCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CobOuttype = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DGItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CobFacory
        '
        Me.CobFacory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobFacory.Enabled = False
        Me.CobFacory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CobFacory.FormattingEnabled = True
        Me.CobFacory.Items.AddRange(New Object() {"SZ-奇宏", "CN-興奇宏"})
        Me.CobFacory.Location = New System.Drawing.Point(361, 29)
        Me.CobFacory.Name = "CobFacory"
        Me.CobFacory.Size = New System.Drawing.Size(123, 23)
        Me.CobFacory.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(299, 34)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 12)
        Me.Label12.TabIndex = 99
        Me.Label12.Text = "工廠別："
        '
        'chkCreate
        '
        Me.chkCreate.AutoSize = True
        Me.chkCreate.Enabled = False
        Me.chkCreate.Location = New System.Drawing.Point(221, 32)
        Me.chkCreate.Name = "chkCreate"
        Me.chkCreate.Size = New System.Drawing.Size(72, 16)
        Me.chkCreate.TabIndex = 2
        Me.chkCreate.Text = "自動生成"
        Me.chkCreate.UseVisualStyleBackColor = True
        '
        'TxtInvoice
        '
        Me.TxtInvoice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtInvoice.Enabled = False
        Me.TxtInvoice.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInvoice.Location = New System.Drawing.Point(82, 30)
        Me.TxtInvoice.MaxLength = 10
        Me.TxtInvoice.Name = "TxtInvoice"
        Me.TxtInvoice.Size = New System.Drawing.Size(128, 21)
        Me.TxtInvoice.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 12)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Invoice No.："
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtNew, Me.ToolStripSeparator1, Me.BtEdit, Me.ToolStripSeparator5, Me.BtSave, Me.ToolStripSeparator4, Me.BtCancel, Me.ToolStripSeparator2, Me.BtExit, Me.ToolStripLabel1, Me.ToolStripLabel2, Me.ToolStripLabel4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(610, 25)
        Me.ToolStrip1.TabIndex = 115
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
        'BtEdit
        '
        Me.BtEdit.Image = CType(resources.GetObject("BtEdit.Image"), System.Drawing.Image)
        Me.BtEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtEdit.Name = "BtEdit"
        Me.BtEdit.Size = New System.Drawing.Size(71, 22)
        Me.BtEdit.Text = "修 改(&E)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
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
        Me.BtCancel.Enabled = False
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
        'BtExit
        '
        Me.BtExit.ForeColor = System.Drawing.Color.Black
        Me.BtExit.Image = CType(resources.GetObject("BtExit.Image"), System.Drawing.Image)
        Me.BtExit.ImageTransparentColor = System.Drawing.Color.White
        Me.BtExit.Name = "BtExit"
        Me.BtExit.Size = New System.Drawing.Size(72, 22)
        Me.BtExit.Text = "退 出(&X)"
        Me.BtExit.ToolTipText = "退 出"
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
        'DGItem
        '
        Me.DGItem.AllowUserToAddRows = False
        Me.DGItem.AllowUserToDeleteRows = False
        Me.DGItem.AllowUserToResizeColumns = False
        Me.DGItem.AllowUserToResizeRows = False
        Me.DGItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGItem.BackgroundColor = System.Drawing.Color.White
        Me.DGItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGItem.ColumnHeadersHeight = 24
        Me.DGItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ComboPart, Me.ColCout, Me.Column2, Me.Column1})
        Me.DGItem.Location = New System.Drawing.Point(3, 73)
        Me.DGItem.Name = "DGItem"
        Me.DGItem.ReadOnly = True
        Me.DGItem.RowHeadersVisible = False
        Me.DGItem.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DGItem.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGItem.RowTemplate.Height = 24
        Me.DGItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DGItem.Size = New System.Drawing.Size(604, 224)
        Me.DGItem.TabIndex = 6
        '
        'ComboPart
        '
        Me.ComboPart.HeaderText = "料件編號"
        Me.ComboPart.Name = "ComboPart"
        Me.ComboPart.ReadOnly = True
        Me.ComboPart.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ComboPart.Width = 130
        '
        'ColCout
        '
        Me.ColCout.HeaderText = "出貨數量"
        Me.ColCout.Name = "ColCout"
        Me.ColCout.ReadOnly = True
        Me.ColCout.Width = 70
        '
        'Column2
        '
        Me.Column2.HeaderText = "操作人員"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 70
        '
        'Column1
        '
        Me.Column1.HeaderText = "操作時間"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtDNew, Me.BtDEdit, Me.BtDDel, Me.BtDSave, Me.BtDReturn})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 17)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip2.Size = New System.Drawing.Size(604, 25)
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
        'BtDSave
        '
        Me.BtDSave.Enabled = False
        Me.BtDSave.ForeColor = System.Drawing.Color.Black
        Me.BtDSave.Image = CType(resources.GetObject("BtDSave.Image"), System.Drawing.Image)
        Me.BtDSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtDSave.Name = "BtDSave"
        Me.BtDSave.Size = New System.Drawing.Size(52, 22)
        Me.BtDSave.Text = "保存"
        '
        'BtDReturn
        '
        Me.BtDReturn.Enabled = False
        Me.BtDReturn.ForeColor = System.Drawing.Color.Black
        Me.BtDReturn.Image = CType(resources.GetObject("BtDReturn.Image"), System.Drawing.Image)
        Me.BtDReturn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtDReturn.Name = "BtDReturn"
        Me.BtDReturn.Size = New System.Drawing.Size(56, 22)
        Me.BtDReturn.Text = "返 回"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 12)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "料件編號："
        '
        'TxtPartNo
        '
        Me.TxtPartNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPartNo.Enabled = False
        Me.TxtPartNo.Location = New System.Drawing.Point(82, 47)
        Me.TxtPartNo.Name = "TxtPartNo"
        Me.TxtPartNo.Size = New System.Drawing.Size(128, 21)
        Me.TxtPartNo.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(218, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "出貨數量："
        '
        'TxtQty
        '
        Me.TxtQty.Enabled = False
        Me.TxtQty.Location = New System.Drawing.Point(280, 47)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(66, 21)
        Me.TxtQty.TabIndex = 10
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.StatusStrip1)
        Me.GroupBox2.Controls.Add(Me.TxtQty)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TxtPartNo)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.ToolStrip2)
        Me.GroupBox2.Controls.Add(Me.DGItem)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox2.Location = New System.Drawing.Point(0, 88)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(610, 319)
        Me.GroupBox2.TabIndex = 114
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "出貨明細："
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolLblCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 294)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(604, 22)
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 116
        Me.Label2.Text = "出貨類型："
        '
        'CobOuttype
        '
        Me.CobOuttype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobOuttype.Enabled = False
        Me.CobOuttype.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CobOuttype.FormattingEnabled = True
        Me.CobOuttype.Items.AddRange(New Object() {"O-正常出貨", "S-樣品出貨", "I-內部領料", "T-其它出貨"})
        Me.CobOuttype.Location = New System.Drawing.Point(82, 59)
        Me.CobOuttype.Name = "CobOuttype"
        Me.CobOuttype.Size = New System.Drawing.Size(128, 23)
        Me.CobOuttype.TabIndex = 4
        '
        'FrmOtherOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 410)
        Me.Controls.Add(Me.CobOuttype)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtInvoice)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkCreate)
        Me.Controls.Add(Me.CobFacory)
        Me.Controls.Add(Me.Label12)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmOtherOut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "其它出貨"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DGItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CobFacory As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkCreate As System.Windows.Forms.CheckBox
    Friend WithEvents TxtInvoice As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DGItem As System.Windows.Forms.DataGridView
    Friend WithEvents ComboPart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCout As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtDNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtDEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtDDel As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtDSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtDReturn As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtPartNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtQty As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CobOuttype As System.Windows.Forms.ComboBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolLblCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtExit As System.Windows.Forms.ToolStripButton
End Class
