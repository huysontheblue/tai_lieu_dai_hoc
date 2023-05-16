<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProcessParametersImport
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
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.lblMsgList = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(6, 23)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(341, 21)
        Me.txtPath.TabIndex = 0
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(360, 21)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 23)
        Me.btnSelect.TabIndex = 1
        Me.btnSelect.Text = "浏览"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(450, 21)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "导入"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'lblMsgList
        '
        Me.lblMsgList.BackColor = System.Drawing.SystemColors.Info
        Me.lblMsgList.FormattingEnabled = True
        Me.lblMsgList.HorizontalScrollbar = True
        Me.lblMsgList.ItemHeight = 12
        Me.lblMsgList.Location = New System.Drawing.Point(6, 58)
        Me.lblMsgList.Name = "lblMsgList"
        Me.lblMsgList.Size = New System.Drawing.Size(519, 256)
        Me.lblMsgList.TabIndex = 5
        '
        'FrmProcessParametersImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 318)
        Me.Controls.Add(Me.lblMsgList)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.txtPath)
        Me.MaximizeBox = False
        Me.Name = "FrmProcessParametersImport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "工艺参数导入"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblMsgList As System.Windows.Forms.ListBox
End Class
