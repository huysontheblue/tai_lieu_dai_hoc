<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfShow
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInfShow))
        Me.BtSure = New System.Windows.Forms.Button()
        Me.BtDorp = New System.Windows.Forms.Button()
        Me.LabInf = New System.Windows.Forms.Label()
        Me.LabQust = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BtSure
        '
        Me.BtSure.Location = New System.Drawing.Point(69, 185)
        Me.BtSure.Name = "BtSure"
        Me.BtSure.Size = New System.Drawing.Size(77, 28)
        Me.BtSure.TabIndex = 0
        Me.BtSure.Text = "確認"
        Me.BtSure.UseVisualStyleBackColor = True
        '
        'BtDorp
        '
        Me.BtDorp.Location = New System.Drawing.Point(278, 186)
        Me.BtDorp.Name = "BtDorp"
        Me.BtDorp.Size = New System.Drawing.Size(85, 27)
        Me.BtDorp.TabIndex = 1
        Me.BtDorp.Text = "取消"
        Me.BtDorp.UseVisualStyleBackColor = True
        '
        'LabInf
        '
        Me.LabInf.Font = New System.Drawing.Font("PMingLiU", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabInf.ForeColor = System.Drawing.Color.Red
        Me.LabInf.Location = New System.Drawing.Point(12, 5)
        Me.LabInf.Name = "LabInf"
        Me.LabInf.Size = New System.Drawing.Size(411, 110)
        Me.LabInf.TabIndex = 2
        Me.LabInf.Text = "該料號產品在：A14F樓層，CEG倉，D2儲位有更早生產的產品"
        Me.LabInf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabQust
        '
        Me.LabQust.Font = New System.Drawing.Font("PMingLiU", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabQust.Location = New System.Drawing.Point(26, 124)
        Me.LabQust.Name = "LabQust"
        Me.LabQust.Size = New System.Drawing.Size(383, 37)
        Me.LabQust.TabIndex = 3
        Me.LabQust.Text = "你確定不遵守先進先出碼？"
        Me.LabQust.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmInfShow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(443, 223)
        Me.Controls.Add(Me.LabQust)
        Me.Controls.Add(Me.LabInf)
        Me.Controls.Add(Me.BtDorp)
        Me.Controls.Add(Me.BtSure)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInfShow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "信息提示"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtSure As System.Windows.Forms.Button
    Friend WithEvents BtDorp As System.Windows.Forms.Button
    Friend WithEvents LabInf As System.Windows.Forms.Label
    Friend WithEvents LabQust As System.Windows.Forms.Label
End Class
