<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModuleManage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmModuleManage))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.ModuleTree = New System.Windows.Forms.TreeView()
        Me.GroupBox_Ico = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox_Img = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox_Parent_Name = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox_Parent_Id = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox_Frm_Name = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox_Module_Name = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox_Id = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewFile = New System.Windows.Forms.ToolStripButton()
        Me.EditFile = New System.Windows.Forms.ToolStripButton()
        Me.Save = New System.Windows.Forms.ToolStripButton()
        Me.Delete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DataRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.Back = New System.Windows.Forms.ToolStripButton()
        Me.TextBox_ButtonId = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox_Ico.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolBt.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1050, 505)
        Me.Panel1.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1050, 505)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel3)
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1042, 479)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "模块&图标设置"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.SplitContainer2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 28)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1036, 448)
        Me.Panel3.TabIndex = 1
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.ModuleTree)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.TextBox_ButtonId)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox_Ico)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TextBox_Parent_Name)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TextBox_Parent_Id)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TextBox_Frm_Name)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TextBox_Module_Name)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TextBox_Id)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1036, 448)
        Me.SplitContainer2.SplitterDistance = 650
        Me.SplitContainer2.TabIndex = 0
        '
        'ModuleTree
        '
        Me.ModuleTree.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ModuleTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ModuleTree.Location = New System.Drawing.Point(0, 0)
        Me.ModuleTree.Name = "ModuleTree"
        Me.ModuleTree.Size = New System.Drawing.Size(650, 448)
        Me.ModuleTree.TabIndex = 3
        '
        'GroupBox_Ico
        '
        Me.GroupBox_Ico.Controls.Add(Me.Label9)
        Me.GroupBox_Ico.Controls.Add(Me.Button1)
        Me.GroupBox_Ico.Controls.Add(Me.TextBox_Img)
        Me.GroupBox_Ico.Controls.Add(Me.Label7)
        Me.GroupBox_Ico.Location = New System.Drawing.Point(8, 167)
        Me.GroupBox_Ico.Name = "GroupBox_Ico"
        Me.GroupBox_Ico.Size = New System.Drawing.Size(366, 88)
        Me.GroupBox_Ico.TabIndex = 11
        Me.GroupBox_Ico.TabStop = False
        Me.GroupBox_Ico.Text = "图标设置"
        Me.GroupBox_Ico.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(66, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(227, 12)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "注：请选择48*48分辨率的图片做为图标！"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(329, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(34, 23)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox_Img
        '
        Me.TextBox_Img.Location = New System.Drawing.Point(66, 26)
        Me.TextBox_Img.Name = "TextBox_Img"
        Me.TextBox_Img.Size = New System.Drawing.Size(259, 21)
        Me.TextBox_Img.TabIndex = 22
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "图标文件"
        '
        'TextBox_Parent_Name
        '
        Me.TextBox_Parent_Name.Location = New System.Drawing.Point(257, 7)
        Me.TextBox_Parent_Name.Name = "TextBox_Parent_Name"
        Me.TextBox_Parent_Name.Size = New System.Drawing.Size(100, 21)
        Me.TextBox_Parent_Name.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(185, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "父模块名称"
        '
        'TextBox_Parent_Id
        '
        Me.TextBox_Parent_Id.Location = New System.Drawing.Point(87, 7)
        Me.TextBox_Parent_Id.Name = "TextBox_Parent_Id"
        Me.TextBox_Parent_Id.Size = New System.Drawing.Size(91, 21)
        Me.TextBox_Parent_Id.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "父模块编号"
        '
        'TextBox_Frm_Name
        '
        Me.TextBox_Frm_Name.Location = New System.Drawing.Point(87, 95)
        Me.TextBox_Frm_Name.Name = "TextBox_Frm_Name"
        Me.TextBox_Frm_Name.Size = New System.Drawing.Size(273, 21)
        Me.TextBox_Frm_Name.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "模块窗口"
        '
        'TextBox_Module_Name
        '
        Me.TextBox_Module_Name.Location = New System.Drawing.Point(87, 63)
        Me.TextBox_Module_Name.Name = "TextBox_Module_Name"
        Me.TextBox_Module_Name.Size = New System.Drawing.Size(273, 21)
        Me.TextBox_Module_Name.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "模块名称"
        '
        'TextBox_Id
        '
        Me.TextBox_Id.Location = New System.Drawing.Point(87, 36)
        Me.TextBox_Id.Name = "TextBox_Id"
        Me.TextBox_Id.Size = New System.Drawing.Size(273, 21)
        Me.TextBox_Id.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "模块编号"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ToolBt)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1036, 25)
        Me.Panel2.TabIndex = 0
        '
        'ToolBt
        '
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.NewFile, Me.EditFile, Me.Save, Me.Delete, Me.DataRefresh, Me.ToolStripSeparator2, Me.Back, Me.ExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1036, 25)
        Me.ToolBt.TabIndex = 11
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'NewFile
        '
        Me.NewFile.Image = CType(resources.GetObject("NewFile.Image"), System.Drawing.Image)
        Me.NewFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewFile.Name = "NewFile"
        Me.NewFile.Size = New System.Drawing.Size(52, 22)
        Me.NewFile.Text = "新增"
        Me.NewFile.ToolTipText = "新增"
        '
        'EditFile
        '
        Me.EditFile.Image = CType(resources.GetObject("EditFile.Image"), System.Drawing.Image)
        Me.EditFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditFile.Name = "EditFile"
        Me.EditFile.Size = New System.Drawing.Size(52, 22)
        Me.EditFile.Text = "修改"
        Me.EditFile.ToolTipText = "修改"
        '
        'Save
        '
        Me.Save.Image = CType(resources.GetObject("Save.Image"), System.Drawing.Image)
        Me.Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(52, 22)
        Me.Save.Text = "保存"
        Me.Save.ToolTipText = "保存"
        '
        'Delete
        '
        Me.Delete.Image = CType(resources.GetObject("Delete.Image"), System.Drawing.Image)
        Me.Delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(52, 22)
        Me.Delete.Text = "刪除"
        Me.Delete.ToolTipText = "刪除"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'DataRefresh
        '
        Me.DataRefresh.Image = CType(resources.GetObject("DataRefresh.Image"), System.Drawing.Image)
        Me.DataRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.DataRefresh.Name = "DataRefresh"
        Me.DataRefresh.Size = New System.Drawing.Size(52, 22)
        Me.DataRefresh.Text = "刷新"
        Me.DataRefresh.ToolTipText = "刷新"
        '
        'ExitFrom
        '
        Me.ExitFrom.Image = CType(resources.GetObject("ExitFrom.Image"), System.Drawing.Image)
        Me.ExitFrom.ImageTransparentColor = System.Drawing.Color.White
        Me.ExitFrom.Name = "ExitFrom"
        Me.ExitFrom.Size = New System.Drawing.Size(52, 22)
        Me.ExitFrom.Text = "退出"
        Me.ExitFrom.ToolTipText = "退出"
        '
        'Back
        '
        Me.Back.Image = CType(resources.GetObject("Back.Image"), System.Drawing.Image)
        Me.Back.ImageTransparentColor = System.Drawing.Color.White
        Me.Back.Name = "Back"
        Me.Back.Size = New System.Drawing.Size(52, 22)
        Me.Back.Text = "返回"
        Me.Back.ToolTipText = "退出"
        '
        'TextBox_ButtonId
        '
        Me.TextBox_ButtonId.Location = New System.Drawing.Point(87, 125)
        Me.TextBox_ButtonId.Name = "TextBox_ButtonId"
        Me.TextBox_ButtonId.Size = New System.Drawing.Size(273, 21)
        Me.TextBox_ButtonId.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "按钮编号"
        '
        'FrmModuleManage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1050, 505)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmModuleManage"
        Me.Text = "前台模块设置"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox_Ico.ResumeLayout(False)
        Me.GroupBox_Ico.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ModuleTree As System.Windows.Forms.TreeView
    Friend WithEvents GroupBox_Ico As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox_Img As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Parent_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Parent_Id As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Frm_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Module_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Id As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents EditFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents Delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents Back As System.Windows.Forms.ToolStripButton
    Friend WithEvents TextBox_ButtonId As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
