<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQcSnDetail
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
        Me.dgvCheckSN = New System.Windows.Forms.DataGridView()
        Me.gbImg = New System.Windows.Forms.GroupBox()
        Me.imgNg = New System.Windows.Forms.PictureBox()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPicPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvCheckSN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbImg.SuspendLayout()
        CType(Me.imgNg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCheckSN
        '
        Me.dgvCheckSN.AllowUserToAddRows = False
        Me.dgvCheckSN.AllowUserToDeleteRows = False
        Me.dgvCheckSN.BackgroundColor = System.Drawing.Color.White
        Me.dgvCheckSN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCheckSN.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.colPicPath})
        Me.dgvCheckSN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCheckSN.Location = New System.Drawing.Point(0, 0)
        Me.dgvCheckSN.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvCheckSN.Name = "dgvCheckSN"
        Me.dgvCheckSN.ReadOnly = True
        Me.dgvCheckSN.RowTemplate.Height = 23
        Me.dgvCheckSN.Size = New System.Drawing.Size(1069, 609)
        Me.dgvCheckSN.TabIndex = 1
        '
        'gbImg
        '
        Me.gbImg.Controls.Add(Me.imgNg)
        Me.gbImg.Dock = System.Windows.Forms.DockStyle.Right
        Me.gbImg.Location = New System.Drawing.Point(1069, 0)
        Me.gbImg.Name = "gbImg"
        Me.gbImg.Size = New System.Drawing.Size(350, 609)
        Me.gbImg.TabIndex = 2
        Me.gbImg.TabStop = False
        Me.gbImg.Text = "不良图片显示"
        '
        'imgNg
        '
        Me.imgNg.Dock = System.Windows.Forms.DockStyle.Top
        Me.imgNg.Location = New System.Drawing.Point(3, 24)
        Me.imgNg.Name = "imgNg"
        Me.imgNg.Size = New System.Drawing.Size(344, 335)
        Me.imgNg.TabIndex = 0
        Me.imgNg.TabStop = False
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column1.DataPropertyName = "SN"
        Me.Column1.HeaderText = "产品条码"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Result"
        Me.Column2.HeaderText = "判定状况"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 80
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "TestitemName"
        Me.Column3.HeaderText = "检验大项"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "SmallName"
        Me.Column4.HeaderText = "检验小项"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "NgCodeId"
        Me.Column5.HeaderText = "不良现象代码"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "CCName"
        Me.Column6.HeaderText = "不良现象名称"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'colPicPath
        '
        Me.colPicPath.DataPropertyName = "PicPath"
        Me.colPicPath.HeaderText = "图片"
        Me.colPicPath.Name = "colPicPath"
        Me.colPicPath.ReadOnly = True
        Me.colPicPath.Visible = False
        '
        'FrmQcSnDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1419, 609)
        Me.Controls.Add(Me.dgvCheckSN)
        Me.Controls.Add(Me.gbImg)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "FrmQcSnDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "检验条码明细 "
        CType(Me.dgvCheckSN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbImg.ResumeLayout(False)
        CType(Me.imgNg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvCheckSN As System.Windows.Forms.DataGridView
    Friend WithEvents gbImg As System.Windows.Forms.GroupBox
    Friend WithEvents imgNg As System.Windows.Forms.PictureBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPicPath As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
