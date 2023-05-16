<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEditEMCPEPT
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMOID = New System.Windows.Forms.TextBox()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.ColStationNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMachineNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRemark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProductDate = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLineleaderName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLineID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBiotechName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtIPQCName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPartID = New System.Windows.Forms.TextBox()
        Me.BtnSubmit = New System.Windows.Forms.Button()
        Me.txtEquNoList = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtUserIDList = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtIPQCConfirm = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtLinerConfirm = New System.Windows.Forms.TextBox()
        Me.txtScaneMessage = New System.Windows.Forms.TextBox()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "工单编号:"
        '
        'txtMOID
        '
        Me.txtMOID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMOID.Location = New System.Drawing.Point(61, 4)
        Me.txtMOID.Name = "txtMOID"
        Me.txtMOID.ReadOnly = True
        Me.txtMOID.Size = New System.Drawing.Size(518, 21)
        Me.txtMOID.TabIndex = 1
        Me.txtMOID.TabStop = False
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColStationNumber, Me.ColMachineNumber, Me.ColProductCode, Me.ColRemark})
        Me.dgvData.Location = New System.Drawing.Point(0, 125)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowTemplate.Height = 23
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(1106, 415)
        Me.dgvData.TabIndex = 2
        Me.dgvData.TabStop = False
        '
        'ColStationNumber
        '
        Me.ColStationNumber.DataPropertyName = "StationNumber"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColStationNumber.DefaultCellStyle = DataGridViewCellStyle1
        Me.ColStationNumber.HeaderText = "NO."
        Me.ColStationNumber.Name = "ColStationNumber"
        Me.ColStationNumber.ReadOnly = True
        Me.ColStationNumber.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColStationNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColStationNumber.Width = 30
        '
        'ColMachineNumber
        '
        Me.ColMachineNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColMachineNumber.DataPropertyName = "MachineNumber"
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColMachineNumber.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColMachineNumber.HeaderText = "机台编号"
        Me.ColMachineNumber.Name = "ColMachineNumber"
        Me.ColMachineNumber.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColMachineNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColProductCode
        '
        Me.ColProductCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColProductCode.DataPropertyName = "ProductCode"
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColProductCode.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColProductCode.HeaderText = "生产人员"
        Me.ColProductCode.Name = "ColProductCode"
        Me.ColProductCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColRemark
        '
        Me.ColRemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColRemark.DataPropertyName = "Remark"
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColRemark.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColRemark.HeaderText = "备注"
        Me.ColRemark.Name = "ColRemark"
        Me.ColRemark.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColRemark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "生产日期:"
        '
        'txtProductDate
        '
        Me.txtProductDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductDate.Location = New System.Drawing.Point(61, 32)
        Me.txtProductDate.Name = "txtProductDate"
        Me.txtProductDate.ReadOnly = True
        Me.txtProductDate.Size = New System.Drawing.Size(128, 21)
        Me.txtProductDate.TabIndex = 4
        Me.txtProductDate.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "线    长:"
        '
        'txtLineleaderName
        '
        Me.txtLineleaderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineleaderName.Location = New System.Drawing.Point(61, 59)
        Me.txtLineleaderName.Name = "txtLineleaderName"
        Me.txtLineleaderName.ReadOnly = True
        Me.txtLineleaderName.Size = New System.Drawing.Size(128, 21)
        Me.txtLineleaderName.TabIndex = 6
        Me.txtLineleaderName.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(191, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "生产线别:"
        '
        'txtLineID
        '
        Me.txtLineID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineID.Location = New System.Drawing.Point(251, 32)
        Me.txtLineID.Name = "txtLineID"
        Me.txtLineID.ReadOnly = True
        Me.txtLineID.Size = New System.Drawing.Size(128, 21)
        Me.txtLineID.TabIndex = 8
        Me.txtLineID.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(191, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "生    技:"
        '
        'txtBiotechName
        '
        Me.txtBiotechName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBiotechName.Location = New System.Drawing.Point(251, 59)
        Me.txtBiotechName.Name = "txtBiotechName"
        Me.txtBiotechName.ReadOnly = True
        Me.txtBiotechName.Size = New System.Drawing.Size(128, 21)
        Me.txtBiotechName.TabIndex = 10
        Me.txtBiotechName.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(393, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "I P Q C:"
        '
        'txtIPQCName
        '
        Me.txtIPQCName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIPQCName.Location = New System.Drawing.Point(449, 59)
        Me.txtIPQCName.Name = "txtIPQCName"
        Me.txtIPQCName.ReadOnly = True
        Me.txtIPQCName.Size = New System.Drawing.Size(128, 21)
        Me.txtIPQCName.TabIndex = 12
        Me.txtIPQCName.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(387, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 12)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "生产料号:"
        '
        'txtPartID
        '
        Me.txtPartID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartID.Location = New System.Drawing.Point(449, 32)
        Me.txtPartID.Name = "txtPartID"
        Me.txtPartID.ReadOnly = True
        Me.txtPartID.Size = New System.Drawing.Size(128, 21)
        Me.txtPartID.TabIndex = 14
        Me.txtPartID.TabStop = False
        '
        'BtnSubmit
        '
        Me.BtnSubmit.Font = New System.Drawing.Font("宋体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BtnSubmit.Location = New System.Drawing.Point(610, 12)
        Me.BtnSubmit.Name = "BtnSubmit"
        Me.BtnSubmit.Size = New System.Drawing.Size(100, 64)
        Me.BtnSubmit.TabIndex = 15
        Me.BtnSubmit.TabStop = False
        Me.BtnSubmit.Text = "提交"
        Me.BtnSubmit.UseVisualStyleBackColor = True
        '
        'txtEquNoList
        '
        Me.txtEquNoList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEquNoList.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.txtEquNoList.Location = New System.Drawing.Point(100, 91)
        Me.txtEquNoList.Name = "txtEquNoList"
        Me.txtEquNoList.Size = New System.Drawing.Size(128, 30)
        Me.txtEquNoList.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.Location = New System.Drawing.Point(1, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 20)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "机台编号:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.Label9.Location = New System.Drawing.Point(232, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 20)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "生产人员:"
        '
        'txtUserIDList
        '
        Me.txtUserIDList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserIDList.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.txtUserIDList.Location = New System.Drawing.Point(337, 91)
        Me.txtUserIDList.Name = "txtUserIDList"
        Me.txtUserIDList.Size = New System.Drawing.Size(128, 30)
        Me.txtUserIDList.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.Label10.Location = New System.Drawing.Point(471, 96)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 20)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "备注:"
        '
        'txtRemark
        '
        Me.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemark.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.txtRemark.Location = New System.Drawing.Point(530, 91)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(128, 30)
        Me.txtRemark.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.Label11.Location = New System.Drawing.Point(872, 96)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 20)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "IPQC确认:"
        '
        'txtIPQCConfirm
        '
        Me.txtIPQCConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIPQCConfirm.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.txtIPQCConfirm.Location = New System.Drawing.Point(977, 91)
        Me.txtIPQCConfirm.Name = "txtIPQCConfirm"
        Me.txtIPQCConfirm.Size = New System.Drawing.Size(97, 30)
        Me.txtIPQCConfirm.TabIndex = 23
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.Label12.Location = New System.Drawing.Point(663, 96)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(99, 20)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "线长确认:"
        '
        'txtLinerConfirm
        '
        Me.txtLinerConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinerConfirm.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.txtLinerConfirm.Location = New System.Drawing.Point(762, 91)
        Me.txtLinerConfirm.Name = "txtLinerConfirm"
        Me.txtLinerConfirm.Size = New System.Drawing.Size(104, 30)
        Me.txtLinerConfirm.TabIndex = 22
        '
        'txtScaneMessage
        '
        Me.txtScaneMessage.BackColor = System.Drawing.SystemColors.Window
        Me.txtScaneMessage.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.txtScaneMessage.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtScaneMessage.Location = New System.Drawing.Point(736, 12)
        Me.txtScaneMessage.Multiline = True
        Me.txtScaneMessage.Name = "txtScaneMessage"
        Me.txtScaneMessage.ReadOnly = True
        Me.txtScaneMessage.Size = New System.Drawing.Size(360, 64)
        Me.txtScaneMessage.TabIndex = 26
        Me.txtScaneMessage.TabStop = False
        '
        'FrmEditEMCPEPT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1108, 542)
        Me.Controls.Add(Me.txtScaneMessage)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtIPQCConfirm)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtLinerConfirm)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtUserIDList)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtEquNoList)
        Me.Controls.Add(Me.BtnSubmit)
        Me.Controls.Add(Me.txtPartID)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtIPQCName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtBiotechName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtLineID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtLineleaderName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtProductDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.txtMOID)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmEditEMCPEPT"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "编辑生产设备人员追踪"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMOID As System.Windows.Forms.TextBox
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProductDate As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLineleaderName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLineID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBiotechName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtIPQCName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPartID As System.Windows.Forms.TextBox
    Friend WithEvents BtnSubmit As System.Windows.Forms.Button
    Friend WithEvents txtEquNoList As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtUserIDList As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents ColStationNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMachineNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColProductCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRemark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtIPQCConfirm As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtLinerConfirm As System.Windows.Forms.TextBox
    Friend WithEvents txtScaneMessage As System.Windows.Forms.TextBox
End Class
