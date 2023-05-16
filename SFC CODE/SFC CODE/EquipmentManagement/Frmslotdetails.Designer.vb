<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmslotdetails
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvBasis = New System.Windows.Forms.DataGridView()
        Me.Mould = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Slots = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Parts = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Storage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Line = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Library = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvBasis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvBasis)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(667, 429)
        Me.Panel1.TabIndex = 0
        '
        'dgvBasis
        '
        Me.dgvBasis.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvBasis.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBasis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBasis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBasis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Mould, Me.Slots, Me.Parts, Me.Storage, Me.Line, Me.Library})
        Me.dgvBasis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBasis.Location = New System.Drawing.Point(0, 0)
        Me.dgvBasis.Name = "dgvBasis"
        Me.dgvBasis.ReadOnly = True
        Me.dgvBasis.RowTemplate.Height = 23
        Me.dgvBasis.Size = New System.Drawing.Size(667, 429)
        Me.dgvBasis.TabIndex = 2
        '
        'Mould
        '
        Me.Mould.DataPropertyName = "MouldID"
        Me.Mould.HeaderText = "模具号"
        Me.Mould.Name = "Mould"
        Me.Mould.ReadOnly = True
        '
        'Slots
        '
        Me.Slots.DataPropertyName = "Slots"
        Me.Slots.HeaderText = "线槽"
        Me.Slots.Name = "Slots"
        Me.Slots.ReadOnly = True
        '
        'Parts
        '
        Me.Parts.DataPropertyName = "Parts"
        Me.Parts.HeaderText = "机种"
        Me.Parts.Name = "Parts"
        Me.Parts.ReadOnly = True
        '
        'Storage
        '
        Me.Storage.DataPropertyName = "Storage"
        Me.Storage.HeaderText = "储位"
        Me.Storage.Name = "Storage"
        Me.Storage.ReadOnly = True
        '
        'Line
        '
        Me.Line.DataPropertyName = "Line"
        Me.Line.HeaderText = "线别"
        Me.Line.Name = "Line"
        Me.Line.ReadOnly = True
        '
        'Library
        '
        Me.Library.DataPropertyName = "Library"
        Me.Library.HeaderText = "在库"
        Me.Library.Name = "Library"
        Me.Library.ReadOnly = True
        '
        'Frmslotdetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 429)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frmslotdetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "模具详细资料"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvBasis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvBasis As System.Windows.Forms.DataGridView
    Friend WithEvents Mould As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Slots As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Parts As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Storage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Line As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Library As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
