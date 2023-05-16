<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDataHistoryMaster
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.chkStatusFlag = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.mtxtMigrateTable = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.mtxtLinkServer = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.mtxtTargetDataBase = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.itxtProcessingNumber = New DevComponents.Editors.IntegerInput()
        Me.cboTreatment = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.mtxtSequenceColumn = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.cboSequenceType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dtpExecEndTime = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX40 = New DevComponents.DotNetBar.LabelX()
        Me.cboIncrementalType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX39 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX31 = New DevComponents.DotNetBar.LabelX()
        Me.itxtRetentionDays = New DevComponents.Editors.IntegerInput()
        Me.itxtExecIncrementalTime = New DevComponents.Editors.IntegerInput()
        Me.LabelX35 = New DevComponents.DotNetBar.LabelX()
        Me.txtSummary = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX34 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.dtEndTime = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rBtnNoEndDate = New System.Windows.Forms.RadioButton()
        Me.rBtnEndDate = New System.Windows.Forms.RadioButton()
        Me.LabelX33 = New DevComponents.DotNetBar.LabelX()
        Me.dtStartTime = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.cboIntervalType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.itxtIntervalFrequency = New DevComponents.Editors.IntegerInput()
        Me.LabelX32 = New DevComponents.DotNetBar.LabelX()
        Me.rBtnIntervalFrequency = New System.Windows.Forms.RadioButton()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.itxtExecutionInterval = New DevComponents.Editors.IntegerInput()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.txtCreateTime = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.txtCreateUserId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.txtRewark = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.chkDateColumnFlag = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.mtxtTargetColumn = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.btnDeleteColumn = New DevComponents.DotNetBar.ButtonX()
        Me.btnAddColumn = New DevComponents.DotNetBar.ButtonX()
        Me.dgvColumn = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataHistoryColumnId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataHistoryId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SourceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TargetColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateColumnFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mtxtSourceColumn = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cboOperatorsType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cboWhereType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.btnDeleteWhere = New DevComponents.DotNetBar.ButtonX()
        Me.btnAddWhere = New DevComponents.DotNetBar.ButtonX()
        Me.dgvWhere = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataHistoryWhereId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WhereType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WhereColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperatorsType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SQLWhere = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WCreateUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WCreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtWhereSQL = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.mtxtWhereColumn = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.mtxtChildColumnName = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX28 = New DevComponents.DotNetBar.LabelX()
        Me.dgvChild = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataHistoryChildId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChildDataHistoryId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChildTableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParentColumnName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChildColumnName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WhereSQL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtChildRemark = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX27 = New DevComponents.DotNetBar.LabelX()
        Me.btnChildDelete = New DevComponents.DotNetBar.ButtonX()
        Me.btnChildAdd = New DevComponents.DotNetBar.ButtonX()
        Me.txtChildWhereSQL = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX26 = New DevComponents.DotNetBar.LabelX()
        Me.mtxtParentColumnName = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX()
        Me.mtxtChildTableName = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.dgvPrimaryKey = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataHistoryPrimaryKeyId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PDataHistroyId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PKItemNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SourcePrimaryKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TargetPrimaryKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PKCreateUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PKCreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mtxtTargetPrimaryKeyColumn = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX36 = New DevComponents.DotNetBar.LabelX()
        Me.btnPrimaryKeyDelete = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrimaryKeyAdd = New DevComponents.DotNetBar.ButtonX()
        Me.mtxtSourcePrimaryKeyColumn = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX30 = New DevComponents.DotNetBar.LabelX()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.cboServerConfigName = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.cboMigrateDataDelete = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX37 = New DevComponents.DotNetBar.LabelX()
        Me.mtxtTargetTableName = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.chkColumnType = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.mtxtMigrateServer = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX29 = New DevComponents.DotNetBar.LabelX()
        Me.cboDataHistoryType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.mtxtMigrateDataBase = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX38 = New DevComponents.DotNetBar.LabelX()
        Me.cboExecuteType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cboTargetServerConfigName = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX41 = New DevComponents.DotNetBar.LabelX()
        CType(Me.itxtProcessingNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dtpExecEndTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.itxtRetentionDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.itxtExecIncrementalTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEndTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dtStartTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.itxtIntervalFrequency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.itxtExecutionInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvWhere, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvChild, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgvPrimaryKey, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(556, 661)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(65, 25)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.btnCancel.TabIndex = 45
        Me.btnCancel.Text = "取  消"
        '
        'btnSave
        '
        Me.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSave.Location = New System.Drawing.Point(409, 661)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(65, 25)
        Me.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.btnSave.TabIndex = 44
        Me.btnSave.Text = "保  存"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(15, 138)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(82, 23)
        Me.LabelX4.TabIndex = 43
        Me.LabelX4.Text = "处理笔数"
        '
        'chkStatusFlag
        '
        '
        '
        '
        Me.chkStatusFlag.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkStatusFlag.Location = New System.Drawing.Point(271, 9)
        Me.chkStatusFlag.Name = "chkStatusFlag"
        Me.chkStatusFlag.Size = New System.Drawing.Size(62, 23)
        Me.chkStatusFlag.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkStatusFlag.TabIndex = 55
        Me.chkStatusFlag.Text = "有效"
        Me.chkStatusFlag.Visible = False
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(15, 83)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(82, 23)
        Me.LabelX1.TabIndex = 54
        Me.LabelX1.Text = "源数据表"
        '
        'mtxtMigrateTable
        '
        '
        '
        '
        Me.mtxtMigrateTable.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtMigrateTable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtMigrateTable.ButtonCustom.Image = Global.DataHistoryManagement.My.Resources.Resources.query
        Me.mtxtMigrateTable.ButtonCustom.Visible = True
        Me.mtxtMigrateTable.Location = New System.Drawing.Point(88, 83)
        Me.mtxtMigrateTable.Name = "mtxtMigrateTable"
        Me.mtxtMigrateTable.ReadOnly = True
        Me.mtxtMigrateTable.Size = New System.Drawing.Size(210, 21)
        Me.mtxtMigrateTable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtMigrateTable.TabIndex = 53
        Me.mtxtMigrateTable.Text = ""
        '
        'mtxtLinkServer
        '
        '
        '
        '
        Me.mtxtLinkServer.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtLinkServer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtLinkServer.ButtonCustom.Image = Global.DataHistoryManagement.My.Resources.Resources.query
        Me.mtxtLinkServer.ButtonCustom.Visible = True
        Me.mtxtLinkServer.Location = New System.Drawing.Point(91, 22)
        Me.mtxtLinkServer.Name = "mtxtLinkServer"
        Me.mtxtLinkServer.ReadOnly = True
        Me.mtxtLinkServer.Size = New System.Drawing.Size(210, 21)
        Me.mtxtLinkServer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtLinkServer.TabIndex = 56
        Me.mtxtLinkServer.Text = ""
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(15, 22)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(82, 23)
        Me.LabelX2.TabIndex = 57
        Me.LabelX2.Text = "链接服务器"
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(10, 61)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(82, 23)
        Me.LabelX7.TabIndex = 58
        Me.LabelX7.Text = "处理方式"
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Location = New System.Drawing.Point(15, 61)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(96, 23)
        Me.LabelX8.TabIndex = 61
        Me.LabelX8.Text = "目标数据库"
        '
        'mtxtTargetDataBase
        '
        '
        '
        '
        Me.mtxtTargetDataBase.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtTargetDataBase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtTargetDataBase.ButtonCustom.Image = Global.DataHistoryManagement.My.Resources.Resources.query
        Me.mtxtTargetDataBase.ButtonCustom.Visible = True
        Me.mtxtTargetDataBase.Location = New System.Drawing.Point(91, 61)
        Me.mtxtTargetDataBase.Name = "mtxtTargetDataBase"
        Me.mtxtTargetDataBase.ReadOnly = True
        Me.mtxtTargetDataBase.Size = New System.Drawing.Size(210, 21)
        Me.mtxtTargetDataBase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtTargetDataBase.TabIndex = 60
        Me.mtxtTargetDataBase.Text = ""
        '
        'itxtProcessingNumber
        '
        '
        '
        '
        Me.itxtProcessingNumber.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.itxtProcessingNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.itxtProcessingNumber.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.itxtProcessingNumber.Location = New System.Drawing.Point(91, 139)
        Me.itxtProcessingNumber.MaxValue = 10000
        Me.itxtProcessingNumber.MinValue = 1
        Me.itxtProcessingNumber.Name = "itxtProcessingNumber"
        Me.itxtProcessingNumber.ShowUpDown = True
        Me.itxtProcessingNumber.Size = New System.Drawing.Size(210, 21)
        Me.itxtProcessingNumber.TabIndex = 74
        Me.itxtProcessingNumber.Value = 1
        '
        'cboTreatment
        '
        Me.cboTreatment.DisplayMember = "Text"
        Me.cboTreatment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboTreatment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTreatment.FormattingEnabled = True
        Me.cboTreatment.ItemHeight = 15
        Me.cboTreatment.Location = New System.Drawing.Point(83, 61)
        Me.cboTreatment.Name = "cboTreatment"
        Me.cboTreatment.Size = New System.Drawing.Size(210, 21)
        Me.cboTreatment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboTreatment.TabIndex = 75
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Location = New System.Drawing.Point(16, 661)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(371, 23)
        Me.lblMessage.TabIndex = 76
        '
        'mtxtSequenceColumn
        '
        '
        '
        '
        Me.mtxtSequenceColumn.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtSequenceColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtSequenceColumn.ButtonCustom.Image = Global.DataHistoryManagement.My.Resources.Resources.query
        Me.mtxtSequenceColumn.ButtonCustom.Visible = True
        Me.mtxtSequenceColumn.Location = New System.Drawing.Point(83, 100)
        Me.mtxtSequenceColumn.Name = "mtxtSequenceColumn"
        Me.mtxtSequenceColumn.ReadOnly = True
        Me.mtxtSequenceColumn.Size = New System.Drawing.Size(210, 21)
        Me.mtxtSequenceColumn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtSequenceColumn.TabIndex = 80
        Me.mtxtSequenceColumn.Text = ""
        '
        'LabelX15
        '
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Location = New System.Drawing.Point(10, 100)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(96, 23)
        Me.LabelX15.TabIndex = 81
        Me.LabelX15.Text = "排序栏位"
        '
        'cboSequenceType
        '
        Me.cboSequenceType.DisplayMember = "Text"
        Me.cboSequenceType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSequenceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSequenceType.Enabled = False
        Me.cboSequenceType.FormattingEnabled = True
        Me.cboSequenceType.ItemHeight = 15
        Me.cboSequenceType.Location = New System.Drawing.Point(83, 138)
        Me.cboSequenceType.Name = "cboSequenceType"
        Me.cboSequenceType.Size = New System.Drawing.Size(210, 21)
        Me.cboSequenceType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboSequenceType.TabIndex = 83
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Location = New System.Drawing.Point(10, 139)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(82, 23)
        Me.LabelX16.TabIndex = 82
        Me.LabelX16.Text = "排序方式"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Location = New System.Drawing.Point(5, 305)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(657, 343)
        Me.TabControl1.TabIndex = 84
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.dtpExecEndTime)
        Me.TabPage1.Controls.Add(Me.LabelX40)
        Me.TabPage1.Controls.Add(Me.cboIncrementalType)
        Me.TabPage1.Controls.Add(Me.LabelX39)
        Me.TabPage1.Controls.Add(Me.LabelX31)
        Me.TabPage1.Controls.Add(Me.itxtRetentionDays)
        Me.TabPage1.Controls.Add(Me.itxtExecIncrementalTime)
        Me.TabPage1.Controls.Add(Me.LabelX35)
        Me.TabPage1.Controls.Add(Me.txtSummary)
        Me.TabPage1.Controls.Add(Me.LabelX34)
        Me.TabPage1.Controls.Add(Me.LabelX12)
        Me.TabPage1.Controls.Add(Me.dtEndTime)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.LabelX33)
        Me.TabPage1.Controls.Add(Me.dtStartTime)
        Me.TabPage1.Controls.Add(Me.cboIntervalType)
        Me.TabPage1.Controls.Add(Me.itxtIntervalFrequency)
        Me.TabPage1.Controls.Add(Me.LabelX32)
        Me.TabPage1.Controls.Add(Me.rBtnIntervalFrequency)
        Me.TabPage1.Controls.Add(Me.LabelX11)
        Me.TabPage1.Controls.Add(Me.LabelX10)
        Me.TabPage1.Controls.Add(Me.itxtExecutionInterval)
        Me.TabPage1.Controls.Add(Me.LabelX9)
        Me.TabPage1.Controls.Add(Me.txtCreateTime)
        Me.TabPage1.Controls.Add(Me.LabelX6)
        Me.TabPage1.Controls.Add(Me.txtCreateUserId)
        Me.TabPage1.Controls.Add(Me.LabelX5)
        Me.TabPage1.Controls.Add(Me.txtRewark)
        Me.TabPage1.Controls.Add(Me.LabelX3)
        Me.TabPage1.Controls.Add(Me.LabelX13)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(649, 317)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "执行计划"
        '
        'dtpExecEndTime
        '
        '
        '
        '
        Me.dtpExecEndTime.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpExecEndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpExecEndTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpExecEndTime.ButtonDropDown.Visible = True
        Me.dtpExecEndTime.IsPopupCalendarOpen = False
        Me.dtpExecEndTime.Location = New System.Drawing.Point(82, 157)
        '
        '
        '
        Me.dtpExecEndTime.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpExecEndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpExecEndTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpExecEndTime.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpExecEndTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpExecEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpExecEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpExecEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpExecEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpExecEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpExecEndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpExecEndTime.MonthCalendar.DisplayMonth = New Date(2015, 9, 1, 0, 0, 0, 0)
        Me.dtpExecEndTime.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpExecEndTime.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpExecEndTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpExecEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpExecEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpExecEndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpExecEndTime.MonthCalendar.TodayButtonVisible = True
        Me.dtpExecEndTime.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpExecEndTime.Name = "dtpExecEndTime"
        Me.dtpExecEndTime.Size = New System.Drawing.Size(210, 21)
        Me.dtpExecEndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpExecEndTime.TabIndex = 196
        '
        'LabelX40
        '
        '
        '
        '
        Me.LabelX40.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX40.Location = New System.Drawing.Point(9, 156)
        Me.LabelX40.Name = "LabelX40"
        Me.LabelX40.Size = New System.Drawing.Size(82, 23)
        Me.LabelX40.TabIndex = 197
        Me.LabelX40.Text = "开始日期"
        '
        'cboIncrementalType
        '
        Me.cboIncrementalType.DisplayMember = "Text"
        Me.cboIncrementalType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboIncrementalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIncrementalType.FormattingEnabled = True
        Me.cboIncrementalType.ItemHeight = 15
        Me.cboIncrementalType.Location = New System.Drawing.Point(426, 125)
        Me.cboIncrementalType.Name = "cboIncrementalType"
        Me.cboIncrementalType.Size = New System.Drawing.Size(210, 21)
        Me.cboIncrementalType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboIncrementalType.TabIndex = 194
        '
        'LabelX39
        '
        '
        '
        '
        Me.LabelX39.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX39.Location = New System.Drawing.Point(350, 126)
        Me.LabelX39.Name = "LabelX39"
        Me.LabelX39.Size = New System.Drawing.Size(82, 23)
        Me.LabelX39.TabIndex = 195
        Me.LabelX39.Text = "日期类型"
        '
        'LabelX31
        '
        '
        '
        '
        Me.LabelX31.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX31.Location = New System.Drawing.Point(299, 125)
        Me.LabelX31.Name = "LabelX31"
        Me.LabelX31.Size = New System.Drawing.Size(25, 23)
        Me.LabelX31.TabIndex = 103
        Me.LabelX31.Text = "分"
        '
        'itxtRetentionDays
        '
        '
        '
        '
        Me.itxtRetentionDays.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.itxtRetentionDays.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.itxtRetentionDays.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.itxtRetentionDays.Location = New System.Drawing.Point(82, 88)
        Me.itxtRetentionDays.MaxValue = 100
        Me.itxtRetentionDays.MinValue = 1
        Me.itxtRetentionDays.Name = "itxtRetentionDays"
        Me.itxtRetentionDays.ShowUpDown = True
        Me.itxtRetentionDays.Size = New System.Drawing.Size(210, 21)
        Me.itxtRetentionDays.TabIndex = 99
        Me.itxtRetentionDays.Value = 1
        '
        'itxtExecIncrementalTime
        '
        '
        '
        '
        Me.itxtExecIncrementalTime.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.itxtExecIncrementalTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.itxtExecIncrementalTime.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.itxtExecIncrementalTime.Location = New System.Drawing.Point(82, 125)
        Me.itxtExecIncrementalTime.MaxValue = 100000
        Me.itxtExecIncrementalTime.MinValue = 1
        Me.itxtExecIncrementalTime.Name = "itxtExecIncrementalTime"
        Me.itxtExecIncrementalTime.ShowUpDown = True
        Me.itxtExecIncrementalTime.Size = New System.Drawing.Size(210, 21)
        Me.itxtExecIncrementalTime.TabIndex = 101
        Me.itxtExecIncrementalTime.Value = 1
        '
        'LabelX35
        '
        '
        '
        '
        Me.LabelX35.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX35.Location = New System.Drawing.Point(9, 88)
        Me.LabelX35.Name = "LabelX35"
        Me.LabelX35.Size = New System.Drawing.Size(82, 23)
        Me.LabelX35.TabIndex = 98
        Me.LabelX35.Text = "保留天数"
        '
        'txtSummary
        '
        '
        '
        '
        Me.txtSummary.Border.Class = "TextBoxBorder"
        Me.txtSummary.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSummary.Enabled = False
        Me.txtSummary.Location = New System.Drawing.Point(82, 193)
        Me.txtSummary.Multiline = True
        Me.txtSummary.Name = "txtSummary"
        Me.txtSummary.ReadOnly = True
        Me.txtSummary.Size = New System.Drawing.Size(554, 40)
        Me.txtSummary.TabIndex = 97
        '
        'LabelX34
        '
        '
        '
        '
        Me.LabelX34.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX34.Location = New System.Drawing.Point(9, 193)
        Me.LabelX34.Name = "LabelX34"
        Me.LabelX34.Size = New System.Drawing.Size(82, 23)
        Me.LabelX34.TabIndex = 96
        Me.LabelX34.Text = "摘要"
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Location = New System.Drawing.Point(9, 197)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(82, 23)
        Me.LabelX12.TabIndex = 96
        Me.LabelX12.Text = "摘要"
        '
        'dtEndTime
        '
        '
        '
        '
        Me.dtEndTime.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtEndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtEndTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtEndTime.ButtonDropDown.Visible = True
        Me.dtEndTime.Enabled = False
        Me.dtEndTime.IsPopupCalendarOpen = False
        Me.dtEndTime.Location = New System.Drawing.Point(516, 50)
        '
        '
        '
        Me.dtEndTime.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtEndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtEndTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtEndTime.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtEndTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtEndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtEndTime.MonthCalendar.DisplayMonth = New Date(2015, 9, 1, 0, 0, 0, 0)
        Me.dtEndTime.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtEndTime.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtEndTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtEndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtEndTime.MonthCalendar.TodayButtonVisible = True
        Me.dtEndTime.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtEndTime.Name = "dtEndTime"
        Me.dtEndTime.Size = New System.Drawing.Size(120, 21)
        Me.dtEndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtEndTime.TabIndex = 95
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rBtnNoEndDate)
        Me.Panel1.Controls.Add(Me.rBtnEndDate)
        Me.Panel1.Location = New System.Drawing.Point(351, 51)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(121, 58)
        Me.Panel1.TabIndex = 94
        '
        'rBtnNoEndDate
        '
        Me.rBtnNoEndDate.AutoSize = True
        Me.rBtnNoEndDate.Checked = True
        Me.rBtnNoEndDate.Location = New System.Drawing.Point(3, 37)
        Me.rBtnNoEndDate.Name = "rBtnNoEndDate"
        Me.rBtnNoEndDate.Size = New System.Drawing.Size(101, 16)
        Me.rBtnNoEndDate.TabIndex = 76
        Me.rBtnNoEndDate.TabStop = True
        Me.rBtnNoEndDate.Text = "无结束日期(O)"
        Me.rBtnNoEndDate.UseVisualStyleBackColor = True
        '
        'rBtnEndDate
        '
        Me.rBtnEndDate.AutoSize = True
        Me.rBtnEndDate.Location = New System.Drawing.Point(3, 4)
        Me.rBtnEndDate.Name = "rBtnEndDate"
        Me.rBtnEndDate.Size = New System.Drawing.Size(89, 16)
        Me.rBtnEndDate.TabIndex = 75
        Me.rBtnEndDate.Text = "结束日期(E)"
        Me.rBtnEndDate.UseVisualStyleBackColor = True
        '
        'LabelX33
        '
        '
        '
        '
        Me.LabelX33.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX33.Location = New System.Drawing.Point(9, 124)
        Me.LabelX33.Name = "LabelX33"
        Me.LabelX33.Size = New System.Drawing.Size(96, 23)
        Me.LabelX33.TabIndex = 102
        Me.LabelX33.Text = "日期增量"
        '
        'dtStartTime
        '
        '
        '
        '
        Me.dtStartTime.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtStartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtStartTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtStartTime.ButtonDropDown.Visible = True
        Me.dtStartTime.CustomFormat = "yyyy/MM/dd"
        Me.dtStartTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtStartTime.IsPopupCalendarOpen = False
        Me.dtStartTime.Location = New System.Drawing.Point(82, 52)
        '
        '
        '
        Me.dtStartTime.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtStartTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtStartTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtStartTime.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtStartTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtStartTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtStartTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtStartTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtStartTime.MonthCalendar.DisplayMonth = New Date(2015, 9, 1, 0, 0, 0, 0)
        Me.dtStartTime.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtStartTime.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtStartTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtStartTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtStartTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtStartTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtStartTime.MonthCalendar.TodayButtonVisible = True
        Me.dtStartTime.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtStartTime.Name = "dtStartTime"
        Me.dtStartTime.Size = New System.Drawing.Size(210, 21)
        Me.dtStartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtStartTime.TabIndex = 93
        '
        'cboIntervalType
        '
        Me.cboIntervalType.DisplayMember = "Text"
        Me.cboIntervalType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboIntervalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIntervalType.FormattingEnabled = True
        Me.cboIntervalType.ItemHeight = 15
        Me.cboIntervalType.Location = New System.Drawing.Point(516, 16)
        Me.cboIntervalType.Name = "cboIntervalType"
        Me.cboIntervalType.Size = New System.Drawing.Size(120, 21)
        Me.cboIntervalType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboIntervalType.TabIndex = 92
        '
        'itxtIntervalFrequency
        '
        '
        '
        '
        Me.itxtIntervalFrequency.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.itxtIntervalFrequency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.itxtIntervalFrequency.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.itxtIntervalFrequency.Location = New System.Drawing.Point(426, 16)
        Me.itxtIntervalFrequency.MaxValue = 100
        Me.itxtIntervalFrequency.MinValue = 1
        Me.itxtIntervalFrequency.Name = "itxtIntervalFrequency"
        Me.itxtIntervalFrequency.ShowUpDown = True
        Me.itxtIntervalFrequency.Size = New System.Drawing.Size(79, 21)
        Me.itxtIntervalFrequency.TabIndex = 91
        Me.itxtIntervalFrequency.Value = 1
        '
        'LabelX32
        '
        '
        '
        '
        Me.LabelX32.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX32.Location = New System.Drawing.Point(9, 52)
        Me.LabelX32.Name = "LabelX32"
        Me.LabelX32.Size = New System.Drawing.Size(82, 23)
        Me.LabelX32.TabIndex = 89
        Me.LabelX32.Text = "开始时间(D)"
        '
        'rBtnIntervalFrequency
        '
        Me.rBtnIntervalFrequency.AutoSize = True
        Me.rBtnIntervalFrequency.Checked = True
        Me.rBtnIntervalFrequency.Location = New System.Drawing.Point(354, 19)
        Me.rBtnIntervalFrequency.Name = "rBtnIntervalFrequency"
        Me.rBtnIntervalFrequency.Size = New System.Drawing.Size(71, 16)
        Me.rBtnIntervalFrequency.TabIndex = 90
        Me.rBtnIntervalFrequency.TabStop = True
        Me.rBtnIntervalFrequency.Text = "间隔频率"
        Me.rBtnIntervalFrequency.UseVisualStyleBackColor = True
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Location = New System.Drawing.Point(9, 59)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(82, 23)
        Me.LabelX11.TabIndex = 89
        Me.LabelX11.Text = "开始时间(D)"
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Location = New System.Drawing.Point(300, 17)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(82, 23)
        Me.LabelX10.TabIndex = 88
        Me.LabelX10.Text = "天"
        '
        'itxtExecutionInterval
        '
        '
        '
        '
        Me.itxtExecutionInterval.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.itxtExecutionInterval.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.itxtExecutionInterval.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.itxtExecutionInterval.Location = New System.Drawing.Point(82, 16)
        Me.itxtExecutionInterval.MaxValue = 100
        Me.itxtExecutionInterval.MinValue = 1
        Me.itxtExecutionInterval.Name = "itxtExecutionInterval"
        Me.itxtExecutionInterval.ShowUpDown = True
        Me.itxtExecutionInterval.Size = New System.Drawing.Size(210, 21)
        Me.itxtExecutionInterval.TabIndex = 87
        Me.itxtExecutionInterval.Value = 1
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Location = New System.Drawing.Point(9, 16)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(82, 23)
        Me.LabelX9.TabIndex = 86
        Me.LabelX9.Text = "执行间隔(R)"
        '
        'txtCreateTime
        '
        '
        '
        '
        Me.txtCreateTime.Border.Class = "TextBoxBorder"
        Me.txtCreateTime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCreateTime.Location = New System.Drawing.Point(428, 283)
        Me.txtCreateTime.Name = "txtCreateTime"
        Me.txtCreateTime.ReadOnly = True
        Me.txtCreateTime.Size = New System.Drawing.Size(208, 21)
        Me.txtCreateTime.TabIndex = 85
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(361, 285)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(82, 23)
        Me.LabelX6.TabIndex = 84
        Me.LabelX6.Text = "维护时间"
        '
        'txtCreateUserId
        '
        '
        '
        '
        Me.txtCreateUserId.Border.Class = "TextBoxBorder"
        Me.txtCreateUserId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCreateUserId.Location = New System.Drawing.Point(82, 285)
        Me.txtCreateUserId.Name = "txtCreateUserId"
        Me.txtCreateUserId.ReadOnly = True
        Me.txtCreateUserId.Size = New System.Drawing.Size(210, 21)
        Me.txtCreateUserId.TabIndex = 83
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(9, 283)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(82, 23)
        Me.LabelX5.TabIndex = 82
        Me.LabelX5.Text = "维护人"
        '
        'txtRewark
        '
        '
        '
        '
        Me.txtRewark.Border.Class = "TextBoxBorder"
        Me.txtRewark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRewark.Location = New System.Drawing.Point(82, 246)
        Me.txtRewark.Multiline = True
        Me.txtRewark.Name = "txtRewark"
        Me.txtRewark.Size = New System.Drawing.Size(554, 23)
        Me.txtRewark.TabIndex = 81
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(9, 246)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(82, 23)
        Me.LabelX3.TabIndex = 80
        Me.LabelX3.Text = "说明"
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Location = New System.Drawing.Point(300, 88)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(82, 23)
        Me.LabelX13.TabIndex = 100
        Me.LabelX13.Text = "天"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.Controls.Add(Me.chkDateColumnFlag)
        Me.TabPage3.Controls.Add(Me.mtxtTargetColumn)
        Me.TabPage3.Controls.Add(Me.LabelX20)
        Me.TabPage3.Controls.Add(Me.btnDeleteColumn)
        Me.TabPage3.Controls.Add(Me.btnAddColumn)
        Me.TabPage3.Controls.Add(Me.dgvColumn)
        Me.TabPage3.Controls.Add(Me.mtxtSourceColumn)
        Me.TabPage3.Controls.Add(Me.LabelX19)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(649, 317)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "列对应关系"
        '
        'chkDateColumnFlag
        '
        '
        '
        '
        Me.chkDateColumnFlag.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkDateColumnFlag.Enabled = False
        Me.chkDateColumnFlag.Location = New System.Drawing.Point(338, 58)
        Me.chkDateColumnFlag.Name = "chkDateColumnFlag"
        Me.chkDateColumnFlag.Size = New System.Drawing.Size(100, 23)
        Me.chkDateColumnFlag.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkDateColumnFlag.TabIndex = 96
        Me.chkDateColumnFlag.Text = "是否日期类型"
        '
        'mtxtTargetColumn
        '
        '
        '
        '
        Me.mtxtTargetColumn.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtTargetColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtTargetColumn.ButtonCustom.Image = Global.DataHistoryManagement.My.Resources.Resources.query
        Me.mtxtTargetColumn.ButtonCustom.Visible = True
        Me.mtxtTargetColumn.Enabled = False
        Me.mtxtTargetColumn.Location = New System.Drawing.Point(76, 58)
        Me.mtxtTargetColumn.Name = "mtxtTargetColumn"
        Me.mtxtTargetColumn.ReadOnly = True
        Me.mtxtTargetColumn.Size = New System.Drawing.Size(210, 21)
        Me.mtxtTargetColumn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtTargetColumn.TabIndex = 94
        Me.mtxtTargetColumn.Text = ""
        '
        'LabelX20
        '
        '
        '
        '
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX20.Location = New System.Drawing.Point(5, 58)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(96, 23)
        Me.LabelX20.TabIndex = 95
        Me.LabelX20.Text = "目标列"
        '
        'btnDeleteColumn
        '
        Me.btnDeleteColumn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDeleteColumn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDeleteColumn.Enabled = False
        Me.btnDeleteColumn.Location = New System.Drawing.Point(452, 15)
        Me.btnDeleteColumn.Name = "btnDeleteColumn"
        Me.btnDeleteColumn.Size = New System.Drawing.Size(65, 25)
        Me.btnDeleteColumn.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.btnDeleteColumn.TabIndex = 93
        Me.btnDeleteColumn.Text = "删 除"
        '
        'btnAddColumn
        '
        Me.btnAddColumn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAddColumn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAddColumn.Enabled = False
        Me.btnAddColumn.Location = New System.Drawing.Point(338, 15)
        Me.btnAddColumn.Name = "btnAddColumn"
        Me.btnAddColumn.Size = New System.Drawing.Size(65, 25)
        Me.btnAddColumn.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.btnAddColumn.TabIndex = 92
        Me.btnAddColumn.Text = "增 加"
        '
        'dgvColumn
        '
        Me.dgvColumn.AllowUserToAddRows = False
        Me.dgvColumn.AllowUserToDeleteRows = False
        Me.dgvColumn.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvColumn.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvColumn.ColumnHeadersHeight = 25
        Me.dgvColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvColumn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataHistoryColumnId, Me.DataHistoryId, Me.id, Me.SourceColumn, Me.TargetColumn, Me.DateColumnFlag, Me.CreateUserId, Me.CreateTime})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvColumn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvColumn.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvColumn.Location = New System.Drawing.Point(3, 96)
        Me.dgvColumn.Name = "dgvColumn"
        Me.dgvColumn.RowHeadersWidth = 15
        Me.dgvColumn.RowTemplate.Height = 28
        Me.dgvColumn.Size = New System.Drawing.Size(643, 218)
        Me.dgvColumn.TabIndex = 91
        '
        'DataHistoryColumnId
        '
        Me.DataHistoryColumnId.DataPropertyName = "DataHistoryColumnId"
        Me.DataHistoryColumnId.HeaderText = "DataHistoryColumnId"
        Me.DataHistoryColumnId.Name = "DataHistoryColumnId"
        Me.DataHistoryColumnId.ReadOnly = True
        Me.DataHistoryColumnId.Visible = False
        '
        'DataHistoryId
        '
        Me.DataHistoryId.DataPropertyName = "DataHistoryId"
        Me.DataHistoryId.HeaderText = "DataHistoryId"
        Me.DataHistoryId.Name = "DataHistoryId"
        Me.DataHistoryId.ReadOnly = True
        Me.DataHistoryId.Visible = False
        '
        'id
        '
        Me.id.DataPropertyName = "RowNumId"
        Me.id.HeaderText = "序号"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 40
        '
        'SourceColumn
        '
        Me.SourceColumn.DataPropertyName = "SourceColumn"
        Me.SourceColumn.HeaderText = "源栏列"
        Me.SourceColumn.Name = "SourceColumn"
        Me.SourceColumn.ReadOnly = True
        Me.SourceColumn.Width = 150
        '
        'TargetColumn
        '
        Me.TargetColumn.DataPropertyName = "TargetColumn"
        Me.TargetColumn.HeaderText = "目标列"
        Me.TargetColumn.Name = "TargetColumn"
        Me.TargetColumn.ReadOnly = True
        Me.TargetColumn.Width = 150
        '
        'DateColumnFlag
        '
        Me.DateColumnFlag.DataPropertyName = "DateColumnFlag"
        Me.DateColumnFlag.HeaderText = "是否日期"
        Me.DateColumnFlag.Name = "DateColumnFlag"
        Me.DateColumnFlag.ReadOnly = True
        Me.DateColumnFlag.Width = 70
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
        Me.CreateTime.Width = 150
        '
        'mtxtSourceColumn
        '
        '
        '
        '
        Me.mtxtSourceColumn.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtSourceColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtSourceColumn.ButtonCustom.Image = Global.DataHistoryManagement.My.Resources.Resources.query
        Me.mtxtSourceColumn.ButtonCustom.Visible = True
        Me.mtxtSourceColumn.Enabled = False
        Me.mtxtSourceColumn.Location = New System.Drawing.Point(76, 18)
        Me.mtxtSourceColumn.Name = "mtxtSourceColumn"
        Me.mtxtSourceColumn.ReadOnly = True
        Me.mtxtSourceColumn.Size = New System.Drawing.Size(210, 21)
        Me.mtxtSourceColumn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtSourceColumn.TabIndex = 89
        Me.mtxtSourceColumn.Text = ""
        '
        'LabelX19
        '
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Location = New System.Drawing.Point(5, 18)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(96, 23)
        Me.LabelX19.TabIndex = 90
        Me.LabelX19.Text = "源列"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.cboOperatorsType)
        Me.TabPage2.Controls.Add(Me.cboWhereType)
        Me.TabPage2.Controls.Add(Me.btnDeleteWhere)
        Me.TabPage2.Controls.Add(Me.btnAddWhere)
        Me.TabPage2.Controls.Add(Me.dgvWhere)
        Me.TabPage2.Controls.Add(Me.txtWhereSQL)
        Me.TabPage2.Controls.Add(Me.LabelX18)
        Me.TabPage2.Controls.Add(Me.mtxtWhereColumn)
        Me.TabPage2.Controls.Add(Me.LabelX17)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(649, 317)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "目标条件设置"
        '
        'cboOperatorsType
        '
        Me.cboOperatorsType.DisplayMember = "Text"
        Me.cboOperatorsType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboOperatorsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOperatorsType.FormattingEnabled = True
        Me.cboOperatorsType.ItemHeight = 15
        Me.cboOperatorsType.Location = New System.Drawing.Point(390, 20)
        Me.cboOperatorsType.Name = "cboOperatorsType"
        Me.cboOperatorsType.Size = New System.Drawing.Size(63, 21)
        Me.cboOperatorsType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboOperatorsType.TabIndex = 90
        '
        'cboWhereType
        '
        Me.cboWhereType.DisplayMember = "Text"
        Me.cboWhereType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboWhereType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWhereType.FormattingEnabled = True
        Me.cboWhereType.ItemHeight = 15
        Me.cboWhereType.Location = New System.Drawing.Point(310, 20)
        Me.cboWhereType.Name = "cboWhereType"
        Me.cboWhereType.Size = New System.Drawing.Size(61, 21)
        Me.cboWhereType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboWhereType.TabIndex = 89
        '
        'btnDeleteWhere
        '
        Me.btnDeleteWhere.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDeleteWhere.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDeleteWhere.Location = New System.Drawing.Point(572, 16)
        Me.btnDeleteWhere.Name = "btnDeleteWhere"
        Me.btnDeleteWhere.Size = New System.Drawing.Size(65, 25)
        Me.btnDeleteWhere.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.btnDeleteWhere.TabIndex = 88
        Me.btnDeleteWhere.Text = "删 除"
        '
        'btnAddWhere
        '
        Me.btnAddWhere.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAddWhere.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAddWhere.Location = New System.Drawing.Point(483, 17)
        Me.btnAddWhere.Name = "btnAddWhere"
        Me.btnAddWhere.Size = New System.Drawing.Size(65, 25)
        Me.btnAddWhere.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.btnAddWhere.TabIndex = 87
        Me.btnAddWhere.Text = "增 加"
        '
        'dgvWhere
        '
        Me.dgvWhere.AllowUserToAddRows = False
        Me.dgvWhere.AllowUserToDeleteRows = False
        Me.dgvWhere.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvWhere.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvWhere.ColumnHeadersHeight = 25
        Me.dgvWhere.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvWhere.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataHistoryWhereId, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.WhereType, Me.WhereColumn, Me.OperatorsType, Me.SQLWhere, Me.WCreateUserId, Me.WCreateTime})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvWhere.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvWhere.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvWhere.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvWhere.Location = New System.Drawing.Point(3, 96)
        Me.dgvWhere.Name = "dgvWhere"
        Me.dgvWhere.RowHeadersWidth = 15
        Me.dgvWhere.RowTemplate.Height = 28
        Me.dgvWhere.Size = New System.Drawing.Size(643, 218)
        Me.dgvWhere.TabIndex = 86
        '
        'DataHistoryWhereId
        '
        Me.DataHistoryWhereId.DataPropertyName = "DataHistoryWhereId"
        Me.DataHistoryWhereId.HeaderText = "DataHistoryWhereId"
        Me.DataHistoryWhereId.Name = "DataHistoryWhereId"
        Me.DataHistoryWhereId.ReadOnly = True
        Me.DataHistoryWhereId.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "DataHistoryId"
        Me.DataGridViewTextBoxColumn1.HeaderText = "DataHistoryId"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "RowNumId"
        Me.DataGridViewTextBoxColumn2.HeaderText = "序号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 40
        '
        'WhereType
        '
        Me.WhereType.DataPropertyName = "WhereType"
        Me.WhereType.HeaderText = "类型"
        Me.WhereType.Name = "WhereType"
        Me.WhereType.ReadOnly = True
        Me.WhereType.Width = 40
        '
        'WhereColumn
        '
        Me.WhereColumn.DataPropertyName = "WhereColumn"
        Me.WhereColumn.HeaderText = "条件列"
        Me.WhereColumn.Name = "WhereColumn"
        Me.WhereColumn.ReadOnly = True
        Me.WhereColumn.Width = 150
        '
        'OperatorsType
        '
        Me.OperatorsType.DataPropertyName = "OperatorsType"
        Me.OperatorsType.HeaderText = "运算符"
        Me.OperatorsType.Name = "OperatorsType"
        Me.OperatorsType.ReadOnly = True
        Me.OperatorsType.Width = 50
        '
        'SQLWhere
        '
        Me.SQLWhere.DataPropertyName = "SQLWhere"
        Me.SQLWhere.HeaderText = "条件SQL"
        Me.SQLWhere.Name = "SQLWhere"
        Me.SQLWhere.ReadOnly = True
        Me.SQLWhere.Width = 180
        '
        'WCreateUserId
        '
        Me.WCreateUserId.DataPropertyName = "CreateUserId"
        Me.WCreateUserId.HeaderText = "创建用户"
        Me.WCreateUserId.Name = "WCreateUserId"
        Me.WCreateUserId.ReadOnly = True
        '
        'WCreateTime
        '
        Me.WCreateTime.DataPropertyName = "CreateTime"
        Me.WCreateTime.HeaderText = "创建时间"
        Me.WCreateTime.Name = "WCreateTime"
        Me.WCreateTime.ReadOnly = True
        Me.WCreateTime.Width = 150
        '
        'txtWhereSQL
        '
        '
        '
        '
        Me.txtWhereSQL.Border.Class = "TextBoxBorder"
        Me.txtWhereSQL.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtWhereSQL.Location = New System.Drawing.Point(77, 57)
        Me.txtWhereSQL.Multiline = True
        Me.txtWhereSQL.Name = "txtWhereSQL"
        Me.txtWhereSQL.Size = New System.Drawing.Size(559, 33)
        Me.txtWhereSQL.TabIndex = 85
        '
        'LabelX18
        '
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Location = New System.Drawing.Point(6, 53)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(96, 23)
        Me.LabelX18.TabIndex = 84
        Me.LabelX18.Text = "条件SQL"
        '
        'mtxtWhereColumn
        '
        '
        '
        '
        Me.mtxtWhereColumn.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtWhereColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtWhereColumn.ButtonCustom.Image = Global.DataHistoryManagement.My.Resources.Resources.query
        Me.mtxtWhereColumn.ButtonCustom.Visible = True
        Me.mtxtWhereColumn.Location = New System.Drawing.Point(77, 20)
        Me.mtxtWhereColumn.Name = "mtxtWhereColumn"
        Me.mtxtWhereColumn.ReadOnly = True
        Me.mtxtWhereColumn.Size = New System.Drawing.Size(210, 21)
        Me.mtxtWhereColumn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtWhereColumn.TabIndex = 82
        Me.mtxtWhereColumn.Text = ""
        '
        'LabelX17
        '
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Location = New System.Drawing.Point(6, 20)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(96, 23)
        Me.LabelX17.TabIndex = 83
        Me.LabelX17.Text = "条件列"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage4.Controls.Add(Me.mtxtChildColumnName)
        Me.TabPage4.Controls.Add(Me.LabelX28)
        Me.TabPage4.Controls.Add(Me.dgvChild)
        Me.TabPage4.Controls.Add(Me.txtChildRemark)
        Me.TabPage4.Controls.Add(Me.LabelX27)
        Me.TabPage4.Controls.Add(Me.btnChildDelete)
        Me.TabPage4.Controls.Add(Me.btnChildAdd)
        Me.TabPage4.Controls.Add(Me.txtChildWhereSQL)
        Me.TabPage4.Controls.Add(Me.LabelX26)
        Me.TabPage4.Controls.Add(Me.mtxtParentColumnName)
        Me.TabPage4.Controls.Add(Me.LabelX25)
        Me.TabPage4.Controls.Add(Me.mtxtChildTableName)
        Me.TabPage4.Controls.Add(Me.LabelX24)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(649, 317)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "子表关系定义"
        '
        'mtxtChildColumnName
        '
        '
        '
        '
        Me.mtxtChildColumnName.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtChildColumnName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtChildColumnName.ButtonCustom.Image = Global.DataHistoryManagement.My.Resources.Resources.query
        Me.mtxtChildColumnName.ButtonCustom.Visible = True
        Me.mtxtChildColumnName.Location = New System.Drawing.Point(423, 54)
        Me.mtxtChildColumnName.Name = "mtxtChildColumnName"
        Me.mtxtChildColumnName.ReadOnly = True
        Me.mtxtChildColumnName.Size = New System.Drawing.Size(210, 21)
        Me.mtxtChildColumnName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtChildColumnName.TabIndex = 100
        Me.mtxtChildColumnName.Text = ""
        '
        'LabelX28
        '
        '
        '
        '
        Me.LabelX28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX28.Location = New System.Drawing.Point(350, 55)
        Me.LabelX28.Name = "LabelX28"
        Me.LabelX28.Size = New System.Drawing.Size(96, 23)
        Me.LabelX28.TabIndex = 101
        Me.LabelX28.Text = "关系子ID列"
        '
        'dgvChild
        '
        Me.dgvChild.AllowUserToAddRows = False
        Me.dgvChild.AllowUserToDeleteRows = False
        Me.dgvChild.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvChild.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvChild.ColumnHeadersHeight = 25
        Me.dgvChild.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataHistoryChildId, Me.ChildDataHistoryId, Me.ItemNo, Me.ChildTableName, Me.ParentColumnName, Me.ChildColumnName, Me.WhereSQL, Me.Remark})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvChild.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvChild.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvChild.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvChild.Location = New System.Drawing.Point(3, 133)
        Me.dgvChild.Name = "dgvChild"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvChild.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvChild.RowHeadersWidth = 15
        Me.dgvChild.RowTemplate.Height = 28
        Me.dgvChild.Size = New System.Drawing.Size(643, 181)
        Me.dgvChild.TabIndex = 99
        '
        'DataHistoryChildId
        '
        Me.DataHistoryChildId.HeaderText = "DataHistoryChildId"
        Me.DataHistoryChildId.Name = "DataHistoryChildId"
        Me.DataHistoryChildId.ReadOnly = True
        Me.DataHistoryChildId.Visible = False
        '
        'ChildDataHistoryId
        '
        Me.ChildDataHistoryId.HeaderText = "DataHistoryId"
        Me.ChildDataHistoryId.Name = "ChildDataHistoryId"
        Me.ChildDataHistoryId.ReadOnly = True
        Me.ChildDataHistoryId.Visible = False
        '
        'ItemNo
        '
        Me.ItemNo.DataPropertyName = "ItemNo"
        Me.ItemNo.HeaderText = "序号"
        Me.ItemNo.Name = "ItemNo"
        Me.ItemNo.ReadOnly = True
        Me.ItemNo.Width = 40
        '
        'ChildTableName
        '
        Me.ChildTableName.DataPropertyName = "ChildTableName"
        Me.ChildTableName.FillWeight = 170.0!
        Me.ChildTableName.HeaderText = "关系子表"
        Me.ChildTableName.Name = "ChildTableName"
        Me.ChildTableName.ReadOnly = True
        Me.ChildTableName.Width = 180
        '
        'ParentColumnName
        '
        Me.ParentColumnName.DataPropertyName = "ParentColumnName"
        Me.ParentColumnName.HeaderText = "关系主ID列"
        Me.ParentColumnName.Name = "ParentColumnName"
        Me.ParentColumnName.ReadOnly = True
        Me.ParentColumnName.Width = 120
        '
        'ChildColumnName
        '
        Me.ChildColumnName.DataPropertyName = "ChildColumnName"
        Me.ChildColumnName.HeaderText = "关系子ID列"
        Me.ChildColumnName.Name = "ChildColumnName"
        Me.ChildColumnName.ReadOnly = True
        Me.ChildColumnName.Width = 130
        '
        'WhereSQL
        '
        Me.WhereSQL.DataPropertyName = "WhereSQL"
        Me.WhereSQL.FillWeight = 200.0!
        Me.WhereSQL.HeaderText = "条件SQL"
        Me.WhereSQL.Name = "WhereSQL"
        Me.WhereSQL.ReadOnly = True
        Me.WhereSQL.Width = 200
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "说明"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        '
        'txtChildRemark
        '
        '
        '
        '
        Me.txtChildRemark.Border.Class = "TextBoxBorder"
        Me.txtChildRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtChildRemark.Location = New System.Drawing.Point(423, 90)
        Me.txtChildRemark.Multiline = True
        Me.txtChildRemark.Name = "txtChildRemark"
        Me.txtChildRemark.Size = New System.Drawing.Size(210, 37)
        Me.txtChildRemark.TabIndex = 98
        '
        'LabelX27
        '
        '
        '
        '
        Me.LabelX27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX27.Location = New System.Drawing.Point(350, 89)
        Me.LabelX27.Name = "LabelX27"
        Me.LabelX27.Size = New System.Drawing.Size(96, 23)
        Me.LabelX27.TabIndex = 97
        Me.LabelX27.Text = "说明"
        '
        'btnChildDelete
        '
        Me.btnChildDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnChildDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnChildDelete.Location = New System.Drawing.Point(471, 13)
        Me.btnChildDelete.Name = "btnChildDelete"
        Me.btnChildDelete.Size = New System.Drawing.Size(65, 25)
        Me.btnChildDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.btnChildDelete.TabIndex = 96
        Me.btnChildDelete.Text = "删 除"
        '
        'btnChildAdd
        '
        Me.btnChildAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnChildAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnChildAdd.Location = New System.Drawing.Point(352, 13)
        Me.btnChildAdd.Name = "btnChildAdd"
        Me.btnChildAdd.Size = New System.Drawing.Size(65, 25)
        Me.btnChildAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.btnChildAdd.TabIndex = 95
        Me.btnChildAdd.Text = "增 加"
        '
        'txtChildWhereSQL
        '
        '
        '
        '
        Me.txtChildWhereSQL.Border.Class = "TextBoxBorder"
        Me.txtChildWhereSQL.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtChildWhereSQL.Location = New System.Drawing.Point(81, 93)
        Me.txtChildWhereSQL.Multiline = True
        Me.txtChildWhereSQL.Name = "txtChildWhereSQL"
        Me.txtChildWhereSQL.Size = New System.Drawing.Size(210, 34)
        Me.txtChildWhereSQL.TabIndex = 94
        '
        'LabelX26
        '
        '
        '
        '
        Me.LabelX26.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX26.Location = New System.Drawing.Point(10, 89)
        Me.LabelX26.Name = "LabelX26"
        Me.LabelX26.Size = New System.Drawing.Size(96, 23)
        Me.LabelX26.TabIndex = 93
        Me.LabelX26.Text = "条件SQL"
        '
        'mtxtParentColumnName
        '
        '
        '
        '
        Me.mtxtParentColumnName.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtParentColumnName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtParentColumnName.ButtonCustom.Image = Global.DataHistoryManagement.My.Resources.Resources.query
        Me.mtxtParentColumnName.ButtonCustom.Visible = True
        Me.mtxtParentColumnName.Location = New System.Drawing.Point(81, 54)
        Me.mtxtParentColumnName.Name = "mtxtParentColumnName"
        Me.mtxtParentColumnName.ReadOnly = True
        Me.mtxtParentColumnName.Size = New System.Drawing.Size(210, 21)
        Me.mtxtParentColumnName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtParentColumnName.TabIndex = 91
        Me.mtxtParentColumnName.Text = ""
        '
        'LabelX25
        '
        '
        '
        '
        Me.LabelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX25.Location = New System.Drawing.Point(10, 55)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(96, 23)
        Me.LabelX25.TabIndex = 92
        Me.LabelX25.Text = "关系主ID列"
        '
        'mtxtChildTableName
        '
        '
        '
        '
        Me.mtxtChildTableName.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtChildTableName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtChildTableName.ButtonCustom.Image = Global.DataHistoryManagement.My.Resources.Resources.query
        Me.mtxtChildTableName.ButtonCustom.Visible = True
        Me.mtxtChildTableName.Location = New System.Drawing.Point(81, 17)
        Me.mtxtChildTableName.Name = "mtxtChildTableName"
        Me.mtxtChildTableName.ReadOnly = True
        Me.mtxtChildTableName.Size = New System.Drawing.Size(210, 21)
        Me.mtxtChildTableName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtChildTableName.TabIndex = 87
        Me.mtxtChildTableName.Text = ""
        '
        'LabelX24
        '
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Location = New System.Drawing.Point(10, 17)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(96, 23)
        Me.LabelX24.TabIndex = 88
        Me.LabelX24.Text = "关系子表"
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage5.Controls.Add(Me.dgvPrimaryKey)
        Me.TabPage5.Controls.Add(Me.mtxtTargetPrimaryKeyColumn)
        Me.TabPage5.Controls.Add(Me.LabelX36)
        Me.TabPage5.Controls.Add(Me.btnPrimaryKeyDelete)
        Me.TabPage5.Controls.Add(Me.btnPrimaryKeyAdd)
        Me.TabPage5.Controls.Add(Me.mtxtSourcePrimaryKeyColumn)
        Me.TabPage5.Controls.Add(Me.LabelX30)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(649, 317)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "主键关系"
        '
        'dgvPrimaryKey
        '
        Me.dgvPrimaryKey.AllowUserToAddRows = False
        Me.dgvPrimaryKey.AllowUserToDeleteRows = False
        Me.dgvPrimaryKey.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrimaryKey.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvPrimaryKey.ColumnHeadersHeight = 25
        Me.dgvPrimaryKey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPrimaryKey.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataHistoryPrimaryKeyId, Me.PDataHistroyId, Me.PKItemNO, Me.SourcePrimaryKeyColumn, Me.TargetPrimaryKeyColumn, Me.PKCreateUserId, Me.PKCreateTime})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPrimaryKey.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvPrimaryKey.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvPrimaryKey.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvPrimaryKey.Location = New System.Drawing.Point(3, 94)
        Me.dgvPrimaryKey.Name = "dgvPrimaryKey"
        Me.dgvPrimaryKey.RowHeadersWidth = 15
        Me.dgvPrimaryKey.RowTemplate.Height = 28
        Me.dgvPrimaryKey.Size = New System.Drawing.Size(643, 220)
        Me.dgvPrimaryKey.TabIndex = 100
        '
        'DataHistoryPrimaryKeyId
        '
        Me.DataHistoryPrimaryKeyId.DataPropertyName = "DataHistoryPrimaryKeyId"
        Me.DataHistoryPrimaryKeyId.HeaderText = "DataHistoryPrimaryKeyId"
        Me.DataHistoryPrimaryKeyId.Name = "DataHistoryPrimaryKeyId"
        Me.DataHistoryPrimaryKeyId.ReadOnly = True
        Me.DataHistoryPrimaryKeyId.Visible = False
        '
        'PDataHistroyId
        '
        Me.PDataHistroyId.DataPropertyName = "DataHistoryId"
        Me.PDataHistroyId.HeaderText = "DataHistoryId"
        Me.PDataHistroyId.Name = "PDataHistroyId"
        Me.PDataHistroyId.ReadOnly = True
        Me.PDataHistroyId.Visible = False
        '
        'PKItemNO
        '
        Me.PKItemNO.DataPropertyName = "ItemNO"
        Me.PKItemNO.HeaderText = "序号"
        Me.PKItemNO.Name = "PKItemNO"
        Me.PKItemNO.ReadOnly = True
        Me.PKItemNO.Width = 40
        '
        'SourcePrimaryKeyColumn
        '
        Me.SourcePrimaryKeyColumn.DataPropertyName = "SourcePrimaryKeyColumn"
        Me.SourcePrimaryKeyColumn.HeaderText = "源主键列"
        Me.SourcePrimaryKeyColumn.Name = "SourcePrimaryKeyColumn"
        Me.SourcePrimaryKeyColumn.ReadOnly = True
        Me.SourcePrimaryKeyColumn.Width = 180
        '
        'TargetPrimaryKeyColumn
        '
        Me.TargetPrimaryKeyColumn.DataPropertyName = "TargetPrimaryKeyColumn"
        Me.TargetPrimaryKeyColumn.HeaderText = "目标主键列"
        Me.TargetPrimaryKeyColumn.Name = "TargetPrimaryKeyColumn"
        Me.TargetPrimaryKeyColumn.ReadOnly = True
        Me.TargetPrimaryKeyColumn.Width = 180
        '
        'PKCreateUserId
        '
        Me.PKCreateUserId.DataPropertyName = "CreateUserId"
        Me.PKCreateUserId.HeaderText = "创建人"
        Me.PKCreateUserId.Name = "PKCreateUserId"
        Me.PKCreateUserId.ReadOnly = True
        Me.PKCreateUserId.Width = 120
        '
        'PKCreateTime
        '
        Me.PKCreateTime.DataPropertyName = "CreateTime"
        Me.PKCreateTime.HeaderText = "创建时间"
        Me.PKCreateTime.Name = "PKCreateTime"
        Me.PKCreateTime.ReadOnly = True
        Me.PKCreateTime.Width = 120
        '
        'mtxtTargetPrimaryKeyColumn
        '
        '
        '
        '
        Me.mtxtTargetPrimaryKeyColumn.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtTargetPrimaryKeyColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtTargetPrimaryKeyColumn.ButtonCustom.Image = Global.DataHistoryManagement.My.Resources.Resources.query
        Me.mtxtTargetPrimaryKeyColumn.ButtonCustom.Visible = True
        Me.mtxtTargetPrimaryKeyColumn.Location = New System.Drawing.Point(82, 55)
        Me.mtxtTargetPrimaryKeyColumn.Name = "mtxtTargetPrimaryKeyColumn"
        Me.mtxtTargetPrimaryKeyColumn.ReadOnly = True
        Me.mtxtTargetPrimaryKeyColumn.Size = New System.Drawing.Size(210, 21)
        Me.mtxtTargetPrimaryKeyColumn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtTargetPrimaryKeyColumn.TabIndex = 98
        Me.mtxtTargetPrimaryKeyColumn.Text = ""
        '
        'LabelX36
        '
        '
        '
        '
        Me.LabelX36.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX36.Location = New System.Drawing.Point(11, 55)
        Me.LabelX36.Name = "LabelX36"
        Me.LabelX36.Size = New System.Drawing.Size(96, 23)
        Me.LabelX36.TabIndex = 99
        Me.LabelX36.Text = "目标主键列"
        '
        'btnPrimaryKeyDelete
        '
        Me.btnPrimaryKeyDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrimaryKeyDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrimaryKeyDelete.Location = New System.Drawing.Point(452, 11)
        Me.btnPrimaryKeyDelete.Name = "btnPrimaryKeyDelete"
        Me.btnPrimaryKeyDelete.Size = New System.Drawing.Size(65, 25)
        Me.btnPrimaryKeyDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.btnPrimaryKeyDelete.TabIndex = 97
        Me.btnPrimaryKeyDelete.Text = "删 除"
        '
        'btnPrimaryKeyAdd
        '
        Me.btnPrimaryKeyAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrimaryKeyAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrimaryKeyAdd.Location = New System.Drawing.Point(338, 11)
        Me.btnPrimaryKeyAdd.Name = "btnPrimaryKeyAdd"
        Me.btnPrimaryKeyAdd.Size = New System.Drawing.Size(65, 25)
        Me.btnPrimaryKeyAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.btnPrimaryKeyAdd.TabIndex = 96
        Me.btnPrimaryKeyAdd.Text = "增 加"
        '
        'mtxtSourcePrimaryKeyColumn
        '
        '
        '
        '
        Me.mtxtSourcePrimaryKeyColumn.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtSourcePrimaryKeyColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtSourcePrimaryKeyColumn.ButtonCustom.Image = Global.DataHistoryManagement.My.Resources.Resources.query
        Me.mtxtSourcePrimaryKeyColumn.ButtonCustom.Visible = True
        Me.mtxtSourcePrimaryKeyColumn.Location = New System.Drawing.Point(82, 15)
        Me.mtxtSourcePrimaryKeyColumn.Name = "mtxtSourcePrimaryKeyColumn"
        Me.mtxtSourcePrimaryKeyColumn.ReadOnly = True
        Me.mtxtSourcePrimaryKeyColumn.Size = New System.Drawing.Size(210, 21)
        Me.mtxtSourcePrimaryKeyColumn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtSourcePrimaryKeyColumn.TabIndex = 94
        Me.mtxtSourcePrimaryKeyColumn.Text = ""
        '
        'LabelX30
        '
        '
        '
        '
        Me.LabelX30.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX30.Location = New System.Drawing.Point(11, 15)
        Me.LabelX30.Name = "LabelX30"
        Me.LabelX30.Size = New System.Drawing.Size(96, 23)
        Me.LabelX30.TabIndex = 95
        Me.LabelX30.Text = "源主键列"
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage6.Controls.Add(Me.cboTargetServerConfigName)
        Me.TabPage6.Controls.Add(Me.LabelX41)
        Me.TabPage6.Controls.Add(Me.cboServerConfigName)
        Me.TabPage6.Controls.Add(Me.LabelX14)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(649, 317)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "其他设置"
        '
        'cboServerConfigName
        '
        Me.cboServerConfigName.DisplayMember = "Text"
        Me.cboServerConfigName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboServerConfigName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServerConfigName.FormattingEnabled = True
        Me.cboServerConfigName.ItemHeight = 15
        Me.cboServerConfigName.Location = New System.Drawing.Point(92, 16)
        Me.cboServerConfigName.Name = "cboServerConfigName"
        Me.cboServerConfigName.Size = New System.Drawing.Size(210, 21)
        Me.cboServerConfigName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboServerConfigName.TabIndex = 196
        '
        'LabelX14
        '
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Location = New System.Drawing.Point(9, 16)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(82, 23)
        Me.LabelX14.TabIndex = 197
        Me.LabelX14.Text = "源Config名称"
        '
        'cboMigrateDataDelete
        '
        Me.cboMigrateDataDelete.DisplayMember = "Text"
        Me.cboMigrateDataDelete.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboMigrateDataDelete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMigrateDataDelete.FormattingEnabled = True
        Me.cboMigrateDataDelete.ItemHeight = 15
        Me.cboMigrateDataDelete.Location = New System.Drawing.Point(435, 83)
        Me.cboMigrateDataDelete.Name = "cboMigrateDataDelete"
        Me.cboMigrateDataDelete.Size = New System.Drawing.Size(210, 21)
        Me.cboMigrateDataDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboMigrateDataDelete.TabIndex = 192
        '
        'LabelX37
        '
        '
        '
        '
        Me.LabelX37.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX37.Location = New System.Drawing.Point(360, 83)
        Me.LabelX37.Name = "LabelX37"
        Me.LabelX37.Size = New System.Drawing.Size(82, 23)
        Me.LabelX37.TabIndex = 193
        Me.LabelX37.Text = "删除源数据"
        '
        'mtxtTargetTableName
        '
        '
        '
        '
        Me.mtxtTargetTableName.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtTargetTableName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtTargetTableName.ButtonCustom.Image = Global.DataHistoryManagement.My.Resources.Resources.query
        Me.mtxtTargetTableName.ButtonCustom.Visible = True
        Me.mtxtTargetTableName.Location = New System.Drawing.Point(91, 100)
        Me.mtxtTargetTableName.Name = "mtxtTargetTableName"
        Me.mtxtTargetTableName.ReadOnly = True
        Me.mtxtTargetTableName.Size = New System.Drawing.Size(210, 21)
        Me.mtxtTargetTableName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtTargetTableName.TabIndex = 85
        Me.mtxtTargetTableName.Text = ""
        '
        'LabelX21
        '
        '
        '
        '
        Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX21.Location = New System.Drawing.Point(15, 100)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(96, 23)
        Me.LabelX21.TabIndex = 86
        Me.LabelX21.Text = "目标表"
        '
        'chkColumnType
        '
        '
        '
        '
        Me.chkColumnType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkColumnType.Location = New System.Drawing.Point(83, 21)
        Me.chkColumnType.Name = "chkColumnType"
        Me.chkColumnType.Size = New System.Drawing.Size(100, 23)
        Me.chkColumnType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkColumnType.TabIndex = 87
        Me.chkColumnType.Text = "自定义"
        '
        'LabelX22
        '
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.Location = New System.Drawing.Point(10, 22)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(82, 23)
        Me.LabelX22.TabIndex = 88
        Me.LabelX22.Text = "列对应关系"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.mtxtTargetTableName)
        Me.GroupBox1.Controls.Add(Me.mtxtLinkServer)
        Me.GroupBox1.Controls.Add(Me.mtxtTargetDataBase)
        Me.GroupBox1.Controls.Add(Me.itxtProcessingNumber)
        Me.GroupBox1.Controls.Add(Me.LabelX8)
        Me.GroupBox1.Controls.Add(Me.LabelX4)
        Me.GroupBox1.Controls.Add(Me.LabelX21)
        Me.GroupBox1.Controls.Add(Me.LabelX2)
        Me.GroupBox1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(344, 125)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(314, 174)
        Me.GroupBox1.TabIndex = 89
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "目标定义"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.mtxtSequenceColumn)
        Me.GroupBox2.Controls.Add(Me.cboSequenceType)
        Me.GroupBox2.Controls.Add(Me.cboTreatment)
        Me.GroupBox2.Controls.Add(Me.LabelX7)
        Me.GroupBox2.Controls.Add(Me.LabelX16)
        Me.GroupBox2.Controls.Add(Me.LabelX15)
        Me.GroupBox2.Controls.Add(Me.chkColumnType)
        Me.GroupBox2.Controls.Add(Me.LabelX22)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 125)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(315, 174)
        Me.GroupBox2.TabIndex = 90
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "源定义"
        '
        'LabelX23
        '
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Location = New System.Drawing.Point(15, 11)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(393, 23)
        Me.LabelX23.TabIndex = 188
        Me.LabelX23.Text = "▼选择自定义列，系统不检查源/目标表列是否一致，否则检查"
        '
        'mtxtMigrateServer
        '
        '
        '
        '
        Me.mtxtMigrateServer.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtMigrateServer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtMigrateServer.ButtonCustom.Image = Global.DataHistoryManagement.My.Resources.Resources.query
        Me.mtxtMigrateServer.ButtonCustom.Visible = True
        Me.mtxtMigrateServer.Location = New System.Drawing.Point(88, 45)
        Me.mtxtMigrateServer.Name = "mtxtMigrateServer"
        Me.mtxtMigrateServer.ReadOnly = True
        Me.mtxtMigrateServer.Size = New System.Drawing.Size(210, 21)
        Me.mtxtMigrateServer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtMigrateServer.TabIndex = 189
        Me.mtxtMigrateServer.Text = ""
        '
        'LabelX29
        '
        '
        '
        '
        Me.LabelX29.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX29.Location = New System.Drawing.Point(15, 45)
        Me.LabelX29.Name = "LabelX29"
        Me.LabelX29.Size = New System.Drawing.Size(82, 23)
        Me.LabelX29.TabIndex = 190
        Me.LabelX29.Text = "源服务器"
        '
        'cboDataHistoryType
        '
        Me.cboDataHistoryType.DisplayMember = "Text"
        Me.cboDataHistoryType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboDataHistoryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDataHistoryType.FormattingEnabled = True
        Me.cboDataHistoryType.ItemHeight = 15
        Me.cboDataHistoryType.Location = New System.Drawing.Point(520, 11)
        Me.cboDataHistoryType.Name = "cboDataHistoryType"
        Me.cboDataHistoryType.Size = New System.Drawing.Size(125, 21)
        Me.cboDataHistoryType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboDataHistoryType.TabIndex = 191
        '
        'mtxtMigrateDataBase
        '
        '
        '
        '
        Me.mtxtMigrateDataBase.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtMigrateDataBase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtMigrateDataBase.ButtonCustom.Image = Global.DataHistoryManagement.My.Resources.Resources.query
        Me.mtxtMigrateDataBase.ButtonCustom.Visible = True
        Me.mtxtMigrateDataBase.Location = New System.Drawing.Point(435, 45)
        Me.mtxtMigrateDataBase.Name = "mtxtMigrateDataBase"
        Me.mtxtMigrateDataBase.ReadOnly = True
        Me.mtxtMigrateDataBase.Size = New System.Drawing.Size(210, 21)
        Me.mtxtMigrateDataBase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtMigrateDataBase.TabIndex = 192
        Me.mtxtMigrateDataBase.Text = ""
        '
        'LabelX38
        '
        '
        '
        '
        Me.LabelX38.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX38.Location = New System.Drawing.Point(359, 45)
        Me.LabelX38.Name = "LabelX38"
        Me.LabelX38.Size = New System.Drawing.Size(96, 23)
        Me.LabelX38.TabIndex = 193
        Me.LabelX38.Text = "源数据库"
        '
        'cboExecuteType
        '
        Me.cboExecuteType.DisplayMember = "Text"
        Me.cboExecuteType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboExecuteType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExecuteType.FormattingEnabled = True
        Me.cboExecuteType.ItemHeight = 15
        Me.cboExecuteType.Location = New System.Drawing.Point(363, 11)
        Me.cboExecuteType.Name = "cboExecuteType"
        Me.cboExecuteType.Size = New System.Drawing.Size(120, 21)
        Me.cboExecuteType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboExecuteType.TabIndex = 194
        '
        'cboTargetServerConfigName
        '
        Me.cboTargetServerConfigName.DisplayMember = "Text"
        Me.cboTargetServerConfigName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboTargetServerConfigName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTargetServerConfigName.FormattingEnabled = True
        Me.cboTargetServerConfigName.ItemHeight = 15
        Me.cboTargetServerConfigName.Location = New System.Drawing.Point(432, 16)
        Me.cboTargetServerConfigName.Name = "cboTargetServerConfigName"
        Me.cboTargetServerConfigName.Size = New System.Drawing.Size(210, 21)
        Me.cboTargetServerConfigName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboTargetServerConfigName.TabIndex = 198
        '
        'LabelX41
        '
        '
        '
        '
        Me.LabelX41.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX41.Location = New System.Drawing.Point(335, 16)
        Me.LabelX41.Name = "LabelX41"
        Me.LabelX41.Size = New System.Drawing.Size(111, 23)
        Me.LabelX41.TabIndex = 199
        Me.LabelX41.Text = "目标Config名称"
        '
        'FrmDataHistoryMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 701)
        Me.Controls.Add(Me.cboExecuteType)
        Me.Controls.Add(Me.cboMigrateDataDelete)
        Me.Controls.Add(Me.mtxtMigrateDataBase)
        Me.Controls.Add(Me.LabelX38)
        Me.Controls.Add(Me.cboDataHistoryType)
        Me.Controls.Add(Me.mtxtMigrateServer)
        Me.Controls.Add(Me.LabelX29)
        Me.Controls.Add(Me.LabelX23)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.chkStatusFlag)
        Me.Controls.Add(Me.mtxtMigrateTable)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LabelX37)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDataHistoryMaster"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "数据迁移维护"
        CType(Me.itxtProcessingNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dtpExecEndTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.itxtRetentionDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.itxtExecIncrementalTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEndTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtStartTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.itxtIntervalFrequency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.itxtExecutionInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvColumn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvWhere, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgvChild, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.dgvPrimaryKey, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents chkStatusFlag As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents mtxtMigrateTable As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents mtxtLinkServer As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents mtxtTargetDataBase As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents itxtProcessingNumber As DevComponents.Editors.IntegerInput
    Friend WithEvents cboTreatment As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents mtxtSequenceColumn As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboSequenceType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents itxtRetentionDays As DevComponents.Editors.IntegerInput
    Friend WithEvents txtSummary As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtEndTime As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rBtnNoEndDate As System.Windows.Forms.RadioButton
    Friend WithEvents rBtnEndDate As System.Windows.Forms.RadioButton
    Friend WithEvents cboIntervalType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents itxtIntervalFrequency As DevComponents.Editors.IntegerInput
    Friend WithEvents rBtnIntervalFrequency As System.Windows.Forms.RadioButton
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents itxtExecutionInterval As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCreateTime As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCreateUserId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtRewark As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents mtxtWhereColumn As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dgvWhere As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtWhereSQL As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnDeleteWhere As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAddWhere As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cboWhereType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents mtxtTargetColumn As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnDeleteColumn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAddColumn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgvColumn As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents mtxtSourceColumn As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents mtxtTargetTableName As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents chkColumnType As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents dgvChild As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtChildRemark As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX27 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnChildDelete As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnChildAdd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtChildWhereSQL As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX26 As DevComponents.DotNetBar.LabelX
    Friend WithEvents mtxtParentColumnName As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents mtxtChildTableName As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents mtxtChildColumnName As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX28 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DataHistoryChildId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChildDataHistoryId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChildTableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParentColumnName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChildColumnName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WhereSQL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboOperatorsType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents DataHistoryWhereId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WhereType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WhereColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperatorsType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SQLWhere As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCreateUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCreateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtStartTime As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents mtxtMigrateServer As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX29 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboDataHistoryType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents itxtExecIncrementalTime As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX31 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX35 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX34 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX33 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX32 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents mtxtTargetPrimaryKeyColumn As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX36 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnPrimaryKeyDelete As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrimaryKeyAdd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents mtxtSourcePrimaryKeyColumn As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX30 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dgvPrimaryKey As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents cboMigrateDataDelete As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX37 As DevComponents.DotNetBar.LabelX
    Friend WithEvents mtxtMigrateDataBase As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX38 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboIncrementalType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX39 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DataHistoryPrimaryKeyId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PDataHistroyId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PKItemNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SourcePrimaryKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TargetPrimaryKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PKCreateUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PKCreateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtpExecEndTime As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX40 As DevComponents.DotNetBar.LabelX
    Friend WithEvents chkDateColumnFlag As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents DataHistoryColumnId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataHistoryId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SourceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TargetColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateColumnFlag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboExecuteType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents cboServerConfigName As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboTargetServerConfigName As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX41 As DevComponents.DotNetBar.LabelX
End Class
