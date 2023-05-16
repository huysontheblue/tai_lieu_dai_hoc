<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLaserPrintOld
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLaserPrintOld))
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtInput = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lbl11 = New System.Windows.Forms.Label
        Me.lbl12 = New System.Windows.Forms.Label
        Me.lbl21 = New System.Windows.Forms.Label
        Me.lbl22 = New System.Windows.Forms.Label
        Me.lbl31 = New System.Windows.Forms.Label
        Me.lbl32 = New System.Windows.Forms.Label
        Me.lbl41 = New System.Windows.Forms.Label
        Me.lbl42 = New System.Windows.Forms.Label
        Me.lbl51 = New System.Windows.Forms.Label
        Me.lbl52 = New System.Windows.Forms.Label
        Me.lbl61 = New System.Windows.Forms.Label
        Me.lbl62 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.tsLable = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.cmdDel = New System.Windows.Forms.Button
        Me.lblresult = New System.Windows.Forms.Label
        Me.chkAuto = New System.Windows.Forms.CheckBox
        Me.txtAdd = New System.Windows.Forms.TextBox
        Me.butSet = New System.Windows.Forms.Button
        Me.txtIP = New System.Windows.Forms.NumericUpDown
        Me.npLine = New System.Windows.Forms.NumericUpDown
        Me.npStart = New System.Windows.Forms.NumericUpDown
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtBkcount = New System.Windows.Forms.TextBox
        Me.Butedit = New System.Windows.Forms.Button
        Me.ButOk = New System.Windows.Forms.Button
        Me.Lblmessage = New System.Windows.Forms.Label
        Me.CobLaserStyle = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.LblReadCount = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.txtIP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.npLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.npStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label3.Font = New System.Drawing.Font("Trebuchet MS", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(0, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1077, 44)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Apple Serial Number Format Cable Laser Etching"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdOK
        '
        Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdOK.Location = New System.Drawing.Point(581, 402)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 25)
        Me.cmdOK.TabIndex = 3
        Me.cmdOK.Text = "标刻"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 288.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtInput, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl11, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl12, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl21, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl22, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl31, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl32, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl41, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl42, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl51, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl52, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl61, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl62, 3, 6)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 70)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1077, 329)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(69, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(448, 35)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "条形码读取"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(526, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(254, 35)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "ASN 17-Digit"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(789, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(282, 35)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "ASN 12-Digit (标刻码)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(6, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 44)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "1"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtInput
        '
        Me.txtInput.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtInput.Font = New System.Drawing.Font("宋体", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtInput.Location = New System.Drawing.Point(69, 44)
        Me.txtInput.Multiline = True
        Me.txtInput.Name = "txtInput"
        Me.TableLayoutPanel1.SetRowSpan(Me.txtInput, 6)
        Me.txtInput.Size = New System.Drawing.Size(448, 279)
        Me.txtInput.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(6, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 44)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "2"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(6, 135)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 44)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "3"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(6, 182)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 44)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "4"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(6, 229)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 44)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "5"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(6, 276)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 50)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "6"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl11
        '
        Me.lbl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl11.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl11.Location = New System.Drawing.Point(526, 41)
        Me.lbl11.Name = "lbl11"
        Me.lbl11.Size = New System.Drawing.Size(254, 44)
        Me.lbl11.TabIndex = 27
        Me.lbl11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl12
        '
        Me.lbl12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl12.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.lbl12.Location = New System.Drawing.Point(789, 41)
        Me.lbl12.Name = "lbl12"
        Me.lbl12.Size = New System.Drawing.Size(282, 44)
        Me.lbl12.TabIndex = 28
        Me.lbl12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl21
        '
        Me.lbl21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl21.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl21.Location = New System.Drawing.Point(526, 88)
        Me.lbl21.Name = "lbl21"
        Me.lbl21.Size = New System.Drawing.Size(254, 44)
        Me.lbl21.TabIndex = 29
        Me.lbl21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl22
        '
        Me.lbl22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl22.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.lbl22.Location = New System.Drawing.Point(789, 88)
        Me.lbl22.Name = "lbl22"
        Me.lbl22.Size = New System.Drawing.Size(282, 44)
        Me.lbl22.TabIndex = 30
        Me.lbl22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl31
        '
        Me.lbl31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl31.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl31.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl31.Location = New System.Drawing.Point(526, 135)
        Me.lbl31.Name = "lbl31"
        Me.lbl31.Size = New System.Drawing.Size(254, 44)
        Me.lbl31.TabIndex = 31
        Me.lbl31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl32
        '
        Me.lbl32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl32.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl32.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.lbl32.Location = New System.Drawing.Point(789, 135)
        Me.lbl32.Name = "lbl32"
        Me.lbl32.Size = New System.Drawing.Size(282, 44)
        Me.lbl32.TabIndex = 32
        Me.lbl32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl41
        '
        Me.lbl41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl41.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl41.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl41.Location = New System.Drawing.Point(526, 182)
        Me.lbl41.Name = "lbl41"
        Me.lbl41.Size = New System.Drawing.Size(254, 44)
        Me.lbl41.TabIndex = 33
        Me.lbl41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl42
        '
        Me.lbl42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl42.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl42.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.lbl42.Location = New System.Drawing.Point(789, 182)
        Me.lbl42.Name = "lbl42"
        Me.lbl42.Size = New System.Drawing.Size(282, 44)
        Me.lbl42.TabIndex = 34
        Me.lbl42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl51
        '
        Me.lbl51.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl51.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl51.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl51.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl51.Location = New System.Drawing.Point(526, 229)
        Me.lbl51.Name = "lbl51"
        Me.lbl51.Size = New System.Drawing.Size(254, 44)
        Me.lbl51.TabIndex = 35
        Me.lbl51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl52
        '
        Me.lbl52.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl52.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl52.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl52.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.lbl52.Location = New System.Drawing.Point(789, 229)
        Me.lbl52.Name = "lbl52"
        Me.lbl52.Size = New System.Drawing.Size(282, 44)
        Me.lbl52.TabIndex = 36
        Me.lbl52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl61
        '
        Me.lbl61.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl61.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl61.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl61.Location = New System.Drawing.Point(526, 276)
        Me.lbl61.Name = "lbl61"
        Me.lbl61.Size = New System.Drawing.Size(254, 50)
        Me.lbl61.TabIndex = 37
        Me.lbl61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl62
        '
        Me.lbl62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl62.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl62.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl62.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.lbl62.Location = New System.Drawing.Point(789, 276)
        Me.lbl62.Name = "lbl62"
        Me.lbl62.Size = New System.Drawing.Size(282, 50)
        Me.lbl62.TabIndex = 38
        Me.lbl62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdExit.Location = New System.Drawing.Point(662, 402)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 25)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "退出"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLable, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 525)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1077, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsLable
        '
        Me.tsLable.BackColor = System.Drawing.SystemColors.Control
        Me.tsLable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsLable.Name = "tsLable"
        Me.tsLable.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(41, 17)
        Me.ToolStripStatusLabel1.Text = "就绪..."
        '
        'cmdDel
        '
        Me.cmdDel.Enabled = False
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdDel.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.cmdDel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.cmdDel.Location = New System.Drawing.Point(498, 462)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(143, 31)
        Me.cmdDel.TabIndex = 5
        Me.cmdDel.Text = "删除读取记录"
        Me.cmdDel.UseVisualStyleBackColor = True
        '
        'lblresult
        '
        Me.lblresult.BackColor = System.Drawing.Color.Transparent
        Me.lblresult.Font = New System.Drawing.Font("幼圆", 24.0!)
        Me.lblresult.ForeColor = System.Drawing.Color.Gray
        Me.lblresult.Location = New System.Drawing.Point(2, 407)
        Me.lblresult.Name = "lblresult"
        Me.lblresult.Size = New System.Drawing.Size(310, 49)
        Me.lblresult.TabIndex = 11
        Me.lblresult.Text = "等候插卡数据读取"
        Me.lblresult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkAuto
        '
        Me.chkAuto.AutoSize = True
        Me.chkAuto.Checked = True
        Me.chkAuto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAuto.Font = New System.Drawing.Font("幼圆", 14.25!)
        Me.chkAuto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkAuto.Location = New System.Drawing.Point(498, 433)
        Me.chkAuto.Name = "chkAuto"
        Me.chkAuto.Size = New System.Drawing.Size(248, 23)
        Me.chkAuto.TabIndex = 12
        Me.chkAuto.Text = "扫描完全部后，自动标刻"
        Me.chkAuto.UseVisualStyleBackColor = True
        '
        'txtAdd
        '
        Me.txtAdd.Enabled = False
        Me.txtAdd.Location = New System.Drawing.Point(377, 421)
        Me.txtAdd.Name = "txtAdd"
        Me.txtAdd.Size = New System.Drawing.Size(81, 21)
        Me.txtAdd.TabIndex = 14
        '
        'butSet
        '
        Me.butSet.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butSet.Location = New System.Drawing.Point(498, 402)
        Me.butSet.Name = "butSet"
        Me.butSet.Size = New System.Drawing.Size(75, 25)
        Me.butSet.TabIndex = 15
        Me.butSet.Text = "设置"
        Me.butSet.UseVisualStyleBackColor = True
        '
        'txtIP
        '
        Me.txtIP.Enabled = False
        Me.txtIP.Location = New System.Drawing.Point(377, 398)
        Me.txtIP.Maximum = New Decimal(New Integer() {32276, 0, 0, 0})
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(81, 21)
        Me.txtIP.TabIndex = 16
        '
        'npLine
        '
        Me.npLine.Enabled = False
        Me.npLine.Location = New System.Drawing.Point(377, 448)
        Me.npLine.Maximum = New Decimal(New Integer() {32276, 0, 0, 0})
        Me.npLine.Name = "npLine"
        Me.npLine.Size = New System.Drawing.Size(40, 21)
        Me.npLine.TabIndex = 17
        '
        'npStart
        '
        Me.npStart.Enabled = False
        Me.npStart.Location = New System.Drawing.Point(418, 448)
        Me.npStart.Maximum = New Decimal(New Integer() {32276, 0, 0, 0})
        Me.npStart.Name = "npStart"
        Me.npStart.Size = New System.Drawing.Size(40, 21)
        Me.npStart.TabIndex = 18
        '
        'menuStrip1
        '
        Me.menuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2, Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5, Me.toolStripMenuItem6})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(1077, 25)
        Me.menuStrip1.TabIndex = 128
        Me.menuStrip1.Text = "menuStrip1"
        '
        'toolStripMenuItem1
        '
        Me.toolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
        Me.toolStripMenuItem1.Size = New System.Drawing.Size(59, 21)
        Me.toolStripMenuItem1.Text = "系统(&S)"
        '
        'toolStripMenuItem2
        '
        Me.toolStripMenuItem2.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
        Me.toolStripMenuItem2.Size = New System.Drawing.Size(58, 21)
        Me.toolStripMenuItem2.Text = "文件(&F)"
        '
        'toolStripMenuItem3
        '
        Me.toolStripMenuItem3.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
        Me.toolStripMenuItem3.Size = New System.Drawing.Size(60, 21)
        Me.toolStripMenuItem3.Text = "查看(&V)"
        '
        'toolStripMenuItem4
        '
        Me.toolStripMenuItem4.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem4.Name = "toolStripMenuItem4"
        Me.toolStripMenuItem4.Size = New System.Drawing.Size(59, 21)
        Me.toolStripMenuItem4.Text = "工具(&T)"
        '
        'toolStripMenuItem5
        '
        Me.toolStripMenuItem5.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem5.Name = "toolStripMenuItem5"
        Me.toolStripMenuItem5.Size = New System.Drawing.Size(64, 21)
        Me.toolStripMenuItem5.Text = "窗口(&W)"
        '
        'toolStripMenuItem6
        '
        Me.toolStripMenuItem6.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem6.Name = "toolStripMenuItem6"
        Me.toolStripMenuItem6.Size = New System.Drawing.Size(61, 21)
        Me.toolStripMenuItem6.Text = "帮助(&H)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("幼圆", 10.0!)
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(23, 465)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 14)
        Me.Label12.TabIndex = 129
        Me.Label12.Text = "标刻数量："
        '
        'TxtBkcount
        '
        Me.TxtBkcount.Enabled = False
        Me.TxtBkcount.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtBkcount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtBkcount.Location = New System.Drawing.Point(105, 459)
        Me.TxtBkcount.Name = "TxtBkcount"
        Me.TxtBkcount.Size = New System.Drawing.Size(66, 32)
        Me.TxtBkcount.TabIndex = 130
        Me.TxtBkcount.Text = "6"
        '
        'Butedit
        '
        Me.Butedit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Butedit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Butedit.Location = New System.Drawing.Point(178, 463)
        Me.Butedit.Name = "Butedit"
        Me.Butedit.Size = New System.Drawing.Size(75, 23)
        Me.Butedit.TabIndex = 131
        Me.Butedit.Text = "修改"
        Me.Butedit.UseVisualStyleBackColor = True
        '
        'ButOk
        '
        Me.ButOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButOk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButOk.Location = New System.Drawing.Point(268, 463)
        Me.ButOk.Name = "ButOk"
        Me.ButOk.Size = New System.Drawing.Size(75, 23)
        Me.ButOk.TabIndex = 132
        Me.ButOk.Text = "确定"
        Me.ButOk.UseVisualStyleBackColor = True
        '
        'Lblmessage
        '
        Me.Lblmessage.AutoSize = True
        Me.Lblmessage.Font = New System.Drawing.Font("幼圆", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Lblmessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Lblmessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Lblmessage.Location = New System.Drawing.Point(752, 433)
        Me.Lblmessage.Name = "Lblmessage"
        Me.Lblmessage.Size = New System.Drawing.Size(159, 19)
        Me.Lblmessage.TabIndex = 133
        Me.Lblmessage.Text = "等待标刻读取..."
        Me.Lblmessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CobLaserStyle
        '
        Me.CobLaserStyle.BackColor = System.Drawing.Color.White
        Me.CobLaserStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobLaserStyle.Enabled = False
        Me.CobLaserStyle.ForeColor = System.Drawing.Color.Black
        Me.CobLaserStyle.FormattingEnabled = True
        Me.CobLaserStyle.Items.AddRange(New Object() {"1-ASN17码转12码打标", "2-ASN17码打标"})
        Me.CobLaserStyle.Location = New System.Drawing.Point(821, 402)
        Me.CobLaserStyle.Name = "CobLaserStyle"
        Me.CobLaserStyle.Size = New System.Drawing.Size(165, 20)
        Me.CobLaserStyle.TabIndex = 134
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("幼圆", 10.0!)
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(748, 406)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 14)
        Me.Label13.TabIndex = 135
        Me.Label13.Text = "标刻方式："
        '
        'LblReadCount
        '
        Me.LblReadCount.AutoSize = True
        Me.LblReadCount.Font = New System.Drawing.Font("幼圆", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblReadCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.LblReadCount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblReadCount.Location = New System.Drawing.Point(495, 507)
        Me.LblReadCount.Name = "LblReadCount"
        Me.LblReadCount.Size = New System.Drawing.Size(95, 15)
        Me.LblReadCount.TabIndex = 136
        Me.LblReadCount.Text = "提示信息..."
        Me.LblReadCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmLaserPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1077, 547)
        Me.Controls.Add(Me.LblReadCount)
        Me.Controls.Add(Me.Lblmessage)
        Me.Controls.Add(Me.ButOk)
        Me.Controls.Add(Me.Butedit)
        Me.Controls.Add(Me.TxtBkcount)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.npStart)
        Me.Controls.Add(Me.npLine)
        Me.Controls.Add(Me.txtIP)
        Me.Controls.Add(Me.butSet)
        Me.Controls.Add(Me.txtAdd)
        Me.Controls.Add(Me.chkAuto)
        Me.Controls.Add(Me.lblresult)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CobLaserStyle)
        Me.Controls.Add(Me.Label13)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmLaserPrint"
        Me.Text = "镭雕打标作业"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.txtIP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.npLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.npStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtInput As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbl11 As System.Windows.Forms.Label
    Friend WithEvents lbl12 As System.Windows.Forms.Label
    Friend WithEvents lbl21 As System.Windows.Forms.Label
    Friend WithEvents lbl22 As System.Windows.Forms.Label
    Friend WithEvents lbl31 As System.Windows.Forms.Label
    Friend WithEvents lbl32 As System.Windows.Forms.Label
    Friend WithEvents lbl41 As System.Windows.Forms.Label
    Friend WithEvents lbl42 As System.Windows.Forms.Label
    Friend WithEvents lbl51 As System.Windows.Forms.Label
    Friend WithEvents lbl52 As System.Windows.Forms.Label
    Friend WithEvents lbl61 As System.Windows.Forms.Label
    Friend WithEvents lbl62 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsLable As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmdDel As System.Windows.Forms.Button
    Friend WithEvents lblresult As System.Windows.Forms.Label
    Friend WithEvents chkAuto As System.Windows.Forms.CheckBox
    Friend WithEvents txtAdd As System.Windows.Forms.TextBox
    Friend WithEvents butSet As System.Windows.Forms.Button
    Friend WithEvents txtIP As System.Windows.Forms.NumericUpDown
    Friend WithEvents npLine As System.Windows.Forms.NumericUpDown
    Friend WithEvents npStart As System.Windows.Forms.NumericUpDown
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtBkcount As System.Windows.Forms.TextBox
    Friend WithEvents Butedit As System.Windows.Forms.Button
    Friend WithEvents ButOk As System.Windows.Forms.Button
    Friend WithEvents Lblmessage As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CobLaserStyle As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblReadCount As System.Windows.Forms.Label
End Class
