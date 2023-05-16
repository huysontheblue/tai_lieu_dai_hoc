<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductNGDayQuerySub
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtSelectedDept = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.checkListBoxLine = New System.Windows.Forms.CheckedListBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.txtSelectedLine = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel2 = New System.Windows.Forms.Button()
        Me.btnOk2 = New System.Windows.Forms.Button()
        Me.checkListPartId = New System.Windows.Forms.CheckedListBox()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbbPartId = New System.Windows.Forms.ComboBox()
        Me.btnSelectedAll = New System.Windows.Forms.Button()
        Me.btnSelectedAll2 = New System.Windows.Forms.Button()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 194
        Me.Label3.Text = "选择部门："
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSelectedDept)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSelectedAll)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCancel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnOk)
        Me.SplitContainer1.Panel2.Controls.Add(Me.checkListBoxLine)
        Me.SplitContainer1.Size = New System.Drawing.Size(410, 419)
        Me.SplitContainer1.SplitterDistance = 68
        Me.SplitContainer1.TabIndex = 195
        '
        'txtSelectedDept
        '
        Me.txtSelectedDept.Enabled = False
        Me.txtSelectedDept.Location = New System.Drawing.Point(73, 11)
        Me.txtSelectedDept.Multiline = True
        Me.txtSelectedDept.Name = "txtSelectedDept"
        Me.txtSelectedDept.Size = New System.Drawing.Size(330, 52)
        Me.txtSelectedDept.TabIndex = 195
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(258, 302)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 33)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(148, 301)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 33)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "确认"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'checkListBoxLine
        '
        Me.checkListBoxLine.FormattingEnabled = True
        Me.checkListBoxLine.Location = New System.Drawing.Point(3, 3)
        Me.checkListBoxLine.Name = "checkListBoxLine"
        Me.checkListBoxLine.Size = New System.Drawing.Size(400, 292)
        Me.checkListBoxLine.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.cbbPartId)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtSelectedLine)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnSelectedAll2)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnCancel2)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnOk2)
        Me.SplitContainer2.Panel2.Controls.Add(Me.checkListPartId)
        Me.SplitContainer2.Size = New System.Drawing.Size(406, 419)
        Me.SplitContainer2.SplitterDistance = 87
        Me.SplitContainer2.TabIndex = 196
        '
        'txtSelectedLine
        '
        Me.txtSelectedLine.Enabled = False
        Me.txtSelectedLine.Location = New System.Drawing.Point(64, 13)
        Me.txtSelectedLine.Multiline = True
        Me.txtSelectedLine.Name = "txtSelectedLine"
        Me.txtSelectedLine.Size = New System.Drawing.Size(330, 49)
        Me.txtSelectedLine.TabIndex = 195
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 194
        Me.Label1.Text = "选择线别："
        '
        'btnCancel2
        '
        Me.btnCancel2.Location = New System.Drawing.Point(282, 283)
        Me.btnCancel2.Name = "btnCancel2"
        Me.btnCancel2.Size = New System.Drawing.Size(75, 33)
        Me.btnCancel2.TabIndex = 1
        Me.btnCancel2.Text = "取消"
        Me.btnCancel2.UseVisualStyleBackColor = True
        '
        'btnOk2
        '
        Me.btnOk2.Location = New System.Drawing.Point(163, 283)
        Me.btnOk2.Name = "btnOk2"
        Me.btnOk2.Size = New System.Drawing.Size(75, 33)
        Me.btnOk2.TabIndex = 1
        Me.btnOk2.Text = "确认"
        Me.btnOk2.UseVisualStyleBackColor = True
        '
        'checkListPartId
        '
        Me.checkListPartId.FormattingEnabled = True
        Me.checkListPartId.Location = New System.Drawing.Point(4, 3)
        Me.checkListPartId.Name = "checkListPartId"
        Me.checkListPartId.Size = New System.Drawing.Size(400, 276)
        Me.checkListPartId.TabIndex = 0
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.SplitContainer1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer3.Size = New System.Drawing.Size(820, 419)
        Me.SplitContainer3.SplitterDistance = 410
        Me.SplitContainer3.TabIndex = 197
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 196
        Me.Label2.Text = "选择料号："
        '
        'cbbPartId
        '
        Me.cbbPartId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbbPartId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbbPartId.FormattingEnabled = True
        Me.cbbPartId.Location = New System.Drawing.Point(64, 68)
        Me.cbbPartId.Name = "cbbPartId"
        Me.cbbPartId.Size = New System.Drawing.Size(279, 20)
        Me.cbbPartId.TabIndex = 197
        '
        'btnSelectedAll
        '
        Me.btnSelectedAll.Location = New System.Drawing.Point(38, 301)
        Me.btnSelectedAll.Name = "btnSelectedAll"
        Me.btnSelectedAll.Size = New System.Drawing.Size(75, 33)
        Me.btnSelectedAll.TabIndex = 2
        Me.btnSelectedAll.Text = "全选"
        Me.btnSelectedAll.UseVisualStyleBackColor = True
        '
        'btnSelectedAll2
        '
        Me.btnSelectedAll2.Location = New System.Drawing.Point(52, 283)
        Me.btnSelectedAll2.Name = "btnSelectedAll2"
        Me.btnSelectedAll2.Size = New System.Drawing.Size(75, 33)
        Me.btnSelectedAll2.TabIndex = 2
        Me.btnSelectedAll2.Text = "全选"
        Me.btnSelectedAll2.UseVisualStyleBackColor = True
        '
        'FrmProductNGDayQuerySub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 419)
        Me.Controls.Add(Me.SplitContainer3)
        Me.MaximizeBox = False
        Me.Name = "FrmProductNGDayQuerySub"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "线别选择-部门对应线别列表"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents checkListBoxLine As System.Windows.Forms.CheckedListBox
    Friend WithEvents txtSelectedDept As System.Windows.Forms.TextBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtSelectedLine As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents checkListPartId As System.Windows.Forms.CheckedListBox
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnCancel2 As System.Windows.Forms.Button
    Friend WithEvents btnOk2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbbPartId As System.Windows.Forms.ComboBox
    Friend WithEvents btnSelectedAll As System.Windows.Forms.Button
    Friend WithEvents btnSelectedAll2 As System.Windows.Forms.Button
End Class
