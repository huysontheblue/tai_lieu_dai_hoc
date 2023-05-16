<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmployeeOnJob
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
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEmpNo = New System.Windows.Forms.TextBox()
        Me.txtEmpName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnTuiSong = New System.Windows.Forms.Button()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.dgvSelect = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Chk = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.CompanyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeptName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRemove = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.CompanyName1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeptName1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpCode1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpName1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Chk, Me.CompanyName, Me.DeptName, Me.EmpCode, Me.EmpName, Me.Email})
        Me.dgvData.Location = New System.Drawing.Point(3, 43)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowTemplate.Height = 23
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(504, 170)
        Me.dgvData.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "工号:"
        '
        'txtEmpNo
        '
        Me.txtEmpNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpNo.Location = New System.Drawing.Point(47, 16)
        Me.txtEmpNo.Name = "txtEmpNo"
        Me.txtEmpNo.Size = New System.Drawing.Size(100, 21)
        Me.txtEmpNo.TabIndex = 2
        '
        'txtEmpName
        '
        Me.txtEmpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpName.Location = New System.Drawing.Point(201, 16)
        Me.txtEmpName.Name = "txtEmpName"
        Me.txtEmpName.Size = New System.Drawing.Size(100, 21)
        Me.txtEmpName.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(166, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "姓名:"
        '
        'BtnTuiSong
        '
        Me.BtnTuiSong.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnTuiSong.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BtnTuiSong.ForeColor = System.Drawing.Color.Blue
        Me.BtnTuiSong.Location = New System.Drawing.Point(431, 14)
        Me.BtnTuiSong.Name = "BtnTuiSong"
        Me.BtnTuiSong.Size = New System.Drawing.Size(75, 23)
        Me.BtnTuiSong.TabIndex = 5
        Me.BtnTuiSong.Text = "推送"
        Me.BtnTuiSong.UseVisualStyleBackColor = True
        '
        'BtnSearch
        '
        Me.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnSearch.Location = New System.Drawing.Point(320, 14)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(75, 23)
        Me.BtnSearch.TabIndex = 6
        Me.BtnSearch.Text = "查询"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'dgvSelect
        '
        Me.dgvSelect.AllowUserToAddRows = False
        Me.dgvSelect.AllowUserToDeleteRows = False
        Me.dgvSelect.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSelect.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSelect.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColRemove, Me.CompanyName1, Me.DeptName1, Me.EmpCode1, Me.EmpName1, Me.Email1})
        Me.dgvSelect.Location = New System.Drawing.Point(3, 239)
        Me.dgvSelect.Name = "dgvSelect"
        Me.dgvSelect.ReadOnly = True
        Me.dgvSelect.RowHeadersVisible = False
        Me.dgvSelect.RowTemplate.Height = 23
        Me.dgvSelect.Size = New System.Drawing.Size(504, 181)
        Me.dgvSelect.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(3, 220)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "已选择推送列表"
        '
        'Chk
        '
        Me.Chk.HeaderText = ""
        Me.Chk.Name = "Chk"
        Me.Chk.ReadOnly = True
        Me.Chk.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Chk.Text = "选择"
        Me.Chk.UseColumnTextForButtonValue = True
        Me.Chk.Width = 40
        '
        'CompanyName
        '
        Me.CompanyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CompanyName.DataPropertyName = "CompanyName"
        Me.CompanyName.HeaderText = "工厂名称"
        Me.CompanyName.Name = "CompanyName"
        Me.CompanyName.ReadOnly = True
        Me.CompanyName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DeptName
        '
        Me.DeptName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DeptName.DataPropertyName = "DeptName"
        Me.DeptName.HeaderText = "部门"
        Me.DeptName.Name = "DeptName"
        Me.DeptName.ReadOnly = True
        Me.DeptName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'EmpCode
        '
        Me.EmpCode.DataPropertyName = "EmpCode"
        Me.EmpCode.HeaderText = "工号"
        Me.EmpCode.Name = "EmpCode"
        Me.EmpCode.ReadOnly = True
        Me.EmpCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'EmpName
        '
        Me.EmpName.DataPropertyName = "EmpName"
        Me.EmpName.HeaderText = "姓名"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.ReadOnly = True
        Me.EmpName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Email
        '
        Me.Email.DataPropertyName = "Email"
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        Me.Email.Visible = False
        '
        'ColRemove
        '
        Me.ColRemove.HeaderText = ""
        Me.ColRemove.Name = "ColRemove"
        Me.ColRemove.ReadOnly = True
        Me.ColRemove.Text = "移除"
        Me.ColRemove.UseColumnTextForButtonValue = True
        Me.ColRemove.Width = 40
        '
        'CompanyName1
        '
        Me.CompanyName1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CompanyName1.DataPropertyName = "CompanyName"
        Me.CompanyName1.HeaderText = "工厂名称"
        Me.CompanyName1.Name = "CompanyName1"
        Me.CompanyName1.ReadOnly = True
        Me.CompanyName1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DeptName1
        '
        Me.DeptName1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DeptName1.DataPropertyName = "DeptName"
        Me.DeptName1.HeaderText = "部门"
        Me.DeptName1.Name = "DeptName1"
        Me.DeptName1.ReadOnly = True
        Me.DeptName1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'EmpCode1
        '
        Me.EmpCode1.DataPropertyName = "EmpCode"
        Me.EmpCode1.HeaderText = "工号"
        Me.EmpCode1.Name = "EmpCode1"
        Me.EmpCode1.ReadOnly = True
        Me.EmpCode1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'EmpName1
        '
        Me.EmpName1.DataPropertyName = "EmpName"
        Me.EmpName1.HeaderText = "姓名"
        Me.EmpName1.Name = "EmpName1"
        Me.EmpName1.ReadOnly = True
        Me.EmpName1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Email1
        '
        Me.Email1.DataPropertyName = "Email"
        Me.Email1.HeaderText = "Email"
        Me.Email1.Name = "Email1"
        Me.Email1.ReadOnly = True
        Me.Email1.Visible = False
        '
        'FrmEmployeeOnJob
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 422)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvSelect)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.BtnTuiSong)
        Me.Controls.Add(Me.txtEmpName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtEmpNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvData)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEmployeeOnJob"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BOF清单治具进度完成-推送人员"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSelect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEmpNo As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnTuiSong As System.Windows.Forms.Button
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents dgvSelect As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Chk As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents CompanyName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRemove As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents CompanyName1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptName1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpCode1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
