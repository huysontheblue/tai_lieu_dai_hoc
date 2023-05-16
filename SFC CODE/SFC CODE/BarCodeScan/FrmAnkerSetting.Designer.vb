<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAnkerSetting
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_NewProductCode = New System.Windows.Forms.TextBox()
        Me.txt_OldProductCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cbo_PartID = New System.Windows.Forms.ComboBox()
        Me.btn_SaveAnkerSetting = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_NewProductCode)
        Me.GroupBox1.Controls.Add(Me.txt_OldProductCode)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Cbo_PartID)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(389, 163)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Anker Setting"
        '
        'txt_NewProductCode
        '
        Me.txt_NewProductCode.Location = New System.Drawing.Point(125, 108)
        Me.txt_NewProductCode.Name = "txt_NewProductCode"
        Me.txt_NewProductCode.Size = New System.Drawing.Size(221, 20)
        Me.txt_NewProductCode.TabIndex = 5
        '
        'txt_OldProductCode
        '
        Me.txt_OldProductCode.Location = New System.Drawing.Point(125, 70)
        Me.txt_OldProductCode.Name = "txt_OldProductCode"
        Me.txt_OldProductCode.ReadOnly = True
        Me.txt_OldProductCode.Size = New System.Drawing.Size(221, 20)
        Me.txt_OldProductCode.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "New Product Code :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Old Product Code :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "PartID :"
        '
        'Cbo_PartID
        '
        Me.Cbo_PartID.FormattingEnabled = True
        Me.Cbo_PartID.Location = New System.Drawing.Point(125, 28)
        Me.Cbo_PartID.Name = "Cbo_PartID"
        Me.Cbo_PartID.Size = New System.Drawing.Size(221, 21)
        Me.Cbo_PartID.TabIndex = 0
        '
        'btn_SaveAnkerSetting
        '
        Me.btn_SaveAnkerSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_SaveAnkerSetting.Location = New System.Drawing.Point(170, 181)
        Me.btn_SaveAnkerSetting.Name = "btn_SaveAnkerSetting"
        Me.btn_SaveAnkerSetting.Size = New System.Drawing.Size(85, 39)
        Me.btn_SaveAnkerSetting.TabIndex = 1
        Me.btn_SaveAnkerSetting.Text = "Save"
        Me.btn_SaveAnkerSetting.UseVisualStyleBackColor = True
        '
        'FrmAnkerSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 234)
        Me.Controls.Add(Me.btn_SaveAnkerSetting)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmAnkerSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmAnkerSetting"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Cbo_PartID As System.Windows.Forms.ComboBox
    Friend WithEvents btn_SaveAnkerSetting As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_NewProductCode As System.Windows.Forms.TextBox
    Friend WithEvents txt_OldProductCode As System.Windows.Forms.TextBox
End Class
