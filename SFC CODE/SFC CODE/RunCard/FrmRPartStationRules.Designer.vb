<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRPartStationRules
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

    '注意： 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRPartStationRules))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ExitFrom = New System.Windows.Forms.ToolStripButton
        Me.FileRefresh = New System.Windows.Forms.ToolStripButton
        Me.UnDo = New System.Windows.Forms.ToolStripButton
        Me.Search = New System.Windows.Forms.ToolStripButton
        Me.RuleName = New System.Windows.Forms.Label
        Me.DgList = New System.Windows.Forms.DataGridView
        Me.ToolBt = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.NewFile = New System.Windows.Forms.ToolStripButton
        Me.EditFile = New System.Windows.Forms.ToolStripButton
        Me.Delete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Save = New System.Windows.Forms.ToolStripButton
        Me.toolCheck = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.Label1 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.txtRuleName = New System.Windows.Forms.TextBox
        Me.txtRuleKeyField = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtRuleOrderby = New System.Windows.Forms.NumericUpDown
        Me.chkRuleusey = New System.Windows.Forms.CheckBox
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.txtRuleCheckSQL = New System.Windows.Forms.TextBox
        Me.txtID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkParameters = New System.Windows.Forms.CheckedListBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtRuleType = New System.Windows.Forms.ComboBox
        CType(Me.DgList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolBt.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.txtRuleOrderby, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExitFrom
        '
        Me.ExitFrom.Image = CType(resources.GetObject("ExitFrom.Image"), System.Drawing.Image)
        Me.ExitFrom.ImageTransparentColor = System.Drawing.Color.White
        Me.ExitFrom.Name = "ExitFrom"
        Me.ExitFrom.Size = New System.Drawing.Size(72, 22)
        Me.ExitFrom.Text = "退 出(&X)"
        Me.ExitFrom.ToolTipText = "退出"
        '
        'FileRefresh
        '
        Me.FileRefresh.Image = CType(resources.GetObject("FileRefresh.Image"), System.Drawing.Image)
        Me.FileRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.FileRefresh.Name = "FileRefresh"
        Me.FileRefresh.Size = New System.Drawing.Size(72, 22)
        Me.FileRefresh.Text = "刷 新(&R)"
        Me.FileRefresh.ToolTipText = "刷新"
        Me.FileRefresh.Visible = False
        '
        'UnDo
        '
        Me.UnDo.Enabled = False
        Me.UnDo.Image = CType(resources.GetObject("UnDo.Image"), System.Drawing.Image)
        Me.UnDo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UnDo.Name = "UnDo"
        Me.UnDo.Size = New System.Drawing.Size(68, 22)
        Me.UnDo.Text = "返回(&C)"
        Me.UnDo.ToolTipText = "返回"
        '
        'Search
        '
        Me.Search.Image = CType(resources.GetObject("Search.Image"), System.Drawing.Image)
        Me.Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(70, 22)
        Me.Search.Text = "查 找(&F)"
        Me.Search.ToolTipText = "查找"
        Me.Search.Visible = False
        '
        'RuleName
        '
        Me.RuleName.AutoSize = True
        Me.RuleName.Location = New System.Drawing.Point(288, 68)
        Me.RuleName.Name = "RuleName"
        Me.RuleName.Size = New System.Drawing.Size(65, 12)
        Me.RuleName.TabIndex = 34
        Me.RuleName.Text = "校验类别："
        '
        'DgList
        '
        Me.DgList.AllowUserToAddRows = False
        Me.DgList.AllowUserToDeleteRows = False
        Me.DgList.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.DgList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgList.BackgroundColor = System.Drawing.Color.White
        Me.DgList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.DgList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgList.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DgList.GridColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.DgList.Location = New System.Drawing.Point(0, 202)
        Me.DgList.MultiSelect = False
        Me.DgList.Name = "DgList"
        Me.DgList.ReadOnly = True
        Me.DgList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DgList.RowHeadersWidth = 4
        Me.DgList.RowTemplate.Height = 24
        Me.DgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgList.ShowEditingIcon = False
        Me.DgList.Size = New System.Drawing.Size(774, 199)
        Me.DgList.TabIndex = 21
        Me.DgList.TabStop = False
        '
        'ToolBt
        '
        Me.ToolBt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.NewFile, Me.EditFile, Me.Delete, Me.ToolStripSeparator5, Me.Save, Me.UnDo, Me.toolCheck, Me.ToolStripSeparator6, Me.Search, Me.FileRefresh, Me.ExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 29)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(774, 25)
        Me.ToolBt.TabIndex = 44
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'NewFile
        '
        Me.NewFile.Image = CType(resources.GetObject("NewFile.Image"), System.Drawing.Image)
        Me.NewFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewFile.Name = "NewFile"
        Me.NewFile.Size = New System.Drawing.Size(74, 22)
        Me.NewFile.Text = "新 增(&N)"
        Me.NewFile.ToolTipText = "新增"
        '
        'EditFile
        '
        Me.EditFile.Image = CType(resources.GetObject("EditFile.Image"), System.Drawing.Image)
        Me.EditFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditFile.Name = "EditFile"
        Me.EditFile.Size = New System.Drawing.Size(71, 22)
        Me.EditFile.Text = "修 改(&E)"
        '
        'Delete
        '
        Me.Delete.Image = CType(resources.GetObject("Delete.Image"), System.Drawing.Image)
        Me.Delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(69, 22)
        Me.Delete.Text = "刪除(&D)"
        Me.Delete.ToolTipText = "刪除"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'Save
        '
        Me.Save.Enabled = False
        Me.Save.Image = CType(resources.GetObject("Save.Image"), System.Drawing.Image)
        Me.Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(71, 22)
        Me.Save.Text = "保 存(&S)"
        Me.Save.ToolTipText = "保存"
        '
        'toolCheck
        '
        Me.toolCheck.Image = CType(resources.GetObject("toolCheck.Image"), System.Drawing.Image)
        Me.toolCheck.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolCheck.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCheck.Name = "toolCheck"
        Me.toolCheck.Size = New System.Drawing.Size(101, 22)
        Me.toolCheck.Tag = "NO"
        Me.toolCheck.Text = "SQL语法检测"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 154)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "检测SQL："
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 404)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(774, 22)
        Me.StatusStrip1.TabIndex = 48
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(68, 17)
        Me.StatusLabel.Text = "记录笔数："
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'txtRuleName
        '
        Me.txtRuleName.Location = New System.Drawing.Point(76, 63)
        Me.txtRuleName.Name = "txtRuleName"
        Me.txtRuleName.Size = New System.Drawing.Size(193, 21)
        Me.txtRuleName.TabIndex = 0
        '
        'txtRuleKeyField
        '
        Me.txtRuleKeyField.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtRuleKeyField.Enabled = False
        Me.txtRuleKeyField.Location = New System.Drawing.Point(76, 95)
        Me.txtRuleKeyField.Name = "txtRuleKeyField"
        Me.txtRuleKeyField.Size = New System.Drawing.Size(446, 21)
        Me.txtRuleKeyField.TabIndex = 4
        Me.txtRuleKeyField.Tag = "当变量栏位不为空的时候，检测SQL也不能为空"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(528, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "排序："
        '
        'txtRuleOrderby
        '
        Me.txtRuleOrderby.Location = New System.Drawing.Point(567, 64)
        Me.txtRuleOrderby.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtRuleOrderby.Name = "txtRuleOrderby"
        Me.txtRuleOrderby.Size = New System.Drawing.Size(42, 21)
        Me.txtRuleOrderby.TabIndex = 55
        Me.txtRuleOrderby.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkRuleusey
        '
        Me.chkRuleusey.AutoSize = True
        Me.chkRuleusey.Location = New System.Drawing.Point(651, 66)
        Me.chkRuleusey.Name = "chkRuleusey"
        Me.chkRuleusey.Size = New System.Drawing.Size(72, 16)
        Me.chkRuleusey.TabIndex = 63
        Me.chkRuleusey.Text = "是否启用"
        Me.chkRuleusey.UseVisualStyleBackColor = True
        '
        'menuStrip1
        '
        Me.menuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2, Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5, Me.toolStripMenuItem6})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(774, 25)
        Me.menuStrip1.TabIndex = 129
        Me.menuStrip1.Text = "menuStrip1"
        '
        'toolStripMenuItem1
        '
        Me.toolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
        Me.toolStripMenuItem1.Size = New System.Drawing.Size(59, 21)
        Me.toolStripMenuItem1.Text = "系统(&S)"
        '
        'toolStripMenuItem2
        '
        Me.toolStripMenuItem2.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
        Me.toolStripMenuItem2.Size = New System.Drawing.Size(58, 21)
        Me.toolStripMenuItem2.Text = "文件(&F)"
        '
        'toolStripMenuItem3
        '
        Me.toolStripMenuItem3.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
        Me.toolStripMenuItem3.Size = New System.Drawing.Size(60, 21)
        Me.toolStripMenuItem3.Text = "查看(&V)"
        '
        'toolStripMenuItem4
        '
        Me.toolStripMenuItem4.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem4.Name = "toolStripMenuItem4"
        Me.toolStripMenuItem4.Size = New System.Drawing.Size(59, 21)
        Me.toolStripMenuItem4.Text = "工具(&T)"
        '
        'toolStripMenuItem5
        '
        Me.toolStripMenuItem5.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem5.Name = "toolStripMenuItem5"
        Me.toolStripMenuItem5.Size = New System.Drawing.Size(64, 21)
        Me.toolStripMenuItem5.Text = "窗口(&W)"
        '
        'toolStripMenuItem6
        '
        Me.toolStripMenuItem6.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem6.Name = "toolStripMenuItem6"
        Me.toolStripMenuItem6.Size = New System.Drawing.Size(61, 21)
        Me.toolStripMenuItem6.Text = "帮助(&H)"
        '
        'txtRuleCheckSQL
        '
        Me.txtRuleCheckSQL.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtRuleCheckSQL.Enabled = False
        Me.txtRuleCheckSQL.Location = New System.Drawing.Point(76, 126)
        Me.txtRuleCheckSQL.Multiline = True
        Me.txtRuleCheckSQL.Name = "txtRuleCheckSQL"
        Me.txtRuleCheckSQL.Size = New System.Drawing.Size(446, 70)
        Me.txtRuleCheckSQL.TabIndex = 130
        Me.txtRuleCheckSQL.Tag = ""
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(651, 126)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(0, 21)
        Me.txtID.TabIndex = 132
        Me.txtID.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "SQL变量："
        '
        'chkParameters
        '
        Me.chkParameters.Enabled = False
        Me.chkParameters.FormattingEnabled = True
        Me.chkParameters.Items.AddRange(New Object() {"@ppid--產品條碼", "@moid--工單編號", "@teamid--線別", "@spoint--電腦名", "@userid--用戶名", "@PPartid--父料號", "@TPartid--子料號", "@Cartonid--主條碼", "@Stationid--站點編號", "@StaOrderid--工站序號", "@ScanOrderid--掃描序號", "@preStaOrderid--前一站掃描站點", "@maxindexqty--工站需要掃描序號總數", "@checktime--兩站之間需間隔的時間"})
        Me.chkParameters.Location = New System.Drawing.Point(531, 95)
        Me.chkParameters.Name = "chkParameters"
        Me.chkParameters.Size = New System.Drawing.Size(231, 100)
        Me.chkParameters.TabIndex = 137
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 138
        Me.Label4.Text = "校验名称："
        '
        'txtRuleType
        '
        Me.txtRuleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtRuleType.FormattingEnabled = True
        Me.txtRuleType.Location = New System.Drawing.Point(359, 64)
        Me.txtRuleType.Name = "txtRuleType"
        Me.txtRuleType.Size = New System.Drawing.Size(163, 20)
        Me.txtRuleType.TabIndex = 139
        '
        'FrmRPartStationRules
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 426)
        Me.Controls.Add(Me.txtRuleType)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chkParameters)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.txtRuleCheckSQL)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.chkRuleusey)
        Me.Controls.Add(Me.txtRuleOrderby)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DgList)
        Me.Controls.Add(Me.txtRuleKeyField)
        Me.Controls.Add(Me.txtRuleName)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.RuleName)
        Me.Controls.Add(Me.ToolBt)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmRPartStationRules"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "卡关校验规则设置"
        CType(Me.DgList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.txtRuleOrderby, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents FileRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents UnDo As System.Windows.Forms.ToolStripButton
    Friend WithEvents Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents RuleName As System.Windows.Forms.Label
    Friend WithEvents DgList As System.Windows.Forms.DataGridView
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents Delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents EditFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtRuleName As System.Windows.Forms.TextBox
    Friend WithEvents txtRuleKeyField As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRuleOrderby As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkRuleusey As System.Windows.Forms.CheckBox
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtRuleCheckSQL As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkParameters As System.Windows.Forms.CheckedListBox
    Private WithEvents toolCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRuleType As System.Windows.Forms.ComboBox
End Class
