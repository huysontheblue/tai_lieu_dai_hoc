<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWmsOutterBBY
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
        Me.txtSKU = New System.Windows.Forms.TextBox()
        Me.txtPO = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.lblRequirement = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.lblOut = New System.Windows.Forms.Label()
        Me.lblSentNumber = New System.Windows.Forms.Label()
        Me.label16 = New System.Windows.Forms.Label()
        Me.label12 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.dgvUnPackBox = New System.Windows.Forms.DataGridView()
        Me.PO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SKU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USERID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvUnPackBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSKU
        '
        Me.txtSKU.Location = New System.Drawing.Point(286, 8)
        Me.txtSKU.MaxLength = 10
        Me.txtSKU.Name = "txtSKU"
        Me.txtSKU.Size = New System.Drawing.Size(177, 21)
        Me.txtSKU.TabIndex = 139
        '
        'txtPO
        '
        Me.txtPO.Location = New System.Drawing.Point(46, 7)
        Me.txtPO.MaxLength = 10
        Me.txtPO.Name = "txtPO"
        Me.txtPO.Size = New System.Drawing.Size(175, 21)
        Me.txtPO.TabIndex = 140
        '
        'label3
        '
        Me.label3.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.label3.Location = New System.Drawing.Point(4, 10)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(36, 20)
        Me.label3.TabIndex = 141
        Me.label3.Text = "PO:"
        '
        'label2
        '
        Me.label2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.label2.Location = New System.Drawing.Point(241, 10)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(39, 20)
        Me.label2.TabIndex = 142
        Me.label2.Text = "SKU:"
        '
        'lblRequirement
        '
        Me.lblRequirement.BackColor = System.Drawing.Color.Transparent
        Me.lblRequirement.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblRequirement.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblRequirement.Location = New System.Drawing.Point(411, 77)
        Me.lblRequirement.Name = "lblRequirement"
        Me.lblRequirement.Size = New System.Drawing.Size(55, 14)
        Me.lblRequirement.TabIndex = 149
        Me.lblRequirement.Text = "000"
        Me.lblRequirement.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'label7
        '
        Me.label7.BackColor = System.Drawing.Color.Transparent
        Me.label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.label7.ForeColor = System.Drawing.Color.RoyalBlue
        Me.label7.Location = New System.Drawing.Point(325, 77)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(55, 14)
        Me.label7.TabIndex = 150
        Me.label7.Text = "需求数"
        Me.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOut
        '
        Me.lblOut.BackColor = System.Drawing.Color.Transparent
        Me.lblOut.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblOut.ForeColor = System.Drawing.Color.Red
        Me.lblOut.Location = New System.Drawing.Point(236, 77)
        Me.lblOut.Name = "lblOut"
        Me.lblOut.Size = New System.Drawing.Size(55, 14)
        Me.lblOut.TabIndex = 151
        Me.lblOut.Text = "000"
        Me.lblOut.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSentNumber
        '
        Me.lblSentNumber.BackColor = System.Drawing.Color.Transparent
        Me.lblSentNumber.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblSentNumber.ForeColor = System.Drawing.Color.Green
        Me.lblSentNumber.Location = New System.Drawing.Point(87, 77)
        Me.lblSentNumber.Name = "lblSentNumber"
        Me.lblSentNumber.Size = New System.Drawing.Size(55, 14)
        Me.lblSentNumber.TabIndex = 152
        Me.lblSentNumber.Text = "000"
        Me.lblSentNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'label16
        '
        Me.label16.BackColor = System.Drawing.Color.Transparent
        Me.label16.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.label16.ForeColor = System.Drawing.Color.Red
        Me.label16.Location = New System.Drawing.Point(171, 77)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(55, 14)
        Me.label16.TabIndex = 153
        Me.label16.Text = "待出数"
        Me.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'label12
        '
        Me.label12.BackColor = System.Drawing.Color.Transparent
        Me.label12.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.label12.ForeColor = System.Drawing.Color.Green
        Me.label12.Location = New System.Drawing.Point(7, 77)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(55, 14)
        Me.label12.TabIndex = 154
        Me.label12.Text = "已出数"
        Me.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.label2)
        Me.Panel1.Controls.Add(Me.lblRequirement)
        Me.Panel1.Controls.Add(Me.label3)
        Me.Panel1.Controls.Add(Me.label7)
        Me.Panel1.Controls.Add(Me.txtPO)
        Me.Panel1.Controls.Add(Me.lblOut)
        Me.Panel1.Controls.Add(Me.txtSKU)
        Me.Panel1.Controls.Add(Me.label16)
        Me.Panel1.Controls.Add(Me.lblSentNumber)
        Me.Panel1.Controls.Add(Me.label12)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1185, 100)
        Me.Panel1.TabIndex = 155
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1191, 369)
        Me.SplitContainer1.SplitterDistance = 99
        Me.SplitContainer1.TabIndex = 157
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgvUnPackBox)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.lblMessage)
        Me.SplitContainer2.Size = New System.Drawing.Size(1191, 266)
        Me.SplitContainer2.SplitterDistance = 538
        Me.SplitContainer2.TabIndex = 157
        '
        'dgvUnPackBox
        '
        Me.dgvUnPackBox.AllowUserToAddRows = False
        Me.dgvUnPackBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUnPackBox.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PO, Me.SKU, Me.USERID, Me.intime})
        Me.dgvUnPackBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUnPackBox.Location = New System.Drawing.Point(0, 0)
        Me.dgvUnPackBox.Name = "dgvUnPackBox"
        Me.dgvUnPackBox.RowTemplate.Height = 23
        Me.dgvUnPackBox.Size = New System.Drawing.Size(538, 266)
        Me.dgvUnPackBox.TabIndex = 0
        '
        'PO
        '
        Me.PO.HeaderText = "PO"
        Me.PO.Name = "PO"
        '
        'SKU
        '
        Me.SKU.HeaderText = "SKU"
        Me.SKU.Name = "SKU"
        '
        'USERID
        '
        Me.USERID.HeaderText = "扫描人员"
        Me.USERID.Name = "USERID"
        '
        'intime
        '
        Me.intime.HeaderText = "扫描时间"
        Me.intime.Name = "intime"
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 25.0!, System.Drawing.FontStyle.Bold)
        Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMessage.Location = New System.Drawing.Point(3, 3)
        Me.lblMessage.Multiline = True
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(640, 260)
        Me.lblMessage.TabIndex = 88
        Me.lblMessage.Text = "PASS"
        '
        'FrmWmsOutterBBY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1191, 369)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmWmsOutterBBY"
        Me.Text = "BBY出货"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvUnPackBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents txtSKU As System.Windows.Forms.TextBox
    Private WithEvents txtPO As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents lblRequirement As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents lblOut As System.Windows.Forms.Label
    Private WithEvents lblSentNumber As System.Windows.Forms.Label
    Private WithEvents label16 As System.Windows.Forms.Label
    Private WithEvents label12 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvUnPackBox As System.Windows.Forms.DataGridView
    Friend WithEvents PO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SKU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USERID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents intime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
End Class
