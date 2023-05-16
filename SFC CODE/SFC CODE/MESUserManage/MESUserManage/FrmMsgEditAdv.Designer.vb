<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMsgEditAdv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMsgEditAdv))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.文件FToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.saveSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.aSaveAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.exitEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.编辑EToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.insertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.格式OToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BoldToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItalicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnderlineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.左对齐LToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.居中对齐CToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.右对齐RToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.familyToolStripComboBoxName = New System.Windows.Forms.ToolStripComboBox()
        Me.fontSizeToolStripComboBoxSize = New System.Windows.Forms.ToolStripComboBox()
        Me.bigToolStripButton15 = New System.Windows.Forms.ToolStripButton()
        Me.smallToolStripButton14 = New System.Windows.Forms.ToolStripButton()
        Me.boldToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.iToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.uToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.strikeToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.colorToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.undoToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.redoToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.LeftToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.centerToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.rightToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ipStripButton13 = New System.Windows.Forms.ToolStripButton()
        Me.ClearToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.saveToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.seeToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.richTextBoxEx1 = New DevComponents.DotNetBar.Controls.RichTextBoxEx()
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.openImageDialog = New System.Windows.Forms.OpenFileDialog()
        Me.colorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件FToolStripMenuItem, Me.编辑EToolStripMenuItem, Me.格式OToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(843, 25)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '文件FToolStripMenuItem
        '
        Me.文件FToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.openToolStripMenuItem, Me.saveSToolStripMenuItem, Me.aSaveAToolStripMenuItem, Me.exitEToolStripMenuItem})
        Me.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem"
        Me.文件FToolStripMenuItem.Size = New System.Drawing.Size(58, 21)
        Me.文件FToolStripMenuItem.Text = "文件(F)"
        '
        'openToolStripMenuItem
        '
        Me.openToolStripMenuItem.Image = CType(resources.GetObject("openToolStripMenuItem.Image"), System.Drawing.Image)
        Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
        Me.openToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.openToolStripMenuItem.Text = "打开(O)"
        '
        'saveSToolStripMenuItem
        '
        Me.saveSToolStripMenuItem.Image = CType(resources.GetObject("saveSToolStripMenuItem.Image"), System.Drawing.Image)
        Me.saveSToolStripMenuItem.Name = "saveSToolStripMenuItem"
        Me.saveSToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.saveSToolStripMenuItem.Text = "保存(S)"
        '
        'aSaveAToolStripMenuItem
        '
        Me.aSaveAToolStripMenuItem.Image = CType(resources.GetObject("aSaveAToolStripMenuItem.Image"), System.Drawing.Image)
        Me.aSaveAToolStripMenuItem.Name = "aSaveAToolStripMenuItem"
        Me.aSaveAToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.aSaveAToolStripMenuItem.Text = "另存为(A)"
        '
        'exitEToolStripMenuItem
        '
        Me.exitEToolStripMenuItem.Image = CType(resources.GetObject("exitEToolStripMenuItem.Image"), System.Drawing.Image)
        Me.exitEToolStripMenuItem.Name = "exitEToolStripMenuItem"
        Me.exitEToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.exitEToolStripMenuItem.Text = "退出(E)"
        '
        '编辑EToolStripMenuItem
        '
        Me.编辑EToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.XToolStripMenuItem, Me.VToolStripMenuItem, Me.PToolStripMenuItem, Me.insertToolStripMenuItem})
        Me.编辑EToolStripMenuItem.Name = "编辑EToolStripMenuItem"
        Me.编辑EToolStripMenuItem.Size = New System.Drawing.Size(59, 21)
        Me.编辑EToolStripMenuItem.Text = "编辑(E)"
        '
        'XToolStripMenuItem
        '
        Me.XToolStripMenuItem.Image = CType(resources.GetObject("XToolStripMenuItem.Image"), System.Drawing.Image)
        Me.XToolStripMenuItem.Name = "XToolStripMenuItem"
        Me.XToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.XToolStripMenuItem.Text = "剪切(X)"
        '
        'VToolStripMenuItem
        '
        Me.VToolStripMenuItem.Image = CType(resources.GetObject("VToolStripMenuItem.Image"), System.Drawing.Image)
        Me.VToolStripMenuItem.Name = "VToolStripMenuItem"
        Me.VToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.VToolStripMenuItem.Text = "复制(V)"
        '
        'PToolStripMenuItem
        '
        Me.PToolStripMenuItem.Image = CType(resources.GetObject("PToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PToolStripMenuItem.Name = "PToolStripMenuItem"
        Me.PToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.PToolStripMenuItem.Text = "粘贴(P)"
        '
        'insertToolStripMenuItem
        '
        Me.insertToolStripMenuItem.Image = CType(resources.GetObject("insertToolStripMenuItem.Image"), System.Drawing.Image)
        Me.insertToolStripMenuItem.Name = "insertToolStripMenuItem"
        Me.insertToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.insertToolStripMenuItem.Text = "插入图片(I)"
        '
        '格式OToolStripMenuItem
        '
        Me.格式OToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BoldToolStripMenuItem, Me.ItalicToolStripMenuItem, Me.UnderlineToolStripMenuItem, Me.FontToolStripMenuItem, Me.ColorToolStripMenuItem, Me.左对齐LToolStripMenuItem, Me.居中对齐CToolStripMenuItem, Me.右对齐RToolStripMenuItem})
        Me.格式OToolStripMenuItem.Name = "格式OToolStripMenuItem"
        Me.格式OToolStripMenuItem.Size = New System.Drawing.Size(62, 21)
        Me.格式OToolStripMenuItem.Text = "格式(O)"
        '
        'BoldToolStripMenuItem
        '
        Me.BoldToolStripMenuItem.Image = CType(resources.GetObject("BoldToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BoldToolStripMenuItem.Name = "BoldToolStripMenuItem"
        Me.BoldToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.BoldToolStripMenuItem.Text = "Bold"
        '
        'ItalicToolStripMenuItem
        '
        Me.ItalicToolStripMenuItem.Image = CType(resources.GetObject("ItalicToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ItalicToolStripMenuItem.Name = "ItalicToolStripMenuItem"
        Me.ItalicToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ItalicToolStripMenuItem.Text = "Italic"
        '
        'UnderlineToolStripMenuItem
        '
        Me.UnderlineToolStripMenuItem.Image = CType(resources.GetObject("UnderlineToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UnderlineToolStripMenuItem.Name = "UnderlineToolStripMenuItem"
        Me.UnderlineToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.UnderlineToolStripMenuItem.Text = "Underline"
        '
        'FontToolStripMenuItem
        '
        Me.FontToolStripMenuItem.Image = CType(resources.GetObject("FontToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FontToolStripMenuItem.Name = "FontToolStripMenuItem"
        Me.FontToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.FontToolStripMenuItem.Text = "TextColor"
        '
        'ColorToolStripMenuItem
        '
        Me.ColorToolStripMenuItem.Image = CType(resources.GetObject("ColorToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ColorToolStripMenuItem.Name = "ColorToolStripMenuItem"
        Me.ColorToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ColorToolStripMenuItem.Text = "BackColor"
        '
        '左对齐LToolStripMenuItem
        '
        Me.左对齐LToolStripMenuItem.Image = CType(resources.GetObject("左对齐LToolStripMenuItem.Image"), System.Drawing.Image)
        Me.左对齐LToolStripMenuItem.Name = "左对齐LToolStripMenuItem"
        Me.左对齐LToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.左对齐LToolStripMenuItem.Text = "左对齐(L)"
        '
        '居中对齐CToolStripMenuItem
        '
        Me.居中对齐CToolStripMenuItem.Image = CType(resources.GetObject("居中对齐CToolStripMenuItem.Image"), System.Drawing.Image)
        Me.居中对齐CToolStripMenuItem.Name = "居中对齐CToolStripMenuItem"
        Me.居中对齐CToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.居中对齐CToolStripMenuItem.Text = "居中对齐(C)"
        '
        '右对齐RToolStripMenuItem
        '
        Me.右对齐RToolStripMenuItem.Image = CType(resources.GetObject("右对齐RToolStripMenuItem.Image"), System.Drawing.Image)
        Me.右对齐RToolStripMenuItem.Name = "右对齐RToolStripMenuItem"
        Me.右对齐RToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.右对齐RToolStripMenuItem.Text = "右对齐(R)"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.familyToolStripComboBoxName, Me.fontSizeToolStripComboBoxSize, Me.bigToolStripButton15, Me.smallToolStripButton14, Me.boldToolStripButton1, Me.iToolStripButton2, Me.uToolStripButton3, Me.strikeToolStripButton8, Me.ToolStripButton7, Me.ToolStripButton4, Me.ToolStripSeparator6, Me.ToolStripButton1, Me.colorToolStripButton4, Me.ToolStripSeparator4, Me.undoToolStripButton2, Me.redoToolStripButton1, Me.ToolStripSeparator1, Me.ToolStripButton5, Me.ToolStripSeparator2, Me.ToolStripButton3, Me.ToolStripButton2, Me.ToolStripSeparator5, Me.LeftToolStripButton7, Me.centerToolStripButton8, Me.rightToolStripButton9, Me.ToolStripSeparator3, Me.ipStripButton13, Me.ClearToolStripButton6, Me.saveToolStripButton1, Me.seeToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(843, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'familyToolStripComboBoxName
        '
        Me.familyToolStripComboBoxName.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.familyToolStripComboBoxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.familyToolStripComboBoxName.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.familyToolStripComboBoxName.Name = "familyToolStripComboBoxName"
        Me.familyToolStripComboBoxName.Size = New System.Drawing.Size(121, 25)
        '
        'fontSizeToolStripComboBoxSize
        '
        Me.fontSizeToolStripComboBoxSize.BackColor = System.Drawing.SystemColors.Window
        Me.fontSizeToolStripComboBoxSize.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.fontSizeToolStripComboBoxSize.Items.AddRange(New Object() {"8", "10", "12", "14", "16", "18", "20 ", "24", "36"})
        Me.fontSizeToolStripComboBoxSize.Name = "fontSizeToolStripComboBoxSize"
        Me.fontSizeToolStripComboBoxSize.Size = New System.Drawing.Size(121, 25)
        '
        'bigToolStripButton15
        '
        Me.bigToolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bigToolStripButton15.Image = CType(resources.GetObject("bigToolStripButton15.Image"), System.Drawing.Image)
        Me.bigToolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.bigToolStripButton15.Name = "bigToolStripButton15"
        Me.bigToolStripButton15.Size = New System.Drawing.Size(23, 22)
        Me.bigToolStripButton15.Text = "增大字号"
        '
        'smallToolStripButton14
        '
        Me.smallToolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.smallToolStripButton14.Image = CType(resources.GetObject("smallToolStripButton14.Image"), System.Drawing.Image)
        Me.smallToolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.smallToolStripButton14.Name = "smallToolStripButton14"
        Me.smallToolStripButton14.Size = New System.Drawing.Size(23, 22)
        Me.smallToolStripButton14.Text = "小"
        '
        'boldToolStripButton1
        '
        Me.boldToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.boldToolStripButton1.Image = CType(resources.GetObject("boldToolStripButton1.Image"), System.Drawing.Image)
        Me.boldToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.boldToolStripButton1.Name = "boldToolStripButton1"
        Me.boldToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.boldToolStripButton1.Text = "加粗"
        '
        'iToolStripButton2
        '
        Me.iToolStripButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.iToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.iToolStripButton2.Image = CType(resources.GetObject("iToolStripButton2.Image"), System.Drawing.Image)
        Me.iToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.iToolStripButton2.Name = "iToolStripButton2"
        Me.iToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.iToolStripButton2.Text = "倾斜"
        '
        'uToolStripButton3
        '
        Me.uToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.uToolStripButton3.Image = CType(resources.GetObject("uToolStripButton3.Image"), System.Drawing.Image)
        Me.uToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.uToolStripButton3.Name = "uToolStripButton3"
        Me.uToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.uToolStripButton3.Text = "下划线"
        '
        'strikeToolStripButton8
        '
        Me.strikeToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.strikeToolStripButton8.Image = CType(resources.GetObject("strikeToolStripButton8.Image"), System.Drawing.Image)
        Me.strikeToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.strikeToolStripButton8.Name = "strikeToolStripButton8"
        Me.strikeToolStripButton8.Size = New System.Drawing.Size(23, 22)
        Me.strikeToolStripButton8.Text = "下划线"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "下标"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "上标"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "背景色"
        Me.ToolStripButton1.ToolTipText = "以不同的颜色突出显示文本"
        '
        'colorToolStripButton4
        '
        Me.colorToolStripButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.colorToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.colorToolStripButton4.Image = CType(resources.GetObject("colorToolStripButton4.Image"), System.Drawing.Image)
        Me.colorToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.colorToolStripButton4.Name = "colorToolStripButton4"
        Me.colorToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.colorToolStripButton4.Text = "字体颜色"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'undoToolStripButton2
        '
        Me.undoToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.undoToolStripButton2.Image = CType(resources.GetObject("undoToolStripButton2.Image"), System.Drawing.Image)
        Me.undoToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.undoToolStripButton2.Name = "undoToolStripButton2"
        Me.undoToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.undoToolStripButton2.Text = "撤销"
        '
        'redoToolStripButton1
        '
        Me.redoToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.redoToolStripButton1.Image = CType(resources.GetObject("redoToolStripButton1.Image"), System.Drawing.Image)
        Me.redoToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.redoToolStripButton1.Name = "redoToolStripButton1"
        Me.redoToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.redoToolStripButton1.Text = "重做"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "项目符号"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "较少缩进量"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "增加缩进量"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'LeftToolStripButton7
        '
        Me.LeftToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LeftToolStripButton7.Image = CType(resources.GetObject("LeftToolStripButton7.Image"), System.Drawing.Image)
        Me.LeftToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LeftToolStripButton7.Name = "LeftToolStripButton7"
        Me.LeftToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.LeftToolStripButton7.Text = "左对齐"
        '
        'centerToolStripButton8
        '
        Me.centerToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.centerToolStripButton8.Image = CType(resources.GetObject("centerToolStripButton8.Image"), System.Drawing.Image)
        Me.centerToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.centerToolStripButton8.Name = "centerToolStripButton8"
        Me.centerToolStripButton8.Size = New System.Drawing.Size(23, 22)
        Me.centerToolStripButton8.Text = "居中"
        '
        'rightToolStripButton9
        '
        Me.rightToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.rightToolStripButton9.Image = CType(resources.GetObject("rightToolStripButton9.Image"), System.Drawing.Image)
        Me.rightToolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.rightToolStripButton9.Name = "rightToolStripButton9"
        Me.rightToolStripButton9.Size = New System.Drawing.Size(23, 22)
        Me.rightToolStripButton9.Text = "右对齐"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ipStripButton13
        '
        Me.ipStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ipStripButton13.Image = CType(resources.GetObject("ipStripButton13.Image"), System.Drawing.Image)
        Me.ipStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ipStripButton13.Name = "ipStripButton13"
        Me.ipStripButton13.Size = New System.Drawing.Size(23, 22)
        Me.ipStripButton13.Text = "插入图片"
        '
        'ClearToolStripButton6
        '
        Me.ClearToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ClearToolStripButton6.Image = CType(resources.GetObject("ClearToolStripButton6.Image"), System.Drawing.Image)
        Me.ClearToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ClearToolStripButton6.Name = "ClearToolStripButton6"
        Me.ClearToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ClearToolStripButton6.Text = "清空"
        '
        'saveToolStripButton1
        '
        Me.saveToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.saveToolStripButton1.Image = CType(resources.GetObject("saveToolStripButton1.Image"), System.Drawing.Image)
        Me.saveToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.saveToolStripButton1.Name = "saveToolStripButton1"
        Me.saveToolStripButton1.Size = New System.Drawing.Size(36, 22)
        Me.saveToolStripButton1.Text = "保存"
        '
        'seeToolStripButton1
        '
        Me.seeToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.seeToolStripButton1.Image = CType(resources.GetObject("seeToolStripButton1.Image"), System.Drawing.Image)
        Me.seeToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.seeToolStripButton1.Name = "seeToolStripButton1"
        Me.seeToolStripButton1.Size = New System.Drawing.Size(36, 22)
        Me.seeToolStripButton1.Text = "查看"
        '
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "OpenFileDialog1"
        '
        'richTextBoxEx1
        '
        '
        '
        '
        Me.richTextBoxEx1.BackgroundStyle.Class = "RichTextBoxBorder"
        Me.richTextBoxEx1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.richTextBoxEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.richTextBoxEx1.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.richTextBoxEx1.Location = New System.Drawing.Point(0, 50)
        Me.richTextBoxEx1.Name = "richTextBoxEx1"
        Me.richTextBoxEx1.Rtf = "{\rtf1\ansi\ansicpg936\deff0\deflang1033\deflangfe2052{\fonttbl{\f0\fnil\fcharset" & _
    "134 \'cb\'ce\'cc\'e5;}}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\viewkind4\uc1\pard\lang2052\f0\fs32\par" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.richTextBoxEx1.Size = New System.Drawing.Size(843, 372)
        Me.richTextBoxEx1.TabIndex = 2
        Me.richTextBoxEx1.Tag = "11"
        '
        'openImageDialog
        '
        Me.openImageDialog.FileName = "OpenFileDialog2"
        '
        'FrmMsgEditAdv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 422)
        Me.Controls.Add(Me.richTextBoxEx1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmMsgEditAdv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "公告详情"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 文件FToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents saveSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents aSaveAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents exitEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 编辑EToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents insertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 格式OToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BoldToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItalicToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnderlineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 左对齐LToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 居中对齐CToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 右对齐RToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents familyToolStripComboBoxName As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents fontSizeToolStripComboBoxSize As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents boldToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents iToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents uToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents colorToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents bigToolStripButton15 As System.Windows.Forms.ToolStripButton
    Friend WithEvents smallToolStripButton14 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LeftToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents centerToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents rightToolStripButton9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ipStripButton13 As System.Windows.Forms.ToolStripButton
    Friend WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents richTextBoxEx1 As DevComponents.DotNetBar.Controls.RichTextBoxEx
    Friend WithEvents saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents openImageDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents colorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents undoToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents redoToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents saveToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents seeToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents strikeToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ClearToolStripButton6 As System.Windows.Forms.ToolStripButton
End Class
