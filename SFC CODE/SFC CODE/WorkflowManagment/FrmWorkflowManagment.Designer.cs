namespace WorkflowManagment
{
    partial class FrmWorkflowManagment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkflowManagment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolNew = new System.Windows.Forms.ToolStripButton();
            this.ToolEdit = new System.Windows.Forms.ToolStripButton();
            this.ToolCommit = new System.Windows.Forms.ToolStripButton();
            this.ToolBack = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolComfire = new System.Windows.Forms.ToolStripButton();
            this.ToolAbandon = new System.Windows.Forms.ToolStripButton();
            this.ToolRecovery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolExit = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dataGridViewX2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolNew,
            this.ToolEdit,
            this.ToolCommit,
            this.ToolBack,
            this.ToolStripSeparator3,
            this.ToolQuery,
            this.toolStripSeparator1,
            this.ToolComfire,
            this.ToolAbandon,
            this.ToolRecovery,
            this.toolStripSeparator2,
            this.ToolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1232, 25);
            this.toolStrip1.TabIndex = 326;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToolNew
            // 
            this.ToolNew.Image = ((System.Drawing.Image)(resources.GetObject("ToolNew.Image")));
            this.ToolNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolNew.Name = "ToolNew";
            this.ToolNew.Size = new System.Drawing.Size(74, 22);
            this.ToolNew.Tag = "NO";
            this.ToolNew.Text = "新 增(&N)";
            // 
            // ToolEdit
            // 
            this.ToolEdit.Image = ((System.Drawing.Image)(resources.GetObject("ToolEdit.Image")));
            this.ToolEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolEdit.Name = "ToolEdit";
            this.ToolEdit.Size = new System.Drawing.Size(71, 22);
            this.ToolEdit.Tag = "NO";
            this.ToolEdit.Text = "修 改(&E)";
            // 
            // ToolCommit
            // 
            this.ToolCommit.Image = ((System.Drawing.Image)(resources.GetObject("ToolCommit.Image")));
            this.ToolCommit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolCommit.Name = "ToolCommit";
            this.ToolCommit.Size = new System.Drawing.Size(68, 22);
            this.ToolCommit.Tag = "";
            this.ToolCommit.Text = "提交(&C)";
            this.ToolCommit.ToolTipText = "提交";
            // 
            // ToolBack
            // 
            this.ToolBack.Image = ((System.Drawing.Image)(resources.GetObject("ToolBack.Image")));
            this.ToolBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolBack.Name = "ToolBack";
            this.ToolBack.Size = new System.Drawing.Size(72, 22);
            this.ToolBack.Tag = "";
            this.ToolBack.Text = "返 回(&B)";
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolQuery
            // 
            this.ToolQuery.ForeColor = System.Drawing.Color.Black;
            this.ToolQuery.Image = ((System.Drawing.Image)(resources.GetObject("ToolQuery.Image")));
            this.ToolQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolQuery.Name = "ToolQuery";
            this.ToolQuery.Size = new System.Drawing.Size(74, 22);
            this.ToolQuery.Text = "查 询(&Q)";
            this.ToolQuery.ToolTipText = "查 詢";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolComfire
            // 
            this.ToolComfire.Image = ((System.Drawing.Image)(resources.GetObject("ToolComfire.Image")));
            this.ToolComfire.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolComfire.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolComfire.Name = "ToolComfire";
            this.ToolComfire.Size = new System.Drawing.Size(69, 22);
            this.ToolComfire.Tag = "NO";
            this.ToolComfire.Text = "确认(&S)";
            // 
            // ToolAbandon
            // 
            this.ToolAbandon.Image = ((System.Drawing.Image)(resources.GetObject("ToolAbandon.Image")));
            this.ToolAbandon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolAbandon.Name = "ToolAbandon";
            this.ToolAbandon.Size = new System.Drawing.Size(69, 22);
            this.ToolAbandon.Tag = "NO";
            this.ToolAbandon.Text = "作废(&D)";
            // 
            // ToolRecovery
            // 
            this.ToolRecovery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolRecovery.Name = "ToolRecovery";
            this.ToolRecovery.Size = new System.Drawing.Size(52, 22);
            this.ToolRecovery.Text = "恢复(&R)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolExit
            // 
            this.ToolExit.Image = ((System.Drawing.Image)(resources.GetObject("ToolExit.Image")));
            this.ToolExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolExit.Name = "ToolExit";
            this.ToolExit.Size = new System.Drawing.Size(72, 22);
            this.ToolExit.Text = "退 出(&X)";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1232, 25);
            this.menuStrip1.TabIndex = 325;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(59, 21);
            this.toolStripMenuItem1.Text = "系统(&S)";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(58, 21);
            this.toolStripMenuItem2.Text = "文件(&F)";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(60, 21);
            this.toolStripMenuItem3.Text = "查看(&V)";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(59, 21);
            this.toolStripMenuItem4.Text = "工具(&T)";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(64, 21);
            this.toolStripMenuItem5.Text = "窗口(&W)";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(61, 21);
            this.toolStripMenuItem6.Text = "帮助(&H)";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewX1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1232, 601);
            this.splitContainer1.SplitterDistance = 285;
            this.splitContainer1.TabIndex = 327;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridViewX2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.elementHost1);
            this.splitContainer2.Size = new System.Drawing.Size(943, 601);
            this.splitContainer2.SplitterDistance = 91;
            this.splitContainer2.TabIndex = 0;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(211)))), ((int)(((byte)(217)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 95);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(285, 506);
            this.dataGridViewX1.TabIndex = 0;
            // 
            // dataGridViewX2
            // 
            this.dataGridViewX2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewX2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(211)))), ((int)(((byte)(217)))));
            this.dataGridViewX2.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX2.Name = "dataGridViewX2";
            this.dataGridViewX2.RowTemplate.Height = 23;
            this.dataGridViewX2.Size = new System.Drawing.Size(943, 91);
            this.dataGridViewX2.TabIndex = 1;
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(943, 506);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // FrmWorkflowManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 651);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FrmWorkflowManagment";
            this.ShowIcon = false;
            this.Text = "流程设置";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton ToolNew;
        internal System.Windows.Forms.ToolStripButton ToolEdit;
        internal System.Windows.Forms.ToolStripButton ToolCommit;
        internal System.Windows.Forms.ToolStripButton ToolBack;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        internal System.Windows.Forms.ToolStripButton ToolQuery;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ToolComfire;
        private System.Windows.Forms.ToolStripButton ToolAbandon;
        private System.Windows.Forms.ToolStripButton ToolRecovery;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ToolExit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX2;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
    }
}