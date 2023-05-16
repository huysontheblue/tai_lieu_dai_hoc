namespace SMTModule
{
    partial class FrmScraperManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScraperManage));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolNew = new System.Windows.Forms.ToolStripButton();
            this.toolModify = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolExport = new System.Windows.Forms.ToolStripButton();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.SCRAPER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCRAPER_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCRAPER_DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USED_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENABLED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNew,
            this.toolModify,
            this.toolDelete,
            this.toolExport,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(952, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolNew
            // 
            this.toolNew.Image = ((System.Drawing.Image)(resources.GetObject("toolNew.Image")));
            this.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNew.Name = "toolNew";
            this.toolNew.Size = new System.Drawing.Size(74, 22);
            this.toolNew.Tag = "新增";
            this.toolNew.Text = "新 增(&N)";
            this.toolNew.ToolTipText = "新增";
            this.toolNew.Click += new System.EventHandler(this.toolNew_Click);
            // 
            // toolModify
            // 
            this.toolModify.Image = ((System.Drawing.Image)(resources.GetObject("toolModify.Image")));
            this.toolModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolModify.Name = "toolModify";
            this.toolModify.Size = new System.Drawing.Size(71, 22);
            this.toolModify.Tag = "修改";
            this.toolModify.Text = "修 改(&E)";
            this.toolModify.ToolTipText = "修 改";
            this.toolModify.Click += new System.EventHandler(this.toolModify_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolDelete.Image")));
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(69, 22);
            this.toolDelete.Tag = "停用";
            this.toolDelete.Text = "停用(&D)";
            this.toolDelete.ToolTipText = "刪除";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // toolExport
            // 
            this.toolExport.Image = ((System.Drawing.Image)(resources.GetObject("toolExport.Image")));
            this.toolExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExport.Name = "toolExport";
            this.toolExport.Size = new System.Drawing.Size(64, 22);
            this.toolExport.Text = "汇   出";
            this.toolExport.Click += new System.EventHandler(this.toolExport_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SCRAPER_ID,
            this.SCRAPER_CODE,
            this.SCRAPER_DESC,
            this.USED_COUNT,
            this.ENABLED,
            this.STATUSN});
            this.dgvData.Location = new System.Drawing.Point(0, 75);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(952, 348);
            this.dgvData.TabIndex = 1;
            // 
            // SCRAPER_ID
            // 
            this.SCRAPER_ID.DataPropertyName = "SCRAPER_ID";
            this.SCRAPER_ID.HeaderText = "SCRAPER_ID";
            this.SCRAPER_ID.Name = "SCRAPER_ID";
            this.SCRAPER_ID.Visible = false;
            // 
            // SCRAPER_CODE
            // 
            this.SCRAPER_CODE.DataPropertyName = "SCRAPER_CODE";
            this.SCRAPER_CODE.HeaderText = "刮刀编号";
            this.SCRAPER_CODE.Name = "SCRAPER_CODE";
            this.SCRAPER_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SCRAPER_DESC
            // 
            this.SCRAPER_DESC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SCRAPER_DESC.DataPropertyName = "SCRAPER_DESC";
            this.SCRAPER_DESC.HeaderText = "刮刀描述";
            this.SCRAPER_DESC.Name = "SCRAPER_DESC";
            this.SCRAPER_DESC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // USED_COUNT
            // 
            this.USED_COUNT.DataPropertyName = "USED_COUNT";
            this.USED_COUNT.HeaderText = "使用次数";
            this.USED_COUNT.Name = "USED_COUNT";
            this.USED_COUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ENABLED
            // 
            this.ENABLED.DataPropertyName = "ENABLED";
            this.ENABLED.HeaderText = "有效否";
            this.ENABLED.Name = "ENABLED";
            this.ENABLED.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ENABLED.Width = 50;
            // 
            // STATUSN
            // 
            this.STATUSN.DataPropertyName = "STATUSN";
            this.STATUSN.HeaderText = "状态";
            this.STATUSN.Name = "STATUSN";
            this.STATUSN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "刮刀编号:";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(73, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(251, 21);
            this.textBox1.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Location = new System.Drawing.Point(633, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // toolExit
            // 
            this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
            this.toolExit.ImageTransparentColor = System.Drawing.Color.White;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(72, 22);
            this.toolExit.Text = "退 出(&X)";
            this.toolExit.ToolTipText = "退出";
            this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
            // 
            // FrmScraperManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 424);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmScraperManage";
            this.Text = "刮刀管理";
            this.Load += new System.EventHandler(this.FrmScraperManage_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton toolNew;
        internal System.Windows.Forms.ToolStripButton toolModify;
        internal System.Windows.Forms.ToolStripButton toolDelete;
        internal System.Windows.Forms.ToolStripButton toolExport;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCRAPER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCRAPER_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCRAPER_DESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn USED_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENABLED;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUSN;
        internal System.Windows.Forms.ToolStripButton toolExit;
    }
}