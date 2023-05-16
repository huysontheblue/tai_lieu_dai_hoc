namespace SMTModule
{
    partial class FrmSolderPasteNumberSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSolderPasteNumberSetting));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsmiComboCondition = new System.Windows.Forms.ToolStripComboBox();
            this.tsmiAdd = new System.Windows.Forms.ToolStripButton();
            this.tsmiStop = new System.Windows.Forms.ToolStripButton();
            this.tsmiExportOut = new System.Windows.Forms.ToolStripButton();
            this.tsmiExit = new System.Windows.Forms.ToolStripButton();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.PARTID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENABLED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPDATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSPartID = new System.Windows.Forms.TextBox();
            this.txtSUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiComboCondition,
            this.tsmiAdd,
            this.tsmiStop,
            this.tsmiExportOut,
            this.tsmiExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(909, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsmiComboCondition
            // 
            this.tsmiComboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsmiComboCondition.Items.AddRange(new object[] {
            "All",
            "可用",
            "停用"});
            this.tsmiComboCondition.Name = "tsmiComboCondition";
            this.tsmiComboCondition.Size = new System.Drawing.Size(121, 25);
            this.tsmiComboCondition.SelectedIndexChanged += new System.EventHandler(this.tsmiComboCondition_SelectedIndexChanged);
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAdd.Image")));
            this.tsmiAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(52, 22);
            this.tsmiAdd.Text = "新增";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiStop
            // 
            this.tsmiStop.Image = ((System.Drawing.Image)(resources.GetObject("tsmiStop.Image")));
            this.tsmiStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiStop.Name = "tsmiStop";
            this.tsmiStop.Size = new System.Drawing.Size(52, 22);
            this.tsmiStop.Text = "停用";
            this.tsmiStop.Click += new System.EventHandler(this.tsmiStop_Click);
            // 
            // tsmiExportOut
            // 
            this.tsmiExportOut.Image = ((System.Drawing.Image)(resources.GetObject("tsmiExportOut.Image")));
            this.tsmiExportOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiExportOut.Name = "tsmiExportOut";
            this.tsmiExportOut.Size = new System.Drawing.Size(52, 22);
            this.tsmiExportOut.Text = "汇出";
            this.tsmiExportOut.Click += new System.EventHandler(this.tsmiExportOut_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Image = ((System.Drawing.Image)(resources.GetObject("tsmiExit.Image")));
            this.tsmiExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(52, 22);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PARTID,
            this.ENABLED,
            this.InputUserName,
            this.UPDATE_TIME});
            this.dgvData.Location = new System.Drawing.Point(0, 59);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(909, 319);
            this.dgvData.TabIndex = 1;
            // 
            // PARTID
            // 
            this.PARTID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PARTID.DataPropertyName = "PARTID";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.PARTID.DefaultCellStyle = dataGridViewCellStyle17;
            this.PARTID.HeaderText = "料号";
            this.PARTID.Name = "PARTID";
            this.PARTID.ReadOnly = true;
            this.PARTID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ENABLED
            // 
            this.ENABLED.DataPropertyName = "ENABLED";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ENABLED.DefaultCellStyle = dataGridViewCellStyle18;
            this.ENABLED.HeaderText = "是否可用";
            this.ENABLED.Name = "ENABLED";
            this.ENABLED.ReadOnly = true;
            this.ENABLED.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // InputUserName
            // 
            this.InputUserName.DataPropertyName = "InputUserName";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.InputUserName.DefaultCellStyle = dataGridViewCellStyle19;
            this.InputUserName.HeaderText = "员工";
            this.InputUserName.Name = "InputUserName";
            this.InputUserName.ReadOnly = true;
            this.InputUserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UPDATE_TIME
            // 
            this.UPDATE_TIME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UPDATE_TIME.DataPropertyName = "UPDATE_TIME";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.UPDATE_TIME.DefaultCellStyle = dataGridViewCellStyle20;
            this.UPDATE_TIME.HeaderText = "更新日期";
            this.UPDATE_TIME.Name = "UPDATE_TIME";
            this.UPDATE_TIME.ReadOnly = true;
            this.UPDATE_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "料号:";
            // 
            // txtSPartID
            // 
            this.txtSPartID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSPartID.Location = new System.Drawing.Point(58, 32);
            this.txtSPartID.Name = "txtSPartID";
            this.txtSPartID.Size = new System.Drawing.Size(173, 21);
            this.txtSPartID.TabIndex = 3;
            // 
            // txtSUserName
            // 
            this.txtSUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSUserName.Location = new System.Drawing.Point(304, 32);
            this.txtSUserName.Name = "txtSUserName";
            this.txtSUserName.Size = new System.Drawing.Size(173, 21);
            this.txtSUserName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "员工:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(522, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmSolderPasteNumberSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 378);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSPartID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSolderPasteNumberSetting";
            this.ShowIcon = false;
            this.Text = "锡膏料号设定";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSolderPasteNumberSetting_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox tsmiComboCondition;
        private System.Windows.Forms.ToolStripButton tsmiAdd;
        private System.Windows.Forms.ToolStripButton tsmiStop;
        private System.Windows.Forms.ToolStripButton tsmiExportOut;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSPartID;
        private System.Windows.Forms.TextBox txtSUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn PARTID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENABLED;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPDATE_TIME;
        private System.Windows.Forms.ToolStripButton tsmiExit;
    }
}