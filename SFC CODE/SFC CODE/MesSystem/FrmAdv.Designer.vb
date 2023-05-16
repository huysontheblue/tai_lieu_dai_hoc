<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAdv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAdv))
        Me.RichTextBoxEx1 = New DevComponents.DotNetBar.Controls.RichTextBoxEx()
        Me.SuspendLayout()
        '
        'RichTextBoxEx1
        '
        Me.RichTextBoxEx1.BackColorRichTextBox = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.RichTextBoxEx1.BackgroundImage = CType(resources.GetObject("RichTextBoxEx1.BackgroundImage"), System.Drawing.Image)
        Me.RichTextBoxEx1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        '
        '
        '
        Me.RichTextBoxEx1.BackgroundStyle.Class = "RichTextBoxBorder"
        Me.RichTextBoxEx1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RichTextBoxEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBoxEx1.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBoxEx1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RichTextBoxEx1.Name = "RichTextBoxEx1"
        Me.RichTextBoxEx1.ReadOnly = True
        Me.RichTextBoxEx1.Rtf = "{\rtf1\ansi\ansicpg936\deff0\deflang1033\deflangfe2052{\fonttbl{\f0\fnil\fcharset" & _
    "134 \'cb\'ce\'cc\'e5;}}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\viewkind4\uc1\pard\lang2052\f0\fs18\par" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.RichTextBoxEx1.Size = New System.Drawing.Size(1288, 651)
        Me.RichTextBoxEx1.TabIndex = 1
        Me.RichTextBoxEx1.TabStop = False
        '
        'FrmAdv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1288, 651)
        Me.Controls.Add(Me.RichTextBoxEx1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MinimizeBox = False
        Me.Name = "FrmAdv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "公告详情"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RichTextBoxEx1 As DevComponents.DotNetBar.Controls.RichTextBoxEx
End Class
