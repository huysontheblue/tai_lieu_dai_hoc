<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDashboardModule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDashboardModule))
        Me.Label1 = New System.Windows.Forms.Label
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem
        Me.MetroTileItem1 = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.MetroTileItem2 = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.MetroTileItem3 = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.MetroTileItem7 = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.MetroTileItem8 = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 42.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(230, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(668, 56)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "昆山联滔JIT生产电子看板"
        '
        'MetroTilePanel1
        '
        '
        '
        '
        Me.MetroTilePanel1.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MetroTilePanel1.BackgroundStyle.BackColor2 = System.Drawing.Color.White
        Me.MetroTilePanel1.BackgroundStyle.Class = "MetroTilePanel"
        Me.MetroTilePanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTilePanel1.ContainerControlProcessDialogKey = True
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1})
        Me.MetroTilePanel1.Location = New System.Drawing.Point(6, 92)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(396, 507)
        Me.MetroTilePanel1.TabIndex = 3
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ItemContainer1.BackgroundStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.MultiLine = True
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.MetroTileItem1, Me.MetroTileItem2, Me.MetroTileItem3, Me.MetroTileItem7, Me.MetroTileItem8})
        '
        'LabelItem1
        '
        Me.LabelItem1.ContainerNewLineAfter = True
        Me.LabelItem1.Font = New System.Drawing.Font("宋体", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "JIT电子看板"
        '
        'MetroTileItem1
        '
        Me.MetroTileItem1.Name = "MetroTileItem1"
        Me.MetroTileItem1.Text = "车间生产电子看板"
        Me.MetroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkGreen
        '
        '
        '
        Me.MetroTileItem1.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(9, Byte), Integer))
        Me.MetroTileItem1.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(9, Byte), Integer))
        Me.MetroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'MetroTileItem2
        '
        Me.MetroTileItem2.Name = "MetroTileItem2"
        Me.MetroTileItem2.Text = "生产状况看板"
        Me.MetroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.MetroTileItem2.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.MetroTileItem2.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.MetroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'MetroTileItem3
        '
        Me.MetroTileItem3.Name = "MetroTileItem3"
        Me.MetroTileItem3.Text = "品质状况看板"
        Me.MetroTileItem3.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Coffee
        '
        '
        '
        Me.MetroTileItem3.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.MetroTileItem3.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.MetroTileItem3.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'MetroTileItem7
        '
        Me.MetroTileItem7.Name = "MetroTileItem7"
        Me.MetroTileItem7.Text = "物料设备状况看板"
        Me.MetroTileItem7.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.MetroTileItem7.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.MetroTileItem7.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.MetroTileItem7.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'MetroTileItem8
        '
        Me.MetroTileItem8.Name = "MetroTileItem8"
        Me.MetroTileItem8.Text = "生产计划看板"
        Me.MetroTileItem8.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.MetroTileItem8.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(4, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1065, 2)
        Me.Label2.TabIndex = 4
        '
        'FrmDashboardModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1067, 620)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "FrmDashboardModule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JIT生产电子看板"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents MetroTileItem1 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents MetroTileItem2 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents MetroTileItem3 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents MetroTileItem7 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents MetroTileItem8 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
