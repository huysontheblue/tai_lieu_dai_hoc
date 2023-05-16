<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAddBOFToolListDetail
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbStation = New System.Windows.Forms.ComboBox()
        Me.BtnSubmit = New System.Windows.Forms.Button()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFixtureNumber = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCapacity = New System.Windows.Forms.TextBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDemandQty = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEquimentName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbEquimentType = New System.Windows.Forms.ComboBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.StationID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StationName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EquimentType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EquimentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DemandQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Capacity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FixtureNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtOrderBy = New DevComponents.Editors.IntegerInput()
        Me.BtnRemove = New System.Windows.Forms.Button()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrderBy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(101, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "工站:"
        '
        'cmbStation
        '
        Me.cmbStation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbStation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbStation.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbStation.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.cmbStation.FormattingEnabled = True
        Me.cmbStation.Location = New System.Drawing.Point(142, 7)
        Me.cmbStation.Name = "cmbStation"
        Me.cmbStation.Size = New System.Drawing.Size(611, 28)
        Me.cmbStation.TabIndex = 0
        '
        'BtnSubmit
        '
        Me.BtnSubmit.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BtnSubmit.Location = New System.Drawing.Point(398, 462)
        Me.BtnSubmit.Name = "BtnSubmit"
        Me.BtnSubmit.Size = New System.Drawing.Size(60, 32)
        Me.BtnSubmit.TabIndex = 12
        Me.BtnSubmit.TabStop = False
        Me.BtnSubmit.Text = "提交"
        Me.BtnSubmit.UseVisualStyleBackColor = True
        '
        'txtRemark
        '
        Me.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemark.Location = New System.Drawing.Point(67, 136)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(686, 21)
        Me.txtRemark.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 138)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 12)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "备    注:"
        '
        'txtFixtureNumber
        '
        Me.txtFixtureNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFixtureNumber.Location = New System.Drawing.Point(542, 100)
        Me.txtFixtureNumber.Name = "txtFixtureNumber"
        Me.txtFixtureNumber.Size = New System.Drawing.Size(211, 21)
        Me.txtFixtureNumber.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(477, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "治具料号:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(332, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "产能(H):"
        '
        'txtCapacity
        '
        Me.txtCapacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCapacity.Location = New System.Drawing.Point(385, 100)
        Me.txtCapacity.Name = "txtCapacity"
        Me.txtCapacity.Size = New System.Drawing.Size(84, 21)
        Me.txtCapacity.TabIndex = 5
        '
        'txtPrice
        '
        Me.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice.Location = New System.Drawing.Point(235, 100)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(92, 21)
        Me.txtPrice.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(194, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 12)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "价格:"
        '
        'txtDemandQty
        '
        Me.txtDemandQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDemandQty.Location = New System.Drawing.Point(67, 100)
        Me.txtDemandQty.Name = "txtDemandQty"
        Me.txtDemandQty.Size = New System.Drawing.Size(121, 21)
        Me.txtDemandQty.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "需求数量:"
        '
        'txtEquimentName
        '
        Me.txtEquimentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEquimentName.Location = New System.Drawing.Point(294, 55)
        Me.txtEquimentName.Name = "txtEquimentName"
        Me.txtEquimentName.Size = New System.Drawing.Size(459, 21)
        Me.txtEquimentName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(205, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 12)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "设备/治具名称:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 12)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "设备/治具类型:"
        '
        'cmbEquimentType
        '
        Me.cmbEquimentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEquimentType.FormattingEnabled = True
        Me.cmbEquimentType.Items.AddRange(New Object() {"治具", "设备"})
        Me.cmbEquimentType.Location = New System.Drawing.Point(103, 56)
        Me.cmbEquimentType.Name = "cmbEquimentType"
        Me.cmbEquimentType.Size = New System.Drawing.Size(85, 20)
        Me.cmbEquimentType.TabIndex = 1
        '
        'BtnCancel
        '
        Me.BtnCancel.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(483, 462)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(53, 32)
        Me.BtnCancel.TabIndex = 28
        Me.BtnCancel.TabStop = False
        Me.BtnCancel.Text = "取消"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.StationID, Me.StationName, Me.EquimentType, Me.EquimentName, Me.DemandQty, Me.Price, Me.Capacity, Me.FixtureNumber, Me.Remark, Me.ID, Me.UserID, Me.UserName, Me.InTime})
        Me.dgvData.Location = New System.Drawing.Point(10, 175)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowTemplate.Height = 23
        Me.dgvData.Size = New System.Drawing.Size(1103, 262)
        Me.dgvData.TabIndex = 29
        Me.dgvData.TabStop = False
        '
        'StationID
        '
        Me.StationID.DataPropertyName = "StationID"
        Me.StationID.HeaderText = "StationID"
        Me.StationID.Name = "StationID"
        Me.StationID.ReadOnly = True
        Me.StationID.Visible = False
        '
        'StationName
        '
        Me.StationName.DataPropertyName = "StationName"
        Me.StationName.HeaderText = "工站"
        Me.StationName.Name = "StationName"
        Me.StationName.ReadOnly = True
        Me.StationName.Width = 148
        '
        'EquimentType
        '
        Me.EquimentType.DataPropertyName = "EquimentType"
        Me.EquimentType.HeaderText = "设备/治具类型"
        Me.EquimentType.Name = "EquimentType"
        Me.EquimentType.ReadOnly = True
        Me.EquimentType.Width = 110
        '
        'EquimentName
        '
        Me.EquimentName.DataPropertyName = "EquimentName"
        Me.EquimentName.HeaderText = "设备/治具名称"
        Me.EquimentName.Name = "EquimentName"
        Me.EquimentName.ReadOnly = True
        Me.EquimentName.Width = 150
        '
        'DemandQty
        '
        Me.DemandQty.DataPropertyName = "DemandQty"
        Me.DemandQty.HeaderText = "需求数量"
        Me.DemandQty.Name = "DemandQty"
        Me.DemandQty.ReadOnly = True
        '
        'Price
        '
        Me.Price.DataPropertyName = "Price"
        Me.Price.HeaderText = "价格"
        Me.Price.Name = "Price"
        Me.Price.ReadOnly = True
        Me.Price.Width = 80
        '
        'Capacity
        '
        Me.Capacity.DataPropertyName = "Capacity"
        Me.Capacity.HeaderText = "产能(H)"
        Me.Capacity.Name = "Capacity"
        Me.Capacity.ReadOnly = True
        Me.Capacity.Width = 70
        '
        'FixtureNumber
        '
        Me.FixtureNumber.DataPropertyName = "FixtureNumber"
        Me.FixtureNumber.HeaderText = "治具料号"
        Me.FixtureNumber.Name = "FixtureNumber"
        Me.FixtureNumber.ReadOnly = True
        Me.FixtureNumber.Width = 115
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "备注"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        Me.Remark.Width = 150
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "UserID"
        Me.UserID.Name = "UserID"
        Me.UserID.ReadOnly = True
        Me.UserID.Visible = False
        '
        'UserName
        '
        Me.UserName.DataPropertyName = "UserName"
        Me.UserName.HeaderText = "修改人"
        Me.UserName.Name = "UserName"
        Me.UserName.ReadOnly = True
        Me.UserName.Width = 75
        '
        'InTime
        '
        Me.InTime.DataPropertyName = "InTime"
        DataGridViewCellStyle2.Format = "g"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.InTime.DefaultCellStyle = DataGridViewCellStyle2
        Me.InTime.HeaderText = "修改时间"
        Me.InTime.Name = "InTime"
        Me.InTime.ReadOnly = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Font = New System.Drawing.Font("宋体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BtnAdd.Location = New System.Drawing.Point(862, 119)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(75, 37)
        Me.BtnAdd.TabIndex = 30
        Me.BtnAdd.TabStop = False
        Me.BtnAdd.Text = "+"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.Red
        Me.lblMessage.Location = New System.Drawing.Point(776, 17)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(161, 99)
        Me.lblMessage.TabIndex = 31
        Me.lblMessage.Text = "如果要保存多个设备信息" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "点击+号,把设备信息" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "先暂存在下面的列表中" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "然后一起提交"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 12)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "工序:"
        '
        'txtOrderBy
        '
        '
        '
        '
        Me.txtOrderBy.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtOrderBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtOrderBy.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtOrderBy.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtOrderBy.Location = New System.Drawing.Point(49, 9)
        Me.txtOrderBy.MinValue = 1
        Me.txtOrderBy.Name = "txtOrderBy"
        Me.txtOrderBy.ShowUpDown = True
        Me.txtOrderBy.Size = New System.Drawing.Size(46, 26)
        Me.txtOrderBy.TabIndex = 34
        Me.txtOrderBy.Value = 1
        Me.txtOrderBy.WatermarkText = "1"
        '
        'BtnRemove
        '
        Me.BtnRemove.Font = New System.Drawing.Font("宋体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BtnRemove.Location = New System.Drawing.Point(964, 120)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(75, 37)
        Me.BtnRemove.TabIndex = 35
        Me.BtnRemove.TabStop = False
        Me.BtnRemove.Text = "-"
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'FrmAddBOFToolListDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1113, 506)
        Me.Controls.Add(Me.BtnRemove)
        Me.Controls.Add(Me.txtOrderBy)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtFixtureNumber)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCapacity)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDemandQty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEquimentName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbEquimentType)
        Me.Controls.Add(Me.BtnSubmit)
        Me.Controls.Add(Me.cmbStation)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddBOFToolListDetail"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "编辑BOF清单明细档"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrderBy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbStation As System.Windows.Forms.ComboBox
    Friend WithEvents BtnSubmit As System.Windows.Forms.Button
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFixtureNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCapacity As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDemandQty As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEquimentName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbEquimentType As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents StationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StationName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EquimentType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EquimentName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DemandQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Capacity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FixtureNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtOrderBy As DevComponents.Editors.IntegerInput
    Friend WithEvents BtnRemove As System.Windows.Forms.Button
End Class
