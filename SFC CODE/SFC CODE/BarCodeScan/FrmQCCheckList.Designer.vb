<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQCCheckList
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbQCqty = New System.Windows.Forms.Label()
        Me.lbCheckedQty = New System.Windows.Forms.Label()
        Me.lbCheckType = New System.Windows.Forms.Label()
        Me.lbMoid = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbBigTypeId = New System.Windows.Forms.Label()
        Me.lbBigTestItem = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbPartNo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbCID = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbMsg = New System.Windows.Forms.Label()
        Me.rbFail = New System.Windows.Forms.RadioButton()
        Me.rbPass = New System.Windows.Forms.RadioButton()
        Me.txtBarCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.panTestItem = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.dgvCheckSN = New System.Windows.Forms.DataGridView()
        Me.rowindex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.tslMsg = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.row = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPpid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.panTestItem.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCheckSN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Snow
        Me.Panel1.Controls.Add(Me.lbQCqty)
        Me.Panel1.Controls.Add(Me.lbCheckedQty)
        Me.Panel1.Controls.Add(Me.lbCheckType)
        Me.Panel1.Controls.Add(Me.lbMoid)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lbBigTypeId)
        Me.Panel1.Controls.Add(Me.lbBigTestItem)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.lbPartNo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lbCID)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1476, 66)
        Me.Panel1.TabIndex = 0
        '
        'lbQCqty
        '
        Me.lbQCqty.AutoSize = True
        Me.lbQCqty.Location = New System.Drawing.Point(1353, 22)
        Me.lbQCqty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbQCqty.Name = "lbQCqty"
        Me.lbQCqty.Size = New System.Drawing.Size(17, 18)
        Me.lbQCqty.TabIndex = 11
        Me.lbQCqty.Text = "0"
        Me.lbQCqty.Visible = False
        '
        'lbCheckedQty
        '
        Me.lbCheckedQty.AutoSize = True
        Me.lbCheckedQty.Location = New System.Drawing.Point(1288, 22)
        Me.lbCheckedQty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCheckedQty.Name = "lbCheckedQty"
        Me.lbCheckedQty.Size = New System.Drawing.Size(17, 18)
        Me.lbCheckedQty.TabIndex = 10
        Me.lbCheckedQty.Text = "0"
        Me.lbCheckedQty.Visible = False
        '
        'lbCheckType
        '
        Me.lbCheckType.AutoSize = True
        Me.lbCheckType.Location = New System.Drawing.Point(1212, 22)
        Me.lbCheckType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCheckType.Name = "lbCheckType"
        Me.lbCheckType.Size = New System.Drawing.Size(35, 18)
        Me.lbCheckType.TabIndex = 9
        Me.lbCheckType.Text = "N/A"
        Me.lbCheckType.Visible = False
        '
        'lbMoid
        '
        Me.lbMoid.AutoSize = True
        Me.lbMoid.ForeColor = System.Drawing.Color.Blue
        Me.lbMoid.Location = New System.Drawing.Point(450, 22)
        Me.lbMoid.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbMoid.Name = "lbMoid"
        Me.lbMoid.Size = New System.Drawing.Size(35, 18)
        Me.lbMoid.TabIndex = 8
        Me.lbMoid.Text = "N/A"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(344, 22)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 18)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "工单编码："
        '
        'lbBigTypeId
        '
        Me.lbBigTypeId.AutoSize = True
        Me.lbBigTypeId.Location = New System.Drawing.Point(1126, 22)
        Me.lbBigTypeId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbBigTypeId.Name = "lbBigTypeId"
        Me.lbBigTypeId.Size = New System.Drawing.Size(35, 18)
        Me.lbBigTypeId.TabIndex = 6
        Me.lbBigTypeId.Text = "N/A"
        Me.lbBigTypeId.Visible = False
        '
        'lbBigTestItem
        '
        Me.lbBigTestItem.AutoSize = True
        Me.lbBigTestItem.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbBigTestItem.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbBigTestItem.Location = New System.Drawing.Point(1035, 22)
        Me.lbBigTestItem.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbBigTestItem.Name = "lbBigTestItem"
        Me.lbBigTestItem.Size = New System.Drawing.Size(38, 18)
        Me.lbBigTestItem.TabIndex = 5
        Me.lbBigTestItem.Text = "N/A"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(944, 22)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 18)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "测试大项："
        '
        'lbPartNo
        '
        Me.lbPartNo.AutoSize = True
        Me.lbPartNo.ForeColor = System.Drawing.Color.Blue
        Me.lbPartNo.Location = New System.Drawing.Point(765, 22)
        Me.lbPartNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbPartNo.Name = "lbPartNo"
        Me.lbPartNo.Size = New System.Drawing.Size(35, 18)
        Me.lbPartNo.TabIndex = 3
        Me.lbPartNo.Text = "N/A"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(658, 22)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 18)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "料号编码："
        '
        'lbCID
        '
        Me.lbCID.AutoSize = True
        Me.lbCID.ForeColor = System.Drawing.Color.Blue
        Me.lbCID.Location = New System.Drawing.Point(138, 22)
        Me.lbCID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCID.Name = "lbCID"
        Me.lbCID.Size = New System.Drawing.Size(35, 18)
        Me.lbCID.TabIndex = 1
        Me.lbCID.Text = "N/A"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(50, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "批次号："
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.lbMsg)
        Me.Panel2.Controls.Add(Me.rbFail)
        Me.Panel2.Controls.Add(Me.rbPass)
        Me.Panel2.Controls.Add(Me.txtBarCode)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 66)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1476, 46)
        Me.Panel2.TabIndex = 1
        '
        'lbMsg
        '
        Me.lbMsg.AutoSize = True
        Me.lbMsg.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbMsg.ForeColor = System.Drawing.Color.Red
        Me.lbMsg.Location = New System.Drawing.Point(657, 15)
        Me.lbMsg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbMsg.Name = "lbMsg"
        Me.lbMsg.Size = New System.Drawing.Size(0, 20)
        Me.lbMsg.TabIndex = 5
        '
        'rbFail
        '
        Me.rbFail.AutoSize = True
        Me.rbFail.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.rbFail.ForeColor = System.Drawing.Color.Red
        Me.rbFail.Location = New System.Drawing.Point(471, 12)
        Me.rbFail.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbFail.Name = "rbFail"
        Me.rbFail.Size = New System.Drawing.Size(73, 22)
        Me.rbFail.TabIndex = 4
        Me.rbFail.TabStop = True
        Me.rbFail.Text = "FAIL"
        Me.rbFail.UseVisualStyleBackColor = True
        '
        'rbPass
        '
        Me.rbPass.AutoSize = True
        Me.rbPass.Checked = True
        Me.rbPass.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.rbPass.ForeColor = System.Drawing.Color.Green
        Me.rbPass.Location = New System.Drawing.Point(368, 12)
        Me.rbPass.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbPass.Name = "rbPass"
        Me.rbPass.Size = New System.Drawing.Size(73, 22)
        Me.rbPass.TabIndex = 3
        Me.rbPass.TabStop = True
        Me.rbPass.Text = "PASS"
        Me.rbPass.UseVisualStyleBackColor = True
        '
        'txtBarCode
        '
        Me.txtBarCode.Location = New System.Drawing.Point(102, 9)
        Me.txtBarCode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBarCode.Name = "txtBarCode"
        Me.txtBarCode.Size = New System.Drawing.Size(242, 28)
        Me.txtBarCode.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 15)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 18)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "产品条码："
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.panTestItem)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 112)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1476, 576)
        Me.Panel3.TabIndex = 2
        '
        'panTestItem
        '
        Me.panTestItem.AutoScroll = True
        Me.panTestItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panTestItem.Controls.Add(Me.Label10)
        Me.panTestItem.Controls.Add(Me.Label9)
        Me.panTestItem.Controls.Add(Me.Label8)
        Me.panTestItem.Controls.Add(Me.Label11)
        Me.panTestItem.Controls.Add(Me.Label12)
        Me.panTestItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panTestItem.Location = New System.Drawing.Point(290, 0)
        Me.panTestItem.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panTestItem.Name = "panTestItem"
        Me.panTestItem.Size = New System.Drawing.Size(1186, 576)
        Me.panTestItem.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(1059, 18)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 18)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "结果判定"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(836, 18)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 18)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "上传图片"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(582, 18)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 18)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "测试值"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(290, 18)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 18)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "不良现象代码"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(27, 18)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 18)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "测试项目"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.SplitContainer1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(290, 576)
        Me.Panel5.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvList)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvCheckSN)
        Me.SplitContainer1.Size = New System.Drawing.Size(290, 576)
        Me.SplitContainer1.SplitterDistance = 200
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 1
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.BackgroundColor = System.Drawing.Color.White
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.row, Me.colPpid, Me.Column2})
        Me.dgvList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvList.Location = New System.Drawing.Point(0, 0)
        Me.dgvList.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.RowTemplate.Height = 23
        Me.dgvList.Size = New System.Drawing.Size(290, 200)
        Me.dgvList.TabIndex = 0
        '
        'dgvCheckSN
        '
        Me.dgvCheckSN.AllowUserToAddRows = False
        Me.dgvCheckSN.AllowUserToDeleteRows = False
        Me.dgvCheckSN.BackgroundColor = System.Drawing.Color.White
        Me.dgvCheckSN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCheckSN.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rowindex, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.dgvCheckSN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCheckSN.Location = New System.Drawing.Point(0, 0)
        Me.dgvCheckSN.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvCheckSN.Name = "dgvCheckSN"
        Me.dgvCheckSN.ReadOnly = True
        Me.dgvCheckSN.RowHeadersVisible = False
        Me.dgvCheckSN.RowTemplate.Height = 23
        Me.dgvCheckSN.Size = New System.Drawing.Size(290, 374)
        Me.dgvCheckSN.TabIndex = 1
        '
        'rowindex
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rowindex.DefaultCellStyle = DataGridViewCellStyle2
        Me.rowindex.HeaderText = ""
        Me.rowindex.Name = "rowindex"
        Me.rowindex.ReadOnly = True
        Me.rowindex.Width = 20
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn1.HeaderText = "已检验条码"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 120
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "JudgeStatus"
        Me.DataGridViewTextBoxColumn2.HeaderText = "判定状况"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.tslMsg)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 688)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1476, 58)
        Me.Panel4.TabIndex = 3
        '
        'tslMsg
        '
        Me.tslMsg.AutoSize = True
        Me.tslMsg.ForeColor = System.Drawing.Color.Blue
        Me.tslMsg.Location = New System.Drawing.Point(580, 26)
        Me.tslMsg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.tslMsg.Name = "tslMsg"
        Me.tslMsg.Size = New System.Drawing.Size(0, 18)
        Me.tslMsg.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(1110, 9)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(112, 34)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(966, 9)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(112, 34)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "保存(&S)"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "判定结果"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn4.HeaderText = ""
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 20
        '
        'DataGridViewTextBoxColumn5
        '
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn5.HeaderText = "已检验条码"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "JudgeStatus"
        Me.DataGridViewTextBoxColumn6.HeaderText = "判定状况"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 80
        '
        'row
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.row.DefaultCellStyle = DataGridViewCellStyle1
        Me.row.HeaderText = ""
        Me.row.Name = "row"
        Me.row.ReadOnly = True
        Me.row.Width = 20
        '
        'colPpid
        '
        Me.colPpid.HeaderText = "产品条码"
        Me.colPpid.Name = "colPpid"
        Me.colPpid.ReadOnly = True
        Me.colPpid.Width = 120
        '
        'Column2
        '
        Me.Column2.HeaderText = "判定结果"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 80
        '
        'FrmQCCheckList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1476, 746)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmQCCheckList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "批量检验"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.panTestItem.ResumeLayout(False)
        Me.panTestItem.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCheckSN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lbCID As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbPartNo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbBigTestItem As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBarCode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rbFail As System.Windows.Forms.RadioButton
    Friend WithEvents rbPass As System.Windows.Forms.RadioButton
    Friend WithEvents panTestItem As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents dgvList As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lbBigTypeId As System.Windows.Forms.Label
    Friend WithEvents lbMoid As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbCheckType As System.Windows.Forms.Label
    Friend WithEvents lbMsg As System.Windows.Forms.Label
    Friend WithEvents tslMsg As System.Windows.Forms.Label
    Friend WithEvents lbCheckedQty As System.Windows.Forms.Label
    Friend WithEvents lbQCqty As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvCheckSN As System.Windows.Forms.DataGridView
    Friend WithEvents rowindex As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents row As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPpid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
