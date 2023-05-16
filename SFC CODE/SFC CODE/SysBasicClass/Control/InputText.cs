using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.WinForms;
using DevComponents.DotNetBar.Controls;
namespace SysBasicClass
{
    public partial class InputText : Form
    {
        MaskedTextBoxAdv _text;
        public InputText()
        {
            InitializeComponent();
        }
        public InputText(MaskedTextBoxAdv ObjText)
        {
            InitializeComponent();
            _text = ObjText;
            StringBuilder str = new StringBuilder();
            if (ObjText.Text.ToString().Trim() != "")
            {
                string[] strarry = ObjText.Text.ToString().Trim().Split(';');
                for (int i = 0; i < strarry.Length; i++)
                {
                    str.Append(strarry[i].ToString().Trim());
                    str.AppendLine();
                }
            }
            textBoxX1.Text = str.ToString();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
            string txt = "";
            if (textBoxX1.Text != "")
            {
                int i = 0;
                for (i = 0; i < textBoxX1.Lines.Length; i++)
                {
                    if (textBoxX1.Lines[i].ToString().Trim() != "")
                    {
                        txt = txt + textBoxX1.Lines[i].ToString().Trim() + ";";
                    }
                }
                txt = txt.Substring(0, txt.Length - 1);
            }
            _text.Text = txt;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
