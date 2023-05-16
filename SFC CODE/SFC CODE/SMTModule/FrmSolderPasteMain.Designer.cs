namespace SMTModule
{
    partial class FrmSolderPasteMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSolderPasteMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolPartSet = new System.Windows.Forms.ToolStripButton();
            this.toolCOMSetting = new System.Windows.Forms.ToolStripButton();
            this.toolQuery = new System.Windows.Forms.ToolStripButton();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonX8 = new DevComponents.DotNetBar.ButtonX();
            this.ButtonX3 = new DevComponents.DotNetBar.ButtonX();
            this.ButtonX6 = new DevComponents.DotNetBar.ButtonX();
            this.ButtonX4 = new DevComponents.DotNetBar.ButtonX();
            this.ButtonX5 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX9 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX10 = new DevComponents.DotNetBar.ButtonX();
            this.ButtonX7 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX11 = new DevComponents.DotNetBar.ButtonX();
            this.toolStrip1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolPartSet,
            this.toolCOMSetting,
            this.toolQuery,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(806, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolPartSet
            // 
            this.toolPartSet.Image = ((System.Drawing.Image)(resources.GetObject("toolPartSet.Image")));
            this.toolPartSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPartSet.Name = "toolPartSet";
            this.toolPartSet.Size = new System.Drawing.Size(97, 22);
            this.toolPartSet.Tag = "NO";
            this.toolPartSet.Text = "锡膏料号设定";
            this.toolPartSet.Click += new System.EventHandler(this.toolPartSet_Click);
            // 
            // toolCOMSetting
            // 
            this.toolCOMSetting.Image = ((System.Drawing.Image)(resources.GetObject("toolCOMSetting.Image")));
            this.toolCOMSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCOMSetting.Name = "toolCOMSetting";
            this.toolCOMSetting.Size = new System.Drawing.Size(73, 22);
            this.toolCOMSetting.Text = "锡膏设定";
            this.toolCOMSetting.Click += new System.EventHandler(this.toolCOMSetting_Click);
            // 
            // toolQuery
            // 
            this.toolQuery.Image = ((System.Drawing.Image)(resources.GetObject("toolQuery.Image")));
            this.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolQuery.Name = "toolQuery";
            this.toolQuery.Size = new System.Drawing.Size(99, 22);
            this.toolQuery.Text = "查看锡膏报表";
            this.toolQuery.Click += new System.EventHandler(this.toolQuery_Click);
            // 
            // toolExit
            // 
            this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
            this.toolExit.ImageTransparentColor = System.Drawing.Color.White;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(73, 22);
            this.toolExit.Text = "退 出(&X)";
            this.toolExit.ToolTipText = "退出";
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.Controls.Add(this.tableLayoutPanel2);
            this.Panel1.Location = new System.Drawing.Point(171, 129);
            this.Panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(469, 225);
            this.Panel1.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel2.Controls.Add(this.ButtonX8, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.ButtonX3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ButtonX6, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.ButtonX4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ButtonX5, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonX9, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonX10, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.ButtonX7, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.buttonX11, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(469, 225);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // ButtonX8
            // 
            this.ButtonX8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButtonX8.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButtonX8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonX8.Location = new System.Drawing.Point(309, 149);
            this.ButtonX8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonX8.Name = "ButtonX8";
            this.ButtonX8.Size = new System.Drawing.Size(155, 71);
            this.ButtonX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButtonX8.TabIndex = 7;
            this.ButtonX8.Tag = "报废";
            this.ButtonX8.Text = "报废";
            this.ButtonX8.Click += new System.EventHandler(this.ButtonX8_Click);
            // 
            // ButtonX3
            // 
            this.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButtonX3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonX3.Location = new System.Drawing.Point(5, 5);
            this.ButtonX3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonX3.Name = "ButtonX3";
            this.ButtonX3.Size = new System.Drawing.Size(148, 68);
            this.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButtonX3.TabIndex = 2;
            this.ButtonX3.Tag = "入冰库";
            this.ButtonX3.Text = "入冰库";
            this.ButtonX3.Click += new System.EventHandler(this.ButtonX3_Click);
            // 
            // ButtonX6
            // 
            this.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButtonX6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonX6.Location = new System.Drawing.Point(157, 149);
            this.ButtonX6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonX6.Name = "ButtonX6";
            this.ButtonX6.Size = new System.Drawing.Size(148, 71);
            this.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButtonX6.TabIndex = 5;
            this.ButtonX6.Tag = "回冰";
            this.ButtonX6.Text = "回冰";
            this.ButtonX6.Click += new System.EventHandler(this.ButtonX6_Click);
            // 
            // ButtonX4
            // 
            this.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButtonX4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonX4.Location = new System.Drawing.Point(157, 5);
            this.ButtonX4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonX4.Name = "ButtonX4";
            this.ButtonX4.Size = new System.Drawing.Size(148, 68);
            this.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButtonX4.TabIndex = 3;
            this.ButtonX4.Tag = "回温";
            this.ButtonX4.Text = "回温";
            this.ButtonX4.Click += new System.EventHandler(this.ButtonX4_Click);
            // 
            // ButtonX5
            // 
            this.ButtonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButtonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButtonX5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonX5.Location = new System.Drawing.Point(309, 5);
            this.ButtonX5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonX5.Name = "ButtonX5";
            this.ButtonX5.Size = new System.Drawing.Size(155, 68);
            this.ButtonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButtonX5.TabIndex = 4;
            this.ButtonX5.Tag = "搅拌";
            this.ButtonX5.Text = "搅拌";
            this.ButtonX5.Click += new System.EventHandler(this.ButtonX5_Click);
            // 
            // buttonX9
            // 
            this.buttonX9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX9.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonX9.Location = new System.Drawing.Point(5, 77);
            this.buttonX9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonX9.Name = "buttonX9";
            this.buttonX9.Size = new System.Drawing.Size(148, 68);
            this.buttonX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX9.TabIndex = 12;
            this.buttonX9.Tag = "领用";
            this.buttonX9.Text = "领用";
            this.buttonX9.Click += new System.EventHandler(this.buttonX9_Click);
            // 
            // buttonX10
            // 
            this.buttonX10.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX10.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonX10.Location = new System.Drawing.Point(157, 77);
            this.buttonX10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonX10.Name = "buttonX10";
            this.buttonX10.Size = new System.Drawing.Size(148, 68);
            this.buttonX10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX10.TabIndex = 11;
            this.buttonX10.Tag = "开封";
            this.buttonX10.Text = "开封";
            this.buttonX10.Click += new System.EventHandler(this.buttonX10_Click);
            // 
            // ButtonX7
            // 
            this.ButtonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButtonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButtonX7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonX7.Location = new System.Drawing.Point(5, 149);
            this.ButtonX7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonX7.Name = "ButtonX7";
            this.ButtonX7.Size = new System.Drawing.Size(148, 71);
            this.ButtonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButtonX7.TabIndex = 6;
            this.ButtonX7.Tag = "用完";
            this.ButtonX7.Text = "用完";
            this.ButtonX7.Click += new System.EventHandler(this.ButtonX7_Click);
            // 
            // buttonX11
            // 
            this.buttonX11.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX11.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonX11.Location = new System.Drawing.Point(309, 77);
            this.buttonX11.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonX11.Name = "buttonX11";
            this.buttonX11.Size = new System.Drawing.Size(155, 68);
            this.buttonX11.TabIndex = 10;
            this.buttonX11.Tag = "上料";
            this.buttonX11.Text = "上料";
            this.buttonX11.Click += new System.EventHandler(this.buttonX11_Click);
            // 
            // FrmSolderPasteMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 493);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmSolderPasteMain";
            this.Text = "锡膏管理";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton toolCOMSetting;
        internal System.Windows.Forms.ToolStripButton toolExit;
        internal System.Windows.Forms.Panel Panel1;
        internal DevComponents.DotNetBar.ButtonX ButtonX6;
        internal DevComponents.DotNetBar.ButtonX ButtonX3;
        internal DevComponents.DotNetBar.ButtonX ButtonX7;
        internal DevComponents.DotNetBar.ButtonX ButtonX8;
        internal DevComponents.DotNetBar.ButtonX ButtonX4;
        internal DevComponents.DotNetBar.ButtonX ButtonX5;
        internal DevComponents.DotNetBar.ButtonX buttonX9;
        internal DevComponents.DotNetBar.ButtonX buttonX10;
        internal DevComponents.DotNetBar.ButtonX buttonX11;
        internal System.Windows.Forms.ToolStripButton toolPartSet;
        private System.Windows.Forms.ToolStripButton toolQuery;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}