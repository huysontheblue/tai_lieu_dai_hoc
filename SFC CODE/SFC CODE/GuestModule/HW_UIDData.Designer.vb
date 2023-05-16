<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HW_UIDData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HW_UIDData))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnQuery = New DevComponents.DotNetBar.ButtonItem()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.btnUnLock = New DevComponents.DotNetBar.ButtonItem()
        Me.btnClear = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSave = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.DtStar = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Partide = New System.Windows.Forms.TextBox()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.DtEnd = New System.Windows.Forms.DateTimePicker()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.DataGridViewX1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Path = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LockBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LockTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsedTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pager1 = New SysBasicClass.Pager()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
        '
        'Bar1
        '
        Me.Bar1.AccessibleDescription = "DotNetBar Bar (Bar1)"
        Me.Bar1.AccessibleName = "DotNetBar Bar"
        Me.Bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar
        Me.Bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!)
        Me.Bar1.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.ResizeHandle
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnQuery, Me.btnAdd, Me.btnEdit, Me.btnUnLock, Me.btnClear, Me.btnSave, Me.btnDelete})
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Margin = New System.Windows.Forms.Padding(2)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.PaddingBottom = 3
        Me.Bar1.PaddingLeft = 3
        Me.Bar1.PaddingRight = 3
        Me.Bar1.PaddingTop = 3
        Me.Bar1.SingleLineColor = System.Drawing.SystemColors.ActiveCaption
        Me.Bar1.Size = New System.Drawing.Size(1044, 31)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 143
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnQuery
        '
        Me.btnQuery.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnQuery.Image = CType(resources.GetObject("btnQuery.Image"), System.Drawing.Image)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Text = "查询(Q)"
        '
        'btnAdd
        '
        Me.btnAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Text = "新增(N)"
        '
        'btnEdit
        '
        Me.btnEdit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnEdit.Enabled = False
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Text = "修改(U)"
        Me.btnEdit.Visible = False
        '
        'btnUnLock
        '
        Me.btnUnLock.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnUnLock.Image = CType(resources.GetObject("btnUnLock.Image"), System.Drawing.Image)
        Me.btnUnLock.Name = "btnUnLock"
        Me.btnUnLock.Text = "解除锁定(U)"
        Me.btnUnLock.Visible = False
        '
        'btnClear
        '
        Me.btnClear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Text = "清除使用记录(C)"
        Me.btnClear.Visible = False
        '
        'btnSave
        '
        Me.btnSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSave.Enabled = False
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Text = "保存(S)"
        Me.btnSave.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDelete.Enabled = False
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Text = "删除(D)"
        '
        'DtStar
        '
        Me.DtStar.CustomFormat = "yyyy/MM/dd"
        Me.DtStar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtStar.Location = New System.Drawing.Point(81, 18)
        Me.DtStar.Name = "DtStar"
        Me.DtStar.ShowCheckBox = True
        Me.DtStar.Size = New System.Drawing.Size(101, 21)
        Me.DtStar.TabIndex = 144
        Me.DtStar.Value = New Date(2019, 9, 30, 0, 0, 0, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Partide)
        Me.GroupBox1.Controls.Add(Me.LabelX4)
        Me.GroupBox1.Controls.Add(Me.txtFileName)
        Me.GroupBox1.Controls.Add(Me.LabelX3)
        Me.GroupBox1.Controls.Add(Me.LabelX2)
        Me.GroupBox1.Controls.Add(Me.DtEnd)
        Me.GroupBox1.Controls.Add(Me.LabelX1)
        Me.GroupBox1.Controls.Add(Me.DtStar)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 27)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(1, 1, 1, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupBox1.Size = New System.Drawing.Size(1029, 46)
        Me.GroupBox1.TabIndex = 145
        Me.GroupBox1.TabStop = False
        '
        'Partide
        '
        Me.Partide.Location = New System.Drawing.Point(413, 17)
        Me.Partide.Margin = New System.Windows.Forms.Padding(2)
        Me.Partide.Name = "Partide"
        Me.Partide.Size = New System.Drawing.Size(161, 21)
        Me.Partide.TabIndex = 151
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(372, 21)
        Me.LabelX4.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(52, 15)
        Me.LabelX4.TabIndex = 150
        Me.LabelX4.Text = "料号:"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(623, 15)
        Me.txtFileName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(273, 21)
        Me.txtFileName.TabIndex = 149
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(578, 18)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(52, 15)
        Me.LabelX3.TabIndex = 148
        Me.LabelX3.Text = "文件名:"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(189, 21)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(65, 15)
        Me.LabelX2.TabIndex = 147
        Me.LabelX2.Text = "截止日期:"
        '
        'DtEnd
        '
        Me.DtEnd.CustomFormat = "yyyy/MM/dd"
        Me.DtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtEnd.Location = New System.Drawing.Point(256, 18)
        Me.DtEnd.Name = "DtEnd"
        Me.DtEnd.ShowCheckBox = True
        Me.DtEnd.Size = New System.Drawing.Size(101, 21)
        Me.DtEnd.TabIndex = 146
        Me.DtEnd.Value = New Date(2019, 9, 30, 0, 0, 0, 0)
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(15, 21)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(65, 15)
        Me.LabelX1.TabIndex = 145
        Me.LabelX1.Text = "开始日期:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "所有文件|*.conf"
        '
        'DataGridViewX1
        '
        Me.DataGridViewX1.AllowUserToAddRows = False
        Me.DataGridViewX1.AllowUserToDeleteRows = False
        Me.DataGridViewX1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewX1.ColumnHeadersHeight = 30
        Me.DataGridViewX1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.PartID, Me.FileName, Me.UID, Me.Path, Me.Intime, Me.UserId, Me.Usey, Me.LockBy, Me.LockTime, Me.UsedBy, Me.UsedTime, Me.Remark})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewX1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewX1.EnableHeadersVisualStyles = False
        Me.DataGridViewX1.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.DataGridViewX1.Location = New System.Drawing.Point(7, 80)
        Me.DataGridViewX1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridViewX1.Name = "DataGridViewX1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewX1.RowHeadersWidth = 30
        Me.DataGridViewX1.RowTemplate.Height = 30
        Me.DataGridViewX1.Size = New System.Drawing.Size(1029, 307)
        Me.DataGridViewX1.TabIndex = 146
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Width = 50
        '
        'PartID
        '
        Me.PartID.DataPropertyName = "PartID"
        Me.PartID.HeaderText = "PartID/Lot"
        Me.PartID.Name = "PartID"
        '
        'FileName
        '
        Me.FileName.DataPropertyName = "FileName"
        Me.FileName.HeaderText = "FileName"
        Me.FileName.Name = "FileName"
        '
        'UID
        '
        Me.UID.DataPropertyName = "UID"
        Me.UID.HeaderText = "UID"
        Me.UID.Name = "UID"
        Me.UID.Visible = False
        '
        'Path
        '
        Me.Path.DataPropertyName = "Path"
        Me.Path.HeaderText = "Path"
        Me.Path.Name = "Path"
        Me.Path.Width = 220
        '
        'Intime
        '
        Me.Intime.DataPropertyName = "Intime"
        Me.Intime.HeaderText = "Intime"
        Me.Intime.Name = "Intime"
        '
        'UserId
        '
        Me.UserId.DataPropertyName = "UserId"
        Me.UserId.HeaderText = "UserId"
        Me.UserId.Name = "UserId"
        '
        'Usey
        '
        Me.Usey.DataPropertyName = "Usey"
        Me.Usey.HeaderText = "Usey"
        Me.Usey.Name = "Usey"
        '
        'LockBy
        '
        Me.LockBy.DataPropertyName = "LockBy"
        Me.LockBy.HeaderText = "LockBy"
        Me.LockBy.Name = "LockBy"
        '
        'LockTime
        '
        Me.LockTime.DataPropertyName = "LockTime"
        Me.LockTime.HeaderText = "LockTime"
        Me.LockTime.Name = "LockTime"
        '
        'UsedBy
        '
        Me.UsedBy.DataPropertyName = "UsedBy"
        Me.UsedBy.HeaderText = "UsedBy"
        Me.UsedBy.Name = "UsedBy"
        '
        'UsedTime
        '
        Me.UsedTime.DataPropertyName = "UsedTime"
        Me.UsedTime.HeaderText = "UsedTime"
        Me.UsedTime.Name = "UsedTime"
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "Remark"
        Me.Remark.Name = "Remark"
        '
        'Pager1
        '
        Me.Pager1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pager1.ExportAllDataToXls = True
        Me.Pager1.ExportPageDataToXls = True
        Me.Pager1.Location = New System.Drawing.Point(0, 391)
        Me.Pager1.Name = "Pager1"
        Me.Pager1.NMax = 0
        Me.Pager1.PageCount = 0
        Me.Pager1.PageCurrent = 0
        Me.Pager1.PageSize = 20
        Me.Pager1.QuerySeconds = 0.0R
        Me.Pager1.Size = New System.Drawing.Size(1044, 30)
        Me.Pager1.TabIndex = 147
        '
        'HW_UIDData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 421)
        Me.Controls.Add(Me.Pager1)
        Me.Controls.Add(Me.DataGridViewX1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Bar1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "HW_UIDData"
        Me.Text = "华为C314_UID数据管理"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnQuery As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents DtStar As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DataGridViewX1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnUnLock As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnClear As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Pager1 As SysBasicClass.Pager
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FileName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Path As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Intime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LockBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LockTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsedTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partide As System.Windows.Forms.TextBox
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
End Class
