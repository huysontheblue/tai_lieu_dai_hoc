<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSysMenu
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSysMenu))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBoxMenu = New System.Windows.Forms.GroupBox()
        Me.tvMenu = New System.Windows.Forms.TreeView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtMenuKey = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtMenuName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtParentName = New System.Windows.Forms.TextBox()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtTreeTag = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtOrderBy = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NewFile = New System.Windows.Forms.ToolStripButton()
        Me.EditFile = New System.Windows.Forms.ToolStripButton()
        Me.Delete = New System.Windows.Forms.ToolStripButton()
        Me.Save = New System.Windows.Forms.ToolStripButton()
        Me.FileRefresh = New System.Windows.Forms.ToolStripButton()
        Me.Back = New System.Windows.Forms.ToolStripButton()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEnname = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFormID = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtButtonId = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbolisty = New System.Windows.Forms.ComboBox()
        Me.cmbUsey = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtImageName = New System.Windows.Forms.TextBox()
        Me.picBoxImageName = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkboxIsMdiChildren = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.BtnSelectImage = New System.Windows.Forms.Button()
        Me.BtnSelectItem = New System.Windows.Forms.Button()
        Me.TxtFieldId = New System.Windows.Forms.TextBox()
        Me.TxtFieldName = New System.Windows.Forms.TextBox()
        Me.chkReportUsey = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dgvuser = New System.Windows.Forms.DataGridView()
        Me.ContextMenuMould = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmi_MaintenanceType = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBoxMenu.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.picBoxImageName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvuser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuMould.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxMenu
        '
        Me.GroupBoxMenu.Controls.Add(Me.tvMenu)
        Me.GroupBoxMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBoxMenu.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxMenu.Name = "GroupBoxMenu"
        Me.GroupBoxMenu.Size = New System.Drawing.Size(377, 461)
        Me.GroupBoxMenu.TabIndex = 0
        Me.GroupBoxMenu.TabStop = False
        Me.GroupBoxMenu.Text = "系统菜单列表"
        '
        'tvMenu
        '
        Me.tvMenu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvMenu.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvMenu.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tvMenu.ItemHeight = 18
        Me.tvMenu.Location = New System.Drawing.Point(6, 20)
        Me.tvMenu.Name = "tvMenu"
        Me.tvMenu.Size = New System.Drawing.Size(365, 435)
        Me.tvMenu.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(486, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "菜单Key"
        '
        'TxtMenuKey
        '
        Me.TxtMenuKey.Location = New System.Drawing.Point(543, 79)
        Me.TxtMenuKey.Name = "TxtMenuKey"
        Me.TxtMenuKey.Size = New System.Drawing.Size(262, 21)
        Me.TxtMenuKey.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(482, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "菜单名称"
        '
        'TxtMenuName
        '
        Me.TxtMenuName.Location = New System.Drawing.Point(543, 117)
        Me.TxtMenuName.Name = "TxtMenuName"
        Me.TxtMenuName.Size = New System.Drawing.Size(262, 21)
        Me.TxtMenuName.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(480, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "上级菜单"
        '
        'TxtParentName
        '
        Me.TxtParentName.Location = New System.Drawing.Point(543, 42)
        Me.TxtParentName.Name = "TxtParentName"
        Me.TxtParentName.ReadOnly = True
        Me.TxtParentName.Size = New System.Drawing.Size(169, 21)
        Me.TxtParentName.TabIndex = 6
        '
        'BtnSelect
        '
        Me.BtnSelect.Location = New System.Drawing.Point(730, 40)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelect.TabIndex = 7
        Me.BtnSelect.Text = "选择菜单"
        Me.BtnSelect.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(482, 223)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "程序名称"
        '
        'TxtTreeTag
        '
        Me.TxtTreeTag.Location = New System.Drawing.Point(543, 218)
        Me.TxtTreeTag.Name = "TxtTreeTag"
        Me.TxtTreeTag.Size = New System.Drawing.Size(262, 21)
        Me.TxtTreeTag.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(482, 255)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "菜单排序"
        '
        'TxtOrderBy
        '
        Me.TxtOrderBy.Location = New System.Drawing.Point(543, 252)
        Me.TxtOrderBy.Name = "TxtOrderBy"
        Me.TxtOrderBy.Size = New System.Drawing.Size(262, 21)
        Me.TxtOrderBy.TabIndex = 11
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewFile, Me.EditFile, Me.Delete, Me.Save, Me.FileRefresh, Me.Back, Me.toolExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(377, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(993, 25)
        Me.ToolStrip1.TabIndex = 12
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NewFile
        '
        Me.NewFile.Image = CType(resources.GetObject("NewFile.Image"), System.Drawing.Image)
        Me.NewFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewFile.Name = "NewFile"
        Me.NewFile.Size = New System.Drawing.Size(52, 22)
        Me.NewFile.Text = "新增"
        Me.NewFile.ToolTipText = "新增"
        '
        'EditFile
        '
        Me.EditFile.Image = CType(resources.GetObject("EditFile.Image"), System.Drawing.Image)
        Me.EditFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditFile.Name = "EditFile"
        Me.EditFile.Size = New System.Drawing.Size(52, 22)
        Me.EditFile.Text = "修改"
        Me.EditFile.ToolTipText = "修改"
        '
        'Delete
        '
        Me.Delete.Image = CType(resources.GetObject("Delete.Image"), System.Drawing.Image)
        Me.Delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(52, 22)
        Me.Delete.Text = "刪除"
        Me.Delete.ToolTipText = "刪除"
        '
        'Save
        '
        Me.Save.Enabled = False
        Me.Save.Image = CType(resources.GetObject("Save.Image"), System.Drawing.Image)
        Me.Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(52, 22)
        Me.Save.Text = "保存"
        Me.Save.ToolTipText = "保存"
        '
        'FileRefresh
        '
        Me.FileRefresh.Image = CType(resources.GetObject("FileRefresh.Image"), System.Drawing.Image)
        Me.FileRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.FileRefresh.Name = "FileRefresh"
        Me.FileRefresh.Size = New System.Drawing.Size(52, 22)
        Me.FileRefresh.Text = "刷新"
        Me.FileRefresh.ToolTipText = "刷新"
        '
        'Back
        '
        Me.Back.Enabled = False
        Me.Back.Image = CType(resources.GetObject("Back.Image"), System.Drawing.Image)
        Me.Back.ImageTransparentColor = System.Drawing.Color.White
        Me.Back.Name = "Back"
        Me.Back.Size = New System.Drawing.Size(52, 22)
        Me.Back.Text = "返回"
        Me.Back.ToolTipText = "退出"
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.White
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(72, 22)
        Me.toolExit.Text = "退 出(&X)"
        Me.toolExit.ToolTipText = "退出"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(506, 193)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Usey"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(482, 153)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "英文名称"
        '
        'txtEnname
        '
        Me.txtEnname.Location = New System.Drawing.Point(543, 151)
        Me.txtEnname.Name = "txtEnname"
        Me.txtEnname.Size = New System.Drawing.Size(262, 21)
        Me.txtEnname.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(496, 289)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "FormId"
        '
        'txtFormID
        '
        Me.txtFormID.Location = New System.Drawing.Point(543, 286)
        Me.txtFormID.Name = "txtFormID"
        Me.txtFormID.Size = New System.Drawing.Size(262, 21)
        Me.txtFormID.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(484, 323)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "ButtonId"
        '
        'txtButtonId
        '
        Me.txtButtonId.Location = New System.Drawing.Point(543, 320)
        Me.txtButtonId.Name = "txtButtonId"
        Me.txtButtonId.Size = New System.Drawing.Size(262, 21)
        Me.txtButtonId.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(500, 357)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 12)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "listy"
        '
        'cmbolisty
        '
        Me.cmbolisty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbolisty.FormattingEnabled = True
        Me.cmbolisty.Items.AddRange(New Object() {"Y", "N"})
        Me.cmbolisty.Location = New System.Drawing.Point(543, 354)
        Me.cmbolisty.Name = "cmbolisty"
        Me.cmbolisty.Size = New System.Drawing.Size(262, 20)
        Me.cmbolisty.TabIndex = 22
        '
        'cmbUsey
        '
        Me.cmbUsey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsey.FormattingEnabled = True
        Me.cmbUsey.Items.AddRange(New Object() {"Y", "N"})
        Me.cmbUsey.Location = New System.Drawing.Point(543, 185)
        Me.cmbUsey.Name = "cmbUsey"
        Me.cmbUsey.Size = New System.Drawing.Size(262, 20)
        Me.cmbUsey.TabIndex = 23
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(484, 390)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 12)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "图标名称"
        '
        'txtImageName
        '
        Me.txtImageName.Location = New System.Drawing.Point(543, 387)
        Me.txtImageName.Name = "txtImageName"
        Me.txtImageName.Size = New System.Drawing.Size(262, 21)
        Me.txtImageName.TabIndex = 25
        '
        'picBoxImageName
        '
        Me.picBoxImageName.Location = New System.Drawing.Point(858, 305)
        Me.picBoxImageName.Name = "picBoxImageName"
        Me.picBoxImageName.Size = New System.Drawing.Size(36, 36)
        Me.picBoxImageName.TabIndex = 26
        Me.picBoxImageName.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(442, 426)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 12)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "是否是Mdi子窗体"
        '
        'chkboxIsMdiChildren
        '
        '
        '
        '
        Me.chkboxIsMdiChildren.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkboxIsMdiChildren.CheckSignSize = New System.Drawing.Size(30, 30)
        Me.chkboxIsMdiChildren.Location = New System.Drawing.Point(543, 421)
        Me.chkboxIsMdiChildren.Name = "chkboxIsMdiChildren"
        Me.chkboxIsMdiChildren.Size = New System.Drawing.Size(32, 23)
        Me.chkboxIsMdiChildren.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkboxIsMdiChildren.TabIndex = 28
        '
        'BtnSelectImage
        '
        Me.BtnSelectImage.Location = New System.Drawing.Point(838, 354)
        Me.BtnSelectImage.Name = "BtnSelectImage"
        Me.BtnSelectImage.Size = New System.Drawing.Size(95, 23)
        Me.BtnSelectImage.TabIndex = 29
        Me.BtnSelectImage.Text = "选择资源图标"
        Me.BtnSelectImage.UseVisualStyleBackColor = True
        '
        'BtnSelectItem
        '
        Me.BtnSelectItem.Location = New System.Drawing.Point(811, 115)
        Me.BtnSelectItem.Name = "BtnSelectItem"
        Me.BtnSelectItem.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectItem.TabIndex = 30
        Me.BtnSelectItem.Text = "选择"
        Me.BtnSelectItem.UseVisualStyleBackColor = True
        Me.BtnSelectItem.Visible = False
        '
        'TxtFieldId
        '
        Me.TxtFieldId.Location = New System.Drawing.Point(826, 144)
        Me.TxtFieldId.Name = "TxtFieldId"
        Me.TxtFieldId.Size = New System.Drawing.Size(100, 21)
        Me.TxtFieldId.TabIndex = 31
        Me.TxtFieldId.Visible = False
        '
        'TxtFieldName
        '
        Me.TxtFieldName.Location = New System.Drawing.Point(826, 171)
        Me.TxtFieldName.Name = "TxtFieldName"
        Me.TxtFieldName.Size = New System.Drawing.Size(100, 21)
        Me.TxtFieldName.TabIndex = 32
        Me.TxtFieldName.Visible = False
        '
        'chkReportUsey
        '
        '
        '
        '
        Me.chkReportUsey.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkReportUsey.CheckSignSize = New System.Drawing.Size(30, 30)
        Me.chkReportUsey.Location = New System.Drawing.Point(743, 421)
        Me.chkReportUsey.Name = "chkReportUsey"
        Me.chkReportUsey.Size = New System.Drawing.Size(32, 23)
        Me.chkReportUsey.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkReportUsey.TabIndex = 33
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(629, 426)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(113, 12)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "是否自定义报表菜单"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(838, 390)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(95, 23)
        Me.btnUpload.TabIndex = 35
        Me.btnUpload.Text = "选择本地图标"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.dgvuser)
        Me.GroupBox1.Location = New System.Drawing.Point(938, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 461)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "权限用户"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(98, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 12)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "查询结果{0}笔"
        '
        'dgvuser
        '
        Me.dgvuser.AllowUserToAddRows = False
        Me.dgvuser.AllowUserToDeleteRows = False
        Me.dgvuser.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvuser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvuser.ContextMenuStrip = Me.ContextMenuMould
        Me.dgvuser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvuser.Location = New System.Drawing.Point(3, 17)
        Me.dgvuser.MultiSelect = False
        Me.dgvuser.Name = "dgvuser"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.dgvuser.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvuser.RowTemplate.Height = 23
        Me.dgvuser.Size = New System.Drawing.Size(426, 441)
        Me.dgvuser.TabIndex = 0
        '
        'ContextMenuMould
        '
        Me.ContextMenuMould.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_MaintenanceType})
        Me.ContextMenuMould.Name = "ContextMenuMould"
        Me.ContextMenuMould.Size = New System.Drawing.Size(101, 26)
        '
        'tsmi_MaintenanceType
        '
        Me.tsmi_MaintenanceType.Name = "tsmi_MaintenanceType"
        Me.tsmi_MaintenanceType.Size = New System.Drawing.Size(100, 22)
        Me.tsmi_MaintenanceType.Text = "移除"
        '
        'FrmSysMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 461)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.chkReportUsey)
        Me.Controls.Add(Me.TxtFieldName)
        Me.Controls.Add(Me.TxtFieldId)
        Me.Controls.Add(Me.BtnSelectItem)
        Me.Controls.Add(Me.BtnSelectImage)
        Me.Controls.Add(Me.chkboxIsMdiChildren)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.picBoxImageName)
        Me.Controls.Add(Me.txtImageName)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmbUsey)
        Me.Controls.Add(Me.cmbolisty)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtButtonId)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtFormID)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtEnname)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TxtOrderBy)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtTreeTag)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnSelect)
        Me.Controls.Add(Me.TxtParentName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtMenuName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtMenuKey)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBoxMenu)
        Me.Name = "FrmSysMenu"
        Me.Text = "FrmSysMenu"
        Me.GroupBoxMenu.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.picBoxImageName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvuser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuMould.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBoxMenu As System.Windows.Forms.GroupBox
    Friend WithEvents tvMenu As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtMenuKey As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtMenuName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtParentName As System.Windows.Forms.TextBox
    Friend WithEvents BtnSelect As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtTreeTag As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtOrderBy As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NewFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents EditFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents Delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents FileRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Back As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtEnname As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFormID As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtButtonId As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbolisty As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUsey As System.Windows.Forms.ComboBox
    Friend WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtImageName As System.Windows.Forms.TextBox
    Friend WithEvents picBoxImageName As System.Windows.Forms.PictureBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BtnSelectImage As System.Windows.Forms.Button
    Friend WithEvents BtnSelectItem As System.Windows.Forms.Button
    Friend WithEvents TxtFieldId As System.Windows.Forms.TextBox
    Friend WithEvents TxtFieldName As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Private WithEvents chkboxIsMdiChildren As DevComponents.DotNetBar.Controls.CheckBoxX
    Private WithEvents chkReportUsey As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvuser As System.Windows.Forms.DataGridView
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuMould As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmi_MaintenanceType As System.Windows.Forms.ToolStripMenuItem
End Class
