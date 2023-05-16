<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.GridList = New System.Windows.Forms.DataGridView
        Me.Machine_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckUser = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CREATEUSERNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CREATEDATETIME = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.GridList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridList
        '
        Me.GridList.AllowUserToAddRows = False
        Me.GridList.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.GridList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GridList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridList.BackgroundColor = System.Drawing.Color.White
        Me.GridList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GridList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.GridList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GridList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Machine_Code, Me.CheckUser, Me.CheckStatus, Me.CREATEUSERNAME, Me.CREATEDATETIME, Me.Remark})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridList.DefaultCellStyle = DataGridViewCellStyle3
        Me.GridList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.GridList.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.GridList.Location = New System.Drawing.Point(-4, 2)
        Me.GridList.MultiSelect = False
        Me.GridList.Name = "GridList"
        Me.GridList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.GridList.RowHeadersWidth = 4
        Me.GridList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GridList.RowTemplate.Height = 24
        Me.GridList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridList.ShowEditingIcon = False
        Me.GridList.Size = New System.Drawing.Size(1019, 300)
        Me.GridList.TabIndex = 136
        Me.GridList.TabStop = False
        '
        'Machine_Code
        '
        Me.Machine_Code.HeaderText = "设备编号"
        Me.Machine_Code.Name = "Machine_Code"
        Me.Machine_Code.ReadOnly = True
        Me.Machine_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CheckUser
        '
        Me.CheckUser.HeaderText = "校验人"
        Me.CheckUser.Name = "CheckUser"
        Me.CheckUser.ReadOnly = True
        Me.CheckUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CheckUser.Width = 80
        '
        'CheckStatus
        '
        Me.CheckStatus.HeaderText = "状态"
        Me.CheckStatus.Name = "CheckStatus"
        Me.CheckStatus.ReadOnly = True
        Me.CheckStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CheckStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CheckStatus.Width = 80
        '
        'CREATEUSERNAME
        '
        Me.CREATEUSERNAME.HeaderText = "创建人"
        Me.CREATEUSERNAME.Name = "CREATEUSERNAME"
        Me.CREATEUSERNAME.ReadOnly = True
        Me.CREATEUSERNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CREATEUSERNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CREATEUSERNAME.Width = 80
        '
        'CREATEDATETIME
        '
        '
        '
        '
        Me.CREATEDATETIME.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.CREATEDATETIME.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CREATEDATETIME.HeaderText = "创建时间"
        Me.CREATEDATETIME.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.CREATEDATETIME.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.CREATEDATETIME.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CREATEDATETIME.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.CREATEDATETIME.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CREATEDATETIME.MonthCalendar.DisplayMonth = New Date(2015, 5, 1, 0, 0, 0, 0)
        Me.CREATEDATETIME.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.CREATEDATETIME.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.CREATEDATETIME.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CREATEDATETIME.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.CREATEDATETIME.Name = "CREATEDATETIME"
        Me.CREATEDATETIME.ReadOnly = True
        Me.CREATEDATETIME.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CREATEDATETIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Remark
        '
        Me.Remark.HeaderText = "备注"
        Me.Remark.Name = "Remark"
        Me.Remark.Width = 250
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1011, 304)
        Me.Controls.Add(Me.GridList)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.GridList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridList As System.Windows.Forms.DataGridView
    Friend WithEvents Machine_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CREATEUSERNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CREATEDATETIME As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
