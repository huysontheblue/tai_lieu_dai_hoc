<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMgWHPart
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMgWHPart))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtExport = New System.Windows.Forms.ToolStripButton()
        Me.BtRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtReturn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.CobArea = New System.Windows.Forms.ComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GB1 = New System.Windows.Forms.GroupBox()
        Me.CobPart = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DgWHList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TxtTmp = New System.Windows.Forms.TextBox()
        Me.BtSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtModify = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.BtNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtClose = New System.Windows.Forms.ToolStripButton()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1.SuspendLayout()
        Me.GB1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgWHList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolBt.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'BtExport
        '
        Me.BtExport.Image = CType(resources.GetObject("BtExport.Image"), System.Drawing.Image)
        Me.BtExport.ImageTransparentColor = System.Drawing.Color.White
        Me.BtExport.Name = "BtExport"
        Me.BtExport.Size = New System.Drawing.Size(74, 22)
        Me.BtExport.Text = "匯 出(&O)"
        Me.BtExport.ToolTipText = "匯出"
        '
        'BtRefresh
        '
        Me.BtRefresh.Image = CType(resources.GetObject("BtRefresh.Image"), System.Drawing.Image)
        Me.BtRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.BtRefresh.Name = "BtRefresh"
        Me.BtRefresh.Size = New System.Drawing.Size(72, 22)
        Me.BtRefresh.Text = "刷 新(&R)"
        Me.BtRefresh.ToolTipText = "刷新"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'BtReturn
        '
        Me.BtReturn.Image = CType(resources.GetObject("BtReturn.Image"), System.Drawing.Image)
        Me.BtReturn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtReturn.Name = "BtReturn"
        Me.BtReturn.Size = New System.Drawing.Size(72, 22)
        Me.BtReturn.Text = "返 回(&C)"
        Me.BtReturn.ToolTipText = "返回"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'CobArea
        '
        Me.CobArea.BackColor = System.Drawing.SystemColors.Window
        Me.CobArea.FormattingEnabled = True
        Me.CobArea.Location = New System.Drawing.Point(300, 14)
        Me.CobArea.Name = "CobArea"
        Me.CobArea.Size = New System.Drawing.Size(82, 20)
        Me.CobArea.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.ToolCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 390)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(701, 22)
        Me.StatusStrip1.TabIndex = 88
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(59, 17)
        Me.ToolStripStatusLabel3.Text = "记录笔数:"
        '
        'ToolCount
        '
        Me.ToolCount.BackColor = System.Drawing.SystemColors.Control
        Me.ToolCount.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ToolCount.Name = "ToolCount"
        Me.ToolCount.Size = New System.Drawing.Size(15, 17)
        Me.ToolCount.Text = "0"
        '
        'GB1
        '
        Me.GB1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB1.Controls.Add(Me.CobArea)
        Me.GB1.Controls.Add(Me.CobPart)
        Me.GB1.Controls.Add(Me.Label1)
        Me.GB1.Controls.Add(Me.Label2)
        Me.GB1.Location = New System.Drawing.Point(3, 27)
        Me.GB1.Name = "GB1"
        Me.GB1.Size = New System.Drawing.Size(698, 43)
        Me.GB1.TabIndex = 87
        Me.GB1.TabStop = False
        '
        'CobPart
        '
        Me.CobPart.BackColor = System.Drawing.SystemColors.Window
        Me.CobPart.FormattingEnabled = True
        Me.CobPart.Location = New System.Drawing.Point(71, 14)
        Me.CobPart.Name = "CobPart"
        Me.CobPart.Size = New System.Drawing.Size(122, 20)
        Me.CobPart.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "料件编号:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(238, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "储位名称:"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 69)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(701, 318)
        Me.Panel1.TabIndex = 90
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DgWHList)
        Me.GroupBox1.Controls.Add(Me.TxtTmp)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(701, 318)
        Me.GroupBox1.TabIndex = 82
        Me.GroupBox1.TabStop = False
        '
        'DgWHList
        '
        Me.DgWHList.AllowUserToAddRows = False
        Me.DgWHList.AllowUserToDeleteRows = False
        Me.DgWHList.AllowUserToOrderColumns = True
        Me.DgWHList.BackgroundColor = System.Drawing.Color.White
        Me.DgWHList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgWHList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgWHList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column5, Me.Column6, Me.Column7})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgWHList.DefaultCellStyle = DataGridViewCellStyle1
        Me.DgWHList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgWHList.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DgWHList.Location = New System.Drawing.Point(3, 17)
        Me.DgWHList.Name = "DgWHList"
        Me.DgWHList.RowHeadersWidth = 4
        Me.DgWHList.RowTemplate.Height = 23
        Me.DgWHList.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.[Default]
        Me.DgWHList.Size = New System.Drawing.Size(695, 298)
        Me.DgWHList.TabIndex = 36
        '
        'TxtTmp
        '
        Me.TxtTmp.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtTmp.Location = New System.Drawing.Point(316, 137)
        Me.TxtTmp.Name = "TxtTmp"
        Me.TxtTmp.Size = New System.Drawing.Size(22, 21)
        Me.TxtTmp.TabIndex = 35
        '
        'BtSave
        '
        Me.BtSave.Image = CType(resources.GetObject("BtSave.Image"), System.Drawing.Image)
        Me.BtSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtSave.Name = "BtSave"
        Me.BtSave.Size = New System.Drawing.Size(71, 22)
        Me.BtSave.Text = "保 存(&S)"
        Me.BtSave.ToolTipText = "保存"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'BtDelete
        '
        Me.BtDelete.Image = CType(resources.GetObject("BtDelete.Image"), System.Drawing.Image)
        Me.BtDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtDelete.Name = "BtDelete"
        Me.BtDelete.Size = New System.Drawing.Size(73, 22)
        Me.BtDelete.Text = "刪 除(&D)"
        Me.BtDelete.ToolTipText = "作廢"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'BtModify
        '
        Me.BtModify.Image = CType(resources.GetObject("BtModify.Image"), System.Drawing.Image)
        Me.BtModify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtModify.Name = "BtModify"
        Me.BtModify.Size = New System.Drawing.Size(71, 22)
        Me.BtModify.Text = "修 改(&E)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolBt
        '
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.BtNew, Me.ToolStripSeparator3, Me.BtModify, Me.ToolStripSeparator4, Me.BtDelete, Me.ToolStripSeparator5, Me.BtSave, Me.ToolStripSeparator2, Me.BtReturn, Me.ToolStripSeparator6, Me.BtExport, Me.ToolStripSeparator7, Me.BtRefresh, Me.ToolStripSeparator9, Me.BtClose})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(701, 25)
        Me.ToolBt.TabIndex = 89
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'BtNew
        '
        Me.BtNew.Image = CType(resources.GetObject("BtNew.Image"), System.Drawing.Image)
        Me.BtNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtNew.Name = "BtNew"
        Me.BtNew.Size = New System.Drawing.Size(74, 22)
        Me.BtNew.Text = "新 增(&N)"
        Me.BtNew.ToolTipText = "新增"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BtClose
        '
        Me.BtClose.ForeColor = System.Drawing.Color.Black
        Me.BtClose.Image = CType(resources.GetObject("BtClose.Image"), System.Drawing.Image)
        Me.BtClose.ImageTransparentColor = System.Drawing.Color.White
        Me.BtClose.Name = "BtClose"
        Me.BtClose.Size = New System.Drawing.Size(72, 22)
        Me.BtClose.Text = "退 出(&X)"
        Me.BtClose.ToolTipText = "退 出"
        '
        'Column3
        '
        Me.Column3.HeaderText = "产品料号"
        Me.Column3.Name = "Column3"
        '
        'Column5
        '
        Me.Column5.HeaderText = "储位名称"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "设置人员"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "设置时间"
        Me.Column7.Name = "Column7"
        '
        'FrmMgWHPart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 412)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GB1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolBt)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMgWHPart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "料件儲位維護"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GB1.ResumeLayout(False)
        Me.GB1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgWHList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtReturn As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CobArea As System.Windows.Forms.ComboBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GB1 As System.Windows.Forms.GroupBox
    Friend WithEvents CobPart As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtTmp As System.Windows.Forms.TextBox
    Friend WithEvents BtSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtModify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents BtNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents DgWHList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
