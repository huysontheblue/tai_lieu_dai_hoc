namespace SMTModule
{
    partial class FrmSteel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSteel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cobStatus = new System.Windows.Forms.ComboBox();
            this.LblMsg = new System.Windows.Forms.Label();
            this.txtSTENCIL_ID = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.dgvSteel = new System.Windows.Forms.DataGridView();
            this.SteelNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Intime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolEdit = new System.Windows.Forms.ToolStripButton();
            this.toolAbandon = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolQuery = new System.Windows.Forms.ToolStripButton();
            this.toolBack = new System.Windows.Forms.ToolStripButton();
            this.FileRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolImport = new System.Windows.Forms.ToolStripButton();
            this.btnPartEdit = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvPartList = new System.Windows.Forms.DataGridView();
            this.PartID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSteel)).BeginInit();
            this.statusStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartList)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.cobStatus);
            this.GroupBox1.Controls.Add(this.LblMsg);
            this.GroupBox1.Controls.Add(this.txtSTENCIL_ID);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(4, 27);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(860, 97);
            this.GroupBox1.TabIndex = 29;
            this.GroupBox1.TabStop = false;
            // 
            // cobStatus
            // 
            this.cobStatus.FormattingEnabled = true;
            this.cobStatus.Items.AddRange(new object[] {
            "I.在库",
            "P.领用",
            "O.在线",
            "D.下线",
            "C.清洗",
            "S.报废",
            "R.归还"});
            this.cobStatus.Location = new System.Drawing.Point(412, 23);
            this.cobStatus.Name = "cobStatus";
            this.cobStatus.Size = new System.Drawing.Size(121, 20);
            this.cobStatus.TabIndex = 118;
            // 
            // LblMsg
            // 
            this.LblMsg.AutoSize = true;
            this.LblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LblMsg.Location = new System.Drawing.Point(645, 23);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Size = new System.Drawing.Size(20, 17);
            this.LblMsg.TabIndex = 117;
            this.LblMsg.Text = "...";
            // 
            // txtSTENCIL_ID
            // 
            this.txtSTENCIL_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSTENCIL_ID.Location = new System.Drawing.Point(82, 23);
            this.txtSTENCIL_ID.MaxLength = 60;
            this.txtSTENCIL_ID.Name = "txtSTENCIL_ID";
            this.txtSTENCIL_ID.Size = new System.Drawing.Size(181, 21);
            this.txtSTENCIL_ID.TabIndex = 26;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(14, 27);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(65, 12);
            this.Label4.TabIndex = 25;
            this.Label4.Text = "钢网编号：";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(350, 27);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 12);
            this.Label1.TabIndex = 22;
            this.Label1.Text = "状态：";
            // 
            // dgvSteel
            // 
            this.dgvSteel.AllowUserToAddRows = false;
            this.dgvSteel.AllowUserToDeleteRows = false;
            this.dgvSteel.AllowUserToOrderColumns = true;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.dgvSteel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSteel.BackgroundColor = System.Drawing.Color.White;
            this.dgvSteel.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSteel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSteel.ColumnHeadersHeight = 30;
            this.dgvSteel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SteelNo,
            this.ProjectName,
            this.UserID,
            this.Intime});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSteel.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSteel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSteel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSteel.GridColor = System.Drawing.SystemColors.Control;
            this.dgvSteel.Location = new System.Drawing.Point(0, 0);
            this.dgvSteel.MultiSelect = false;
            this.dgvSteel.Name = "dgvSteel";
            this.dgvSteel.RowHeadersWidth = 30;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvSteel.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvSteel.RowTemplate.Height = 25;
            this.dgvSteel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSteel.ShowEditingIcon = false;
            this.dgvSteel.Size = new System.Drawing.Size(602, 271);
            this.dgvSteel.TabIndex = 30;
            this.dgvSteel.TabStop = false;
            this.dgvSteel.Click += new System.EventHandler(this.dgvSteel_Click);
            // 
            // SteelNo
            // 
            this.SteelNo.Frozen = true;
            this.SteelNo.HeaderText = "钢网编号";
            this.SteelNo.Name = "SteelNo";
            this.SteelNo.ReadOnly = true;
            this.SteelNo.Width = 80;
            // 
            // ProjectName
            // 
            this.ProjectName.HeaderText = "状态";
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.ReadOnly = true;
            // 
            // UserID
            // 
            this.UserID.HeaderText = "维护人员";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            // 
            // Intime
            // 
            this.Intime.HeaderText = "维护时间";
            this.Intime.Name = "Intime";
            this.Intime.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumn1
            // 
            this.DataGridViewTextBoxColumn1.HeaderText = "工站类别";
            this.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
            this.DataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumn2
            // 
            this.DataGridViewTextBoxColumn2.HeaderText = "工站编号";
            this.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
            this.DataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumn3
            // 
            this.DataGridViewTextBoxColumn3.HeaderText = "工站名称";
            this.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3";
            this.DataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumn4
            // 
            this.DataGridViewTextBoxColumn4.HeaderText = "工站描述";
            this.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4";
            this.DataGridViewTextBoxColumn4.ReadOnly = true;
            this.DataGridViewTextBoxColumn4.Width = 120;
            // 
            // DataGridViewTextBoxColumn5
            // 
            this.DataGridViewTextBoxColumn5.HeaderText = "有效否";
            this.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5";
            this.DataGridViewTextBoxColumn5.ReadOnly = true;
            this.DataGridViewTextBoxColumn5.Width = 80;
            // 
            // DataGridViewTextBoxColumn6
            // 
            this.DataGridViewTextBoxColumn6.HeaderText = "设置人员";
            this.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6";
            this.DataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumn7
            // 
            this.DataGridViewTextBoxColumn7.HeaderText = "设置时间";
            this.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7";
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(238)))), ((int)(((byte)(244)))));
            this.statusStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3});
            this.statusStrip2.Location = new System.Drawing.Point(0, 423);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(869, 22);
            this.statusStrip2.TabIndex = 27;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel1.Text = "记录笔数:";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(41)))), ((int)(((byte)(49)))));
            this.toolStripStatusLabel3.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(130)))), ((int)(((byte)(196)))));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(15, 17);
            this.toolStripStatusLabel3.Text = "0";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAdd,
            this.toolEdit,
            this.toolAbandon,
            this.ToolStripSeparator1,
            this.toolSave,
            this.toolQuery,
            this.toolBack,
            this.FileRefresh,
            this.toolStripSeparator4,
            this.toolImport,
            this.btnPartEdit,
            this.ToolStripSeparator2,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(880, 25);
            this.toolStrip1.TabIndex = 28;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolAdd
            // 
            this.toolAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolAdd.Image")));
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(73, 22);
            this.toolAdd.Tag = "NO";
            this.toolAdd.Text = "新 增(&N)";
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolEdit
            // 
            this.toolEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolEdit.Image")));
            this.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEdit.Name = "toolEdit";
            this.toolEdit.Size = new System.Drawing.Size(73, 22);
            this.toolEdit.Tag = "NO";
            this.toolEdit.Text = "修 改(&E)";
            // 
            // toolAbandon
            // 
            this.toolAbandon.Image = ((System.Drawing.Image)(resources.GetObject("toolAbandon.Image")));
            this.toolAbandon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAbandon.Name = "toolAbandon";
            this.toolAbandon.Size = new System.Drawing.Size(73, 22);
            this.toolAbandon.Tag = "NO";
            this.toolAbandon.Text = "作 废(&D)";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolSave
            // 
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(75, 22);
            this.toolSave.Tag = "";
            this.toolSave.Text = "保 存(&S)";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolQuery
            // 
            this.toolQuery.Image = ((System.Drawing.Image)(resources.GetObject("toolQuery.Image")));
            this.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolQuery.Name = "toolQuery";
            this.toolQuery.Size = new System.Drawing.Size(81, 22);
            this.toolQuery.Text = "查  询(&F)";
            this.toolQuery.Click += new System.EventHandler(this.toolQuery_Click);
            // 
            // toolBack
            // 
            this.toolBack.Image = ((System.Drawing.Image)(resources.GetObject("toolBack.Image")));
            this.toolBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBack.Name = "toolBack";
            this.toolBack.Size = new System.Drawing.Size(73, 22);
            this.toolBack.Tag = "";
            this.toolBack.Text = "返 回(&B)";
            this.toolBack.Click += new System.EventHandler(this.toolBack_Click);
            // 
            // FileRefresh
            // 
            this.FileRefresh.Image = ((System.Drawing.Image)(resources.GetObject("FileRefresh.Image")));
            this.FileRefresh.ImageTransparentColor = System.Drawing.Color.Black;
            this.FileRefresh.Name = "FileRefresh";
            this.FileRefresh.Size = new System.Drawing.Size(73, 22);
            this.FileRefresh.Text = "刷 新(&R)";
            this.FileRefresh.ToolTipText = "刷新";
            this.FileRefresh.Click += new System.EventHandler(this.FileRefresh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolImport
            // 
            this.toolImport.Image = ((System.Drawing.Image)(resources.GetObject("toolImport.Image")));
            this.toolImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolImport.Name = "toolImport";
            this.toolImport.Size = new System.Drawing.Size(67, 22);
            this.toolImport.Text = "汇   入";
            this.toolImport.ToolTipText = "汇   入(只对工治具)";
            // 
            // btnPartEdit
            // 
            this.btnPartEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnPartEdit.Image")));
            this.btnPartEdit.ImageTransparentColor = System.Drawing.Color.White;
            this.btnPartEdit.Name = "btnPartEdit";
            this.btnPartEdit.Size = new System.Drawing.Size(115, 22);
            this.btnPartEdit.Text = "维护对应料号(&O)";
            this.btnPartEdit.ToolTipText = "匯出";
            this.btnPartEdit.Click += new System.EventHandler(this.btnPartEdit_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolExit
            // 
            this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
            this.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(73, 22);
            this.toolExit.Text = "退 出(&X)";
            this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(4, 143);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvSteel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvPartList);
            this.splitContainer1.Size = new System.Drawing.Size(860, 271);
            this.splitContainer1.SplitterDistance = 602;
            this.splitContainer1.TabIndex = 30;
            // 
            // dgvPartList
            // 
            this.dgvPartList.AllowUserToAddRows = false;
            this.dgvPartList.AllowUserToDeleteRows = false;
            this.dgvPartList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.dgvPartList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvPartList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPartList.BackgroundColor = System.Drawing.Color.White;
            this.dgvPartList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPartList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvPartList.ColumnHeadersHeight = 30;
            this.dgvPartList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PartID});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPartList.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvPartList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPartList.GridColor = System.Drawing.SystemColors.Control;
            this.dgvPartList.Location = new System.Drawing.Point(0, 0);
            this.dgvPartList.MultiSelect = false;
            this.dgvPartList.Name = "dgvPartList";
            this.dgvPartList.RowHeadersWidth = 30;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvPartList.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvPartList.RowTemplate.Height = 25;
            this.dgvPartList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartList.ShowEditingIcon = false;
            this.dgvPartList.Size = new System.Drawing.Size(254, 271);
            this.dgvPartList.TabIndex = 31;
            this.dgvPartList.TabStop = false;
            // 
            // PartID
            // 
            this.PartID.Frozen = true;
            this.PartID.HeaderText = "料号";
            this.PartID.Name = "PartID";
            this.PartID.ReadOnly = true;
            this.PartID.Width = 80;
            // 
            // FrmSteel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 445);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmSteel";
            this.Text = "钢网基础资料";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSteel)).EndInit();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label LblMsg;
        internal System.Windows.Forms.TextBox txtSTENCIL_ID;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn2;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn3;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn4;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn5;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn6;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn7;
        internal System.Windows.Forms.DataGridView dgvSteel;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton toolAdd;
        internal System.Windows.Forms.ToolStripButton toolEdit;
        private System.Windows.Forms.ToolStripButton toolAbandon;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolQuery;
        internal System.Windows.Forms.ToolStripButton toolBack;
        internal System.Windows.Forms.ToolStripButton FileRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        internal System.Windows.Forms.ToolStripButton toolImport;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.ComboBox cobStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.DataGridView dgvPartList;
        internal System.Windows.Forms.ToolStripButton btnPartEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn SteelNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Intime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartID;
    }
}