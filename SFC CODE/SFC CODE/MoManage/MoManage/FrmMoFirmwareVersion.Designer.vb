<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMoFirmwareVersion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMoFirmwareVersion))
        Me.label1 = New System.Windows.Forms.Label()
        Me.dgvQuery = New System.Windows.Forms.DataGridView()
        Me.moid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ppartid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FirmwareVersion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HardwareVersion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.userid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolEdit = New System.Windows.Forms.ToolStripButton()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExit = New System.Windows.Forms.ToolStripButton()
        Me.txtMoId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPartId = New System.Windows.Forms.TextBox()
        Me.txtFirmwareVersion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHardwareVersion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolBt.SuspendLayout()
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.ForeColor = System.Drawing.Color.Black
        Me.label1.Location = New System.Drawing.Point(31, 45)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(41, 12)
        Me.label1.TabIndex = 2
        Me.label1.Text = "工单："
        '
        'dgvQuery
        '
        Me.dgvQuery.AllowUserToAddRows = False
        Me.dgvQuery.AllowUserToDeleteRows = False
        Me.dgvQuery.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvQuery.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvQuery.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
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
        Me.dgvQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.moid, Me.ppartid, Me.FirmwareVersion, Me.HardwareVersion, Me.userid, Me.UpdateTime})
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
        Me.dgvQuery.Location = New System.Drawing.Point(0, 80)
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
        Me.dgvQuery.Size = New System.Drawing.Size(857, 343)
        Me.dgvQuery.TabIndex = 158
        Me.dgvQuery.TabStop = False
        '
        'moid
        '
        Me.moid.HeaderText = "工单"
        Me.moid.Name = "moid"
        Me.moid.ReadOnly = True
        Me.moid.Width = 56
        '
        'ppartid
        '
        Me.ppartid.HeaderText = "料号"
        Me.ppartid.Name = "ppartid"
        Me.ppartid.ReadOnly = True
        Me.ppartid.Width = 56
        '
        'FirmwareVersion
        '
        Me.FirmwareVersion.HeaderText = "固件版本"
        Me.FirmwareVersion.Name = "FirmwareVersion"
        Me.FirmwareVersion.ReadOnly = True
        Me.FirmwareVersion.Width = 80
        '
        'HardwareVersion
        '
        Me.HardwareVersion.HeaderText = "硬件版本"
        Me.HardwareVersion.Name = "HardwareVersion"
        Me.HardwareVersion.ReadOnly = True
        Me.HardwareVersion.Width = 80
        '
        'userid
        '
        Me.userid.HeaderText = "维护人"
        Me.userid.Name = "userid"
        Me.userid.ReadOnly = True
        Me.userid.Width = 68
        '
        'UpdateTime
        '
        Me.UpdateTime.HeaderText = "维护时间"
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.ReadOnly = True
        Me.UpdateTime.Width = 80
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNew, Me.ToolEdit, Me.toolSave, Me.ToolBack, Me.ToolStripSeparator3, Me.ToolQuery, Me.ToolStripSeparator1, Me.ToolExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(859, 25)
        Me.ToolBt.TabIndex = 159
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolNew
        '
        Me.ToolNew.ForeColor = System.Drawing.Color.Black
        Me.ToolNew.Image = CType(resources.GetObject("ToolNew.Image"), System.Drawing.Image)
        Me.ToolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolNew.Name = "ToolNew"
        Me.ToolNew.Size = New System.Drawing.Size(74, 22)
        Me.ToolNew.Tag = "NO"
        Me.ToolNew.Text = "新 增(&N)"
        Me.ToolNew.ToolTipText = "新 增"
        '
        'ToolEdit
        '
        Me.ToolEdit.ForeColor = System.Drawing.Color.Black
        Me.ToolEdit.Image = CType(resources.GetObject("ToolEdit.Image"), System.Drawing.Image)
        Me.ToolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEdit.Name = "ToolEdit"
        Me.ToolEdit.Size = New System.Drawing.Size(71, 22)
        Me.ToolEdit.Tag = "NO"
        Me.ToolEdit.Text = "修 改(&E)"
        Me.ToolEdit.ToolTipText = "修 改"
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
        'ToolExit
        '
        Me.ToolExit.ForeColor = System.Drawing.Color.Black
        Me.ToolExit.Image = CType(resources.GetObject("ToolExit.Image"), System.Drawing.Image)
        Me.ToolExit.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolExit.Name = "ToolExit"
        Me.ToolExit.Size = New System.Drawing.Size(72, 22)
        Me.ToolExit.Text = "退 出(&X)"
        Me.ToolExit.ToolTipText = "退 出"
        '
        'txtMoId
        '
        Me.txtMoId.BackColor = System.Drawing.SystemColors.Window
        Me.txtMoId.Enabled = False
        Me.txtMoId.Location = New System.Drawing.Point(68, 41)
        Me.txtMoId.Name = "txtMoId"
        Me.txtMoId.Size = New System.Drawing.Size(128, 21)
        Me.txtMoId.TabIndex = 160
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(213, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 166
        Me.Label2.Text = "料号："
        '
        'txtPartId
        '
        Me.txtPartId.BackColor = System.Drawing.SystemColors.Window
        Me.txtPartId.Enabled = False
        Me.txtPartId.Location = New System.Drawing.Point(248, 41)
        Me.txtPartId.Name = "txtPartId"
        Me.txtPartId.Size = New System.Drawing.Size(128, 21)
        Me.txtPartId.TabIndex = 167
        '
        'txtFirmwareVersion
        '
        Me.txtFirmwareVersion.Location = New System.Drawing.Point(450, 41)
        Me.txtFirmwareVersion.Name = "txtFirmwareVersion"
        Me.txtFirmwareVersion.Size = New System.Drawing.Size(165, 21)
        Me.txtFirmwareVersion.TabIndex = 169
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(390, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 168
        Me.Label3.Text = "固件版本："
        '
        'txtHardwareVersion
        '
        Me.txtHardwareVersion.Location = New System.Drawing.Point(686, 42)
        Me.txtHardwareVersion.Name = "txtHardwareVersion"
        Me.txtHardwareVersion.Size = New System.Drawing.Size(140, 21)
        Me.txtHardwareVersion.TabIndex = 171
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(626, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 170
        Me.Label4.Text = "硬件版本："
        '
        'FrmMoFirmwareVersion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 448)
        Me.Controls.Add(Me.txtHardwareVersion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFirmwareVersion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPartId)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMoId)
        Me.Controls.Add(Me.ToolBt)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.dgvQuery)
        Me.Name = "FrmMoFirmwareVersion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "工单固件版本维护"
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents dgvQuery As System.Windows.Forms.DataGridView
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolEdit As System.Windows.Forms.ToolStripButton
    Private WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtMoId As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPartId As System.Windows.Forms.TextBox
    Friend WithEvents txtFirmwareVersion As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHardwareVersion As System.Windows.Forms.TextBox
    Private WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents moid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ppartid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FirmwareVersion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HardwareVersion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents userid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
