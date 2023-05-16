namespace CPU_Simulator {
    partial class ProgramForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.randomBtn = new System.Windows.Forms.Button();
            this.timeQuantumBox = new System.Windows.Forms.NumericUpDown();
            this.psPreemtiveCheck = new System.Windows.Forms.CheckBox();
            this.rrBtn = new System.Windows.Forms.RadioButton();
            this.psBtn = new System.Windows.Forms.RadioButton();
            this.sjfBtn = new System.Windows.Forms.RadioButton();
            this.fcfsBtn = new System.Windows.Forms.RadioButton();
            this.sjfPreemtiveCheck = new System.Windows.Forms.CheckBox();
            this.calcBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cpuExecutionTimeLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.throughputLabel = new System.Windows.Forms.Label();
            this.utilizationLabel = new System.Windows.Forms.Label();
            this.averageResponseTimeLabel = new System.Windows.Forms.Label();
            this.averageTurnaroundTimeLabel = new System.Windows.Forms.Label();
            this.averageWaitingTimeLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fileBrowser = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox0 = new System.Windows.Forms.GroupBox();
            this.cpuWorkflowBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeQuantumBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox0.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "txt";
            this.openFileDialog.FileName = "InputData";
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.NavajoWhite;
            this.groupBox2.Controls.Add(this.randomBtn);
            this.groupBox2.Controls.Add(this.timeQuantumBox);
            this.groupBox2.Controls.Add(this.psPreemtiveCheck);
            this.groupBox2.Controls.Add(this.rrBtn);
            this.groupBox2.Controls.Add(this.psBtn);
            this.groupBox2.Controls.Add(this.sjfBtn);
            this.groupBox2.Controls.Add(this.fcfsBtn);
            this.groupBox2.Controls.Add(this.sjfPreemtiveCheck);
            this.groupBox2.Controls.Add(this.calcBtn);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // randomBtn
            // 
            this.randomBtn.BackColor = System.Drawing.Color.White;
            this.randomBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.randomBtn, "randomBtn");
            this.randomBtn.Name = "randomBtn";
            this.toolTip1.SetToolTip(this.randomBtn, resources.GetString("randomBtn.ToolTip"));
            this.randomBtn.UseVisualStyleBackColor = false;
            this.randomBtn.Click += new System.EventHandler(this.RandomBtn_Click);
            // 
            // timeQuantumBox
            // 
            resources.ApplyResources(this.timeQuantumBox, "timeQuantumBox");
            this.timeQuantumBox.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.timeQuantumBox.Name = "timeQuantumBox";
            this.timeQuantumBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // psPreemtiveCheck
            // 
            resources.ApplyResources(this.psPreemtiveCheck, "psPreemtiveCheck");
            this.psPreemtiveCheck.BackColor = System.Drawing.Color.Pink;
            this.psPreemtiveCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.psPreemtiveCheck.Name = "psPreemtiveCheck";
            this.psPreemtiveCheck.UseVisualStyleBackColor = false;
            // 
            // rrBtn
            // 
            resources.ApplyResources(this.rrBtn, "rrBtn");
            this.rrBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rrBtn.ForeColor = System.Drawing.Color.Black;
            this.rrBtn.Name = "rrBtn";
            this.rrBtn.TabStop = true;
            this.rrBtn.UseVisualStyleBackColor = true;
            this.rrBtn.CheckedChanged += new System.EventHandler(this.RrBtn_CheckedChanged);
            // 
            // psBtn
            // 
            resources.ApplyResources(this.psBtn, "psBtn");
            this.psBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.psBtn.ForeColor = System.Drawing.Color.Black;
            this.psBtn.Name = "psBtn";
            this.psBtn.TabStop = true;
            this.psBtn.UseVisualStyleBackColor = true;
            this.psBtn.CheckedChanged += new System.EventHandler(this.PsBtn_CheckedChanged);
            // 
            // sjfBtn
            // 
            resources.ApplyResources(this.sjfBtn, "sjfBtn");
            this.sjfBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sjfBtn.ForeColor = System.Drawing.Color.Black;
            this.sjfBtn.Name = "sjfBtn";
            this.sjfBtn.TabStop = true;
            this.sjfBtn.UseVisualStyleBackColor = true;
            this.sjfBtn.CheckedChanged += new System.EventHandler(this.SjfBtn_CheckedChanged);
            // 
            // fcfsBtn
            // 
            resources.ApplyResources(this.fcfsBtn, "fcfsBtn");
            this.fcfsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fcfsBtn.ForeColor = System.Drawing.Color.Black;
            this.fcfsBtn.Name = "fcfsBtn";
            this.fcfsBtn.TabStop = true;
            this.fcfsBtn.UseVisualStyleBackColor = true;
            this.fcfsBtn.CheckedChanged += new System.EventHandler(this.FcfsBtn_CheckedChanged);
            // 
            // sjfPreemtiveCheck
            // 
            resources.ApplyResources(this.sjfPreemtiveCheck, "sjfPreemtiveCheck");
            this.sjfPreemtiveCheck.BackColor = System.Drawing.Color.Pink;
            this.sjfPreemtiveCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sjfPreemtiveCheck.Name = "sjfPreemtiveCheck";
            this.sjfPreemtiveCheck.UseVisualStyleBackColor = false;
            // 
            // calcBtn
            // 
            this.calcBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.calcBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.calcBtn, "calcBtn");
            this.calcBtn.Name = "calcBtn";
            this.calcBtn.UseVisualStyleBackColor = false;
            this.calcBtn.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.NavajoWhite;
            this.groupBox3.Controls.Add(this.cpuExecutionTimeLabel);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.throughputLabel);
            this.groupBox3.Controls.Add(this.utilizationLabel);
            this.groupBox3.Controls.Add(this.averageResponseTimeLabel);
            this.groupBox3.Controls.Add(this.averageTurnaroundTimeLabel);
            this.groupBox3.Controls.Add(this.averageWaitingTimeLabel);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // cpuExecutionTimeLabel
            // 
            resources.ApplyResources(this.cpuExecutionTimeLabel, "cpuExecutionTimeLabel");
            this.cpuExecutionTimeLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.cpuExecutionTimeLabel.Name = "cpuExecutionTimeLabel";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // throughputLabel
            // 
            resources.ApplyResources(this.throughputLabel, "throughputLabel");
            this.throughputLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.throughputLabel.Name = "throughputLabel";
            // 
            // utilizationLabel
            // 
            resources.ApplyResources(this.utilizationLabel, "utilizationLabel");
            this.utilizationLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.utilizationLabel.Name = "utilizationLabel";
            // 
            // averageResponseTimeLabel
            // 
            resources.ApplyResources(this.averageResponseTimeLabel, "averageResponseTimeLabel");
            this.averageResponseTimeLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.averageResponseTimeLabel.Name = "averageResponseTimeLabel";
            // 
            // averageTurnaroundTimeLabel
            // 
            resources.ApplyResources(this.averageTurnaroundTimeLabel, "averageTurnaroundTimeLabel");
            this.averageTurnaroundTimeLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.averageTurnaroundTimeLabel.Name = "averageTurnaroundTimeLabel";
            // 
            // averageWaitingTimeLabel
            // 
            resources.ApplyResources(this.averageWaitingTimeLabel, "averageWaitingTimeLabel");
            this.averageWaitingTimeLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.averageWaitingTimeLabel.Name = "averageWaitingTimeLabel";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // fileBrowser
            // 
            this.fileBrowser.BackColor = System.Drawing.Color.White;
            this.fileBrowser.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.fileBrowser, "fileBrowser");
            this.fileBrowser.Name = "fileBrowser";
            this.toolTip2.SetToolTip(this.fileBrowser, resources.GetString("fileBrowser.ToolTip"));
            this.fileBrowser.UseVisualStyleBackColor = false;
            this.fileBrowser.Click += new System.EventHandler(this.FileBrowser_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.dataGridView, "dataGridView");
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // groupBox0
            // 
            this.groupBox0.BackColor = System.Drawing.Color.PapayaWhip;
            resources.ApplyResources(this.groupBox0, "groupBox0");
            this.groupBox0.Controls.Add(this.cpuWorkflowBox);
            this.groupBox0.Controls.Add(this.label7);
            this.groupBox0.Controls.Add(this.dataGridView);
            this.groupBox0.Controls.Add(this.fileBrowser);
            this.groupBox0.Name = "groupBox0";
            this.groupBox0.TabStop = false;
            // 
            // cpuWorkflowBox
            // 
            this.cpuWorkflowBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.cpuWorkflowBox.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.cpuWorkflowBox, "cpuWorkflowBox");
            this.cpuWorkflowBox.Name = "cpuWorkflowBox";
            this.cpuWorkflowBox.ReadOnly = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 1000;
            this.toolTip1.AutoPopDelay = 7000;
            this.toolTip1.InitialDelay = 1000;
            this.toolTip1.ReshowDelay = 200;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Random Numbers Range";
            // 
            // toolTip2
            // 
            this.toolTip2.AutomaticDelay = 1000;
            this.toolTip2.AutoPopDelay = 10000;
            this.toolTip2.ForeColor = System.Drawing.Color.Ivory;
            this.toolTip2.InitialDelay = 1000;
            this.toolTip2.ReshowDelay = 200;
            this.toolTip2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip2.ToolTipTitle = "Data Input File Info";
            // 
            // ProgramForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.BackgroundImage = global::CPU_Simulator.Properties.Resources.Rose_BLACKPINK_Luu_Thi_Thi_du_show_Valentino_tai_Bac_Kinh_DepOnline_02;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox0);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ProgramForm";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeQuantumBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox0.ResumeLayout(false);
            this.groupBox0.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBox0;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown timeQuantumBox;
        private System.Windows.Forms.CheckBox psPreemtiveCheck;
        private System.Windows.Forms.RadioButton rrBtn;
        private System.Windows.Forms.RadioButton psBtn;
        private System.Windows.Forms.RadioButton sjfBtn;
        private System.Windows.Forms.RadioButton fcfsBtn;
        private System.Windows.Forms.CheckBox sjfPreemtiveCheck;
        private System.Windows.Forms.Button calcBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label throughputLabel;
        private System.Windows.Forms.Label utilizationLabel;
        private System.Windows.Forms.Label averageResponseTimeLabel;
        private System.Windows.Forms.Label averageTurnaroundTimeLabel;
        private System.Windows.Forms.Label averageWaitingTimeLabel;
        private System.Windows.Forms.Label cpuExecutionTimeLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button fileBrowser;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cpuWorkflowBox;
        private System.Windows.Forms.Button randomBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
    }
}

