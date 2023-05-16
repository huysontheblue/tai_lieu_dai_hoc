<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEMCEquipmentconfig
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.NO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StationName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EquimentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EquimentNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApplicationDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExpirationDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiSubmit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiDelete = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvData
        '
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NO, Me.StationName, Me.EquimentName, Me.EquimentNO, Me.EmpCode, Me.EmpName, Me.JobName, Me.ApplicationDate, Me.ExpirationDate, Me.Status})
        Me.dgvData.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvData.Location = New System.Drawing.Point(2, 1)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowTemplate.Height = 23
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(1035, 534)
        Me.dgvData.TabIndex = 0
        '
        'NO
        '
        Me.NO.DataPropertyName = "NO"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NO.DefaultCellStyle = DataGridViewCellStyle1
        Me.NO.HeaderText = "NO."
        Me.NO.Name = "NO"
        Me.NO.ReadOnly = True
        Me.NO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NO.Width = 30
        '
        'StationName
        '
        Me.StationName.DataPropertyName = "StationName"
        Me.StationName.HeaderText = "工站名称"
        Me.StationName.Name = "StationName"
        Me.StationName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.StationName.Width = 120
        '
        'EquimentName
        '
        Me.EquimentName.DataPropertyName = "EquimentName"
        Me.EquimentName.HeaderText = "设备名称"
        Me.EquimentName.Name = "EquimentName"
        Me.EquimentName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EquimentName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EquimentName.Width = 110
        '
        'EquimentNO
        '
        Me.EquimentNO.DataPropertyName = "EquimentNO"
        Me.EquimentNO.HeaderText = "设备编码"
        Me.EquimentNO.Name = "EquimentNO"
        Me.EquimentNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EquimentNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EquimentNO.Width = 110
        '
        'EmpCode
        '
        Me.EmpCode.DataPropertyName = "EmpCode"
        Me.EmpCode.HeaderText = "操作人工号"
        Me.EmpCode.Name = "EmpCode"
        Me.EmpCode.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EmpCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'EmpName
        '
        Me.EmpName.DataPropertyName = "EmpName"
        Me.EmpName.HeaderText = "操作人姓名"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.ReadOnly = True
        Me.EmpName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EmpName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'JobName
        '
        Me.JobName.DataPropertyName = "JobName"
        Me.JobName.HeaderText = "岗位名称"
        Me.JobName.Name = "JobName"
        Me.JobName.ReadOnly = True
        Me.JobName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.JobName.Width = 110
        '
        'ApplicationDate
        '
        Me.ApplicationDate.DataPropertyName = "ApplicationDate"
        DataGridViewCellStyle2.Format = "yyyy-MM-dd"
        Me.ApplicationDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.ApplicationDate.HeaderText = "申请日期"
        Me.ApplicationDate.Name = "ApplicationDate"
        Me.ApplicationDate.ReadOnly = True
        Me.ApplicationDate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ApplicationDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ExpirationDate
        '
        Me.ExpirationDate.DataPropertyName = "ExpirationDate"
        DataGridViewCellStyle3.Format = "yyyy-MM-dd"
        Me.ExpirationDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.ExpirationDate.HeaderText = "失效日期"
        Me.ExpirationDate.Name = "ExpirationDate"
        Me.ExpirationDate.ReadOnly = True
        Me.ExpirationDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "状态"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiSubmit, Me.tsmiDelete})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(101, 48)
        '
        'tsmiSubmit
        '
        Me.tsmiSubmit.Name = "tsmiSubmit"
        Me.tsmiSubmit.Size = New System.Drawing.Size(100, 22)
        Me.tsmiSubmit.Text = "提交"
        '
        'tsmiDelete
        '
        Me.tsmiDelete.Name = "tsmiDelete"
        Me.tsmiDelete.Size = New System.Drawing.Size(100, 22)
        Me.tsmiDelete.Text = "删除"
        '
        'FrmEMCEquipmentconfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1037, 535)
        Me.Controls.Add(Me.dgvData)
        Me.Name = "FrmEMCEquipmentconfig"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "外部高速产品设备配置信息"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiSubmit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StationName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EquimentName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EquimentNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JobName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApplicationDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExpirationDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
