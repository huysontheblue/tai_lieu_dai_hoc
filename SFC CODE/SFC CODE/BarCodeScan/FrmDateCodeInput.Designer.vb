<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDateCodeInput
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
        Me.txtCartonID = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtDateCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDCQty = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCartonCapacity = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.dgvDCList = New System.Windows.Forms.DataGridView()
        Me.DateCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DCQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtBigCarton_Hide = New System.Windows.Forms.TextBox()
        Me.txtPartID_hide = New System.Windows.Forms.TextBox()
        CType(Me.dgvDCList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCartonID
        '
        Me.txtCartonID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCartonID.Location = New System.Drawing.Point(110, 49)
        Me.txtCartonID.Name = "txtCartonID"
        Me.txtCartonID.ReadOnly = True
        Me.txtCartonID.Size = New System.Drawing.Size(350, 21)
        Me.txtCartonID.TabIndex = 22
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(47, 54)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(59, 12)
        Me.label1.TabIndex = 1
        Me.label1.Text = "当前箱号:"
        '
        'txtDateCode
        '
        Me.txtDateCode.Location = New System.Drawing.Point(112, 148)
        Me.txtDateCode.Name = "txtDateCode"
        Me.txtDateCode.Size = New System.Drawing.Size(128, 21)
        Me.txtDateCode.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(60, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "D/C:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 196)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "该D/C数量:"
        '
        'txtDCQty
        '
        Me.txtDCQty.Location = New System.Drawing.Point(112, 193)
        Me.txtDCQty.Name = "txtDCQty"
        Me.txtDCQty.Size = New System.Drawing.Size(126, 21)
        Me.txtDCQty.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "该箱容量:"
        '
        'txtCartonCapacity
        '
        Me.txtCartonCapacity.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCartonCapacity.Location = New System.Drawing.Point(110, 90)
        Me.txtCartonCapacity.Name = "txtCartonCapacity"
        Me.txtCartonCapacity.ReadOnly = True
        Me.txtCartonCapacity.Size = New System.Drawing.Size(350, 21)
        Me.txtCartonCapacity.TabIndex = 6
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(289, 167)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "添加(+)"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(394, 167)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnRemove.TabIndex = 9
        Me.btnRemove.Text = "移除(-)"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'dgvDCList
        '
        Me.dgvDCList.AllowUserToAddRows = False
        Me.dgvDCList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDCList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDCList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateCode, Me.DCQty})
        Me.dgvDCList.Location = New System.Drawing.Point(110, 230)
        Me.dgvDCList.Name = "dgvDCList"
        Me.dgvDCList.RowHeadersVisible = False
        Me.dgvDCList.RowTemplate.Height = 23
        Me.dgvDCList.Size = New System.Drawing.Size(357, 87)
        Me.dgvDCList.TabIndex = 10
        '
        'DateCode
        '
        Me.DateCode.HeaderText = "D/C"
        Me.DateCode.Name = "DateCode"
        '
        'DCQty
        '
        Me.DCQty.HeaderText = "该DC数量"
        Me.DCQty.Name = "DCQty"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(126, 346)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 11
        Me.btnOK.Text = "确定"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtBigCarton_Hide
        '
        Me.txtBigCarton_Hide.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBigCarton_Hide.Location = New System.Drawing.Point(126, 12)
        Me.txtBigCarton_Hide.Name = "txtBigCarton_Hide"
        Me.txtBigCarton_Hide.ReadOnly = True
        Me.txtBigCarton_Hide.Size = New System.Drawing.Size(24, 21)
        Me.txtBigCarton_Hide.TabIndex = 13
        Me.txtBigCarton_Hide.Visible = False
        '
        'txtPartID_hide
        '
        Me.txtPartID_hide.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartID_hide.Location = New System.Drawing.Point(214, 12)
        Me.txtPartID_hide.Name = "txtPartID_hide"
        Me.txtPartID_hide.ReadOnly = True
        Me.txtPartID_hide.Size = New System.Drawing.Size(24, 21)
        Me.txtPartID_hide.TabIndex = 14
        Me.txtPartID_hide.Visible = False
        '
        'FrmDateCodeInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 384)
        Me.Controls.Add(Me.txtPartID_hide)
        Me.Controls.Add(Me.txtBigCarton_Hide)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.dgvDCList)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCartonCapacity)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDCQty)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDateCode)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.txtCartonID)
        Me.Name = "FrmDateCodeInput"
        Me.Text = "DateCode维护"
        CType(Me.dgvDCList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCartonID As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txtDateCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDCQty As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCartonCapacity As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents dgvDCList As System.Windows.Forms.DataGridView
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents DateCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DCQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtBigCarton_Hide As System.Windows.Forms.TextBox
    Friend WithEvents txtPartID_hide As System.Windows.Forms.TextBox
End Class
