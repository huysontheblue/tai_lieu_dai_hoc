<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSampleProblem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSampleProblem))
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolAdd = New System.Windows.Forms.ToolStripButton()
        Me.toolEdit = New System.Windows.Forms.ToolStripButton()
        Me.toolDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExprot = New System.Windows.Forms.ToolStripButton()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbSatus = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ChkKaiShi = New System.Windows.Forms.CheckBox()
        Me.ChkZhiYang = New System.Windows.Forms.CheckBox()
        Me.txtE_SampleTime = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTrackingSummary = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtEndTime = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtStartTime = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbIsOtherNG = New System.Windows.Forms.CheckBox()
        Me.cbIsMouldNG = New System.Windows.Forms.CheckBox()
        Me.cbIsCraftNG = New System.Windows.Forms.CheckBox()
        Me.cbIsMaterialNG = New System.Windows.Forms.CheckBox()
        Me.cbIsDrawingNG = New System.Windows.Forms.CheckBox()
        Me.selStatus = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtLongCountermeasure = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTempCountermeasure = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtProblemDesc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPersonLiable = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtS_SampleTime = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRDEngineer = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProblemName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dgvSampleProblem = New System.Windows.Forms.DataGridView()
        Me.ProblemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UrgentState = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RDEngineer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SampleTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SampleQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NGQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NGRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProblemDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsDrawingNG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsMaterialNG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsCraftNG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsMouldNG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsOtherNG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PersonLiable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TempCountermeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LongCountermeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TrackingSummary = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColExpFinishTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActFinishTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FilePath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProblemNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDutyEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBossEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBossEmailDept = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBossEmailDeptChief = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BeOverdueNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lbAcount = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.selStage = New System.Windows.Forms.ComboBox()
        Me.toolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvSampleProblem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolStrip1
        '
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAdd, Me.toolEdit, Me.toolDelete, Me.ToolStripSeparator1, Me.toolQuery, Me.ToolStripSeparator2, Me.toolExprot, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1370, 29)
        Me.toolStrip1.TabIndex = 134
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolAdd
        '
        Me.toolAdd.Image = CType(resources.GetObject("toolAdd.Image"), System.Drawing.Image)
        Me.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAdd.Name = "toolAdd"
        Me.toolAdd.Size = New System.Drawing.Size(74, 26)
        Me.toolAdd.Tag = "NO"
        Me.toolAdd.Text = "新 增(&N)"
        '
        'toolEdit
        '
        Me.toolEdit.Image = CType(resources.GetObject("toolEdit.Image"), System.Drawing.Image)
        Me.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEdit.Name = "toolEdit"
        Me.toolEdit.Size = New System.Drawing.Size(71, 26)
        Me.toolEdit.Tag = "NO"
        Me.toolEdit.Text = "修 改(&E)"
        '
        'toolDelete
        '
        Me.toolDelete.Image = CType(resources.GetObject("toolDelete.Image"), System.Drawing.Image)
        Me.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolDelete.Name = "toolDelete"
        Me.toolDelete.Size = New System.Drawing.Size(69, 26)
        Me.toolDelete.Tag = "NO"
        Me.toolDelete.Text = "作废(&D)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'toolQuery
        '
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(76, 26)
        Me.toolQuery.Text = "查  询(&F)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'toolExprot
        '
        Me.toolExprot.Image = CType(resources.GetObject("toolExprot.Image"), System.Drawing.Image)
        Me.toolExprot.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExprot.Name = "toolExprot"
        Me.toolExprot.Size = New System.Drawing.Size(52, 26)
        Me.toolExprot.Text = "导出"
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(72, 26)
        Me.toolExit.Text = "退 出(&X)"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.selStage)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.cmbSatus)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.ChkKaiShi)
        Me.Panel1.Controls.Add(Me.ChkZhiYang)
        Me.Panel1.Controls.Add(Me.txtE_SampleTime)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txtUserName)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtTrackingSummary)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtEndTime)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtStartTime)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.cbIsOtherNG)
        Me.Panel1.Controls.Add(Me.cbIsMouldNG)
        Me.Panel1.Controls.Add(Me.cbIsCraftNG)
        Me.Panel1.Controls.Add(Me.cbIsMaterialNG)
        Me.Panel1.Controls.Add(Me.cbIsDrawingNG)
        Me.Panel1.Controls.Add(Me.selStatus)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txtLongCountermeasure)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtTempCountermeasure)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtProblemDesc)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtPersonLiable)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtS_SampleTime)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtRDEngineer)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtProblemName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1370, 121)
        Me.Panel1.TabIndex = 135
        '
        'cmbSatus
        '
        Me.cmbSatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSatus.FormattingEnabled = True
        Me.cmbSatus.Items.AddRange(New Object() {"全部", "一般件", "加急件"})
        Me.cmbSatus.Location = New System.Drawing.Point(1239, 83)
        Me.cmbSatus.Name = "cmbSatus"
        Me.cmbSatus.Size = New System.Drawing.Size(92, 20)
        Me.cmbSatus.TabIndex = 167
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(1184, 87)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 12)
        Me.Label14.TabIndex = 166
        Me.Label14.Text = "加急状态"
        '
        'ChkKaiShi
        '
        Me.ChkKaiShi.AutoSize = True
        Me.ChkKaiShi.Location = New System.Drawing.Point(12, 49)
        Me.ChkKaiShi.Name = "ChkKaiShi"
        Me.ChkKaiShi.Size = New System.Drawing.Size(15, 14)
        Me.ChkKaiShi.TabIndex = 165
        Me.ChkKaiShi.UseVisualStyleBackColor = True
        '
        'ChkZhiYang
        '
        Me.ChkZhiYang.AutoSize = True
        Me.ChkZhiYang.Location = New System.Drawing.Point(405, 17)
        Me.ChkZhiYang.Name = "ChkZhiYang"
        Me.ChkZhiYang.Size = New System.Drawing.Size(15, 14)
        Me.ChkZhiYang.TabIndex = 164
        Me.ChkZhiYang.UseVisualStyleBackColor = True
        '
        'txtE_SampleTime
        '
        Me.txtE_SampleTime.CustomFormat = "yyyy/MM/dd"
        Me.txtE_SampleTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtE_SampleTime.Location = New System.Drawing.Point(613, 13)
        Me.txtE_SampleTime.Name = "txtE_SampleTime"
        Me.txtE_SampleTime.Size = New System.Drawing.Size(100, 21)
        Me.txtE_SampleTime.TabIndex = 163
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(600, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(11, 12)
        Me.Label13.TabIndex = 162
        Me.Label13.Text = "~"
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(658, 84)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(100, 21)
        Me.txtUserName.TabIndex = 161
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(611, 90)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 12)
        Me.Label11.TabIndex = 160
        Me.Label11.Text = "创建人"
        '
        'txtTrackingSummary
        '
        Me.txtTrackingSummary.Location = New System.Drawing.Point(62, 86)
        Me.txtTrackingSummary.Name = "txtTrackingSummary"
        Me.txtTrackingSummary.Size = New System.Drawing.Size(111, 21)
        Me.txtTrackingSummary.TabIndex = 159
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 88)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 12)
        Me.Label12.TabIndex = 158
        Me.Label12.Text = "追踪结论"
        '
        'txtEndTime
        '
        Me.txtEndTime.CustomFormat = "yyyy/MM/dd"
        Me.txtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtEndTime.Location = New System.Drawing.Point(293, 48)
        Me.txtEndTime.Name = "txtEndTime"
        Me.txtEndTime.Size = New System.Drawing.Size(100, 21)
        Me.txtEndTime.TabIndex = 157
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(240, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 12)
        Me.Label8.TabIndex = 156
        Me.Label8.Text = "~"
        '
        'txtStartTime
        '
        Me.txtStartTime.CustomFormat = "yyyy/MM/dd"
        Me.txtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtStartTime.Location = New System.Drawing.Point(83, 48)
        Me.txtStartTime.Name = "txtStartTime"
        Me.txtStartTime.Size = New System.Drawing.Size(111, 21)
        Me.txtStartTime.TabIndex = 155
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(28, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 154
        Me.Label7.Text = "开始日期"
        '
        'cbIsOtherNG
        '
        Me.cbIsOtherNG.AutoSize = True
        Me.cbIsOtherNG.Location = New System.Drawing.Point(1113, 87)
        Me.cbIsOtherNG.Name = "cbIsOtherNG"
        Me.cbIsOtherNG.Size = New System.Drawing.Size(72, 16)
        Me.cbIsOtherNG.TabIndex = 153
        Me.cbIsOtherNG.Text = "其它问题"
        Me.cbIsOtherNG.UseVisualStyleBackColor = True
        '
        'cbIsMouldNG
        '
        Me.cbIsMouldNG.AutoSize = True
        Me.cbIsMouldNG.Location = New System.Drawing.Point(1027, 87)
        Me.cbIsMouldNG.Name = "cbIsMouldNG"
        Me.cbIsMouldNG.Size = New System.Drawing.Size(84, 16)
        Me.cbIsMouldNG.TabIndex = 152
        Me.cbIsMouldNG.Text = "模治具问题"
        Me.cbIsMouldNG.UseVisualStyleBackColor = True
        '
        'cbIsCraftNG
        '
        Me.cbIsCraftNG.AutoSize = True
        Me.cbIsCraftNG.Location = New System.Drawing.Point(951, 87)
        Me.cbIsCraftNG.Name = "cbIsCraftNG"
        Me.cbIsCraftNG.Size = New System.Drawing.Size(72, 16)
        Me.cbIsCraftNG.TabIndex = 151
        Me.cbIsCraftNG.Text = "工艺问题"
        Me.cbIsCraftNG.UseVisualStyleBackColor = True
        '
        'cbIsMaterialNG
        '
        Me.cbIsMaterialNG.AutoSize = True
        Me.cbIsMaterialNG.Location = New System.Drawing.Point(872, 87)
        Me.cbIsMaterialNG.Name = "cbIsMaterialNG"
        Me.cbIsMaterialNG.Size = New System.Drawing.Size(72, 16)
        Me.cbIsMaterialNG.TabIndex = 150
        Me.cbIsMaterialNG.Text = "物料问题"
        Me.cbIsMaterialNG.UseVisualStyleBackColor = True
        '
        'cbIsDrawingNG
        '
        Me.cbIsDrawingNG.AutoSize = True
        Me.cbIsDrawingNG.Location = New System.Drawing.Point(770, 87)
        Me.cbIsDrawingNG.Name = "cbIsDrawingNG"
        Me.cbIsDrawingNG.Size = New System.Drawing.Size(102, 16)
        Me.cbIsDrawingNG.TabIndex = 149
        Me.cbIsDrawingNG.Text = "设计/图纸问题"
        Me.cbIsDrawingNG.UseVisualStyleBackColor = True
        '
        'selStatus
        '
        Me.selStatus.FormattingEnabled = True
        Me.selStatus.Location = New System.Drawing.Point(293, 86)
        Me.selStatus.Name = "selStatus"
        Me.selStatus.Size = New System.Drawing.Size(100, 20)
        Me.selStatus.TabIndex = 148
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(222, 89)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 12)
        Me.Label17.TabIndex = 147
        Me.Label17.Text = "追踪状态"
        '
        'txtLongCountermeasure
        '
        Me.txtLongCountermeasure.Location = New System.Drawing.Point(956, 46)
        Me.txtLongCountermeasure.Name = "txtLongCountermeasure"
        Me.txtLongCountermeasure.Size = New System.Drawing.Size(375, 21)
        Me.txtLongCountermeasure.TabIndex = 31
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(891, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "长期对策"
        '
        'txtTempCountermeasure
        '
        Me.txtTempCountermeasure.Location = New System.Drawing.Point(482, 49)
        Me.txtTempCountermeasure.Name = "txtTempCountermeasure"
        Me.txtTempCountermeasure.Size = New System.Drawing.Size(276, 21)
        Me.txtTempCountermeasure.TabIndex = 29
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(423, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "临时对策"
        '
        'txtProblemDesc
        '
        Me.txtProblemDesc.Location = New System.Drawing.Point(956, 13)
        Me.txtProblemDesc.Name = "txtProblemDesc"
        Me.txtProblemDesc.Size = New System.Drawing.Size(375, 21)
        Me.txtProblemDesc.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(891, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "问题描述"
        '
        'txtPersonLiable
        '
        Me.txtPersonLiable.Location = New System.Drawing.Point(483, 84)
        Me.txtPersonLiable.Name = "txtPersonLiable"
        Me.txtPersonLiable.Size = New System.Drawing.Size(100, 21)
        Me.txtPersonLiable.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(423, 88)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 12)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "责任人"
        '
        'txtS_SampleTime
        '
        Me.txtS_SampleTime.CustomFormat = " yyyy/MM/dd"
        Me.txtS_SampleTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtS_SampleTime.Location = New System.Drawing.Point(483, 13)
        Me.txtS_SampleTime.Name = "txtS_SampleTime"
        Me.txtS_SampleTime.Size = New System.Drawing.Size(111, 21)
        Me.txtS_SampleTime.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(424, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "制样日期"
        '
        'txtRDEngineer
        '
        Me.txtRDEngineer.Location = New System.Drawing.Point(293, 13)
        Me.txtRDEngineer.Name = "txtRDEngineer"
        Me.txtRDEngineer.Size = New System.Drawing.Size(100, 21)
        Me.txtRDEngineer.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(222, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "研发工程师"
        '
        'txtProblemName
        '
        Me.txtProblemName.Location = New System.Drawing.Point(83, 13)
        Me.txtProblemName.Name = "txtProblemName"
        Me.txtProblemName.Size = New System.Drawing.Size(111, 21)
        Me.txtProblemName.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "RDN/品名"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 150)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1370, 428)
        Me.Panel2.TabIndex = 136
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.dgvSampleProblem)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1370, 402)
        Me.Panel3.TabIndex = 1
        '
        'dgvSampleProblem
        '
        Me.dgvSampleProblem.AllowUserToAddRows = False
        Me.dgvSampleProblem.AllowUserToDeleteRows = False
        Me.dgvSampleProblem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSampleProblem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProblemName, Me.UrgentState, Me.stage, Me.RDEngineer, Me.SampleTime, Me.SampleQty, Me.NGQty, Me.NGRate, Me.StatusName, Me.ProblemDesc, Me.IsDrawingNG, Me.IsMaterialNG, Me.IsCraftNG, Me.IsMouldNG, Me.IsOtherNG, Me.PersonLiable, Me.TempCountermeasure, Me.LongCountermeasure, Me.TrackingSummary, Me.StartTime, Me.ColExpFinishTime, Me.ActFinishTime, Me.FilePath, Me.Column21, Me.Column22, Me.ProblemNo, Me.Column25, Me.ColDutyEmail, Me.ColBossEmail, Me.ColBossEmailDept, Me.ColBossEmailDeptChief, Me.BeOverdueNum})
        Me.dgvSampleProblem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSampleProblem.Location = New System.Drawing.Point(0, 0)
        Me.dgvSampleProblem.Name = "dgvSampleProblem"
        Me.dgvSampleProblem.ReadOnly = True
        Me.dgvSampleProblem.RowHeadersVisible = False
        Me.dgvSampleProblem.RowTemplate.Height = 23
        Me.dgvSampleProblem.Size = New System.Drawing.Size(1370, 402)
        Me.dgvSampleProblem.TabIndex = 0
        '
        'ProblemName
        '
        Me.ProblemName.DataPropertyName = "ProblemName"
        Me.ProblemName.Frozen = True
        Me.ProblemName.HeaderText = "RDN/品名"
        Me.ProblemName.Name = "ProblemName"
        Me.ProblemName.ReadOnly = True
        '
        'UrgentState
        '
        Me.UrgentState.DataPropertyName = "UrgentState"
        Me.UrgentState.Frozen = True
        Me.UrgentState.HeaderText = "加急状态"
        Me.UrgentState.Name = "UrgentState"
        Me.UrgentState.ReadOnly = True
        Me.UrgentState.Width = 80
        '
        'stage
        '
        Me.stage.DataPropertyName = "stage"
        Me.stage.Frozen = True
        Me.stage.HeaderText = "发生阶段"
        Me.stage.Name = "stage"
        Me.stage.ReadOnly = True
        '
        'RDEngineer
        '
        Me.RDEngineer.DataPropertyName = "RDEngineer"
        Me.RDEngineer.Frozen = True
        Me.RDEngineer.HeaderText = "研发工程师"
        Me.RDEngineer.Name = "RDEngineer"
        Me.RDEngineer.ReadOnly = True
        '
        'SampleTime
        '
        Me.SampleTime.DataPropertyName = "SampleTime"
        Me.SampleTime.Frozen = True
        Me.SampleTime.HeaderText = "制样日期"
        Me.SampleTime.Name = "SampleTime"
        Me.SampleTime.ReadOnly = True
        Me.SampleTime.Width = 80
        '
        'SampleQty
        '
        Me.SampleQty.DataPropertyName = "SampleQty"
        Me.SampleQty.Frozen = True
        Me.SampleQty.HeaderText = "制样数量"
        Me.SampleQty.Name = "SampleQty"
        Me.SampleQty.ReadOnly = True
        Me.SampleQty.Width = 80
        '
        'NGQty
        '
        Me.NGQty.DataPropertyName = "NGQty"
        Me.NGQty.Frozen = True
        Me.NGQty.HeaderText = "不良数量"
        Me.NGQty.Name = "NGQty"
        Me.NGQty.ReadOnly = True
        Me.NGQty.Width = 80
        '
        'NGRate
        '
        Me.NGRate.DataPropertyName = "NGRate"
        Me.NGRate.Frozen = True
        Me.NGRate.HeaderText = "不良率(%)"
        Me.NGRate.Name = "NGRate"
        Me.NGRate.ReadOnly = True
        '
        'StatusName
        '
        Me.StatusName.DataPropertyName = "StatusName"
        Me.StatusName.Frozen = True
        Me.StatusName.HeaderText = "追踪状态"
        Me.StatusName.Name = "StatusName"
        Me.StatusName.ReadOnly = True
        Me.StatusName.Width = 80
        '
        'ProblemDesc
        '
        Me.ProblemDesc.DataPropertyName = "ProblemDesc"
        Me.ProblemDesc.Frozen = True
        Me.ProblemDesc.HeaderText = "问题描述"
        Me.ProblemDesc.Name = "ProblemDesc"
        Me.ProblemDesc.ReadOnly = True
        '
        'IsDrawingNG
        '
        Me.IsDrawingNG.DataPropertyName = "IsDrawingNG"
        Me.IsDrawingNG.HeaderText = "设计/图纸问题"
        Me.IsDrawingNG.Name = "IsDrawingNG"
        Me.IsDrawingNG.ReadOnly = True
        Me.IsDrawingNG.Width = 90
        '
        'IsMaterialNG
        '
        Me.IsMaterialNG.DataPropertyName = "IsMaterialNG"
        Me.IsMaterialNG.HeaderText = "物料问题"
        Me.IsMaterialNG.Name = "IsMaterialNG"
        Me.IsMaterialNG.ReadOnly = True
        Me.IsMaterialNG.Width = 60
        '
        'IsCraftNG
        '
        Me.IsCraftNG.DataPropertyName = "IsCraftNG"
        Me.IsCraftNG.HeaderText = "工艺问题"
        Me.IsCraftNG.Name = "IsCraftNG"
        Me.IsCraftNG.ReadOnly = True
        Me.IsCraftNG.Width = 60
        '
        'IsMouldNG
        '
        Me.IsMouldNG.DataPropertyName = "IsMouldNG"
        Me.IsMouldNG.HeaderText = "模治具问题"
        Me.IsMouldNG.Name = "IsMouldNG"
        Me.IsMouldNG.ReadOnly = True
        Me.IsMouldNG.Width = 70
        '
        'IsOtherNG
        '
        Me.IsOtherNG.DataPropertyName = "IsOtherNG"
        Me.IsOtherNG.HeaderText = "其它问题"
        Me.IsOtherNG.Name = "IsOtherNG"
        Me.IsOtherNG.ReadOnly = True
        Me.IsOtherNG.Width = 60
        '
        'PersonLiable
        '
        Me.PersonLiable.DataPropertyName = "PersonLiable"
        Me.PersonLiable.HeaderText = "责任人"
        Me.PersonLiable.Name = "PersonLiable"
        Me.PersonLiable.ReadOnly = True
        Me.PersonLiable.Width = 80
        '
        'TempCountermeasure
        '
        Me.TempCountermeasure.DataPropertyName = "TempCountermeasure"
        Me.TempCountermeasure.HeaderText = "临时对策"
        Me.TempCountermeasure.Name = "TempCountermeasure"
        Me.TempCountermeasure.ReadOnly = True
        '
        'LongCountermeasure
        '
        Me.LongCountermeasure.DataPropertyName = "LongCountermeasure"
        Me.LongCountermeasure.HeaderText = "长期对策"
        Me.LongCountermeasure.Name = "LongCountermeasure"
        Me.LongCountermeasure.ReadOnly = True
        '
        'TrackingSummary
        '
        Me.TrackingSummary.DataPropertyName = "TrackingSummary"
        Me.TrackingSummary.HeaderText = "追踪结论"
        Me.TrackingSummary.Name = "TrackingSummary"
        Me.TrackingSummary.ReadOnly = True
        Me.TrackingSummary.Width = 80
        '
        'StartTime
        '
        Me.StartTime.DataPropertyName = "StartTime"
        Me.StartTime.HeaderText = "开始日期"
        Me.StartTime.Name = "StartTime"
        Me.StartTime.ReadOnly = True
        Me.StartTime.Width = 80
        '
        'ColExpFinishTime
        '
        Me.ColExpFinishTime.DataPropertyName = "ExpFinishTime"
        Me.ColExpFinishTime.HeaderText = "预计完成日期"
        Me.ColExpFinishTime.Name = "ColExpFinishTime"
        Me.ColExpFinishTime.ReadOnly = True
        '
        'ActFinishTime
        '
        Me.ActFinishTime.DataPropertyName = "ActFinishTime"
        Me.ActFinishTime.HeaderText = "实际完成日期"
        Me.ActFinishTime.Name = "ActFinishTime"
        Me.ActFinishTime.ReadOnly = True
        '
        'FilePath
        '
        Me.FilePath.DataPropertyName = "FilePath"
        Me.FilePath.HeaderText = "附件"
        Me.FilePath.Name = "FilePath"
        Me.FilePath.ReadOnly = True
        Me.FilePath.Width = 70
        '
        'Column21
        '
        Me.Column21.DataPropertyName = "UserName"
        Me.Column21.HeaderText = "创建人"
        Me.Column21.Name = "Column21"
        Me.Column21.ReadOnly = True
        Me.Column21.Width = 80
        '
        'Column22
        '
        Me.Column22.DataPropertyName = "CreateTime"
        Me.Column22.HeaderText = "创建日期"
        Me.Column22.Name = "Column22"
        Me.Column22.ReadOnly = True
        Me.Column22.Width = 80
        '
        'ProblemNo
        '
        Me.ProblemNo.DataPropertyName = "ProblemNo"
        Me.ProblemNo.HeaderText = "问题单号"
        Me.ProblemNo.Name = "ProblemNo"
        Me.ProblemNo.ReadOnly = True
        Me.ProblemNo.Visible = False
        '
        'Column25
        '
        Me.Column25.DataPropertyName = "Status"
        Me.Column25.HeaderText = "状态值"
        Me.Column25.Name = "Column25"
        Me.Column25.ReadOnly = True
        Me.Column25.Visible = False
        '
        'ColDutyEmail
        '
        Me.ColDutyEmail.DataPropertyName = "DutyEmail"
        Me.ColDutyEmail.HeaderText = "负责人邮箱"
        Me.ColDutyEmail.Name = "ColDutyEmail"
        Me.ColDutyEmail.ReadOnly = True
        Me.ColDutyEmail.Visible = False
        '
        'ColBossEmail
        '
        Me.ColBossEmail.DataPropertyName = "BossEmail"
        Me.ColBossEmail.HeaderText = "负责人直属主管邮箱"
        Me.ColBossEmail.Name = "ColBossEmail"
        Me.ColBossEmail.ReadOnly = True
        Me.ColBossEmail.Visible = False
        '
        'ColBossEmailDept
        '
        Me.ColBossEmailDept.DataPropertyName = "BossEmailDept"
        Me.ColBossEmailDept.HeaderText = "部级主管邮箱"
        Me.ColBossEmailDept.Name = "ColBossEmailDept"
        Me.ColBossEmailDept.ReadOnly = True
        Me.ColBossEmailDept.Visible = False
        '
        'ColBossEmailDeptChief
        '
        Me.ColBossEmailDeptChief.DataPropertyName = "BossEmailDeptChief"
        Me.ColBossEmailDeptChief.HeaderText = "处级主管邮箱"
        Me.ColBossEmailDeptChief.Name = "ColBossEmailDeptChief"
        Me.ColBossEmailDeptChief.ReadOnly = True
        Me.ColBossEmailDeptChief.Visible = False
        '
        'BeOverdueNum
        '
        Me.BeOverdueNum.DataPropertyName = "BeOverdueNum"
        Me.BeOverdueNum.HeaderText = "延期次数"
        Me.BeOverdueNum.Name = "BeOverdueNum"
        Me.BeOverdueNum.ReadOnly = True
        Me.BeOverdueNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.BeOverdueNum.Width = 70
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lbAcount)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 402)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1370, 26)
        Me.Panel4.TabIndex = 2
        '
        'lbAcount
        '
        Me.lbAcount.AutoSize = True
        Me.lbAcount.ForeColor = System.Drawing.Color.Blue
        Me.lbAcount.Location = New System.Drawing.Point(60, 7)
        Me.lbAcount.Name = "lbAcount"
        Me.lbAcount.Size = New System.Drawing.Size(11, 12)
        Me.lbAcount.TabIndex = 1
        Me.lbAcount.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 12)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "总笔数:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(736, 17)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 12)
        Me.Label15.TabIndex = 168
        Me.Label15.Text = "发生阶段"
        '
        'selStage
        '
        Me.selStage.FormattingEnabled = True
        Me.selStage.Location = New System.Drawing.Point(795, 13)
        Me.selStage.Name = "selStage"
        Me.selStage.Size = New System.Drawing.Size(77, 20)
        Me.selStage.TabIndex = 169
        '
        'FrmSampleProblem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 578)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "FrmSampleProblem"
        Me.Text = "制样解析备忘库"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgvSampleProblem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEdit As System.Windows.Forms.ToolStripButton
    Private WithEvents toolDelete As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtProblemName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRDEngineer As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPersonLiable As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtProblemDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLongCountermeasure As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTempCountermeasure As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents selStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbIsOtherNG As System.Windows.Forms.CheckBox
    Friend WithEvents cbIsMouldNG As System.Windows.Forms.CheckBox
    Friend WithEvents cbIsCraftNG As System.Windows.Forms.CheckBox
    Friend WithEvents cbIsMaterialNG As System.Windows.Forms.CheckBox
    Friend WithEvents cbIsDrawingNG As System.Windows.Forms.CheckBox
    Friend WithEvents txtEndTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtStartTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTrackingSummary As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dgvSampleProblem As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbAcount As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtE_SampleTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtS_SampleTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents toolExprot As System.Windows.Forms.ToolStripButton
    Friend WithEvents ChkZhiYang As System.Windows.Forms.CheckBox
    Friend WithEvents ChkKaiShi As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbSatus As System.Windows.Forms.ComboBox
    Friend WithEvents ProblemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UrgentState As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RDEngineer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SampleTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SampleQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NGQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NGRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProblemDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsDrawingNG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsMaterialNG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsCraftNG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsMouldNG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsOtherNG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PersonLiable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TempCountermeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LongCountermeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrackingSummary As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColExpFinishTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActFinishTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FilePath As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProblemNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDutyEmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBossEmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBossEmailDept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBossEmailDeptChief As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BeOverdueNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selStage As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
