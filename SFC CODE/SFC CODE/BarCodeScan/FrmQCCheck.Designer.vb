<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQCCheck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmQCCheck))
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtMinFunQty = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lbNoJudge = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbCheckCount = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbFuncQCRatio = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbCheckLevel = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtQCQty = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMoQty = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPartNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMoid = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbCid = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbMsg = New System.Windows.Forms.Label()
        Me.cbbBigTestItem = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPcsResult = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnPcsNg = New System.Windows.Forms.Button()
        Me.btnPcsOk = New System.Windows.Forms.Button()
        Me.cbbCheckType = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dgvAQL = New System.Windows.Forms.DataGridView()
        Me.Samplingname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConfigQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConfigUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MA_RejectQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MI_RejectQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CR_RejectQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lbFuncQty = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnListCheck = New System.Windows.Forms.Button()
        Me.lbDefectQty = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtBarCode = New System.Windows.Forms.TextBox()
        Me.lbNgQty = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbOKQty = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvCheckDetail = New System.Windows.Forms.DataGridView()
        Me.Partid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TestitemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SmallName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Result = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CCName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.dgvCheckSN = New System.Windows.Forms.DataGridView()
        Me.ppid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAllOk = New System.Windows.Forms.Button()
        Me.btnAllNg = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lbMsgResult = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
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
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnRejection = New System.Windows.Forms.ToolStripButton()
        Me.btnNoCheck = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolBt.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvAQL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCheckDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCheckSN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btnNew, Me.ToolStripSeparator2, Me.btnRejection, Me.ToolStripSeparator3, Me.btnNoCheck, Me.ToolStripSeparator7, Me.btnSearch, Me.ToolStripSeparator4, Me.btnExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolBt.Size = New System.Drawing.Size(1845, 34)
        Me.ToolBt.TabIndex = 47
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 34)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 34)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 34)
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 34)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lbStatus)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.txtMinFunQty)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.txtUserName)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.lbNoJudge)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.lbCheckCount)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.lbFuncQCRatio)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.lbCheckLevel)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txtQCQty)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtMoQty)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtPartNo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtMoid)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lbCid)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 34)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1845, 160)
        Me.Panel1.TabIndex = 48
        '
        'lbStatus
        '
        Me.lbStatus.AutoSize = True
        Me.lbStatus.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lbStatus.Location = New System.Drawing.Point(1472, 16)
        Me.lbStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(0, 18)
        Me.lbStatus.TabIndex = 24
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(1398, 16)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(62, 18)
        Me.Label22.TabIndex = 23
        Me.Label22.Text = "状态："
        '
        'txtMinFunQty
        '
        Me.txtMinFunQty.Enabled = False
        Me.txtMinFunQty.Location = New System.Drawing.Point(828, 54)
        Me.txtMinFunQty.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMinFunQty.Name = "txtMinFunQty"
        Me.txtMinFunQty.Size = New System.Drawing.Size(208, 28)
        Me.txtMinFunQty.TabIndex = 22
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(690, 58)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(152, 18)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "功能最小检验数："
        '
        'txtUserName
        '
        Me.txtUserName.Enabled = False
        Me.txtUserName.Location = New System.Drawing.Point(828, 105)
        Me.txtUserName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(208, 28)
        Me.txtUserName.TabIndex = 20
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(699, 110)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(98, 18)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "检验人员："
        '
        'lbNoJudge
        '
        Me.lbNoJudge.AutoSize = True
        Me.lbNoJudge.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lbNoJudge.Location = New System.Drawing.Point(1300, 16)
        Me.lbNoJudge.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbNoJudge.Name = "lbNoJudge"
        Me.lbNoJudge.Size = New System.Drawing.Size(35, 18)
        Me.lbNoJudge.TabIndex = 18
        Me.lbNoJudge.Text = "N/A"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(1194, 16)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 18)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "待判定数："
        '
        'lbCheckCount
        '
        Me.lbCheckCount.AutoSize = True
        Me.lbCheckCount.ForeColor = System.Drawing.Color.Green
        Me.lbCheckCount.Location = New System.Drawing.Point(1050, 16)
        Me.lbCheckCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCheckCount.Name = "lbCheckCount"
        Me.lbCheckCount.Size = New System.Drawing.Size(35, 18)
        Me.lbCheckCount.TabIndex = 16
        Me.lbCheckCount.Text = "N/A"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(966, 16)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 18)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "已验数："
        '
        'lbFuncQCRatio
        '
        Me.lbFuncQCRatio.AutoSize = True
        Me.lbFuncQCRatio.ForeColor = System.Drawing.Color.Yellow
        Me.lbFuncQCRatio.Location = New System.Drawing.Point(825, 16)
        Me.lbFuncQCRatio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbFuncQCRatio.Name = "lbFuncQCRatio"
        Me.lbFuncQCRatio.Size = New System.Drawing.Size(35, 18)
        Me.lbFuncQCRatio.TabIndex = 13
        Me.lbFuncQCRatio.Text = "N/A"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(686, 16)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(134, 18)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "功能检验比例："
        '
        'lbCheckLevel
        '
        Me.lbCheckLevel.AutoSize = True
        Me.lbCheckLevel.Location = New System.Drawing.Point(465, 16)
        Me.lbCheckLevel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCheckLevel.Name = "lbCheckLevel"
        Me.lbCheckLevel.Size = New System.Drawing.Size(44, 18)
        Me.lbCheckLevel.TabIndex = 11
        Me.lbCheckLevel.Text = "正常"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(358, 16)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(98, 18)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "检验程度："
        '
        'txtQCQty
        '
        Me.txtQCQty.Enabled = False
        Me.txtQCQty.Location = New System.Drawing.Point(465, 105)
        Me.txtQCQty.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQCQty.Name = "txtQCQty"
        Me.txtQCQty.Size = New System.Drawing.Size(208, 28)
        Me.txtQCQty.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(358, 110)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 18)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "本批检验数："
        '
        'txtMoQty
        '
        Me.txtMoQty.Enabled = False
        Me.txtMoQty.Location = New System.Drawing.Point(465, 54)
        Me.txtMoQty.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMoQty.Name = "txtMoQty"
        Me.txtMoQty.Size = New System.Drawing.Size(208, 28)
        Me.txtMoQty.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(358, 54)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 18)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "工单数量："
        '
        'txtPartNo
        '
        Me.txtPartNo.Enabled = False
        Me.txtPartNo.Location = New System.Drawing.Point(124, 105)
        Me.txtPartNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPartNo.Name = "txtPartNo"
        Me.txtPartNo.Size = New System.Drawing.Size(208, 28)
        Me.txtPartNo.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 105)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 18)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "料号："
        '
        'txtMoid
        '
        Me.txtMoid.Enabled = False
        Me.txtMoid.Location = New System.Drawing.Point(124, 50)
        Me.txtMoid.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMoid.Name = "txtMoid"
        Me.txtMoid.Size = New System.Drawing.Size(208, 28)
        Me.txtMoid.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 54)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "工单："
        '
        'lbCid
        '
        Me.lbCid.AutoSize = True
        Me.lbCid.ForeColor = System.Drawing.Color.Blue
        Me.lbCid.Location = New System.Drawing.Point(124, 16)
        Me.lbCid.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCid.Name = "lbCid"
        Me.lbCid.Size = New System.Drawing.Size(35, 18)
        Me.lbCid.TabIndex = 1
        Me.lbCid.Text = "N/A"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "检验批号："
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lbMsg)
        Me.Panel2.Controls.Add(Me.cbbBigTestItem)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtPcsResult)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.btnPcsNg)
        Me.Panel2.Controls.Add(Me.btnPcsOk)
        Me.Panel2.Controls.Add(Me.cbbCheckType)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 194)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1845, 50)
        Me.Panel2.TabIndex = 49
        '
        'lbMsg
        '
        Me.lbMsg.AutoSize = True
        Me.lbMsg.ForeColor = System.Drawing.Color.Blue
        Me.lbMsg.Location = New System.Drawing.Point(1166, 15)
        Me.lbMsg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbMsg.Name = "lbMsg"
        Me.lbMsg.Size = New System.Drawing.Size(0, 18)
        Me.lbMsg.TabIndex = 10
        '
        'cbbBigTestItem
        '
        Me.cbbBigTestItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbBigTestItem.FormattingEnabled = True
        Me.cbbBigTestItem.Location = New System.Drawing.Point(465, 9)
        Me.cbbBigTestItem.Margin = New System.Windows.Forms.Padding(4)
        Me.cbbBigTestItem.Name = "cbbBigTestItem"
        Me.cbbBigTestItem.Size = New System.Drawing.Size(208, 26)
        Me.cbbBigTestItem.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(358, 15)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 18)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "测试大项："
        '
        'txtPcsResult
        '
        Me.txtPcsResult.Enabled = False
        Me.txtPcsResult.ForeColor = System.Drawing.Color.Blue
        Me.txtPcsResult.Location = New System.Drawing.Point(1046, 9)
        Me.txtPcsResult.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPcsResult.Name = "txtPcsResult"
        Me.txtPcsResult.Size = New System.Drawing.Size(92, 28)
        Me.txtPcsResult.TabIndex = 9
        Me.txtPcsResult.Text = "N/A"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(957, 15)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 18)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "检验结果："
        '
        'btnPcsNg
        '
        Me.btnPcsNg.Enabled = False
        Me.btnPcsNg.ForeColor = System.Drawing.Color.DarkOrange
        Me.btnPcsNg.Location = New System.Drawing.Point(824, 6)
        Me.btnPcsNg.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPcsNg.Name = "btnPcsNg"
        Me.btnPcsNg.Size = New System.Drawing.Size(112, 34)
        Me.btnPcsNg.TabIndex = 7
        Me.btnPcsNg.Text = "拒收"
        Me.btnPcsNg.UseVisualStyleBackColor = True
        '
        'btnPcsOk
        '
        Me.btnPcsOk.Enabled = False
        Me.btnPcsOk.ForeColor = System.Drawing.Color.Green
        Me.btnPcsOk.Location = New System.Drawing.Point(702, 8)
        Me.btnPcsOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPcsOk.Name = "btnPcsOk"
        Me.btnPcsOk.Size = New System.Drawing.Size(112, 34)
        Me.btnPcsOk.TabIndex = 6
        Me.btnPcsOk.Text = "允收"
        Me.btnPcsOk.UseVisualStyleBackColor = True
        '
        'cbbCheckType
        '
        Me.cbbCheckType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbCheckType.FormattingEnabled = True
        Me.cbbCheckType.Location = New System.Drawing.Point(124, 8)
        Me.cbbCheckType.Margin = New System.Windows.Forms.Padding(4)
        Me.cbbCheckType.Name = "cbbCheckType"
        Me.cbbCheckType.Size = New System.Drawing.Size(208, 26)
        Me.cbbCheckType.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 12)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 18)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "检验类型："
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.dgvAQL)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 244)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1845, 100)
        Me.Panel3.TabIndex = 50
        '
        'dgvAQL
        '
        Me.dgvAQL.AllowUserToAddRows = False
        Me.dgvAQL.AllowUserToDeleteRows = False
        Me.dgvAQL.BackgroundColor = System.Drawing.Color.White
        Me.dgvAQL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAQL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Samplingname, Me.ConfigQty, Me.ConfigUnit, Me.MA_RejectQty, Me.MI_RejectQty, Me.CR_RejectQty})
        Me.dgvAQL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAQL.Location = New System.Drawing.Point(0, 0)
        Me.dgvAQL.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvAQL.Name = "dgvAQL"
        Me.dgvAQL.RowHeadersVisible = False
        Me.dgvAQL.RowTemplate.Height = 23
        Me.dgvAQL.Size = New System.Drawing.Size(1845, 100)
        Me.dgvAQL.TabIndex = 0
        '
        'Samplingname
        '
        Me.Samplingname.DataPropertyName = "Samplingname"
        Me.Samplingname.HeaderText = "抽验计划"
        Me.Samplingname.Name = "Samplingname"
        '
        'ConfigQty
        '
        Me.ConfigQty.DataPropertyName = "ConfigQty"
        Me.ConfigQty.HeaderText = "配置数"
        Me.ConfigQty.Name = "ConfigQty"
        '
        'ConfigUnit
        '
        Me.ConfigUnit.DataPropertyName = "ConfigUnit"
        Me.ConfigUnit.HeaderText = "单位"
        Me.ConfigUnit.Name = "ConfigUnit"
        '
        'MA_RejectQty
        '
        Me.MA_RejectQty.DataPropertyName = "MA_RejectQty"
        Me.MA_RejectQty.HeaderText = "主缺批退标准"
        Me.MA_RejectQty.Name = "MA_RejectQty"
        Me.MA_RejectQty.Width = 150
        '
        'MI_RejectQty
        '
        Me.MI_RejectQty.DataPropertyName = "MI_RejectQty"
        Me.MI_RejectQty.HeaderText = "次缺批退标准"
        Me.MI_RejectQty.Name = "MI_RejectQty"
        Me.MI_RejectQty.Width = 150
        '
        'CR_RejectQty
        '
        Me.CR_RejectQty.DataPropertyName = "CR_RejectQty"
        Me.CR_RejectQty.HeaderText = "重缺批退标准"
        Me.CR_RejectQty.Name = "CR_RejectQty"
        Me.CR_RejectQty.Width = 150
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.lbFuncQty)
        Me.Panel4.Controls.Add(Me.Label21)
        Me.Panel4.Controls.Add(Me.btnListCheck)
        Me.Panel4.Controls.Add(Me.lbDefectQty)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.txtBarCode)
        Me.Panel4.Controls.Add(Me.lbNgQty)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.lbOKQty)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 344)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1845, 59)
        Me.Panel4.TabIndex = 51
        '
        'lbFuncQty
        '
        Me.lbFuncQty.AutoSize = True
        Me.lbFuncQty.ForeColor = System.Drawing.Color.IndianRed
        Me.lbFuncQty.Location = New System.Drawing.Point(1334, 24)
        Me.lbFuncQty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbFuncQty.Name = "lbFuncQty"
        Me.lbFuncQty.Size = New System.Drawing.Size(17, 18)
        Me.lbFuncQty.TabIndex = 26
        Me.lbFuncQty.Text = "0"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(1191, 24)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(134, 18)
        Me.Label21.TabIndex = 25
        Me.Label21.Text = "功能待检验数："
        '
        'btnListCheck
        '
        Me.btnListCheck.Location = New System.Drawing.Point(369, 15)
        Me.btnListCheck.Margin = New System.Windows.Forms.Padding(4)
        Me.btnListCheck.Name = "btnListCheck"
        Me.btnListCheck.Size = New System.Drawing.Size(156, 34)
        Me.btnListCheck.TabIndex = 8
        Me.btnListCheck.Text = "外观批量检验"
        Me.btnListCheck.UseVisualStyleBackColor = True
        '
        'lbDefectQty
        '
        Me.lbDefectQty.AutoSize = True
        Me.lbDefectQty.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbDefectQty.ForeColor = System.Drawing.Color.Blue
        Me.lbDefectQty.Location = New System.Drawing.Point(1044, 20)
        Me.lbDefectQty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbDefectQty.Name = "lbDefectQty"
        Me.lbDefectQty.Size = New System.Drawing.Size(70, 24)
        Me.lbDefectQty.TabIndex = 7
        Me.lbDefectQty.Text = "0/0/0"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(888, 22)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(152, 18)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "主缺/次缺/重缺："
        '
        'txtBarCode
        '
        Me.txtBarCode.Location = New System.Drawing.Point(124, 18)
        Me.txtBarCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBarCode.Name = "txtBarCode"
        Me.txtBarCode.Size = New System.Drawing.Size(216, 28)
        Me.txtBarCode.TabIndex = 2
        '
        'lbNgQty
        '
        Me.lbNgQty.AutoSize = True
        Me.lbNgQty.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbNgQty.ForeColor = System.Drawing.Color.Red
        Me.lbNgQty.Location = New System.Drawing.Point(813, 20)
        Me.lbNgQty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbNgQty.Name = "lbNgQty"
        Me.lbNgQty.Size = New System.Drawing.Size(22, 24)
        Me.lbNgQty.TabIndex = 5
        Me.lbNgQty.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 22)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 18)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "产品条码："
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(724, 22)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 18)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "不良数："
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(574, 22)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 18)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "良品数："
        '
        'lbOKQty
        '
        Me.lbOKQty.AutoSize = True
        Me.lbOKQty.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbOKQty.ForeColor = System.Drawing.Color.Blue
        Me.lbOKQty.Location = New System.Drawing.Point(663, 20)
        Me.lbOKQty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbOKQty.Name = "lbOKQty"
        Me.lbOKQty.Size = New System.Drawing.Size(22, 24)
        Me.lbOKQty.TabIndex = 3
        Me.lbOKQty.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvCheckDetail)
        Me.GroupBox1.Controls.Add(Me.Splitter1)
        Me.GroupBox1.Controls.Add(Me.dgvCheckSN)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 403)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1845, 346)
        Me.GroupBox1.TabIndex = 52
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "检验序号明细"
        '
        'dgvCheckDetail
        '
        Me.dgvCheckDetail.AllowUserToAddRows = False
        Me.dgvCheckDetail.AllowUserToDeleteRows = False
        Me.dgvCheckDetail.BackgroundColor = System.Drawing.Color.White
        Me.dgvCheckDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCheckDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Partid, Me.SN, Me.TypeName, Me.TestitemName, Me.SmallName, Me.CheckStatus, Me.Result, Me.CCName, Me.CLevel})
        Me.dgvCheckDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCheckDetail.Location = New System.Drawing.Point(712, 25)
        Me.dgvCheckDetail.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvCheckDetail.Name = "dgvCheckDetail"
        Me.dgvCheckDetail.ReadOnly = True
        Me.dgvCheckDetail.RowHeadersVisible = False
        Me.dgvCheckDetail.RowTemplate.Height = 23
        Me.dgvCheckDetail.Size = New System.Drawing.Size(1129, 317)
        Me.dgvCheckDetail.TabIndex = 1
        '
        'Partid
        '
        Me.Partid.DataPropertyName = "Partid"
        Me.Partid.HeaderText = "料号编码"
        Me.Partid.Name = "Partid"
        Me.Partid.ReadOnly = True
        '
        'SN
        '
        Me.SN.DataPropertyName = "SN"
        Me.SN.HeaderText = "产品条码"
        Me.SN.Name = "SN"
        Me.SN.ReadOnly = True
        Me.SN.Width = 150
        '
        'TypeName
        '
        Me.TypeName.DataPropertyName = "TypeName"
        Me.TypeName.HeaderText = "检验类型"
        Me.TypeName.Name = "TypeName"
        Me.TypeName.ReadOnly = True
        '
        'TestitemName
        '
        Me.TestitemName.DataPropertyName = "TestitemName"
        Me.TestitemName.HeaderText = "检验大项"
        Me.TestitemName.Name = "TestitemName"
        Me.TestitemName.ReadOnly = True
        '
        'SmallName
        '
        Me.SmallName.DataPropertyName = "SmallName"
        Me.SmallName.HeaderText = "检验小项"
        Me.SmallName.Name = "SmallName"
        Me.SmallName.ReadOnly = True
        '
        'CheckStatus
        '
        Me.CheckStatus.DataPropertyName = "CheckStatus"
        Me.CheckStatus.HeaderText = "状态"
        Me.CheckStatus.Name = "CheckStatus"
        Me.CheckStatus.ReadOnly = True
        '
        'Result
        '
        Me.Result.DataPropertyName = "Result"
        Me.Result.HeaderText = "检验结果"
        Me.Result.Name = "Result"
        Me.Result.ReadOnly = True
        '
        'CCName
        '
        Me.CCName.DataPropertyName = "CCName"
        Me.CCName.HeaderText = "不良现象"
        Me.CCName.Name = "CCName"
        Me.CCName.ReadOnly = True
        '
        'CLevel
        '
        Me.CLevel.DataPropertyName = "CLevel"
        Me.CLevel.HeaderText = "缺陷等级"
        Me.CLevel.Name = "CLevel"
        Me.CLevel.ReadOnly = True
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(708, 25)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(4)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(4, 317)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        '
        'dgvCheckSN
        '
        Me.dgvCheckSN.AllowUserToAddRows = False
        Me.dgvCheckSN.AllowUserToDeleteRows = False
        Me.dgvCheckSN.BackgroundColor = System.Drawing.Color.White
        Me.dgvCheckSN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCheckSN.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ppid, Me.wg, Me.gn, Me.Column2})
        Me.dgvCheckSN.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgvCheckSN.Location = New System.Drawing.Point(4, 25)
        Me.dgvCheckSN.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvCheckSN.Name = "dgvCheckSN"
        Me.dgvCheckSN.ReadOnly = True
        Me.dgvCheckSN.RowTemplate.Height = 23
        Me.dgvCheckSN.Size = New System.Drawing.Size(704, 317)
        Me.dgvCheckSN.TabIndex = 0
        '
        'ppid
        '
        Me.ppid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ppid.DataPropertyName = "Ppid"
        Me.ppid.HeaderText = "产品条码"
        Me.ppid.Name = "ppid"
        Me.ppid.ReadOnly = True
        '
        'wg
        '
        Me.wg.DataPropertyName = "WG"
        Me.wg.HeaderText = "外观是否检验"
        Me.wg.Name = "wg"
        Me.wg.ReadOnly = True
        '
        'gn
        '
        Me.gn.DataPropertyName = "GN"
        Me.gn.HeaderText = "功能是否检验"
        Me.gn.Name = "gn"
        Me.gn.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "JudgeStatus"
        Me.Column2.HeaderText = "判定状况"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 80
        '
        'btnAllOk
        '
        Me.btnAllOk.Enabled = False
        Me.btnAllOk.ForeColor = System.Drawing.Color.Green
        Me.btnAllOk.Location = New System.Drawing.Point(176, 9)
        Me.btnAllOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAllOk.Name = "btnAllOk"
        Me.btnAllOk.Size = New System.Drawing.Size(112, 34)
        Me.btnAllOk.TabIndex = 0
        Me.btnAllOk.Text = "允收"
        Me.btnAllOk.UseVisualStyleBackColor = True
        '
        'btnAllNg
        '
        Me.btnAllNg.Enabled = False
        Me.btnAllNg.ForeColor = System.Drawing.Color.DarkOrange
        Me.btnAllNg.Location = New System.Drawing.Point(326, 9)
        Me.btnAllNg.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAllNg.Name = "btnAllNg"
        Me.btnAllNg.Size = New System.Drawing.Size(112, 34)
        Me.btnAllNg.TabIndex = 1
        Me.btnAllNg.Text = "批退"
        Me.btnAllNg.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lbMsgResult)
        Me.Panel5.Controls.Add(Me.Label12)
        Me.Panel5.Controls.Add(Me.btnAllNg)
        Me.Panel5.Controls.Add(Me.btnAllOk)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 749)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1845, 52)
        Me.Panel5.TabIndex = 53
        '
        'lbMsgResult
        '
        Me.lbMsgResult.AutoSize = True
        Me.lbMsgResult.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbMsgResult.ForeColor = System.Drawing.Color.Blue
        Me.lbMsgResult.Location = New System.Drawing.Point(519, 16)
        Me.lbMsgResult.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbMsgResult.Name = "lbMsgResult"
        Me.lbMsgResult.Size = New System.Drawing.Size(0, 18)
        Me.lbMsgResult.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(20, 16)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 18)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "综合判定："
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Samplingname"
        Me.DataGridViewTextBoxColumn1.HeaderText = "抽验计划"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ConfigQty"
        Me.DataGridViewTextBoxColumn2.HeaderText = "配置数"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "ConfigUnit"
        Me.DataGridViewTextBoxColumn3.HeaderText = "单位"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "MA_RejectQty"
        Me.DataGridViewTextBoxColumn4.HeaderText = "主缺批退标准"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "MI_RejectQty"
        Me.DataGridViewTextBoxColumn5.HeaderText = "次缺批退标准"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 150
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "CR_RejectQty"
        Me.DataGridViewTextBoxColumn6.HeaderText = "重缺批退标准"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 150
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Partid"
        Me.DataGridViewTextBoxColumn7.HeaderText = "料号编码"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "SN"
        Me.DataGridViewTextBoxColumn8.HeaderText = "产品条码"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 150
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "TypeName"
        Me.DataGridViewTextBoxColumn9.HeaderText = "检验类型"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "TestitemName"
        Me.DataGridViewTextBoxColumn10.HeaderText = "检验大项"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "SmallName"
        Me.DataGridViewTextBoxColumn11.HeaderText = "检验小项"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "CheckStatus"
        Me.DataGridViewTextBoxColumn12.HeaderText = "状态"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "Result"
        Me.DataGridViewTextBoxColumn13.HeaderText = "检验结果"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "Ppid"
        Me.DataGridViewTextBoxColumn14.HeaderText = "产品条码"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "WG"
        Me.DataGridViewTextBoxColumn15.HeaderText = "外观是否检验"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "GN"
        Me.DataGridViewTextBoxColumn16.HeaderText = "功能是否检验"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "JudgeStatus"
        Me.DataGridViewTextBoxColumn17.HeaderText = "判定状况"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Width = 80
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.HeaderText = "操作"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.Width = 60
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 34)
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(129, 31)
        Me.btnNew.Tag = "新增批号"
        Me.btnNew.Text = "新增批号(&N)"
        Me.btnNew.ToolTipText = "新增批号"
        '
        'btnRejection
        '
        Me.btnRejection.Image = CType(resources.GetObject("btnRejection.Image"), System.Drawing.Image)
        Me.btnRejection.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRejection.Name = "btnRejection"
        Me.btnRejection.Size = New System.Drawing.Size(84, 31)
        Me.btnRejection.Tag = "NO"
        Me.btnRejection.Text = "拒收区"
        '
        'btnNoCheck
        '
        Me.btnNoCheck.Image = CType(resources.GetObject("btnNoCheck.Image"), System.Drawing.Image)
        Me.btnNoCheck.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNoCheck.Name = "btnNoCheck"
        Me.btnNoCheck.Size = New System.Drawing.Size(84, 31)
        Me.btnNoCheck.Text = "待检品"
        '
        'btnSearch
        '
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(93, 31)
        Me.btnSearch.Text = "查 找(&F)"
        Me.btnSearch.ToolTipText = "查找"
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.White
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(95, 31)
        Me.btnExit.Text = "退 出(&X)"
        Me.btnExit.ToolTipText = "退出"
        '
        'FrmQCCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1845, 801)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolBt)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmQCCheck"
        Me.Text = "品质抽检"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgvAQL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvCheckDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCheckSN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbCid As System.Windows.Forms.Label
    Friend WithEvents txtMoQty As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPartNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMoid As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtQCQty As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbbCheckType As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPcsResult As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnPcsNg As System.Windows.Forms.Button
    Friend WithEvents btnPcsOk As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents dgvAQL As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txtBarCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCheckSN As System.Windows.Forms.DataGridView
    Friend WithEvents btnAllNg As System.Windows.Forms.Button
    Friend WithEvents btnAllOk As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lbDefectQty As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lbNgQty As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbOKQty As System.Windows.Forms.Label
    Friend WithEvents btnRejection As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbCheckLevel As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lbFuncQCRatio As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbbBigTestItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbMsg As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents dgvCheckDetail As System.Windows.Forms.DataGridView
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lbMsgResult As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbCheckCount As System.Windows.Forms.Label
    Friend WithEvents lbNoJudge As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Samplingname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConfigQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConfigUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MA_RejectQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MI_RejectQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CR_RejectQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtMinFunQty As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnListCheck As System.Windows.Forms.Button
    Friend WithEvents lbFuncQty As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
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
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbStatus As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Partid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypeName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TestitemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SmallName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Result As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CCName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ppid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnNoCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
End Class
