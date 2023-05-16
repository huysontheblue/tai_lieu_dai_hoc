<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParetoShowSub
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
        Me.dgvNG = New System.Windows.Forms.DataGridView()
        Me.cboPartID = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboQueryLine = New System.Windows.Forms.ComboBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnBefore = New System.Windows.Forms.Button()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        CType(Me.dgvNG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvNG
        '
        Me.dgvNG.AllowUserToAddRows = False
        Me.dgvNG.AllowUserToDeleteRows = False
        Me.dgvNG.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvNG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNG.Location = New System.Drawing.Point(0, 0)
        Me.dgvNG.Name = "dgvNG"
        Me.dgvNG.ReadOnly = True
        Me.dgvNG.RowHeadersWidth = 35
        Me.dgvNG.RowTemplate.Height = 23
        Me.dgvNG.Size = New System.Drawing.Size(792, 344)
        Me.dgvNG.TabIndex = 1
        '
        'cboPartID
        '
        Me.cboPartID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartID.FormattingEnabled = True
        Me.cboPartID.Location = New System.Drawing.Point(174, 12)
        Me.cboPartID.Name = "cboPartID"
        Me.cboPartID.Size = New System.Drawing.Size(107, 20)
        Me.cboPartID.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 12)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "线别:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(135, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 12)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "料号:"
        '
        'cboQueryLine
        '
        Me.cboQueryLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboQueryLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboQueryLine.FormattingEnabled = True
        Me.cboQueryLine.Location = New System.Drawing.Point(51, 12)
        Me.cboQueryLine.Name = "cboQueryLine"
        Me.cboQueryLine.Size = New System.Drawing.Size(80, 20)
        Me.cboQueryLine.TabIndex = 8
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvNG)
        Me.SplitContainer1.Size = New System.Drawing.Size(792, 399)
        Me.SplitContainer1.SplitterDistance = 51
        Me.SplitContainer1.TabIndex = 13
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtpDate)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblStartDate)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(792, 51)
        Me.SplitContainer2.SplitterDistance = 182
        Me.SplitContainer2.TabIndex = 14
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(61, 10)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(106, 21)
        Me.dtpDate.TabIndex = 3
        '
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = True
        Me.lblStartDate.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.lblStartDate.Location = New System.Drawing.Point(19, 14)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(47, 12)
        Me.lblStartDate.TabIndex = 4
        Me.lblStartDate.Text = "开始日:"
        '
        'btnNext
        '
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNext.Location = New System.Drawing.Point(399, 7)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(25, 30)
        Me.btnNext.TabIndex = 16
        Me.btnNext.Text = ">"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnBefore
        '
        Me.btnBefore.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBefore.Location = New System.Drawing.Point(368, 7)
        Me.btnBefore.Name = "btnBefore"
        Me.btnBefore.Size = New System.Drawing.Size(25, 30)
        Me.btnBefore.TabIndex = 14
        Me.btnBefore.Text = "<"
        Me.btnBefore.UseVisualStyleBackColor = True
        '
        'dtpDateTo
        '
        Me.dtpDateTo.Enabled = False
        Me.dtpDateTo.Location = New System.Drawing.Point(48, 12)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(106, 21)
        Me.dtpDateTo.TabIndex = 14
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.lblEndDate.Location = New System.Drawing.Point(6, 17)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(47, 12)
        Me.lblEndDate.TabIndex = 15
        Me.lblEndDate.Text = "结束日:"
        '
        'btnFind
        '
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFind.Location = New System.Drawing.Point(287, 7)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(70, 30)
        Me.btnFind.TabIndex = 13
        Me.btnFind.Text = "查找"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.dtpDateTo)
        Me.SplitContainer3.Panel1.Controls.Add(Me.lblEndDate)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.btnNext)
        Me.SplitContainer3.Panel2.Controls.Add(Me.cboPartID)
        Me.SplitContainer3.Panel2.Controls.Add(Me.btnBefore)
        Me.SplitContainer3.Panel2.Controls.Add(Me.cboQueryLine)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer3.Panel2.Controls.Add(Me.btnFind)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label9)
        Me.SplitContainer3.Size = New System.Drawing.Size(606, 51)
        Me.SplitContainer3.SplitterDistance = 161
        Me.SplitContainer3.TabIndex = 2
        '
        'FrmParetoShowSub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 399)
        Me.Controls.Add(Me.SplitContainer1)
        Me.MaximizeBox = False
        Me.Name = "FrmParetoShowSub"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "不良参照查询（前一天数据）"
        CType(Me.dgvNG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        Me.SplitContainer3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvNG As System.Windows.Forms.DataGridView
    Friend WithEvents cboPartID As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboQueryLine As System.Windows.Forms.ComboBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents dtpDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents btnBefore As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
End Class
