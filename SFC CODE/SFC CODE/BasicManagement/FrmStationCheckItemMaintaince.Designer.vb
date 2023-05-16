<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStationCheckItemMaintaince
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
        Me.uxSelectedCheckItemTreeView = New System.Windows.Forms.TreeView()
        Me.uxCheckItemList = New System.Windows.Forms.TreeView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'uxSelectedCheckItemTreeView
        '
        Me.uxSelectedCheckItemTreeView.AllowDrop = True
        Me.uxSelectedCheckItemTreeView.Location = New System.Drawing.Point(1, 26)
        Me.uxSelectedCheckItemTreeView.Name = "uxSelectedCheckItemTreeView"
        Me.uxSelectedCheckItemTreeView.Size = New System.Drawing.Size(310, 337)
        Me.uxSelectedCheckItemTreeView.TabIndex = 0
        '
        'uxCheckItemList
        '
        Me.uxCheckItemList.AllowDrop = True
        Me.uxCheckItemList.Location = New System.Drawing.Point(317, 26)
        Me.uxCheckItemList.Name = "uxCheckItemList"
        Me.uxCheckItemList.Size = New System.Drawing.Size(297, 337)
        Me.uxCheckItemList.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "已选择校验项次"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(402, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "从右往左拖动为新增"
        '
        'FrmStationCheckItemMaintaince
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 368)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.uxCheckItemList)
        Me.Controls.Add(Me.uxSelectedCheckItemTreeView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmStationCheckItemMaintaince"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "工站校验项次维护"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents uxSelectedCheckItemTreeView As System.Windows.Forms.TreeView
    Friend WithEvents uxCheckItemList As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
