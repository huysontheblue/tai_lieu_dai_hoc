<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClientMaster
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
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.txtClientName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.TabControlClient = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cboReleasedVersion = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.cboProfitCenter = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cboFactory = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.txtAdministratorName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.txtRemark = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.txtCreateUserid = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.txtCreateTime = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.txtLineId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtDeptId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnReadLocal = New DevComponents.DotNetBar.ButtonX()
        Me.txtMarRemark = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.txtClientMacAddress = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.btnDeleteMac = New DevComponents.DotNetBar.ButtonX()
        Me.btnAddMac = New DevComponents.DotNetBar.ButtonX()
        Me.dgvClientMac = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ClientMacId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClientInfoId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClientMacAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControlClient.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvClientMac, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(510, 418)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(65, 25)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 214
        Me.btnCancel.Text = "取  消"
        '
        'btnSave
        '
        Me.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSave.Location = New System.Drawing.Point(369, 419)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(65, 25)
        Me.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSave.TabIndex = 213
        Me.btnSave.Text = "保  存"
        '
        'LabelX23
        '
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Location = New System.Drawing.Point(23, 17)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(532, 23)
        Me.LabelX23.TabIndex = 208
        Me.LabelX23.Text = "▼客户端程序版本对应该电脑系统更新使用功能版本类型"
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Location = New System.Drawing.Point(22, 420)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(371, 23)
        Me.lblMessage.TabIndex = 220
        '
        'txtClientName
        '
        '
        '
        '
        Me.txtClientName.Border.Class = "TextBoxBorder"
        Me.txtClientName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtClientName.Location = New System.Drawing.Point(92, 57)
        Me.txtClientName.Name = "txtClientName"
        Me.txtClientName.Size = New System.Drawing.Size(186, 21)
        Me.txtClientName.TabIndex = 227
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Location = New System.Drawing.Point(21, 57)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(75, 23)
        Me.LabelX11.TabIndex = 228
        Me.LabelX11.Text = "电脑名称"
        '
        'TabControlClient
        '
        Me.TabControlClient.Controls.Add(Me.TabPage1)
        Me.TabControlClient.Controls.Add(Me.TabPage2)
        Me.TabControlClient.Location = New System.Drawing.Point(2, 105)
        Me.TabControlClient.Name = "TabControlClient"
        Me.TabControlClient.SelectedIndex = 0
        Me.TabControlClient.Size = New System.Drawing.Size(607, 298)
        Me.TabControlClient.TabIndex = 229
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.cboReleasedVersion)
        Me.TabPage1.Controls.Add(Me.LabelX10)
        Me.TabPage1.Controls.Add(Me.cboProfitCenter)
        Me.TabPage1.Controls.Add(Me.cboFactory)
        Me.TabPage1.Controls.Add(Me.txtAdministratorName)
        Me.TabPage1.Controls.Add(Me.LabelX9)
        Me.TabPage1.Controls.Add(Me.txtRemark)
        Me.TabPage1.Controls.Add(Me.LabelX8)
        Me.TabPage1.Controls.Add(Me.txtCreateUserid)
        Me.TabPage1.Controls.Add(Me.LabelX6)
        Me.TabPage1.Controls.Add(Me.txtCreateTime)
        Me.TabPage1.Controls.Add(Me.LabelX7)
        Me.TabPage1.Controls.Add(Me.txtLineId)
        Me.TabPage1.Controls.Add(Me.LabelX5)
        Me.TabPage1.Controls.Add(Me.LabelX4)
        Me.TabPage1.Controls.Add(Me.txtDeptId)
        Me.TabPage1.Controls.Add(Me.LabelX3)
        Me.TabPage1.Controls.Add(Me.LabelX2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(599, 272)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "基本信息"
        '
        'cboReleasedVersion
        '
        Me.cboReleasedVersion.DisplayMember = "Text"
        Me.cboReleasedVersion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboReleasedVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReleasedVersion.FormattingEnabled = True
        Me.cboReleasedVersion.ItemHeight = 15
        Me.cboReleasedVersion.Location = New System.Drawing.Point(95, 130)
        Me.cboReleasedVersion.Name = "cboReleasedVersion"
        Me.cboReleasedVersion.Size = New System.Drawing.Size(170, 21)
        Me.cboReleasedVersion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboReleasedVersion.TabIndex = 262
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Location = New System.Drawing.Point(333, 28)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(75, 23)
        Me.LabelX10.TabIndex = 261
        Me.LabelX10.Text = "利润中心"
        '
        'cboProfitCenter
        '
        Me.cboProfitCenter.DisplayMember = "Text"
        Me.cboProfitCenter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboProfitCenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProfitCenter.FormattingEnabled = True
        Me.cboProfitCenter.ItemHeight = 15
        Me.cboProfitCenter.Location = New System.Drawing.Point(414, 28)
        Me.cboProfitCenter.Name = "cboProfitCenter"
        Me.cboProfitCenter.Size = New System.Drawing.Size(170, 21)
        Me.cboProfitCenter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboProfitCenter.TabIndex = 260
        '
        'cboFactory
        '
        Me.cboFactory.DisplayMember = "Text"
        Me.cboFactory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboFactory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFactory.FormattingEnabled = True
        Me.cboFactory.ItemHeight = 15
        Me.cboFactory.Location = New System.Drawing.Point(95, 28)
        Me.cboFactory.Name = "cboFactory"
        Me.cboFactory.Size = New System.Drawing.Size(170, 21)
        Me.cboFactory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboFactory.TabIndex = 259
        '
        'txtAdministratorName
        '
        '
        '
        '
        Me.txtAdministratorName.Border.Class = "TextBoxBorder"
        Me.txtAdministratorName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAdministratorName.Location = New System.Drawing.Point(414, 128)
        Me.txtAdministratorName.Name = "txtAdministratorName"
        Me.txtAdministratorName.Size = New System.Drawing.Size(170, 21)
        Me.txtAdministratorName.TabIndex = 257
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Location = New System.Drawing.Point(333, 128)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(75, 23)
        Me.LabelX9.TabIndex = 258
        Me.LabelX9.Text = "管理人"
        '
        'txtRemark
        '
        '
        '
        '
        Me.txtRemark.Border.Class = "TextBoxBorder"
        Me.txtRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRemark.Location = New System.Drawing.Point(95, 181)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(489, 21)
        Me.txtRemark.TabIndex = 255
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Location = New System.Drawing.Point(14, 181)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(75, 23)
        Me.LabelX8.TabIndex = 256
        Me.LabelX8.Text = "说明"
        '
        'txtCreateUserid
        '
        '
        '
        '
        Me.txtCreateUserid.Border.Class = "TextBoxBorder"
        Me.txtCreateUserid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCreateUserid.Location = New System.Drawing.Point(95, 232)
        Me.txtCreateUserid.Name = "txtCreateUserid"
        Me.txtCreateUserid.ReadOnly = True
        Me.txtCreateUserid.Size = New System.Drawing.Size(170, 21)
        Me.txtCreateUserid.TabIndex = 253
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(14, 232)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 23)
        Me.LabelX6.TabIndex = 254
        Me.LabelX6.Text = "编辑用户"
        '
        'txtCreateTime
        '
        '
        '
        '
        Me.txtCreateTime.Border.Class = "TextBoxBorder"
        Me.txtCreateTime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCreateTime.Location = New System.Drawing.Point(414, 232)
        Me.txtCreateTime.Name = "txtCreateTime"
        Me.txtCreateTime.ReadOnly = True
        Me.txtCreateTime.Size = New System.Drawing.Size(170, 21)
        Me.txtCreateTime.TabIndex = 251
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(333, 232)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(75, 23)
        Me.LabelX7.TabIndex = 252
        Me.LabelX7.Text = "编辑时间"
        '
        'txtLineId
        '
        '
        '
        '
        Me.txtLineId.Border.Class = "TextBoxBorder"
        Me.txtLineId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtLineId.Location = New System.Drawing.Point(414, 79)
        Me.txtLineId.Name = "txtLineId"
        Me.txtLineId.Size = New System.Drawing.Size(170, 21)
        Me.txtLineId.TabIndex = 249
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(333, 81)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 250
        Me.LabelX5.Text = "产线"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(14, 130)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 248
        Me.LabelX4.Text = "更新版本"
        '
        'txtDeptId
        '
        '
        '
        '
        Me.txtDeptId.Border.Class = "TextBoxBorder"
        Me.txtDeptId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDeptId.Location = New System.Drawing.Point(95, 79)
        Me.txtDeptId.Name = "txtDeptId"
        Me.txtDeptId.Size = New System.Drawing.Size(170, 21)
        Me.txtDeptId.TabIndex = 246
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(14, 79)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 247
        Me.LabelX3.Text = "部门"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(14, 28)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 245
        Me.LabelX2.Text = "工厂"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.btnReadLocal)
        Me.TabPage2.Controls.Add(Me.txtMarRemark)
        Me.TabPage2.Controls.Add(Me.LabelX13)
        Me.TabPage2.Controls.Add(Me.txtClientMacAddress)
        Me.TabPage2.Controls.Add(Me.LabelX12)
        Me.TabPage2.Controls.Add(Me.btnDeleteMac)
        Me.TabPage2.Controls.Add(Me.btnAddMac)
        Me.TabPage2.Controls.Add(Me.dgvClientMac)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(599, 272)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "客户端MAC"
        '
        'btnReadLocal
        '
        Me.btnReadLocal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReadLocal.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReadLocal.Location = New System.Drawing.Point(518, 15)
        Me.btnReadLocal.Name = "btnReadLocal"
        Me.btnReadLocal.Size = New System.Drawing.Size(65, 25)
        Me.btnReadLocal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReadLocal.TabIndex = 204
        Me.btnReadLocal.Text = "读取本机"
        '
        'txtMarRemark
        '
        '
        '
        '
        Me.txtMarRemark.Border.Class = "TextBoxBorder"
        Me.txtMarRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMarRemark.Location = New System.Drawing.Point(101, 51)
        Me.txtMarRemark.Name = "txtMarRemark"
        Me.txtMarRemark.Size = New System.Drawing.Size(180, 21)
        Me.txtMarRemark.TabIndex = 202
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Location = New System.Drawing.Point(12, 51)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(75, 23)
        Me.LabelX13.TabIndex = 203
        Me.LabelX13.Text = "地址说明"
        '
        'txtClientMacAddress
        '
        '
        '
        '
        Me.txtClientMacAddress.Border.Class = "TextBoxBorder"
        Me.txtClientMacAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtClientMacAddress.Location = New System.Drawing.Point(101, 17)
        Me.txtClientMacAddress.Name = "txtClientMacAddress"
        Me.txtClientMacAddress.Size = New System.Drawing.Size(180, 21)
        Me.txtClientMacAddress.TabIndex = 200
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Location = New System.Drawing.Point(12, 17)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(75, 23)
        Me.LabelX12.TabIndex = 201
        Me.LabelX12.Text = "电脑MAC地址"
        '
        'btnDeleteMac
        '
        Me.btnDeleteMac.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDeleteMac.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDeleteMac.Location = New System.Drawing.Point(414, 15)
        Me.btnDeleteMac.Name = "btnDeleteMac"
        Me.btnDeleteMac.Size = New System.Drawing.Size(65, 25)
        Me.btnDeleteMac.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDeleteMac.TabIndex = 90
        Me.btnDeleteMac.Text = "作 废"
        '
        'btnAddMac
        '
        Me.btnAddMac.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAddMac.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAddMac.Location = New System.Drawing.Point(310, 15)
        Me.btnAddMac.Name = "btnAddMac"
        Me.btnAddMac.Size = New System.Drawing.Size(65, 25)
        Me.btnAddMac.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAddMac.TabIndex = 89
        Me.btnAddMac.Text = "增 加"
        '
        'dgvClientMac
        '
        Me.dgvClientMac.AllowUserToAddRows = False
        Me.dgvClientMac.AllowUserToDeleteRows = False
        Me.dgvClientMac.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvClientMac.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvClientMac.ColumnHeadersHeight = 28
        Me.dgvClientMac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvClientMac.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ClientMacId, Me.ClientInfoId, Me.ClientMacAddress, Me.Remark, Me.StatusFlag, Me.CreateUserId, Me.CreateTime, Me.UpdateUserId, Me.UpdateTime})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvClientMac.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvClientMac.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvClientMac.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvClientMac.Location = New System.Drawing.Point(3, 85)
        Me.dgvClientMac.Name = "dgvClientMac"
        Me.dgvClientMac.RowHeadersWidth = 15
        Me.dgvClientMac.RowTemplate.Height = 25
        Me.dgvClientMac.Size = New System.Drawing.Size(593, 184)
        Me.dgvClientMac.TabIndex = 0
        '
        'ClientMacId
        '
        Me.ClientMacId.DataPropertyName = "ClientMacId"
        Me.ClientMacId.HeaderText = "ClientMacId"
        Me.ClientMacId.Name = "ClientMacId"
        Me.ClientMacId.ReadOnly = True
        Me.ClientMacId.Visible = False
        '
        'ClientInfoId
        '
        Me.ClientInfoId.DataPropertyName = "ClientInfoId"
        Me.ClientInfoId.HeaderText = "ClientInfoId"
        Me.ClientInfoId.Name = "ClientInfoId"
        Me.ClientInfoId.ReadOnly = True
        Me.ClientInfoId.Visible = False
        '
        'ClientMacAddress
        '
        Me.ClientMacAddress.DataPropertyName = "ClientMacAddress"
        Me.ClientMacAddress.HeaderText = "电脑MAC地址"
        Me.ClientMacAddress.Name = "ClientMacAddress"
        Me.ClientMacAddress.ReadOnly = True
        Me.ClientMacAddress.Width = 200
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "说明"
        Me.Remark.Name = "Remark"
        Me.Remark.Width = 120
        '
        'StatusFlag
        '
        Me.StatusFlag.DataPropertyName = "StatusFlag"
        Me.StatusFlag.HeaderText = "状态"
        Me.StatusFlag.Name = "StatusFlag"
        Me.StatusFlag.ReadOnly = True
        Me.StatusFlag.Width = 60
        '
        'CreateUserId
        '
        Me.CreateUserId.DataPropertyName = "CreateUserId"
        Me.CreateUserId.HeaderText = "创建人"
        Me.CreateUserId.Name = "CreateUserId"
        Me.CreateUserId.ReadOnly = True
        '
        'CreateTime
        '
        Me.CreateTime.DataPropertyName = "CreateTime"
        Me.CreateTime.HeaderText = "创建时间"
        Me.CreateTime.Name = "CreateTime"
        Me.CreateTime.ReadOnly = True
        '
        'UpdateUserId
        '
        Me.UpdateUserId.DataPropertyName = "UpdateUserId"
        Me.UpdateUserId.HeaderText = "更新用户"
        Me.UpdateUserId.Name = "UpdateUserId"
        Me.UpdateUserId.ReadOnly = True
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        Me.UpdateTime.HeaderText = "更新时间"
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.ReadOnly = True
        '
        'FrmClientMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 463)
        Me.Controls.Add(Me.TabControlClient)
        Me.Controls.Add(Me.txtClientName)
        Me.Controls.Add(Me.LabelX11)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.LabelX23)
        Me.Controls.Add(Me.lblMessage)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmClientMaster"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "客户端维护"
        Me.TabControlClient.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvClientMac, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtClientName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabControlClient As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents cboReleasedVersion As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboProfitCenter As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cboFactory As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents txtAdministratorName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtRemark As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCreateUserid As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCreateTime As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtLineId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtDeptId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvClientMac As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnDeleteMac As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAddMac As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtMarRemark As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtClientMacAddress As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnReadLocal As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ClientMacId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClientInfoId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClientMacAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusFlag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
