<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWpartNumber
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnPrintAll = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvPartNumber = New System.Windows.Forms.DataGridView
        Me.cbkPrint = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.JobNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrintNumbers = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Lot = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Adress = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCategory = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtPartNumber = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.lblMsg = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbxPrint = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTimes = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPnForPrint = New System.Windows.Forms.TextBox
        CType(Me.dgvPartNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(646, 20)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "确认"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnPrintAll
        '
        Me.btnPrintAll.Enabled = False
        Me.btnPrintAll.Location = New System.Drawing.Point(540, 49)
        Me.btnPrintAll.Name = "btnPrintAll"
        Me.btnPrintAll.Size = New System.Drawing.Size(75, 23)
        Me.btnPrintAll.TabIndex = 1
        Me.btnPrintAll.Text = "全部打印"
        Me.btnPrintAll.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Enabled = False
        Me.btnPrint.Location = New System.Drawing.Point(450, 49)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 2
        Me.btnPrint.Text = "打印"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "发料单号:"
        '
        'dgvPartNumber
        '
        Me.dgvPartNumber.AllowUserToAddRows = False
        Me.dgvPartNumber.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPartNumber.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPartNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartNumber.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cbkPrint, Me.JobNumber, Me.PartNumber, Me.Quantity, Me.PrintNumbers, Me.Lot, Me.Adress, Me.LineCategory})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPartNumber.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPartNumber.Location = New System.Drawing.Point(40, 113)
        Me.dgvPartNumber.Name = "dgvPartNumber"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPartNumber.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPartNumber.RowTemplate.Height = 23
        Me.dgvPartNumber.Size = New System.Drawing.Size(943, 341)
        Me.dgvPartNumber.TabIndex = 5
        '
        'cbkPrint
        '
        Me.cbkPrint.HeaderText = "全选"
        Me.cbkPrint.Name = "cbkPrint"
        Me.cbkPrint.Width = 60
        '
        'JobNumber
        '
        Me.JobNumber.DataPropertyName = "JobNumber"
        Me.JobNumber.HeaderText = "工单号"
        Me.JobNumber.Name = "JobNumber"
        '
        'PartNumber
        '
        Me.PartNumber.DataPropertyName = "PartNumber"
        Me.PartNumber.HeaderText = "料件编号"
        Me.PartNumber.Name = "PartNumber"
        '
        'Quantity
        '
        Me.Quantity.DataPropertyName = "Quantity"
        Me.Quantity.HeaderText = "数量"
        Me.Quantity.Name = "Quantity"
        '
        'PrintNumbers
        '
        Me.PrintNumbers.DataPropertyName = "PrintNumbers"
        Me.PrintNumbers.HeaderText = "打印份数"
        Me.PrintNumbers.Name = "PrintNumbers"
        '
        'Lot
        '
        Me.Lot.DataPropertyName = "Lot"
        Me.Lot.HeaderText = "批次"
        Me.Lot.Name = "Lot"
        '
        'Adress
        '
        Me.Adress.DataPropertyName = "Adress"
        Me.Adress.HeaderText = "储位"
        Me.Adress.Name = "Adress"
        '
        'LineCategory
        '
        Me.LineCategory.DataPropertyName = "LineCategory"
        Me.LineCategory.HeaderText = "线别"
        Me.LineCategory.Name = "LineCategory"
        '
        'txtPartNumber
        '
        Me.txtPartNumber.Location = New System.Drawing.Point(119, 20)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Size = New System.Drawing.Size(496, 21)
        Me.txtPartNumber.TabIndex = 6
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 441)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1055, 25)
        Me.ToolStrip1.TabIndex = 8
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(68, 22)
        Me.ToolStripStatusLabel1.Text = "记录笔数："
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(747, 25)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(57, 12)
        Me.lblMsg.TabIndex = 9
        Me.lblMsg.Text = "提示信息"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "打印机:"
        '
        'cbxPrint
        '
        Me.cbxPrint.FormattingEnabled = True
        Me.cbxPrint.Location = New System.Drawing.Point(119, 51)
        Me.cbxPrint.Name = "cbxPrint"
        Me.cbxPrint.Size = New System.Drawing.Size(292, 20)
        Me.cbxPrint.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(449, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "打印份数:"
        Me.Label3.Visible = False
        '
        'txtTimes
        '
        Me.txtTimes.Location = New System.Drawing.Point(540, 84)
        Me.txtTimes.Name = "txtTimes"
        Me.txtTimes.Size = New System.Drawing.Size(75, 21)
        Me.txtTimes.TabIndex = 13
        Me.txtTimes.Text = "1"
        Me.txtTimes.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "打印料号:"
        '
        'txtPnForPrint
        '
        Me.txtPnForPrint.Enabled = False
        Me.txtPnForPrint.Location = New System.Drawing.Point(119, 84)
        Me.txtPnForPrint.Name = "txtPnForPrint"
        Me.txtPnForPrint.Size = New System.Drawing.Size(292, 21)
        Me.txtPnForPrint.TabIndex = 15
        '
        'FrmWpartNumber
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1055, 466)
        Me.Controls.Add(Me.txtPnForPrint)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTimes)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbxPrint)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.txtPartNumber)
        Me.Controls.Add(Me.dgvPartNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnPrintAll)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "FrmWpartNumber"
        Me.Text = "仓库发料"
        CType(Me.dgvPartNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnPrintAll As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvPartNumber As System.Windows.Forms.DataGridView
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbxPrint As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTimes As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPnForPrint As System.Windows.Forms.TextBox
    Friend WithEvents cbkPrint As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents JobNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintNumbers As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Adress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCategory As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
