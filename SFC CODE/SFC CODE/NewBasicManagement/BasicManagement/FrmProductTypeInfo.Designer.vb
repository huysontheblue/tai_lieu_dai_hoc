<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductTypeInfo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProductTypeInfo))
        Me.DgvData = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtProductType = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolAdd = New System.Windows.Forms.ToolStripButton()
        Me.toolEdit = New System.Windows.Forms.ToolStripButton()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.toolBack = New System.Windows.Forms.ToolStripButton()
        Me.ColProductTypeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColProductType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColInUserCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColinUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColinTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvData
        '
        Me.DgvData.AllowUserToAddRows = False
        Me.DgvData.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.DgvData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvData.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColProductTypeID, Me.ColProductType, Me.ColInUserCode, Me.ColinUser, Me.ColinTime})
        Me.DgvData.Location = New System.Drawing.Point(1, 76)
        Me.DgvData.Name = "DgvData"
        Me.DgvData.RowHeadersVisible = False
        Me.DgvData.RowTemplate.Height = 23
        Me.DgvData.Size = New System.Drawing.Size(849, 366)
        Me.DgvData.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "产品类型名称:"
        '
        'TxtProductType
        '
        Me.TxtProductType.Location = New System.Drawing.Point(101, 34)
        Me.TxtProductType.Name = "TxtProductType"
        Me.TxtProductType.Size = New System.Drawing.Size(190, 21)
        Me.TxtProductType.TabIndex = 3
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAdd, Me.toolEdit, Me.toolSave, Me.toolBack})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(851, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'toolAdd
        '
        Me.toolAdd.Image = CType(resources.GetObject("toolAdd.Image"), System.Drawing.Image)
        Me.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAdd.Name = "toolAdd"
        Me.toolAdd.Size = New System.Drawing.Size(74, 22)
        Me.toolAdd.Tag = "NO"
        Me.toolAdd.Text = "新 增(&N)"
        '
        'toolEdit
        '
        Me.toolEdit.Image = CType(resources.GetObject("toolEdit.Image"), System.Drawing.Image)
        Me.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEdit.Name = "toolEdit"
        Me.toolEdit.Size = New System.Drawing.Size(71, 22)
        Me.toolEdit.Tag = "NO"
        Me.toolEdit.Text = "修 改(&E)"
        '
        'toolSave
        '
        Me.toolSave.Image = CType(resources.GetObject("toolSave.Image"), System.Drawing.Image)
        Me.toolSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(73, 22)
        Me.toolSave.Tag = ""
        Me.toolSave.Text = "保 存(&S)"
        '
        'toolBack
        '
        Me.toolBack.Image = CType(resources.GetObject("toolBack.Image"), System.Drawing.Image)
        Me.toolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBack.Name = "toolBack"
        Me.toolBack.Size = New System.Drawing.Size(72, 22)
        Me.toolBack.Tag = ""
        Me.toolBack.Text = "返 回(&B)"
        '
        'ColProductTypeID
        '
        Me.ColProductTypeID.DataPropertyName = "ProductTypeID"
        Me.ColProductTypeID.HeaderText = "产品类型编号"
        Me.ColProductTypeID.Name = "ColProductTypeID"
        Me.ColProductTypeID.ReadOnly = True
        '
        'ColProductType
        '
        Me.ColProductType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColProductType.DataPropertyName = "ProductType"
        Me.ColProductType.HeaderText = "产品类型名称"
        Me.ColProductType.Name = "ColProductType"
        '
        'ColInUserCode
        '
        Me.ColInUserCode.DataPropertyName = "InUserCode"
        Me.ColInUserCode.HeaderText = "设置人工号"
        Me.ColInUserCode.Name = "ColInUserCode"
        '
        'ColinUser
        '
        Me.ColinUser.DataPropertyName = "inUser"
        Me.ColinUser.HeaderText = "设置人姓名"
        Me.ColinUser.Name = "ColinUser"
        '
        'ColinTime
        '
        Me.ColinTime.DataPropertyName = "inTime"
        Me.ColinTime.HeaderText = "设置时间"
        Me.ColinTime.Name = "ColinTime"
        '
        'FrmProductTypeInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 443)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TxtProductType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DgvData)
        Me.Name = "FrmProductTypeInfo"
        Me.ShowIcon = False
        Me.Text = "产品类型基础资料"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvData As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtProductType As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEdit As System.Windows.Forms.ToolStripButton
    Private WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColProductTypeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColProductType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColInUserCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColinUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColinTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
