<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmScanCheckRule
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmScanCheckRule))
        Me.dgvScanChkRule = New System.Windows.Forms.DataGridView()
        Me.TxtPavcPart = New System.Windows.Forms.TextBox()
        Me.Search = New System.Windows.Forms.ToolStripButton()
        Me.UnDo = New System.Windows.Forms.ToolStripButton()
        Me.LelTpart = New System.Windows.Forms.Label()
        Me.LblPartID = New System.Windows.Forms.Label()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewFile = New System.Windows.Forms.ToolStripButton()
        Me.EditFile = New System.Windows.Forms.ToolStripButton()
        Me.toolAbandon = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.Save = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.FileRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtTavcPart = New System.Windows.Forms.TextBox()
        Me.TxtStationNo = New System.Windows.Forms.TextBox()
        Me.CobStationid = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtScanOrder = New System.Windows.Forms.TextBox()
        Me.IsNIChk = New System.Windows.Forms.CheckBox()
        Me.IsLaserChk = New System.Windows.Forms.CheckBox()
        Me.IsPCBAChk = New System.Windows.Forms.CheckBox()
        Me.IsGuesSemiChk = New System.Windows.Forms.CheckBox()
        Me.IsGuesFinChk = New System.Windows.Forms.CheckBox()
        Me.IsAcrChk = New System.Windows.Forms.CheckBox()
        Me.IsAoiChk = New System.Windows.Forms.CheckBox()
        Me.IsFT1Chk = New System.Windows.Forms.CheckBox()
        Me.IsFT2Chk = New System.Windows.Forms.CheckBox()
        Me.IsVoltageChk = New System.Windows.Forms.CheckBox()
        Me.IsGenChk = New System.Windows.Forms.CheckBox()
        Me.IsLotChk = New System.Windows.Forms.CheckBox()
        Me.IsRanOQCChk = New System.Windows.Forms.CheckBox()
        Me.IsOQCChk = New System.Windows.Forms.CheckBox()
        Me.txtRanOQCQty = New System.Windows.Forms.TextBox()
        Me.lblChouJian = New System.Windows.Forms.Label()
        Me.IsShipChk = New System.Windows.Forms.CheckBox()
        Me.IsMagnetSemiChk = New System.Windows.Forms.CheckBox()
        Me.IsMagnetFChk = New System.Windows.Forms.CheckBox()
        Me.IsMultiLotChk = New System.Windows.Forms.CheckBox()
        Me.IsLinkMSNChk = New System.Windows.Forms.CheckBox()
        Me.IsA20Chk = New System.Windows.Forms.CheckBox()
        Me.IsA20BurnChk = New System.Windows.Forms.CheckBox()
        Me.IsACRoneChk = New System.Windows.Forms.CheckBox()
        Me.IsAcrIqcChk = New System.Windows.Forms.CheckBox()
        Me.IsSpecChk = New System.Windows.Forms.CheckBox()
        Me.IsW2Chk = New System.Windows.Forms.CheckBox()
        Me.IsW2NetLinkChk = New System.Windows.Forms.CheckBox()
        Me.IsFinalChk = New System.Windows.Forms.CheckBox()
        Me.IsWiggleChk = New System.Windows.Forms.CheckBox()
        Me.IsE75Chk = New System.Windows.Forms.CheckBox()
        Me.IsWeightChk = New System.Windows.Forms.CheckBox()
        Me.IsChargeChk = New System.Windows.Forms.CheckBox()
        Me.IsTwoInOneChk = New System.Windows.Forms.CheckBox()
        Me.IsW2FT6Chk = New System.Windows.Forms.CheckBox()
        Me.IsPLPackChk = New System.Windows.Forms.CheckBox()
        Me.IsAOIOneChk = New System.Windows.Forms.CheckBox()
        Me.IsAllowMuLineChk = New System.Windows.Forms.CheckBox()
        Me.IsChkParentPart = New System.Windows.Forms.CheckBox()
        CType(Me.dgvScanChkRule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolBt.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvScanChkRule
        '
        Me.dgvScanChkRule.AllowUserToAddRows = False
        Me.dgvScanChkRule.AllowUserToDeleteRows = False
        Me.dgvScanChkRule.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvScanChkRule.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvScanChkRule.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvScanChkRule.BackgroundColor = System.Drawing.Color.White
        Me.dgvScanChkRule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvScanChkRule.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvScanChkRule.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvScanChkRule.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvScanChkRule.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvScanChkRule.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvScanChkRule.GridColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.dgvScanChkRule.Location = New System.Drawing.Point(0, 191)
        Me.dgvScanChkRule.MultiSelect = False
        Me.dgvScanChkRule.Name = "dgvScanChkRule"
        Me.dgvScanChkRule.ReadOnly = True
        Me.dgvScanChkRule.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvScanChkRule.RowHeadersWidth = 4
        Me.dgvScanChkRule.RowTemplate.Height = 24
        Me.dgvScanChkRule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvScanChkRule.ShowEditingIcon = False
        Me.dgvScanChkRule.Size = New System.Drawing.Size(1000, 356)
        Me.dgvScanChkRule.TabIndex = 135
        Me.dgvScanChkRule.TabStop = False
        '
        'TxtPavcPart
        '
        Me.TxtPavcPart.Enabled = False
        Me.TxtPavcPart.Location = New System.Drawing.Point(323, 35)
        Me.TxtPavcPart.Name = "TxtPavcPart"
        Me.TxtPavcPart.Size = New System.Drawing.Size(170, 21)
        Me.TxtPavcPart.TabIndex = 134
        '
        'Search
        '
        Me.Search.Image = CType(resources.GetObject("Search.Image"), System.Drawing.Image)
        Me.Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(70, 22)
        Me.Search.Text = "查 找(&F)"
        Me.Search.ToolTipText = "查找"
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
        'LelTpart
        '
        Me.LelTpart.AutoSize = True
        Me.LelTpart.Location = New System.Drawing.Point(11, 40)
        Me.LelTpart.Name = "LelTpart"
        Me.LelTpart.Size = New System.Drawing.Size(65, 12)
        Me.LelTpart.TabIndex = 136
        Me.LelTpart.Text = "料件编号："
        '
        'LblPartID
        '
        Me.LblPartID.AutoSize = True
        Me.LblPartID.Location = New System.Drawing.Point(255, 40)
        Me.LblPartID.Name = "LblPartID"
        Me.LblPartID.Size = New System.Drawing.Size(65, 12)
        Me.LblPartID.TabIndex = 137
        Me.LblPartID.Text = "上级料号："
        '
        'ToolBt
        '
        Me.ToolBt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.NewFile, Me.EditFile, Me.toolAbandon, Me.ToolStripSeparator5, Me.Save, Me.UnDo, Me.ToolStripSeparator6, Me.Search, Me.FileRefresh, Me.ExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, -2)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(991, 25)
        Me.ToolBt.TabIndex = 138
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
        'toolAbandon
        '
        Me.toolAbandon.Image = CType(resources.GetObject("toolAbandon.Image"), System.Drawing.Image)
        Me.toolAbandon.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAbandon.Name = "toolAbandon"
        Me.toolAbandon.Size = New System.Drawing.Size(73, 22)
        Me.toolAbandon.Tag = "NO"
        Me.toolAbandon.Text = "作 废(&D)"
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
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'FileRefresh
        '
        Me.FileRefresh.Image = CType(resources.GetObject("FileRefresh.Image"), System.Drawing.Image)
        Me.FileRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.FileRefresh.Name = "FileRefresh"
        Me.FileRefresh.Size = New System.Drawing.Size(72, 22)
        Me.FileRefresh.Text = "刷 新(&R)"
        Me.FileRefresh.ToolTipText = "刷新"
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
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 550)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1000, 22)
        Me.StatusStrip1.TabIndex = 141
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(511, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 139
        Me.Label1.Text = "站点编号："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(746, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "站点顺序："
        '
        'TxtTavcPart
        '
        Me.TxtTavcPart.Enabled = False
        Me.TxtTavcPart.Location = New System.Drawing.Point(76, 35)
        Me.TxtTavcPart.Name = "TxtTavcPart"
        Me.TxtTavcPart.Size = New System.Drawing.Size(162, 21)
        Me.TxtTavcPart.TabIndex = 131
        '
        'TxtStationNo
        '
        Me.TxtStationNo.Enabled = False
        Me.TxtStationNo.Location = New System.Drawing.Point(816, 33)
        Me.TxtStationNo.Name = "TxtStationNo"
        Me.TxtStationNo.Size = New System.Drawing.Size(42, 21)
        Me.TxtStationNo.TabIndex = 133
        '
        'CobStationid
        '
        Me.CobStationid.Enabled = False
        Me.CobStationid.FormattingEnabled = True
        Me.CobStationid.Location = New System.Drawing.Point(571, 35)
        Me.CobStationid.Name = "CobStationid"
        Me.CobStationid.Size = New System.Drawing.Size(167, 20)
        Me.CobStationid.TabIndex = 132
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 159
        Me.Label3.Text = "版本号："
        '
        'txtVersion
        '
        Me.txtVersion.Enabled = False
        Me.txtVersion.Location = New System.Drawing.Point(76, 62)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(37, 21)
        Me.txtVersion.TabIndex = 160
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(876, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 161
        Me.Label4.Text = "扫描顺序："
        '
        'txtScanOrder
        '
        Me.txtScanOrder.Enabled = False
        Me.txtScanOrder.Location = New System.Drawing.Point(943, 33)
        Me.txtScanOrder.Name = "txtScanOrder"
        Me.txtScanOrder.Size = New System.Drawing.Size(42, 21)
        Me.txtScanOrder.TabIndex = 162
        '
        'IsNIChk
        '
        Me.IsNIChk.AutoSize = True
        Me.IsNIChk.Location = New System.Drawing.Point(132, 64)
        Me.IsNIChk.Name = "IsNIChk"
        Me.IsNIChk.Size = New System.Drawing.Size(108, 16)
        Me.IsNIChk.TabIndex = 163
        Me.IsNIChk.Text = "是否NI测试校验"
        Me.IsNIChk.UseVisualStyleBackColor = True
        '
        'IsLaserChk
        '
        Me.IsLaserChk.AutoSize = True
        Me.IsLaserChk.Location = New System.Drawing.Point(258, 64)
        Me.IsLaserChk.Name = "IsLaserChk"
        Me.IsLaserChk.Size = New System.Drawing.Size(120, 16)
        Me.IsLaserChk.TabIndex = 164
        Me.IsLaserChk.Text = "是否镭射测试校验"
        Me.IsLaserChk.UseVisualStyleBackColor = True
        '
        'IsPCBAChk
        '
        Me.IsPCBAChk.AutoSize = True
        Me.IsPCBAChk.Location = New System.Drawing.Point(382, 64)
        Me.IsPCBAChk.Name = "IsPCBAChk"
        Me.IsPCBAChk.Size = New System.Drawing.Size(120, 16)
        Me.IsPCBAChk.TabIndex = 165
        Me.IsPCBAChk.Text = "是否PCBA测试校验"
        Me.IsPCBAChk.UseVisualStyleBackColor = True
        '
        'IsGuesSemiChk
        '
        Me.IsGuesSemiChk.AutoSize = True
        Me.IsGuesSemiChk.Location = New System.Drawing.Point(507, 63)
        Me.IsGuesSemiChk.Name = "IsGuesSemiChk"
        Me.IsGuesSemiChk.Size = New System.Drawing.Size(132, 16)
        Me.IsGuesSemiChk.TabIndex = 166
        Me.IsGuesSemiChk.Text = "是否高斯半成品校验"
        Me.IsGuesSemiChk.UseVisualStyleBackColor = True
        '
        'IsGuesFinChk
        '
        Me.IsGuesFinChk.AutoSize = True
        Me.IsGuesFinChk.Location = New System.Drawing.Point(644, 64)
        Me.IsGuesFinChk.Name = "IsGuesFinChk"
        Me.IsGuesFinChk.Size = New System.Drawing.Size(120, 16)
        Me.IsGuesFinChk.TabIndex = 167
        Me.IsGuesFinChk.Text = "是否高斯成品校验"
        Me.IsGuesFinChk.UseVisualStyleBackColor = True
        '
        'IsAcrChk
        '
        Me.IsAcrChk.AutoSize = True
        Me.IsAcrChk.Location = New System.Drawing.Point(767, 63)
        Me.IsAcrChk.Name = "IsAcrChk"
        Me.IsAcrChk.Size = New System.Drawing.Size(114, 16)
        Me.IsAcrChk.TabIndex = 168
        Me.IsAcrChk.Text = "是否ACR测试校验"
        Me.IsAcrChk.UseVisualStyleBackColor = True
        '
        'IsAoiChk
        '
        Me.IsAoiChk.AutoSize = True
        Me.IsAoiChk.Location = New System.Drawing.Point(885, 64)
        Me.IsAoiChk.Name = "IsAoiChk"
        Me.IsAoiChk.Size = New System.Drawing.Size(114, 16)
        Me.IsAoiChk.TabIndex = 169
        Me.IsAoiChk.Text = "是否AOI测试校验"
        Me.IsAoiChk.UseVisualStyleBackColor = True
        '
        'IsFT1Chk
        '
        Me.IsFT1Chk.AutoSize = True
        Me.IsFT1Chk.Location = New System.Drawing.Point(13, 89)
        Me.IsFT1Chk.Name = "IsFT1Chk"
        Me.IsFT1Chk.Size = New System.Drawing.Size(90, 16)
        Me.IsFT1Chk.TabIndex = 170
        Me.IsFT1Chk.Text = "是否FT1校验"
        Me.IsFT1Chk.UseVisualStyleBackColor = True
        '
        'IsFT2Chk
        '
        Me.IsFT2Chk.AutoSize = True
        Me.IsFT2Chk.Location = New System.Drawing.Point(109, 89)
        Me.IsFT2Chk.Name = "IsFT2Chk"
        Me.IsFT2Chk.Size = New System.Drawing.Size(90, 16)
        Me.IsFT2Chk.TabIndex = 171
        Me.IsFT2Chk.Text = "是否FT2校验"
        Me.IsFT2Chk.UseVisualStyleBackColor = True
        '
        'IsVoltageChk
        '
        Me.IsVoltageChk.AutoSize = True
        Me.IsVoltageChk.Location = New System.Drawing.Point(205, 89)
        Me.IsVoltageChk.Name = "IsVoltageChk"
        Me.IsVoltageChk.Size = New System.Drawing.Size(120, 16)
        Me.IsVoltageChk.TabIndex = 172
        Me.IsVoltageChk.Text = "是否电压测试校验"
        Me.IsVoltageChk.UseVisualStyleBackColor = True
        '
        'IsGenChk
        '
        Me.IsGenChk.AutoSize = True
        Me.IsGenChk.Location = New System.Drawing.Point(331, 89)
        Me.IsGenChk.Name = "IsGenChk"
        Me.IsGenChk.Size = New System.Drawing.Size(114, 16)
        Me.IsGenChk.TabIndex = 173
        Me.IsGenChk.Text = "是否GEN测试校验"
        Me.IsGenChk.UseVisualStyleBackColor = True
        '
        'IsLotChk
        '
        Me.IsLotChk.AutoSize = True
        Me.IsLotChk.Location = New System.Drawing.Point(457, 89)
        Me.IsLotChk.Name = "IsLotChk"
        Me.IsLotChk.Size = New System.Drawing.Size(96, 16)
        Me.IsLotChk.TabIndex = 174
        Me.IsLotChk.Text = "是否批次校验"
        Me.IsLotChk.UseVisualStyleBackColor = True
        '
        'IsRanOQCChk
        '
        Me.IsRanOQCChk.AutoSize = True
        Me.IsRanOQCChk.Location = New System.Drawing.Point(559, 89)
        Me.IsRanOQCChk.Name = "IsRanOQCChk"
        Me.IsRanOQCChk.Size = New System.Drawing.Size(114, 16)
        Me.IsRanOQCChk.TabIndex = 175
        Me.IsRanOQCChk.Text = "是否OQC抽检校验"
        Me.IsRanOQCChk.UseVisualStyleBackColor = True
        '
        'IsOQCChk
        '
        Me.IsOQCChk.AutoSize = True
        Me.IsOQCChk.Location = New System.Drawing.Point(789, 88)
        Me.IsOQCChk.Name = "IsOQCChk"
        Me.IsOQCChk.Size = New System.Drawing.Size(90, 16)
        Me.IsOQCChk.TabIndex = 176
        Me.IsOQCChk.Text = "是否OQC校验"
        Me.IsOQCChk.UseVisualStyleBackColor = True
        '
        'txtRanOQCQty
        '
        Me.txtRanOQCQty.Enabled = False
        Me.txtRanOQCQty.Location = New System.Drawing.Point(734, 86)
        Me.txtRanOQCQty.Name = "txtRanOQCQty"
        Me.txtRanOQCQty.Size = New System.Drawing.Size(37, 21)
        Me.txtRanOQCQty.TabIndex = 178
        '
        'lblChouJian
        '
        Me.lblChouJian.AutoSize = True
        Me.lblChouJian.Location = New System.Drawing.Point(685, 90)
        Me.lblChouJian.Name = "lblChouJian"
        Me.lblChouJian.Size = New System.Drawing.Size(53, 12)
        Me.lblChouJian.TabIndex = 177
        Me.lblChouJian.Text = "抽检数："
        '
        'IsShipChk
        '
        Me.IsShipChk.AutoSize = True
        Me.IsShipChk.Location = New System.Drawing.Point(885, 86)
        Me.IsShipChk.Name = "IsShipChk"
        Me.IsShipChk.Size = New System.Drawing.Size(96, 16)
        Me.IsShipChk.TabIndex = 179
        Me.IsShipChk.Text = "是否出货校验"
        Me.IsShipChk.UseVisualStyleBackColor = True
        '
        'IsMagnetSemiChk
        '
        Me.IsMagnetSemiChk.AutoSize = True
        Me.IsMagnetSemiChk.Location = New System.Drawing.Point(12, 111)
        Me.IsMagnetSemiChk.Name = "IsMagnetSemiChk"
        Me.IsMagnetSemiChk.Size = New System.Drawing.Size(156, 16)
        Me.IsMagnetSemiChk.TabIndex = 180
        Me.IsMagnetSemiChk.Text = "是否磁力半成品测试校验"
        Me.IsMagnetSemiChk.UseVisualStyleBackColor = True
        '
        'IsMagnetFChk
        '
        Me.IsMagnetFChk.AutoSize = True
        Me.IsMagnetFChk.Location = New System.Drawing.Point(174, 111)
        Me.IsMagnetFChk.Name = "IsMagnetFChk"
        Me.IsMagnetFChk.Size = New System.Drawing.Size(144, 16)
        Me.IsMagnetFChk.TabIndex = 181
        Me.IsMagnetFChk.Text = "是否磁力成品测试校验"
        Me.IsMagnetFChk.UseVisualStyleBackColor = True
        '
        'IsMultiLotChk
        '
        Me.IsMultiLotChk.AutoSize = True
        Me.IsMultiLotChk.Location = New System.Drawing.Point(329, 111)
        Me.IsMultiLotChk.Name = "IsMultiLotChk"
        Me.IsMultiLotChk.Size = New System.Drawing.Size(108, 16)
        Me.IsMultiLotChk.TabIndex = 182
        Me.IsMultiLotChk.Text = "是否多批次校验"
        Me.IsMultiLotChk.UseVisualStyleBackColor = True
        '
        'IsLinkMSNChk
        '
        Me.IsLinkMSNChk.AutoSize = True
        Me.IsLinkMSNChk.Location = New System.Drawing.Point(443, 111)
        Me.IsLinkMSNChk.Name = "IsLinkMSNChk"
        Me.IsLinkMSNChk.Size = New System.Drawing.Size(114, 16)
        Me.IsLinkMSNChk.TabIndex = 183
        Me.IsLinkMSNChk.Text = "是否MSN绑定校验"
        Me.IsLinkMSNChk.UseVisualStyleBackColor = True
        '
        'IsA20Chk
        '
        Me.IsA20Chk.AutoSize = True
        Me.IsA20Chk.Location = New System.Drawing.Point(557, 111)
        Me.IsA20Chk.Name = "IsA20Chk"
        Me.IsA20Chk.Size = New System.Drawing.Size(114, 16)
        Me.IsA20Chk.TabIndex = 184
        Me.IsA20Chk.Text = "是否A20测试校验"
        Me.IsA20Chk.UseVisualStyleBackColor = True
        '
        'IsA20BurnChk
        '
        Me.IsA20BurnChk.AutoSize = True
        Me.IsA20BurnChk.Location = New System.Drawing.Point(677, 110)
        Me.IsA20BurnChk.Name = "IsA20BurnChk"
        Me.IsA20BurnChk.Size = New System.Drawing.Size(114, 16)
        Me.IsA20BurnChk.TabIndex = 185
        Me.IsA20BurnChk.Text = "是否A20烧入校验"
        Me.IsA20BurnChk.UseVisualStyleBackColor = True
        '
        'IsACRoneChk
        '
        Me.IsACRoneChk.AutoSize = True
        Me.IsACRoneChk.Location = New System.Drawing.Point(797, 111)
        Me.IsACRoneChk.Name = "IsACRoneChk"
        Me.IsACRoneChk.Size = New System.Drawing.Size(96, 16)
        Me.IsACRoneChk.TabIndex = 186
        Me.IsACRoneChk.Text = "是否Acr1校验"
        Me.IsACRoneChk.UseVisualStyleBackColor = True
        '
        'IsAcrIqcChk
        '
        Me.IsAcrIqcChk.AutoSize = True
        Me.IsAcrIqcChk.Location = New System.Drawing.Point(893, 110)
        Me.IsAcrIqcChk.Name = "IsAcrIqcChk"
        Me.IsAcrIqcChk.Size = New System.Drawing.Size(108, 16)
        Me.IsAcrIqcChk.TabIndex = 187
        Me.IsAcrIqcChk.Text = "是否AcrIQC校验"
        Me.IsAcrIqcChk.UseVisualStyleBackColor = True
        '
        'IsSpecChk
        '
        Me.IsSpecChk.AutoSize = True
        Me.IsSpecChk.Location = New System.Drawing.Point(12, 133)
        Me.IsSpecChk.Name = "IsSpecChk"
        Me.IsSpecChk.Size = New System.Drawing.Size(108, 16)
        Me.IsSpecChk.TabIndex = 188
        Me.IsSpecChk.Text = "是否外观检校验"
        Me.IsSpecChk.UseVisualStyleBackColor = True
        '
        'IsW2Chk
        '
        Me.IsW2Chk.AutoSize = True
        Me.IsW2Chk.Location = New System.Drawing.Point(128, 133)
        Me.IsW2Chk.Name = "IsW2Chk"
        Me.IsW2Chk.Size = New System.Drawing.Size(84, 16)
        Me.IsW2Chk.TabIndex = 189
        Me.IsW2Chk.Text = "是否W2校验"
        Me.IsW2Chk.UseVisualStyleBackColor = True
        '
        'IsW2NetLinkChk
        '
        Me.IsW2NetLinkChk.AutoSize = True
        Me.IsW2NetLinkChk.Location = New System.Drawing.Point(218, 133)
        Me.IsW2NetLinkChk.Name = "IsW2NetLinkChk"
        Me.IsW2NetLinkChk.Size = New System.Drawing.Size(132, 16)
        Me.IsW2NetLinkChk.TabIndex = 190
        Me.IsW2NetLinkChk.Text = "是否W2网络连接校验"
        Me.IsW2NetLinkChk.UseVisualStyleBackColor = True
        '
        'IsFinalChk
        '
        Me.IsFinalChk.AutoSize = True
        Me.IsFinalChk.Location = New System.Drawing.Point(356, 133)
        Me.IsFinalChk.Name = "IsFinalChk"
        Me.IsFinalChk.Size = New System.Drawing.Size(96, 16)
        Me.IsFinalChk.TabIndex = 191
        Me.IsFinalChk.Text = "是否终检校验"
        Me.IsFinalChk.UseVisualStyleBackColor = True
        '
        'IsWiggleChk
        '
        Me.IsWiggleChk.AutoSize = True
        Me.IsWiggleChk.Location = New System.Drawing.Point(459, 133)
        Me.IsWiggleChk.Name = "IsWiggleChk"
        Me.IsWiggleChk.Size = New System.Drawing.Size(120, 16)
        Me.IsWiggleChk.TabIndex = 192
        Me.IsWiggleChk.Text = "是否摇摆测试校验"
        Me.IsWiggleChk.UseVisualStyleBackColor = True
        '
        'IsE75Chk
        '
        Me.IsE75Chk.AutoSize = True
        Me.IsE75Chk.Location = New System.Drawing.Point(585, 133)
        Me.IsE75Chk.Name = "IsE75Chk"
        Me.IsE75Chk.Size = New System.Drawing.Size(114, 16)
        Me.IsE75Chk.TabIndex = 193
        Me.IsE75Chk.Text = "是否E75测试校验"
        Me.IsE75Chk.UseVisualStyleBackColor = True
        '
        'IsWeightChk
        '
        Me.IsWeightChk.AutoSize = True
        Me.IsWeightChk.Location = New System.Drawing.Point(703, 133)
        Me.IsWeightChk.Name = "IsWeightChk"
        Me.IsWeightChk.Size = New System.Drawing.Size(96, 16)
        Me.IsWeightChk.TabIndex = 194
        Me.IsWeightChk.Text = "是否称重校验"
        Me.IsWeightChk.UseVisualStyleBackColor = True
        '
        'IsChargeChk
        '
        Me.IsChargeChk.AutoSize = True
        Me.IsChargeChk.Location = New System.Drawing.Point(795, 133)
        Me.IsChargeChk.Name = "IsChargeChk"
        Me.IsChargeChk.Size = New System.Drawing.Size(96, 16)
        Me.IsChargeChk.TabIndex = 195
        Me.IsChargeChk.Text = "是否充电校验"
        Me.IsChargeChk.UseVisualStyleBackColor = True
        '
        'IsTwoInOneChk
        '
        Me.IsTwoInOneChk.AutoSize = True
        Me.IsTwoInOneChk.Location = New System.Drawing.Point(891, 133)
        Me.IsTwoInOneChk.Name = "IsTwoInOneChk"
        Me.IsTwoInOneChk.Size = New System.Drawing.Size(108, 16)
        Me.IsTwoInOneChk.TabIndex = 196
        Me.IsTwoInOneChk.Text = "是否二合一校验"
        Me.IsTwoInOneChk.UseVisualStyleBackColor = True
        '
        'IsW2FT6Chk
        '
        Me.IsW2FT6Chk.AutoSize = True
        Me.IsW2FT6Chk.Location = New System.Drawing.Point(12, 155)
        Me.IsW2FT6Chk.Name = "IsW2FT6Chk"
        Me.IsW2FT6Chk.Size = New System.Drawing.Size(102, 16)
        Me.IsW2FT6Chk.TabIndex = 197
        Me.IsW2FT6Chk.Text = "是否W2FT6校验"
        Me.IsW2FT6Chk.UseVisualStyleBackColor = True
        '
        'IsPLPackChk
        '
        Me.IsPLPackChk.AutoSize = True
        Me.IsPLPackChk.Location = New System.Drawing.Point(128, 155)
        Me.IsPLPackChk.Name = "IsPLPackChk"
        Me.IsPLPackChk.Size = New System.Drawing.Size(108, 16)
        Me.IsPLPackChk.TabIndex = 198
        Me.IsPLPackChk.Text = "是否充电宝校验"
        Me.IsPLPackChk.UseVisualStyleBackColor = True
        '
        'IsAOIOneChk
        '
        Me.IsAOIOneChk.AutoSize = True
        Me.IsAOIOneChk.Location = New System.Drawing.Point(242, 155)
        Me.IsAOIOneChk.Name = "IsAOIOneChk"
        Me.IsAOIOneChk.Size = New System.Drawing.Size(108, 16)
        Me.IsAOIOneChk.TabIndex = 199
        Me.IsAOIOneChk.Text = "是否AOIOne校验"
        Me.IsAOIOneChk.UseVisualStyleBackColor = True
        '
        'IsAllowMuLineChk
        '
        Me.IsAllowMuLineChk.AutoSize = True
        Me.IsAllowMuLineChk.Location = New System.Drawing.Point(356, 155)
        Me.IsAllowMuLineChk.Name = "IsAllowMuLineChk"
        Me.IsAllowMuLineChk.Size = New System.Drawing.Size(132, 16)
        Me.IsAllowMuLineChk.TabIndex = 200
        Me.IsAllowMuLineChk.Text = "是否允许多线别校验"
        Me.IsAllowMuLineChk.UseVisualStyleBackColor = True
        '
        'IsChkParentPart
        '
        Me.IsChkParentPart.AutoSize = True
        Me.IsChkParentPart.Location = New System.Drawing.Point(494, 155)
        Me.IsChkParentPart.Name = "IsChkParentPart"
        Me.IsChkParentPart.Size = New System.Drawing.Size(156, 16)
        Me.IsChkParentPart.TabIndex = 201
        Me.IsChkParentPart.Text = "是否父工艺流程扫描校验"
        Me.IsChkParentPart.UseVisualStyleBackColor = True
        '
        'FrmScanCheckRule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 572)
        Me.Controls.Add(Me.IsChkParentPart)
        Me.Controls.Add(Me.IsAllowMuLineChk)
        Me.Controls.Add(Me.IsAOIOneChk)
        Me.Controls.Add(Me.IsPLPackChk)
        Me.Controls.Add(Me.IsW2FT6Chk)
        Me.Controls.Add(Me.IsTwoInOneChk)
        Me.Controls.Add(Me.IsChargeChk)
        Me.Controls.Add(Me.IsWeightChk)
        Me.Controls.Add(Me.IsE75Chk)
        Me.Controls.Add(Me.IsWiggleChk)
        Me.Controls.Add(Me.IsFinalChk)
        Me.Controls.Add(Me.IsW2NetLinkChk)
        Me.Controls.Add(Me.IsW2Chk)
        Me.Controls.Add(Me.IsSpecChk)
        Me.Controls.Add(Me.IsAcrIqcChk)
        Me.Controls.Add(Me.IsACRoneChk)
        Me.Controls.Add(Me.IsA20BurnChk)
        Me.Controls.Add(Me.IsA20Chk)
        Me.Controls.Add(Me.IsLinkMSNChk)
        Me.Controls.Add(Me.IsMultiLotChk)
        Me.Controls.Add(Me.IsMagnetFChk)
        Me.Controls.Add(Me.IsMagnetSemiChk)
        Me.Controls.Add(Me.IsShipChk)
        Me.Controls.Add(Me.txtRanOQCQty)
        Me.Controls.Add(Me.lblChouJian)
        Me.Controls.Add(Me.IsOQCChk)
        Me.Controls.Add(Me.IsRanOQCChk)
        Me.Controls.Add(Me.IsLotChk)
        Me.Controls.Add(Me.IsGenChk)
        Me.Controls.Add(Me.IsVoltageChk)
        Me.Controls.Add(Me.IsFT2Chk)
        Me.Controls.Add(Me.IsFT1Chk)
        Me.Controls.Add(Me.IsAoiChk)
        Me.Controls.Add(Me.IsAcrChk)
        Me.Controls.Add(Me.IsGuesFinChk)
        Me.Controls.Add(Me.IsGuesSemiChk)
        Me.Controls.Add(Me.IsPCBAChk)
        Me.Controls.Add(Me.IsLaserChk)
        Me.Controls.Add(Me.IsNIChk)
        Me.Controls.Add(Me.txtScanOrder)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtVersion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvScanChkRule)
        Me.Controls.Add(Me.TxtPavcPart)
        Me.Controls.Add(Me.LelTpart)
        Me.Controls.Add(Me.LblPartID)
        Me.Controls.Add(Me.ToolBt)
        Me.Controls.Add(Me.CobStationid)
        Me.Controls.Add(Me.TxtStationNo)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtTavcPart)
        Me.Name = "FrmScanCheckRule"
        Me.Text = "扫描校验规则设置"
        CType(Me.dgvScanChkRule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvScanChkRule As System.Windows.Forms.DataGridView
    Friend WithEvents TxtPavcPart As System.Windows.Forms.TextBox
    Friend WithEvents Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents UnDo As System.Windows.Forms.ToolStripButton
    Friend WithEvents LelTpart As System.Windows.Forms.Label
    Friend WithEvents LblPartID As System.Windows.Forms.Label
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents EditFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FileRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtTavcPart As System.Windows.Forms.TextBox
    Friend WithEvents TxtStationNo As System.Windows.Forms.TextBox
    Friend WithEvents CobStationid As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtScanOrder As System.Windows.Forms.TextBox
    Friend WithEvents IsNIChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsLaserChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsPCBAChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsGuesSemiChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsGuesFinChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsAcrChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsAoiChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsFT1Chk As System.Windows.Forms.CheckBox
    Friend WithEvents IsFT2Chk As System.Windows.Forms.CheckBox
    Friend WithEvents IsVoltageChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsGenChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsLotChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsRanOQCChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsOQCChk As System.Windows.Forms.CheckBox
    Friend WithEvents txtRanOQCQty As System.Windows.Forms.TextBox
    Friend WithEvents lblChouJian As System.Windows.Forms.Label
    Friend WithEvents IsShipChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsMagnetSemiChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsMagnetFChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsMultiLotChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsLinkMSNChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsA20Chk As System.Windows.Forms.CheckBox
    Friend WithEvents IsA20BurnChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsACRoneChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsAcrIqcChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsSpecChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsW2Chk As System.Windows.Forms.CheckBox
    Friend WithEvents IsW2NetLinkChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsFinalChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsWiggleChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsE75Chk As System.Windows.Forms.CheckBox
    Friend WithEvents IsWeightChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsChargeChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsTwoInOneChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsW2FT6Chk As System.Windows.Forms.CheckBox
    Friend WithEvents IsPLPackChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsAOIOneChk As System.Windows.Forms.CheckBox
    Private WithEvents toolAbandon As System.Windows.Forms.ToolStripButton
    Friend WithEvents IsAllowMuLineChk As System.Windows.Forms.CheckBox
    Friend WithEvents IsChkParentPart As System.Windows.Forms.CheckBox
End Class
