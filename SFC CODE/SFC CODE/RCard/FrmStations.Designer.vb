<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStations
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbStationName = New System.Windows.Forms.ComboBox()
        Me.BtSubmit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "工站:"
        '
        'cmbStationName
        '
        Me.cmbStationName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbStationName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbStationName.FormattingEnabled = True
        Me.cmbStationName.Location = New System.Drawing.Point(68, 20)
        Me.cmbStationName.Name = "cmbStationName"
        Me.cmbStationName.Size = New System.Drawing.Size(344, 20)
        Me.cmbStationName.TabIndex = 1
        '
        'BtSubmit
        '
        Me.BtSubmit.Location = New System.Drawing.Point(432, 18)
        Me.BtSubmit.Name = "BtSubmit"
        Me.BtSubmit.Size = New System.Drawing.Size(75, 23)
        Me.BtSubmit.TabIndex = 2
        Me.BtSubmit.Text = "提交"
        Me.BtSubmit.UseVisualStyleBackColor = True
        '
        'FrmStations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 64)
        Me.Controls.Add(Me.BtSubmit)
        Me.Controls.Add(Me.cmbStationName)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmStations"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "编辑工站"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbStationName As System.Windows.Forms.ComboBox
    Friend WithEvents BtSubmit As System.Windows.Forms.Button
End Class
