<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmManualpacking
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmManualpacking))
        Me.txtCarton = New TextBoxUL.TextBoxUL()
        Me.lblCode01 = New System.Windows.Forms.Label()
        Me.lblCode02 = New System.Windows.Forms.Label()
        Me.txtSecond = New TextBoxUL.TextBoxUL()
        Me.MetroTileItem3 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem2 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolScanSet = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolNext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolPartSet = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripAnkerSetting = New System.Windows.Forms.ToolStripButton()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_MONGQty = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_MOSetupQty = New System.Windows.Forms.Label()
        Me.lbl_MOScannedQty = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chk_MoRework = New System.Windows.Forms.CheckBox()
        Me.chk_OPPORepaired = New System.Windows.Forms.CheckBox()
        Me.chk_Warning = New System.Windows.Forms.CheckBox()
        Me.chk_CartonWarning = New System.Windows.Forms.CheckBox()
        Me.TxtBHWCode = New TextBoxUL.TextBoxUL()
        Me.LabHWDesc = New System.Windows.Forms.Label()
        Me.LabNeedQtyI = New System.Windows.Forms.Label()
        Me.LabCompleteQtyI = New System.Windows.Forms.Label()
        Me.LabNeed = New System.Windows.Forms.Label()
        Me.LabComplete = New System.Windows.Forms.Label()
        Me.txtStyle = New TextBoxUL.TextBoxUL()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblppid = New System.Windows.Forms.Label()
        Me.txtPpid = New TextBoxUL.TextBoxUL()
        Me.LabLineID = New System.Windows.Forms.Label()
        Me.LabMoID = New System.Windows.Forms.Label()
        Me.LabLineIDInfo = New System.Windows.Forms.Label()
        Me.LabMoIDInfo = New System.Windows.Forms.Label()
        Me.PanInfo = New System.Windows.Forms.Panel()
        Me.LabHwInfo = New System.Windows.Forms.Label()
        Me.LabInfo4 = New System.Windows.Forms.Label()
        Me.LabInfo3 = New System.Windows.Forms.Label()
        Me.LabInfo2 = New System.Windows.Forms.Label()
        Me.LabInfo1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ppid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cartonid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.userID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LabNeedQtyIShow = New System.Windows.Forms.Label()
        Me.LabCompleteQtyIShow = New System.Windows.Forms.Label()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.txtPE1 = New System.Windows.Forms.TextBox()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.groupBox3.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PanInfo.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        Me.MetroTilePanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCarton
        '
        Me.txtCarton.BackColor = System.Drawing.Color.White
        Me.txtCarton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCarton.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCarton.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCarton.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtCarton.Location = New System.Drawing.Point(131, 85)
        Me.txtCarton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCarton.Name = "txtCarton"
        Me.txtCarton.ReadOnly = True
        Me.txtCarton.Size = New System.Drawing.Size(427, 18)
        Me.txtCarton.TabIndex = 1
        '
        'lblCode01
        '
        Me.lblCode01.AutoSize = True
        Me.lblCode01.Location = New System.Drawing.Point(8, 90)
        Me.lblCode01.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCode01.Name = "lblCode01"
        Me.lblCode01.Size = New System.Drawing.Size(105, 15)
        Me.lblCode01.TabIndex = 105
        Me.lblCode01.Text = "外层外箱条码:"
        '
        'lblCode02
        '
        Me.lblCode02.AutoSize = True
        Me.lblCode02.Location = New System.Drawing.Point(8, 121)
        Me.lblCode02.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCode02.Name = "lblCode02"
        Me.lblCode02.Size = New System.Drawing.Size(105, 15)
        Me.lblCode02.TabIndex = 107
        Me.lblCode02.Text = "二层外箱条码:"
        '
        'txtSecond
        '
        Me.txtSecond.BackColor = System.Drawing.Color.White
        Me.txtSecond.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSecond.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSecond.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSecond.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtSecond.Location = New System.Drawing.Point(131, 116)
        Me.txtSecond.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSecond.Name = "txtSecond"
        Me.txtSecond.ReadOnly = True
        Me.txtSecond.Size = New System.Drawing.Size(427, 18)
        Me.txtSecond.TabIndex = 2
        '
        'MetroTileItem3
        '
        Me.MetroTileItem3.Name = "MetroTileItem3"
        Me.MetroTileItem3.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem3.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.MetroTileItem3.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'MetroTileItem2
        '
        Me.MetroTileItem2.Name = "MetroTileItem2"
        Me.MetroTileItem2.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.MetroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'groupBox3
        '
        Me.groupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox3.BackColor = System.Drawing.Color.White
        Me.groupBox3.Controls.Add(Me.lblMessage)
        Me.groupBox3.Controls.Add(Me.lblResult)
        Me.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.groupBox3.ForeColor = System.Drawing.Color.Black
        Me.groupBox3.Location = New System.Drawing.Point(593, 12)
        Me.groupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.groupBox3.Size = New System.Drawing.Size(1175, 138)
        Me.groupBox3.TabIndex = 182
        Me.groupBox3.TabStop = False
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMessage.Location = New System.Drawing.Point(8, 62)
        Me.lblMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(132, 49)
        Me.lblMessage.TabIndex = 86
        Me.lblMessage.Text = "PASS"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResult.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblResult.Location = New System.Drawing.Point(13, 24)
        Me.lblResult.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(310, 24)
        Me.lblResult.TabIndex = 82
        Me.lblResult.Text = "CN0XX5807244997E000A000026"
        Me.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolScanSet, Me.ToolStripSeparator1, Me.ToolNext, Me.ToolStripSeparator2, Me.ToolPartSet, Me.ToolStripSeparator3, Me.ToolStripAnkerSetting, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(-8, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1936, 35)
        Me.toolStrip1.TabIndex = 183
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolScanSet
        '
        Me.toolScanSet.Image = CType(resources.GetObject("toolScanSet.Image"), System.Drawing.Image)
        Me.toolScanSet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolScanSet.Name = "toolScanSet"
        Me.toolScanSet.Size = New System.Drawing.Size(120, 32)
        Me.toolScanSet.Text = "扫描设置(&F1)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 35)
        '
        'ToolNext
        '
        Me.ToolNext.Image = CType(resources.GetObject("ToolNext.Image"), System.Drawing.Image)
        Me.ToolNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolNext.Name = "ToolNext"
        Me.ToolNext.Size = New System.Drawing.Size(195, 32)
        Me.ToolNext.Text = "跳过继续下一箱产品(F5)"
        Me.ToolNext.ToolTipText = "跳过继续下一箱产品(F5)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 35)
        '
        'ToolPartSet
        '
        Me.ToolPartSet.Enabled = False
        Me.ToolPartSet.Image = CType(resources.GetObject("ToolPartSet.Image"), System.Drawing.Image)
        Me.ToolPartSet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolPartSet.Name = "ToolPartSet"
        Me.ToolPartSet.Size = New System.Drawing.Size(183, 32)
        Me.ToolPartSet.Text = "料件包装扫描参数设置"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 35)
        '
        'ToolStripAnkerSetting
        '
        Me.ToolStripAnkerSetting.Image = CType(resources.GetObject("ToolStripAnkerSetting.Image"), System.Drawing.Image)
        Me.ToolStripAnkerSetting.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripAnkerSetting.Name = "ToolStripAnkerSetting"
        Me.ToolStripAnkerSetting.Size = New System.Drawing.Size(135, 32)
        Me.ToolStripAnkerSetting.Text = "Anker-Setting"
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(87, 32)
        Me.toolExit.Text = "退 出(&X)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lbl_MONGQty)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lbl_MOSetupQty)
        Me.GroupBox1.Controls.Add(Me.lbl_MOScannedQty)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.chk_MoRework)
        Me.GroupBox1.Controls.Add(Me.chk_OPPORepaired)
        Me.GroupBox1.Controls.Add(Me.chk_Warning)
        Me.GroupBox1.Controls.Add(Me.chk_CartonWarning)
        Me.GroupBox1.Controls.Add(Me.TxtBHWCode)
        Me.GroupBox1.Controls.Add(Me.LabHWDesc)
        Me.GroupBox1.Controls.Add(Me.LabNeedQtyI)
        Me.GroupBox1.Controls.Add(Me.LabCompleteQtyI)
        Me.GroupBox1.Controls.Add(Me.LabNeed)
        Me.GroupBox1.Controls.Add(Me.LabComplete)
        Me.GroupBox1.Controls.Add(Me.txtStyle)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblppid)
        Me.GroupBox1.Controls.Add(Me.txtPpid)
        Me.GroupBox1.Controls.Add(Me.LabLineID)
        Me.GroupBox1.Controls.Add(Me.LabMoID)
        Me.GroupBox1.Controls.Add(Me.LabLineIDInfo)
        Me.GroupBox1.Controls.Add(Me.LabMoIDInfo)
        Me.GroupBox1.Controls.Add(Me.PanInfo)
        Me.GroupBox1.Controls.Add(Me.groupBox3)
        Me.GroupBox1.Controls.Add(Me.txtCarton)
        Me.GroupBox1.Controls.Add(Me.lblCode01)
        Me.GroupBox1.Controls.Add(Me.lblCode02)
        Me.GroupBox1.Controls.Add(Me.txtSecond)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 35)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1776, 224)
        Me.GroupBox1.TabIndex = 184
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "工站扫描数据采集"
        '
        'lbl_MONGQty
        '
        Me.lbl_MONGQty.AutoSize = True
        Me.lbl_MONGQty.Font = New System.Drawing.Font("SimSun", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl_MONGQty.ForeColor = System.Drawing.Color.Red
        Me.lbl_MONGQty.Location = New System.Drawing.Point(1729, 151)
        Me.lbl_MONGQty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_MONGQty.Name = "lbl_MONGQty"
        Me.lbl_MONGQty.Size = New System.Drawing.Size(37, 37)
        Me.lbl_MONGQty.TabIndex = 221
        Me.lbl_MONGQty.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1665, 161)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 15)
        Me.Label2.TabIndex = 220
        Me.Label2.Text = "ScanNG:"
        '
        'lbl_MOSetupQty
        '
        Me.lbl_MOSetupQty.AutoSize = True
        Me.lbl_MOSetupQty.Font = New System.Drawing.Font("SimSun", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl_MOSetupQty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_MOSetupQty.Location = New System.Drawing.Point(1540, 185)
        Me.lbl_MOSetupQty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_MOSetupQty.Name = "lbl_MOSetupQty"
        Me.lbl_MOSetupQty.Size = New System.Drawing.Size(37, 37)
        Me.lbl_MOSetupQty.TabIndex = 219
        Me.lbl_MOSetupQty.Text = "0"
        '
        'lbl_MOScannedQty
        '
        Me.lbl_MOScannedQty.AutoSize = True
        Me.lbl_MOScannedQty.Font = New System.Drawing.Font("SimSun", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl_MOScannedQty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_MOScannedQty.Location = New System.Drawing.Point(1540, 149)
        Me.lbl_MOScannedQty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_MOScannedQty.Name = "lbl_MOScannedQty"
        Me.lbl_MOScannedQty.Size = New System.Drawing.Size(37, 37)
        Me.lbl_MOScannedQty.TabIndex = 218
        Me.lbl_MOScannedQty.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1457, 198)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 15)
        Me.Label5.TabIndex = 217
        Me.Label5.Text = "MOSetup:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1457, 161)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 15)
        Me.Label6.TabIndex = 216
        Me.Label6.Text = "MOScanned:"
        '
        'chk_MoRework
        '
        Me.chk_MoRework.AutoSize = True
        Me.chk_MoRework.Location = New System.Drawing.Point(1313, 192)
        Me.chk_MoRework.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_MoRework.Name = "chk_MoRework"
        Me.chk_MoRework.Size = New System.Drawing.Size(101, 19)
        Me.chk_MoRework.TabIndex = 215
        Me.chk_MoRework.Text = "MO-Rework"
        Me.chk_MoRework.UseVisualStyleBackColor = True
        '
        'chk_OPPORepaired
        '
        Me.chk_OPPORepaired.AutoSize = True
        Me.chk_OPPORepaired.Location = New System.Drawing.Point(1313, 158)
        Me.chk_OPPORepaired.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_OPPORepaired.Name = "chk_OPPORepaired"
        Me.chk_OPPORepaired.Size = New System.Drawing.Size(133, 19)
        Me.chk_OPPORepaired.TabIndex = 213
        Me.chk_OPPORepaired.Text = "OPPO-Repaired"
        Me.chk_OPPORepaired.UseVisualStyleBackColor = True
        '
        'chk_Warning
        '
        Me.chk_Warning.AutoSize = True
        Me.chk_Warning.Location = New System.Drawing.Point(1175, 192)
        Me.chk_Warning.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_Warning.Name = "chk_Warning"
        Me.chk_Warning.Size = New System.Drawing.Size(133, 19)
        Me.chk_Warning.TabIndex = 212
        Me.chk_Warning.Text = "Warning Voice"
        Me.chk_Warning.UseVisualStyleBackColor = True
        '
        'chk_CartonWarning
        '
        Me.chk_CartonWarning.AutoSize = True
        Me.chk_CartonWarning.Location = New System.Drawing.Point(1175, 158)
        Me.chk_CartonWarning.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_CartonWarning.Name = "chk_CartonWarning"
        Me.chk_CartonWarning.Size = New System.Drawing.Size(125, 19)
        Me.chk_CartonWarning.TabIndex = 211
        Me.chk_CartonWarning.Text = "Full Carton "
        Me.chk_CartonWarning.UseVisualStyleBackColor = True
        '
        'TxtBHWCode
        '
        Me.TxtBHWCode.BackColor = System.Drawing.Color.White
        Me.TxtBHWCode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtBHWCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBHWCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBHWCode.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtBHWCode.Location = New System.Drawing.Point(131, 55)
        Me.TxtBHWCode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtBHWCode.Name = "TxtBHWCode"
        Me.TxtBHWCode.ReadOnly = True
        Me.TxtBHWCode.Size = New System.Drawing.Size(427, 18)
        Me.TxtBHWCode.TabIndex = 0
        '
        'LabHWDesc
        '
        Me.LabHWDesc.AutoSize = True
        Me.LabHWDesc.Location = New System.Drawing.Point(8, 60)
        Me.LabHWDesc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabHWDesc.Name = "LabHWDesc"
        Me.LabHWDesc.Size = New System.Drawing.Size(105, 15)
        Me.LabHWDesc.TabIndex = 208
        Me.LabHWDesc.Text = "客户料号条码:"
        '
        'LabNeedQtyI
        '
        Me.LabNeedQtyI.AutoSize = True
        Me.LabNeedQtyI.Font = New System.Drawing.Font("SimSun", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabNeedQtyI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LabNeedQtyI.Location = New System.Drawing.Point(839, 185)
        Me.LabNeedQtyI.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabNeedQtyI.Name = "LabNeedQtyI"
        Me.LabNeedQtyI.Size = New System.Drawing.Size(37, 37)
        Me.LabNeedQtyI.TabIndex = 206
        Me.LabNeedQtyI.Text = "0"
        '
        'LabCompleteQtyI
        '
        Me.LabCompleteQtyI.AutoSize = True
        Me.LabCompleteQtyI.Font = New System.Drawing.Font("SimSun", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabCompleteQtyI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabCompleteQtyI.Location = New System.Drawing.Point(839, 149)
        Me.LabCompleteQtyI.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabCompleteQtyI.Name = "LabCompleteQtyI"
        Me.LabCompleteQtyI.Size = New System.Drawing.Size(37, 37)
        Me.LabCompleteQtyI.TabIndex = 205
        Me.LabCompleteQtyI.Text = "0"
        '
        'LabNeed
        '
        Me.LabNeed.AutoSize = True
        Me.LabNeed.Location = New System.Drawing.Point(756, 198)
        Me.LabNeed.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabNeed.Name = "LabNeed"
        Me.LabNeed.Size = New System.Drawing.Size(75, 15)
        Me.LabNeed.TabIndex = 204
        Me.LabNeed.Text = "应装数量:"
        '
        'LabComplete
        '
        Me.LabComplete.AutoSize = True
        Me.LabComplete.Location = New System.Drawing.Point(756, 161)
        Me.LabComplete.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabComplete.Name = "LabComplete"
        Me.LabComplete.Size = New System.Drawing.Size(75, 15)
        Me.LabComplete.TabIndex = 203
        Me.LabComplete.Text = "已装数量:"
        '
        'txtStyle
        '
        Me.txtStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtStyle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtStyle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStyle.Enabled = False
        Me.txtStyle.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtStyle.Location = New System.Drawing.Point(131, 24)
        Me.txtStyle.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtStyle.Name = "txtStyle"
        Me.txtStyle.ReadOnly = True
        Me.txtStyle.Size = New System.Drawing.Size(427, 18)
        Me.txtStyle.TabIndex = 201
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 29)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 202
        Me.Label1.Text = "条码样式:"
        '
        'lblppid
        '
        Me.lblppid.AutoSize = True
        Me.lblppid.Location = New System.Drawing.Point(40, 151)
        Me.lblppid.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblppid.Name = "lblppid"
        Me.lblppid.Size = New System.Drawing.Size(75, 15)
        Me.lblppid.TabIndex = 199
        Me.lblppid.Text = "产品条码:"
        '
        'txtPpid
        '
        Me.txtPpid.BackColor = System.Drawing.Color.White
        Me.txtPpid.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPpid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPpid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPpid.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtPpid.Location = New System.Drawing.Point(131, 146)
        Me.txtPpid.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPpid.Name = "txtPpid"
        Me.txtPpid.ReadOnly = True
        Me.txtPpid.Size = New System.Drawing.Size(427, 18)
        Me.txtPpid.TabIndex = 3
        '
        'LabLineID
        '
        Me.LabLineID.AutoSize = True
        Me.LabLineID.Location = New System.Drawing.Point(1048, 198)
        Me.LabLineID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabLineID.Name = "LabLineID"
        Me.LabLineID.Size = New System.Drawing.Size(0, 15)
        Me.LabLineID.TabIndex = 197
        '
        'LabMoID
        '
        Me.LabMoID.AutoSize = True
        Me.LabMoID.Location = New System.Drawing.Point(1048, 161)
        Me.LabMoID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabMoID.Name = "LabMoID"
        Me.LabMoID.Size = New System.Drawing.Size(0, 15)
        Me.LabMoID.TabIndex = 196
        '
        'LabLineIDInfo
        '
        Me.LabLineIDInfo.AutoSize = True
        Me.LabLineIDInfo.Location = New System.Drawing.Point(963, 198)
        Me.LabLineIDInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabLineIDInfo.Name = "LabLineIDInfo"
        Me.LabLineIDInfo.Size = New System.Drawing.Size(75, 15)
        Me.LabLineIDInfo.TabIndex = 195
        Me.LabLineIDInfo.Text = "线别编号:"
        '
        'LabMoIDInfo
        '
        Me.LabMoIDInfo.AutoSize = True
        Me.LabMoIDInfo.Location = New System.Drawing.Point(963, 161)
        Me.LabMoIDInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabMoIDInfo.Name = "LabMoIDInfo"
        Me.LabMoIDInfo.Size = New System.Drawing.Size(75, 15)
        Me.LabMoIDInfo.TabIndex = 194
        Me.LabMoIDInfo.Text = "工单编号:"
        '
        'PanInfo
        '
        Me.PanInfo.Controls.Add(Me.LabHwInfo)
        Me.PanInfo.Controls.Add(Me.LabInfo4)
        Me.PanInfo.Controls.Add(Me.LabInfo3)
        Me.PanInfo.Controls.Add(Me.LabInfo2)
        Me.PanInfo.Controls.Add(Me.LabInfo1)
        Me.PanInfo.ForeColor = System.Drawing.Color.White
        Me.PanInfo.Location = New System.Drawing.Point(1, 175)
        Me.PanInfo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PanInfo.Name = "PanInfo"
        Me.PanInfo.Size = New System.Drawing.Size(709, 46)
        Me.PanInfo.TabIndex = 193
        '
        'LabHwInfo
        '
        Me.LabHwInfo.BackColor = System.Drawing.Color.Gray
        Me.LabHwInfo.ForeColor = System.Drawing.Color.White
        Me.LabHwInfo.Location = New System.Drawing.Point(11, 10)
        Me.LabHwInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabHwInfo.Name = "LabHwInfo"
        Me.LabHwInfo.Size = New System.Drawing.Size(200, 25)
        Me.LabHwInfo.TabIndex = 10
        Me.LabHwInfo.Text = "客户料号及装箱数量条码"
        Me.LabHwInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabInfo4
        '
        Me.LabInfo4.BackColor = System.Drawing.Color.Gray
        Me.LabInfo4.ForeColor = System.Drawing.Color.White
        Me.LabInfo4.Location = New System.Drawing.Point(584, 10)
        Me.LabInfo4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabInfo4.Name = "LabInfo4"
        Me.LabInfo4.Size = New System.Drawing.Size(107, 25)
        Me.LabInfo4.TabIndex = 9
        Me.LabInfo4.Text = "产品条码"
        Me.LabInfo4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabInfo3
        '
        Me.LabInfo3.BackColor = System.Drawing.Color.Gray
        Me.LabInfo3.ForeColor = System.Drawing.Color.White
        Me.LabInfo3.Location = New System.Drawing.Point(464, 10)
        Me.LabInfo3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabInfo3.Name = "LabInfo3"
        Me.LabInfo3.Size = New System.Drawing.Size(107, 25)
        Me.LabInfo3.TabIndex = 8
        Me.LabInfo3.Text = "PE袋条码"
        Me.LabInfo3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabInfo2
        '
        Me.LabInfo2.BackColor = System.Drawing.Color.Gray
        Me.LabInfo2.ForeColor = System.Drawing.Color.White
        Me.LabInfo2.Location = New System.Drawing.Point(344, 10)
        Me.LabInfo2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabInfo2.Name = "LabInfo2"
        Me.LabInfo2.Size = New System.Drawing.Size(107, 25)
        Me.LabInfo2.TabIndex = 7
        Me.LabInfo2.Text = "外箱QRCode"
        Me.LabInfo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabInfo1
        '
        Me.LabInfo1.BackColor = System.Drawing.Color.Gray
        Me.LabInfo1.ForeColor = System.Drawing.Color.White
        Me.LabInfo1.Location = New System.Drawing.Point(224, 10)
        Me.LabInfo1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabInfo1.Name = "LabInfo1"
        Me.LabInfo1.Size = New System.Drawing.Size(107, 25)
        Me.LabInfo1.TabIndex = 6
        Me.LabInfo1.Text = "外箱条码"
        Me.LabInfo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ppid, Me.cartonid, Me.userID, Me.intime})
        Me.DataGridView1.Location = New System.Drawing.Point(7, 310)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(1005, 342)
        Me.DataGridView1.TabIndex = 185
        '
        'ppid
        '
        Me.ppid.HeaderText = "扫描条码"
        Me.ppid.Name = "ppid"
        '
        'cartonid
        '
        Me.cartonid.HeaderText = "父级条码"
        Me.cartonid.Name = "cartonid"
        '
        'userID
        '
        Me.userID.HeaderText = "操作人"
        Me.userID.Name = "userID"
        '
        'intime
        '
        Me.intime.HeaderText = "作业时间"
        Me.intime.Name = "intime"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label4.Location = New System.Drawing.Point(11, 274)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 20)
        Me.Label4.TabIndex = 187
        Me.Label4.Text = "扫描记录"
        '
        'PanelEx1
        '
        Me.PanelEx1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.MetroTilePanel1)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Location = New System.Drawing.Point(751, 262)
        Me.PanelEx1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(1032, 388)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 186
        Me.PanelEx1.Text = "PanelEx1"
        '
        'MetroTilePanel1
        '
        '
        '
        '
        Me.MetroTilePanel1.BackgroundStyle.Class = "MetroTilePanel"
        Me.MetroTilePanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTilePanel1.ContainerControlProcessDialogKey = True
        Me.MetroTilePanel1.Controls.Add(Me.Label11)
        Me.MetroTilePanel1.Controls.Add(Me.LabNeedQtyIShow)
        Me.MetroTilePanel1.Controls.Add(Me.LabCompleteQtyIShow)
        Me.MetroTilePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroTilePanel1.DragDropSupport = True
        Me.MetroTilePanel1.Font = New System.Drawing.Font("SimSun", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1})
        Me.MetroTilePanel1.ItemSpacing = 0
        Me.MetroTilePanel1.Location = New System.Drawing.Point(0, 0)
        Me.MetroTilePanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(1032, 388)
        Me.MetroTilePanel1.TabIndex = 0
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("SimSun", 42.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(447, 300)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 70)
        Me.Label11.TabIndex = 208
        Me.Label11.Text = "/"
        '
        'LabNeedQtyIShow
        '
        Me.LabNeedQtyIShow.AutoSize = True
        Me.LabNeedQtyIShow.Font = New System.Drawing.Font("SimSun", 42.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabNeedQtyIShow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LabNeedQtyIShow.Location = New System.Drawing.Point(505, 300)
        Me.LabNeedQtyIShow.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabNeedQtyIShow.Name = "LabNeedQtyIShow"
        Me.LabNeedQtyIShow.Size = New System.Drawing.Size(174, 70)
        Me.LabNeedQtyIShow.TabIndex = 207
        Me.LabNeedQtyIShow.Text = "0000"
        '
        'LabCompleteQtyIShow
        '
        Me.LabCompleteQtyIShow.AutoSize = True
        Me.LabCompleteQtyIShow.Font = New System.Drawing.Font("SimSun", 42.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabCompleteQtyIShow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabCompleteQtyIShow.Location = New System.Drawing.Point(276, 300)
        Me.LabCompleteQtyIShow.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabCompleteQtyIShow.Name = "LabCompleteQtyIShow"
        Me.LabCompleteQtyIShow.Size = New System.Drawing.Size(174, 70)
        Me.LabCompleteQtyIShow.TabIndex = 206
        Me.LabCompleteQtyIShow.Text = "0000"
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.MultiLine = True
        Me.ItemContainer1.Name = "ItemContainer1"
        '
        '
        '
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'LabelItem1
        '
        Me.LabelItem1.ContainerNewLineAfter = True
        Me.LabelItem1.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "装箱进度明细"
        '
        'txtPE1
        '
        Me.txtPE1.BackColor = System.Drawing.Color.Red
        Me.txtPE1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPE1.ForeColor = System.Drawing.Color.White
        Me.txtPE1.Location = New System.Drawing.Point(767, 310)
        Me.txtPE1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPE1.Multiline = True
        Me.txtPE1.Name = "txtPE1"
        Me.txtPE1.Size = New System.Drawing.Size(65, 374)
        Me.txtPE1.TabIndex = 191
        Me.txtPE1.Text = "PE1"
        Me.txtPE1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPE1.Visible = False
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.AutoSize = True
        Me.tableLayoutPanel1.ColumnCount = 13
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308!))
        Me.tableLayoutPanel1.ForeColor = System.Drawing.Color.White
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(839, 309)
        Me.tableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.tableLayoutPanel1.MaximumSize = New System.Drawing.Size(0, 831)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 4
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(0, 375)
        Me.tableLayoutPanel1.TabIndex = 190
        '
        'FrmManualpacking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1789, 656)
        Me.Controls.Add(Me.txtPE1)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmManualpacking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "非系统条码包装工站扫描数据采集"
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PanInfo.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        Me.MetroTilePanel1.ResumeLayout(False)
        Me.MetroTilePanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCarton As TextBoxUL.TextBoxUL
    Friend WithEvents lblCode01 As System.Windows.Forms.Label
    Friend WithEvents lblCode02 As System.Windows.Forms.Label
    Friend WithEvents txtSecond As TextBoxUL.TextBoxUL
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents lblMessage As System.Windows.Forms.Label
    Private WithEvents lblResult As System.Windows.Forms.Label
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents toolScanSet As System.Windows.Forms.ToolStripButton
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PanInfo As System.Windows.Forms.Panel
    Friend WithEvents LabInfo4 As System.Windows.Forms.Label
    Friend WithEvents LabInfo3 As System.Windows.Forms.Label
    Friend WithEvents LabInfo2 As System.Windows.Forms.Label
    Friend WithEvents LabInfo1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents LabLineID As System.Windows.Forms.Label
    Friend WithEvents LabMoID As System.Windows.Forms.Label
    Friend WithEvents LabLineIDInfo As System.Windows.Forms.Label
    Friend WithEvents LabMoIDInfo As System.Windows.Forms.Label
    Private WithEvents ToolNext As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblppid As System.Windows.Forms.Label
    Friend WithEvents txtPpid As TextBoxUL.TextBoxUL
    Friend WithEvents txtStyle As TextBoxUL.TextBoxUL
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LabNeedQtyI As System.Windows.Forms.Label
    Friend WithEvents LabCompleteQtyI As System.Windows.Forms.Label
    Friend WithEvents LabNeed As System.Windows.Forms.Label
    Friend WithEvents LabComplete As System.Windows.Forms.Label
    Friend WithEvents ppid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cartonid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents userID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents intime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LabNeedQtyIShow As System.Windows.Forms.Label
    Friend WithEvents LabCompleteQtyIShow As System.Windows.Forms.Label
    Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolPartSet As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxtBHWCode As TextBoxUL.TextBoxUL
    Friend WithEvents LabHWDesc As System.Windows.Forms.Label
    Friend WithEvents LabHwInfo As System.Windows.Forms.Label
    Private WithEvents txtPE1 As System.Windows.Forms.TextBox
    Private WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents MetroTileItem3 As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents MetroTileItem2 As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Private WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Private WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Private WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents chk_Warning As System.Windows.Forms.CheckBox
    Friend WithEvents chk_CartonWarning As System.Windows.Forms.CheckBox
    Friend WithEvents chk_OPPORepaired As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripAnkerSetting As System.Windows.Forms.ToolStripButton
    Friend WithEvents chk_MoRework As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_MOSetupQty As System.Windows.Forms.Label
    Friend WithEvents lbl_MOScannedQty As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_MONGQty As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
