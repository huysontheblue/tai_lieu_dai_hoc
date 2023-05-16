<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrintCard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrintCard))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboPrintType = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ChkPn = New System.Windows.Forms.CheckedListBox
        Me.txtCopies = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ChkSelectAll = New System.Windows.Forms.CheckBox
        Me.txtMo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboPrinter = New System.Windows.Forms.ComboBox
        Me.cboReportType = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnPrint = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cboPrintType)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.ChkPn)
        Me.GroupBox1.Controls.Add(Me.txtCopies)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ChkSelectAll)
        Me.GroupBox1.Controls.Add(Me.txtMo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboPrinter)
        Me.GroupBox1.Controls.Add(Me.cboReportType)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(722, 378)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "选择打印条件"
        '
        'cboPrintType
        '
        Me.cboPrintType.FormattingEnabled = True
        Me.cboPrintType.Location = New System.Drawing.Point(96, 157)
        Me.cboPrintType.Name = "cboPrintType"
        Me.cboPrintType.Size = New System.Drawing.Size(182, 20)
        Me.cboPrintType.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微软雅黑", 10.5!)
        Me.Label6.Location = New System.Drawing.Point(24, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "打印方式："
        '
        'ChkPn
        '
        Me.ChkPn.Font = New System.Drawing.Font("微软雅黑", 10.5!)
        Me.ChkPn.FormattingEnabled = True
        Me.ChkPn.Location = New System.Drawing.Point(395, 47)
        Me.ChkPn.Name = "ChkPn"
        Me.ChkPn.Size = New System.Drawing.Size(315, 298)
        Me.ChkPn.TabIndex = 12
        '
        'txtCopies
        '
        Me.txtCopies.Location = New System.Drawing.Point(96, 265)
        Me.txtCopies.Name = "txtCopies"
        Me.txtCopies.Size = New System.Drawing.Size(100, 21)
        Me.txtCopies.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 264)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "打印份数："
        '
        'ChkSelectAll
        '
        Me.ChkSelectAll.AutoSize = True
        Me.ChkSelectAll.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ChkSelectAll.Location = New System.Drawing.Point(398, 15)
        Me.ChkSelectAll.Name = "ChkSelectAll"
        Me.ChkSelectAll.Size = New System.Drawing.Size(56, 24)
        Me.ChkSelectAll.TabIndex = 8
        Me.ChkSelectAll.Text = "全选"
        Me.ChkSelectAll.UseVisualStyleBackColor = True
        '
        'txtMo
        '
        Me.txtMo.Location = New System.Drawing.Point(96, 18)
        Me.txtMo.Multiline = True
        Me.txtMo.Name = "txtMo"
        Me.txtMo.Size = New System.Drawing.Size(182, 65)
        Me.txtMo.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "工单编号："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(310, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "料件编号："
        '
        'cboPrinter
        '
        Me.cboPrinter.FormattingEnabled = True
        Me.cboPrinter.Location = New System.Drawing.Point(97, 208)
        Me.cboPrinter.Name = "cboPrinter"
        Me.cboPrinter.Size = New System.Drawing.Size(181, 20)
        Me.cboPrinter.TabIndex = 3
        '
        'cboReportType
        '
        Me.cboReportType.FormattingEnabled = True
        Me.cboReportType.Location = New System.Drawing.Point(96, 100)
        Me.cboReportType.Name = "cboReportType"
        Me.cboReportType.Size = New System.Drawing.Size(182, 20)
        Me.cboReportType.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 208)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "打印机名称："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "流程卡类型："
        '
        'toolStrip1
        '
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btnPrint, Me.ToolStripSeparator1, Me.btnExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(724, 25)
        Me.toolStrip1.TabIndex = 4
        Me.toolStrip1.Text = "toolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnPrint
        '
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(71, 22)
        Me.btnPrint.Text = "打 印(&P)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 22)
        Me.btnExit.Text = "退 出(&X)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.Location = New System.Drawing.Point(25, 329)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(154, 16)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "打印中，请稍等..."
        '
        'FrmPrintCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 419)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "FrmPrintCard"
        Me.Text = "流程卡列印"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPrinter As System.Windows.Forms.ComboBox
    Friend WithEvents cboReportType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMo As System.Windows.Forms.TextBox
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents btnPrint As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ChkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents txtCopies As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ChkPn As System.Windows.Forms.CheckedListBox
    Friend WithEvents cboPrintType As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
