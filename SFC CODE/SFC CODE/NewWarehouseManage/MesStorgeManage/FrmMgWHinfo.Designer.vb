<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMgWHinfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMgWHinfo))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CkbControl = New System.Windows.Forms.CheckBox()
        Me.CobWHName = New System.Windows.Forms.ComboBox()
        Me.CobWHID = New System.Windows.Forms.ComboBox()
        Me.TxtRemark = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CobFactory = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CobFloor = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtModify = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtReturn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.Toolfind = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.Toolreflash = New System.Windows.Forms.ToolStripButton()
        Me.BtClose = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Chkusey = New System.Windows.Forms.CheckBox()
        Me.DgWHList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ColSit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColStationName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Colusey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolBt.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DgWHList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CkbControl
        '
        Me.CkbControl.AutoSize = True
        Me.CkbControl.Location = New System.Drawing.Point(588, 49)
        Me.CkbControl.Name = "CkbControl"
        Me.CkbControl.Size = New System.Drawing.Size(60, 16)
        Me.CkbControl.TabIndex = 15
        Me.CkbControl.Text = "管制仓"
        Me.CkbControl.UseVisualStyleBackColor = True
        '
        'CobWHName
        '
        Me.CobWHName.BackColor = System.Drawing.SystemColors.Window
        Me.CobWHName.FormattingEnabled = True
        Me.CobWHName.Location = New System.Drawing.Point(263, 47)
        Me.CobWHName.Name = "CobWHName"
        Me.CobWHName.Size = New System.Drawing.Size(158, 20)
        Me.CobWHName.TabIndex = 14
        '
        'CobWHID
        '
        Me.CobWHID.BackColor = System.Drawing.SystemColors.Window
        Me.CobWHID.FormattingEnabled = True
        Me.CobWHID.Location = New System.Drawing.Point(74, 47)
        Me.CobWHID.Name = "CobWHID"
        Me.CobWHID.Size = New System.Drawing.Size(109, 20)
        Me.CobWHID.TabIndex = 13
        '
        'TxtRemark
        '
        Me.TxtRemark.BackColor = System.Drawing.SystemColors.Window
        Me.TxtRemark.Location = New System.Drawing.Point(263, 73)
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(310, 21)
        Me.TxtRemark.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(199, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 12)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "备  注:"
        '
        'CobFactory
        '
        Me.CobFactory.BackColor = System.Drawing.SystemColors.Window
        Me.CobFactory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobFactory.FormattingEnabled = True
        Me.CobFactory.Location = New System.Drawing.Point(487, 47)
        Me.CobFactory.Name = "CobFactory"
        Me.CobFactory.Size = New System.Drawing.Size(86, 20)
        Me.CobFactory.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(437, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 12)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "工厂别:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "仓库编号:"
        '
        'CobFloor
        '
        Me.CobFloor.BackColor = System.Drawing.SystemColors.Window
        Me.CobFloor.FormattingEnabled = True
        Me.CobFloor.Location = New System.Drawing.Point(73, 74)
        Me.CobFloor.Name = "CobFloor"
        Me.CobFloor.Size = New System.Drawing.Size(110, 20)
        Me.CobFloor.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "仓库位置:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(199, 51)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(59, 12)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "仓库名称:"
        '
        'ToolBt
        '
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.BtNew, Me.ToolStripSeparator3, Me.BtModify, Me.ToolStripSeparator4, Me.BtDelete, Me.ToolStripSeparator5, Me.BtSave, Me.ToolStripSeparator2, Me.BtReturn, Me.ToolStripSeparator6, Me.Toolfind, Me.ToolStripSeparator7, Me.BtExport, Me.ToolStripSeparator9, Me.Toolreflash, Me.BtClose})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(839, 25)
        Me.ToolBt.TabIndex = 80
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'BtModify
        '
        Me.BtModify.Image = CType(resources.GetObject("BtModify.Image"), System.Drawing.Image)
        Me.BtModify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtModify.Name = "BtModify"
        Me.BtModify.Size = New System.Drawing.Size(71, 22)
        Me.BtModify.Text = "修 改(&E)"
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
        Me.BtDelete.Visible = False
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
        Me.BtSave.ToolTipText = "保存"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'Toolfind
        '
        Me.Toolfind.Image = CType(resources.GetObject("Toolfind.Image"), System.Drawing.Image)
        Me.Toolfind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Toolfind.Name = "Toolfind"
        Me.Toolfind.Size = New System.Drawing.Size(66, 22)
        Me.Toolfind.Text = "查詢(&F)"
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
        Me.BtExport.Visible = False
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'Toolreflash
        '
        Me.Toolreflash.ForeColor = System.Drawing.Color.Black
        Me.Toolreflash.Image = CType(resources.GetObject("Toolreflash.Image"), System.Drawing.Image)
        Me.Toolreflash.ImageTransparentColor = System.Drawing.Color.Black
        Me.Toolreflash.Name = "Toolreflash"
        Me.Toolreflash.Size = New System.Drawing.Size(72, 22)
        Me.Toolreflash.Text = "刷 新(&R)"
        Me.Toolreflash.ToolTipText = "刷 新"
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
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.ToolCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 584)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(839, 22)
        Me.StatusStrip1.TabIndex = 79
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
        'Chkusey
        '
        Me.Chkusey.AutoSize = True
        Me.Chkusey.Location = New System.Drawing.Point(588, 77)
        Me.Chkusey.Name = "Chkusey"
        Me.Chkusey.Size = New System.Drawing.Size(48, 16)
        Me.Chkusey.TabIndex = 81
        Me.Chkusey.Text = "有效"
        Me.Chkusey.UseVisualStyleBackColor = True
        '
        'DgWHList
        '
        Me.DgWHList.AllowUserToAddRows = False
        Me.DgWHList.AllowUserToDeleteRows = False
        Me.DgWHList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgWHList.BackgroundColor = System.Drawing.Color.White
        Me.DgWHList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgWHList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgWHList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColSit, Me.Column7, Me.Column8, Me.ColStationName, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Colusey})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgWHList.DefaultCellStyle = DataGridViewCellStyle1
        Me.DgWHList.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DgWHList.Location = New System.Drawing.Point(0, 131)
        Me.DgWHList.Name = "DgWHList"
        Me.DgWHList.ReadOnly = True
        Me.DgWHList.RowHeadersWidth = 4
        Me.DgWHList.RowTemplate.Height = 23
        Me.DgWHList.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.[Default]
        Me.DgWHList.Size = New System.Drawing.Size(839, 451)
        Me.DgWHList.TabIndex = 82
        '
        'ColSit
        '
        Me.ColSit.HeaderText = "仓库编号"
        Me.ColSit.Name = "ColSit"
        Me.ColSit.ReadOnly = True
        Me.ColSit.Width = 80
        '
        'Column7
        '
        Me.Column7.HeaderText = "仓库名称"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "工厂别"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 80
        '
        'ColStationName
        '
        Me.ColStationName.HeaderText = "仓库位置"
        Me.ColStationName.Name = "ColStationName"
        Me.ColStationName.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "类别"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 70
        '
        'Column11
        '
        Me.Column11.HeaderText = "备注"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.HeaderText = "设置人员"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 80
        '
        'Column13
        '
        Me.Column13.HeaderText = "设置时间"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Width = 80
        '
        'Colusey
        '
        Me.Colusey.HeaderText = "有效否"
        Me.Colusey.Name = "Colusey"
        Me.Colusey.ReadOnly = True
        Me.Colusey.Width = 70
        '
        'FrmMgWHinfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(839, 606)
        Me.Controls.Add(Me.DgWHList)
        Me.Controls.Add(Me.Chkusey)
        Me.Controls.Add(Me.CkbControl)
        Me.Controls.Add(Me.CobWHName)
        Me.Controls.Add(Me.ToolBt)
        Me.Controls.Add(Me.CobWHID)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CobFactory)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CobFloor)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMgWHinfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "仓库仓别维护"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DgWHList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CobFactory As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CobFloor As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtModify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtReturn As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CobWHID As System.Windows.Forms.ComboBox
    Friend WithEvents CobWHName As System.Windows.Forms.ComboBox
    Friend WithEvents CkbControl As System.Windows.Forms.CheckBox
    Friend WithEvents Chkusey As System.Windows.Forms.CheckBox
    Friend WithEvents Toolfind As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Toolreflash As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents DgWHList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ColSit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColStationName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Colusey As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
