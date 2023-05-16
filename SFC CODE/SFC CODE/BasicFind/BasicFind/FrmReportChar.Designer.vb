<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportChar
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
        Dim XyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SideBySideBarSeriesLabel1 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim Series2 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SideBySideBarSeriesLabel2 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim SideBySideBarSeriesLabel3 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim ChartTitle1 As DevExpress.XtraCharts.ChartTitle = New DevExpress.XtraCharts.ChartTitle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportChar))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.lblMessage = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.ComboBoxItem1 = New DevComponents.DotNetBar.ComboBoxItem()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.ComboItem6 = New DevComponents.Editors.ComboItem()
        Me.ComboItem5 = New DevComponents.Editors.ComboItem()
        Me.ComboItem7 = New DevComponents.Editors.ComboItem()
        Me.CheckBoxItem1 = New DevComponents.DotNetBar.CheckBoxItem()
        Me.ComboBoxItem2 = New DevComponents.DotNetBar.ComboBoxItem()
        Me.ComboItem8 = New DevComponents.Editors.ComboItem()
        Me.ComboItem9 = New DevComponents.Editors.ComboItem()
        Me.btnexit = New DevComponents.DotNetBar.ButtonItem()
        Me.ChartControl1 = New DevExpress.XtraCharts.ChartControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.lblMessage, Me.LabelItem1, Me.ComboBoxItem1, Me.CheckBoxItem1, Me.ComboBoxItem2, Me.btnexit})
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.SingleLineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Bar1.Size = New System.Drawing.Size(1016, 28)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 138
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'lblMessage
        '
        Me.lblMessage.Name = "lblMessage"
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "报表导出"
        '
        'ComboBoxItem1
        '
        Me.ComboBoxItem1.ComboWidth = 150
        Me.ComboBoxItem1.DropDownHeight = 106
        Me.ComboBoxItem1.DropDownWidth = 300
        Me.ComboBoxItem1.ItemHeight = 17
        Me.ComboBoxItem1.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2, Me.ComboItem3, Me.ComboItem4, Me.ComboItem6, Me.ComboItem5, Me.ComboItem7})
        Me.ComboBoxItem1.Name = "ComboBoxItem1"
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Export to PDF"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Export to HTML"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "Export to XLS"
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "Export to XLSX"
        '
        'ComboItem6
        '
        Me.ComboItem6.Text = "Export to PNG"
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "Export to JPEG"
        '
        'ComboItem7
        '
        Me.ComboItem7.Text = "Export to BMP"
        '
        'CheckBoxItem1
        '
        Me.CheckBoxItem1.Checked = True
        Me.CheckBoxItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxItem1.Name = "CheckBoxItem1"
        Me.CheckBoxItem1.Text = "显示标签值"
        '
        'ComboBoxItem2
        '
        Me.ComboBoxItem2.ComboWidth = 120
        Me.ComboBoxItem2.DropDownHeight = 106
        Me.ComboBoxItem2.DropDownWidth = 120
        Me.ComboBoxItem2.ItemHeight = 17
        Me.ComboBoxItem2.Items.AddRange(New Object() {Me.ComboItem8, Me.ComboItem9})
        Me.ComboBoxItem2.Name = "ComboBoxItem2"
        '
        'ComboItem8
        '
        Me.ComboItem8.Text = "单数据源"
        '
        'ComboItem9
        '
        Me.ComboItem9.Text = "双数据源"
        '
        'btnexit
        '
        Me.btnexit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.Image = Global.BasicFind.My.Resources.Resources.delete
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Text = "退出(T)"
        Me.btnexit.Tooltip = "退出(T)"
        '
        'ChartControl1
        '
        XyDiagram1.AxisX.Range.ScrollingRange.SideMarginsEnabled = True
        XyDiagram1.AxisX.Range.SideMarginsEnabled = True
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.Range.ScrollingRange.SideMarginsEnabled = True
        XyDiagram1.AxisY.Range.SideMarginsEnabled = True
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        Me.ChartControl1.Diagram = XyDiagram1
        Me.ChartControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartControl1.Location = New System.Drawing.Point(0, 0)
        Me.ChartControl1.Name = "ChartControl1"
        SideBySideBarSeriesLabel1.LineVisible = True
        Series1.Label = SideBySideBarSeriesLabel1
        Series1.Name = "Series 1"
        SideBySideBarSeriesLabel2.LineVisible = True
        Series2.Label = SideBySideBarSeriesLabel2
        Series2.Name = "Series 2"
        Me.ChartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1, Series2}
        SideBySideBarSeriesLabel3.LineVisible = True
        Me.ChartControl1.SeriesTemplate.Label = SideBySideBarSeriesLabel3
        Me.ChartControl1.Size = New System.Drawing.Size(1016, 466)
        Me.ChartControl1.TabIndex = 139
        Me.ChartControl1.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() {ChartTitle1})
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.ChartControl1)
        Me.Panel1.Location = New System.Drawing.Point(0, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1016, 466)
        Me.Panel1.TabIndex = 140
        '
        'FrmReportChar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 493)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Bar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmReportChar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "报表统计"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelItem
    Friend WithEvents btnexit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ComboBoxItem1 As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ChartControl1 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CheckBoxItem1 As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents ComboItem6 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem7 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboBoxItem2 As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents ComboItem8 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem9 As DevComponents.Editors.ComboItem
End Class
