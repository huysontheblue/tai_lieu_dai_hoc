<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLifecontrol
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLifecontrol))
        Me.dgvBasis = New System.Windows.Forms.DataGridView()
        Me.CheckDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.moud = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OutLineID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Parts = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TheDayUseTimes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckedTimes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dtCheckDate1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtCheckDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMouldID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvBasis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvBasis
        '
        Me.dgvBasis.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvBasis.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBasis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBasis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CheckDate, Me.moud, Me.OutLineID, Me.Parts, Me.TheDayUseTimes, Me.CheckedTimes, Me.UserName})
        Me.dgvBasis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBasis.Location = New System.Drawing.Point(0, 0)
        Me.dgvBasis.Name = "dgvBasis"
        Me.dgvBasis.ReadOnly = True
        Me.dgvBasis.RowTemplate.Height = 23
        Me.dgvBasis.Size = New System.Drawing.Size(973, 331)
        Me.dgvBasis.TabIndex = 1
        '
        'CheckDate
        '
        Me.CheckDate.DataPropertyName = "CheckDate"
        Me.CheckDate.HeaderText = "日期"
        Me.CheckDate.Name = "CheckDate"
        Me.CheckDate.ReadOnly = True
        '
        'moud
        '
        Me.moud.DataPropertyName = "MouldID"
        Me.moud.HeaderText = "模号"
        Me.moud.Name = "moud"
        Me.moud.ReadOnly = True
        '
        'OutLineID
        '
        Me.OutLineID.DataPropertyName = "OutLineID"
        Me.OutLineID.HeaderText = "线别"
        Me.OutLineID.Name = "OutLineID"
        Me.OutLineID.ReadOnly = True
        '
        'Parts
        '
        Me.Parts.DataPropertyName = "Parts"
        Me.Parts.HeaderText = "料号"
        Me.Parts.Name = "Parts"
        Me.Parts.ReadOnly = True
        '
        'TheDayUseTimes
        '
        Me.TheDayUseTimes.DataPropertyName = "TheDayUseTimes"
        Me.TheDayUseTimes.HeaderText = "使用次数"
        Me.TheDayUseTimes.Name = "TheDayUseTimes"
        Me.TheDayUseTimes.ReadOnly = True
        '
        'CheckedTimes
        '
        Me.CheckedTimes.DataPropertyName = "CheckedTimes"
        Me.CheckedTimes.HeaderText = "累计使用次数"
        Me.CheckedTimes.Name = "CheckedTimes"
        Me.CheckedTimes.ReadOnly = True
        '
        'UserName
        '
        Me.UserName.DataPropertyName = "UserName"
        Me.UserName.HeaderText = "使用人"
        Me.UserName.Name = "UserName"
        Me.UserName.ReadOnly = True
        '
        'toolQuery
        '
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(70, 22)
        Me.toolQuery.Text = "查 询(&F)"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolQuery})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(973, 25)
        Me.ToolStrip1.TabIndex = 231
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtCheckDate1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtCheckDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMouldID)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvBasis)
        Me.SplitContainer1.Size = New System.Drawing.Size(973, 433)
        Me.SplitContainer1.SplitterDistance = 98
        Me.SplitContainer1.TabIndex = 231
        '
        'dtCheckDate1
        '
        Me.dtCheckDate1.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.dtCheckDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtCheckDate1.Location = New System.Drawing.Point(536, 32)
        Me.dtCheckDate1.Name = "dtCheckDate1"
        Me.dtCheckDate1.Size = New System.Drawing.Size(152, 21)
        Me.dtCheckDate1.TabIndex = 235
        Me.dtCheckDate1.Value = New Date(2019, 3, 29, 0, 25, 49, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(468, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 234
        Me.Label3.Text = "终止时间："
        '
        'dtCheckDate
        '
        Me.dtCheckDate.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.dtCheckDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtCheckDate.Location = New System.Drawing.Point(293, 32)
        Me.dtCheckDate.Name = "dtCheckDate"
        Me.dtCheckDate.Size = New System.Drawing.Size(152, 21)
        Me.dtCheckDate.TabIndex = 233
        Me.dtCheckDate.Value = New Date(2019, 3, 29, 0, 25, 49, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(225, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 232
        Me.Label2.Text = "起始时间："
        '
        'txtMouldID
        '
        Me.txtMouldID.Location = New System.Drawing.Point(47, 32)
        Me.txtMouldID.Name = "txtMouldID"
        Me.txtMouldID.ReadOnly = True
        Me.txtMouldID.Size = New System.Drawing.Size(158, 21)
        Me.txtMouldID.TabIndex = 224
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 223
        Me.Label1.Text = "模号："
        '
        'FrmLifecontrol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 433)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmLifecontrol"
        Me.Text = "寿命管制明细"
        CType(Me.dgvBasis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvBasis As System.Windows.Forms.DataGridView
    Friend WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtMouldID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtCheckDate1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtCheckDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents moud As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutLineID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Parts As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TheDayUseTimes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckedTimes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
