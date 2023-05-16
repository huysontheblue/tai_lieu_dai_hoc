using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SysBasicClass
{
    public partial class waitForm : Form
    {
        public waitForm(string strWait)
        {
            InitializeComponent();
            if (strWait == "")
            {
                strWait = "数据处理进行中...";
            }
            SetText(strWait);
        }
        private delegate void SetTextHandler(string text);
        public void SetText(string text)
        {
            if (this.label1.InvokeRequired)
            {
                this.Invoke(new SetTextHandler(SetText), text);
            }
            else
            {
                if (text == "close")
                    this.Close();
                else
                    this.label1.Text = text;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
