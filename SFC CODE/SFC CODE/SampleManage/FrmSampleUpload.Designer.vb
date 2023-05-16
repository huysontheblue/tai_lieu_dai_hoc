<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSampleUpload
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSampleUpload))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolAdd = New System.Windows.Forms.ToolStripButton()
        Me.toolEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolEquConfirm = New System.Windows.Forms.ToolStripButton()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.btnSetFinish = New System.Windows.Forms.ToolStripButton()
        Me.ToolAddDutyName = New System.Windows.Forms.ToolStripButton()
        Me.ToolAllUpload = New System.Windows.Forms.ToolStripButton()
        Me.toolBack = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolRefresh = New System.Windows.Forms.ToolStripButton()
        Me.toolExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.SideBarPanelItem1 = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.sbPanelFinish = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.SideBarPanelItem2 = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SideBar1 = New DevComponents.DotNetBar.SideBar()
        Me.SideBarPanelYP = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.sbPanelRD = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.SideBarPanelEqu = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.SideBarPanelZEqu = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.SideBarPanelUserself = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBOMLook = New System.Windows.Forms.Button()
        Me.btnPackLook = New System.Windows.Forms.Button()
        Me.btnCBlueLook = New System.Windows.Forms.Button()
        Me.btnZEquLook = New System.Windows.Forms.Button()
        Me.btnCutLook = New System.Windows.Forms.Button()
        Me.btnRCardLook = New System.Windows.Forms.Button()
        Me.txtBOMTimes = New System.Windows.Forms.TextBox()
        Me.btnImportBOM = New System.Windows.Forms.Button()
        Me.btnUploadBOM = New System.Windows.Forms.Button()
        Me.txtBOMFilePath = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnBlueLook = New System.Windows.Forms.Button()
        Me.txtPackTimes = New System.Windows.Forms.TextBox()
        Me.btnImportPack = New System.Windows.Forms.Button()
        Me.btnUploadPack = New System.Windows.Forms.Button()
        Me.txtPackFilePath = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCBlueTimes = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnImportCBlue = New System.Windows.Forms.Button()
        Me.btnUploadCBlue = New System.Windows.Forms.Button()
        Me.txtCBlueFilePath = New System.Windows.Forms.TextBox()
        Me.txtZEquTimes = New System.Windows.Forms.TextBox()
        Me.btnImportZEqu = New System.Windows.Forms.Button()
        Me.btnUploadZEqu = New System.Windows.Forms.Button()
        Me.txtZEquFilePath = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCutTimes = New System.Windows.Forms.TextBox()
        Me.txtBlueTimes = New System.Windows.Forms.TextBox()
        Me.txtRCardTimes = New System.Windows.Forms.TextBox()
        Me.txtFormatDes = New System.Windows.Forms.TextBox()
        Me.txtPartNo = New System.Windows.Forms.TextBox()
        Me.lblFormatDes = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSampleNo = New System.Windows.Forms.TextBox()
        Me.lblPartNO = New System.Windows.Forms.Label()
        Me.btnImportCut = New System.Windows.Forms.Button()
        Me.btnImportRCard = New System.Windows.Forms.Button()
        Me.btnUploadCut = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnImportBlue = New System.Windows.Forms.Button()
        Me.txtCutFilePath = New System.Windows.Forms.TextBox()
        Me.btnUploadBlue = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnUploadRCard = New System.Windows.Forms.Button()
        Me.txtBlueFilePath = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRCardFilePath = New System.Windows.Forms.TextBox()
        Me.btnImportEqu = New System.Windows.Forms.Button()
        Me.txtEquFilePath = New System.Windows.Forms.TextBox()
        Me.btnUploadEqu = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TabSheet = New System.Windows.Forms.TabControl()
        Me.TabEqu = New System.Windows.Forms.TabPage()
        Me.dgvEqu = New System.Windows.Forms.DataGridView()
        Me.TabZEqu = New System.Windows.Forms.TabPage()
        Me.dgvZEqu = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SampleNo_ZEqu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NO_ZEqu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ZEquName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_ZEqu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsShare = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.SharePN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ZJDutyUserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanDueDate_ZEqu = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.RealDueDate_ZEqu = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.TabModel = New System.Windows.Forms.TabPage()
        Me.dgvModel = New System.Windows.Forms.DataGridView()
        Me.TabDocument = New System.Windows.Forms.TabPage()
        Me.dgvDocument = New System.Windows.Forms.DataGridView()
        Me.SideBarPanelItem3 = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.选择 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SampleNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EquName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_Equ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.YpsDutyUserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SjDutyUserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanDuedate = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.RealDuedate = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.CustID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SampleNo_Model = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NO_Model = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModelName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_Model = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsShare_Model = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.SharePN_Model = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RDDutyUserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanDueDate_Model = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.RealDueDate_Model = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.toolStrip1.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabSheet.SuspendLayout()
        Me.TabEqu.SuspendLayout()
        CType(Me.dgvEqu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabZEqu.SuspendLayout()
        CType(Me.dgvZEqu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabModel.SuspendLayout()
        CType(Me.dgvModel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabDocument.SuspendLayout()
        CType(Me.dgvDocument, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "请选择文件夹"
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(202, 127)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(0, 12)
        Me.lblMsg.TabIndex = 12
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAdd, Me.toolEdit, Me.ToolStripSeparator1, Me.ToolEquConfirm, Me.toolSave, Me.btnSetFinish, Me.ToolAddDutyName, Me.ToolAllUpload, Me.toolBack, Me.toolStripSeparator4, Me.toolQuery, Me.ToolRefresh, Me.toolExcel, Me.ToolStripSeparator2, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(2418, 25)
        Me.toolStrip1.TabIndex = 148
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolAdd
        '
        Me.toolAdd.Image = CType(resources.GetObject("toolAdd.Image"), System.Drawing.Image)
        Me.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAdd.Name = "toolAdd"
        Me.toolAdd.Size = New System.Drawing.Size(73, 22)
        Me.toolAdd.Tag = "NO"
        Me.toolAdd.Text = "新 增(&N)"
        '
        'toolEdit
        '
        Me.toolEdit.Image = CType(resources.GetObject("toolEdit.Image"), System.Drawing.Image)
        Me.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEdit.Name = "toolEdit"
        Me.toolEdit.Size = New System.Drawing.Size(73, 22)
        Me.toolEdit.Tag = "NO"
        Me.toolEdit.Text = "修 改(&E)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolEquConfirm
        '
        Me.ToolEquConfirm.Image = CType(resources.GetObject("ToolEquConfirm.Image"), System.Drawing.Image)
        Me.ToolEquConfirm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolEquConfirm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEquConfirm.Name = "ToolEquConfirm"
        Me.ToolEquConfirm.Size = New System.Drawing.Size(93, 22)
        Me.ToolEquConfirm.Tag = ""
        Me.ToolEquConfirm.Text = "勾选保存(&S)"
        '
        'toolSave
        '
        Me.toolSave.Image = CType(resources.GetObject("toolSave.Image"), System.Drawing.Image)
        Me.toolSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(75, 22)
        Me.toolSave.Tag = ""
        Me.toolSave.Text = "保 存(&S)"
        '
        'btnSetFinish
        '
        Me.btnSetFinish.Image = CType(resources.GetObject("btnSetFinish.Image"), System.Drawing.Image)
        Me.btnSetFinish.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnSetFinish.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSetFinish.Name = "btnSetFinish"
        Me.btnSetFinish.Size = New System.Drawing.Size(103, 22)
        Me.btnSetFinish.Tag = "审核"
        Me.btnSetFinish.Text = "转到完成区(&S)"
        '
        'ToolAddDutyName
        '
        Me.ToolAddDutyName.Image = CType(resources.GetObject("ToolAddDutyName.Image"), System.Drawing.Image)
        Me.ToolAddDutyName.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolAddDutyName.Name = "ToolAddDutyName"
        Me.ToolAddDutyName.Size = New System.Drawing.Size(103, 22)
        Me.ToolAddDutyName.Tag = "NO"
        Me.ToolAddDutyName.Text = "维护责任人(&A)"
        '
        'ToolAllUpload
        '
        Me.ToolAllUpload.ForeColor = System.Drawing.Color.Black
        Me.ToolAllUpload.Image = CType(resources.GetObject("ToolAllUpload.Image"), System.Drawing.Image)
        Me.ToolAllUpload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolAllUpload.Name = "ToolAllUpload"
        Me.ToolAllUpload.Size = New System.Drawing.Size(91, 22)
        Me.ToolAllUpload.Tag = "NO"
        Me.ToolAllUpload.Text = "一键上传(&C)"
        Me.ToolAllUpload.ToolTipText = "確 認"
        '
        'toolBack
        '
        Me.toolBack.Image = CType(resources.GetObject("toolBack.Image"), System.Drawing.Image)
        Me.toolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBack.Name = "toolBack"
        Me.toolBack.Size = New System.Drawing.Size(73, 22)
        Me.toolBack.Tag = ""
        Me.toolBack.Text = "返 回(&B)"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'toolQuery
        '
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(81, 22)
        Me.toolQuery.Text = "查  询(&F)"
        '
        'ToolRefresh
        '
        Me.ToolRefresh.Image = CType(resources.GetObject("ToolRefresh.Image"), System.Drawing.Image)
        Me.ToolRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolRefresh.Name = "ToolRefresh"
        Me.ToolRefresh.Size = New System.Drawing.Size(73, 22)
        Me.ToolRefresh.Text = "刷 新(&R)"
        Me.ToolRefresh.ToolTipText = "刷新"
        '
        'toolExcel
        '
        Me.toolExcel.Image = CType(resources.GetObject("toolExcel.Image"), System.Drawing.Image)
        Me.toolExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExcel.Name = "toolExcel"
        Me.toolExcel.Size = New System.Drawing.Size(85, 22)
        Me.toolExcel.Tag = "汇   出"
        Me.toolExcel.Text = "汇   出(&H)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(73, 22)
        Me.toolExit.Text = "退 出(&X)"
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "请选择文件夹"
        '
        'SideBarPanelItem1
        '
        Me.SideBarPanelItem1.FontBold = True
        Me.SideBarPanelItem1.Name = "SideBarPanelItem1"
        Me.SideBarPanelItem1.Text = "已生效"
        '
        'sbPanelFinish
        '
        Me.sbPanelFinish.FontBold = True
        Me.sbPanelFinish.Name = "sbPanelFinish"
        Me.sbPanelFinish.Text = "已生效"
        '
        'SideBarPanelItem2
        '
        Me.SideBarPanelItem2.FontBold = True
        Me.SideBarPanelItem2.Name = "SideBarPanelItem2"
        Me.SideBarPanelItem2.Text = "已生效"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.toolStrip1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer3.Size = New System.Drawing.Size(1287, 415)
        Me.SplitContainer3.SplitterDistance = 27
        Me.SplitContainer3.SplitterWidth = 1
        Me.SplitContainer3.TabIndex = 150
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.SplitContainer2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1287, 387)
        Me.Panel1.TabIndex = 150
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SideBar1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1287, 387)
        Me.SplitContainer2.SplitterDistance = 201
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 94
        '
        'SideBar1
        '
        Me.SideBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.SideBar1.BorderStyle = DevComponents.DotNetBar.eBorderType.None
        Me.SideBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideBar1.ExpandedPanel = Me.SideBarPanelYP
        Me.SideBar1.Location = New System.Drawing.Point(0, 0)
        Me.SideBar1.Name = "SideBar1"
        Me.SideBar1.Panels.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.sbPanelRD, Me.SideBarPanelEqu, Me.SideBarPanelZEqu, Me.SideBarPanelYP, Me.SideBarPanelUserself})
        Me.SideBar1.Size = New System.Drawing.Size(201, 387)
        Me.SideBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SideBar1.TabIndex = 65
        Me.SideBar1.Text = "SideBar1"
        '
        'SideBarPanelYP
        '
        Me.SideBarPanelYP.FontBold = True
        Me.SideBarPanelYP.Name = "SideBarPanelYP"
        Me.SideBarPanelYP.Text = "样品室"
        '
        'sbPanelRD
        '
        Me.sbPanelRD.FontBold = True
        Me.sbPanelRD.Name = "sbPanelRD"
        Me.sbPanelRD.Text = "研发"
        '
        'SideBarPanelEqu
        '
        Me.SideBarPanelEqu.FontBold = True
        Me.SideBarPanelEqu.Name = "SideBarPanelEqu"
        Me.SideBarPanelEqu.Text = "设备"
        '
        'SideBarPanelZEqu
        '
        Me.SideBarPanelZEqu.FontBold = True
        Me.SideBarPanelZEqu.Name = "SideBarPanelZEqu"
        Me.SideBarPanelZEqu.Text = "治具"
        '
        'SideBarPanelUserself
        '
        Me.SideBarPanelUserself.FontBold = True
        Me.SideBarPanelUserself.Name = "SideBarPanelUserself"
        Me.SideBarPanelUserself.Text = "个人已完成区"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabSheet)
        Me.SplitContainer1.Size = New System.Drawing.Size(1085, 387)
        Me.SplitContainer1.SplitterDistance = 161
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 93
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBOMLook)
        Me.GroupBox1.Controls.Add(Me.btnPackLook)
        Me.GroupBox1.Controls.Add(Me.btnCBlueLook)
        Me.GroupBox1.Controls.Add(Me.btnZEquLook)
        Me.GroupBox1.Controls.Add(Me.btnCutLook)
        Me.GroupBox1.Controls.Add(Me.btnRCardLook)
        Me.GroupBox1.Controls.Add(Me.txtBOMTimes)
        Me.GroupBox1.Controls.Add(Me.btnImportBOM)
        Me.GroupBox1.Controls.Add(Me.btnUploadBOM)
        Me.GroupBox1.Controls.Add(Me.txtBOMFilePath)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnBlueLook)
        Me.GroupBox1.Controls.Add(Me.txtPackTimes)
        Me.GroupBox1.Controls.Add(Me.btnImportPack)
        Me.GroupBox1.Controls.Add(Me.btnUploadPack)
        Me.GroupBox1.Controls.Add(Me.txtPackFilePath)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtCBlueTimes)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnImportCBlue)
        Me.GroupBox1.Controls.Add(Me.btnUploadCBlue)
        Me.GroupBox1.Controls.Add(Me.txtCBlueFilePath)
        Me.GroupBox1.Controls.Add(Me.txtZEquTimes)
        Me.GroupBox1.Controls.Add(Me.btnImportZEqu)
        Me.GroupBox1.Controls.Add(Me.btnUploadZEqu)
        Me.GroupBox1.Controls.Add(Me.txtZEquFilePath)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtCutTimes)
        Me.GroupBox1.Controls.Add(Me.txtBlueTimes)
        Me.GroupBox1.Controls.Add(Me.txtRCardTimes)
        Me.GroupBox1.Controls.Add(Me.txtFormatDes)
        Me.GroupBox1.Controls.Add(Me.txtPartNo)
        Me.GroupBox1.Controls.Add(Me.lblFormatDes)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtSampleNo)
        Me.GroupBox1.Controls.Add(Me.lblPartNO)
        Me.GroupBox1.Controls.Add(Me.btnImportCut)
        Me.GroupBox1.Controls.Add(Me.btnImportRCard)
        Me.GroupBox1.Controls.Add(Me.btnUploadCut)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnImportBlue)
        Me.GroupBox1.Controls.Add(Me.txtCutFilePath)
        Me.GroupBox1.Controls.Add(Me.btnUploadBlue)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnUploadRCard)
        Me.GroupBox1.Controls.Add(Me.txtBlueFilePath)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtRCardFilePath)
        Me.GroupBox1.Controls.Add(Me.btnImportEqu)
        Me.GroupBox1.Controls.Add(Me.txtEquFilePath)
        Me.GroupBox1.Controls.Add(Me.btnUploadEqu)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1078, 156)
        Me.GroupBox1.TabIndex = 106
        Me.GroupBox1.TabStop = False
        '
        'btnBOMLook
        '
        Me.btnBOMLook.Location = New System.Drawing.Point(784, 100)
        Me.btnBOMLook.Name = "btnBOMLook"
        Me.btnBOMLook.Size = New System.Drawing.Size(47, 23)
        Me.btnBOMLook.TabIndex = 140
        Me.btnBOMLook.Text = "预览"
        Me.btnBOMLook.UseVisualStyleBackColor = True
        '
        'btnPackLook
        '
        Me.btnPackLook.Location = New System.Drawing.Point(353, 97)
        Me.btnPackLook.Name = "btnPackLook"
        Me.btnPackLook.Size = New System.Drawing.Size(47, 23)
        Me.btnPackLook.TabIndex = 139
        Me.btnPackLook.Text = "预览"
        Me.btnPackLook.UseVisualStyleBackColor = True
        '
        'btnCBlueLook
        '
        Me.btnCBlueLook.Location = New System.Drawing.Point(786, 72)
        Me.btnCBlueLook.Name = "btnCBlueLook"
        Me.btnCBlueLook.Size = New System.Drawing.Size(47, 23)
        Me.btnCBlueLook.TabIndex = 138
        Me.btnCBlueLook.Text = "预览"
        Me.btnCBlueLook.UseVisualStyleBackColor = True
        '
        'btnZEquLook
        '
        Me.btnZEquLook.Location = New System.Drawing.Point(353, 71)
        Me.btnZEquLook.Name = "btnZEquLook"
        Me.btnZEquLook.Size = New System.Drawing.Size(47, 23)
        Me.btnZEquLook.TabIndex = 137
        Me.btnZEquLook.Text = "预览"
        Me.btnZEquLook.UseVisualStyleBackColor = True
        '
        'btnCutLook
        '
        Me.btnCutLook.Location = New System.Drawing.Point(782, 42)
        Me.btnCutLook.Name = "btnCutLook"
        Me.btnCutLook.Size = New System.Drawing.Size(47, 23)
        Me.btnCutLook.TabIndex = 136
        Me.btnCutLook.Text = "预览"
        Me.btnCutLook.UseVisualStyleBackColor = True
        '
        'btnRCardLook
        '
        Me.btnRCardLook.Location = New System.Drawing.Point(350, 41)
        Me.btnRCardLook.Name = "btnRCardLook"
        Me.btnRCardLook.Size = New System.Drawing.Size(47, 23)
        Me.btnRCardLook.TabIndex = 135
        Me.btnRCardLook.Text = "预览"
        Me.btnRCardLook.UseVisualStyleBackColor = True
        '
        'txtBOMTimes
        '
        Me.txtBOMTimes.Location = New System.Drawing.Point(695, 101)
        Me.txtBOMTimes.Name = "txtBOMTimes"
        Me.txtBOMTimes.ReadOnly = True
        Me.txtBOMTimes.Size = New System.Drawing.Size(24, 21)
        Me.txtBOMTimes.TabIndex = 134
        '
        'btnImportBOM
        '
        Me.btnImportBOM.Location = New System.Drawing.Point(840, 101)
        Me.btnImportBOM.Name = "btnImportBOM"
        Me.btnImportBOM.Size = New System.Drawing.Size(53, 23)
        Me.btnImportBOM.TabIndex = 133
        Me.btnImportBOM.Text = "上传"
        Me.btnImportBOM.UseVisualStyleBackColor = True
        '
        'btnUploadBOM
        '
        Me.btnUploadBOM.Location = New System.Drawing.Point(723, 101)
        Me.btnUploadBOM.Name = "btnUploadBOM"
        Me.btnUploadBOM.Size = New System.Drawing.Size(53, 23)
        Me.btnUploadBOM.TabIndex = 132
        Me.btnUploadBOM.Text = "浏览"
        Me.btnUploadBOM.UseVisualStyleBackColor = True
        '
        'txtBOMFilePath
        '
        Me.txtBOMFilePath.Location = New System.Drawing.Point(516, 102)
        Me.txtBOMFilePath.Name = "txtBOMFilePath"
        Me.txtBOMFilePath.Size = New System.Drawing.Size(178, 21)
        Me.txtBOMFilePath.TabIndex = 131
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(477, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 12)
        Me.Label8.TabIndex = 130
        Me.Label8.Text = "BOM："
        '
        'btnBlueLook
        '
        Me.btnBlueLook.Location = New System.Drawing.Point(783, 10)
        Me.btnBlueLook.Name = "btnBlueLook"
        Me.btnBlueLook.Size = New System.Drawing.Size(47, 23)
        Me.btnBlueLook.TabIndex = 129
        Me.btnBlueLook.Text = "预览"
        Me.btnBlueLook.UseVisualStyleBackColor = True
        '
        'txtPackTimes
        '
        Me.txtPackTimes.Location = New System.Drawing.Point(266, 99)
        Me.txtPackTimes.Name = "txtPackTimes"
        Me.txtPackTimes.ReadOnly = True
        Me.txtPackTimes.Size = New System.Drawing.Size(24, 21)
        Me.txtPackTimes.TabIndex = 128
        '
        'btnImportPack
        '
        Me.btnImportPack.Location = New System.Drawing.Point(406, 98)
        Me.btnImportPack.Name = "btnImportPack"
        Me.btnImportPack.Size = New System.Drawing.Size(53, 23)
        Me.btnImportPack.TabIndex = 127
        Me.btnImportPack.Text = "上传"
        Me.btnImportPack.UseVisualStyleBackColor = True
        '
        'btnUploadPack
        '
        Me.btnUploadPack.Location = New System.Drawing.Point(296, 98)
        Me.btnUploadPack.Name = "btnUploadPack"
        Me.btnUploadPack.Size = New System.Drawing.Size(53, 23)
        Me.btnUploadPack.TabIndex = 126
        Me.btnUploadPack.Text = "浏览"
        Me.btnUploadPack.UseVisualStyleBackColor = True
        '
        'txtPackFilePath
        '
        Me.txtPackFilePath.Location = New System.Drawing.Point(80, 98)
        Me.txtPackFilePath.Name = "txtPackFilePath"
        Me.txtPackFilePath.Size = New System.Drawing.Size(180, 21)
        Me.txtPackFilePath.TabIndex = 125
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 12)
        Me.Label7.TabIndex = 124
        Me.Label7.Text = "包规："
        '
        'txtCBlueTimes
        '
        Me.txtCBlueTimes.Location = New System.Drawing.Point(695, 72)
        Me.txtCBlueTimes.Name = "txtCBlueTimes"
        Me.txtCBlueTimes.ReadOnly = True
        Me.txtCBlueTimes.Size = New System.Drawing.Size(24, 21)
        Me.txtCBlueTimes.TabIndex = 123
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(457, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 119
        Me.Label6.Text = "客户蓝图:"
        '
        'btnImportCBlue
        '
        Me.btnImportCBlue.Location = New System.Drawing.Point(840, 72)
        Me.btnImportCBlue.Name = "btnImportCBlue"
        Me.btnImportCBlue.Size = New System.Drawing.Size(53, 23)
        Me.btnImportCBlue.TabIndex = 122
        Me.btnImportCBlue.Text = "上传"
        Me.btnImportCBlue.UseVisualStyleBackColor = True
        '
        'btnUploadCBlue
        '
        Me.btnUploadCBlue.Location = New System.Drawing.Point(723, 72)
        Me.btnUploadCBlue.Name = "btnUploadCBlue"
        Me.btnUploadCBlue.Size = New System.Drawing.Size(53, 23)
        Me.btnUploadCBlue.TabIndex = 121
        Me.btnUploadCBlue.Text = "浏览"
        Me.btnUploadCBlue.UseVisualStyleBackColor = True
        '
        'txtCBlueFilePath
        '
        Me.txtCBlueFilePath.Location = New System.Drawing.Point(516, 72)
        Me.txtCBlueFilePath.Name = "txtCBlueFilePath"
        Me.txtCBlueFilePath.Size = New System.Drawing.Size(178, 21)
        Me.txtCBlueFilePath.TabIndex = 120
        '
        'txtZEquTimes
        '
        Me.txtZEquTimes.Location = New System.Drawing.Point(266, 72)
        Me.txtZEquTimes.Name = "txtZEquTimes"
        Me.txtZEquTimes.ReadOnly = True
        Me.txtZEquTimes.Size = New System.Drawing.Size(24, 21)
        Me.txtZEquTimes.TabIndex = 118
        '
        'btnImportZEqu
        '
        Me.btnImportZEqu.Location = New System.Drawing.Point(401, 71)
        Me.btnImportZEqu.Name = "btnImportZEqu"
        Me.btnImportZEqu.Size = New System.Drawing.Size(53, 23)
        Me.btnImportZEqu.TabIndex = 117
        Me.btnImportZEqu.Text = "上传"
        Me.btnImportZEqu.UseVisualStyleBackColor = True
        '
        'btnUploadZEqu
        '
        Me.btnUploadZEqu.Location = New System.Drawing.Point(296, 71)
        Me.btnUploadZEqu.Name = "btnUploadZEqu"
        Me.btnUploadZEqu.Size = New System.Drawing.Size(53, 23)
        Me.btnUploadZEqu.TabIndex = 116
        Me.btnUploadZEqu.Text = "浏览"
        Me.btnUploadZEqu.UseVisualStyleBackColor = True
        '
        'txtZEquFilePath
        '
        Me.txtZEquFilePath.Location = New System.Drawing.Point(80, 70)
        Me.txtZEquFilePath.Name = "txtZEquFilePath"
        Me.txtZEquFilePath.Size = New System.Drawing.Size(180, 21)
        Me.txtZEquFilePath.TabIndex = 115
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 12)
        Me.Label5.TabIndex = 114
        Me.Label5.Text = "治具开立资料:"
        '
        'txtCutTimes
        '
        Me.txtCutTimes.Location = New System.Drawing.Point(695, 43)
        Me.txtCutTimes.Name = "txtCutTimes"
        Me.txtCutTimes.ReadOnly = True
        Me.txtCutTimes.Size = New System.Drawing.Size(24, 21)
        Me.txtCutTimes.TabIndex = 113
        '
        'txtBlueTimes
        '
        Me.txtBlueTimes.Location = New System.Drawing.Point(695, 10)
        Me.txtBlueTimes.Name = "txtBlueTimes"
        Me.txtBlueTimes.ReadOnly = True
        Me.txtBlueTimes.Size = New System.Drawing.Size(24, 21)
        Me.txtBlueTimes.TabIndex = 112
        '
        'txtRCardTimes
        '
        Me.txtRCardTimes.Location = New System.Drawing.Point(266, 43)
        Me.txtRCardTimes.Name = "txtRCardTimes"
        Me.txtRCardTimes.ReadOnly = True
        Me.txtRCardTimes.Size = New System.Drawing.Size(24, 21)
        Me.txtRCardTimes.TabIndex = 111
        '
        'txtFormatDes
        '
        Me.txtFormatDes.Location = New System.Drawing.Point(850, 129)
        Me.txtFormatDes.Name = "txtFormatDes"
        Me.txtFormatDes.ReadOnly = True
        Me.txtFormatDes.Size = New System.Drawing.Size(148, 21)
        Me.txtFormatDes.TabIndex = 109
        '
        'txtPartNo
        '
        Me.txtPartNo.Location = New System.Drawing.Point(544, 128)
        Me.txtPartNo.Name = "txtPartNo"
        Me.txtPartNo.ReadOnly = True
        Me.txtPartNo.Size = New System.Drawing.Size(150, 21)
        Me.txtPartNo.TabIndex = 108
        '
        'lblFormatDes
        '
        Me.lblFormatDes.AutoSize = True
        Me.lblFormatDes.ForeColor = System.Drawing.Color.Red
        Me.lblFormatDes.Location = New System.Drawing.Point(761, 134)
        Me.lblFormatDes.Name = "lblFormatDes"
        Me.lblFormatDes.Size = New System.Drawing.Size(83, 12)
        Me.lblFormatDes.TabIndex = 107
        Me.lblFormatDes.Text = "样品规格描述:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "样品单号:"
        '
        'txtSampleNo
        '
        Me.txtSampleNo.Location = New System.Drawing.Point(80, 13)
        Me.txtSampleNo.Name = "txtSampleNo"
        Me.txtSampleNo.Size = New System.Drawing.Size(210, 21)
        Me.txtSampleNo.TabIndex = 92
        '
        'lblPartNO
        '
        Me.lblPartNO.AutoSize = True
        Me.lblPartNO.ForeColor = System.Drawing.Color.Red
        Me.lblPartNO.Location = New System.Drawing.Point(477, 134)
        Me.lblPartNO.Name = "lblPartNO"
        Me.lblPartNO.Size = New System.Drawing.Size(59, 12)
        Me.lblPartNO.TabIndex = 105
        Me.lblPartNO.Text = "产品料号:"
        '
        'btnImportCut
        '
        Me.btnImportCut.Location = New System.Drawing.Point(836, 40)
        Me.btnImportCut.Name = "btnImportCut"
        Me.btnImportCut.Size = New System.Drawing.Size(53, 23)
        Me.btnImportCut.TabIndex = 100
        Me.btnImportCut.Text = "上传"
        Me.btnImportCut.UseVisualStyleBackColor = True
        '
        'btnImportRCard
        '
        Me.btnImportRCard.Location = New System.Drawing.Point(399, 41)
        Me.btnImportRCard.Name = "btnImportRCard"
        Me.btnImportRCard.Size = New System.Drawing.Size(53, 23)
        Me.btnImportRCard.TabIndex = 104
        Me.btnImportRCard.Text = "上传"
        Me.btnImportRCard.UseVisualStyleBackColor = True
        '
        'btnUploadCut
        '
        Me.btnUploadCut.Location = New System.Drawing.Point(723, 42)
        Me.btnUploadCut.Name = "btnUploadCut"
        Me.btnUploadCut.Size = New System.Drawing.Size(53, 23)
        Me.btnUploadCut.TabIndex = 99
        Me.btnUploadCut.Text = "浏览"
        Me.btnUploadCut.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(474, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "蓝图:"
        '
        'btnImportBlue
        '
        Me.btnImportBlue.Location = New System.Drawing.Point(836, 10)
        Me.btnImportBlue.Name = "btnImportBlue"
        Me.btnImportBlue.Size = New System.Drawing.Size(53, 23)
        Me.btnImportBlue.TabIndex = 96
        Me.btnImportBlue.Text = "上传"
        Me.btnImportBlue.UseVisualStyleBackColor = True
        '
        'txtCutFilePath
        '
        Me.txtCutFilePath.Location = New System.Drawing.Point(516, 43)
        Me.txtCutFilePath.Name = "txtCutFilePath"
        Me.txtCutFilePath.Size = New System.Drawing.Size(178, 21)
        Me.txtCutFilePath.TabIndex = 97
        '
        'btnUploadBlue
        '
        Me.btnUploadBlue.Location = New System.Drawing.Point(723, 10)
        Me.btnUploadBlue.Name = "btnUploadBlue"
        Me.btnUploadBlue.Size = New System.Drawing.Size(53, 23)
        Me.btnUploadBlue.TabIndex = 95
        Me.btnUploadBlue.Text = "浏览"
        Me.btnUploadBlue.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(468, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 12)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "裁线卡:"
        '
        'btnUploadRCard
        '
        Me.btnUploadRCard.Location = New System.Drawing.Point(296, 41)
        Me.btnUploadRCard.Name = "btnUploadRCard"
        Me.btnUploadRCard.Size = New System.Drawing.Size(53, 23)
        Me.btnUploadRCard.TabIndex = 103
        Me.btnUploadRCard.Text = "浏览"
        Me.btnUploadRCard.UseVisualStyleBackColor = True
        '
        'txtBlueFilePath
        '
        Me.txtBlueFilePath.Location = New System.Drawing.Point(516, 10)
        Me.txtBlueFilePath.Name = "txtBlueFilePath"
        Me.txtBlueFilePath.Size = New System.Drawing.Size(178, 21)
        Me.txtBlueFilePath.TabIndex = 94
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(14, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 12)
        Me.Label4.TabIndex = 101
        Me.Label4.Text = "流程卡:"
        '
        'txtRCardFilePath
        '
        Me.txtRCardFilePath.Location = New System.Drawing.Point(80, 43)
        Me.txtRCardFilePath.Name = "txtRCardFilePath"
        Me.txtRCardFilePath.Size = New System.Drawing.Size(180, 21)
        Me.txtRCardFilePath.TabIndex = 102
        '
        'btnImportEqu
        '
        Me.btnImportEqu.Location = New System.Drawing.Point(365, 129)
        Me.btnImportEqu.Name = "btnImportEqu"
        Me.btnImportEqu.Size = New System.Drawing.Size(53, 23)
        Me.btnImportEqu.TabIndex = 19
        Me.btnImportEqu.Text = "导入"
        Me.btnImportEqu.UseVisualStyleBackColor = True
        '
        'txtEquFilePath
        '
        Me.txtEquFilePath.Location = New System.Drawing.Point(80, 131)
        Me.txtEquFilePath.Name = "txtEquFilePath"
        Me.txtEquFilePath.Size = New System.Drawing.Size(210, 21)
        Me.txtEquFilePath.TabIndex = 89
        '
        'btnUploadEqu
        '
        Me.btnUploadEqu.Location = New System.Drawing.Point(306, 130)
        Me.btnUploadEqu.Name = "btnUploadEqu"
        Me.btnUploadEqu.Size = New System.Drawing.Size(53, 23)
        Me.btnUploadEqu.TabIndex = 91
        Me.btnUploadEqu.Text = "浏览"
        Me.btnUploadEqu.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(23, 134)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 12)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "清单:"
        '
        'TabSheet
        '
        Me.TabSheet.Controls.Add(Me.TabEqu)
        Me.TabSheet.Controls.Add(Me.TabZEqu)
        Me.TabSheet.Controls.Add(Me.TabModel)
        Me.TabSheet.Controls.Add(Me.TabDocument)
        Me.TabSheet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabSheet.Location = New System.Drawing.Point(0, 0)
        Me.TabSheet.Name = "TabSheet"
        Me.TabSheet.SelectedIndex = 0
        Me.TabSheet.Size = New System.Drawing.Size(1085, 225)
        Me.TabSheet.TabIndex = 0
        '
        'TabEqu
        '
        Me.TabEqu.Controls.Add(Me.dgvEqu)
        Me.TabEqu.Location = New System.Drawing.Point(4, 22)
        Me.TabEqu.Name = "TabEqu"
        Me.TabEqu.Padding = New System.Windows.Forms.Padding(3)
        Me.TabEqu.Size = New System.Drawing.Size(1077, 199)
        Me.TabEqu.TabIndex = 0
        Me.TabEqu.Text = "设备清单"
        Me.TabEqu.UseVisualStyleBackColor = True
        '
        'dgvEqu
        '
        Me.dgvEqu.AllowUserToAddRows = False
        Me.dgvEqu.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvEqu.ColumnHeadersHeight = 32
        Me.dgvEqu.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.选择, Me.SampleNo, Me.No, Me.EquName, Me.Qty_Equ, Me.YpsDutyUserName, Me.SjDutyUserName, Me.PlanDuedate, Me.RealDuedate, Me.CustID})
        Me.dgvEqu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEqu.Location = New System.Drawing.Point(3, 3)
        Me.dgvEqu.Name = "dgvEqu"
        Me.dgvEqu.RowHeadersVisible = False
        Me.dgvEqu.RowTemplate.Height = 23
        Me.dgvEqu.Size = New System.Drawing.Size(1071, 193)
        Me.dgvEqu.TabIndex = 0
        '
        'TabZEqu
        '
        Me.TabZEqu.Controls.Add(Me.dgvZEqu)
        Me.TabZEqu.Location = New System.Drawing.Point(4, 22)
        Me.TabZEqu.Name = "TabZEqu"
        Me.TabZEqu.Padding = New System.Windows.Forms.Padding(3)
        Me.TabZEqu.Size = New System.Drawing.Size(1077, 199)
        Me.TabZEqu.TabIndex = 2
        Me.TabZEqu.Text = "治工具清单"
        Me.TabZEqu.UseVisualStyleBackColor = True
        '
        'dgvZEqu
        '
        Me.dgvZEqu.AllowUserToAddRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvZEqu.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvZEqu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvZEqu.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SampleNo_ZEqu, Me.NO_ZEqu, Me.ZEquName, Me.Qty_ZEqu, Me.IsShare, Me.SharePN, Me.ZJDutyUserName, Me.PlanDueDate_ZEqu, Me.RealDueDate_ZEqu})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvZEqu.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvZEqu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvZEqu.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvZEqu.EnableHeadersVisualStyles = False
        Me.dgvZEqu.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvZEqu.Location = New System.Drawing.Point(3, 3)
        Me.dgvZEqu.Name = "dgvZEqu"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvZEqu.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvZEqu.RowHeadersVisible = False
        Me.dgvZEqu.RowTemplate.Height = 23
        Me.dgvZEqu.Size = New System.Drawing.Size(1071, 193)
        Me.dgvZEqu.TabIndex = 0
        '
        'SampleNo_ZEqu
        '
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Info
        Me.SampleNo_ZEqu.DefaultCellStyle = DataGridViewCellStyle5
        Me.SampleNo_ZEqu.HeaderText = "样品单号"
        Me.SampleNo_ZEqu.Name = "SampleNo_ZEqu"
        '
        'NO_ZEqu
        '
        Me.NO_ZEqu.HeaderText = "NO"
        Me.NO_ZEqu.Name = "NO_ZEqu"
        '
        'ZEquName
        '
        Me.ZEquName.HeaderText = "治工具名称"
        Me.ZEquName.Name = "ZEquName"
        '
        'Qty_ZEqu
        '
        Me.Qty_ZEqu.HeaderText = "申请数量"
        Me.Qty_ZEqu.Name = "Qty_ZEqu"
        '
        'IsShare
        '
        Me.IsShare.HeaderText = "是否共用"
        Me.IsShare.Name = "IsShare"
        '
        'SharePN
        '
        Me.SharePN.HeaderText = "共用备注料号"
        Me.SharePN.Name = "SharePN"
        Me.SharePN.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SharePN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ZJDutyUserName
        '
        Me.ZJDutyUserName.HeaderText = "治具责任人"
        Me.ZJDutyUserName.Name = "ZJDutyUserName"
        '
        'PlanDueDate_ZEqu
        '
        '
        '
        '
        Me.PlanDueDate_ZEqu.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.PlanDueDate_ZEqu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Info
        Me.PlanDueDate_ZEqu.DefaultCellStyle = DataGridViewCellStyle6
        Me.PlanDueDate_ZEqu.HeaderText = "预计交期"
        Me.PlanDueDate_ZEqu.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.PlanDueDate_ZEqu.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.PlanDueDate_ZEqu.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanDueDate_ZEqu.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.PlanDueDate_ZEqu.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanDueDate_ZEqu.MonthCalendar.DisplayMonth = New Date(2016, 11, 1, 0, 0, 0, 0)
        Me.PlanDueDate_ZEqu.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.PlanDueDate_ZEqu.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.PlanDueDate_ZEqu.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanDueDate_ZEqu.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.PlanDueDate_ZEqu.Name = "PlanDueDate_ZEqu"
        Me.PlanDueDate_ZEqu.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'RealDueDate_ZEqu
        '
        '
        '
        '
        Me.RealDueDate_ZEqu.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.RealDueDate_ZEqu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Info
        Me.RealDueDate_ZEqu.DefaultCellStyle = DataGridViewCellStyle7
        Me.RealDueDate_ZEqu.HeaderText = "实际交期"
        Me.RealDueDate_ZEqu.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.RealDueDate_ZEqu.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.RealDueDate_ZEqu.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RealDueDate_ZEqu.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.RealDueDate_ZEqu.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RealDueDate_ZEqu.MonthCalendar.DisplayMonth = New Date(2016, 11, 1, 0, 0, 0, 0)
        Me.RealDueDate_ZEqu.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.RealDueDate_ZEqu.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.RealDueDate_ZEqu.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RealDueDate_ZEqu.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.RealDueDate_ZEqu.Name = "RealDueDate_ZEqu"
        Me.RealDueDate_ZEqu.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'TabModel
        '
        Me.TabModel.Controls.Add(Me.dgvModel)
        Me.TabModel.Location = New System.Drawing.Point(4, 22)
        Me.TabModel.Name = "TabModel"
        Me.TabModel.Size = New System.Drawing.Size(1077, 199)
        Me.TabModel.TabIndex = 3
        Me.TabModel.Text = "模具清单"
        Me.TabModel.UseVisualStyleBackColor = True
        '
        'dgvModel
        '
        Me.dgvModel.AllowUserToAddRows = False
        Me.dgvModel.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvModel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvModel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SampleNo_Model, Me.NO_Model, Me.ModelName, Me.Qty_Model, Me.IsShare_Model, Me.SharePN_Model, Me.RDDutyUserName, Me.PlanDueDate_Model, Me.RealDueDate_Model})
        Me.dgvModel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvModel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvModel.Location = New System.Drawing.Point(0, 0)
        Me.dgvModel.Name = "dgvModel"
        Me.dgvModel.RowHeadersVisible = False
        Me.dgvModel.RowTemplate.Height = 23
        Me.dgvModel.Size = New System.Drawing.Size(1077, 199)
        Me.dgvModel.TabIndex = 0
        '
        'TabDocument
        '
        Me.TabDocument.Controls.Add(Me.dgvDocument)
        Me.TabDocument.Location = New System.Drawing.Point(4, 22)
        Me.TabDocument.Name = "TabDocument"
        Me.TabDocument.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDocument.Size = New System.Drawing.Size(1077, 199)
        Me.TabDocument.TabIndex = 4
        Me.TabDocument.Text = "文档信息"
        Me.TabDocument.UseVisualStyleBackColor = True
        '
        'dgvDocument
        '
        Me.dgvDocument.AllowUserToAddRows = False
        Me.dgvDocument.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvDocument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDocument.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dgvDocument.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDocument.Location = New System.Drawing.Point(3, 3)
        Me.dgvDocument.Name = "dgvDocument"
        Me.dgvDocument.RowHeadersVisible = False
        Me.dgvDocument.RowTemplate.Height = 23
        Me.dgvDocument.Size = New System.Drawing.Size(1071, 193)
        Me.dgvDocument.TabIndex = 0
        '
        'SideBarPanelItem3
        '
        Me.SideBarPanelItem3.FontBold = True
        Me.SideBarPanelItem3.Name = "SideBarPanelItem3"
        Me.SideBarPanelItem3.Text = "已生效"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "make_tree.png")
        Me.ImageList1.Images.SetKeyName(1, "sign_tree.png")
        Me.ImageList1.Images.SetKeyName(2, "dept_tree.png")
        Me.ImageList1.Images.SetKeyName(3, "approval_tree.png")
        Me.ImageList1.Images.SetKeyName(4, "ok.png")
        '
        '选择
        '
        Me.选择.DataPropertyName = "ISEXIST"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.NullValue = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Info
        Me.选择.DefaultCellStyle = DataGridViewCellStyle1
        Me.选择.FalseValue = "0"
        Me.选择.HeaderText = "选择"
        Me.选择.Name = "选择"
        Me.选择.TrueValue = "1"
        Me.选择.Width = 80
        '
        'SampleNo
        '
        Me.SampleNo.DataPropertyName = "SampleNo"
        Me.SampleNo.HeaderText = "样品单号"
        Me.SampleNo.Name = "SampleNo"
        Me.SampleNo.ReadOnly = True
        '
        'No
        '
        Me.No.DataPropertyName = "No"
        Me.No.HeaderText = "NO"
        Me.No.Name = "No"
        Me.No.ReadOnly = True
        '
        'EquName
        '
        Me.EquName.DataPropertyName = "EquName"
        Me.EquName.HeaderText = "设备名称"
        Me.EquName.Name = "EquName"
        '
        'Qty_Equ
        '
        Me.Qty_Equ.HeaderText = "申请数量"
        Me.Qty_Equ.Name = "Qty_Equ"
        '
        'YpsDutyUserName
        '
        Me.YpsDutyUserName.DataPropertyName = "YPSDutyUserName"
        Me.YpsDutyUserName.HeaderText = "样品室责任人"
        Me.YpsDutyUserName.Name = "YpsDutyUserName"
        '
        'SjDutyUserName
        '
        Me.SjDutyUserName.HeaderText = "生技责任人"
        Me.SjDutyUserName.Name = "SjDutyUserName"
        '
        'PlanDuedate
        '
        '
        '
        '
        Me.PlanDuedate.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.PlanDuedate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanDuedate.DataPropertyName = "PlanDuedate"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Info
        Me.PlanDuedate.DefaultCellStyle = DataGridViewCellStyle2
        Me.PlanDuedate.HeaderText = "预计交期"
        Me.PlanDuedate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.PlanDuedate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.PlanDuedate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanDuedate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.PlanDuedate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanDuedate.MonthCalendar.DisplayMonth = New Date(2016, 11, 1, 0, 0, 0, 0)
        Me.PlanDuedate.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.PlanDuedate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.PlanDuedate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanDuedate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.PlanDuedate.Name = "PlanDuedate"
        Me.PlanDuedate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'RealDuedate
        '
        '
        '
        '
        Me.RealDuedate.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.RealDuedate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RealDuedate.DataPropertyName = "RealDuedate"
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Info
        Me.RealDuedate.DefaultCellStyle = DataGridViewCellStyle3
        Me.RealDuedate.HeaderText = "实际交期"
        Me.RealDuedate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.RealDuedate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.RealDuedate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RealDuedate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.RealDuedate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RealDuedate.MonthCalendar.DisplayMonth = New Date(2016, 11, 1, 0, 0, 0, 0)
        Me.RealDuedate.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.RealDuedate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.RealDuedate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RealDuedate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.RealDuedate.Name = "RealDuedate"
        Me.RealDuedate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'CustID
        '
        Me.CustID.DataPropertyName = "CustID"
        Me.CustID.HeaderText = "CustID"
        Me.CustID.Name = "CustID"
        Me.CustID.Visible = False
        '
        'SampleNo_Model
        '
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Info
        Me.SampleNo_Model.DefaultCellStyle = DataGridViewCellStyle10
        Me.SampleNo_Model.HeaderText = "样品单号"
        Me.SampleNo_Model.Name = "SampleNo_Model"
        Me.SampleNo_Model.ReadOnly = True
        '
        'NO_Model
        '
        Me.NO_Model.HeaderText = "NO"
        Me.NO_Model.Name = "NO_Model"
        Me.NO_Model.ReadOnly = True
        '
        'ModelName
        '
        Me.ModelName.HeaderText = "模具名称"
        Me.ModelName.Name = "ModelName"
        '
        'Qty_Model
        '
        Me.Qty_Model.HeaderText = "申请数量"
        Me.Qty_Model.Name = "Qty_Model"
        '
        'IsShare_Model
        '
        Me.IsShare_Model.HeaderText = "是否共用"
        Me.IsShare_Model.Name = "IsShare_Model"
        '
        'SharePN_Model
        '
        Me.SharePN_Model.HeaderText = "共用备注料号"
        Me.SharePN_Model.Name = "SharePN_Model"
        Me.SharePN_Model.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SharePN_Model.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'RDDutyUserName
        '
        Me.RDDutyUserName.HeaderText = "研发责任人"
        Me.RDDutyUserName.Name = "RDDutyUserName"
        '
        'PlanDueDate_Model
        '
        '
        '
        '
        Me.PlanDueDate_Model.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.PlanDueDate_Model.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Info
        Me.PlanDueDate_Model.DefaultCellStyle = DataGridViewCellStyle11
        Me.PlanDueDate_Model.HeaderText = "预计交期"
        Me.PlanDueDate_Model.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.PlanDueDate_Model.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.PlanDueDate_Model.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanDueDate_Model.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.PlanDueDate_Model.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanDueDate_Model.MonthCalendar.DisplayMonth = New Date(2016, 11, 1, 0, 0, 0, 0)
        Me.PlanDueDate_Model.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.PlanDueDate_Model.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.PlanDueDate_Model.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanDueDate_Model.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.PlanDueDate_Model.Name = "PlanDueDate_Model"
        Me.PlanDueDate_Model.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'RealDueDate_Model
        '
        '
        '
        '
        Me.RealDueDate_Model.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.RealDueDate_Model.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Info
        Me.RealDueDate_Model.DefaultCellStyle = DataGridViewCellStyle12
        Me.RealDueDate_Model.HeaderText = "实际交期"
        Me.RealDueDate_Model.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.RealDueDate_Model.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.RealDueDate_Model.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RealDueDate_Model.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.RealDueDate_Model.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RealDueDate_Model.MonthCalendar.DisplayMonth = New Date(2016, 11, 1, 0, 0, 0, 0)
        Me.RealDueDate_Model.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.RealDueDate_Model.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.RealDueDate_Model.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RealDueDate_Model.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.RealDueDate_Model.Name = "RealDueDate_Model"
        Me.RealDueDate_Model.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "SampleNo"
        Me.Column1.HeaderText = "样品单号"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Type"
        Me.Column2.HeaderText = "文件类型"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.ActiveLinkColor = System.Drawing.Color.Orange
        Me.Column3.DataPropertyName = "Path"
        Me.Column3.HeaderText = "文件路径"
        Me.Column3.Name = "Column3"
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'FrmSampleUpload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1287, 415)
        Me.Controls.Add(Me.SplitContainer3)
        Me.Controls.Add(Me.lblMsg)
        Me.Name = "FrmSampleUpload"
        Me.Text = "样品资料上传"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabSheet.ResumeLayout(False)
        Me.TabEqu.ResumeLayout(False)
        CType(Me.dgvEqu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabZEqu.ResumeLayout(False)
        CType(Me.dgvZEqu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabModel.ResumeLayout(False)
        CType(Me.dgvModel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabDocument.ResumeLayout(False)
        CType(Me.dgvDocument, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEdit As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolBack As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolRefresh As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolEquConfirm As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolAllUpload As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SideBarPanelItem1 As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents sbPanelFinish As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents SideBarPanelItem2 As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SideBar1 As DevComponents.DotNetBar.SideBar
    Friend WithEvents sbPanelRD As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCutTimes As System.Windows.Forms.TextBox
    Friend WithEvents txtBlueTimes As System.Windows.Forms.TextBox
    Friend WithEvents txtRCardTimes As System.Windows.Forms.TextBox
    Friend WithEvents txtFormatDes As System.Windows.Forms.TextBox
    Friend WithEvents txtPartNo As System.Windows.Forms.TextBox
    Friend WithEvents lblFormatDes As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSampleNo As System.Windows.Forms.TextBox
    Friend WithEvents lblPartNO As System.Windows.Forms.Label
    Friend WithEvents btnImportCut As System.Windows.Forms.Button
    Friend WithEvents btnImportRCard As System.Windows.Forms.Button
    Friend WithEvents btnUploadCut As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnImportBlue As System.Windows.Forms.Button
    Friend WithEvents txtCutFilePath As System.Windows.Forms.TextBox
    Friend WithEvents btnUploadBlue As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnUploadRCard As System.Windows.Forms.Button
    Friend WithEvents txtBlueFilePath As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRCardFilePath As System.Windows.Forms.TextBox
    Friend WithEvents btnImportEqu As System.Windows.Forms.Button
    Friend WithEvents txtEquFilePath As System.Windows.Forms.TextBox
    Friend WithEvents btnUploadEqu As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TabSheet As System.Windows.Forms.TabControl
    Friend WithEvents TabEqu As System.Windows.Forms.TabPage
    Friend WithEvents dgvEqu As System.Windows.Forms.DataGridView
    Friend WithEvents TabZEqu As System.Windows.Forms.TabPage
    Friend WithEvents dgvZEqu As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents SampleNo_ZEqu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NO_ZEqu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ZEquName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty_ZEqu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsShare As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SharePN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ZJDutyUserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanDueDate_ZEqu As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents RealDueDate_ZEqu As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents TabModel As System.Windows.Forms.TabPage
    Friend WithEvents dgvModel As System.Windows.Forms.DataGridView
    Friend WithEvents TabDocument As System.Windows.Forms.TabPage
    Friend WithEvents dgvDocument As System.Windows.Forms.DataGridView
    Friend WithEvents SideBarPanelItem3 As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents SideBarPanelEqu As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents SideBarPanelZEqu As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents SideBarPanelYP As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents btnImportZEqu As System.Windows.Forms.Button
    Friend WithEvents btnUploadZEqu As System.Windows.Forms.Button
    Friend WithEvents txtZEquFilePath As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtZEquTimes As System.Windows.Forms.TextBox
    Friend WithEvents txtPackTimes As System.Windows.Forms.TextBox
    Friend WithEvents btnImportPack As System.Windows.Forms.Button
    Friend WithEvents btnUploadPack As System.Windows.Forms.Button
    Friend WithEvents txtPackFilePath As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCBlueTimes As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnImportCBlue As System.Windows.Forms.Button
    Friend WithEvents btnUploadCBlue As System.Windows.Forms.Button
    Friend WithEvents txtCBlueFilePath As System.Windows.Forms.TextBox
    Friend WithEvents ToolAddDutyName As System.Windows.Forms.ToolStripButton
    Friend WithEvents SideBarPanelUserself As DevComponents.DotNetBar.SideBarPanelItem
    Private WithEvents btnSetFinish As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBlueLook As System.Windows.Forms.Button
    Friend WithEvents txtBOMTimes As System.Windows.Forms.TextBox
    Friend WithEvents btnImportBOM As System.Windows.Forms.Button
    Friend WithEvents btnUploadBOM As System.Windows.Forms.Button
    Friend WithEvents txtBOMFilePath As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnRCardLook As System.Windows.Forms.Button
    Friend WithEvents btnCutLook As System.Windows.Forms.Button
    Friend WithEvents btnZEquLook As System.Windows.Forms.Button
    Friend WithEvents btnPackLook As System.Windows.Forms.Button
    Friend WithEvents btnCBlueLook As System.Windows.Forms.Button
    Friend WithEvents btnBOMLook As System.Windows.Forms.Button
    Friend WithEvents 选择 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SampleNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EquName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty_Equ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YpsDutyUserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SjDutyUserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanDuedate As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents RealDuedate As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents CustID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SampleNo_Model As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NO_Model As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModelName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty_Model As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsShare_Model As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SharePN_Model As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RDDutyUserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanDueDate_Model As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents RealDueDate_Model As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewLinkColumn
End Class
