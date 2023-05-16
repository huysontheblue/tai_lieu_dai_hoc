<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EquipmentApply
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
        Me.btnOK = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbsd = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtApplyID = New System.Windows.Forms.TextBox
        Me.txtMOID = New System.Windows.Forms.TextBox
        Me.txtPNumber = New System.Windows.Forms.TextBox
        Me.txtQTY = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboDept = New System.Windows.Forms.ComboBox
        Me.cboLine = New System.Windows.Forms.ComboBox
        Me.cboFactory = New System.Windows.Forms.ComboBox
        Me.dgvApply = New System.Windows.Forms.DataGridView
        Me.cboSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.QTY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnSearch = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvEquipment = New System.Windows.Forms.DataGridView
        Me.txtLine = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        CType(Me.dgvApply, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvEquipment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(208, 95)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "申请"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "申请人工号："
        '
        'lbsd
        '
        Me.lbsd.AutoSize = True
        Me.lbsd.Location = New System.Drawing.Point(206, 17)
        Me.lbsd.Name = "lbsd"
        Me.lbsd.Size = New System.Drawing.Size(53, 12)
        Me.lbsd.TabIndex = 2
        Me.lbsd.Text = "工单号："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(455, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "产品料号："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(206, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "课别："
        '
        'txtApplyID
        '
        Me.txtApplyID.Location = New System.Drawing.Point(99, 17)
        Me.txtApplyID.Name = "txtApplyID"
        Me.txtApplyID.Size = New System.Drawing.Size(75, 21)
        Me.txtApplyID.TabIndex = 5
        '
        'txtMOID
        '
        Me.txtMOID.Location = New System.Drawing.Point(265, 14)
        Me.txtMOID.Name = "txtMOID"
        Me.txtMOID.Size = New System.Drawing.Size(170, 21)
        Me.txtMOID.TabIndex = 6
        '
        'txtPNumber
        '
        Me.txtPNumber.Location = New System.Drawing.Point(526, 14)
        Me.txtPNumber.Name = "txtPNumber"
        Me.txtPNumber.Size = New System.Drawing.Size(125, 21)
        Me.txtPNumber.TabIndex = 7
        '
        'txtQTY
        '
        Me.txtQTY.Location = New System.Drawing.Point(99, 93)
        Me.txtQTY.Name = "txtQTY"
        Me.txtQTY.Size = New System.Drawing.Size(72, 21)
        Me.txtQTY.TabIndex = 8
        Me.txtQTY.Text = "1"
        Me.txtQTY.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(364, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "线别："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "厂别："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "数量："
        Me.Label6.Visible = False
        '
        'cboDept
        '
        Me.cboDept.FormattingEnabled = True
        Me.cboDept.Location = New System.Drawing.Point(253, 56)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(98, 20)
        Me.cboDept.TabIndex = 12
        '
        'cboLine
        '
        Me.cboLine.FormattingEnabled = True
        Me.cboLine.Location = New System.Drawing.Point(411, 56)
        Me.cboLine.Name = "cboLine"
        Me.cboLine.Size = New System.Drawing.Size(88, 20)
        Me.cboLine.TabIndex = 13
        '
        'cboFactory
        '
        Me.cboFactory.FormattingEnabled = True
        Me.cboFactory.Items.AddRange(New Object() {" "})
        Me.cboFactory.Location = New System.Drawing.Point(99, 53)
        Me.cboFactory.Name = "cboFactory"
        Me.cboFactory.Size = New System.Drawing.Size(75, 20)
        Me.cboFactory.TabIndex = 14
        '
        'dgvApply
        '
        Me.dgvApply.AllowUserToAddRows = False
        Me.dgvApply.AllowUserToDeleteRows = False
        Me.dgvApply.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvApply.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cboSelect, Me.QTY})
        Me.dgvApply.Location = New System.Drawing.Point(12, 167)
        Me.dgvApply.Name = "dgvApply"
        Me.dgvApply.RowTemplate.Height = 23
        Me.dgvApply.Size = New System.Drawing.Size(651, 360)
        Me.dgvApply.TabIndex = 15
        '
        'cboSelect
        '
        Me.cboSelect.FalseValue = " "
        Me.cboSelect.HeaderText = "选择"
        Me.cboSelect.Name = "cboSelect"
        Me.cboSelect.TrueValue = ""
        '
        'QTY
        '
        Me.QTY.HeaderText = "数量"
        Me.QTY.Name = "QTY"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(252, 17)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 16
        Me.btnSearch.Text = " 查询"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnOK)
        Me.GroupBox1.Controls.Add(Me.lbsd)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboFactory)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboLine)
        Me.GroupBox1.Controls.Add(Me.txtApplyID)
        Me.GroupBox1.Controls.Add(Me.cboDept)
        Me.GroupBox1.Controls.Add(Me.txtMOID)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtPNumber)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtQTY)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(666, 140)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvEquipment)
        Me.GroupBox2.Controls.Add(Me.txtLine)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.btnSearch)
        Me.GroupBox2.Location = New System.Drawing.Point(686, 30)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(480, 257)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        '
        'dgvEquipment
        '
        Me.dgvEquipment.AllowUserToAddRows = False
        Me.dgvEquipment.AllowUserToDeleteRows = False
        Me.dgvEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEquipment.Location = New System.Drawing.Point(30, 72)
        Me.dgvEquipment.Name = "dgvEquipment"
        Me.dgvEquipment.ReadOnly = True
        Me.dgvEquipment.RowTemplate.Height = 23
        Me.dgvEquipment.Size = New System.Drawing.Size(447, 179)
        Me.dgvEquipment.TabIndex = 19
        '
        'txtLine
        '
        Me.txtLine.Location = New System.Drawing.Point(129, 17)
        Me.txtLine.Name = "txtLine"
        Me.txtLine.Size = New System.Drawing.Size(70, 21)
        Me.txtLine.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 12)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "按线别查询工治具："
        '
        'EquipmentApply
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1234, 542)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvApply)
        Me.Name = "EquipmentApply"
        Me.Text = "申请工治具"
        CType(Me.dgvApply, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvEquipment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbsd As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtApplyID As System.Windows.Forms.TextBox
    Friend WithEvents txtMOID As System.Windows.Forms.TextBox
    Friend WithEvents txtPNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtQTY As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboDept As System.Windows.Forms.ComboBox
    Friend WithEvents cboLine As System.Windows.Forms.ComboBox
    Friend WithEvents cboFactory As System.Windows.Forms.ComboBox
    Friend WithEvents dgvApply As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLine As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgvEquipment As System.Windows.Forms.DataGridView
    Friend WithEvents cboSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents QTY As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
