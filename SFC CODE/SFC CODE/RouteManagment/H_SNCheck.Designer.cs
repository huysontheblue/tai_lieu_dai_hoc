
namespace RouteManagement
{
    partial class H_SNCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(H_SNCheck));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.btnReSet = new System.Windows.Forms.Button();
            this.lblEslId = new System.Windows.Forms.Label();
            this.txtScreenCode = new System.Windows.Forms.TextBox();
            this.txtLaserCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMSG = new System.Windows.Forms.TextBox();
            this.txtMSG1 = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1192, 33);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolExit
            // 
            this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
            this.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(98, 28);
            this.toolExit.Text = "退出(&X)";
            // 
            // btnReSet
            // 
            this.btnReSet.Location = new System.Drawing.Point(474, 228);
            this.btnReSet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReSet.Name = "btnReSet";
            this.btnReSet.Size = new System.Drawing.Size(115, 52);
            this.btnReSet.TabIndex = 18;
            this.btnReSet.Text = "扫描重置";
            this.btnReSet.UseVisualStyleBackColor = true;
            this.btnReSet.Click += new System.EventHandler(this.btnReSet_Click_1);
            // 
            // lblEslId
            // 
            this.lblEslId.AutoSize = true;
            this.lblEslId.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEslId.ForeColor = System.Drawing.Color.Blue;
            this.lblEslId.Location = new System.Drawing.Point(1080, 62);
            this.lblEslId.Name = "lblEslId";
            this.lblEslId.Size = new System.Drawing.Size(54, 28);
            this.lblEslId.TabIndex = 17;
            this.lblEslId.Text = "MSG";
            // 
            // txtScreenCode
            // 
            this.txtScreenCode.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtScreenCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtScreenCode.Location = new System.Drawing.Point(201, 168);
            this.txtScreenCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtScreenCode.Name = "txtScreenCode";
            this.txtScreenCode.Size = new System.Drawing.Size(820, 39);
            this.txtScreenCode.TabIndex = 16;
            this.txtScreenCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtScreenCode_KeyPress);
            // 
            // txtLaserCode
            // 
            this.txtLaserCode.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLaserCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLaserCode.Location = new System.Drawing.Point(201, 54);
            this.txtLaserCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLaserCode.Name = "txtLaserCode";
            this.txtLaserCode.Size = new System.Drawing.Size(820, 39);
            this.txtLaserCode.TabIndex = 15;
            this.txtLaserCode.Enter += new System.EventHandler(this.txtLaserCode_Enter);
            this.txtLaserCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLaserCode_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(56, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 28);
            this.label2.TabIndex = 14;
            this.label2.Text = "屏幕条码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(56, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 28);
            this.label1.TabIndex = 13;
            this.label1.Text = "镭雕条码";
            // 
            // txtMSG
            // 
            this.txtMSG.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMSG.ForeColor = System.Drawing.Color.Blue;
            this.txtMSG.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtMSG.Location = new System.Drawing.Point(61, 315);
            this.txtMSG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMSG.Name = "txtMSG";
            this.txtMSG.Size = new System.Drawing.Size(1058, 39);
            this.txtMSG.TabIndex = 19;
            // 
            // txtMSG1
            // 
            this.txtMSG1.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMSG1.ForeColor = System.Drawing.Color.Blue;
            this.txtMSG1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtMSG1.Location = new System.Drawing.Point(61, 410);
            this.txtMSG1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMSG1.Name = "txtMSG1";
            this.txtMSG1.Size = new System.Drawing.Size(1058, 39);
            this.txtMSG1.TabIndex = 20;
            // 
            // H_SNCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 674);
            this.Controls.Add(this.txtMSG1);
            this.Controls.Add(this.txtMSG);
            this.Controls.Add(this.btnReSet);
            this.Controls.Add(this.lblEslId);
            this.Controls.Add(this.txtScreenCode);
            this.Controls.Add(this.txtLaserCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "H_SNCheck";
            this.Text = "H_SNCheck";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.Button btnReSet;
        private System.Windows.Forms.Label lblEslId;
        private System.Windows.Forms.TextBox txtScreenCode;
        private System.Windows.Forms.TextBox txtLaserCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMSG;
        private System.Windows.Forms.TextBox txtMSG1;
    }
}