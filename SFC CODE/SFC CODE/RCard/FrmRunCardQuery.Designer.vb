<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRunCardQuery
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRunCardQuery))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTypeDest = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.ckDateEnd = New System.Windows.Forms.CheckBox()
        Me.dateTimeTo = New System.Windows.Forms.DateTimePicker()
        Me.txtPartNumber = New System.Windows.Forms.TextBox()
        Me.txtShape = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dateTimeFrom = New System.Windows.Forms.DateTimePicker()
        Me.ckDateBegin = New System.Windows.Forms.CheckBox()
        Me.lblDateTo = New System.Windows.Forms.Label()
        Me.txtDrawingVer = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblDateFrom = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtRemark)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtTypeDest)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtDescription)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtUserID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboStatus)
        Me.GroupBox1.Controls.Add(Me.ckDateEnd)
        Me.GroupBox1.Controls.Add(Me.dateTimeTo)
        Me.GroupBox1.Controls.Add(Me.txtPartNumber)
        Me.GroupBox1.Controls.Add(Me.txtShape)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dateTimeFrom)
        Me.GroupBox1.Controls.Add(Me.ckDateBegin)
        Me.GroupBox1.Controls.Add(Me.lblDateTo)
        Me.GroupBox1.Controls.Add(Me.txtDrawingVer)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblDateFrom)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(766, 182)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtTypeDest
        '
        Me.txtTypeDest.Location = New System.Drawing.Point(581, 101)
        Me.txtTypeDest.Name = "txtTypeDest"
        Me.txtTypeDest.Size = New System.Drawing.Size(156, 21)
        Me.txtTypeDest.TabIndex = 25
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(540, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 12)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "描述:"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(367, 101)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(156, 21)
        Me.txtDescription.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(326, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 12)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "规格:"
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(101, 101)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(162, 21)
        Me.txtUserID.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "创建人:"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(15, 60)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(84, 16)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "查询旧版本"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(540, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "状态:"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"0:制作中", "1:已生效", "2:待审核"})
        Me.cboStatus.Location = New System.Drawing.Point(581, 58)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(161, 20)
        Me.cboStatus.TabIndex = 7
        '
        'ckDateEnd
        '
        Me.ckDateEnd.AutoSize = True
        Me.ckDateEnd.Checked = True
        Me.ckDateEnd.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckDateEnd.Location = New System.Drawing.Point(281, 22)
        Me.ckDateEnd.Name = "ckDateEnd"
        Me.ckDateEnd.Size = New System.Drawing.Size(15, 14)
        Me.ckDateEnd.TabIndex = 3
        Me.ckDateEnd.UseVisualStyleBackColor = True
        '
        'dateTimeTo
        '
        Me.dateTimeTo.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.dateTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateTimeTo.Location = New System.Drawing.Point(367, 19)
        Me.dateTimeTo.Name = "dateTimeTo"
        Me.dateTimeTo.Size = New System.Drawing.Size(155, 21)
        Me.dateTimeTo.TabIndex = 2
        '
        'txtPartNumber
        '
        Me.txtPartNumber.Location = New System.Drawing.Point(581, 19)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Size = New System.Drawing.Size(161, 21)
        Me.txtPartNumber.TabIndex = 3
        '
        'txtShape
        '
        Me.txtShape.FormattingEnabled = True
        Me.txtShape.Location = New System.Drawing.Point(367, 60)
        Me.txtShape.Name = "txtShape"
        Me.txtShape.Size = New System.Drawing.Size(155, 20)
        Me.txtShape.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(540, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "料号:"
        '
        'dateTimeFrom
        '
        Me.dateTimeFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.dateTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateTimeFrom.Location = New System.Drawing.Point(101, 20)
        Me.dateTimeFrom.Name = "dateTimeFrom"
        Me.dateTimeFrom.Size = New System.Drawing.Size(162, 21)
        Me.dateTimeFrom.TabIndex = 1
        '
        'ckDateBegin
        '
        Me.ckDateBegin.AutoSize = True
        Me.ckDateBegin.Location = New System.Drawing.Point(15, 22)
        Me.ckDateBegin.Name = "ckDateBegin"
        Me.ckDateBegin.Size = New System.Drawing.Size(15, 14)
        Me.ckDateBegin.TabIndex = 0
        Me.ckDateBegin.UseVisualStyleBackColor = True
        '
        'lblDateTo
        '
        Me.lblDateTo.AutoSize = True
        Me.lblDateTo.Location = New System.Drawing.Point(302, 22)
        Me.lblDateTo.Name = "lblDateTo"
        Me.lblDateTo.Size = New System.Drawing.Size(59, 12)
        Me.lblDateTo.TabIndex = 14
        Me.lblDateTo.Text = "结束日期:"
        '
        'txtDrawingVer
        '
        Me.txtDrawingVer.Location = New System.Drawing.Point(149, 59)
        Me.txtDrawingVer.Name = "txtDrawingVer"
        Me.txtDrawingVer.Size = New System.Drawing.Size(114, 21)
        Me.txtDrawingVer.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(115, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 12)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "版本:"
        '
        'lblDateFrom
        '
        Me.lblDateFrom.AutoSize = True
        Me.lblDateFrom.Location = New System.Drawing.Point(36, 22)
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(59, 12)
        Me.lblDateFrom.TabIndex = 16
        Me.lblDateFrom.Text = "开始日期:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(36, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 12)
        Me.Label7.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(326, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "形态:"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(623, 188)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "取 消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(517, 188)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "确 定(&O)"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(36, 153)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 12)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "备注:"
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(101, 150)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(269, 21)
        Me.txtRemark.TabIndex = 27
        '
        'FrmRunCardQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 232)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmRunCardQuery"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "流程卡查询"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDrawingVer As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblDateTo As System.Windows.Forms.Label
    Friend WithEvents lblDateFrom As System.Windows.Forms.Label
    Friend WithEvents dateTimeTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateTimeFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtShape As System.Windows.Forms.ComboBox
    Friend WithEvents ckDateBegin As System.Windows.Forms.CheckBox
    Friend WithEvents ckDateEnd As System.Windows.Forms.CheckBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTypeDest As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
