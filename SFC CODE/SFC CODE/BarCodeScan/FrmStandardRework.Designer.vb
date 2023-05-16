<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStandardRework
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmStandardRework))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.dgvUnPackBox = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtLineId = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbMoid = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbPackQty = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbScanQty = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbUnPackBoxMessage = New System.Windows.Forms.Label()
        Me.lbUnPackBoxResult = New System.Windows.Forms.Label()
        Me.txtPackingBoxBarcode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPackingBoxCartonCode = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lbMsg = New System.Windows.Forms.Label()
        Me.btnUnboxing = New System.Windows.Forms.Button()
        Me.txtUnboxCartonCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnTranfer = New System.Windows.Forms.Button()
        Me.txtLine = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblMoid = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtOldHWAsn = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtNewHWAsn = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLXAsn = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblResult3 = New System.Windows.Forms.Label()
        Me.lblMessage3 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtHWASN2 = New System.Windows.Forms.TextBox()
        Me.txtLXASN2 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.dgvUnPackBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 25)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(942, 402)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel6)
        Me.TabPage1.Controls.Add(Me.Panel5)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(934, 376)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "重工拆装箱作业"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.dgvUnPackBox)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 62)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(934, 314)
        Me.Panel6.TabIndex = 1
        '
        'dgvUnPackBox
        '
        Me.dgvUnPackBox.AllowUserToAddRows = False
        Me.dgvUnPackBox.AllowUserToDeleteRows = False
        Me.dgvUnPackBox.BackgroundColor = System.Drawing.Color.White
        Me.dgvUnPackBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvUnPackBox.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvUnPackBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUnPackBox.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.Column1, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.dgvUnPackBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUnPackBox.Location = New System.Drawing.Point(0, 148)
        Me.dgvUnPackBox.Name = "dgvUnPackBox"
        Me.dgvUnPackBox.ReadOnly = True
        Me.dgvUnPackBox.RowHeadersWidth = 4
        Me.dgvUnPackBox.RowTemplate.Height = 23
        Me.dgvUnPackBox.Size = New System.Drawing.Size(934, 166)
        Me.dgvUnPackBox.TabIndex = 135
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "外箱条码"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 250
        '
        'Column1
        '
        Me.Column1.HeaderText = "产品条码"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 200
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "扫描人员"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "扫描时间"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 200
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.txtLineId)
        Me.Panel7.Controls.Add(Me.Label10)
        Me.Panel7.Controls.Add(Me.lbMoid)
        Me.Panel7.Controls.Add(Me.Label8)
        Me.Panel7.Controls.Add(Me.lbPackQty)
        Me.Panel7.Controls.Add(Me.Label9)
        Me.Panel7.Controls.Add(Me.lbScanQty)
        Me.Panel7.Controls.Add(Me.Label6)
        Me.Panel7.Controls.Add(Me.GroupBox2)
        Me.Panel7.Controls.Add(Me.txtPackingBoxBarcode)
        Me.Panel7.Controls.Add(Me.Label5)
        Me.Panel7.Controls.Add(Me.Label4)
        Me.Panel7.Controls.Add(Me.Label2)
        Me.Panel7.Controls.Add(Me.txtPackingBoxCartonCode)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(934, 148)
        Me.Panel7.TabIndex = 5
        '
        'txtLineId
        '
        Me.txtLineId.Location = New System.Drawing.Point(684, 122)
        Me.txtLineId.Name = "txtLineId"
        Me.txtLineId.Size = New System.Drawing.Size(64, 21)
        Me.txtLineId.TabIndex = 112
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(636, 127)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 12)
        Me.Label10.TabIndex = 111
        Me.Label10.Text = "线别："
        '
        'lbMoid
        '
        Me.lbMoid.AutoSize = True
        Me.lbMoid.Location = New System.Drawing.Point(483, 128)
        Me.lbMoid.Name = "lbMoid"
        Me.lbMoid.Size = New System.Drawing.Size(0, 12)
        Me.lbMoid.TabIndex = 110
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(422, 127)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 109
        Me.Label8.Text = "工单编号："
        '
        'lbPackQty
        '
        Me.lbPackQty.AutoSize = True
        Me.lbPackQty.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbPackQty.ForeColor = System.Drawing.Color.Red
        Me.lbPackQty.Location = New System.Drawing.Point(91, 121)
        Me.lbPackQty.Name = "lbPackQty"
        Me.lbPackQty.Size = New System.Drawing.Size(17, 16)
        Me.lbPackQty.TabIndex = 108
        Me.lbPackQty.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(31, 123)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 107
        Me.Label9.Text = "应装数量："
        '
        'lbScanQty
        '
        Me.lbScanQty.AutoSize = True
        Me.lbScanQty.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbScanQty.ForeColor = System.Drawing.Color.Green
        Me.lbScanQty.Location = New System.Drawing.Point(248, 123)
        Me.lbScanQty.Name = "lbScanQty"
        Me.lbScanQty.Size = New System.Drawing.Size(17, 16)
        Me.lbScanQty.TabIndex = 106
        Me.lbScanQty.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(187, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 105
        Me.Label6.Text = "已装数量："
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.lbUnPackBoxMessage)
        Me.GroupBox2.Controls.Add(Me.lbUnPackBoxResult)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(467, 33)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(464, 82)
        Me.GroupBox2.TabIndex = 104
        Me.GroupBox2.TabStop = False
        '
        'lbUnPackBoxMessage
        '
        Me.lbUnPackBoxMessage.AutoSize = True
        Me.lbUnPackBoxMessage.Font = New System.Drawing.Font("Arial", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnPackBoxMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbUnPackBoxMessage.Location = New System.Drawing.Point(6, 40)
        Me.lbUnPackBoxMessage.Name = "lbUnPackBoxMessage"
        Me.lbUnPackBoxMessage.Size = New System.Drawing.Size(106, 40)
        Me.lbUnPackBoxMessage.TabIndex = 86
        Me.lbUnPackBoxMessage.Text = "PASS"
        Me.lbUnPackBoxMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbUnPackBoxResult
        '
        Me.lbUnPackBoxResult.AutoSize = True
        Me.lbUnPackBoxResult.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnPackBoxResult.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbUnPackBoxResult.Location = New System.Drawing.Point(7, 15)
        Me.lbUnPackBoxResult.Name = "lbUnPackBoxResult"
        Me.lbUnPackBoxResult.Size = New System.Drawing.Size(257, 19)
        Me.lbUnPackBoxResult.TabIndex = 82
        Me.lbUnPackBoxResult.Text = "CN0XX5807244997E000A000026"
        Me.lbUnPackBoxResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPackingBoxBarcode
        '
        Me.txtPackingBoxBarcode.Location = New System.Drawing.Point(94, 82)
        Me.txtPackingBoxBarcode.Name = "txtPackingBoxBarcode"
        Me.txtPackingBoxBarcode.Size = New System.Drawing.Size(367, 21)
        Me.txtPackingBoxBarcode.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "产品条码："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(29, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(461, 12)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "温馨提示：重新装箱作业，如果多箱混装，请先把混装的箱全部拆箱，再来重新装箱！"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "外箱标签："
        '
        'txtPackingBoxCartonCode
        '
        Me.txtPackingBoxCartonCode.Location = New System.Drawing.Point(94, 42)
        Me.txtPackingBoxCartonCode.Name = "txtPackingBoxCartonCode"
        Me.txtPackingBoxCartonCode.Size = New System.Drawing.Size(367, 21)
        Me.txtPackingBoxCartonCode.TabIndex = 3
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lbMsg)
        Me.Panel5.Controls.Add(Me.btnUnboxing)
        Me.Panel5.Controls.Add(Me.txtUnboxCartonCode)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(934, 62)
        Me.Panel5.TabIndex = 0
        '
        'lbMsg
        '
        Me.lbMsg.AutoSize = True
        Me.lbMsg.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbMsg.ForeColor = System.Drawing.Color.Red
        Me.lbMsg.Location = New System.Drawing.Point(560, 25)
        Me.lbMsg.Name = "lbMsg"
        Me.lbMsg.Size = New System.Drawing.Size(0, 12)
        Me.lbMsg.TabIndex = 3
        '
        'btnUnboxing
        '
        Me.btnUnboxing.Location = New System.Drawing.Point(467, 20)
        Me.btnUnboxing.Name = "btnUnboxing"
        Me.btnUnboxing.Size = New System.Drawing.Size(75, 23)
        Me.btnUnboxing.TabIndex = 2
        Me.btnUnboxing.Text = "拆箱"
        Me.btnUnboxing.UseVisualStyleBackColor = True
        '
        'txtUnboxCartonCode
        '
        Me.txtUnboxCartonCode.Location = New System.Drawing.Point(94, 22)
        Me.txtUnboxCartonCode.Name = "txtUnboxCartonCode"
        Me.txtUnboxCartonCode.Size = New System.Drawing.Size(367, 21)
        Me.txtUnboxCartonCode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "外箱标签："
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(934, 376)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "华为ASN产品重工"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnTranfer)
        Me.Panel1.Controls.Add(Me.txtLine)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.lblMoid)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txtOldHWAsn)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.txtNewHWAsn)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtLXAsn)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(934, 376)
        Me.Panel1.TabIndex = 1
        '
        'btnTranfer
        '
        Me.btnTranfer.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnTranfer.Location = New System.Drawing.Point(127, 127)
        Me.btnTranfer.Name = "btnTranfer"
        Me.btnTranfer.Size = New System.Drawing.Size(109, 30)
        Me.btnTranfer.TabIndex = 3
        Me.btnTranfer.Text = "华为ASN重工"
        Me.btnTranfer.UseVisualStyleBackColor = True
        '
        'txtLine
        '
        Me.txtLine.Enabled = False
        Me.txtLine.Location = New System.Drawing.Point(292, 211)
        Me.txtLine.Name = "txtLine"
        Me.txtLine.ReadOnly = True
        Me.txtLine.Size = New System.Drawing.Size(64, 21)
        Me.txtLine.TabIndex = 116
        Me.txtLine.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(244, 216)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 12)
        Me.Label11.TabIndex = 115
        Me.Label11.Text = "线别："
        '
        'lblMoid
        '
        Me.lblMoid.AutoSize = True
        Me.lblMoid.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMoid.Location = New System.Drawing.Point(101, 216)
        Me.lblMoid.Name = "lblMoid"
        Me.lblMoid.Size = New System.Drawing.Size(0, 12)
        Me.lblMoid.TabIndex = 114
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(30, 216)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 12)
        Me.Label13.TabIndex = 113
        Me.Label13.Text = "工单编号："
        '
        'txtOldHWAsn
        '
        Me.txtOldHWAsn.Enabled = False
        Me.txtOldHWAsn.Location = New System.Drawing.Point(128, 174)
        Me.txtOldHWAsn.Name = "txtOldHWAsn"
        Me.txtOldHWAsn.ReadOnly = True
        Me.txtOldHWAsn.Size = New System.Drawing.Size(799, 21)
        Me.txtOldHWAsn.TabIndex = 1
        Me.txtOldHWAsn.TabStop = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(30, 103)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(71, 12)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "新华为ASN："
        '
        'txtNewHWAsn
        '
        Me.txtNewHWAsn.Location = New System.Drawing.Point(127, 100)
        Me.txtNewHWAsn.Name = "txtNewHWAsn"
        Me.txtNewHWAsn.Size = New System.Drawing.Size(799, 21)
        Me.txtNewHWAsn.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 177)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "旧华为ASN："
        '
        'txtLXAsn
        '
        Me.txtLXAsn.Location = New System.Drawing.Point(127, 63)
        Me.txtLXAsn.Name = "txtLXAsn"
        Me.txtLXAsn.Size = New System.Drawing.Size(799, 21)
        Me.txtLXAsn.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label14.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(34, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(456, 16)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "温馨提示：华为ASN重工，只替换华为ASN条码，不扫描产品条码"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 12)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "立讯ASN(立讯箱)："
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.txtHWASN2)
        Me.TabPage3.Controls.Add(Me.txtLXASN2)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(934, 376)
        Me.TabPage3.TabIndex = 4
        Me.TabPage3.Text = "追加华为ASN+立讯ASN关联"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.lblResult3)
        Me.GroupBox1.Controls.Add(Me.lblMessage3)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(23, 129)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(898, 82)
        Me.GroupBox1.TabIndex = 128
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " "
        '
        'lblResult3
        '
        Me.lblResult3.AutoSize = True
        Me.lblResult3.Font = New System.Drawing.Font("Arial", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResult3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblResult3.Location = New System.Drawing.Point(6, 40)
        Me.lblResult3.Name = "lblResult3"
        Me.lblResult3.Size = New System.Drawing.Size(106, 40)
        Me.lblResult3.TabIndex = 86
        Me.lblResult3.Text = "PASS"
        Me.lblResult3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMessage3
        '
        Me.lblMessage3.AutoSize = True
        Me.lblMessage3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMessage3.Location = New System.Drawing.Point(7, 15)
        Me.lblMessage3.Name = "lblMessage3"
        Me.lblMessage3.Size = New System.Drawing.Size(257, 19)
        Me.lblMessage3.TabIndex = 82
        Me.lblMessage3.Text = "CN0XX5807244997E000A000026"
        Me.lblMessage3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(25, 89)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 12)
        Me.Label18.TabIndex = 117
        Me.Label18.Text = "华为ASN："
        '
        'txtHWASN2
        '
        Me.txtHWASN2.Location = New System.Drawing.Point(122, 86)
        Me.txtHWASN2.Name = "txtHWASN2"
        Me.txtHWASN2.Size = New System.Drawing.Size(799, 21)
        Me.txtHWASN2.TabIndex = 122
        '
        'txtLXASN2
        '
        Me.txtLXASN2.Location = New System.Drawing.Point(122, 50)
        Me.txtLXASN2.Name = "txtLXASN2"
        Me.txtLXASN2.Size = New System.Drawing.Size(799, 21)
        Me.txtLXASN2.TabIndex = 119
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(25, 53)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 12)
        Me.Label21.TabIndex = 120
        Me.Label21.Text = "立讯ASN："
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label12.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(36, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(392, 16)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "温馨提示：立讯箱有扫描，但没有扫描LXASN和华为ASN"
        '
        'toolStrip1
        '
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(942, 25)
        Me.toolStrip1.TabIndex = 8
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(68, 22)
        Me.toolExit.Text = "退出(&X)"
        '
        'FrmStandardRework
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 427)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "FrmStandardRework"
        Me.Text = "标准重工作业"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        CType(Me.dgvUnPackBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnUnboxing As System.Windows.Forms.Button
    Friend WithEvents txtUnboxCartonCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Private WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents lbUnPackBoxMessage As System.Windows.Forms.Label
    Private WithEvents lbUnPackBoxResult As System.Windows.Forms.Label
    Friend WithEvents txtPackingBoxBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPackingBoxCartonCode As System.Windows.Forms.TextBox
    Friend WithEvents dgvUnPackBox As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbMsg As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbScanQty As System.Windows.Forms.Label
    Friend WithEvents lbPackQty As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbMoid As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtLineId As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtLXAsn As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNewHWAsn As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLine As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblMoid As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtOldHWAsn As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnTranfer As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtHWASN2 As System.Windows.Forms.TextBox
    Friend WithEvents txtLXASN2 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents lblResult3 As System.Windows.Forms.Label
    Private WithEvents lblMessage3 As System.Windows.Forms.Label
End Class
