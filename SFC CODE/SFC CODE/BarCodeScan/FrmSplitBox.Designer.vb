<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSplitBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSplitBox))
        Me.txtOldCarton = New TextBoxUL.TextBoxUL()
        Me.lblCode01 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNewCarton = New TextBoxUL.TextBoxUL()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPpid = New TextBoxUL.TextBoxUL()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.gridView1 = New System.Windows.Forms.DataGridView()
        Me.ppid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gridView2 = New System.Windows.Forms.DataGridView()
        Me.ppid2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblOldQty = New System.Windows.Forms.Label()
        Me.lblNewQtyShould = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblNewQtyFact = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.groupBox3.SuspendLayout()
        CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtOldCarton
        '
        Me.txtOldCarton.BackColor = System.Drawing.Color.White
        Me.txtOldCarton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtOldCarton.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOldCarton.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOldCarton.Font = New System.Drawing.Font("宋体", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtOldCarton.Location = New System.Drawing.Point(91, 17)
        Me.txtOldCarton.Name = "txtOldCarton"
        Me.txtOldCarton.Size = New System.Drawing.Size(320, 17)
        Me.txtOldCarton.TabIndex = 23
        '
        'lblCode01
        '
        Me.lblCode01.AutoSize = True
        Me.lblCode01.Location = New System.Drawing.Point(14, 20)
        Me.lblCode01.Name = "lblCode01"
        Me.lblCode01.Size = New System.Drawing.Size(71, 12)
        Me.lblCode01.TabIndex = 106
        Me.lblCode01.Text = "旧外箱条码:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 12)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "新外箱条码:"
        '
        'txtNewCarton
        '
        Me.txtNewCarton.BackColor = System.Drawing.Color.White
        Me.txtNewCarton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtNewCarton.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNewCarton.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNewCarton.Font = New System.Drawing.Font("宋体", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtNewCarton.Location = New System.Drawing.Point(91, 48)
        Me.txtNewCarton.Name = "txtNewCarton"
        Me.txtNewCarton.Size = New System.Drawing.Size(320, 17)
        Me.txtNewCarton.TabIndex = 107
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "产品条码:"
        '
        'txtPpid
        '
        Me.txtPpid.BackColor = System.Drawing.Color.White
        Me.txtPpid.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPpid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPpid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPpid.Font = New System.Drawing.Font("宋体", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtPpid.Location = New System.Drawing.Point(91, 79)
        Me.txtPpid.Name = "txtPpid"
        Me.txtPpid.Size = New System.Drawing.Size(320, 17)
        Me.txtPpid.TabIndex = 109
        '
        'groupBox3
        '
        Me.groupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox3.BackColor = System.Drawing.Color.White
        Me.groupBox3.Controls.Add(Me.lblMessage)
        Me.groupBox3.Controls.Add(Me.lblResult)
        Me.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.groupBox3.ForeColor = System.Drawing.Color.Black
        Me.groupBox3.Location = New System.Drawing.Point(3, 3)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(512, 93)
        Me.groupBox3.TabIndex = 183
        Me.groupBox3.TabStop = False
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMessage.Location = New System.Drawing.Point(6, 50)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(106, 40)
        Me.lblMessage.TabIndex = 86
        Me.lblMessage.Text = "PASS"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResult.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblResult.Location = New System.Drawing.Point(10, 11)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(257, 19)
        Me.lblResult.TabIndex = 82
        Me.lblResult.Text = "CN0XX5807244997E000A000026"
        Me.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gridView1
        '
        Me.gridView1.AllowUserToAddRows = False
        Me.gridView1.AllowUserToDeleteRows = False
        Me.gridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridView1.BackgroundColor = System.Drawing.Color.White
        Me.gridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ppid})
        Me.gridView1.Location = New System.Drawing.Point(3, 138)
        Me.gridView1.Name = "gridView1"
        Me.gridView1.ReadOnly = True
        Me.gridView1.RowTemplate.Height = 23
        Me.gridView1.Size = New System.Drawing.Size(407, 297)
        Me.gridView1.TabIndex = 184
        '
        'ppid
        '
        Me.ppid.HeaderText = "产品条码 "
        Me.ppid.Name = "ppid"
        Me.ppid.ReadOnly = True
        Me.ppid.Width = 220
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(30, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 12)
        Me.Label3.TabIndex = 185
        Me.Label3.Text = "旧箱产品明细"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Green
        Me.Label4.Location = New System.Drawing.Point(9, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 12)
        Me.Label4.TabIndex = 186
        Me.Label4.Text = "新箱产品明细"
        '
        'gridView2
        '
        Me.gridView2.AllowUserToAddRows = False
        Me.gridView2.AllowUserToDeleteRows = False
        Me.gridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridView2.BackgroundColor = System.Drawing.Color.White
        Me.gridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ppid2})
        Me.gridView2.Location = New System.Drawing.Point(3, 138)
        Me.gridView2.Name = "gridView2"
        Me.gridView2.ReadOnly = True
        Me.gridView2.RowTemplate.Height = 23
        Me.gridView2.Size = New System.Drawing.Size(512, 295)
        Me.gridView2.TabIndex = 187
        '
        'ppid2
        '
        Me.ppid2.HeaderText = "产品条码 "
        Me.ppid2.Name = "ppid2"
        Me.ppid2.ReadOnly = True
        Me.ppid2.Width = 220
        '
        'lblOldQty
        '
        Me.lblOldQty.AutoSize = True
        Me.lblOldQty.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblOldQty.Location = New System.Drawing.Point(213, 112)
        Me.lblOldQty.Name = "lblOldQty"
        Me.lblOldQty.Size = New System.Drawing.Size(12, 12)
        Me.lblOldQty.TabIndex = 188
        Me.lblOldQty.Text = " "
        '
        'lblNewQtyShould
        '
        Me.lblNewQtyShould.AutoSize = True
        Me.lblNewQtyShould.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblNewQtyShould.Location = New System.Drawing.Point(193, 110)
        Me.lblNewQtyShould.Name = "lblNewQtyShould"
        Me.lblNewQtyShould.Size = New System.Drawing.Size(19, 12)
        Me.lblNewQtyShould.TabIndex = 188
        Me.lblNewQtyShould.Text = "  "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(9, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 12)
        Me.Label5.TabIndex = 186
        Me.Label5.Text = "新箱产品明细"
        '
        'lblNewQtyFact
        '
        Me.lblNewQtyFact.AutoSize = True
        Me.lblNewQtyFact.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblNewQtyFact.Location = New System.Drawing.Point(322, 110)
        Me.lblNewQtyFact.Name = "lblNewQtyFact"
        Me.lblNewQtyFact.Size = New System.Drawing.Size(19, 12)
        Me.lblNewQtyFact.TabIndex = 188
        Me.lblNewQtyFact.Text = "  "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.Location = New System.Drawing.Point(131, 110)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 188
        Me.Label7.Text = "应装数量："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.Location = New System.Drawing.Point(262, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 188
        Me.Label8.Text = "实装数量："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.Location = New System.Drawing.Point(155, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 188
        Me.Label9.Text = "剩余数量："
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtNewCarton)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtOldCarton)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblCode01)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblOldQty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtPpid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gridView1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.groupBox3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.gridView2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblNewQtyFact)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblNewQtyShould)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label7)
        Me.SplitContainer1.Size = New System.Drawing.Size(947, 447)
        Me.SplitContainer1.SplitterDistance = 425
        Me.SplitContainer1.TabIndex = 189
        '
        'FrmSplitBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(947, 447)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmSplitBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "分箱作业"
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtOldCarton As TextBoxUL.TextBoxUL
    Friend WithEvents lblCode01 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNewCarton As TextBoxUL.TextBoxUL
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPpid As TextBoxUL.TextBoxUL
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents lblMessage As System.Windows.Forms.Label
    Private WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents gridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents ppid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ppid2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblOldQty As System.Windows.Forms.Label
    Friend WithEvents lblNewQtyShould As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblNewQtyFact As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
End Class
