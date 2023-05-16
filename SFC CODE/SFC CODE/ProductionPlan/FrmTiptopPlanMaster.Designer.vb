<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTiptopPlanMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTiptopPlanMaster))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolAgain = New System.Windows.Forms.ToolStripButton()
        Me.ToolEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolCommit = New System.Windows.Forms.ToolStripButton()
        Me.ToolBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolQuery = New System.Windows.Forms.ToolStripButton()
        Me.toolCheck = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cboQueryType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.cboDept = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.txtChildLineId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtLineId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.txtPartId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.txtMOId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.dgvMoList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TiptopPlanId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Specification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeptId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstimatedDate = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.InNumberDays = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BelongsDeptId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StorageQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOStorageQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StandardWorkingHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LocationId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanStartTime = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.PlanEndTime = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.PlanRework = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanStatusFlagText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.dgvMoItemList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TiptopPlanItemId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMOid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CPartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SSpecification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CDeptId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mtxtLineId = New DevComponents.DotNetBar.Controls.DataGridViewMaskedTextBoxAdvColumn()
        Me.CActualStartDate = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.CStandardWorkingHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemPlanStartTime = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.ItemPlanEndTime = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvPlanWorkingHours = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.PlanWorkingHoursId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WHDeptId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WHLineId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WorkingHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SWorkingHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WHPlanStartTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WHPlanEndTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusFlagText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolLblCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn37 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn38 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn39 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolBt.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvMoList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvMoItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPlanWorkingHours, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNew, Me.ToolAgain, Me.ToolEdit, Me.ToolDelete, Me.ToolCommit, Me.ToolBack, Me.ToolStripSeparator3, Me.ToolQuery, Me.toolCheck, Me.ToolStripSeparator1, Me.ToolExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1082, 25)
        Me.ToolBt.TabIndex = 133
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolNew
        '
        Me.ToolNew.Enabled = False
        Me.ToolNew.ForeColor = System.Drawing.Color.Black
        Me.ToolNew.Image = CType(resources.GetObject("ToolNew.Image"), System.Drawing.Image)
        Me.ToolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolNew.Name = "ToolNew"
        Me.ToolNew.Size = New System.Drawing.Size(74, 22)
        Me.ToolNew.Tag = "NO"
        Me.ToolNew.Text = "新 增(&N)"
        Me.ToolNew.ToolTipText = "新 增"
        '
        'ToolAgain
        '
        Me.ToolAgain.ForeColor = System.Drawing.Color.Black
        Me.ToolAgain.Image = CType(resources.GetObject("ToolAgain.Image"), System.Drawing.Image)
        Me.ToolAgain.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolAgain.Name = "ToolAgain"
        Me.ToolAgain.Size = New System.Drawing.Size(92, 22)
        Me.ToolAgain.Tag = "NO"
        Me.ToolAgain.Text = "手动派工(&A)"
        Me.ToolAgain.ToolTipText = "重新手动下载"
        '
        'ToolEdit
        '
        Me.ToolEdit.Enabled = False
        Me.ToolEdit.ForeColor = System.Drawing.Color.Black
        Me.ToolEdit.Image = CType(resources.GetObject("ToolEdit.Image"), System.Drawing.Image)
        Me.ToolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEdit.Name = "ToolEdit"
        Me.ToolEdit.Size = New System.Drawing.Size(71, 22)
        Me.ToolEdit.Tag = "NO"
        Me.ToolEdit.Text = "修 改(&E)"
        Me.ToolEdit.ToolTipText = "修 改"
        '
        'ToolDelete
        '
        Me.ToolDelete.Enabled = False
        Me.ToolDelete.ForeColor = System.Drawing.Color.Black
        Me.ToolDelete.Image = CType(resources.GetObject("ToolDelete.Image"), System.Drawing.Image)
        Me.ToolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolDelete.Name = "ToolDelete"
        Me.ToolDelete.Size = New System.Drawing.Size(73, 22)
        Me.ToolDelete.Tag = "NO"
        Me.ToolDelete.Text = "删 除(&D)"
        Me.ToolDelete.ToolTipText = "删除"
        '
        'ToolCommit
        '
        Me.ToolCommit.Image = CType(resources.GetObject("ToolCommit.Image"), System.Drawing.Image)
        Me.ToolCommit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCommit.Name = "ToolCommit"
        Me.ToolCommit.Size = New System.Drawing.Size(68, 22)
        Me.ToolCommit.Tag = ""
        Me.ToolCommit.Text = "提交(&C)"
        Me.ToolCommit.ToolTipText = "提交"
        '
        'ToolBack
        '
        Me.ToolBack.Image = CType(resources.GetObject("ToolBack.Image"), System.Drawing.Image)
        Me.ToolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolBack.Name = "ToolBack"
        Me.ToolBack.Size = New System.Drawing.Size(68, 22)
        Me.ToolBack.Text = "返回(&B)"
        Me.ToolBack.ToolTipText = "返回"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolQuery
        '
        Me.ToolQuery.ForeColor = System.Drawing.Color.Black
        Me.ToolQuery.Image = CType(resources.GetObject("ToolQuery.Image"), System.Drawing.Image)
        Me.ToolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolQuery.Name = "ToolQuery"
        Me.ToolQuery.Size = New System.Drawing.Size(74, 22)
        Me.ToolQuery.Text = "查 询(&Q)"
        Me.ToolQuery.ToolTipText = "查 詢"
        '
        'toolCheck
        '
        Me.toolCheck.Image = CType(resources.GetObject("toolCheck.Image"), System.Drawing.Image)
        Me.toolCheck.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCheck.Name = "toolCheck"
        Me.toolCheck.Size = New System.Drawing.Size(67, 22)
        Me.toolCheck.Text = "审核(&T)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolExitFrom
        '
        Me.ToolExitFrom.ForeColor = System.Drawing.Color.Black
        Me.ToolExitFrom.Image = CType(resources.GetObject("ToolExitFrom.Image"), System.Drawing.Image)
        Me.ToolExitFrom.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolExitFrom.Name = "ToolExitFrom"
        Me.ToolExitFrom.Size = New System.Drawing.Size(72, 22)
        Me.ToolExitFrom.Text = "退 出(&X)"
        Me.ToolExitFrom.ToolTipText = "退 出"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboQueryType)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelX6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboDept)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelX5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtChildLineId)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelX4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtLineId)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelX3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtpStartDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtpEndDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblMessage)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtPartId)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelX2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMOId)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelX1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvMoList)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.StatusStrip1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1082, 547)
        Me.SplitContainer1.SplitterDistance = 266
        Me.SplitContainer1.TabIndex = 134
        '
        'cboQueryType
        '
        Me.cboQueryType.DisplayMember = "Text"
        Me.cboQueryType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboQueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboQueryType.FormattingEnabled = True
        Me.cboQueryType.ItemHeight = 15
        Me.cboQueryType.Location = New System.Drawing.Point(683, 58)
        Me.cboQueryType.Name = "cboQueryType"
        Me.cboQueryType.Size = New System.Drawing.Size(121, 21)
        Me.cboQueryType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboQueryType.TabIndex = 244
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(647, 58)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 23)
        Me.LabelX6.TabIndex = 245
        Me.LabelX6.Text = "类型："
        '
        'cboDept
        '
        Me.cboDept.DisplayMember = "Text"
        Me.cboDept.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboDept.FormattingEnabled = True
        Me.cboDept.ItemHeight = 15
        Me.cboDept.Location = New System.Drawing.Point(480, 58)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(121, 21)
        Me.cboDept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboDept.TabIndex = 221
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(432, 58)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 222
        Me.LabelX5.Text = "主部门："
        '
        'txtChildLineId
        '
        '
        '
        '
        Me.txtChildLineId.Border.Class = "TextBoxBorder"
        Me.txtChildLineId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtChildLineId.Location = New System.Drawing.Point(683, 16)
        Me.txtChildLineId.Name = "txtChildLineId"
        Me.txtChildLineId.Size = New System.Drawing.Size(120, 21)
        Me.txtChildLineId.TabIndex = 220
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(636, 16)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 219
        Me.LabelX4.Text = "子产线："
        '
        'txtLineId
        '
        '
        '
        '
        Me.txtLineId.Border.Class = "TextBoxBorder"
        Me.txtLineId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtLineId.Location = New System.Drawing.Point(480, 16)
        Me.txtLineId.Multiline = True
        Me.txtLineId.Name = "txtLineId"
        Me.txtLineId.Size = New System.Drawing.Size(120, 36)
        Me.txtLineId.TabIndex = 218
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(432, 16)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 217
        Me.LabelX3.Text = "主产线："
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(276, 58)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(120, 21)
        Me.dtpStartDate.TabIndex = 216
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(213, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 215
        Me.Label4.Text = "结束日期："
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(276, 15)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(120, 21)
        Me.dtpEndDate.TabIndex = 214
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(213, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 213
        Me.Label3.Text = "开始日期："
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Location = New System.Drawing.Point(835, 58)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(486, 23)
        Me.lblMessage.TabIndex = 5
        '
        'txtPartId
        '
        '
        '
        '
        Me.txtPartId.Border.Class = "TextBoxBorder"
        Me.txtPartId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPartId.Location = New System.Drawing.Point(58, 56)
        Me.txtPartId.Name = "txtPartId"
        Me.txtPartId.Size = New System.Drawing.Size(120, 21)
        Me.txtPartId.TabIndex = 4
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(22, 56)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "料号："
        '
        'txtMOId
        '
        '
        '
        '
        Me.txtMOId.Border.Class = "TextBoxBorder"
        Me.txtMOId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMOId.Location = New System.Drawing.Point(58, 17)
        Me.txtMOId.Name = "txtMOId"
        Me.txtMOId.Size = New System.Drawing.Size(120, 21)
        Me.txtMOId.TabIndex = 2
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(21, 17)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "工单："
        '
        'dgvMoList
        '
        Me.dgvMoList.AllowUserToAddRows = False
        Me.dgvMoList.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMoList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMoList.ColumnHeadersHeight = 27
        Me.dgvMoList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TiptopPlanId, Me.MOid, Me.PartId, Me.Description, Me.Specification, Me.Quantity, Me.CustId, Me.DeptId, Me.LineId, Me.EstimatedDate, Me.InNumberDays, Me.BelongsDeptId, Me.StorageQuantity, Me.NOStorageQuantity, Me.StandardWorkingHours, Me.LocationId, Me.PlanStartTime, Me.PlanEndTime, Me.PlanRework, Me.PlanStatusFlagText})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMoList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMoList.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvMoList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvMoList.EnableHeadersVisualStyles = False
        Me.dgvMoList.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvMoList.Location = New System.Drawing.Point(0, 126)
        Me.dgvMoList.Name = "dgvMoList"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMoList.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvMoList.RowHeadersWidth = 15
        Me.dgvMoList.RowTemplate.Height = 23
        Me.dgvMoList.Size = New System.Drawing.Size(1082, 140)
        Me.dgvMoList.TabIndex = 0
        '
        'TiptopPlanId
        '
        Me.TiptopPlanId.DataPropertyName = "TiptopPlanId"
        Me.TiptopPlanId.HeaderText = "TiptopPlanId"
        Me.TiptopPlanId.Name = "TiptopPlanId"
        Me.TiptopPlanId.ReadOnly = True
        Me.TiptopPlanId.Visible = False
        '
        'MOid
        '
        Me.MOid.DataPropertyName = "MOid"
        Me.MOid.HeaderText = "工单"
        Me.MOid.Name = "MOid"
        Me.MOid.ReadOnly = True
        '
        'PartId
        '
        Me.PartId.DataPropertyName = "PartId"
        Me.PartId.HeaderText = "料号"
        Me.PartId.Name = "PartId"
        Me.PartId.ReadOnly = True
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        Me.Description.HeaderText = "品名"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Visible = False
        '
        'Specification
        '
        Me.Specification.DataPropertyName = "Specification"
        Me.Specification.HeaderText = "规格"
        Me.Specification.Name = "Specification"
        Me.Specification.ReadOnly = True
        '
        'Quantity
        '
        Me.Quantity.DataPropertyName = "Quantity"
        Me.Quantity.HeaderText = "数量"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = True
        Me.Quantity.Width = 60
        '
        'CustId
        '
        Me.CustId.DataPropertyName = "CustId"
        Me.CustId.HeaderText = "客户简称"
        Me.CustId.Name = "CustId"
        Me.CustId.ReadOnly = True
        Me.CustId.Width = 60
        '
        'DeptId
        '
        Me.DeptId.DataPropertyName = "DeptId"
        Me.DeptId.HeaderText = "部门"
        Me.DeptId.Name = "DeptId"
        Me.DeptId.ReadOnly = True
        Me.DeptId.Width = 60
        '
        'LineId
        '
        Me.LineId.DataPropertyName = "LineId"
        Me.LineId.HeaderText = "线别"
        Me.LineId.Name = "LineId"
        Me.LineId.ReadOnly = True
        Me.LineId.Width = 60
        '
        'EstimatedDate
        '
        '
        '
        '
        Me.EstimatedDate.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.EstimatedDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.EstimatedDate.ButtonDropDown.Visible = True
        Me.EstimatedDate.CustomFormat = "yyyy-MM-dd"
        Me.EstimatedDate.DataPropertyName = "EstimatedDate"
        Me.EstimatedDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.EstimatedDate.HeaderText = "实际开工日"
        Me.EstimatedDate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.EstimatedDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.EstimatedDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.EstimatedDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.EstimatedDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.EstimatedDate.MonthCalendar.DisplayMonth = New Date(2016, 10, 1, 0, 0, 0, 0)
        Me.EstimatedDate.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.EstimatedDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.EstimatedDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.EstimatedDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.EstimatedDate.Name = "EstimatedDate"
        Me.EstimatedDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EstimatedDate.Width = 80
        '
        'InNumberDays
        '
        Me.InNumberDays.DataPropertyName = "InNumberDays"
        Me.InNumberDays.HeaderText = "派工日"
        Me.InNumberDays.Name = "InNumberDays"
        Me.InNumberDays.ReadOnly = True
        Me.InNumberDays.Width = 80
        '
        'BelongsDeptId
        '
        Me.BelongsDeptId.DataPropertyName = "BelongsDeptId"
        Me.BelongsDeptId.HeaderText = "所属部门"
        Me.BelongsDeptId.Name = "BelongsDeptId"
        Me.BelongsDeptId.ReadOnly = True
        Me.BelongsDeptId.Width = 60
        '
        'StorageQuantity
        '
        Me.StorageQuantity.DataPropertyName = "StorageQuantity"
        Me.StorageQuantity.HeaderText = "完工入库数量"
        Me.StorageQuantity.Name = "StorageQuantity"
        Me.StorageQuantity.ReadOnly = True
        Me.StorageQuantity.Width = 60
        '
        'NOStorageQuantity
        '
        Me.NOStorageQuantity.DataPropertyName = "NOStorageQuantity"
        Me.NOStorageQuantity.HeaderText = "未完成数量"
        Me.NOStorageQuantity.Name = "NOStorageQuantity"
        Me.NOStorageQuantity.ReadOnly = True
        Me.NOStorageQuantity.Width = 60
        '
        'StandardWorkingHours
        '
        Me.StandardWorkingHours.DataPropertyName = "StandardWorkingHours"
        Me.StandardWorkingHours.HeaderText = "标准工时"
        Me.StandardWorkingHours.Name = "StandardWorkingHours"
        Me.StandardWorkingHours.ReadOnly = True
        Me.StandardWorkingHours.Width = 60
        '
        'LocationId
        '
        Me.LocationId.DataPropertyName = "LocationId"
        Me.LocationId.HeaderText = "储位"
        Me.LocationId.Name = "LocationId"
        Me.LocationId.ReadOnly = True
        Me.LocationId.Visible = False
        Me.LocationId.Width = 60
        '
        'PlanStartTime
        '
        '
        '
        '
        Me.PlanStartTime.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.PlanStartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanStartTime.ButtonDropDown.Visible = True
        Me.PlanStartTime.CustomFormat = "yyyy-MM-dd HH:mm:dd"
        Me.PlanStartTime.DataPropertyName = "PlanStartTime"
        Me.PlanStartTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.PlanStartTime.HeaderText = "计划开始时间"
        Me.PlanStartTime.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.PlanStartTime.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.PlanStartTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanStartTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.PlanStartTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanStartTime.MonthCalendar.DisplayMonth = New Date(2017, 5, 1, 0, 0, 0, 0)
        Me.PlanStartTime.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.PlanStartTime.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.PlanStartTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanStartTime.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.PlanStartTime.Name = "PlanStartTime"
        Me.PlanStartTime.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'PlanEndTime
        '
        '
        '
        '
        Me.PlanEndTime.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.PlanEndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanEndTime.ButtonDropDown.Visible = True
        Me.PlanEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.PlanEndTime.DataPropertyName = "PlanEndTime"
        Me.PlanEndTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.PlanEndTime.HeaderText = "计划结束时间"
        Me.PlanEndTime.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.PlanEndTime.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.PlanEndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanEndTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.PlanEndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanEndTime.MonthCalendar.DisplayMonth = New Date(2017, 5, 1, 0, 0, 0, 0)
        Me.PlanEndTime.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.PlanEndTime.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.PlanEndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanEndTime.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.PlanEndTime.Name = "PlanEndTime"
        Me.PlanEndTime.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'PlanRework
        '
        Me.PlanRework.DataPropertyName = "PlanRework"
        Me.PlanRework.HeaderText = "计划备注"
        Me.PlanRework.Name = "PlanRework"
        Me.PlanRework.ReadOnly = True
        '
        'PlanStatusFlagText
        '
        Me.PlanStatusFlagText.DataPropertyName = "PlanStatusFlagText"
        Me.PlanStatusFlagText.HeaderText = "状态"
        Me.PlanStatusFlagText.Name = "PlanStatusFlagText"
        Me.PlanStatusFlagText.ReadOnly = True
        Me.PlanStatusFlagText.Width = 80
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgvMoItemList)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgvPlanWorkingHours)
        Me.SplitContainer2.Size = New System.Drawing.Size(1082, 255)
        Me.SplitContainer2.SplitterDistance = 843
        Me.SplitContainer2.TabIndex = 138
        '
        'dgvMoItemList
        '
        Me.dgvMoItemList.AllowUserToAddRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMoItemList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvMoItemList.ColumnHeadersHeight = 27
        Me.dgvMoItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TiptopPlanItemId, Me.CMOid, Me.CPartId, Me.CDescription, Me.SSpecification, Me.CQuantity, Me.CDeptId, Me.mtxtLineId, Me.CActualStartDate, Me.CStandardWorkingHours, Me.ItemPlanStartTime, Me.ItemPlanEndTime, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMoItemList.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvMoItemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMoItemList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvMoItemList.EnableHeadersVisualStyles = False
        Me.dgvMoItemList.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvMoItemList.Location = New System.Drawing.Point(0, 0)
        Me.dgvMoItemList.Name = "dgvMoItemList"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMoItemList.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvMoItemList.RowHeadersWidth = 15
        Me.dgvMoItemList.RowTemplate.Height = 23
        Me.dgvMoItemList.Size = New System.Drawing.Size(843, 255)
        Me.dgvMoItemList.TabIndex = 137
        '
        'TiptopPlanItemId
        '
        Me.TiptopPlanItemId.DataPropertyName = "TiptopPlanItemId"
        Me.TiptopPlanItemId.HeaderText = "TiptopPlanItemId"
        Me.TiptopPlanItemId.Name = "TiptopPlanItemId"
        Me.TiptopPlanItemId.ReadOnly = True
        Me.TiptopPlanItemId.Visible = False
        '
        'CMOid
        '
        Me.CMOid.DataPropertyName = "MOid"
        Me.CMOid.HeaderText = "工单"
        Me.CMOid.Name = "CMOid"
        Me.CMOid.ReadOnly = True
        Me.CMOid.Width = 200
        '
        'CPartId
        '
        Me.CPartId.DataPropertyName = "PartId"
        Me.CPartId.HeaderText = "料号"
        Me.CPartId.Name = "CPartId"
        Me.CPartId.ReadOnly = True
        '
        'CDescription
        '
        Me.CDescription.DataPropertyName = "Description"
        Me.CDescription.HeaderText = "品名"
        Me.CDescription.Name = "CDescription"
        Me.CDescription.ReadOnly = True
        Me.CDescription.Visible = False
        '
        'SSpecification
        '
        Me.SSpecification.DataPropertyName = "Specification"
        Me.SSpecification.HeaderText = "规格"
        Me.SSpecification.Name = "SSpecification"
        Me.SSpecification.ReadOnly = True
        '
        'CQuantity
        '
        Me.CQuantity.DataPropertyName = "Quantity"
        Me.CQuantity.HeaderText = "数量"
        Me.CQuantity.Name = "CQuantity"
        Me.CQuantity.ReadOnly = True
        Me.CQuantity.Width = 60
        '
        'CDeptId
        '
        Me.CDeptId.DataPropertyName = "DeptId"
        Me.CDeptId.HeaderText = "部门"
        Me.CDeptId.Name = "CDeptId"
        Me.CDeptId.ReadOnly = True
        Me.CDeptId.Width = 60
        '
        'mtxtLineId
        '
        Me.mtxtLineId.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.mtxtLineId.BackgroundStyle.Class = "DataGridViewBorder"
        Me.mtxtLineId.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtLineId.ButtonCustom.Visible = True
        Me.mtxtLineId.Culture = New System.Globalization.CultureInfo("zh-CN")
        Me.mtxtLineId.DataPropertyName = "LineId"
        Me.mtxtLineId.ForeColor = System.Drawing.SystemColors.ControlText
        Me.mtxtLineId.HeaderText = "产线"
        Me.mtxtLineId.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.mtxtLineId.Mask = ""
        Me.mtxtLineId.Name = "mtxtLineId"
        Me.mtxtLineId.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.mtxtLineId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mtxtLineId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.mtxtLineId.Text = ""
        Me.mtxtLineId.Width = 60
        '
        'CActualStartDate
        '
        '
        '
        '
        Me.CActualStartDate.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.CActualStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CActualStartDate.ButtonDropDown.Visible = True
        Me.CActualStartDate.CustomFormat = "yyyy-MM-dd"
        Me.CActualStartDate.DataPropertyName = "ActualStartDate"
        Me.CActualStartDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.CActualStartDate.HeaderText = "实际开工日"
        Me.CActualStartDate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.CActualStartDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.CActualStartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CActualStartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.CActualStartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CActualStartDate.MonthCalendar.DisplayMonth = New Date(2016, 10, 1, 0, 0, 0, 0)
        Me.CActualStartDate.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.CActualStartDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.CActualStartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CActualStartDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.CActualStartDate.Name = "CActualStartDate"
        Me.CActualStartDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CActualStartDate.Width = 80
        '
        'CStandardWorkingHours
        '
        Me.CStandardWorkingHours.DataPropertyName = "StandardWorkingHours"
        Me.CStandardWorkingHours.HeaderText = "标准工时"
        Me.CStandardWorkingHours.Name = "CStandardWorkingHours"
        Me.CStandardWorkingHours.ReadOnly = True
        Me.CStandardWorkingHours.Width = 60
        '
        'ItemPlanStartTime
        '
        '
        '
        '
        Me.ItemPlanStartTime.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.ItemPlanStartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPlanStartTime.ButtonDropDown.Visible = True
        Me.ItemPlanStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.ItemPlanStartTime.DataPropertyName = "PlanStartTime"
        Me.ItemPlanStartTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.ItemPlanStartTime.HeaderText = "计划开始时间"
        Me.ItemPlanStartTime.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.ItemPlanStartTime.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.ItemPlanStartTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPlanStartTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.ItemPlanStartTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPlanStartTime.MonthCalendar.DisplayMonth = New Date(2017, 5, 1, 0, 0, 0, 0)
        Me.ItemPlanStartTime.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.ItemPlanStartTime.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.ItemPlanStartTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPlanStartTime.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.ItemPlanStartTime.Name = "ItemPlanStartTime"
        Me.ItemPlanStartTime.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ItemPlanEndTime
        '
        '
        '
        '
        Me.ItemPlanEndTime.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.ItemPlanEndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPlanEndTime.ButtonDropDown.Visible = True
        Me.ItemPlanEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.ItemPlanEndTime.DataPropertyName = "PlanEndTime"
        Me.ItemPlanEndTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.ItemPlanEndTime.HeaderText = "计划结束时间"
        Me.ItemPlanEndTime.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.ItemPlanEndTime.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.ItemPlanEndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPlanEndTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.ItemPlanEndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPlanEndTime.MonthCalendar.DisplayMonth = New Date(2017, 5, 1, 0, 0, 0, 0)
        Me.ItemPlanEndTime.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.ItemPlanEndTime.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.ItemPlanEndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPlanEndTime.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.ItemPlanEndTime.Name = "ItemPlanEndTime"
        Me.ItemPlanEndTime.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "PlanRework"
        Me.DataGridViewTextBoxColumn3.HeaderText = "计划备注"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "PlanStatusFlagText"
        Me.DataGridViewTextBoxColumn4.HeaderText = "状态"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'dgvPlanWorkingHours
        '
        Me.dgvPlanWorkingHours.AllowUserToAddRows = False
        Me.dgvPlanWorkingHours.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPlanWorkingHours.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvPlanWorkingHours.ColumnHeadersHeight = 27
        Me.dgvPlanWorkingHours.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PlanWorkingHoursId, Me.WHDeptId, Me.WHLineId, Me.WorkingHours, Me.SWorkingHours, Me.WHPlanStartTime, Me.WHPlanEndTime, Me.StatusFlagText})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPlanWorkingHours.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvPlanWorkingHours.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPlanWorkingHours.EnableHeadersVisualStyles = False
        Me.dgvPlanWorkingHours.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvPlanWorkingHours.Location = New System.Drawing.Point(0, 0)
        Me.dgvPlanWorkingHours.Name = "dgvPlanWorkingHours"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPlanWorkingHours.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvPlanWorkingHours.RowHeadersWidth = 15
        Me.dgvPlanWorkingHours.RowTemplate.Height = 23
        Me.dgvPlanWorkingHours.Size = New System.Drawing.Size(235, 255)
        Me.dgvPlanWorkingHours.TabIndex = 0
        Me.dgvPlanWorkingHours.Visible = False
        '
        'PlanWorkingHoursId
        '
        Me.PlanWorkingHoursId.DataPropertyName = "PlanWorkingHoursId"
        Me.PlanWorkingHoursId.HeaderText = "PlanWorkingHoursId"
        Me.PlanWorkingHoursId.Name = "PlanWorkingHoursId"
        Me.PlanWorkingHoursId.ReadOnly = True
        Me.PlanWorkingHoursId.Visible = False
        '
        'WHDeptId
        '
        Me.WHDeptId.DataPropertyName = "DeptId"
        Me.WHDeptId.HeaderText = "部门"
        Me.WHDeptId.Name = "WHDeptId"
        Me.WHDeptId.ReadOnly = True
        Me.WHDeptId.Width = 70
        '
        'WHLineId
        '
        Me.WHLineId.DataPropertyName = "LineId"
        Me.WHLineId.HeaderText = "产线"
        Me.WHLineId.Name = "WHLineId"
        Me.WHLineId.ReadOnly = True
        Me.WHLineId.Width = 70
        '
        'WorkingHours
        '
        Me.WorkingHours.DataPropertyName = "WorkingHours"
        Me.WorkingHours.HeaderText = "排配工时"
        Me.WorkingHours.Name = "WorkingHours"
        Me.WorkingHours.ReadOnly = True
        Me.WorkingHours.Width = 80
        '
        'SWorkingHours
        '
        Me.SWorkingHours.DataPropertyName = "SWorkingHours"
        Me.SWorkingHours.HeaderText = "在制工时"
        Me.SWorkingHours.Name = "SWorkingHours"
        Me.SWorkingHours.ReadOnly = True
        Me.SWorkingHours.Width = 80
        '
        'WHPlanStartTime
        '
        Me.WHPlanStartTime.DataPropertyName = "PlanStartTime"
        Me.WHPlanStartTime.HeaderText = "开始时间"
        Me.WHPlanStartTime.Name = "WHPlanStartTime"
        Me.WHPlanStartTime.ReadOnly = True
        '
        'WHPlanEndTime
        '
        Me.WHPlanEndTime.DataPropertyName = "PlanEndTime"
        Me.WHPlanEndTime.HeaderText = "结束时间"
        Me.WHPlanEndTime.Name = "WHPlanEndTime"
        Me.WHPlanEndTime.ReadOnly = True
        '
        'StatusFlagText
        '
        Me.StatusFlagText.DataPropertyName = "StatusFlagText"
        Me.StatusFlagText.HeaderText = "状态"
        Me.StatusFlagText.Name = "StatusFlagText"
        Me.StatusFlagText.ReadOnly = True
        Me.StatusFlagText.Width = 80
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolLblCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 255)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1082, 22)
        Me.StatusStrip1.TabIndex = 136
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel1.Text = "记录笔数："
        '
        'ToolLblCount
        '
        Me.ToolLblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolLblCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ToolLblCount.LinkColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ToolLblCount.Name = "ToolLblCount"
        Me.ToolLblCount.Size = New System.Drawing.Size(15, 17)
        Me.ToolLblCount.Text = "0"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Specification"
        Me.DataGridViewTextBoxColumn5.HeaderText = "规格"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Quantity"
        Me.DataGridViewTextBoxColumn6.HeaderText = "数量"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 60
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "CustId"
        Me.DataGridViewTextBoxColumn7.HeaderText = "客户简称"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 60
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "DeptId"
        Me.DataGridViewTextBoxColumn8.HeaderText = "部门"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 60
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "LineId"
        Me.DataGridViewTextBoxColumn9.HeaderText = "线别"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 60
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "InNumberDays"
        Me.DataGridViewTextBoxColumn10.HeaderText = "在制天数"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 80
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "BelongsDeptId"
        Me.DataGridViewTextBoxColumn11.HeaderText = "所属部门"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 60
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "StorageQuantity"
        Me.DataGridViewTextBoxColumn12.HeaderText = "完工入库数量"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 60
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "NOStorageQuantity"
        Me.DataGridViewTextBoxColumn13.HeaderText = "未完成数量"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 60
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "StandardWorkingHours"
        Me.DataGridViewTextBoxColumn14.HeaderText = "标准工时"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 60
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "LocationId"
        Me.DataGridViewTextBoxColumn15.HeaderText = "储位"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 60
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "PlanStartTime"
        Me.DataGridViewTextBoxColumn16.HeaderText = "计划开始时间"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "PlanEndTime"
        Me.DataGridViewTextBoxColumn17.HeaderText = "计划结束时间"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "PlanRework"
        Me.DataGridViewTextBoxColumn18.HeaderText = "计划备注"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "PlanStatusFlagText"
        Me.DataGridViewTextBoxColumn19.HeaderText = "状态"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Width = 80
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "TiptopPlanItemId"
        Me.DataGridViewTextBoxColumn20.HeaderText = "TiptopPlanItemId"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Visible = False
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "MOid"
        Me.DataGridViewTextBoxColumn21.HeaderText = "工单"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Width = 200
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "PartId"
        Me.DataGridViewTextBoxColumn22.HeaderText = "料号"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "Description"
        Me.DataGridViewTextBoxColumn23.HeaderText = "品名"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "Specification"
        Me.DataGridViewTextBoxColumn24.HeaderText = "规格"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "Quantity"
        Me.DataGridViewTextBoxColumn25.HeaderText = "数量"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        Me.DataGridViewTextBoxColumn25.Width = 60
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "DeptId"
        Me.DataGridViewTextBoxColumn26.HeaderText = "部门"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        Me.DataGridViewTextBoxColumn26.Width = 60
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "StandardWorkingHours"
        Me.DataGridViewTextBoxColumn27.HeaderText = "标准工时"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.ReadOnly = True
        Me.DataGridViewTextBoxColumn27.Width = 60
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "PlanStartTime"
        Me.DataGridViewTextBoxColumn28.HeaderText = "计划开始时间"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.ReadOnly = True
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "PlanEndTime"
        Me.DataGridViewTextBoxColumn29.HeaderText = "计划结束时间"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.ReadOnly = True
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "PlanRework"
        Me.DataGridViewTextBoxColumn30.HeaderText = "计划备注"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.ReadOnly = True
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "PlanStatusFlagText"
        Me.DataGridViewTextBoxColumn31.HeaderText = "状态"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        Me.DataGridViewTextBoxColumn31.ReadOnly = True
        Me.DataGridViewTextBoxColumn31.Width = 80
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.DataPropertyName = "PlanWorkingHoursId"
        Me.DataGridViewTextBoxColumn32.HeaderText = "PlanWorkingHoursId"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        Me.DataGridViewTextBoxColumn32.ReadOnly = True
        Me.DataGridViewTextBoxColumn32.Visible = False
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "DeptId"
        Me.DataGridViewTextBoxColumn33.HeaderText = "部门"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.ReadOnly = True
        Me.DataGridViewTextBoxColumn33.Width = 70
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.DataPropertyName = "LineId"
        Me.DataGridViewTextBoxColumn34.HeaderText = "产线"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        Me.DataGridViewTextBoxColumn34.ReadOnly = True
        Me.DataGridViewTextBoxColumn34.Width = 70
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.DataPropertyName = "WorkingHours"
        Me.DataGridViewTextBoxColumn35.HeaderText = "排配工时"
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        Me.DataGridViewTextBoxColumn35.ReadOnly = True
        Me.DataGridViewTextBoxColumn35.Width = 80
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.DataPropertyName = "SWorkingHours"
        Me.DataGridViewTextBoxColumn36.HeaderText = "在制工时"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        Me.DataGridViewTextBoxColumn36.ReadOnly = True
        Me.DataGridViewTextBoxColumn36.Width = 80
        '
        'DataGridViewTextBoxColumn37
        '
        Me.DataGridViewTextBoxColumn37.DataPropertyName = "PlanStartTime"
        Me.DataGridViewTextBoxColumn37.HeaderText = "开始时间"
        Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
        Me.DataGridViewTextBoxColumn37.ReadOnly = True
        '
        'DataGridViewTextBoxColumn38
        '
        Me.DataGridViewTextBoxColumn38.DataPropertyName = "PlanEndTime"
        Me.DataGridViewTextBoxColumn38.HeaderText = "结束时间"
        Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
        Me.DataGridViewTextBoxColumn38.ReadOnly = True
        '
        'DataGridViewTextBoxColumn39
        '
        Me.DataGridViewTextBoxColumn39.DataPropertyName = "StatusFlagText"
        Me.DataGridViewTextBoxColumn39.HeaderText = "状态"
        Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
        Me.DataGridViewTextBoxColumn39.ReadOnly = True
        Me.DataGridViewTextBoxColumn39.Width = 80
        '
        'FrmTiptopPlanMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1082, 572)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmTiptopPlanMaster"
        Me.ShowIcon = False
        Me.Text = "生产派单计划"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvMoList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvMoItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPlanWorkingHours, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolAgain As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolCommit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvMoList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtMOId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtPartId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvMoItemList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolLblCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtLineId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtChildLineId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboDept As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvPlanWorkingHours As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents PlanWorkingHoursId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WHDeptId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WHLineId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkingHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SWorkingHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WHPlanStartTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WHPlanEndTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusFlagText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboQueryType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn35 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn37 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn38 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn39 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TiptopPlanId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Specification As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstimatedDate As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents InNumberDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BelongsDeptId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StorageQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOStorageQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardWorkingHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LocationId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanStartTime As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents PlanEndTime As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents PlanRework As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanStatusFlagText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TiptopPlanItemId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CMOid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CPartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SSpecification As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CDeptId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mtxtLineId As DevComponents.DotNetBar.Controls.DataGridViewMaskedTextBoxAdvColumn
    Friend WithEvents CActualStartDate As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents CStandardWorkingHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemPlanStartTime As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents ItemPlanEndTime As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
