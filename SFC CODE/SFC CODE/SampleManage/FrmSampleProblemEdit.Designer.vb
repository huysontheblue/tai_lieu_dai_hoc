<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSampleProblemEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSampleProblemEdit))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.selStage = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.rdoBtnN = New System.Windows.Forms.RadioButton()
        Me.rdoBtnY = New System.Windows.Forms.RadioButton()
        Me.btnSelDuty = New System.Windows.Forms.Button()
        Me.txtActFinishTime = New System.Windows.Forms.TextBox()
        Me.btnViewFile = New System.Windows.Forms.Button()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.txtProblemNo = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.selStatus = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtLongCountermeasure = New System.Windows.Forms.RichTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.btnUpdata = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTrackingSummary = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtExpFinishTime = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtStartTime = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPersonLiable = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTempCountermeasure = New System.Windows.Forms.RichTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtProblemDesc = New System.Windows.Forms.RichTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbIsOtherNG = New System.Windows.Forms.CheckBox()
        Me.cbIsMouldNG = New System.Windows.Forms.CheckBox()
        Me.cbIsCraftNG = New System.Windows.Forms.CheckBox()
        Me.cbIsMaterialNG = New System.Windows.Forms.CheckBox()
        Me.cbIsDrawingNG = New System.Windows.Forms.CheckBox()
        Me.txtNGRate = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNGQty = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSampleQty = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSampleTime = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRDEngineer = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProblemName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1.SuspendLayout()
        Me.ToolBt.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.selStage)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.rdoBtnN)
        Me.Panel1.Controls.Add(Me.rdoBtnY)
        Me.Panel1.Controls.Add(Me.btnSelDuty)
        Me.Panel1.Controls.Add(Me.txtActFinishTime)
        Me.Panel1.Controls.Add(Me.btnViewFile)
        Me.Panel1.Controls.Add(Me.lblMsg)
        Me.Panel1.Controls.Add(Me.txtProblemNo)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.selStatus)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.txtLongCountermeasure)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtFilePath)
        Me.Panel1.Controls.Add(Me.btnUpdata)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtTrackingSummary)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtExpFinishTime)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txtStartTime)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtPersonLiable)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtTempCountermeasure)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtProblemDesc)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.cbIsOtherNG)
        Me.Panel1.Controls.Add(Me.cbIsMouldNG)
        Me.Panel1.Controls.Add(Me.cbIsCraftNG)
        Me.Panel1.Controls.Add(Me.cbIsMaterialNG)
        Me.Panel1.Controls.Add(Me.cbIsDrawingNG)
        Me.Panel1.Controls.Add(Me.txtNGRate)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtNGQty)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtSampleQty)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtSampleTime)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtRDEngineer)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtProblemName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(837, 515)
        Me.Panel1.TabIndex = 48
        '
        'selStage
        '
        Me.selStage.FormattingEnabled = True
        Me.selStage.Location = New System.Drawing.Point(688, 420)
        Me.selStage.Name = "selStage"
        Me.selStage.Size = New System.Drawing.Size(134, 20)
        Me.selStage.TabIndex = 156
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(629, 423)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 12)
        Me.Label19.TabIndex = 155
        Me.Label19.Text = "发生阶段"
        '
        'rdoBtnN
        '
        Me.rdoBtnN.AutoSize = True
        Me.rdoBtnN.Checked = True
        Me.rdoBtnN.Location = New System.Drawing.Point(776, 93)
        Me.rdoBtnN.Name = "rdoBtnN"
        Me.rdoBtnN.Size = New System.Drawing.Size(59, 16)
        Me.rdoBtnN.TabIndex = 154
        Me.rdoBtnN.TabStop = True
        Me.rdoBtnN.Text = "一般件"
        Me.rdoBtnN.UseVisualStyleBackColor = True
        '
        'rdoBtnY
        '
        Me.rdoBtnY.AutoSize = True
        Me.rdoBtnY.Location = New System.Drawing.Point(721, 93)
        Me.rdoBtnY.Name = "rdoBtnY"
        Me.rdoBtnY.Size = New System.Drawing.Size(59, 16)
        Me.rdoBtnY.TabIndex = 153
        Me.rdoBtnY.Text = "加急件"
        Me.rdoBtnY.UseVisualStyleBackColor = True
        '
        'btnSelDuty
        '
        Me.btnSelDuty.Location = New System.Drawing.Point(344, 306)
        Me.btnSelDuty.Name = "btnSelDuty"
        Me.btnSelDuty.Size = New System.Drawing.Size(71, 23)
        Me.btnSelDuty.TabIndex = 152
        Me.btnSelDuty.Text = "选择"
        Me.btnSelDuty.UseVisualStyleBackColor = True
        '
        'txtActFinishTime
        '
        Me.txtActFinishTime.Location = New System.Drawing.Point(688, 345)
        Me.txtActFinishTime.Name = "txtActFinishTime"
        Me.txtActFinishTime.ReadOnly = True
        Me.txtActFinishTime.Size = New System.Drawing.Size(134, 21)
        Me.txtActFinishTime.TabIndex = 151
        '
        'btnViewFile
        '
        Me.btnViewFile.Location = New System.Drawing.Point(784, 306)
        Me.btnViewFile.Name = "btnViewFile"
        Me.btnViewFile.Size = New System.Drawing.Size(38, 23)
        Me.btnViewFile.TabIndex = 150
        Me.btnViewFile.Text = "预览"
        Me.btnViewFile.UseVisualStyleBackColor = True
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(20, 493)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(0, 12)
        Me.lblMsg.TabIndex = 149
        '
        'txtProblemNo
        '
        Me.txtProblemNo.Location = New System.Drawing.Point(722, 16)
        Me.txtProblemNo.Name = "txtProblemNo"
        Me.txtProblemNo.ReadOnly = True
        Me.txtProblemNo.Size = New System.Drawing.Size(100, 21)
        Me.txtProblemNo.TabIndex = 148
        Me.txtProblemNo.Text = "..."
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(651, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 12)
        Me.Label18.TabIndex = 147
        Me.Label18.Text = "问题单号"
        '
        'selStatus
        '
        Me.selStatus.FormattingEnabled = True
        Me.selStatus.Location = New System.Drawing.Point(688, 385)
        Me.selStatus.Name = "selStatus"
        Me.selStatus.Size = New System.Drawing.Size(134, 20)
        Me.selStatus.TabIndex = 146
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(629, 388)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 12)
        Me.Label17.TabIndex = 145
        Me.Label17.Text = "追踪状态"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(605, 348)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(77, 12)
        Me.Label16.TabIndex = 143
        Me.Label16.Text = "实际完成日期"
        '
        'txtLongCountermeasure
        '
        Me.txtLongCountermeasure.Location = New System.Drawing.Point(83, 423)
        Me.txtLongCountermeasure.Name = "txtLongCountermeasure"
        Me.txtLongCountermeasure.Size = New System.Drawing.Size(499, 67)
        Me.txtLongCountermeasure.TabIndex = 142
        Me.txtLongCountermeasure.Text = ""
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 423)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 12)
        Me.Label15.TabIndex = 141
        Me.Label15.Text = "长期对策"
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(521, 308)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.ReadOnly = True
        Me.txtFilePath.Size = New System.Drawing.Size(202, 21)
        Me.txtFilePath.TabIndex = 139
        '
        'btnUpdata
        '
        Me.btnUpdata.Location = New System.Drawing.Point(740, 306)
        Me.btnUpdata.Name = "btnUpdata"
        Me.btnUpdata.Size = New System.Drawing.Size(38, 23)
        Me.btnUpdata.TabIndex = 140
        Me.btnUpdata.Text = "上传"
        Me.btnUpdata.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(473, 311)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 12)
        Me.Label14.TabIndex = 138
        Me.Label14.Text = "附档"
        '
        'txtTrackingSummary
        '
        Me.txtTrackingSummary.Location = New System.Drawing.Point(83, 385)
        Me.txtTrackingSummary.Name = "txtTrackingSummary"
        Me.txtTrackingSummary.Size = New System.Drawing.Size(499, 21)
        Me.txtTrackingSummary.TabIndex = 31
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 388)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 12)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "追踪结论"
        '
        'txtExpFinishTime
        '
        Me.txtExpFinishTime.CustomFormat = " "
        Me.txtExpFinishTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtExpFinishTime.Location = New System.Drawing.Point(399, 346)
        Me.txtExpFinishTime.Name = "txtExpFinishTime"
        Me.txtExpFinishTime.Size = New System.Drawing.Size(183, 21)
        Me.txtExpFinishTime.TabIndex = 29
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(306, 351)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 12)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "预计完成日期"
        '
        'txtStartTime
        '
        Me.txtStartTime.CustomFormat = "yyyy-MM-dd"
        Me.txtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtStartTime.Location = New System.Drawing.Point(83, 346)
        Me.txtStartTime.Name = "txtStartTime"
        Me.txtStartTime.Size = New System.Drawing.Size(183, 21)
        Me.txtStartTime.TabIndex = 25
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 351)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 12)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "开始日期"
        '
        'txtPersonLiable
        '
        Me.txtPersonLiable.Location = New System.Drawing.Point(83, 308)
        Me.txtPersonLiable.Name = "txtPersonLiable"
        Me.txtPersonLiable.ReadOnly = True
        Me.txtPersonLiable.Size = New System.Drawing.Size(248, 21)
        Me.txtPersonLiable.TabIndex = 23
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 311)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 12)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "责任人"
        '
        'txtTempCountermeasure
        '
        Me.txtTempCountermeasure.Location = New System.Drawing.Point(83, 241)
        Me.txtTempCountermeasure.Name = "txtTempCountermeasure"
        Me.txtTempCountermeasure.Size = New System.Drawing.Size(739, 50)
        Me.txtTempCountermeasure.TabIndex = 21
        Me.txtTempCountermeasure.Text = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 244)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "临时对策"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(187, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 12)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "%"
        '
        'txtProblemDesc
        '
        Me.txtProblemDesc.Location = New System.Drawing.Point(83, 127)
        Me.txtProblemDesc.Name = "txtProblemDesc"
        Me.txtProblemDesc.Size = New System.Drawing.Size(739, 96)
        Me.txtProblemDesc.TabIndex = 18
        Me.txtProblemDesc.Text = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "问题描述"
        '
        'cbIsOtherNG
        '
        Me.cbIsOtherNG.AutoSize = True
        Me.cbIsOtherNG.Location = New System.Drawing.Point(651, 94)
        Me.cbIsOtherNG.Name = "cbIsOtherNG"
        Me.cbIsOtherNG.Size = New System.Drawing.Size(72, 16)
        Me.cbIsOtherNG.TabIndex = 16
        Me.cbIsOtherNG.Text = "其它问题"
        Me.cbIsOtherNG.UseVisualStyleBackColor = True
        '
        'cbIsMouldNG
        '
        Me.cbIsMouldNG.AutoSize = True
        Me.cbIsMouldNG.Location = New System.Drawing.Point(540, 94)
        Me.cbIsMouldNG.Name = "cbIsMouldNG"
        Me.cbIsMouldNG.Size = New System.Drawing.Size(84, 16)
        Me.cbIsMouldNG.TabIndex = 15
        Me.cbIsMouldNG.Text = "模治具问题"
        Me.cbIsMouldNG.UseVisualStyleBackColor = True
        '
        'cbIsCraftNG
        '
        Me.cbIsCraftNG.AutoSize = True
        Me.cbIsCraftNG.Location = New System.Drawing.Point(447, 95)
        Me.cbIsCraftNG.Name = "cbIsCraftNG"
        Me.cbIsCraftNG.Size = New System.Drawing.Size(72, 16)
        Me.cbIsCraftNG.TabIndex = 14
        Me.cbIsCraftNG.Text = "工艺问题"
        Me.cbIsCraftNG.UseVisualStyleBackColor = True
        '
        'cbIsMaterialNG
        '
        Me.cbIsMaterialNG.AutoSize = True
        Me.cbIsMaterialNG.Location = New System.Drawing.Point(349, 95)
        Me.cbIsMaterialNG.Name = "cbIsMaterialNG"
        Me.cbIsMaterialNG.Size = New System.Drawing.Size(72, 16)
        Me.cbIsMaterialNG.TabIndex = 13
        Me.cbIsMaterialNG.Text = "物料问题"
        Me.cbIsMaterialNG.UseVisualStyleBackColor = True
        '
        'cbIsDrawingNG
        '
        Me.cbIsDrawingNG.AutoSize = True
        Me.cbIsDrawingNG.Location = New System.Drawing.Point(215, 95)
        Me.cbIsDrawingNG.Name = "cbIsDrawingNG"
        Me.cbIsDrawingNG.Size = New System.Drawing.Size(102, 16)
        Me.cbIsDrawingNG.TabIndex = 12
        Me.cbIsDrawingNG.Text = "设计/图纸问题"
        Me.cbIsDrawingNG.UseVisualStyleBackColor = True
        '
        'txtNGRate
        '
        Me.txtNGRate.Location = New System.Drawing.Point(83, 92)
        Me.txtNGRate.Name = "txtNGRate"
        Me.txtNGRate.Size = New System.Drawing.Size(100, 21)
        Me.txtNGRate.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "不良率"
        '
        'txtNGQty
        '
        Me.txtNGQty.Location = New System.Drawing.Point(722, 55)
        Me.txtNGQty.Name = "txtNGQty"
        Me.txtNGQty.Size = New System.Drawing.Size(100, 21)
        Me.txtNGQty.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(651, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "不良数量"
        '
        'txtSampleQty
        '
        Me.txtSampleQty.Location = New System.Drawing.Point(504, 54)
        Me.txtSampleQty.Name = "txtSampleQty"
        Me.txtSampleQty.Size = New System.Drawing.Size(100, 21)
        Me.txtSampleQty.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(436, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "制样数量"
        '
        'txtSampleTime
        '
        Me.txtSampleTime.CustomFormat = "yyyy-MM-dd"
        Me.txtSampleTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtSampleTime.Location = New System.Drawing.Point(272, 54)
        Me.txtSampleTime.Name = "txtSampleTime"
        Me.txtSampleTime.Size = New System.Drawing.Size(111, 21)
        Me.txtSampleTime.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(213, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "制样日期"
        '
        'txtRDEngineer
        '
        Me.txtRDEngineer.Location = New System.Drawing.Point(83, 55)
        Me.txtRDEngineer.Name = "txtRDEngineer"
        Me.txtRDEngineer.Size = New System.Drawing.Size(100, 21)
        Me.txtRDEngineer.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "研发工程师"
        '
        'txtProblemName
        '
        Me.txtProblemName.Location = New System.Drawing.Point(83, 16)
        Me.txtProblemName.Name = "txtProblemName"
        Me.txtProblemName.Size = New System.Drawing.Size(521, 21)
        Me.txtProblemName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "RDN/品名"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(71, 20)
        Me.btnSave.Text = "保 存(&S)"
        Me.btnSave.ToolTipText = "保存"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.White
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 20)
        Me.btnExit.Text = "退 出(&X)"
        Me.btnExit.ToolTipText = "退出"
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.ToolStripSeparator3, Me.btnExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(837, 23)
        Me.ToolBt.TabIndex = 47
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "(*.*)|*.*"
        '
        'FrmSampleProblemEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 538)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmSampleProblemEdit"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "制程解析备忘库"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtProblemName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents txtNGQty As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSampleQty As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSampleTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRDEngineer As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNGRate As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbIsOtherNG As System.Windows.Forms.CheckBox
    Friend WithEvents cbIsMouldNG As System.Windows.Forms.CheckBox
    Friend WithEvents cbIsCraftNG As System.Windows.Forms.CheckBox
    Friend WithEvents cbIsMaterialNG As System.Windows.Forms.CheckBox
    Friend WithEvents cbIsDrawingNG As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtProblemDesc As System.Windows.Forms.RichTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtStartTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPersonLiable As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTempCountermeasure As System.Windows.Forms.RichTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTrackingSummary As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtExpFinishTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdata As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtLongCountermeasure As System.Windows.Forms.RichTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents selStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtProblemNo As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnViewFile As System.Windows.Forms.Button
    Friend WithEvents txtActFinishTime As System.Windows.Forms.TextBox
    Friend WithEvents btnSelDuty As System.Windows.Forms.Button
    Friend WithEvents rdoBtnY As System.Windows.Forms.RadioButton
    Friend WithEvents rdoBtnN As System.Windows.Forms.RadioButton
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents selStage As System.Windows.Forms.ComboBox
End Class
