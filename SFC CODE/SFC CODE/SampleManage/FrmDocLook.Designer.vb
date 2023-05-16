<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDocLook
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDocLook))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        '  Me.AxAcroPDF1 = New AxAcroPDFLib.AxAcroPDF()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        ' Me.AxFramerControl1 = New AxDSOFramer.AxFramerControl()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        '  CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        '  CType(Me.AxFramerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(1, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(914, 497)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        '  Me.TabPage1.Controls.Add(Me.AxAcroPDF1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(906, 423)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "pdf"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'AxAcroPDF1
        '
        'Me.AxAcroPDF1.Enabled = True
        'Me.AxAcroPDF1.Location = New System.Drawing.Point(3, 6)
        'Me.AxAcroPDF1.Name = "AxAcroPDF1"
        'Me.AxAcroPDF1.OcxState = CType(resources.GetObject("AxAcroPDF1.OcxState"), System.Windows.Forms.AxHost.State)
        'Me.AxAcroPDF1.Size = New System.Drawing.Size(893, 414)
        'Me.AxAcroPDF1.TabIndex = 0
        '
        'TabPage2
        '
        '  Me.TabPage2.Controls.Add(Me.AxFramerControl1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(906, 471)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "office"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'AxFramerControl1
        '
        'Me.AxFramerControl1.Enabled = True
        'Me.AxFramerControl1.Location = New System.Drawing.Point(0, 6)
        'Me.AxFramerControl1.Name = "AxFramerControl1"
        'Me.AxFramerControl1.OcxState = CType(resources.GetObject("AxFramerControl1.OcxState"), System.Windows.Forms.AxHost.State)
        'Me.AxFramerControl1.Size = New System.Drawing.Size(896, 462)
        'Me.AxFramerControl1.TabIndex = 0
        '
        'FrmDocLook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 504)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmDocLook"
        Me.Text = "文件预览"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        '  CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        ' CType(Me.AxFramerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    ' Friend WithEvents AxAcroPDF1 As AxAcroPDFLib.AxAcroPDF
    ' Friend WithEvents AxFramerControl1 As AxDSOFramer.AxFramerControl
End Class
