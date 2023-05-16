<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReleaseFileManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReleaseFileManagement))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NavigationPaneList = New DevComponents.DotNetBar.NavigationPane()
        Me.NavigationPanePanel1 = New DevComponents.DotNetBar.NavigationPanePanel()
        Me.tvReleasedVersion = New System.Windows.Forms.TreeView()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ExpandableSplitter1 = New DevComponents.DotNetBar.ExpandableSplitter()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEnable = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDisabled = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.txtReleaseFileName = New DevComponents.DotNetBar.TextBoxItem()
        Me.btnQuery = New DevComponents.DotNetBar.ButtonItem()
        Me.lblMessage = New DevComponents.DotNetBar.LabelItem()
        Me.dgvReleaseFile = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Fileno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RowNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReleasedVersionName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Filename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProgramVersion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fileversion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Factory_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProfitCenter_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fileclass = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SystemUpdateStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MinimumVersion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Filetime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Userid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menuStrip1.SuspendLayout()
        Me.NavigationPaneList.SuspendLayout()
        Me.NavigationPanePanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReleaseFile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menuStrip1
        '
        Me.menuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2, Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5, Me.toolStripMenuItem6})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(882, 25)
        Me.menuStrip1.TabIndex = 145
        Me.menuStrip1.Text = "menuStrip1"
        '
        'toolStripMenuItem1
        '
        Me.toolStripMenuItem1.ForeColor = System.Drawing.Color.Black
        Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
        Me.toolStripMenuItem1.Size = New System.Drawing.Size(59, 21)
        Me.toolStripMenuItem1.Text = "系统(&S)"
        '
        'toolStripMenuItem2
        '
        Me.toolStripMenuItem2.ForeColor = System.Drawing.Color.Black
        Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
        Me.toolStripMenuItem2.Size = New System.Drawing.Size(58, 21)
        Me.toolStripMenuItem2.Text = "文件(&F)"
        '
        'toolStripMenuItem3
        '
        Me.toolStripMenuItem3.ForeColor = System.Drawing.Color.Black
        Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
        Me.toolStripMenuItem3.Size = New System.Drawing.Size(60, 21)
        Me.toolStripMenuItem3.Text = "查看(&V)"
        '
        'toolStripMenuItem4
        '
        Me.toolStripMenuItem4.ForeColor = System.Drawing.Color.Black
        Me.toolStripMenuItem4.Name = "toolStripMenuItem4"
        Me.toolStripMenuItem4.Size = New System.Drawing.Size(59, 21)
        Me.toolStripMenuItem4.Text = "工具(&T)"
        '
        'toolStripMenuItem5
        '
        Me.toolStripMenuItem5.ForeColor = System.Drawing.Color.Black
        Me.toolStripMenuItem5.Name = "toolStripMenuItem5"
        Me.toolStripMenuItem5.Size = New System.Drawing.Size(64, 21)
        Me.toolStripMenuItem5.Text = "窗口(&W)"
        '
        'toolStripMenuItem6
        '
        Me.toolStripMenuItem6.ForeColor = System.Drawing.Color.Black
        Me.toolStripMenuItem6.Name = "toolStripMenuItem6"
        Me.toolStripMenuItem6.Size = New System.Drawing.Size(61, 21)
        Me.toolStripMenuItem6.Text = "帮助(&H)"
        '
        'NavigationPaneList
        '
        Me.NavigationPaneList.Controls.Add(Me.NavigationPanePanel1)
        Me.NavigationPaneList.Dock = System.Windows.Forms.DockStyle.Left
        Me.NavigationPaneList.ItemPaddingBottom = 2
        Me.NavigationPaneList.ItemPaddingTop = 2
        Me.NavigationPaneList.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem2})
        Me.NavigationPaneList.Location = New System.Drawing.Point(0, 25)
        Me.NavigationPaneList.Name = "NavigationPaneList"
        Me.NavigationPaneList.Size = New System.Drawing.Size(206, 385)
        Me.NavigationPaneList.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.NavigationPaneList.TabIndex = 148
        '
        '
        '
        Me.NavigationPaneList.TitlePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.NavigationPaneList.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.NavigationPaneList.TitlePanel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavigationPaneList.TitlePanel.Location = New System.Drawing.Point(0, 0)
        Me.NavigationPaneList.TitlePanel.Name = "panelTitle"
        Me.NavigationPaneList.TitlePanel.Size = New System.Drawing.Size(206, 24)
        Me.NavigationPaneList.TitlePanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.NavigationPaneList.TitlePanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.NavigationPaneList.TitlePanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPaneList.TitlePanel.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.NavigationPaneList.TitlePanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.NavigationPaneList.TitlePanel.Style.GradientAngle = 90
        Me.NavigationPaneList.TitlePanel.Style.MarginLeft = 4
        Me.NavigationPaneList.TitlePanel.TabIndex = 0
        Me.NavigationPaneList.TitlePanel.Text = "发布版本"
        '
        'NavigationPanePanel1
        '
        Me.NavigationPanePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.NavigationPanePanel1.Controls.Add(Me.tvReleasedVersion)
        Me.NavigationPanePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationPanePanel1.Location = New System.Drawing.Point(0, 24)
        Me.NavigationPanePanel1.Name = "NavigationPanePanel1"
        Me.NavigationPanePanel1.ParentItem = Me.ButtonItem2
        Me.NavigationPanePanel1.Size = New System.Drawing.Size(206, 329)
        Me.NavigationPanePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.NavigationPanePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.NavigationPanePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPanePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.NavigationPanePanel1.Style.GradientAngle = 90
        Me.NavigationPanePanel1.TabIndex = 2
        '
        'tvReleasedVersion
        '
        Me.tvReleasedVersion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvReleasedVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvReleasedVersion.Location = New System.Drawing.Point(0, 0)
        Me.tvReleasedVersion.Name = "tvReleasedVersion"
        Me.tvReleasedVersion.Scrollable = False
        Me.tvReleasedVersion.Size = New System.Drawing.Size(206, 329)
        Me.tvReleasedVersion.Sorted = True
        Me.tvReleasedVersion.TabIndex = 2
        '
        'ButtonItem2
        '
        Me.ButtonItem2.Checked = True
        Me.ButtonItem2.Image = CType(resources.GetObject("ButtonItem2.Image"), System.Drawing.Image)
        Me.ButtonItem2.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.OptionGroup = "navBar"
        Me.ButtonItem2.Text = "发布版本"
        '
        'ExpandableSplitter1
        '
        Me.ExpandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.ExpandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandableSplitter1.ExpandableControl = Me.NavigationPaneList
        Me.ExpandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.ExpandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.ExpandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.ExpandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.ExpandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.ExpandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.ExpandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
        Me.ExpandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.ExpandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.ExpandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.ExpandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.ExpandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.ExpandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter1.Location = New System.Drawing.Point(206, 25)
        Me.ExpandableSplitter1.Name = "ExpandableSplitter1"
        Me.ExpandableSplitter1.Size = New System.Drawing.Size(6, 385)
        Me.ExpandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
        Me.ExpandableSplitter1.TabIndex = 151
        Me.ExpandableSplitter1.TabStop = False
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnAdd, Me.btnDelete, Me.btnEdit, Me.btnEnable, Me.btnDisabled, Me.LabelItem5, Me.LabelItem2, Me.txtReleaseFileName, Me.btnQuery, Me.lblMessage})
        Me.Bar1.Location = New System.Drawing.Point(212, 25)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.SingleLineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Bar1.Size = New System.Drawing.Size(670, 27)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 153
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnAdd
        '
        Me.btnAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnAdd.Image = Global.ProgramRelease.My.Resources.Resources.add
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Text = "添加"
        Me.btnAdd.Tooltip = "添加"
        '
        'btnDelete
        '
        Me.btnDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Image = Global.ProgramRelease.My.Resources.Resources.delete
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Text = "删除"
        Me.btnDelete.Tooltip = "删除"
        '
        'btnEdit
        '
        Me.btnEdit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnEdit.Image = Global.ProgramRelease.My.Resources.Resources.edit
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Text = "修改"
        Me.btnEdit.Tooltip = "修改"
        '
        'btnEnable
        '
        Me.btnEnable.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnEnable.Image = Global.ProgramRelease.My.Resources.Resources.control_play_blue
        Me.btnEnable.Name = "btnEnable"
        Me.btnEnable.Text = "启用"
        Me.btnEnable.Tooltip = "启用"
        '
        'btnDisabled
        '
        Me.btnDisabled.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDisabled.Image = Global.ProgramRelease.My.Resources.Resources.control_pause_blue
        Me.btnDisabled.Name = "btnDisabled"
        Me.btnDisabled.Text = "停用"
        Me.btnDisabled.Tooltip = "停用"
        '
        'LabelItem5
        '
        Me.LabelItem5.BackColor = System.Drawing.Color.Transparent
        Me.LabelItem5.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem5.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem5.Name = "LabelItem5"
        Me.LabelItem5.PaddingBottom = 1
        Me.LabelItem5.PaddingLeft = 10
        Me.LabelItem5.PaddingTop = 1
        Me.LabelItem5.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelItem5.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "启用"
        Me.ButtonItem1.Tooltip = "启用"
        '
        'LabelItem2
        '
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.Text = "发布程序名称:"
        '
        'txtReleaseFileName
        '
        Me.txtReleaseFileName.FocusHighlightColor = System.Drawing.Color.Transparent
        Me.txtReleaseFileName.Name = "txtReleaseFileName"
        Me.txtReleaseFileName.Tag = "查询单号"
        Me.txtReleaseFileName.TextBoxWidth = 150
        Me.txtReleaseFileName.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'btnQuery
        '
        Me.btnQuery.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnQuery.Image = Global.ProgramRelease.My.Resources.Resources.query
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Tag = "查询"
        Me.btnQuery.Text = "查询"
        '
        'lblMessage
        '
        Me.lblMessage.Name = "lblMessage"
        '
        'dgvReleaseFile
        '
        Me.dgvReleaseFile.AllowUserToAddRows = False
        Me.dgvReleaseFile.AllowUserToDeleteRows = False
        Me.dgvReleaseFile.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReleaseFile.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReleaseFile.ColumnHeadersHeight = 32
        Me.dgvReleaseFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvReleaseFile.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fileno, Me.RowNum, Me.ReleasedVersionName, Me.Filename, Me.ProgramVersion, Me.Fileversion, Me.Factory_Id, Me.ProfitCenter_Id, Me.Fileclass, Me.SystemUpdateStatus, Me.UpdateType, Me.MinimumVersion, Me.Filetime, Me.Remark, Me.Userid, Me.Intime, Me.Size, Me.Usey})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReleaseFile.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvReleaseFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReleaseFile.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvReleaseFile.Location = New System.Drawing.Point(212, 52)
        Me.dgvReleaseFile.Name = "dgvReleaseFile"
        Me.dgvReleaseFile.ReadOnly = True
        Me.dgvReleaseFile.RowHeadersWidth = 15
        Me.dgvReleaseFile.RowTemplate.Height = 28
        Me.dgvReleaseFile.Size = New System.Drawing.Size(670, 358)
        Me.dgvReleaseFile.TabIndex = 154
        '
        'Fileno
        '
        Me.Fileno.DataPropertyName = "Fileno"
        Me.Fileno.HeaderText = "Fileno"
        Me.Fileno.Name = "Fileno"
        Me.Fileno.ReadOnly = True
        Me.Fileno.Visible = False
        '
        'RowNum
        '
        Me.RowNum.DataPropertyName = "RowNum"
        Me.RowNum.HeaderText = "序号"
        Me.RowNum.Name = "RowNum"
        Me.RowNum.ReadOnly = True
        Me.RowNum.Width = 40
        '
        'ReleasedVersionName
        '
        Me.ReleasedVersionName.DataPropertyName = "ReleasedVersionName"
        Me.ReleasedVersionName.HeaderText = "发布版本"
        Me.ReleasedVersionName.Name = "ReleasedVersionName"
        Me.ReleasedVersionName.ReadOnly = True
        '
        'Filename
        '
        Me.Filename.DataPropertyName = "Filename"
        Me.Filename.HeaderText = "发布程序"
        Me.Filename.Name = "Filename"
        Me.Filename.ReadOnly = True
        Me.Filename.Width = 200
        '
        'ProgramVersion
        '
        Me.ProgramVersion.DataPropertyName = "ProgramVersion"
        Me.ProgramVersion.HeaderText = "程序版本"
        Me.ProgramVersion.Name = "ProgramVersion"
        Me.ProgramVersion.ReadOnly = True
        Me.ProgramVersion.Width = 80
        '
        'Fileversion
        '
        Me.Fileversion.DataPropertyName = "Fileversion"
        Me.Fileversion.HeaderText = "文件版本"
        Me.Fileversion.Name = "Fileversion"
        Me.Fileversion.ReadOnly = True
        Me.Fileversion.Width = 80
        '
        'Factory_Id
        '
        Me.Factory_Id.DataPropertyName = "Factory_Id"
        Me.Factory_Id.HeaderText = "工厂"
        Me.Factory_Id.Name = "Factory_Id"
        Me.Factory_Id.ReadOnly = True
        Me.Factory_Id.Width = 60
        '
        'ProfitCenter_Id
        '
        Me.ProfitCenter_Id.DataPropertyName = "ProfitCenter_Id"
        Me.ProfitCenter_Id.HeaderText = "利润中心"
        Me.ProfitCenter_Id.Name = "ProfitCenter_Id"
        Me.ProfitCenter_Id.ReadOnly = True
        Me.ProfitCenter_Id.Width = 60
        '
        'Fileclass
        '
        Me.Fileclass.DataPropertyName = "Fileclass"
        Me.Fileclass.HeaderText = "文件类别"
        Me.Fileclass.Name = "Fileclass"
        Me.Fileclass.ReadOnly = True
        Me.Fileclass.Width = 80
        '
        'SystemUpdateStatus
        '
        Me.SystemUpdateStatus.DataPropertyName = "SystemUpdateStatus"
        Me.SystemUpdateStatus.HeaderText = "更新类别"
        Me.SystemUpdateStatus.Name = "SystemUpdateStatus"
        Me.SystemUpdateStatus.ReadOnly = True
        Me.SystemUpdateStatus.Width = 80
        '
        'UpdateType
        '
        Me.UpdateType.DataPropertyName = "UpdateType"
        Me.UpdateType.HeaderText = "更新类型"
        Me.UpdateType.Name = "UpdateType"
        Me.UpdateType.ReadOnly = True
        Me.UpdateType.Width = 80
        '
        'MinimumVersion
        '
        Me.MinimumVersion.DataPropertyName = "MinimumVersion"
        Me.MinimumVersion.HeaderText = "最低版本"
        Me.MinimumVersion.Name = "MinimumVersion"
        Me.MinimumVersion.ReadOnly = True
        Me.MinimumVersion.Width = 80
        '
        'Filetime
        '
        Me.Filetime.DataPropertyName = "Filetime"
        Me.Filetime.HeaderText = "最后修改时间"
        Me.Filetime.Name = "Filetime"
        Me.Filetime.ReadOnly = True
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "说明"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        '
        'Userid
        '
        Me.Userid.DataPropertyName = "Userid"
        Me.Userid.HeaderText = "上传用户"
        Me.Userid.Name = "Userid"
        Me.Userid.ReadOnly = True
        Me.Userid.Width = 80
        '
        'Intime
        '
        Me.Intime.DataPropertyName = "Intime"
        Me.Intime.HeaderText = "上传时间"
        Me.Intime.Name = "Intime"
        Me.Intime.ReadOnly = True
        '
        'Size
        '
        Me.Size.DataPropertyName = "Size"
        Me.Size.HeaderText = "文件大小"
        Me.Size.Name = "Size"
        Me.Size.ReadOnly = True
        Me.Size.Width = 80
        '
        'Usey
        '
        Me.Usey.DataPropertyName = "Usey"
        Me.Usey.HeaderText = "状态"
        Me.Usey.Name = "Usey"
        Me.Usey.ReadOnly = True
        Me.Usey.Width = 60
        '
        'FrmReleaseFileManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 410)
        Me.Controls.Add(Me.dgvReleaseFile)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.ExpandableSplitter1)
        Me.Controls.Add(Me.NavigationPaneList)
        Me.Controls.Add(Me.menuStrip1)
        Me.Name = "FrmReleaseFileManagement"
        Me.ShowIcon = False
        Me.Text = "发布文件管理"
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.NavigationPaneList.ResumeLayout(False)
        Me.NavigationPanePanel1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReleaseFile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NavigationPaneList As DevComponents.DotNetBar.NavigationPane
    Friend WithEvents NavigationPanePanel1 As DevComponents.DotNetBar.NavigationPanePanel
    Private WithEvents tvReleasedVersion As System.Windows.Forms.TreeView
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ExpandableSplitter1 As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEnable As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDisabled As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents txtReleaseFileName As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents btnQuery As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelItem
    Friend WithEvents dgvReleaseFile As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Fileno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RowNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReleasedVersionName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Filename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProgramVersion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fileversion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Factory_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProfitCenter_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fileclass As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SystemUpdateStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinimumVersion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Filetime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Userid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Intime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usey As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
