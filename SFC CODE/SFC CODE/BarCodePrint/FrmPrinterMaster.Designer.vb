<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrinterMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrinterMaster))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolLblCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolCommit = New System.Windows.Forms.ToolStripButton()
        Me.ToolBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cbxStatus = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.cboPrintType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.txtPrintIP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.txtPrintName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.dgvPrintList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.IDE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRINT_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRINT_IP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TYPE_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STATUS_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolBt.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvPrintList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel1.Text = "记录笔数："
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolLblCount, Me.lblMessage})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 475)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1013, 22)
        Me.StatusStrip1.TabIndex = 132
        Me.StatusStrip1.Text = "StatusStrip1"
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
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.lblMessage.LinkColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(15, 17)
        Me.lblMessage.Text = "0"
        '
        'ToolBt
        '
        Me.ToolBt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNew, Me.ToolEdit, Me.ToolCancel, Me.ToolCommit, Me.ToolBack, Me.ToolStripSeparator3, Me.ToolStripSeparator2, Me.ToolQuery, Me.ToolExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 2)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(524, 25)
        Me.ToolBt.TabIndex = 131
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolNew
        '
        Me.ToolNew.ForeColor = System.Drawing.Color.Black
        Me.ToolNew.Image = CType(resources.GetObject("ToolNew.Image"), System.Drawing.Image)
        Me.ToolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolNew.Name = "ToolNew"
        Me.ToolNew.Size = New System.Drawing.Size(74, 22)
        Me.ToolNew.Tag = "NO"
        Me.ToolNew.Text = "新 增(&N)"
        Me.ToolNew.ToolTipText = "新 增"
        '
        'ToolEdit
        '
        Me.ToolEdit.ForeColor = System.Drawing.Color.Black
        Me.ToolEdit.Image = CType(resources.GetObject("ToolEdit.Image"), System.Drawing.Image)
        Me.ToolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEdit.Name = "ToolEdit"
        Me.ToolEdit.Size = New System.Drawing.Size(71, 22)
        Me.ToolEdit.Tag = "NO"
        Me.ToolEdit.Text = "修 改(&E)"
        Me.ToolEdit.ToolTipText = "修 改"
        '
        'ToolCancel
        '
        Me.ToolCancel.ForeColor = System.Drawing.Color.Black
        Me.ToolCancel.Image = CType(resources.GetObject("ToolCancel.Image"), System.Drawing.Image)
        Me.ToolCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCancel.Name = "ToolCancel"
        Me.ToolCancel.Size = New System.Drawing.Size(73, 22)
        Me.ToolCancel.Tag = "NO"
        Me.ToolCancel.Text = "作 废(&D)"
        Me.ToolCancel.ToolTipText = "作 廢"
        '
        'ToolCommit
        '
        Me.ToolCommit.Image = CType(resources.GetObject("ToolCommit.Image"), System.Drawing.Image)
        Me.ToolCommit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCommit.Name = "ToolCommit"
        Me.ToolCommit.Size = New System.Drawing.Size(68, 22)
        Me.ToolCommit.Tag = ""
        Me.ToolCommit.Text = "提交(&C)"
        Me.ToolCommit.ToolTipText = "提交"
        '
        'ToolBack
        '
        Me.ToolBack.Image = CType(resources.GetObject("ToolBack.Image"), System.Drawing.Image)
        Me.ToolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolBack.Name = "ToolBack"
        Me.ToolBack.Size = New System.Drawing.Size(68, 22)
        Me.ToolBack.Text = "返回(&B)"
        Me.ToolBack.ToolTipText = "返回"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'ToolExitFrom
        '
        Me.ToolExitFrom.ForeColor = System.Drawing.Color.Black
        Me.ToolExitFrom.Image = CType(resources.GetObject("ToolExitFrom.Image"), System.Drawing.Image)
        Me.ToolExitFrom.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolExitFrom.Name = "ToolExitFrom"
        Me.ToolExitFrom.Size = New System.Drawing.Size(72, 21)
        Me.ToolExitFrom.Text = "退 出(&X)"
        Me.ToolExitFrom.ToolTipText = "退 出"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.cbxStatus)
        Me.Panel2.Controls.Add(Me.LabelX4)
        Me.Panel2.Controls.Add(Me.cboPrintType)
        Me.Panel2.Controls.Add(Me.LabelX3)
        Me.Panel2.Controls.Add(Me.txtPrintIP)
        Me.Panel2.Controls.Add(Me.LabelX2)
        Me.Panel2.Controls.Add(Me.txtPrintName)
        Me.Panel2.Controls.Add(Me.LabelX1)
        Me.Panel2.Location = New System.Drawing.Point(0, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1019, 111)
        Me.Panel2.TabIndex = 135
        '
        'cbxStatus
        '
        '
        '
        '
        Me.cbxStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxStatus.Location = New System.Drawing.Point(369, 48)
        Me.cbxStatus.Name = "cbxStatus"
        Me.cbxStatus.Size = New System.Drawing.Size(100, 23)
        Me.cbxStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxStatus.TabIndex = 8
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(327, 49)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(64, 23)
        Me.LabelX4.TabIndex = 7
        Me.LabelX4.Text = "可用："
        '
        'cboPrintType
        '
        Me.cboPrintType.AutoCompleteCustomSource.AddRange(New String() {"网络", "共享"})
        Me.cboPrintType.DisplayMember = "Text"
        Me.cboPrintType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboPrintType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrintType.FormattingEnabled = True
        Me.cboPrintType.ItemHeight = 15
        Me.cboPrintType.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2})
        Me.cboPrintType.Location = New System.Drawing.Point(111, 49)
        Me.cboPrintType.Name = "cboPrintType"
        Me.cboPrintType.Size = New System.Drawing.Size(123, 21)
        Me.cboPrintType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboPrintType.TabIndex = 6
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "共享打印机"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "网络打印机"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(65, 49)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(64, 23)
        Me.LabelX3.TabIndex = 5
        Me.LabelX3.Text = "类型："
        '
        'txtPrintIP
        '
        '
        '
        '
        Me.txtPrintIP.Border.Class = "TextBoxBorder"
        Me.txtPrintIP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPrintIP.Location = New System.Drawing.Point(371, 15)
        Me.txtPrintIP.Name = "txtPrintIP"
        Me.txtPrintIP.Size = New System.Drawing.Size(171, 21)
        Me.txtPrintIP.TabIndex = 4
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(316, 15)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(101, 23)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "IP地址："
        '
        'txtPrintName
        '
        '
        '
        '
        Me.txtPrintName.Border.Class = "TextBoxBorder"
        Me.txtPrintName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPrintName.Location = New System.Drawing.Point(111, 15)
        Me.txtPrintName.Name = "txtPrintName"
        Me.txtPrintName.Size = New System.Drawing.Size(171, 21)
        Me.txtPrintName.TabIndex = 2
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(28, 15)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(101, 23)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "打印机名称："
        '
        'dgvPrintList
        '
        Me.dgvPrintList.AllowUserToAddRows = False
        Me.dgvPrintList.AllowUserToDeleteRows = False
        Me.dgvPrintList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPrintList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrintList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPrintList.ColumnHeadersHeight = 25
        Me.dgvPrintList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDE, Me.PRINT_NAME, Me.PRINT_IP, Me.TYPE_ID, Me.STATUS_NAME})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPrintList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPrintList.EnableHeadersVisualStyles = False
        Me.dgvPrintList.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvPrintList.Location = New System.Drawing.Point(0, 122)
        Me.dgvPrintList.MultiSelect = False
        Me.dgvPrintList.Name = "dgvPrintList"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrintList.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPrintList.RowHeadersWidth = 20
        Me.dgvPrintList.RowTemplate.Height = 23
        Me.dgvPrintList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPrintList.Size = New System.Drawing.Size(1013, 350)
        Me.dgvPrintList.TabIndex = 136
        '
        'IDE
        '
        Me.IDE.HeaderText = "IDE"
        Me.IDE.Name = "IDE"
        Me.IDE.Visible = False
        '
        'PRINT_NAME
        '
        Me.PRINT_NAME.HeaderText = "打印机名称"
        Me.PRINT_NAME.Name = "PRINT_NAME"
        Me.PRINT_NAME.ReadOnly = True
        '
        'PRINT_IP
        '
        Me.PRINT_IP.HeaderText = "IP地址"
        Me.PRINT_IP.Name = "PRINT_IP"
        Me.PRINT_IP.ReadOnly = True
        '
        'TYPE_ID
        '
        Me.TYPE_ID.HeaderText = "类型"
        Me.TYPE_ID.Name = "TYPE_ID"
        Me.TYPE_ID.ReadOnly = True
        '
        'STATUS_NAME
        '
        Me.STATUS_NAME.HeaderText = "状态"
        Me.STATUS_NAME.Name = "STATUS_NAME"
        Me.STATUS_NAME.ReadOnly = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "打印机名称"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "IP地址"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "类型"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "状态"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "状态"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'FrmPrinterMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 497)
        Me.Controls.Add(Me.dgvPrintList)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmPrinterMaster"
        Me.Text = "打印机维护"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvPrintList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolLblCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolCommit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvPrintList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtPrintName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtPrintIP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboPrintType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cbxStatus As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents IDE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRINT_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRINT_IP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TYPE_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STATUS_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
