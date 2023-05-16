<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMaintenanceDetails
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgvMonth = New System.Windows.Forms.DataGridView()
        Me.dgvQuarter = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.dtpYear = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AssetNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaintenanceProject = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Months = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AssetNoQ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaintenanceProjectQ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quarter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateTimeQ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvQuarter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvMonth)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvQuarter)
        Me.SplitContainer1.Size = New System.Drawing.Size(1041, 469)
        Me.SplitContainer1.SplitterDistance = 499
        Me.SplitContainer1.TabIndex = 0
        '
        'dgvMonth
        '
        Me.dgvMonth.AllowUserToAddRows = False
        Me.dgvMonth.AllowUserToDeleteRows = False
        Me.dgvMonth.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMonth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMonth.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AssetNo, Me.MaintenanceProject, Me.Months, Me.CreateTime})
        Me.dgvMonth.Location = New System.Drawing.Point(0, 33)
        Me.dgvMonth.Name = "dgvMonth"
        Me.dgvMonth.ReadOnly = True
        Me.dgvMonth.RowHeadersVisible = False
        Me.dgvMonth.RowTemplate.Height = 23
        Me.dgvMonth.Size = New System.Drawing.Size(497, 434)
        Me.dgvMonth.TabIndex = 0
        '
        'dgvQuarter
        '
        Me.dgvQuarter.AllowUserToAddRows = False
        Me.dgvQuarter.AllowUserToDeleteRows = False
        Me.dgvQuarter.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvQuarter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQuarter.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AssetNoQ, Me.MaintenanceProjectQ, Me.Quarter, Me.CreateTimeQ})
        Me.dgvQuarter.Location = New System.Drawing.Point(0, 33)
        Me.dgvQuarter.Name = "dgvQuarter"
        Me.dgvQuarter.ReadOnly = True
        Me.dgvQuarter.RowHeadersVisible = False
        Me.dgvQuarter.RowTemplate.Height = 23
        Me.dgvQuarter.Size = New System.Drawing.Size(542, 434)
        Me.dgvQuarter.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnSearch)
        Me.Panel1.Controls.Add(Me.dtpYear)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1041, 34)
        Me.Panel1.TabIndex = 1
        '
        'BtnSearch
        '
        Me.BtnSearch.Location = New System.Drawing.Point(174, 8)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(75, 23)
        Me.BtnSearch.TabIndex = 2
        Me.BtnSearch.Text = "查询"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'dtpYear
        '
        Me.dtpYear.CustomFormat = "yyyy"
        Me.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpYear.Location = New System.Drawing.Point(94, 8)
        Me.dtpYear.Name = "dtpYear"
        Me.dtpYear.Size = New System.Drawing.Size(47, 21)
        Me.dtpYear.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(39, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "年份:"
        '
        'AssetNo
        '
        Me.AssetNo.DataPropertyName = "AssetNo"
        Me.AssetNo.FillWeight = 110.0!
        Me.AssetNo.HeaderText = "设备编号"
        Me.AssetNo.Name = "AssetNo"
        Me.AssetNo.ReadOnly = True
        Me.AssetNo.Width = 130
        '
        'MaintenanceProject
        '
        Me.MaintenanceProject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.MaintenanceProject.DataPropertyName = "MaintenanceProject"
        Me.MaintenanceProject.FillWeight = 110.0!
        Me.MaintenanceProject.HeaderText = "保养项目"
        Me.MaintenanceProject.Name = "MaintenanceProject"
        Me.MaintenanceProject.ReadOnly = True
        '
        'Months
        '
        Me.Months.DataPropertyName = "Months"
        Me.Months.HeaderText = "月份"
        Me.Months.Name = "Months"
        Me.Months.ReadOnly = True
        Me.Months.Width = 55
        '
        'CreateTime
        '
        Me.CreateTime.DataPropertyName = "CreateTime"
        Me.CreateTime.HeaderText = "保养时间"
        Me.CreateTime.Name = "CreateTime"
        Me.CreateTime.ReadOnly = True
        Me.CreateTime.Visible = False
        '
        'AssetNoQ
        '
        Me.AssetNoQ.DataPropertyName = "AssetNo"
        Me.AssetNoQ.HeaderText = "设备编号"
        Me.AssetNoQ.Name = "AssetNoQ"
        Me.AssetNoQ.ReadOnly = True
        Me.AssetNoQ.Width = 130
        '
        'MaintenanceProjectQ
        '
        Me.MaintenanceProjectQ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.MaintenanceProjectQ.DataPropertyName = "MaintenanceProject"
        Me.MaintenanceProjectQ.HeaderText = "保养项目"
        Me.MaintenanceProjectQ.Name = "MaintenanceProjectQ"
        Me.MaintenanceProjectQ.ReadOnly = True
        '
        'Quarter
        '
        Me.Quarter.DataPropertyName = "Quarter"
        Me.Quarter.HeaderText = "季度"
        Me.Quarter.Name = "Quarter"
        Me.Quarter.ReadOnly = True
        Me.Quarter.Width = 55
        '
        'CreateTimeQ
        '
        Me.CreateTimeQ.DataPropertyName = "CreateTime"
        Me.CreateTimeQ.HeaderText = "保养时间"
        Me.CreateTimeQ.Name = "CreateTimeQ"
        Me.CreateTimeQ.ReadOnly = True
        Me.CreateTimeQ.Visible = False
        '
        'FrmMaintenanceDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1041, 469)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmMaintenanceDetails"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "保养明细"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvQuarter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvMonth As System.Windows.Forms.DataGridView
    Friend WithEvents dgvQuarter As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpYear As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents AssetNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaintenanceProject As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Months As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssetNoQ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaintenanceProjectQ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quarter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateTimeQ As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
