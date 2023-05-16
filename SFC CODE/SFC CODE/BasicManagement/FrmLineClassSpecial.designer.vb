<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLineClassSpecial
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLineClassSpecial))
        Me.txtTimeEnd = New System.Windows.Forms.DateTimePicker()
        Me.txtTimeStart = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLineID = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.dgvQuery = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartDt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndDt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolDelete = New System.Windows.Forms.ToolStripButton()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExitFrom = New System.Windows.Forms.ToolStripButton()
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolBt.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTimeEnd
        '
        Me.txtTimeEnd.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.txtTimeEnd.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.txtTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtTimeEnd.Location = New System.Drawing.Point(358, 52)
        Me.txtTimeEnd.Name = "txtTimeEnd"
        Me.txtTimeEnd.Size = New System.Drawing.Size(160, 21)
        Me.txtTimeEnd.TabIndex = 196
        '
        'txtTimeStart
        '
        Me.txtTimeStart.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.txtTimeStart.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.txtTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtTimeStart.Location = New System.Drawing.Point(165, 52)
        Me.txtTimeStart.Name = "txtTimeStart"
        Me.txtTimeStart.Size = New System.Drawing.Size(155, 21)
        Me.txtTimeStart.TabIndex = 195
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(83, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 198
        Me.Label1.Text = "特殊时间段："
        '
        'txtLineID
        '
        Me.txtLineID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineID.Location = New System.Drawing.Point(165, 28)
        Me.txtLineID.MaxLength = 6
        Me.txtLineID.Name = "txtLineID"
        Me.txtLineID.Size = New System.Drawing.Size(103, 21)
        Me.txtLineID.TabIndex = 201
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(118, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 200
        Me.Label4.Text = "线别："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(118, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 200
        Me.Label2.Text = "理由："
        '
        'txtRemark
        '
        Me.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemark.Location = New System.Drawing.Point(165, 79)
        Me.txtRemark.MaxLength = 6
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(353, 52)
        Me.txtRemark.TabIndex = 201
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(329, 58)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(17, 12)
        Me.Label36.TabIndex = 202
        Me.Label36.Text = "～"
        '
        'dgvQuery
        '
        Me.dgvQuery.AllowUserToAddRows = False
        Me.dgvQuery.AllowUserToDeleteRows = False
        Me.dgvQuery.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvQuery.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvQuery.BackgroundColor = System.Drawing.Color.White
        Me.dgvQuery.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvQuery.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvQuery.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvQuery.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvQuery.ColumnHeadersHeight = 25
        Me.dgvQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.LineID, Me.StartDt, Me.EndDt, Me.Usey, Me.Remark, Me.UserId, Me.Intime})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvQuery.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvQuery.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvQuery.GridColor = System.Drawing.Color.Silver
        Me.dgvQuery.Location = New System.Drawing.Point(1, 159)
        Me.dgvQuery.MultiSelect = False
        Me.dgvQuery.Name = "dgvQuery"
        Me.dgvQuery.ReadOnly = True
        Me.dgvQuery.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvQuery.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvQuery.RowHeadersWidth = 45
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.dgvQuery.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvQuery.RowTemplate.Height = 24
        Me.dgvQuery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvQuery.ShowEditingIcon = False
        Me.dgvQuery.Size = New System.Drawing.Size(715, 258)
        Me.dgvQuery.TabIndex = 203
        Me.dgvQuery.TabStop = False
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'LineID
        '
        Me.LineID.HeaderText = "线别"
        Me.LineID.Name = "LineID"
        Me.LineID.ReadOnly = True
        Me.LineID.Width = 60
        '
        'StartDt
        '
        Me.StartDt.HeaderText = "开始时间"
        Me.StartDt.Name = "StartDt"
        Me.StartDt.ReadOnly = True
        '
        'EndDt
        '
        Me.EndDt.HeaderText = "结束时间"
        Me.EndDt.Name = "EndDt"
        Me.EndDt.ReadOnly = True
        '
        'Usey
        '
        Me.Usey.HeaderText = "有效否"
        Me.Usey.Name = "Usey"
        Me.Usey.ReadOnly = True
        Me.Usey.Width = 80
        '
        'Remark
        '
        Me.Remark.HeaderText = "理由"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        '
        'UserId
        '
        Me.UserId.HeaderText = "维护人"
        Me.UserId.Name = "UserId"
        Me.UserId.ReadOnly = True
        '
        'Intime
        '
        Me.Intime.HeaderText = "维护时间"
        Me.Intime.Name = "Intime"
        Me.Intime.ReadOnly = True
        Me.Intime.Width = 130
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Location = New System.Drawing.Point(120, 132)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(383, 21)
        Me.lblMessage.TabIndex = 204
        Me.lblMessage.Text = "MESSAGE"
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNew, Me.ToolDelete, Me.toolSave, Me.ToolBack, Me.ToolStripSeparator3, Me.ToolQuery, Me.ToolStripSeparator1, Me.ToolExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(720, 25)
        Me.ToolBt.TabIndex = 205
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolNew
        '
        Me.ToolNew.Enabled = False
        Me.ToolNew.ForeColor = System.Drawing.Color.Black
        Me.ToolNew.Image = CType(resources.GetObject("ToolNew.Image"), System.Drawing.Image)
        Me.ToolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolNew.Name = "ToolNew"
        Me.ToolNew.Size = New System.Drawing.Size(74, 22)
        Me.ToolNew.Tag = "NO"
        Me.ToolNew.Text = "新 增(&N)"
        Me.ToolNew.ToolTipText = "新 增"
        '
        'ToolDelete
        '
        Me.ToolDelete.Enabled = False
        Me.ToolDelete.ForeColor = System.Drawing.Color.Black
        Me.ToolDelete.Image = CType(resources.GetObject("ToolDelete.Image"), System.Drawing.Image)
        Me.ToolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolDelete.Name = "ToolDelete"
        Me.ToolDelete.Size = New System.Drawing.Size(73, 22)
        Me.ToolDelete.Tag = "NO"
        Me.ToolDelete.Text = "作 废(&D)"
        Me.ToolDelete.ToolTipText = "删除"
        '
        'toolSave
        '
        Me.toolSave.Image = CType(resources.GetObject("toolSave.Image"), System.Drawing.Image)
        Me.toolSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(73, 22)
        Me.toolSave.Tag = ""
        Me.toolSave.Text = "保 存(&S)"
        '
        'ToolBack
        '
        Me.ToolBack.Image = CType(resources.GetObject("ToolBack.Image"), System.Drawing.Image)
        Me.ToolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolBack.Name = "ToolBack"
        Me.ToolBack.Size = New System.Drawing.Size(68, 22)
        Me.ToolBack.Text = "返回(&B)"
        Me.ToolBack.ToolTipText = "返回"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolQuery
        '
        Me.ToolQuery.ForeColor = System.Drawing.Color.Black
        Me.ToolQuery.Image = CType(resources.GetObject("ToolQuery.Image"), System.Drawing.Image)
        Me.ToolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolQuery.Name = "ToolQuery"
        Me.ToolQuery.Size = New System.Drawing.Size(74, 22)
        Me.ToolQuery.Text = "查 询(&Q)"
        Me.ToolQuery.ToolTipText = "查 詢"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolExitFrom
        '
        Me.ToolExitFrom.ForeColor = System.Drawing.Color.Black
        Me.ToolExitFrom.Image = CType(resources.GetObject("ToolExitFrom.Image"), System.Drawing.Image)
        Me.ToolExitFrom.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolExitFrom.Name = "ToolExitFrom"
        Me.ToolExitFrom.Size = New System.Drawing.Size(72, 22)
        Me.ToolExitFrom.Text = "退 出(&X)"
        Me.ToolExitFrom.ToolTipText = "退 出"
        '
        'FrmLineClassSpecial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 417)
        Me.Controls.Add(Me.ToolBt)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvQuery)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLineID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTimeEnd)
        Me.Controls.Add(Me.txtTimeStart)
        Me.MaximizeBox = False
        Me.Name = "FrmLineClassSpecial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "线别特殊时段维护"
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTimeEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTimeStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLineID As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents dgvQuery As System.Windows.Forms.DataGridView
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExitFrom As System.Windows.Forms.ToolStripButton
    Private WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartDt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndDt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Intime As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents lblMessage As DevComponents.DotNetBar.LabelX
End Class
