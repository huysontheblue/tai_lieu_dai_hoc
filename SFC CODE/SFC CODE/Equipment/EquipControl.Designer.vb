<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EquipControl
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DgMoData = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Comoid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColPartid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column24 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDept = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColLine = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Colqty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Coltype = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Colstate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCustomer = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DgMoData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgMoData
        '
        Me.DgMoData.AllowUserToAddRows = False
        Me.DgMoData.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.DgMoData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgMoData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgMoData.BackgroundColor = System.Drawing.Color.White
        Me.DgMoData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgMoData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.DgMoData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgMoData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgMoData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Comoid, Me.ColPartid, Me.Column24, Me.ColDept, Me.ColLine, Me.Colqty, Me.Coltype, Me.Colstate, Me.ColCustomer, Me.Column2, Me.Column3})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgMoData.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgMoData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DgMoData.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.DgMoData.Location = New System.Drawing.Point(23, 12)
        Me.DgMoData.MultiSelect = False
        Me.DgMoData.Name = "DgMoData"
        Me.DgMoData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DgMoData.RowHeadersWidth = 4
        Me.DgMoData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgMoData.RowTemplate.Height = 24
        Me.DgMoData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgMoData.ShowEditingIcon = False
        Me.DgMoData.Size = New System.Drawing.Size(1019, 300)
        Me.DgMoData.TabIndex = 17
        Me.DgMoData.TabStop = False
        '
        'Column1
        '
        Me.Column1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Column1.HeaderText = "选择"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 50
        '
        'Comoid
        '
        Me.Comoid.HeaderText = "工单编号"
        Me.Comoid.Name = "Comoid"
        Me.Comoid.ReadOnly = True
        Me.Comoid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Comoid.Width = 120
        '
        'ColPartid
        '
        Me.ColPartid.HeaderText = "料件编号"
        Me.ColPartid.Name = "ColPartid"
        Me.ColPartid.ReadOnly = True
        Me.ColPartid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column24
        '
        Me.Column24.HeaderText = "品名"
        Me.Column24.Name = "Column24"
        Me.Column24.ReadOnly = True
        Me.Column24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column24.Width = 53
        '
        'ColDept
        '
        Me.ColDept.HeaderText = "生产部门"
        Me.ColDept.Name = "ColDept"
        Me.ColDept.ReadOnly = True
        Me.ColDept.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColDept.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDept.Width = 150
        '
        'ColLine
        '
        Me.ColLine.HeaderText = "生产线别"
        Me.ColLine.Name = "ColLine"
        Me.ColLine.ReadOnly = True
        Me.ColLine.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColLine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColLine.Width = 120
        '
        'Colqty
        '
        Me.Colqty.HeaderText = "工单数量"
        Me.Colqty.Name = "Colqty"
        Me.Colqty.ReadOnly = True
        Me.Colqty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Colqty.Width = 77
        '
        'Coltype
        '
        Me.Coltype.HeaderText = "工单类型"
        Me.Coltype.Name = "Coltype"
        Me.Coltype.ReadOnly = True
        Me.Coltype.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Coltype.Width = 77
        '
        'Colstate
        '
        Me.Colstate.HeaderText = "工单状态"
        Me.Colstate.Name = "Colstate"
        Me.Colstate.ReadOnly = True
        Me.Colstate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Colstate.Width = 77
        '
        'ColCustomer
        '
        Me.ColCustomer.HeaderText = "客户代码"
        Me.ColCustomer.Name = "ColCustomer"
        Me.ColCustomer.ReadOnly = True
        Me.ColCustomer.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColCustomer.Width = 70
        '
        'Column2
        '
        Me.Column2.HeaderText = "订单编号"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "订单项次"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'EquipControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1074, 462)
        Me.Controls.Add(Me.DgMoData)
        Me.Name = "EquipControl"
        Me.Text = "EquipControl"
        CType(Me.DgMoData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgMoData As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Comoid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPartid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Colqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Coltype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Colstate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCustomer As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
