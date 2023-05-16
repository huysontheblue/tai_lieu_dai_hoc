<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmShowEquList
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Consumable = New System.Windows.Forms.TabPage()
        Me.dgvConsumble = New System.Windows.Forms.DataGridView()
        Me.UsedTimes = New System.Windows.Forms.TabPage()
        Me.dgvEquUsedTimes = New System.Windows.Forms.DataGridView()
        Me.KeepQuarter = New System.Windows.Forms.TabPage()
        Me.dgvKeepQuarter = New System.Windows.Forms.DataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblRemain = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkStop = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.Consumable.SuspendLayout()
        CType(Me.dgvConsumble, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UsedTimes.SuspendLayout()
        CType(Me.dgvEquUsedTimes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KeepQuarter.SuspendLayout()
        CType(Me.dgvKeepQuarter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Consumable)
        Me.TabControl1.Controls.Add(Me.UsedTimes)
        Me.TabControl1.Controls.Add(Me.KeepQuarter)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1024, 459)
        Me.TabControl1.TabIndex = 0
        '
        'Consumable
        '
        Me.Consumable.Controls.Add(Me.dgvConsumble)
        Me.Consumable.Location = New System.Drawing.Point(4, 22)
        Me.Consumable.Name = "Consumable"
        Me.Consumable.Padding = New System.Windows.Forms.Padding(3)
        Me.Consumable.Size = New System.Drawing.Size(1016, 433)
        Me.Consumable.TabIndex = 0
        Me.Consumable.Text = "消耗品管制"
        Me.Consumable.UseVisualStyleBackColor = True
        '
        'dgvConsumble
        '
        Me.dgvConsumble.AllowUserToAddRows = False
        Me.dgvConsumble.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvConsumble.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConsumble.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConsumble.Location = New System.Drawing.Point(3, 3)
        Me.dgvConsumble.Name = "dgvConsumble"
        Me.dgvConsumble.RowHeadersVisible = False
        Me.dgvConsumble.RowTemplate.Height = 23
        Me.dgvConsumble.Size = New System.Drawing.Size(1010, 427)
        Me.dgvConsumble.TabIndex = 0
        '
        'UsedTimes
        '
        Me.UsedTimes.Controls.Add(Me.dgvEquUsedTimes)
        Me.UsedTimes.Location = New System.Drawing.Point(4, 22)
        Me.UsedTimes.Name = "UsedTimes"
        Me.UsedTimes.Padding = New System.Windows.Forms.Padding(3)
        Me.UsedTimes.Size = New System.Drawing.Size(1016, 433)
        Me.UsedTimes.TabIndex = 1
        Me.UsedTimes.Text = "治具寿命预警"
        Me.UsedTimes.UseVisualStyleBackColor = True
        '
        'dgvEquUsedTimes
        '
        Me.dgvEquUsedTimes.AllowUserToAddRows = False
        Me.dgvEquUsedTimes.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvEquUsedTimes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEquUsedTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEquUsedTimes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEquUsedTimes.Location = New System.Drawing.Point(3, 3)
        Me.dgvEquUsedTimes.Name = "dgvEquUsedTimes"
        Me.dgvEquUsedTimes.RowHeadersVisible = False
        Me.dgvEquUsedTimes.RowTemplate.Height = 23
        Me.dgvEquUsedTimes.Size = New System.Drawing.Size(1010, 427)
        Me.dgvEquUsedTimes.TabIndex = 1
        '
        'KeepQuarter
        '
        Me.KeepQuarter.Controls.Add(Me.dgvKeepQuarter)
        Me.KeepQuarter.Location = New System.Drawing.Point(4, 22)
        Me.KeepQuarter.Name = "KeepQuarter"
        Me.KeepQuarter.Padding = New System.Windows.Forms.Padding(3)
        Me.KeepQuarter.Size = New System.Drawing.Size(1016, 433)
        Me.KeepQuarter.TabIndex = 2
        Me.KeepQuarter.Text = "保养管制"
        Me.KeepQuarter.UseVisualStyleBackColor = True
        '
        'dgvKeepQuarter
        '
        Me.dgvKeepQuarter.AllowUserToAddRows = False
        Me.dgvKeepQuarter.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvKeepQuarter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvKeepQuarter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvKeepQuarter.Location = New System.Drawing.Point(3, 3)
        Me.dgvKeepQuarter.Name = "dgvKeepQuarter"
        Me.dgvKeepQuarter.RowHeadersVisible = False
        Me.dgvKeepQuarter.RowTemplate.Height = 23
        Me.dgvKeepQuarter.Size = New System.Drawing.Size(1010, 427)
        Me.dgvKeepQuarter.TabIndex = 1
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'lblRemain
        '
        Me.lblRemain.AutoSize = True
        Me.lblRemain.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblRemain.Location = New System.Drawing.Point(529, 2)
        Me.lblRemain.Name = "lblRemain"
        Me.lblRemain.Size = New System.Drawing.Size(85, 24)
        Me.lblRemain.TabIndex = 4
        Me.lblRemain.Text = "倒计时"
        Me.lblRemain.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(740, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'chkStop
        '
        Me.chkStop.AutoSize = True
        Me.chkStop.Font = New System.Drawing.Font("仿宋", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.chkStop.Location = New System.Drawing.Point(235, -2)
        Me.chkStop.Name = "chkStop"
        Me.chkStop.Size = New System.Drawing.Size(129, 28)
        Me.chkStop.TabIndex = 6
        Me.chkStop.Text = "暂停显示"
        Me.chkStop.UseVisualStyleBackColor = True
        Me.chkStop.Visible = False
        '
        'FrmShowEquList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 459)
        Me.Controls.Add(Me.chkStop)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblRemain)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmShowEquList"
        Me.Text = "工治具轮播看板"
        Me.TabControl1.ResumeLayout(False)
        Me.Consumable.ResumeLayout(False)
        CType(Me.dgvConsumble, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UsedTimes.ResumeLayout(False)
        CType(Me.dgvEquUsedTimes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KeepQuarter.ResumeLayout(False)
        CType(Me.dgvKeepQuarter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Consumable As System.Windows.Forms.TabPage
    Friend WithEvents dgvConsumble As System.Windows.Forms.DataGridView
    Friend WithEvents UsedTimes As System.Windows.Forms.TabPage
    Friend WithEvents dgvEquUsedTimes As System.Windows.Forms.DataGridView
    Friend WithEvents KeepQuarter As System.Windows.Forms.TabPage
    Friend WithEvents dgvKeepQuarter As System.Windows.Forms.DataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblRemain As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkStop As System.Windows.Forms.CheckBox
End Class
