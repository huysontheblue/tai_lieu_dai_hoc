<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNoBarCodeSet
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LabelLine = New System.Windows.Forms.Label()
        Me.CobLine = New System.Windows.Forms.ComboBox()
        Me.mtxtMOid = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.txtPerCartonPackQty = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CboSupport = New System.Windows.Forms.ComboBox()
        Me.ButConfirm = New System.Windows.Forms.Button()
        Me.ButCancel = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.GroupShow = New System.Windows.Forms.GroupBox()
        Me.lblMOQty = New System.Windows.Forms.Label()
        Me.lblPartID = New System.Windows.Forms.Label()
        Me.lblCustPartID = New System.Windows.Forms.Label()
        Me.lblMOType = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupShow.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.LabelLine)
        Me.GroupBox2.Controls.Add(Me.CobLine)
        Me.GroupBox2.Controls.Add(Me.mtxtMOid)
        Me.GroupBox2.Controls.Add(Me.lblMsg)
        Me.GroupBox2.Controls.Add(Me.txtPerCartonPackQty)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.CboSupport)
        Me.GroupBox2.Location = New System.Drawing.Point(1, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(461, 127)
        Me.GroupBox2.TabIndex = 101
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "基础信息设置"
        '
        'LabelLine
        '
        Me.LabelLine.AutoSize = True
        Me.LabelLine.Location = New System.Drawing.Point(109, 70)
        Me.LabelLine.Name = "LabelLine"
        Me.LabelLine.Size = New System.Drawing.Size(65, 12)
        Me.LabelLine.TabIndex = 110
        Me.LabelLine.Text = "线别编号："
        Me.LabelLine.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CobLine
        '
        Me.CobLine.BackColor = System.Drawing.Color.White
        Me.CobLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobLine.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CobLine.FormattingEnabled = True
        Me.CobLine.Location = New System.Drawing.Point(180, 67)
        Me.CobLine.Name = "CobLine"
        Me.CobLine.Size = New System.Drawing.Size(140, 20)
        Me.CobLine.TabIndex = 2
        '
        'mtxtMOid
        '
        '
        '
        '
        Me.mtxtMOid.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtMOid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtMOid.ButtonCustom.Image = Global.BarCodeScan.My.Resources.Resources.query
        Me.mtxtMOid.ButtonCustom.Visible = True
        Me.mtxtMOid.Location = New System.Drawing.Point(178, 14)
        Me.mtxtMOid.Name = "mtxtMOid"
        Me.mtxtMOid.ReadOnly = True
        Me.mtxtMOid.Size = New System.Drawing.Size(142, 21)
        Me.mtxtMOid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtMOid.TabIndex = 0
        Me.mtxtMOid.Text = ""
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.ForeColor = System.Drawing.Color.Green
        Me.lblMsg.Location = New System.Drawing.Point(326, 102)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(77, 12)
        Me.lblMsg.TabIndex = 71
        Me.lblMsg.Text = "已装箱完成！"
        '
        'txtPerCartonPackQty
        '
        Me.txtPerCartonPackQty.Location = New System.Drawing.Point(180, 93)
        Me.txtPerCartonPackQty.Name = "txtPerCartonPackQty"
        Me.txtPerCartonPackQty.Size = New System.Drawing.Size(140, 21)
        Me.txtPerCartonPackQty.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(97, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "每箱包装数："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(109, 45)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 12)
        Me.Label15.TabIndex = 68
        Me.Label15.Text = "客户名称："
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(107, 20)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 12)
        Me.Label23.TabIndex = 48
        Me.Label23.Text = "工单编号："
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CboSupport
        '
        Me.CboSupport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboSupport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboSupport.BackColor = System.Drawing.Color.White
        Me.CboSupport.FormattingEnabled = True
        Me.CboSupport.Location = New System.Drawing.Point(180, 41)
        Me.CboSupport.Name = "CboSupport"
        Me.CboSupport.Size = New System.Drawing.Size(140, 20)
        Me.CboSupport.TabIndex = 1
        '
        'ButConfirm
        '
        Me.ButConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButConfirm.Location = New System.Drawing.Point(372, 21)
        Me.ButConfirm.Name = "ButConfirm"
        Me.ButConfirm.Size = New System.Drawing.Size(66, 21)
        Me.ButConfirm.TabIndex = 0
        Me.ButConfirm.Text = "确认"
        Me.ButConfirm.UseVisualStyleBackColor = True
        '
        'ButCancel
        '
        Me.ButCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButCancel.Location = New System.Drawing.Point(372, 48)
        Me.ButCancel.Name = "ButCancel"
        Me.ButCancel.Size = New System.Drawing.Size(66, 23)
        Me.ButCancel.TabIndex = 1
        Me.ButCancel.Text = "取消"
        Me.ButCancel.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(15, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 12)
        Me.Label20.TabIndex = 88
        Me.Label20.Text = "工单类型："
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(188, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "工单数量："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(15, 50)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(65, 12)
        Me.Label31.TabIndex = 90
        Me.Label31.Text = "料件编号："
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupShow
        '
        Me.GroupShow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupShow.Controls.Add(Me.lblMOQty)
        Me.GroupShow.Controls.Add(Me.lblPartID)
        Me.GroupShow.Controls.Add(Me.lblCustPartID)
        Me.GroupShow.Controls.Add(Me.lblMOType)
        Me.GroupShow.Controls.Add(Me.ButConfirm)
        Me.GroupShow.Controls.Add(Me.ButCancel)
        Me.GroupShow.Controls.Add(Me.Label18)
        Me.GroupShow.Controls.Add(Me.Label20)
        Me.GroupShow.Controls.Add(Me.Label4)
        Me.GroupShow.Controls.Add(Me.Label31)
        Me.GroupShow.Location = New System.Drawing.Point(2, 137)
        Me.GroupShow.Name = "GroupShow"
        Me.GroupShow.Size = New System.Drawing.Size(460, 76)
        Me.GroupShow.TabIndex = 102
        Me.GroupShow.TabStop = False
        Me.GroupShow.Text = "工单资料信息"
        '
        'lblMOQty
        '
        Me.lblMOQty.AutoSize = True
        Me.lblMOQty.Location = New System.Drawing.Point(280, 50)
        Me.lblMOQty.Name = "lblMOQty"
        Me.lblMOQty.Size = New System.Drawing.Size(11, 12)
        Me.lblMOQty.TabIndex = 107
        Me.lblMOQty.Text = "0"
        '
        'lblPartID
        '
        Me.lblPartID.AutoSize = True
        Me.lblPartID.Location = New System.Drawing.Point(86, 50)
        Me.lblPartID.Name = "lblPartID"
        Me.lblPartID.Size = New System.Drawing.Size(11, 12)
        Me.lblPartID.TabIndex = 106
        Me.lblPartID.Text = "0"
        '
        'lblCustPartID
        '
        Me.lblCustPartID.AutoSize = True
        Me.lblCustPartID.Location = New System.Drawing.Point(278, 21)
        Me.lblCustPartID.Name = "lblCustPartID"
        Me.lblCustPartID.Size = New System.Drawing.Size(11, 12)
        Me.lblCustPartID.TabIndex = 105
        Me.lblCustPartID.Text = "0"
        '
        'lblMOType
        '
        Me.lblMOType.AutoSize = True
        Me.lblMOType.Location = New System.Drawing.Point(86, 25)
        Me.lblMOType.Name = "lblMOType"
        Me.lblMOType.Size = New System.Drawing.Size(11, 12)
        Me.lblMOType.TabIndex = 104
        Me.lblMOType.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(188, 25)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 12)
        Me.Label18.TabIndex = 92
        Me.Label18.Text = "客户料号："
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmNoBarCodeSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 225)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmNoBarCodeSet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "基础资料设置界面"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupShow.ResumeLayout(False)
        Me.GroupShow.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents CboSupport As System.Windows.Forms.ComboBox
    Friend WithEvents ButConfirm As System.Windows.Forms.Button
    Friend WithEvents ButCancel As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents GroupShow As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtPerCartonPackQty As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblMOType As System.Windows.Forms.Label
    Friend WithEvents lblCustPartID As System.Windows.Forms.Label
    Friend WithEvents lblPartID As System.Windows.Forms.Label
    Friend WithEvents lblMOQty As System.Windows.Forms.Label
    Friend WithEvents mtxtMOid As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents LabelLine As System.Windows.Forms.Label
    Friend WithEvents CobLine As System.Windows.Forms.ComboBox
End Class
