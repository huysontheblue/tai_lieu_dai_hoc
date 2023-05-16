<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTranWH
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTranWH))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CobFloor = New System.Windows.Forms.ComboBox()
        Me.CobWHName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CobArea = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btConfirm = New System.Windows.Forms.Button()
        Me.btClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "倉庫位置:"
        '
        'CobFloor
        '
        Me.CobFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobFloor.FormattingEnabled = True
        Me.CobFloor.Location = New System.Drawing.Point(79, 24)
        Me.CobFloor.Name = "CobFloor"
        Me.CobFloor.Size = New System.Drawing.Size(114, 20)
        Me.CobFloor.TabIndex = 1
        '
        'CobWHName
        '
        Me.CobWHName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobWHName.FormattingEnabled = True
        Me.CobWHName.Location = New System.Drawing.Point(77, 60)
        Me.CobWHName.Name = "CobWHName"
        Me.CobWHName.Size = New System.Drawing.Size(144, 20)
        Me.CobWHName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "倉庫名稱:"
        '
        'CobArea
        '
        Me.CobArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobArea.FormattingEnabled = True
        Me.CobArea.Location = New System.Drawing.Point(78, 97)
        Me.CobArea.Name = "CobArea"
        Me.CobArea.Size = New System.Drawing.Size(144, 20)
        Me.CobArea.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "儲位名稱:"
        '
        'btConfirm
        '
        Me.btConfirm.Location = New System.Drawing.Point(257, 13)
        Me.btConfirm.Name = "btConfirm"
        Me.btConfirm.Size = New System.Drawing.Size(80, 24)
        Me.btConfirm.TabIndex = 6
        Me.btConfirm.Text = "確  定(&C)"
        Me.btConfirm.UseVisualStyleBackColor = True
        '
        'btClose
        '
        Me.btClose.Location = New System.Drawing.Point(257, 50)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(80, 24)
        Me.btClose.TabIndex = 7
        Me.btClose.Text = "取  消"
        Me.btClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CobArea)
        Me.GroupBox1.Controls.Add(Me.CobFloor)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CobWHName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(239, 135)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "轉入倉庫："
        '
        'FrmTranWH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 155)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.btConfirm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmTranWH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "轉入倉庫設置"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CobFloor As System.Windows.Forms.ComboBox
    Friend WithEvents CobWHName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CobArea As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btConfirm As System.Windows.Forms.Button
    Friend WithEvents btClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
