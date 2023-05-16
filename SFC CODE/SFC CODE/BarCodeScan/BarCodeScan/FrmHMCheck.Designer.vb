<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHMCheck
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbtnSelecte = New System.Windows.Forms.RadioButton()
        Me.rbtnSelected = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LabResult = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.txtPackingBoxBarcode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPackingBoxCartonCode = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgvUnPackBox = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataERR = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvUnPackBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataERR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.rbtnSelecte)
        Me.GroupBox2.Controls.Add(Me.rbtnSelected)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.txtPackingBoxBarcode)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtPackingBoxCartonCode)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(938, 140)
        Me.GroupBox2.TabIndex = 144
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(164, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 12)
        Me.Label2.TabIndex = 112
        '
        'rbtnSelecte
        '
        Me.rbtnSelecte.AutoSize = True
        Me.rbtnSelecte.Location = New System.Drawing.Point(87, 11)
        Me.rbtnSelecte.Name = "rbtnSelecte"
        Me.rbtnSelecte.Size = New System.Drawing.Size(71, 16)
        Me.rbtnSelecte.TabIndex = 111
        Me.rbtnSelecte.Text = "扫描产品"
        Me.rbtnSelecte.UseVisualStyleBackColor = True
        '
        'rbtnSelected
        '
        Me.rbtnSelected.AutoSize = True
        Me.rbtnSelected.Checked = True
        Me.rbtnSelected.Location = New System.Drawing.Point(10, 11)
        Me.rbtnSelected.Name = "rbtnSelected"
        Me.rbtnSelected.Size = New System.Drawing.Size(71, 16)
        Me.rbtnSelected.TabIndex = 110
        Me.rbtnSelected.TabStop = True
        Me.rbtnSelected.Text = "扫描外箱"
        Me.rbtnSelected.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.LabResult)
        Me.GroupBox3.Controls.Add(Me.lblMessage)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(444, 34)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(494, 82)
        Me.GroupBox3.TabIndex = 109
        Me.GroupBox3.TabStop = False
        '
        'LabResult
        '
        Me.LabResult.AutoSize = True
        Me.LabResult.Font = New System.Drawing.Font("Arial", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabResult.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabResult.Location = New System.Drawing.Point(6, 40)
        Me.LabResult.Name = "LabResult"
        Me.LabResult.Size = New System.Drawing.Size(106, 40)
        Me.LabResult.TabIndex = 86
        Me.LabResult.Text = "PASS"
        Me.LabResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMessage.Location = New System.Drawing.Point(7, 15)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(257, 19)
        Me.lblMessage.TabIndex = 82
        Me.lblMessage.Text = "CN0XX5807244997E000A000026"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPackingBoxBarcode
        '
        Me.txtPackingBoxBarcode.Enabled = False
        Me.txtPackingBoxBarcode.Location = New System.Drawing.Point(71, 83)
        Me.txtPackingBoxBarcode.Name = "txtPackingBoxBarcode"
        Me.txtPackingBoxBarcode.Size = New System.Drawing.Size(367, 21)
        Me.txtPackingBoxBarcode.TabIndex = 108
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 107
        Me.Label5.Text = "产品条码："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "外箱标签："
        '
        'txtPackingBoxCartonCode
        '
        Me.txtPackingBoxCartonCode.Location = New System.Drawing.Point(71, 43)
        Me.txtPackingBoxCartonCode.Name = "txtPackingBoxCartonCode"
        Me.txtPackingBoxCartonCode.Size = New System.Drawing.Size(367, 21)
        Me.txtPackingBoxCartonCode.TabIndex = 106
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox4.Controls.Add(Me.dgvUnPackBox)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 147)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(760, 325)
        Me.GroupBox4.TabIndex = 145
        Me.GroupBox4.TabStop = False
        '
        'dgvUnPackBox
        '
        Me.dgvUnPackBox.AllowUserToAddRows = False
        Me.dgvUnPackBox.AllowUserToDeleteRows = False
        Me.dgvUnPackBox.BackgroundColor = System.Drawing.Color.White
        Me.dgvUnPackBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvUnPackBox.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvUnPackBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUnPackBox.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.Column1, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.dgvUnPackBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUnPackBox.Location = New System.Drawing.Point(3, 17)
        Me.dgvUnPackBox.Name = "dgvUnPackBox"
        Me.dgvUnPackBox.ReadOnly = True
        Me.dgvUnPackBox.RowHeadersWidth = 4
        Me.dgvUnPackBox.RowTemplate.Height = 23
        Me.dgvUnPackBox.Size = New System.Drawing.Size(754, 305)
        Me.dgvUnPackBox.TabIndex = 136
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Cartonid"
        Me.DataGridViewTextBoxColumn4.HeaderText = "外箱条码"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 129
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "sn"
        Me.Column1.HeaderText = "产品条码"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 128
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "UseId"
        Me.DataGridViewTextBoxColumn5.HeaderText = "扫描人员"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 129
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "INTIME"
        Me.DataGridViewTextBoxColumn6.HeaderText = "扫描时间"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 128
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.DataERR)
        Me.GroupBox1.Location = New System.Drawing.Point(757, 147)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(184, 325)
        Me.GroupBox1.TabIndex = 146
        Me.GroupBox1.TabStop = False
        '
        'DataERR
        '
        Me.DataERR.AllowUserToAddRows = False
        Me.DataERR.AllowUserToDeleteRows = False
        Me.DataERR.AllowUserToResizeColumns = False
        Me.DataERR.AllowUserToResizeRows = False
        Me.DataERR.BackgroundColor = System.Drawing.Color.White
        Me.DataERR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataERR.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataERR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataERR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        Me.DataERR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataERR.Location = New System.Drawing.Point(3, 17)
        Me.DataERR.Name = "DataERR"
        Me.DataERR.ReadOnly = True
        Me.DataERR.RowHeadersWidth = 4
        Me.DataERR.RowTemplate.Height = 23
        Me.DataERR.Size = New System.Drawing.Size(178, 305)
        Me.DataERR.TabIndex = 136
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Err"
        Me.DataGridViewTextBoxColumn1.HeaderText = "错误内容"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 520
        '
        'FrmHMCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 471)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "FrmHMCheck"
        Me.Text = "华米校验外箱"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvUnPackBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataERR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents LabResult As System.Windows.Forms.Label
    Private WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents txtPackingBoxBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPackingBoxCartonCode As System.Windows.Forms.TextBox
    Friend WithEvents rbtnSelected As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnSelecte As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvUnPackBox As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataERR As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
