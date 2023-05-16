<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRunCardImportStation
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
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.lblMsgList = New System.Windows.Forms.ListBox()
        Me.CobCust = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CobSeriesID = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(12, 60)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(386, 21)
        Me.txtPath.TabIndex = 0
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(404, 60)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 23)
        Me.btnSelect.TabIndex = 1
        Me.btnSelect.Text = "浏览"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "请选择文件夹"
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(485, 60)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(75, 23)
        Me.btnImport.TabIndex = 2
        Me.btnImport.Text = "导入"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(12, 84)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(0, 12)
        Me.lblMsg.TabIndex = 3
        '
        'lblMsgList
        '
        Me.lblMsgList.BackColor = System.Drawing.SystemColors.Info
        Me.lblMsgList.FormattingEnabled = True
        Me.lblMsgList.HorizontalScrollbar = True
        Me.lblMsgList.ItemHeight = 12
        Me.lblMsgList.Location = New System.Drawing.Point(12, 87)
        Me.lblMsgList.Name = "lblMsgList"
        Me.lblMsgList.Size = New System.Drawing.Size(546, 244)
        Me.lblMsgList.TabIndex = 4
        '
        'CobCust
        '
        Me.CobCust.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CobCust.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CobCust.FormattingEnabled = True
        Me.CobCust.Location = New System.Drawing.Point(77, 9)
        Me.CobCust.Name = "CobCust"
        Me.CobCust.Size = New System.Drawing.Size(121, 20)
        Me.CobCust.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "客户编码:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(223, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "系列别:"
        '
        'CobSeriesID
        '
        Me.CobSeriesID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CobSeriesID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CobSeriesID.FormattingEnabled = True
        Me.CobSeriesID.Location = New System.Drawing.Point(294, 12)
        Me.CobSeriesID.Name = "CobSeriesID"
        Me.CobSeriesID.Size = New System.Drawing.Size(121, 20)
        Me.CobSeriesID.TabIndex = 8
        '
        'FrmRunCardImportStation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 352)
        Me.Controls.Add(Me.CobSeriesID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CobCust)
        Me.Controls.Add(Me.lblMsgList)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.txtPath)
        Me.MaximizeBox = False
        Me.Name = "FrmRunCardImportStation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "流程卡导入"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblMsgList As System.Windows.Forms.ListBox
    Friend WithEvents CobCust As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CobSeriesID As System.Windows.Forms.ComboBox
End Class
