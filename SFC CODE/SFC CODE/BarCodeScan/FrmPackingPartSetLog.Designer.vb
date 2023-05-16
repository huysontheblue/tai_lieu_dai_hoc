<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPackingPartSetLog
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
        Me.GbData = New System.Windows.Forms.GroupBox()
        Me.LPartLogDg = New System.Windows.Forms.DataGridView()
        Me.LPartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CartonStylePackID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CartonStylePackItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CartonQtyI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsAutoGenerateCarton = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsScanFixedCarton = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsSystemPrintCarton = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsScanCustProAndQtyI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsScanQRCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QRCodeStylePackID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QRCodeStylePackItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsSystemPrintQRCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsScanPECarton = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PECartonStylePackID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PECartonStylePackItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PECartonQtyI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsSystemPrintPECarton = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PpIDCodeStylePackID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PpIDCodeStylePackItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsFixedCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PpIDQtyI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsSystemPrintPpID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateUserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsChecked = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckedUserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperUserid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GbData.SuspendLayout()
        CType(Me.LPartLogDg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GbData
        '
        Me.GbData.Controls.Add(Me.LPartLogDg)
        Me.GbData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GbData.Location = New System.Drawing.Point(0, 0)
        Me.GbData.Name = "GbData"
        Me.GbData.Size = New System.Drawing.Size(1253, 442)
        Me.GbData.TabIndex = 63
        Me.GbData.TabStop = False
        Me.GbData.Text = "料件明细(双击可查询编辑历史记录)"
        '
        'LPartLogDg
        '
        Me.LPartLogDg.AllowUserToAddRows = False
        Me.LPartLogDg.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.LPartLogDg.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.LPartLogDg.BackgroundColor = System.Drawing.Color.White
        Me.LPartLogDg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LPartLogDg.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LPartLogDg.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.LPartLogDg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.LPartLogDg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LPartID, Me.CartonStylePackID, Me.CartonStylePackItem, Me.CartonQtyI, Me.IsAutoGenerateCarton, Me.IsScanFixedCarton, Me.IsSystemPrintCarton, Me.IsScanCustProAndQtyI, Me.IsScanQRCode, Me.QRCodeStylePackID, Me.QRCodeStylePackItem, Me.IsSystemPrintQRCode, Me.IsScanPECarton, Me.PECartonStylePackID, Me.PECartonStylePackItem, Me.PECartonQtyI, Me.IsSystemPrintPECarton, Me.PpIDCodeStylePackID, Me.PpIDCodeStylePackItem, Me.IsFixedCode, Me.PpIDQtyI, Me.IsSystemPrintPpID, Me.CreateUserID, Me.CreateDate, Me.IsChecked, Me.CheckedUserID, Me.CheckedDate, Me.OperType, Me.OperUserid, Me.OperDate})
        Me.LPartLogDg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LPartLogDg.Location = New System.Drawing.Point(3, 19)
        Me.LPartLogDg.Name = "LPartLogDg"
        Me.LPartLogDg.ReadOnly = True
        Me.LPartLogDg.RowHeadersWidth = 4
        Me.LPartLogDg.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.LPartLogDg.RowTemplate.Height = 24
        Me.LPartLogDg.ShowEditingIcon = False
        Me.LPartLogDg.Size = New System.Drawing.Size(1247, 420)
        Me.LPartLogDg.StandardTab = True
        Me.LPartLogDg.TabIndex = 3
        '
        'LPartID
        '
        Me.LPartID.DataPropertyName = "LPartID"
        Me.LPartID.Frozen = True
        Me.LPartID.HeaderText = "料件编号"
        Me.LPartID.Name = "LPartID"
        Me.LPartID.ReadOnly = True
        Me.LPartID.Width = 120
        '
        'CartonStylePackID
        '
        Me.CartonStylePackID.DataPropertyName = "CartonStylePackID"
        Me.CartonStylePackID.HeaderText = "外箱条码类型"
        Me.CartonStylePackID.Name = "CartonStylePackID"
        Me.CartonStylePackID.ReadOnly = True
        Me.CartonStylePackID.Width = 80
        '
        'CartonStylePackItem
        '
        Me.CartonStylePackItem.DataPropertyName = "CartonStylePackItem"
        Me.CartonStylePackItem.HeaderText = "外箱条码项次"
        Me.CartonStylePackItem.Name = "CartonStylePackItem"
        Me.CartonStylePackItem.ReadOnly = True
        Me.CartonStylePackItem.Width = 80
        '
        'CartonQtyI
        '
        Me.CartonQtyI.DataPropertyName = "CartonQtyI"
        Me.CartonQtyI.HeaderText = "装箱数量"
        Me.CartonQtyI.Name = "CartonQtyI"
        Me.CartonQtyI.ReadOnly = True
        Me.CartonQtyI.Width = 80
        '
        'IsAutoGenerateCarton
        '
        Me.IsAutoGenerateCarton.DataPropertyName = "IsAutoGenerateCarton"
        Me.IsAutoGenerateCarton.HeaderText = "是否自动产生外箱"
        Me.IsAutoGenerateCarton.Name = "IsAutoGenerateCarton"
        Me.IsAutoGenerateCarton.ReadOnly = True
        '
        'IsScanFixedCarton
        '
        Me.IsScanFixedCarton.DataPropertyName = "IsScanFixedCarton"
        Me.IsScanFixedCarton.HeaderText = "是否扫描固定外箱"
        Me.IsScanFixedCarton.Name = "IsScanFixedCarton"
        Me.IsScanFixedCarton.ReadOnly = True
        '
        'IsSystemPrintCarton
        '
        Me.IsSystemPrintCarton.DataPropertyName = "IsSystemPrintCarton"
        Me.IsSystemPrintCarton.HeaderText = "是否系统打印外箱条码"
        Me.IsSystemPrintCarton.Name = "IsSystemPrintCarton"
        Me.IsSystemPrintCarton.ReadOnly = True
        '
        'IsScanCustProAndQtyI
        '
        Me.IsScanCustProAndQtyI.DataPropertyName = "IsScanCustProAndQtyI"
        Me.IsScanCustProAndQtyI.HeaderText = "是否扫描客户料号及装箱数量"
        Me.IsScanCustProAndQtyI.Name = "IsScanCustProAndQtyI"
        Me.IsScanCustProAndQtyI.ReadOnly = True
        Me.IsScanCustProAndQtyI.Width = 120
        '
        'IsScanQRCode
        '
        Me.IsScanQRCode.DataPropertyName = "IsScanQRCode"
        Me.IsScanQRCode.HeaderText = "是否扫描QRCODE"
        Me.IsScanQRCode.Name = "IsScanQRCode"
        Me.IsScanQRCode.ReadOnly = True
        '
        'QRCodeStylePackID
        '
        Me.QRCodeStylePackID.DataPropertyName = "QRCodeStylePackID"
        Me.QRCodeStylePackID.HeaderText = "QR条码类型"
        Me.QRCodeStylePackID.Name = "QRCodeStylePackID"
        Me.QRCodeStylePackID.ReadOnly = True
        Me.QRCodeStylePackID.Width = 80
        '
        'QRCodeStylePackItem
        '
        Me.QRCodeStylePackItem.DataPropertyName = "QRCodeStylePackItem"
        Me.QRCodeStylePackItem.HeaderText = "QR条码项次"
        Me.QRCodeStylePackItem.Name = "QRCodeStylePackItem"
        Me.QRCodeStylePackItem.ReadOnly = True
        Me.QRCodeStylePackItem.Width = 80
        '
        'IsSystemPrintQRCode
        '
        Me.IsSystemPrintQRCode.DataPropertyName = "IsSystemPrintQRCode"
        Me.IsSystemPrintQRCode.HeaderText = "是否系统打印QR条码"
        Me.IsSystemPrintQRCode.Name = "IsSystemPrintQRCode"
        Me.IsSystemPrintQRCode.ReadOnly = True
        '
        'IsScanPECarton
        '
        Me.IsScanPECarton.DataPropertyName = "IsScanPECarton"
        Me.IsScanPECarton.HeaderText = "是否扫描PE袋条码"
        Me.IsScanPECarton.Name = "IsScanPECarton"
        Me.IsScanPECarton.ReadOnly = True
        '
        'PECartonStylePackID
        '
        Me.PECartonStylePackID.DataPropertyName = "PECartonStylePackID"
        Me.PECartonStylePackID.HeaderText = "PE袋条码类型"
        Me.PECartonStylePackID.Name = "PECartonStylePackID"
        Me.PECartonStylePackID.ReadOnly = True
        Me.PECartonStylePackID.Width = 80
        '
        'PECartonStylePackItem
        '
        Me.PECartonStylePackItem.DataPropertyName = "PECartonStylePackItem"
        Me.PECartonStylePackItem.HeaderText = "PE袋条码项次"
        Me.PECartonStylePackItem.Name = "PECartonStylePackItem"
        Me.PECartonStylePackItem.ReadOnly = True
        Me.PECartonStylePackItem.Width = 80
        '
        'PECartonQtyI
        '
        Me.PECartonQtyI.DataPropertyName = "PECartonQtyI"
        Me.PECartonQtyI.HeaderText = "PE袋包装数量"
        Me.PECartonQtyI.Name = "PECartonQtyI"
        Me.PECartonQtyI.ReadOnly = True
        Me.PECartonQtyI.Width = 80
        '
        'IsSystemPrintPECarton
        '
        Me.IsSystemPrintPECarton.DataPropertyName = "IsSystemPrintPECarton"
        Me.IsSystemPrintPECarton.HeaderText = "是否系统打印PE袋条码"
        Me.IsSystemPrintPECarton.Name = "IsSystemPrintPECarton"
        Me.IsSystemPrintPECarton.ReadOnly = True
        '
        'PpIDCodeStylePackID
        '
        Me.PpIDCodeStylePackID.DataPropertyName = "PpIDCodeStylePackID"
        Me.PpIDCodeStylePackID.HeaderText = "产品条码类型"
        Me.PpIDCodeStylePackID.Name = "PpIDCodeStylePackID"
        Me.PpIDCodeStylePackID.ReadOnly = True
        Me.PpIDCodeStylePackID.Width = 80
        '
        'PpIDCodeStylePackItem
        '
        Me.PpIDCodeStylePackItem.DataPropertyName = "PpIDCodeStylePackItem"
        Me.PpIDCodeStylePackItem.HeaderText = "产品条码项次"
        Me.PpIDCodeStylePackItem.Name = "PpIDCodeStylePackItem"
        Me.PpIDCodeStylePackItem.ReadOnly = True
        Me.PpIDCodeStylePackItem.Width = 80
        '
        'IsFixedCode
        '
        Me.IsFixedCode.DataPropertyName = "IsFixedCode"
        Me.IsFixedCode.HeaderText = "是否固定码"
        Me.IsFixedCode.Name = "IsFixedCode"
        Me.IsFixedCode.ReadOnly = True
        Me.IsFixedCode.Width = 80
        '
        'PpIDQtyI
        '
        Me.PpIDQtyI.DataPropertyName = "PpIDQtyI"
        Me.PpIDQtyI.HeaderText = "产品数量"
        Me.PpIDQtyI.Name = "PpIDQtyI"
        Me.PpIDQtyI.ReadOnly = True
        Me.PpIDQtyI.Width = 80
        '
        'IsSystemPrintPpID
        '
        Me.IsSystemPrintPpID.DataPropertyName = "IsSystemPrintPpID"
        Me.IsSystemPrintPpID.HeaderText = "是否系统打印产品条码"
        Me.IsSystemPrintPpID.Name = "IsSystemPrintPpID"
        Me.IsSystemPrintPpID.ReadOnly = True
        '
        'CreateUserID
        '
        Me.CreateUserID.DataPropertyName = "CreateUserID"
        Me.CreateUserID.HeaderText = "最后编辑用户"
        Me.CreateUserID.Name = "CreateUserID"
        Me.CreateUserID.ReadOnly = True
        '
        'CreateDate
        '
        Me.CreateDate.DataPropertyName = "CreateDate"
        Me.CreateDate.HeaderText = "最后编辑时间"
        Me.CreateDate.Name = "CreateDate"
        Me.CreateDate.ReadOnly = True
        Me.CreateDate.Width = 120
        '
        'IsChecked
        '
        Me.IsChecked.DataPropertyName = "IsChecked"
        Me.IsChecked.HeaderText = "是否审核"
        Me.IsChecked.Name = "IsChecked"
        Me.IsChecked.ReadOnly = True
        Me.IsChecked.Width = 80
        '
        'CheckedUserID
        '
        Me.CheckedUserID.DataPropertyName = "CheckedUserID"
        Me.CheckedUserID.HeaderText = "审核用户"
        Me.CheckedUserID.Name = "CheckedUserID"
        Me.CheckedUserID.ReadOnly = True
        '
        'CheckedDate
        '
        Me.CheckedDate.DataPropertyName = "CheckedDate"
        Me.CheckedDate.HeaderText = "审核时间"
        Me.CheckedDate.Name = "CheckedDate"
        Me.CheckedDate.ReadOnly = True
        Me.CheckedDate.Width = 120
        '
        'OperType
        '
        Me.OperType.DataPropertyName = "OperType"
        Me.OperType.HeaderText = "操作类型"
        Me.OperType.Name = "OperType"
        Me.OperType.ReadOnly = True
        '
        'OperUserid
        '
        Me.OperUserid.DataPropertyName = "OperUserid"
        Me.OperUserid.HeaderText = "操作用户"
        Me.OperUserid.Name = "OperUserid"
        Me.OperUserid.ReadOnly = True
        '
        'OperDate
        '
        Me.OperDate.DataPropertyName = "OperDate"
        Me.OperDate.HeaderText = "操作时间"
        Me.OperDate.Name = "OperDate"
        Me.OperDate.ReadOnly = True
        Me.OperDate.Width = 120
        '
        'FrmPackingPartSetLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1253, 442)
        Me.Controls.Add(Me.GbData)
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPackingPartSetLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "料件包装扫描参数设置历史记录"
        Me.GbData.ResumeLayout(False)
        CType(Me.LPartLogDg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GbData As System.Windows.Forms.GroupBox
    Friend WithEvents LPartLogDg As System.Windows.Forms.DataGridView
    Friend WithEvents LPartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CartonStylePackID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CartonStylePackItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CartonQtyI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsAutoGenerateCarton As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsScanFixedCarton As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsSystemPrintCarton As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsScanCustProAndQtyI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsScanQRCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QRCodeStylePackID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QRCodeStylePackItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsSystemPrintQRCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsScanPECarton As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PECartonStylePackID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PECartonStylePackItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PECartonQtyI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsSystemPrintPECarton As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PpIDCodeStylePackID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PpIDCodeStylePackItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsFixedCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PpIDQtyI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsSystemPrintPpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateUserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsChecked As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckedUserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperUserid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperDate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
