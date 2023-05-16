<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProcessParametersMaintain
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

    'Windows 窗体设计器所必需的test
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。test
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProcessParametersMaintain))
        Dim PageDataGridPager4 As Pager.PageDataGridPager = New Pager.PageDataGridPager()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtLineDesc4 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtPnOfLineFour = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtLineDesc3 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtPnOfLineThree = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtLineDesc2 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtPnOfLineTwo = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtPnOfCut = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtFrontSize = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCutSize = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSizeOfCut = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDrawForce = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtWireWidth = New System.Windows.Forms.TextBox()
        Me.txtWireHeight = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtLineDesc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPnOfLine = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTvName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPnOfTV = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvProcessParameter = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgvCD = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.txtToleranceRange = New System.Windows.Forms.TextBox()
        Me.lblTolerance = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cdCobStatus = New System.Windows.Forms.ComboBox()
        Me.txtCDCutSize = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtCDOtherFinishStandard = New System.Windows.Forms.TextBox()
        Me.txtCDEmFinishStandard = New System.Windows.Forms.TextBox()
        Me.txtCDHWFinishStandard = New System.Windows.Forms.TextBox()
        Me.txtCDFinishSizeMax = New System.Windows.Forms.TextBox()
        Me.txtCDFinishSizeMin = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnModify = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnUndo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImport = New System.Windows.Forms.ToolStripButton()
        Me.btnExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PagerPaging = New Pager.PagerPaging()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvProcessParameter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvCD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.ToolBt.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(1, 30)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1340, 467)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1332, 441)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "加工工艺参数"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1332, 441)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLineDesc4)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cboStatus)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.txtPnOfLineFour)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.txtLineDesc3)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.txtPnOfLineThree)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.txtLineDesc2)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtPnOfLineTwo)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.txtPnOfCut)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtFrontSize)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtCutSize)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtSizeOfCut)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtDrawForce)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtWireWidth)
        Me.GroupBox1.Controls.Add(Me.txtWireHeight)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtLineDesc)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtPnOfLine)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtTvName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPnOfTV)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1324, 114)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "工艺参数设定"
        '
        'txtLineDesc4
        '
        Me.txtLineDesc4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineDesc4.Location = New System.Drawing.Point(970, 47)
        Me.txtLineDesc4.Name = "txtLineDesc4"
        Me.txtLineDesc4.Size = New System.Drawing.Size(138, 21)
        Me.txtLineDesc4.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label11.Location = New System.Drawing.Point(1134, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 14)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "状态:"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"Y.有效", "N.无效"})
        Me.cboStatus.Location = New System.Drawing.Point(1182, 48)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(110, 20)
        Me.cboStatus.TabIndex = 11
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label25.Location = New System.Drawing.Point(894, 51)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(77, 14)
        Me.Label25.TabIndex = 35
        Me.Label25.Text = "线材规格4:"
        '
        'txtPnOfLineFour
        '
        Me.txtPnOfLineFour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPnOfLineFour.Location = New System.Drawing.Point(970, 16)
        Me.txtPnOfLineFour.Name = "txtPnOfLineFour"
        Me.txtPnOfLineFour.Size = New System.Drawing.Size(138, 21)
        Me.txtPnOfLineFour.TabIndex = 4
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label26.Location = New System.Drawing.Point(894, 20)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(77, 14)
        Me.Label26.TabIndex = 33
        Me.Label26.Text = "线材料号4:"
        '
        'txtLineDesc3
        '
        Me.txtLineDesc3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineDesc3.Location = New System.Drawing.Point(747, 47)
        Me.txtLineDesc3.Name = "txtLineDesc3"
        Me.txtLineDesc3.Size = New System.Drawing.Size(138, 21)
        Me.txtLineDesc3.TabIndex = 9
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label23.Location = New System.Drawing.Point(670, 51)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(77, 14)
        Me.Label23.TabIndex = 31
        Me.Label23.Text = "线材规格3:"
        '
        'txtPnOfLineThree
        '
        Me.txtPnOfLineThree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPnOfLineThree.Location = New System.Drawing.Point(747, 15)
        Me.txtPnOfLineThree.Name = "txtPnOfLineThree"
        Me.txtPnOfLineThree.Size = New System.Drawing.Size(138, 21)
        Me.txtPnOfLineThree.TabIndex = 3
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label24.Location = New System.Drawing.Point(670, 19)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(77, 14)
        Me.Label24.TabIndex = 29
        Me.Label24.Text = "线材料号3:"
        '
        'txtLineDesc2
        '
        Me.txtLineDesc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineDesc2.Location = New System.Drawing.Point(520, 48)
        Me.txtLineDesc2.Name = "txtLineDesc2"
        Me.txtLineDesc2.Size = New System.Drawing.Size(138, 21)
        Me.txtLineDesc2.TabIndex = 8
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label21.Location = New System.Drawing.Point(443, 51)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(77, 14)
        Me.Label21.TabIndex = 27
        Me.Label21.Text = "线材规格2:"
        '
        'txtPnOfLineTwo
        '
        Me.txtPnOfLineTwo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPnOfLineTwo.Location = New System.Drawing.Point(520, 15)
        Me.txtPnOfLineTwo.Name = "txtPnOfLineTwo"
        Me.txtPnOfLineTwo.Size = New System.Drawing.Size(138, 21)
        Me.txtPnOfLineTwo.TabIndex = 2
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label22.Location = New System.Drawing.Point(443, 20)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(77, 14)
        Me.Label22.TabIndex = 25
        Me.Label22.Text = "线材料号2:"
        '
        'txtPnOfCut
        '
        Me.txtPnOfCut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPnOfCut.Location = New System.Drawing.Point(1182, 13)
        Me.txtPnOfCut.Name = "txtPnOfCut"
        Me.txtPnOfCut.Size = New System.Drawing.Size(110, 21)
        Me.txtPnOfCut.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label13.Location = New System.Drawing.Point(1115, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 14)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "刀模料号:"
        '
        'txtFrontSize
        '
        Me.txtFrontSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFrontSize.Location = New System.Drawing.Point(300, 86)
        Me.txtFrontSize.Name = "txtFrontSize"
        Me.txtFrontSize.Size = New System.Drawing.Size(137, 21)
        Me.txtFrontSize.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label12.Location = New System.Drawing.Point(231, 88)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 14)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "前端尺寸:"
        '
        'txtCutSize
        '
        Me.txtCutSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCutSize.Location = New System.Drawing.Point(1182, 82)
        Me.txtCutSize.Name = "txtCutSize"
        Me.txtCutSize.Size = New System.Drawing.Size(110, 21)
        Me.txtCutSize.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label10.Location = New System.Drawing.Point(1114, 86)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 14)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "裁线尺寸:"
        '
        'txtSizeOfCut
        '
        Me.txtSizeOfCut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSizeOfCut.Location = New System.Drawing.Point(80, 86)
        Me.txtSizeOfCut.Name = "txtSizeOfCut"
        Me.txtSizeOfCut.Size = New System.Drawing.Size(138, 21)
        Me.txtSizeOfCut.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 14)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "脱皮尺寸:"
        '
        'txtDrawForce
        '
        Me.txtDrawForce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDrawForce.Location = New System.Drawing.Point(970, 83)
        Me.txtDrawForce.Name = "txtDrawForce"
        Me.txtDrawForce.Size = New System.Drawing.Size(138, 21)
        Me.txtDrawForce.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.Location = New System.Drawing.Point(914, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 14)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "拉拔力:"
        '
        'txtWireWidth
        '
        Me.txtWireWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWireWidth.Location = New System.Drawing.Point(767, 85)
        Me.txtWireWidth.Name = "txtWireWidth"
        Me.txtWireWidth.Size = New System.Drawing.Size(118, 21)
        Me.txtWireWidth.TabIndex = 15
        '
        'txtWireHeight
        '
        Me.txtWireHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWireHeight.Location = New System.Drawing.Point(537, 86)
        Me.txtWireHeight.Name = "txtWireHeight"
        Me.txtWireHeight.Size = New System.Drawing.Size(121, 21)
        Me.txtWireHeight.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.Location = New System.Drawing.Point(670, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 14)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "铜丝压着宽度:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.Location = New System.Drawing.Point(442, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 14)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "铜丝压着高度:"
        '
        'txtLineDesc
        '
        Me.txtLineDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineDesc.Location = New System.Drawing.Point(300, 50)
        Me.txtLineDesc.Name = "txtLineDesc"
        Me.txtLineDesc.Size = New System.Drawing.Size(137, 21)
        Me.txtLineDesc.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.Location = New System.Drawing.Point(224, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 14)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "线材规格1:"
        '
        'txtPnOfLine
        '
        Me.txtPnOfLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPnOfLine.Location = New System.Drawing.Point(299, 17)
        Me.txtPnOfLine.Name = "txtPnOfLine"
        Me.txtPnOfLine.Size = New System.Drawing.Size(138, 21)
        Me.txtPnOfLine.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(224, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 14)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "线材料号1:"
        '
        'txtTvName
        '
        Me.txtTvName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTvName.Location = New System.Drawing.Point(80, 49)
        Me.txtTvName.Name = "txtTvName"
        Me.txtTvName.Size = New System.Drawing.Size(138, 21)
        Me.txtTvName.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "端子规格:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "端子料号:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 12)
        Me.Label1.TabIndex = 1
        '
        'txtPnOfTV
        '
        Me.txtPnOfTV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPnOfTV.Location = New System.Drawing.Point(80, 17)
        Me.txtPnOfTV.Name = "txtPnOfTV"
        Me.txtPnOfTV.Size = New System.Drawing.Size(138, 21)
        Me.txtPnOfTV.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvProcessParameter)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 117)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1324, 319)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "工艺参数列表"
        '
        'dgvProcessParameter
        '
        Me.dgvProcessParameter.AllowUserToAddRows = False
        Me.dgvProcessParameter.BackgroundColor = System.Drawing.Color.White
        Me.dgvProcessParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProcessParameter.Location = New System.Drawing.Point(6, 20)
        Me.dgvProcessParameter.Name = "dgvProcessParameter"
        Me.dgvProcessParameter.ReadOnly = True
        Me.dgvProcessParameter.RowHeadersVisible = False
        Me.dgvProcessParameter.RowTemplate.Height = 23
        Me.dgvProcessParameter.Size = New System.Drawing.Size(1312, 299)
        Me.dgvProcessParameter.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1332, 441)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "公差参数"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.GroupBox4)
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1332, 447)
        Me.Panel2.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgvCD)
        Me.GroupBox4.Location = New System.Drawing.Point(-1, 111)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1328, 329)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "公差参数列表"
        '
        'dgvCD
        '
        Me.dgvCD.AllowUserToAddRows = False
        Me.dgvCD.AllowUserToDeleteRows = False
        Me.dgvCD.BackgroundColor = System.Drawing.Color.White
        Me.dgvCD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCD.Location = New System.Drawing.Point(7, 20)
        Me.dgvCD.Name = "dgvCD"
        Me.dgvCD.ReadOnly = True
        Me.dgvCD.RowHeadersVisible = False
        Me.dgvCD.RowTemplate.Height = 23
        Me.dgvCD.Size = New System.Drawing.Size(1315, 303)
        Me.dgvCD.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblID)
        Me.GroupBox3.Controls.Add(Me.txtToleranceRange)
        Me.GroupBox3.Controls.Add(Me.lblTolerance)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.cdCobStatus)
        Me.GroupBox3.Controls.Add(Me.txtCDCutSize)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.txtCDOtherFinishStandard)
        Me.GroupBox3.Controls.Add(Me.txtCDEmFinishStandard)
        Me.GroupBox3.Controls.Add(Me.txtCDHWFinishStandard)
        Me.GroupBox3.Controls.Add(Me.txtCDFinishSizeMax)
        Me.GroupBox3.Controls.Add(Me.txtCDFinishSizeMin)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1322, 100)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "公差参数设定"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(1110, 28)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(56, 14)
        Me.lblID.TabIndex = 16
        Me.lblID.Text = "Label21"
        Me.lblID.Visible = False
        '
        'txtToleranceRange
        '
        Me.txtToleranceRange.Location = New System.Drawing.Point(928, 51)
        Me.txtToleranceRange.Name = "txtToleranceRange"
        Me.txtToleranceRange.Size = New System.Drawing.Size(78, 23)
        Me.txtToleranceRange.TabIndex = 7
        '
        'lblTolerance
        '
        Me.lblTolerance.AutoSize = True
        Me.lblTolerance.Location = New System.Drawing.Point(860, 56)
        Me.lblTolerance.Name = "lblTolerance"
        Me.lblTolerance.Size = New System.Drawing.Size(70, 14)
        Me.lblTolerance.TabIndex = 14
        Me.lblTolerance.Text = "公差范围:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(880, 21)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 14)
        Me.Label20.TabIndex = 13
        Me.Label20.Text = "状态:"
        '
        'cdCobStatus
        '
        Me.cdCobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cdCobStatus.FormattingEnabled = True
        Me.cdCobStatus.Items.AddRange(New Object() {"Y.有效", "N.无效"})
        Me.cdCobStatus.Location = New System.Drawing.Point(928, 16)
        Me.cdCobStatus.Name = "cdCobStatus"
        Me.cdCobStatus.Size = New System.Drawing.Size(78, 22)
        Me.cdCobStatus.TabIndex = 3
        '
        'txtCDCutSize
        '
        Me.txtCDCutSize.Location = New System.Drawing.Point(703, 51)
        Me.txtCDCutSize.Name = "txtCDCutSize"
        Me.txtCDCutSize.Size = New System.Drawing.Size(131, 23)
        Me.txtCDCutSize.TabIndex = 6
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(591, 56)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 14)
        Me.Label19.TabIndex = 10
        Me.Label19.Text = "裁线下公差(mm):"
        '
        'txtCDOtherFinishStandard
        '
        Me.txtCDOtherFinishStandard.Location = New System.Drawing.Point(703, 17)
        Me.txtCDOtherFinishStandard.Name = "txtCDOtherFinishStandard"
        Me.txtCDOtherFinishStandard.Size = New System.Drawing.Size(131, 23)
        Me.txtCDOtherFinishStandard.TabIndex = 2
        '
        'txtCDEmFinishStandard
        '
        Me.txtCDEmFinishStandard.Location = New System.Drawing.Point(465, 51)
        Me.txtCDEmFinishStandard.Name = "txtCDEmFinishStandard"
        Me.txtCDEmFinishStandard.Size = New System.Drawing.Size(108, 23)
        Me.txtCDEmFinishStandard.TabIndex = 5
        '
        'txtCDHWFinishStandard
        '
        Me.txtCDHWFinishStandard.Location = New System.Drawing.Point(465, 18)
        Me.txtCDHWFinishStandard.Name = "txtCDHWFinishStandard"
        Me.txtCDHWFinishStandard.Size = New System.Drawing.Size(108, 23)
        Me.txtCDHWFinishStandard.TabIndex = 1
        '
        'txtCDFinishSizeMax
        '
        Me.txtCDFinishSizeMax.Location = New System.Drawing.Point(166, 51)
        Me.txtCDFinishSizeMax.Name = "txtCDFinishSizeMax"
        Me.txtCDFinishSizeMax.Size = New System.Drawing.Size(111, 23)
        Me.txtCDFinishSizeMax.TabIndex = 4
        '
        'txtCDFinishSizeMin
        '
        Me.txtCDFinishSizeMin.Location = New System.Drawing.Point(166, 17)
        Me.txtCDFinishSizeMin.Name = "txtCDFinishSizeMin"
        Me.txtCDFinishSizeMin.Size = New System.Drawing.Size(111, 23)
        Me.txtCDFinishSizeMin.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(577, 20)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(126, 14)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "其他成品公差标准:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(293, 19)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(168, 14)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "HuaWei成品公差标准(mm):"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(293, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(175, 14)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Emerson成品公差标准(mm):"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(21, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(147, 14)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "成品尺寸范围Max(mm):"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(21, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(147, 14)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "成品尺寸范围Min(mm):"
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btnNew, Me.ToolStripSeparator4, Me.btnModify, Me.ToolStripSeparator5, Me.btnSave, Me.ToolStripSeparator2, Me.btnUndo, Me.ToolStripSeparator6, Me.btnSearch, Me.ToolStripSeparator3, Me.btnRefresh, Me.ToolStripSeparator7, Me.btnImport, Me.btnExport, Me.ToolStripSeparator8, Me.btnExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1361, 23)
        Me.ToolBt.TabIndex = 46
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(74, 20)
        Me.btnNew.Tag = ""
        Me.btnNew.Text = "新 增(&N)"
        Me.btnNew.ToolTipText = "新增"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'btnModify
        '
        Me.btnModify.Image = CType(resources.GetObject("btnModify.Image"), System.Drawing.Image)
        Me.btnModify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(71, 20)
        Me.btnModify.Tag = ""
        Me.btnModify.Text = "修 改(&E)"
        Me.btnModify.ToolTipText = "修 改"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 23)
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(71, 20)
        Me.btnSave.Text = "保 存(&S)"
        Me.btnSave.ToolTipText = "保存"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'btnUndo
        '
        Me.btnUndo.Enabled = False
        Me.btnUndo.Image = CType(resources.GetObject("btnUndo.Image"), System.Drawing.Image)
        Me.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(68, 20)
        Me.btnUndo.Text = "返回(&C)"
        Me.btnUndo.ToolTipText = "返回"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 23)
        '
        'btnSearch
        '
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(70, 20)
        Me.btnSearch.Text = "查 找(&F)"
        Me.btnSearch.ToolTipText = "查找"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 20)
        Me.btnRefresh.Text = "刷 新(&R)"
        Me.btnRefresh.ToolTipText = "刷新"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 23)
        '
        'btnImport
        '
        Me.btnImport.Image = CType(resources.GetObject("btnImport.Image"), System.Drawing.Image)
        Me.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(52, 20)
        Me.btnImport.Text = "导入"
        '
        'btnExport
        '
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(52, 20)
        Me.btnExport.Text = "导出"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 23)
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
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(368, 138)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(681, 203)
        Me.DataGridView1.TabIndex = 0
        '
        'PagerPaging
        '
        Me.PagerPaging.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.PagerPaging.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PagerPaging.Location = New System.Drawing.Point(247, 503)
        Me.PagerPaging.Name = "PagerPaging"
        PageDataGridPager4.DataGrid = Nothing
        PageDataGridPager4.PageSize = 10
        PageDataGridPager4.PageSizes = New Integer() {10, 20, 50, 100, 500, 1000}
        PageDataGridPager4.Sort = ""
        'PageDataGridPager4.x7155dda3b72cd3e5 = 1
        'PageDataGridPager4.x744ea7fab69a66e7 = 0
        Me.PagerPaging.PagerGrid = PageDataGridPager4
        Me.PagerPaging.Size = New System.Drawing.Size(767, 29)
        Me.PagerPaging.TabIndex = 47
        '
        'FrmProcessParametersMaintain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1361, 536)
        Me.Controls.Add(Me.PagerPaging)
        Me.Controls.Add(Me.ToolBt)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmProcessParametersMaintain"
        Me.Text = "工艺参数维护"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvProcessParameter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvCD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnModify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvProcessParameter As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPnOfTV As System.Windows.Forms.TextBox
    Friend WithEvents PagerPaging As Pager.PagerPaging
    Friend WithEvents txtTvName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPnOfLine As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLineDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtWireWidth As System.Windows.Forms.TextBox
    Friend WithEvents txtWireHeight As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCutSize As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSizeOfCut As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDrawForce As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFrontSize As System.Windows.Forms.TextBox
    Friend WithEvents txtPnOfCut As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCDEmFinishStandard As System.Windows.Forms.TextBox
    Friend WithEvents txtCDHWFinishStandard As System.Windows.Forms.TextBox
    Friend WithEvents txtCDFinishSizeMax As System.Windows.Forms.TextBox
    Friend WithEvents txtCDFinishSizeMin As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCDOtherFinishStandard As System.Windows.Forms.TextBox
    Friend WithEvents txtCDCutSize As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cdCobStatus As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCD As System.Windows.Forms.DataGridView
    Friend WithEvents lblTolerance As System.Windows.Forms.Label
    Friend WithEvents txtToleranceRange As System.Windows.Forms.TextBox
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents txtLineDesc2 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtPnOfLineTwo As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtLineDesc4 As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtPnOfLineFour As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtLineDesc3 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtPnOfLineThree As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
End Class
