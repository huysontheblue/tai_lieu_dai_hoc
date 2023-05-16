<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfigSet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConfigSet))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BnConFrm = New System.Windows.Forms.Button()
        Me.ButCancel = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPpidQty = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtThirdQty = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtThirdStyle = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkScanThird = New System.Windows.Forms.CheckBox()
        Me.txtPpidStyle = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSecondQty = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSecondStyle = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCartonQty = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCartonStyle = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkScanPpid = New System.Windows.Forms.CheckBox()
        Me.chkScanSecond = New System.Windows.Forms.CheckBox()
        Me.chkScanCarton = New System.Windows.Forms.CheckBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblTrayQTY = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCartonCheckCode = New System.Windows.Forms.TextBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPPIDCheckCode = New System.Windows.Forms.TextBox()
        Me.scanset = New System.Windows.Forms.GroupBox()
        Me.layerType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mtxtMOid = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CobLine = New System.Windows.Forms.ComboBox()
        Me.IsScanOld = New System.Windows.Forms.CheckBox()
        Me.CobSitId = New System.Windows.Forms.ComboBox()
        Me.TxtAvcPart = New ULControls.textBoxUL()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DtpSet = New System.Windows.Forms.DateTimePicker()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.scanset.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 109
        Me.Label1.Text = "站点编号："
        '
        'BnConFrm
        '
        Me.BnConFrm.Location = New System.Drawing.Point(184, 501)
        Me.BnConFrm.Name = "BnConFrm"
        Me.BnConFrm.Size = New System.Drawing.Size(75, 23)
        Me.BnConFrm.TabIndex = 114
        Me.BnConFrm.Text = "确定"
        Me.BnConFrm.UseVisualStyleBackColor = True
        '
        'ButCancel
        '
        Me.ButCancel.Location = New System.Drawing.Point(302, 501)
        Me.ButCancel.Name = "ButCancel"
        Me.ButCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButCancel.TabIndex = 115
        Me.ButCancel.Text = "取消"
        Me.ButCancel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "线别编号："
        '
        'txtPpidQty
        '
        Me.txtPpidQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPpidQty.Location = New System.Drawing.Point(473, 30)
        Me.txtPpidQty.Name = "txtPpidQty"
        Me.txtPpidQty.Size = New System.Drawing.Size(83, 21)
        Me.txtPpidQty.TabIndex = 130
        Me.txtPpidQty.Text = "1"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(410, 34)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 12)
        Me.Label12.TabIndex = 131
        Me.Label12.Text = "产品数量:"
        '
        'txtThirdQty
        '
        Me.txtThirdQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtThirdQty.Location = New System.Drawing.Point(473, 33)
        Me.txtThirdQty.Name = "txtThirdQty"
        Me.txtThirdQty.Size = New System.Drawing.Size(83, 21)
        Me.txtThirdQty.TabIndex = 128
        Me.txtThirdQty.Text = "5"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(410, 37)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 12)
        Me.Label10.TabIndex = 129
        Me.Label10.Text = "包装数量:"
        '
        'txtThirdStyle
        '
        Me.txtThirdStyle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtThirdStyle.Location = New System.Drawing.Point(98, 33)
        Me.txtThirdStyle.Name = "txtThirdStyle"
        Me.txtThirdStyle.Size = New System.Drawing.Size(300, 21)
        Me.txtThirdStyle.TabIndex = 126
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 35)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 12)
        Me.Label11.TabIndex = 127
        Me.Label11.Text = "PE袋条码样式:"
        '
        'chkScanThird
        '
        Me.chkScanThird.AutoSize = True
        Me.chkScanThird.Enabled = False
        Me.chkScanThird.Location = New System.Drawing.Point(13, 11)
        Me.chkScanThird.Name = "chkScanThird"
        Me.chkScanThird.Size = New System.Drawing.Size(204, 16)
        Me.chkScanThird.TabIndex = 125
        Me.chkScanThird.Text = "扫描第三层外箱条码（三层外箱）"
        Me.chkScanThird.UseVisualStyleBackColor = True
        '
        'txtPpidStyle
        '
        Me.txtPpidStyle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPpidStyle.Location = New System.Drawing.Point(99, 30)
        Me.txtPpidStyle.Name = "txtPpidStyle"
        Me.txtPpidStyle.Size = New System.Drawing.Size(300, 21)
        Me.txtPpidStyle.TabIndex = 120
        Me.txtPpidStyle.Text = "L2180531*********D01*"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 12)
        Me.Label8.TabIndex = 121
        Me.Label8.Text = "产品条码样式:"
        '
        'txtSecondQty
        '
        Me.txtSecondQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSecondQty.Location = New System.Drawing.Point(473, 30)
        Me.txtSecondQty.Name = "txtSecondQty"
        Me.txtSecondQty.Size = New System.Drawing.Size(83, 21)
        Me.txtSecondQty.TabIndex = 118
        Me.txtSecondQty.Text = "20"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(410, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 119
        Me.Label4.Text = "包装数量:"
        '
        'txtSecondStyle
        '
        Me.txtSecondStyle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSecondStyle.Location = New System.Drawing.Point(98, 30)
        Me.txtSecondStyle.Name = "txtSecondStyle"
        Me.txtSecondStyle.Size = New System.Drawing.Size(300, 21)
        Me.txtSecondStyle.TabIndex = 116
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 12)
        Me.Label5.TabIndex = 117
        Me.Label5.Text = "PE袋条码样式:"
        '
        'txtCartonQty
        '
        Me.txtCartonQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCartonQty.Location = New System.Drawing.Point(473, 33)
        Me.txtCartonQty.Name = "txtCartonQty"
        Me.txtCartonQty.Size = New System.Drawing.Size(83, 21)
        Me.txtCartonQty.TabIndex = 114
        Me.txtCartonQty.Text = "100"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(410, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 12)
        Me.Label7.TabIndex = 115
        Me.Label7.Text = "装箱数量:"
        '
        'txtCartonStyle
        '
        Me.txtCartonStyle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCartonStyle.Location = New System.Drawing.Point(98, 33)
        Me.txtCartonStyle.Name = "txtCartonStyle"
        Me.txtCartonStyle.Size = New System.Drawing.Size(300, 21)
        Me.txtCartonStyle.TabIndex = 112
        Me.txtCartonStyle.Text = "*******-D287*-*****-*****"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 12)
        Me.Label6.TabIndex = 113
        Me.Label6.Text = "外箱条码样式:"
        '
        'chkScanPpid
        '
        Me.chkScanPpid.AutoSize = True
        Me.chkScanPpid.Checked = True
        Me.chkScanPpid.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkScanPpid.Enabled = False
        Me.chkScanPpid.Location = New System.Drawing.Point(14, 8)
        Me.chkScanPpid.Name = "chkScanPpid"
        Me.chkScanPpid.Size = New System.Drawing.Size(96, 16)
        Me.chkScanPpid.TabIndex = 2
        Me.chkScanPpid.Text = "扫描产品条码"
        Me.chkScanPpid.UseVisualStyleBackColor = True
        '
        'chkScanSecond
        '
        Me.chkScanSecond.AutoSize = True
        Me.chkScanSecond.Enabled = False
        Me.chkScanSecond.Location = New System.Drawing.Point(13, 8)
        Me.chkScanSecond.Name = "chkScanSecond"
        Me.chkScanSecond.Size = New System.Drawing.Size(204, 16)
        Me.chkScanSecond.TabIndex = 1
        Me.chkScanSecond.Text = "扫描第二层包装条码（二层外箱）"
        Me.chkScanSecond.UseVisualStyleBackColor = True
        '
        'chkScanCarton
        '
        Me.chkScanCarton.AutoSize = True
        Me.chkScanCarton.Checked = True
        Me.chkScanCarton.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkScanCarton.Enabled = False
        Me.chkScanCarton.Location = New System.Drawing.Point(13, 12)
        Me.chkScanCarton.Name = "chkScanCarton"
        Me.chkScanCarton.Size = New System.Drawing.Size(96, 16)
        Me.chkScanCarton.TabIndex = 0
        Me.chkScanCarton.Text = "扫描外箱条码"
        Me.chkScanCarton.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Enabled = False
        Me.btnEdit.Location = New System.Drawing.Point(437, 501)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(96, 23)
        Me.btnEdit.TabIndex = 205
        Me.btnEdit.Text = "扫描设置编辑"
        Me.btnEdit.UseVisualStyleBackColor = True
        Me.btnEdit.Visible = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(13, 62)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblTrayQTY)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCartonCheckCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkScanCarton)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCartonStyle)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCartonQty)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.Size = New System.Drawing.Size(573, 311)
        Me.SplitContainer1.SplitterDistance = 90
        Me.SplitContainer1.TabIndex = 206
        '
        'lblTrayQTY
        '
        Me.lblTrayQTY.AutoSize = True
        Me.lblTrayQTY.Location = New System.Drawing.Point(132, 13)
        Me.lblTrayQTY.Name = "lblTrayQTY"
        Me.lblTrayQTY.Size = New System.Drawing.Size(65, 12)
        Me.lblTrayQTY.TabIndex = 127
        Me.lblTrayQTY.Text = "Tray盘数量"
        Me.lblTrayQTY.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(33, 67)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 12)
        Me.Label13.TabIndex = 126
        Me.Label13.Text = "箱校验码:"
        '
        'txtCartonCheckCode
        '
        Me.txtCartonCheckCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCartonCheckCode.Enabled = False
        Me.txtCartonCheckCode.Location = New System.Drawing.Point(98, 63)
        Me.txtCartonCheckCode.Name = "txtCartonCheckCode"
        Me.txtCartonCheckCode.ReadOnly = True
        Me.txtCartonCheckCode.Size = New System.Drawing.Size(458, 21)
        Me.txtCartonCheckCode.TabIndex = 125
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtThirdStyle)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtThirdQty)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkScanThird)
        Me.SplitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer2.Size = New System.Drawing.Size(573, 217)
        Me.SplitContainer2.SplitterDistance = 70
        Me.SplitContainer2.TabIndex = 0
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtSecondQty)
        Me.SplitContainer3.Panel1.Controls.Add(Me.chkScanSecond)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtSecondStyle)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer3.Panel1.Enabled = False
        Me.SplitContainer3.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label14)
        Me.SplitContainer3.Panel2.Controls.Add(Me.txtPPIDCheckCode)
        Me.SplitContainer3.Panel2.Controls.Add(Me.txtPpidQty)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label12)
        Me.SplitContainer3.Panel2.Controls.Add(Me.chkScanPpid)
        Me.SplitContainer3.Panel2.Controls.Add(Me.txtPpidStyle)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer3.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer3.Size = New System.Drawing.Size(573, 143)
        Me.SplitContainer3.SplitterDistance = 57
        Me.SplitContainer3.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(24, 59)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 12)
        Me.Label14.TabIndex = 133
        Me.Label14.Text = "产品校验码:"
        '
        'txtPPIDCheckCode
        '
        Me.txtPPIDCheckCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPPIDCheckCode.Enabled = False
        Me.txtPPIDCheckCode.Location = New System.Drawing.Point(98, 57)
        Me.txtPPIDCheckCode.Name = "txtPPIDCheckCode"
        Me.txtPPIDCheckCode.ReadOnly = True
        Me.txtPPIDCheckCode.Size = New System.Drawing.Size(458, 21)
        Me.txtPPIDCheckCode.TabIndex = 132
        '
        'scanset
        '
        Me.scanset.Controls.Add(Me.layerType)
        Me.scanset.Controls.Add(Me.Label2)
        Me.scanset.Controls.Add(Me.SplitContainer1)
        Me.scanset.Enabled = False
        Me.scanset.Location = New System.Drawing.Point(12, 105)
        Me.scanset.Name = "scanset"
        Me.scanset.Size = New System.Drawing.Size(600, 386)
        Me.scanset.TabIndex = 207
        Me.scanset.TabStop = False
        Me.scanset.Text = "扫描设置"
        '
        'layerType
        '
        Me.layerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.layerType.Enabled = False
        Me.layerType.FormattingEnabled = True
        Me.layerType.Items.AddRange(New Object() {"-------------------------------------------------------------------------", "两层包装（扫描外箱条码，产品条码）", "三层包装（扫描外箱条码，二层外箱条码，产品条码）", "四层包装（扫描外箱条码，三层外箱条码，二层外箱条码，产品条码）"})
        Me.layerType.Location = New System.Drawing.Point(111, 30)
        Me.layerType.Name = "layerType"
        Me.layerType.Size = New System.Drawing.Size(458, 20)
        Me.layerType.TabIndex = 211
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 210
        Me.Label2.Text = "扫描层级："
        '
        'mtxtMOid
        '
        '
        '
        '
        Me.mtxtMOid.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtMOid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtMOid.ButtonCustom.Visible = True
        Me.mtxtMOid.Location = New System.Drawing.Point(87, 12)
        Me.mtxtMOid.Name = "mtxtMOid"
        Me.mtxtMOid.ReadOnly = True
        Me.mtxtMOid.Size = New System.Drawing.Size(142, 21)
        Me.mtxtMOid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtMOid.TabIndex = 208
        Me.mtxtMOid.Text = ""
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(19, 16)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 12)
        Me.Label23.TabIndex = 207
        Me.Label23.Text = "工单编号："
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CobLine
        '
        Me.CobLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobLine.FormattingEnabled = True
        Me.CobLine.Location = New System.Drawing.Point(85, 66)
        Me.CobLine.Name = "CobLine"
        Me.CobLine.Size = New System.Drawing.Size(180, 20)
        Me.CobLine.TabIndex = 209
        '
        'IsScanOld
        '
        Me.IsScanOld.AutoSize = True
        Me.IsScanOld.Location = New System.Drawing.Point(25, 505)
        Me.IsScanOld.Name = "IsScanOld"
        Me.IsScanOld.Size = New System.Drawing.Size(108, 16)
        Me.IsScanOld.TabIndex = 127
        Me.IsScanOld.Text = "是否扫描旧条码"
        Me.IsScanOld.UseVisualStyleBackColor = True
        Me.IsScanOld.Visible = False
        '
        'CobSitId
        '
        Me.CobSitId.BackColor = System.Drawing.Color.White
        Me.CobSitId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobSitId.FormattingEnabled = True
        Me.CobSitId.Location = New System.Drawing.Point(85, 39)
        Me.CobSitId.Name = "CobSitId"
        Me.CobSitId.Size = New System.Drawing.Size(180, 20)
        Me.CobSitId.TabIndex = 210
        '
        'TxtAvcPart
        '
        Me.TxtAvcPart.BackColor = System.Drawing.Color.White
        Me.TxtAvcPart.BorderColor = System.Drawing.Color.FromArgb(CType(CType(104, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.TxtAvcPart.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAvcPart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtAvcPart.HotColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TxtAvcPart.Location = New System.Drawing.Point(383, 42)
        Me.TxtAvcPart.Name = "TxtAvcPart"
        Me.TxtAvcPart.ReadOnly = True
        Me.TxtAvcPart.Size = New System.Drawing.Size(180, 14)
        Me.TxtAvcPart.TabIndex = 212
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(312, 42)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(65, 12)
        Me.Label31.TabIndex = 211
        Me.Label31.Text = "料件编号："
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(312, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 12)
        Me.Label15.TabIndex = 214
        Me.Label15.Text = "条码日期："
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DtpSet
        '
        Me.DtpSet.Location = New System.Drawing.Point(383, 11)
        Me.DtpSet.Name = "DtpSet"
        Me.DtpSet.Size = New System.Drawing.Size(180, 21)
        Me.DtpSet.TabIndex = 213
        '
        'FrmConfigSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 547)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.DtpSet)
        Me.Controls.Add(Me.TxtAvcPart)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.CobSitId)
        Me.Controls.Add(Me.IsScanOld)
        Me.Controls.Add(Me.CobLine)
        Me.Controls.Add(Me.mtxtMOid)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.scanset)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ButCancel)
        Me.Controls.Add(Me.BnConFrm)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConfigSet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "工站设置"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        Me.SplitContainer3.ResumeLayout(False)
        Me.scanset.ResumeLayout(False)
        Me.scanset.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BnConFrm As System.Windows.Forms.Button
    Friend WithEvents ButCancel As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPpidStyle As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSecondQty As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSecondStyle As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCartonQty As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCartonStyle As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkScanPpid As System.Windows.Forms.CheckBox
    Friend WithEvents chkScanSecond As System.Windows.Forms.CheckBox
    Friend WithEvents chkScanCarton As System.Windows.Forms.CheckBox
    Friend WithEvents txtThirdQty As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtThirdStyle As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkScanThird As System.Windows.Forms.CheckBox
    Friend WithEvents txtPpidQty As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents scanset As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCartonCheckCode As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents CobLine As System.Windows.Forms.ComboBox
    Friend WithEvents layerType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents IsScanOld As System.Windows.Forms.CheckBox
    Private WithEvents mtxtMOid As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents CobSitId As System.Windows.Forms.ComboBox
    Friend WithEvents TxtAvcPart As ULControls.textBoxUL
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPPIDCheckCode As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DtpSet As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTrayQTY As System.Windows.Forms.Label
End Class
