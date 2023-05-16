<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUserManage
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUserManage))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LabDescript = New System.Windows.Forms.Label()
        Me.ChBusey = New System.Windows.Forms.CheckBox()
        Me.CboFactoryID = New System.Windows.Forms.ComboBox()
        Me.LabUserid = New System.Windows.Forms.Label()
        Me.LabFactory = New System.Windows.Forms.Label()
        Me.TxtUserID = New System.Windows.Forms.TextBox()
        Me.TxtUserName = New System.Windows.Forms.TextBox()
        Me.CboGroupID = New System.Windows.Forms.ComboBox()
        Me.LabDept = New System.Windows.Forms.Label()
        Me.LabGroup = New System.Windows.Forms.Label()
        Me.LabUsername = New System.Windows.Forms.Label()
        Me.LabJobs = New System.Windows.Forms.Label()
        Me.CboJobs = New System.Windows.Forms.ComboBox()
        Me.CboTeam = New System.Windows.Forms.ComboBox()
        Me.LabTeam = New System.Windows.Forms.Label()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewFile = New System.Windows.Forms.ToolStripButton()
        Me.EditFile = New System.Windows.Forms.ToolStripButton()
        Me.Save = New System.Windows.Forms.ToolStripButton()
        Me.Delete = New System.Windows.Forms.ToolStripButton()
        Me.StopFile = New System.Windows.Forms.ToolStripButton()
        Me.UnDo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Search = New System.Windows.Forms.ToolStripButton()
        Me.btnSetFinger = New System.Windows.Forms.ToolStripButton()
        Me.ReSetPw = New System.Windows.Forms.ToolStripButton()
        Me.ToolSuperPwd = New System.Windows.Forms.ToolStripButton()
        Me.SetRole = New System.Windows.Forms.ToolStripButton()
        Me.Export = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.FileRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TpUser = New System.Windows.Forms.TabPage()
        Me.cbousergrade = New System.Windows.Forms.ComboBox()
        Me.ChOutuser = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboverifytype = New System.Windows.Forms.ComboBox()
        Me.TxtAutoId = New System.Windows.Forms.TextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TxtUnSearch = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CobDeptSearch = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.BtnQuery = New System.Windows.Forms.Button()
        Me.LabUserID_R = New System.Windows.Forms.Label()
        Me.UserinfDg = New System.Windows.Forms.DataGridView()
        Me.TxtDescript = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CboDept = New System.Windows.Forms.ComboBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TextBox_RoleName_S = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox_RoleId_S = New System.Windows.Forms.TextBox()
        Me.Button_Role_S = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TreeView_Role = New System.Windows.Forms.TreeView()
        Me.TextBox_RoleDesc = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CheckBox_Status = New System.Windows.Forms.CheckBox()
        Me.TextBox_RoleName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox_RoleId = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RoleBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewRole = New System.Windows.Forms.ToolStripButton()
        Me.EditRole = New System.Windows.Forms.ToolStripButton()
        Me.SaveRole = New System.Windows.Forms.ToolStripButton()
        Me.DeleteRole = New System.Windows.Forms.ToolStripButton()
        Me.StopRole = New System.Windows.Forms.ToolStripButton()
        Me.BackRole = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.SearchRole = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitRole = New System.Windows.Forms.ToolStripButton()
        Me.DataGridView_Role = New System.Windows.Forms.DataGridView()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TpRight = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GpUserRight = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSecarch = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboThird = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboSecond = New System.Windows.Forms.ComboBox()
        Me.UserTree = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TxtJob = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtRemark = New System.Windows.Forms.TextBox()
        Me.CobDeptShow = New System.Windows.Forms.ComboBox()
        Me.TxtNameShow = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CobUseShow = New System.Windows.Forms.ComboBox()
        Me.Btcontrast = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DGriduser = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImageTab = New System.Windows.Forms.ImageList(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolBt.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TpUser.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.UserinfDg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.RoleBt.SuspendLayout()
        CType(Me.DataGridView_Role, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpRight.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GpUserRight.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGriduser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabDescript
        '
        Me.LabDescript.AutoSize = True
        Me.LabDescript.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabDescript.Location = New System.Drawing.Point(410, 63)
        Me.LabDescript.Name = "LabDescript"
        Me.LabDescript.Size = New System.Drawing.Size(67, 15)
        Me.LabDescript.TabIndex = 16
        Me.LabDescript.Text = "自动编号："
        '
        'ChBusey
        '
        Me.ChBusey.AutoSize = True
        Me.ChBusey.Enabled = False
        Me.ChBusey.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ChBusey.Location = New System.Drawing.Point(605, 85)
        Me.ChBusey.Name = "ChBusey"
        Me.ChBusey.Size = New System.Drawing.Size(74, 19)
        Me.ChBusey.TabIndex = 8
        Me.ChBusey.Text = "是否有效"
        Me.ChBusey.UseVisualStyleBackColor = True
        '
        'CboFactoryID
        '
        Me.CboFactoryID.Enabled = False
        Me.CboFactoryID.FormattingEnabled = True
        Me.CboFactoryID.Items.AddRange(New Object() {"LX21"})
        Me.CboFactoryID.Location = New System.Drawing.Point(472, 35)
        Me.CboFactoryID.Name = "CboFactoryID"
        Me.CboFactoryID.Size = New System.Drawing.Size(120, 20)
        Me.CboFactoryID.TabIndex = 6
        '
        'LabUserid
        '
        Me.LabUserid.AutoSize = True
        Me.LabUserid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabUserid.Location = New System.Drawing.Point(10, 39)
        Me.LabUserid.Name = "LabUserid"
        Me.LabUserid.Size = New System.Drawing.Size(67, 15)
        Me.LabUserid.TabIndex = 4
        Me.LabUserid.Text = "用户工号："
        '
        'LabFactory
        '
        Me.LabFactory.AutoSize = True
        Me.LabFactory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabFactory.Location = New System.Drawing.Point(410, 39)
        Me.LabFactory.Name = "LabFactory"
        Me.LabFactory.Size = New System.Drawing.Size(67, 15)
        Me.LabFactory.TabIndex = 23
        Me.LabFactory.Text = "营运中心："
        '
        'TxtUserID
        '
        Me.TxtUserID.BackColor = System.Drawing.SystemColors.Window
        Me.TxtUserID.Enabled = False
        Me.TxtUserID.Location = New System.Drawing.Point(72, 34)
        Me.TxtUserID.Name = "TxtUserID"
        Me.TxtUserID.Size = New System.Drawing.Size(120, 21)
        Me.TxtUserID.TabIndex = 0
        '
        'TxtUserName
        '
        Me.TxtUserName.Enabled = False
        Me.TxtUserName.Location = New System.Drawing.Point(72, 58)
        Me.TxtUserName.Name = "TxtUserName"
        Me.TxtUserName.Size = New System.Drawing.Size(120, 21)
        Me.TxtUserName.TabIndex = 1
        '
        'CboGroupID
        '
        Me.CboGroupID.Enabled = False
        Me.CboGroupID.FormattingEnabled = True
        Me.CboGroupID.Location = New System.Drawing.Point(269, 83)
        Me.CboGroupID.Name = "CboGroupID"
        Me.CboGroupID.Size = New System.Drawing.Size(120, 20)
        Me.CboGroupID.TabIndex = 5
        '
        'LabDept
        '
        Me.LabDept.AutoSize = True
        Me.LabDept.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabDept.Location = New System.Drawing.Point(10, 87)
        Me.LabDept.Name = "LabDept"
        Me.LabDept.Size = New System.Drawing.Size(67, 15)
        Me.LabDept.TabIndex = 5
        Me.LabDept.Text = "用户部门："
        '
        'LabGroup
        '
        Me.LabGroup.AutoSize = True
        Me.LabGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabGroup.Location = New System.Drawing.Point(207, 87)
        Me.LabGroup.Name = "LabGroup"
        Me.LabGroup.Size = New System.Drawing.Size(67, 15)
        Me.LabGroup.TabIndex = 21
        Me.LabGroup.Text = "用户群组："
        '
        'LabUsername
        '
        Me.LabUsername.AutoSize = True
        Me.LabUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabUsername.Location = New System.Drawing.Point(10, 63)
        Me.LabUsername.Name = "LabUsername"
        Me.LabUsername.Size = New System.Drawing.Size(67, 15)
        Me.LabUsername.TabIndex = 3
        Me.LabUsername.Text = "用户姓名："
        '
        'LabJobs
        '
        Me.LabJobs.AutoSize = True
        Me.LabJobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabJobs.Location = New System.Drawing.Point(207, 39)
        Me.LabJobs.Name = "LabJobs"
        Me.LabJobs.Size = New System.Drawing.Size(67, 15)
        Me.LabJobs.TabIndex = 6
        Me.LabJobs.Text = "用户职称："
        '
        'CboJobs
        '
        Me.CboJobs.Enabled = False
        Me.CboJobs.FormattingEnabled = True
        Me.CboJobs.Location = New System.Drawing.Point(269, 35)
        Me.CboJobs.Name = "CboJobs"
        Me.CboJobs.Size = New System.Drawing.Size(120, 20)
        Me.CboJobs.TabIndex = 3
        '
        'CboTeam
        '
        Me.CboTeam.Enabled = False
        Me.CboTeam.FormattingEnabled = True
        Me.CboTeam.Location = New System.Drawing.Point(269, 59)
        Me.CboTeam.Name = "CboTeam"
        Me.CboTeam.Size = New System.Drawing.Size(120, 20)
        Me.CboTeam.TabIndex = 4
        '
        'LabTeam
        '
        Me.LabTeam.AutoSize = True
        Me.LabTeam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabTeam.Location = New System.Drawing.Point(207, 63)
        Me.LabTeam.Name = "LabTeam"
        Me.LabTeam.Size = New System.Drawing.Size(67, 15)
        Me.LabTeam.TabIndex = 18
        Me.LabTeam.Text = "部门组别："
        '
        'ToolBt
        '
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.NewFile, Me.EditFile, Me.Save, Me.Delete, Me.StopFile, Me.UnDo, Me.ToolStripSeparator2, Me.Search, Me.btnSetFinger, Me.ReSetPw, Me.ToolSuperPwd, Me.SetRole, Me.Export, Me.ToolStripSeparator3, Me.FileRefresh, Me.ExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(3, 3)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(997, 25)
        Me.ToolBt.TabIndex = 10
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
        'Delete
        '
        Me.Delete.Image = CType(resources.GetObject("Delete.Image"), System.Drawing.Image)
        Me.Delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(52, 22)
        Me.Delete.Text = "刪除"
        Me.Delete.ToolTipText = "刪除"
        '
        'StopFile
        '
        Me.StopFile.Image = CType(resources.GetObject("StopFile.Image"), System.Drawing.Image)
        Me.StopFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.StopFile.Name = "StopFile"
        Me.StopFile.Size = New System.Drawing.Size(52, 22)
        Me.StopFile.Text = "作废"
        Me.StopFile.ToolTipText = "作廢"
        '
        'UnDo
        '
        Me.UnDo.Enabled = False
        Me.UnDo.Image = CType(resources.GetObject("UnDo.Image"), System.Drawing.Image)
        Me.UnDo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UnDo.Name = "UnDo"
        Me.UnDo.Size = New System.Drawing.Size(52, 22)
        Me.UnDo.Text = "返回"
        Me.UnDo.ToolTipText = "返回"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Search
        '
        Me.Search.Image = CType(resources.GetObject("Search.Image"), System.Drawing.Image)
        Me.Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(52, 22)
        Me.Search.Text = "查找"
        Me.Search.ToolTipText = "查找"
        '
        'btnSetFinger
        '
        Me.btnSetFinger.Image = CType(resources.GetObject("btnSetFinger.Image"), System.Drawing.Image)
        Me.btnSetFinger.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSetFinger.Name = "btnSetFinger"
        Me.btnSetFinger.Size = New System.Drawing.Size(76, 22)
        Me.btnSetFinger.Text = "绑定指纹"
        '
        'ReSetPw
        '
        Me.ReSetPw.Image = CType(resources.GetObject("ReSetPw.Image"), System.Drawing.Image)
        Me.ReSetPw.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ReSetPw.Name = "ReSetPw"
        Me.ReSetPw.Size = New System.Drawing.Size(76, 22)
        Me.ReSetPw.Text = "设置密码"
        '
        'ToolSuperPwd
        '
        Me.ToolSuperPwd.Image = CType(resources.GetObject("ToolSuperPwd.Image"), System.Drawing.Image)
        Me.ToolSuperPwd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolSuperPwd.Name = "ToolSuperPwd"
        Me.ToolSuperPwd.Size = New System.Drawing.Size(100, 22)
        Me.ToolSuperPwd.Text = "超级密码管理"
        '
        'SetRole
        '
        Me.SetRole.Image = CType(resources.GetObject("SetRole.Image"), System.Drawing.Image)
        Me.SetRole.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SetRole.Name = "SetRole"
        Me.SetRole.Size = New System.Drawing.Size(76, 22)
        Me.SetRole.Text = "设置角色"
        '
        'Export
        '
        Me.Export.Image = CType(resources.GetObject("Export.Image"), System.Drawing.Image)
        Me.Export.ImageTransparentColor = System.Drawing.Color.White
        Me.Export.Name = "Export"
        Me.Export.Size = New System.Drawing.Size(52, 22)
        Me.Export.Text = "汇出"
        Me.Export.ToolTipText = "匯出"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'ExitFrom
        '
        Me.ExitFrom.Image = CType(resources.GetObject("ExitFrom.Image"), System.Drawing.Image)
        Me.ExitFrom.ImageTransparentColor = System.Drawing.Color.White
        Me.ExitFrom.Name = "ExitFrom"
        Me.ExitFrom.Size = New System.Drawing.Size(52, 22)
        Me.ExitFrom.Text = "退出"
        Me.ExitFrom.ToolTipText = "退出"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TpUser)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TpRight)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1011, 458)
        Me.TabControl1.TabIndex = 28
        '
        'TpUser
        '
        Me.TpUser.BackColor = System.Drawing.Color.Transparent
        Me.TpUser.Controls.Add(Me.cbousergrade)
        Me.TpUser.Controls.Add(Me.ChOutuser)
        Me.TpUser.Controls.Add(Me.Label15)
        Me.TpUser.Controls.Add(Me.Label9)
        Me.TpUser.Controls.Add(Me.cboverifytype)
        Me.TpUser.Controls.Add(Me.TxtAutoId)
        Me.TpUser.Controls.Add(Me.SplitContainer1)
        Me.TpUser.Controls.Add(Me.TxtDescript)
        Me.TpUser.Controls.Add(Me.ToolBt)
        Me.TpUser.Controls.Add(Me.CboFactoryID)
        Me.TpUser.Controls.Add(Me.Label1)
        Me.TpUser.Controls.Add(Me.CboTeam)
        Me.TpUser.Controls.Add(Me.CboGroupID)
        Me.TpUser.Controls.Add(Me.CboJobs)
        Me.TpUser.Controls.Add(Me.LabTeam)
        Me.TpUser.Controls.Add(Me.CboDept)
        Me.TpUser.Controls.Add(Me.TxtUserID)
        Me.TpUser.Controls.Add(Me.LabGroup)
        Me.TpUser.Controls.Add(Me.TxtUserName)
        Me.TpUser.Controls.Add(Me.LabJobs)
        Me.TpUser.Controls.Add(Me.ChBusey)
        Me.TpUser.Controls.Add(Me.LabUserid)
        Me.TpUser.Controls.Add(Me.LabUsername)
        Me.TpUser.Controls.Add(Me.LabDept)
        Me.TpUser.Controls.Add(Me.LabFactory)
        Me.TpUser.Controls.Add(Me.LabDescript)
        Me.TpUser.Location = New System.Drawing.Point(4, 22)
        Me.TpUser.Name = "TpUser"
        Me.TpUser.Padding = New System.Windows.Forms.Padding(3)
        Me.TpUser.Size = New System.Drawing.Size(1003, 432)
        Me.TpUser.TabIndex = 0
        Me.TpUser.Text = "用户基本信息"
        Me.TpUser.UseVisualStyleBackColor = True
        '
        'cbousergrade
        '
        Me.cbousergrade.Enabled = False
        Me.cbousergrade.FormattingEnabled = True
        Me.cbousergrade.Items.AddRange(New Object() {"1-普通用户", "2-管理人员", "3-IT系统管理员"})
        Me.cbousergrade.Location = New System.Drawing.Point(853, 34)
        Me.cbousergrade.Name = "cbousergrade"
        Me.cbousergrade.Size = New System.Drawing.Size(120, 20)
        Me.cbousergrade.TabIndex = 30
        '
        'ChOutuser
        '
        Me.ChOutuser.AutoSize = True
        Me.ChOutuser.Enabled = False
        Me.ChOutuser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ChOutuser.Location = New System.Drawing.Point(605, 64)
        Me.ChOutuser.Name = "ChOutuser"
        Me.ChOutuser.Size = New System.Drawing.Size(98, 19)
        Me.ChOutuser.TabIndex = 29
        Me.ChOutuser.Text = "是否外厂员工"
        Me.ChOutuser.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(790, 35)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 15)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "用户级别："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(598, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 15)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "验证方式："
        '
        'cboverifytype
        '
        Me.cboverifytype.Enabled = False
        Me.cboverifytype.FormattingEnabled = True
        Me.cboverifytype.Items.AddRange(New Object() {"0-密码验证", "1-指纹验证", "2-密码+指纹验证"})
        Me.cboverifytype.Location = New System.Drawing.Point(664, 34)
        Me.cboverifytype.Name = "cboverifytype"
        Me.cboverifytype.Size = New System.Drawing.Size(120, 20)
        Me.cboverifytype.TabIndex = 27
        '
        'TxtAutoId
        '
        Me.TxtAutoId.Enabled = False
        Me.TxtAutoId.Location = New System.Drawing.Point(472, 58)
        Me.TxtAutoId.Name = "TxtAutoId"
        Me.TxtAutoId.Size = New System.Drawing.Size(120, 21)
        Me.TxtAutoId.TabIndex = 26
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 107)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtUnSearch)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CobDeptSearch)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtSearch)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnQuery)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabUserID_R)
        Me.SplitContainer1.Panel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.UserinfDg)
        Me.SplitContainer1.Size = New System.Drawing.Size(1003, 355)
        Me.SplitContainer1.SplitterDistance = 32
        Me.SplitContainer1.TabIndex = 20
        '
        'TxtUnSearch
        '
        Me.TxtUnSearch.Location = New System.Drawing.Point(269, 4)
        Me.TxtUnSearch.Name = "TxtUnSearch"
        Me.TxtUnSearch.Size = New System.Drawing.Size(120, 21)
        Me.TxtUnSearch.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(207, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 15)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "用户姓名："
        '
        'CobDeptSearch
        '
        Me.CobDeptSearch.FormattingEnabled = True
        Me.CobDeptSearch.Location = New System.Drawing.Point(472, 5)
        Me.CobDeptSearch.Name = "CobDeptSearch"
        Me.CobDeptSearch.Size = New System.Drawing.Size(120, 20)
        Me.CobDeptSearch.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(410, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "用户部门"
        '
        'TxtSearch
        '
        Me.TxtSearch.Location = New System.Drawing.Point(72, 4)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(120, 21)
        Me.TxtSearch.TabIndex = 15
        '
        'BtnQuery
        '
        Me.BtnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnQuery.Image = CType(resources.GetObject("BtnQuery.Image"), System.Drawing.Image)
        Me.BtnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnQuery.Location = New System.Drawing.Point(607, 4)
        Me.BtnQuery.Name = "BtnQuery"
        Me.BtnQuery.Size = New System.Drawing.Size(66, 23)
        Me.BtnQuery.TabIndex = 19
        Me.BtnQuery.Text = "查 詢"
        Me.BtnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnQuery.UseVisualStyleBackColor = True
        '
        'LabUserID_R
        '
        Me.LabUserID_R.AutoSize = True
        Me.LabUserID_R.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabUserID_R.Location = New System.Drawing.Point(10, 9)
        Me.LabUserID_R.Name = "LabUserID_R"
        Me.LabUserID_R.Size = New System.Drawing.Size(67, 15)
        Me.LabUserID_R.TabIndex = 16
        Me.LabUserID_R.Text = "用户工号："
        '
        'UserinfDg
        '
        Me.UserinfDg.AllowUserToAddRows = False
        Me.UserinfDg.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.AliceBlue
        Me.UserinfDg.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.UserinfDg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UserinfDg.BackgroundColor = System.Drawing.Color.White
        Me.UserinfDg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.UserinfDg.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.UserinfDg.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.UserinfDg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UserinfDg.Location = New System.Drawing.Point(3, 3)
        Me.UserinfDg.Name = "UserinfDg"
        Me.UserinfDg.ReadOnly = True
        Me.UserinfDg.RowHeadersWidth = 4
        Me.UserinfDg.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.UserinfDg.RowTemplate.Height = 24
        Me.UserinfDg.ShowEditingIcon = False
        Me.UserinfDg.Size = New System.Drawing.Size(994, 281)
        Me.UserinfDg.StandardTab = True
        Me.UserinfDg.TabIndex = 1
        '
        'TxtDescript
        '
        Me.TxtDescript.Enabled = False
        Me.TxtDescript.Location = New System.Drawing.Point(472, 82)
        Me.TxtDescript.Multiline = True
        Me.TxtDescript.Name = "TxtDescript"
        Me.TxtDescript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtDescript.Size = New System.Drawing.Size(120, 22)
        Me.TxtDescript.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(410, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 15)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "备注："
        '
        'CboDept
        '
        Me.CboDept.Enabled = False
        Me.CboDept.FormattingEnabled = True
        Me.CboDept.Location = New System.Drawing.Point(72, 83)
        Me.CboDept.Name = "CboDept"
        Me.CboDept.Size = New System.Drawing.Size(120, 20)
        Me.CboDept.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1003, 432)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "角色管理"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.Panel3)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.DataGridView_Role)
        Me.SplitContainer3.Size = New System.Drawing.Size(997, 426)
        Me.SplitContainer3.SplitterDistance = 219
        Me.SplitContainer3.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TextBox_RoleName_S)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.TextBox_RoleId_S)
        Me.Panel3.Controls.Add(Me.Button_Role_S)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 184)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(997, 35)
        Me.Panel3.TabIndex = 2
        Me.Panel3.Visible = False
        '
        'TextBox_RoleName_S
        '
        Me.TextBox_RoleName_S.Location = New System.Drawing.Point(272, 6)
        Me.TextBox_RoleName_S.Name = "TextBox_RoleName_S"
        Me.TextBox_RoleName_S.Size = New System.Drawing.Size(120, 21)
        Me.TextBox_RoleName_S.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(210, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 15)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "角色名称："
        '
        'TextBox_RoleId_S
        '
        Me.TextBox_RoleId_S.Location = New System.Drawing.Point(75, 6)
        Me.TextBox_RoleId_S.Name = "TextBox_RoleId_S"
        Me.TextBox_RoleId_S.Size = New System.Drawing.Size(120, 21)
        Me.TextBox_RoleId_S.TabIndex = 24
        '
        'Button_Role_S
        '
        Me.Button_Role_S.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button_Role_S.Image = CType(resources.GetObject("Button_Role_S.Image"), System.Drawing.Image)
        Me.Button_Role_S.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button_Role_S.Location = New System.Drawing.Point(398, 6)
        Me.Button_Role_S.Name = "Button_Role_S"
        Me.Button_Role_S.Size = New System.Drawing.Size(66, 23)
        Me.Button_Role_S.TabIndex = 28
        Me.Button_Role_S.Text = "查 詢"
        Me.Button_Role_S.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button_Role_S.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(13, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 15)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "角色编号："
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TreeView_Role)
        Me.Panel2.Controls.Add(Me.TextBox_RoleDesc)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.CheckBox_Status)
        Me.Panel2.Controls.Add(Me.TextBox_RoleName)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.TextBox_RoleId)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 27)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(997, 192)
        Me.Panel2.TabIndex = 1
        '
        'TreeView_Role
        '
        Me.TreeView_Role.CheckBoxes = True
        Me.TreeView_Role.Location = New System.Drawing.Point(343, 6)
        Me.TreeView_Role.Name = "TreeView_Role"
        Me.TreeView_Role.Size = New System.Drawing.Size(406, 201)
        Me.TreeView_Role.TabIndex = 8
        '
        'TextBox_RoleDesc
        '
        Me.TextBox_RoleDesc.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox_RoleDesc.Enabled = False
        Me.TextBox_RoleDesc.Location = New System.Drawing.Point(72, 70)
        Me.TextBox_RoleDesc.Name = "TextBox_RoleDesc"
        Me.TextBox_RoleDesc.Size = New System.Drawing.Size(245, 21)
        Me.TextBox_RoleDesc.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(10, 77)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 15)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "角色说明："
        '
        'CheckBox_Status
        '
        Me.CheckBox_Status.AutoSize = True
        Me.CheckBox_Status.Enabled = False
        Me.CheckBox_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckBox_Status.Location = New System.Drawing.Point(72, 97)
        Me.CheckBox_Status.Name = "CheckBox_Status"
        Me.CheckBox_Status.Size = New System.Drawing.Size(74, 19)
        Me.CheckBox_Status.TabIndex = 9
        Me.CheckBox_Status.Text = "是否有效"
        Me.CheckBox_Status.UseVisualStyleBackColor = True
        '
        'TextBox_RoleName
        '
        Me.TextBox_RoleName.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox_RoleName.Enabled = False
        Me.TextBox_RoleName.Location = New System.Drawing.Point(72, 45)
        Me.TextBox_RoleName.Name = "TextBox_RoleName"
        Me.TextBox_RoleName.Size = New System.Drawing.Size(245, 21)
        Me.TextBox_RoleName.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 15)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "角色名称："
        '
        'TextBox_RoleId
        '
        Me.TextBox_RoleId.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox_RoleId.Enabled = False
        Me.TextBox_RoleId.Location = New System.Drawing.Point(72, 18)
        Me.TextBox_RoleId.Name = "TextBox_RoleId"
        Me.TextBox_RoleId.Size = New System.Drawing.Size(245, 21)
        Me.TextBox_RoleId.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 15)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "角色编号："
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RoleBt)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(997, 27)
        Me.Panel1.TabIndex = 0
        '
        'RoleBt
        '
        Me.RoleBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.RoleBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.RoleBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.NewRole, Me.EditRole, Me.SaveRole, Me.DeleteRole, Me.StopRole, Me.BackRole, Me.ToolStripSeparator5, Me.SearchRole, Me.ToolStripSeparator6, Me.ExitRole})
        Me.RoleBt.Location = New System.Drawing.Point(0, 0)
        Me.RoleBt.Name = "RoleBt"
        Me.RoleBt.Size = New System.Drawing.Size(997, 25)
        Me.RoleBt.TabIndex = 12
        Me.RoleBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'NewRole
        '
        Me.NewRole.Image = CType(resources.GetObject("NewRole.Image"), System.Drawing.Image)
        Me.NewRole.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewRole.Name = "NewRole"
        Me.NewRole.Size = New System.Drawing.Size(52, 22)
        Me.NewRole.Text = "新增"
        Me.NewRole.ToolTipText = "新增"
        '
        'EditRole
        '
        Me.EditRole.Image = CType(resources.GetObject("EditRole.Image"), System.Drawing.Image)
        Me.EditRole.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditRole.Name = "EditRole"
        Me.EditRole.Size = New System.Drawing.Size(52, 22)
        Me.EditRole.Text = "修改"
        Me.EditRole.ToolTipText = "修改"
        '
        'SaveRole
        '
        Me.SaveRole.Enabled = False
        Me.SaveRole.Image = CType(resources.GetObject("SaveRole.Image"), System.Drawing.Image)
        Me.SaveRole.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveRole.Name = "SaveRole"
        Me.SaveRole.Size = New System.Drawing.Size(52, 22)
        Me.SaveRole.Text = "保存"
        Me.SaveRole.ToolTipText = "保存"
        '
        'DeleteRole
        '
        Me.DeleteRole.Image = CType(resources.GetObject("DeleteRole.Image"), System.Drawing.Image)
        Me.DeleteRole.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteRole.Name = "DeleteRole"
        Me.DeleteRole.Size = New System.Drawing.Size(52, 22)
        Me.DeleteRole.Text = "刪除"
        Me.DeleteRole.ToolTipText = "刪除"
        '
        'StopRole
        '
        Me.StopRole.Image = CType(resources.GetObject("StopRole.Image"), System.Drawing.Image)
        Me.StopRole.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.StopRole.Name = "StopRole"
        Me.StopRole.Size = New System.Drawing.Size(52, 22)
        Me.StopRole.Text = "作废"
        Me.StopRole.ToolTipText = "作廢"
        '
        'BackRole
        '
        Me.BackRole.Enabled = False
        Me.BackRole.Image = CType(resources.GetObject("BackRole.Image"), System.Drawing.Image)
        Me.BackRole.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BackRole.Name = "BackRole"
        Me.BackRole.Size = New System.Drawing.Size(52, 22)
        Me.BackRole.Text = "返回"
        Me.BackRole.ToolTipText = "返回"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator5.Visible = False
        '
        'SearchRole
        '
        Me.SearchRole.Image = CType(resources.GetObject("SearchRole.Image"), System.Drawing.Image)
        Me.SearchRole.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SearchRole.Name = "SearchRole"
        Me.SearchRole.Size = New System.Drawing.Size(52, 22)
        Me.SearchRole.Text = "查找"
        Me.SearchRole.ToolTipText = "查找"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ExitRole
        '
        Me.ExitRole.Image = CType(resources.GetObject("ExitRole.Image"), System.Drawing.Image)
        Me.ExitRole.ImageTransparentColor = System.Drawing.Color.White
        Me.ExitRole.Name = "ExitRole"
        Me.ExitRole.Size = New System.Drawing.Size(52, 22)
        Me.ExitRole.Text = "退出"
        Me.ExitRole.ToolTipText = "退出"
        '
        'DataGridView_Role
        '
        Me.DataGridView_Role.AllowUserToAddRows = False
        Me.DataGridView_Role.AllowUserToDeleteRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.AliceBlue
        Me.DataGridView_Role.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridView_Role.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView_Role.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView_Role.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView_Role.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridView_Role.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Role.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column13, Me.Column14, Me.Column15, Me.Column16})
        Me.DataGridView_Role.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_Role.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_Role.Name = "DataGridView_Role"
        Me.DataGridView_Role.ReadOnly = True
        Me.DataGridView_Role.RowHeadersWidth = 4
        Me.DataGridView_Role.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView_Role.RowTemplate.Height = 24
        Me.DataGridView_Role.ShowEditingIcon = False
        Me.DataGridView_Role.Size = New System.Drawing.Size(997, 203)
        Me.DataGridView_Role.StandardTab = True
        Me.DataGridView_Role.TabIndex = 9
        '
        'Column13
        '
        Me.Column13.HeaderText = "角色编号"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Width = 150
        '
        'Column14
        '
        Me.Column14.HeaderText = "角色名称"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        Me.Column14.Width = 150
        '
        'Column15
        '
        Me.Column15.HeaderText = "角色说明"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        Me.Column15.Width = 300
        '
        'Column16
        '
        Me.Column16.HeaderText = "是否有效"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        '
        'TpRight
        '
        Me.TpRight.BackColor = System.Drawing.Color.Transparent
        Me.TpRight.Controls.Add(Me.SplitContainer2)
        Me.TpRight.Location = New System.Drawing.Point(4, 22)
        Me.TpRight.Name = "TpRight"
        Me.TpRight.Padding = New System.Windows.Forms.Padding(3)
        Me.TpRight.Size = New System.Drawing.Size(1003, 432)
        Me.TpRight.TabIndex = 1
        Me.TpRight.Text = "用户权限管理"
        Me.TpRight.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.AutoScroll = True
        Me.SplitContainer2.Panel1.Controls.Add(Me.GpUserRight)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TxtJob)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TxtRemark)
        Me.SplitContainer2.Panel1.Controls.Add(Me.CobDeptShow)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TxtNameShow)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Button2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.CobUseShow)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Btcontrast)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label8)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer2.Size = New System.Drawing.Size(997, 426)
        Me.SplitContainer2.SplitterDistance = 312
        Me.SplitContainer2.TabIndex = 36
        '
        'GpUserRight
        '
        Me.GpUserRight.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GpUserRight.BackColor = System.Drawing.SystemColors.Control
        Me.GpUserRight.Controls.Add(Me.GroupBox1)
        Me.GpUserRight.Controls.Add(Me.UserTree)
        Me.GpUserRight.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GpUserRight.Location = New System.Drawing.Point(3, 3)
        Me.GpUserRight.Name = "GpUserRight"
        Me.GpUserRight.Size = New System.Drawing.Size(530, 305)
        Me.GpUserRight.TabIndex = 17
        Me.GpUserRight.TabStop = False
        Me.GpUserRight.Text = "所有权限列表"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSecarch)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.cboThird)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cboSecond)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(3, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(524, 49)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'btnSecarch
        '
        Me.btnSecarch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSecarch.Image = CType(resources.GetObject("btnSecarch.Image"), System.Drawing.Image)
        Me.btnSecarch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSecarch.Location = New System.Drawing.Point(434, 16)
        Me.btnSecarch.Name = "btnSecarch"
        Me.btnSecarch.Size = New System.Drawing.Size(66, 23)
        Me.btnSecarch.TabIndex = 20
        Me.btnSecarch.Text = "查 詢"
        Me.btnSecarch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSecarch.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(214, 21)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 12)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "三级菜单："
        '
        'cboThird
        '
        Me.cboThird.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboThird.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboThird.FormattingEnabled = True
        Me.cboThird.Location = New System.Drawing.Point(280, 18)
        Me.cboThird.Name = "cboThird"
        Me.cboThird.Size = New System.Drawing.Size(121, 20)
        Me.cboThird.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 12)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "二级菜单："
        '
        'cboSecond
        '
        Me.cboSecond.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSecond.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSecond.FormattingEnabled = True
        Me.cboSecond.Location = New System.Drawing.Point(72, 18)
        Me.cboSecond.Name = "cboSecond"
        Me.cboSecond.Size = New System.Drawing.Size(121, 20)
        Me.cboSecond.TabIndex = 0
        '
        'UserTree
        '
        Me.UserTree.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UserTree.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.UserTree.CheckBoxes = True
        Me.UserTree.ContextMenuStrip = Me.ContextMenuStrip1
        Me.UserTree.Location = New System.Drawing.Point(2, 72)
        Me.UserTree.Name = "UserTree"
        Me.UserTree.Size = New System.Drawing.Size(524, 230)
        Me.UserTree.TabIndex = 1
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(137, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(136, 22)
        Me.ToolStripMenuItem1.Text = "更新主窗口"
        '
        'TxtJob
        '
        Me.TxtJob.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtJob.Enabled = False
        Me.TxtJob.Location = New System.Drawing.Point(639, 114)
        Me.TxtJob.Name = "TxtJob"
        Me.TxtJob.Size = New System.Drawing.Size(282, 21)
        Me.TxtJob.TabIndex = 35
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(568, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "用户职称："
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(568, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "用户部门：" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label4.Visible = False
        '
        'TxtRemark
        '
        Me.TxtRemark.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRemark.Enabled = False
        Me.TxtRemark.Location = New System.Drawing.Point(639, 149)
        Me.TxtRemark.Multiline = True
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(282, 44)
        Me.TxtRemark.TabIndex = 33
        '
        'CobDeptShow
        '
        Me.CobDeptShow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CobDeptShow.FormattingEnabled = True
        Me.CobDeptShow.Location = New System.Drawing.Point(639, 13)
        Me.CobDeptShow.Name = "CobDeptShow"
        Me.CobDeptShow.Size = New System.Drawing.Size(282, 20)
        Me.CobDeptShow.TabIndex = 22
        Me.CobDeptShow.Visible = False
        '
        'TxtNameShow
        '
        Me.TxtNameShow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNameShow.Enabled = False
        Me.TxtNameShow.Location = New System.Drawing.Point(639, 81)
        Me.TxtNameShow.Name = "TxtNameShow"
        Me.TxtNameShow.Size = New System.Drawing.Size(282, 21)
        Me.TxtNameShow.TabIndex = 32
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(568, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "用户工号："
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(858, 206)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(86, 33)
        Me.Button2.TabIndex = 31
        Me.Button2.Text = "退出"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CobUseShow
        '
        Me.CobUseShow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CobUseShow.FormattingEnabled = True
        Me.CobUseShow.Location = New System.Drawing.Point(639, 49)
        Me.CobUseShow.Name = "CobUseShow"
        Me.CobUseShow.Size = New System.Drawing.Size(282, 20)
        Me.CobUseShow.TabIndex = 25
        '
        'Btcontrast
        '
        Me.Btcontrast.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btcontrast.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btcontrast.Image = CType(resources.GetObject("Btcontrast.Image"), System.Drawing.Image)
        Me.Btcontrast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btcontrast.Location = New System.Drawing.Point(682, 206)
        Me.Btcontrast.Name = "Btcontrast"
        Me.Btcontrast.Size = New System.Drawing.Size(86, 33)
        Me.Btcontrast.TabIndex = 30
        Me.Btcontrast.Text = "权限对照"
        Me.Btcontrast.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btcontrast.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(568, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 15)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "用户姓名："
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(568, 149)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 15)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "权限描述："
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DGriduser)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(997, 110)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "权限拥有用户"
        '
        'DGriduser
        '
        Me.DGriduser.AllowUserToAddRows = False
        Me.DGriduser.AllowUserToDeleteRows = False
        Me.DGriduser.AllowUserToOrderColumns = True
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue
        Me.DGriduser.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DGriduser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGriduser.BackgroundColor = System.Drawing.Color.White
        Me.DGriduser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGriduser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGriduser.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DGriduser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGriduser.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12})
        Me.DGriduser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGriduser.Location = New System.Drawing.Point(3, 17)
        Me.DGriduser.Name = "DGriduser"
        Me.DGriduser.RowHeadersWidth = 4
        Me.DGriduser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGriduser.RowTemplate.Height = 24
        Me.DGriduser.ShowEditingIcon = False
        Me.DGriduser.Size = New System.Drawing.Size(991, 90)
        Me.DGriduser.StandardTab = True
        Me.DGriduser.TabIndex = 3
        '
        'Column1
        '
        Me.Column1.HeaderText = "选择"
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.Width = 37
        '
        'Column2
        '
        Me.Column2.HeaderText = "用户工号"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 80
        '
        'Column3
        '
        Me.Column3.HeaderText = "用户姓名"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 80
        '
        'Column4
        '
        Me.Column4.HeaderText = "部门编号"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 80
        '
        'Column5
        '
        Me.Column5.HeaderText = "部门名称"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 80
        '
        'Column6
        '
        Me.Column6.HeaderText = "职位"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 56
        '
        'Column7
        '
        Me.Column7.HeaderText = "部门组别"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 80
        '
        'Column8
        '
        Me.Column8.HeaderText = "群组"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 56
        '
        'Column9
        '
        Me.Column9.HeaderText = "营运中心"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 80
        '
        'Column10
        '
        Me.Column10.HeaderText = "自动编号"
        Me.Column10.Name = "Column10"
        Me.Column10.Width = 80
        '
        'Column11
        '
        Me.Column11.HeaderText = "备注"
        Me.Column11.Name = "Column11"
        Me.Column11.Width = 56
        '
        'Column12
        '
        Me.Column12.HeaderText = "有效否"
        Me.Column12.Name = "Column12"
        Me.Column12.Width = 68
        '
        'ImageTab
        '
        Me.ImageTab.ImageStream = CType(resources.GetObject("ImageTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageTab.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageTab.Images.SetKeyName(0, "单页.ico")
        Me.ImageTab.Images.SetKeyName(1, "设置.ico")
        Me.ImageTab.Images.SetKeyName(2, "Web页面.ico")
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "用户工号"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 78
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "用户姓名"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 78
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "部门编号"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 78
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "部门名称"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 78
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "职位"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 54
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "部门组别"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 78
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "群组"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 54
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "营运中心"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 78
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "自动编号"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 78
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "备注"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 54
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "有效否"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 66
        '
        'FrmUserManage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1011, 464)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmUserManage"
        Me.Text = "用戶信息管理"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TpUser.ResumeLayout(False)
        Me.TpUser.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.UserinfDg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.RoleBt.ResumeLayout(False)
        Me.RoleBt.PerformLayout()
        CType(Me.DataGridView_Role, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TpRight.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.GpUserRight.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DGriduser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtUserID As System.Windows.Forms.TextBox
    Friend WithEvents LabUsername As System.Windows.Forms.Label
    Friend WithEvents TxtUserName As System.Windows.Forms.TextBox
    Friend WithEvents LabUserid As System.Windows.Forms.Label
    Friend WithEvents LabJobs As System.Windows.Forms.Label
    Friend WithEvents LabDept As System.Windows.Forms.Label
    Friend WithEvents CboJobs As System.Windows.Forms.ComboBox
    Friend WithEvents ChBusey As System.Windows.Forms.CheckBox
    Friend WithEvents LabDescript As System.Windows.Forms.Label
    Friend WithEvents CboTeam As System.Windows.Forms.ComboBox
    Friend WithEvents LabTeam As System.Windows.Forms.Label
    Friend WithEvents CboGroupID As System.Windows.Forms.ComboBox
    Friend WithEvents LabGroup As System.Windows.Forms.Label
    Friend WithEvents CboFactoryID As System.Windows.Forms.ComboBox
    Friend WithEvents LabFactory As System.Windows.Forms.Label
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents EditFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents Delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents StopFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UnDo As System.Windows.Forms.ToolStripButton
    Friend WithEvents Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents ExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents Export As System.Windows.Forms.ToolStripButton
    Friend WithEvents Refurbish As System.Windows.Forms.ToolStripButton
    Friend WithEvents FileRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TpUser As System.Windows.Forms.TabPage
    Friend WithEvents TpRight As System.Windows.Forms.TabPage
    Friend WithEvents TxtDescript As System.Windows.Forms.TextBox
    Friend WithEvents TxtAutoId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboDept As System.Windows.Forms.ComboBox
    Friend WithEvents LabUserID_R As System.Windows.Forms.Label
    Friend WithEvents TxtSearch As System.Windows.Forms.TextBox
    Friend WithEvents GpUserRight As System.Windows.Forms.GroupBox
    Friend WithEvents UserTree As System.Windows.Forms.TreeView
    Friend WithEvents BtnQuery As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CobDeptSearch As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ReSetPw As System.Windows.Forms.ToolStripButton
    Friend WithEvents CobUseShow As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CobDeptShow As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Btcontrast As System.Windows.Forms.Button
    Friend WithEvents ImageTab As System.Windows.Forms.ImageList
    Friend WithEvents TxtNameShow As System.Windows.Forms.TextBox
    Friend WithEvents TxtRemark As System.Windows.Forms.TextBox
    Friend WithEvents TxtJob As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtUnSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DGriduser As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolSuperPwd As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSetFinger As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboverifytype As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChOutuser As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents UserinfDg As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridView_Role As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TextBox_RoleName_S As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox_RoleId_S As System.Windows.Forms.TextBox
    Friend WithEvents Button_Role_S As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RoleBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewRole As System.Windows.Forms.ToolStripButton
    Friend WithEvents EditRole As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveRole As System.Windows.Forms.ToolStripButton
    Friend WithEvents DeleteRole As System.Windows.Forms.ToolStripButton
    Friend WithEvents StopRole As System.Windows.Forms.ToolStripButton
    Friend WithEvents BackRole As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SearchRole As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitRole As System.Windows.Forms.ToolStripButton
    Friend WithEvents CheckBox_Status As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox_RoleName As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox_RoleId As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox_RoleDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TreeView_Role As System.Windows.Forms.TreeView
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SetRole As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbousergrade As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboSecond As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnSecarch As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboThird As System.Windows.Forms.ComboBox

End Class
