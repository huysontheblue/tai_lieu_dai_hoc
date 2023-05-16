<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductionLineBoard
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
        Me.chkStop = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.dgvProductionLine = New System.Windows.Forms.DataGridView()
        Me.lblRemain = New System.Windows.Forms.Label()
        Me.dgvID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AppUserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EquipmentPNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeptID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Line = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.M = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txFactoryName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txProfitcenter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvProductionLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkStop
        '
        Me.chkStop.AutoSize = True
        Me.chkStop.Font = New System.Drawing.Font("仿宋", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.chkStop.Location = New System.Drawing.Point(40, 5)
        Me.chkStop.Name = "chkStop"
        Me.chkStop.Size = New System.Drawing.Size(129, 28)
        Me.chkStop.TabIndex = 1
        Me.chkStop.Text = "暂停显示"
        Me.chkStop.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("仿宋", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(502, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'dgvProductionLine
        '
        Me.dgvProductionLine.AllowUserToAddRows = False
        Me.dgvProductionLine.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProductionLine.BackgroundColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductionLine.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProductionLine.ColumnHeadersHeight = 55
        Me.dgvProductionLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvProductionLine.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvID, Me.AppUserName, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.EquipmentPNumber, Me.DeptID, Me.Line, Me.DataGridViewTextBoxColumn20, Me.Status, Me.Intime, Me.M, Me.txFactoryName, Me.txProfitcenter, Me.txtId})
        Me.dgvProductionLine.Location = New System.Drawing.Point(2, 34)
        Me.dgvProductionLine.Name = "dgvProductionLine"
        Me.dgvProductionLine.ReadOnly = True
        Me.dgvProductionLine.RowHeadersVisible = False
        Me.dgvProductionLine.RowTemplate.Height = 50
        Me.dgvProductionLine.Size = New System.Drawing.Size(1362, 668)
        Me.dgvProductionLine.TabIndex = 12
        '
        'lblRemain
        '
        Me.lblRemain.AutoSize = True
        Me.lblRemain.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblRemain.Location = New System.Drawing.Point(703, 7)
        Me.lblRemain.Name = "lblRemain"
        Me.lblRemain.Size = New System.Drawing.Size(85, 24)
        Me.lblRemain.TabIndex = 13
        Me.lblRemain.Text = "倒计时"
        '
        'dgvID
        '
        Me.dgvID.HeaderText = "序号"
        Me.dgvID.Name = "dgvID"
        Me.dgvID.ReadOnly = True
        Me.dgvID.Width = 50
        '
        'AppUserName
        '
        Me.AppUserName.HeaderText = "申请人"
        Me.AppUserName.Name = "AppUserName"
        Me.AppUserName.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "工单编号"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Visible = False
        Me.DataGridViewTextBoxColumn12.Width = 250
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "生产料号"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Visible = False
        Me.DataGridViewTextBoxColumn13.Width = 110
        '
        'EquipmentPNumber
        '
        Me.EquipmentPNumber.HeaderText = "工治具料号"
        Me.EquipmentPNumber.Name = "EquipmentPNumber"
        Me.EquipmentPNumber.ReadOnly = True
        Me.EquipmentPNumber.Width = 250
        '
        'DeptID
        '
        Me.DeptID.HeaderText = "课别"
        Me.DeptID.Name = "DeptID"
        Me.DeptID.ReadOnly = True
        Me.DeptID.Width = 150
        '
        'Line
        '
        Me.Line.HeaderText = "线别"
        Me.Line.Name = "Line"
        Me.Line.ReadOnly = True
        Me.Line.Width = 80
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.HeaderText = "剩余需求"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Width = 90
        '
        'Status
        '
        Me.Status.HeaderText = "状态"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 80
        '
        'Intime
        '
        Me.Intime.HeaderText = "申请时间"
        Me.Intime.Name = "Intime"
        Me.Intime.ReadOnly = True
        Me.Intime.Width = 150
        '
        'M
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.M.DefaultCellStyle = DataGridViewCellStyle2
        Me.M.HeaderText = "申请时长(min)"
        Me.M.Name = "M"
        Me.M.ReadOnly = True
        Me.M.Width = 130
        '
        'txFactoryName
        '
        Me.txFactoryName.HeaderText = "厂区"
        Me.txFactoryName.Name = "txFactoryName"
        Me.txFactoryName.ReadOnly = True
        Me.txFactoryName.Visible = False
        Me.txFactoryName.Width = 75
        '
        'txProfitcenter
        '
        Me.txProfitcenter.HeaderText = "利润中心"
        Me.txProfitcenter.Name = "txProfitcenter"
        Me.txProfitcenter.ReadOnly = True
        Me.txProfitcenter.Visible = False
        Me.txProfitcenter.Width = 95
        '
        'txtId
        '
        Me.txtId.HeaderText = "编号"
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Visible = False
        '
        'FrmProductionLineBoard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1362, 721)
        Me.Controls.Add(Me.lblRemain)
        Me.Controls.Add(Me.dgvProductionLine)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkStop)
        Me.Name = "FrmProductionLineBoard"
        Me.Text = "工治具－产线看板"
        CType(Me.dgvProductionLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkStop As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents dgvProductionLine As System.Windows.Forms.DataGridView
    Friend WithEvents lblRemain As System.Windows.Forms.Label
    Friend WithEvents dgvID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AppUserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EquipmentPNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Line As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Intime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents M As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txFactoryName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txProfitcenter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtId As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
