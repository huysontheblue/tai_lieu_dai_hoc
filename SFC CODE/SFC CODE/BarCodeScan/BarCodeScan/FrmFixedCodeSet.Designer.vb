<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFixedCodeSet
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
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtScanFour = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtScanTree = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtScanTwo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtScanOne = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMoid = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.lbMsg = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Qty = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.box = New System.Windows.Forms.TextBox()
        Me.boxeffective = New System.Windows.Forms.CheckBox()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(7, 254)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 23)
        Me.btnSave.TabIndex = 17
        Me.btnSave.Text = "确定(&O)"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtScanFour
        '
        Me.txtScanFour.Enabled = False
        Me.txtScanFour.Location = New System.Drawing.Point(92, 227)
        Me.txtScanFour.Name = "txtScanFour"
        Me.txtScanFour.Size = New System.Drawing.Size(205, 21)
        Me.txtScanFour.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 227)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 12)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "固定条码四:"
        '
        'txtScanTree
        '
        Me.txtScanTree.Enabled = False
        Me.txtScanTree.Location = New System.Drawing.Point(92, 193)
        Me.txtScanTree.Name = "txtScanTree"
        Me.txtScanTree.Size = New System.Drawing.Size(204, 21)
        Me.txtScanTree.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 196)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 12)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "固定条码三:"
        '
        'txtScanTwo
        '
        Me.txtScanTwo.Enabled = False
        Me.txtScanTwo.Location = New System.Drawing.Point(92, 152)
        Me.txtScanTwo.Name = "txtScanTwo"
        Me.txtScanTwo.Size = New System.Drawing.Size(204, 21)
        Me.txtScanTwo.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 12)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "固定条码二:"
        '
        'txtScanOne
        '
        Me.txtScanOne.Enabled = False
        Me.txtScanOne.Location = New System.Drawing.Point(92, 122)
        Me.txtScanOne.Name = "txtScanOne"
        Me.txtScanOne.Size = New System.Drawing.Size(204, 21)
        Me.txtScanOne.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 12)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "固定条码一:"
        '
        'txtMoid
        '
        Me.txtMoid.Location = New System.Drawing.Point(93, 17)
        Me.txtMoid.Name = "txtMoid"
        Me.txtMoid.Size = New System.Drawing.Size(303, 21)
        Me.txtMoid.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 12)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "工单编号:"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(135, 254)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 20
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(411, 17)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(54, 21)
        Me.btnQuery.TabIndex = 21
        Me.btnQuery.Text = "查询"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'lbMsg
        '
        Me.lbMsg.AutoSize = True
        Me.lbMsg.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbMsg.ForeColor = System.Drawing.Color.Red
        Me.lbMsg.Location = New System.Drawing.Point(23, 76)
        Me.lbMsg.Name = "lbMsg"
        Me.lbMsg.Size = New System.Drawing.Size(48, 16)
        Me.lbMsg.TabIndex = 22
        Me.lbMsg.Text = "     "
        '
        'btnReset
        '
        Me.btnReset.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnReset.Location = New System.Drawing.Point(280, 254)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 23
        Me.btnReset.Text = "重置(&R)"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 16
        Me.LineShape1.X2 = 476
        Me.LineShape1.Y1 = 81
        Me.LineShape1.Y2 = 81
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbMsg)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Qty)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.box)
        Me.GroupBox1.Controls.Add(Me.boxeffective)
        Me.GroupBox1.Controls.Add(Me.txtScanTree)
        Me.GroupBox1.Controls.Add(Me.btnReset)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtScanOne)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.txtScanTwo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.txtScanFour)
        Me.GroupBox1.Controls.Add(Me.ShapeContainer2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(494, 291)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "扫描设置"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(355, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 12)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "装箱数量:"
        '
        'Qty
        '
        Me.Qty.Enabled = False
        Me.Qty.Location = New System.Drawing.Point(417, 52)
        Me.Qty.Name = "Qty"
        Me.Qty.Size = New System.Drawing.Size(58, 21)
        Me.Qty.TabIndex = 28
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 12)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "箱样式:"
        '
        'box
        '
        Me.box.Enabled = False
        Me.box.Location = New System.Drawing.Point(66, 50)
        Me.box.Name = "box"
        Me.box.Size = New System.Drawing.Size(260, 21)
        Me.box.TabIndex = 26
        '
        'boxeffective
        '
        Me.boxeffective.AutoSize = True
        Me.boxeffective.Enabled = False
        Me.boxeffective.Location = New System.Drawing.Point(16, 30)
        Me.boxeffective.Name = "boxeffective"
        Me.boxeffective.Size = New System.Drawing.Size(96, 16)
        Me.boxeffective.TabIndex = 24
        Me.boxeffective.Text = "是否扫描外箱"
        Me.boxeffective.UseVisualStyleBackColor = True
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(3, 17)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer2.Size = New System.Drawing.Size(488, 271)
        Me.ShapeContainer2.TabIndex = 0
        Me.ShapeContainer2.TabStop = False
        '
        'FrmFixedCodeSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 355)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.txtMoid)
        Me.Controls.Add(Me.Label5)
        Me.Name = "FrmFixedCodeSet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "设置"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtScanFour As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtScanTree As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtScanTwo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtScanOne As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMoid As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents lbMsg As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Qty As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents box As System.Windows.Forms.TextBox
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents boxeffective As System.Windows.Forms.CheckBox
End Class
