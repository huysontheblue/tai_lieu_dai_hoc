namespace RouteManagement
{
    partial class FrmDbDictionary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDbDictionary));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTableName = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createUserid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTableStruc = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.orderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.details = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.decimalPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.characteristic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isNull = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableStruc)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbQuery,
            this.toolStripSeparator1,
            this.tsbExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1218, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbQuery
            // 
            this.tsbQuery.Image = ((System.Drawing.Image)(resources.GetObject("tsbQuery.Image")));
            this.tsbQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQuery.Name = "tsbQuery";
            this.tsbQuery.Size = new System.Drawing.Size(52, 22);
            this.tsbQuery.Text = "查询";
            this.tsbQuery.Click += new System.EventHandler(this.tsbQuery_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(52, 22);
            this.tsbExit.Text = "退出";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvTableStruc);
            this.splitContainer1.Size = new System.Drawing.Size(1218, 467);
            this.splitContainer1.SplitterDistance = 417;
            this.splitContainer1.TabIndex = 2;
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
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvTableName);
            this.splitContainer2.Size = new System.Drawing.Size(417, 467);
            this.splitContainer2.SplitterDistance = 69;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDetails);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTableName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(126, 42);
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(198, 21);
            this.txtDetails.TabIndex = 4;
            this.txtDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDetails_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(52, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "表说明：";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(126, 11);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(198, 21);
            this.txtTableName.TabIndex = 2;
            this.txtTableName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTableName_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(68, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "表名：";
            // 
            // dgvTableName
            // 
            this.dgvTableName.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTableName.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTableName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableName.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tableName,
            this.tableDetails,
            this.createUserid,
            this.createTime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTableName.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTableName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableName.EnableHeadersVisualStyles = false;
            this.dgvTableName.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(211)))), ((int)(((byte)(217)))));
            this.dgvTableName.Location = new System.Drawing.Point(0, 0);
            this.dgvTableName.MultiSelect = false;
            this.dgvTableName.Name = "dgvTableName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTableName.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTableName.RowTemplate.Height = 23;
            this.dgvTableName.Size = new System.Drawing.Size(417, 394);
            this.dgvTableName.TabIndex = 0;
            this.dgvTableName.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTableName_CellClick);
            this.dgvTableName.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTableName_CellLeave);
            this.dgvTableName.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTableName_RowPostPaint);
            // 
            // tableName
            // 
            this.tableName.DataPropertyName = "tabName";
            this.tableName.FillWeight = 150F;
            this.tableName.HeaderText = "数据库表名";
            this.tableName.Name = "tableName";
            this.tableName.ReadOnly = true;
            this.tableName.Width = 130;
            // 
            // tableDetails
            // 
            this.tableDetails.DataPropertyName = "tabDetails";
            this.tableDetails.HeaderText = "表说明";
            this.tableDetails.Name = "tableDetails";
            this.tableDetails.Width = 150;
            // 
            // createUserid
            // 
            this.createUserid.DataPropertyName = "UpdateUserid";
            this.createUserid.HeaderText = "维护人员";
            this.createUserid.Name = "createUserid";
            this.createUserid.ReadOnly = true;
            this.createUserid.Width = 90;
            // 
            // createTime
            // 
            this.createTime.DataPropertyName = "UpdateTime";
            this.createTime.HeaderText = "维护时间";
            this.createTime.Name = "createTime";
            this.createTime.ReadOnly = true;
            this.createTime.Width = 150;
            // 
            // dgvTableStruc
            // 
            this.dgvTableStruc.AllowUserToAddRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTableStruc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTableStruc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableStruc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderNumber,
            this.columnName,
            this.dataType,
            this.details,
            this.length,
            this.decimalPlace,
            this.characteristic,
            this.pK,
            this.fK,
            this.isNull,
            this.defaultValue});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTableStruc.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTableStruc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableStruc.EnableHeadersVisualStyles = false;
            this.dgvTableStruc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(211)))), ((int)(((byte)(217)))));
            this.dgvTableStruc.Location = new System.Drawing.Point(0, 0);
            this.dgvTableStruc.MultiSelect = false;
            this.dgvTableStruc.Name = "dgvTableStruc";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTableStruc.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTableStruc.RowTemplate.Height = 23;
            this.dgvTableStruc.Size = new System.Drawing.Size(797, 467);
            this.dgvTableStruc.TabIndex = 0;
            this.dgvTableStruc.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTableStruc_CellLeave);
            // 
            // orderNumber
            // 
            this.orderNumber.DataPropertyName = "序号";
            this.orderNumber.HeaderText = "序号";
            this.orderNumber.Name = "orderNumber";
            this.orderNumber.ReadOnly = true;
            this.orderNumber.Width = 60;
            // 
            // columnName
            // 
            this.columnName.DataPropertyName = "列名";
            this.columnName.HeaderText = "列名";
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            // 
            // dataType
            // 
            this.dataType.DataPropertyName = "数据类型";
            this.dataType.HeaderText = "数据类型";
            this.dataType.Name = "dataType";
            this.dataType.ReadOnly = true;
            // 
            // details
            // 
            this.details.DataPropertyName = "说明";
            this.details.HeaderText = "说明";
            this.details.Name = "details";
            this.details.Width = 160;
            // 
            // length
            // 
            this.length.DataPropertyName = "长度";
            this.length.HeaderText = "长度";
            this.length.Name = "length";
            this.length.ReadOnly = true;
            // 
            // decimalPlace
            // 
            this.decimalPlace.DataPropertyName = "小数位";
            this.decimalPlace.HeaderText = "小数位";
            this.decimalPlace.Name = "decimalPlace";
            this.decimalPlace.ReadOnly = true;
            // 
            // characteristic
            // 
            this.characteristic.DataPropertyName = "标识";
            this.characteristic.HeaderText = "标识";
            this.characteristic.Name = "characteristic";
            this.characteristic.ReadOnly = true;
            // 
            // pK
            // 
            this.pK.DataPropertyName = "主键";
            this.pK.HeaderText = "主键";
            this.pK.Name = "pK";
            this.pK.ReadOnly = true;
            // 
            // fK
            // 
            this.fK.DataPropertyName = "外键";
            this.fK.HeaderText = "外键";
            this.fK.Name = "fK";
            this.fK.ReadOnly = true;
            // 
            // isNull
            // 
            this.isNull.DataPropertyName = "允许空";
            this.isNull.HeaderText = "允许空";
            this.isNull.Name = "isNull";
            this.isNull.ReadOnly = true;
            // 
            // defaultValue
            // 
            this.defaultValue.DataPropertyName = "默认值";
            this.defaultValue.HeaderText = "默认值";
            this.defaultValue.Name = "defaultValue";
            this.defaultValue.ReadOnly = true;
            // 
            // FrmDbDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 492);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmDbDictionary";
            this.Text = "数据库字典";
            this.Load += new System.EventHandler(this.FrmDbDictionary_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableStruc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvTableName;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvTableStruc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn createUserid;
        private System.Windows.Forms.DataGridViewTextBoxColumn createTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn details;
        private System.Windows.Forms.DataGridViewTextBoxColumn length;
        private System.Windows.Forms.DataGridViewTextBoxColumn decimalPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn characteristic;
        private System.Windows.Forms.DataGridViewTextBoxColumn pK;
        private System.Windows.Forms.DataGridViewTextBoxColumn fK;
        private System.Windows.Forms.DataGridViewTextBoxColumn isNull;
        private System.Windows.Forms.DataGridViewTextBoxColumn defaultValue;
    }
}