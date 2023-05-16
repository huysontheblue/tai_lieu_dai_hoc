<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInformation
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DgvItem = New System.Windows.Forms.DataGridView()
        Me.ColCartonid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMoid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCartonqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFloorid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWhid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAreaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabCartonQty = New System.Windows.Forms.Label()
        Me.labTatalQty = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.DgvItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DgvItem)
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 31)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(443, 260)
        Me.Panel1.TabIndex = 0
        '
        'DgvItem
        '
        Me.DgvItem.AllowUserToAddRows = False
        Me.DgvItem.BackgroundColor = System.Drawing.Color.White
        Me.DgvItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCartonid, Me.ColMoid, Me.ColCartonqty, Me.ColFloorid, Me.ColWhid, Me.ColAreaid, Me.Column1})
        Me.DgvItem.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DgvItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvItem.Location = New System.Drawing.Point(0, 0)
        Me.DgvItem.Name = "DgvItem"
        Me.DgvItem.ReadOnly = True
        Me.DgvItem.RowHeadersWidth = 10
        Me.DgvItem.RowTemplate.Height = 24
        Me.DgvItem.Size = New System.Drawing.Size(443, 238)
        Me.DgvItem.TabIndex = 0
        '
        'ColCartonid
        '
        Me.ColCartonid.HeaderText = "工單編號"
        Me.ColCartonid.Name = "ColCartonid"
        Me.ColCartonid.ReadOnly = True
        '
        'ColMoid
        '
        Me.ColMoid.HeaderText = "料件編號"
        Me.ColMoid.Name = "ColMoid"
        Me.ColMoid.ReadOnly = True
        '
        'ColCartonqty
        '
        Me.ColCartonqty.HeaderText = "產品數量"
        Me.ColCartonqty.Name = "ColCartonqty"
        Me.ColCartonqty.ReadOnly = True
        '
        'ColFloorid
        '
        Me.ColFloorid.HeaderText = "樓層"
        Me.ColFloorid.Name = "ColFloorid"
        Me.ColFloorid.ReadOnly = True
        Me.ColFloorid.Visible = False
        '
        'ColWhid
        '
        Me.ColWhid.HeaderText = "倉庫"
        Me.ColWhid.Name = "ColWhid"
        Me.ColWhid.ReadOnly = True
        Me.ColWhid.Visible = False
        '
        'ColAreaid
        '
        Me.ColAreaid.HeaderText = "儲位"
        Me.ColAreaid.Name = "ColAreaid"
        Me.ColAreaid.ReadOnly = True
        Me.ColAreaid.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "生產日期"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(125, 26)
        '
        'ToolStripMenuItem
        '
        Me.ToolStripMenuItem.Name = "ToolStripMenuItem"
        Me.ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripMenuItem.Text = "顯示全部"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 238)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(443, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.LabCartonQty)
        Me.Panel2.Controls.Add(Me.labTatalQty)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(443, 31)
        Me.Panel2.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(381, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "退出(按q)"
        '
        'LabCartonQty
        '
        Me.LabCartonQty.AutoSize = True
        Me.LabCartonQty.Location = New System.Drawing.Point(249, 8)
        Me.LabCartonQty.Name = "LabCartonQty"
        Me.LabCartonQty.Size = New System.Drawing.Size(11, 12)
        Me.LabCartonQty.TabIndex = 4
        Me.LabCartonQty.Text = "0"
        '
        'labTatalQty
        '
        Me.labTatalQty.AutoSize = True
        Me.labTatalQty.Location = New System.Drawing.Point(87, 9)
        Me.labTatalQty.Name = "labTatalQty"
        Me.labTatalQty.Size = New System.Drawing.Size(11, 12)
        Me.labTatalQty.TabIndex = 3
        Me.labTatalQty.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(189, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "總筆數："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "總數量："
        '
        'FrmInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 291)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "FrmInformation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "優先出貨的料件"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DgvItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DgvItem As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LabCartonQty As System.Windows.Forms.Label
    Friend WithEvents labTatalQty As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColCartonid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMoid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCartonqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFloorid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColWhid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAreaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
