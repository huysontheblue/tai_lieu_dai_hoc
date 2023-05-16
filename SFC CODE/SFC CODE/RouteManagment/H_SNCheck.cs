using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RouteManagement
{
    public partial class H_SNCheck : Form
    {
        public H_SNCheck()
        {
            InitializeComponent();
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string time = "";
 


        private void txtScreenCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                if (txtScreenCode.Text.Trim() == lblEslId.Text)
                {
                    string LaserID = txtLaserCode.Text.Trim();

                    txtMSG1.Text = txtLaserCode.Text + " SN 核对成功";
                    txtMSG1.ForeColor = Color.Blue;
                    //  btnReSet_Click(null, null);
                }
                else
                {
                    txtMSG1.Text = txtLaserCode.Text  + " SN 核对失败";
                    txtMSG1.ForeColor = Color.Red ;
                    // btnReSet_Click(null, null);
                }
            }

        }

        private void btnReSet_Click_1(object sender, EventArgs e)
        {
            txtLaserCode.Enabled = true;
            txtLaserCode.Clear();
            txtScreenCode.Clear();
            txtLaserCode.Focus();
            lblEslId.Text = string.Empty;
            txtMSG.Clear();
            txtMSG1.Clear();

        }

        private void txtLaserCode_Enter(object sender, EventArgs e)
        {
        }

        private void txtLaserCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    string sn = txtLaserCode.Text.Trim();

                    DataTable dt = new DataTable();
                    dt = DbHelperSQL.Query(string.Format(@"	 select moid, ppid, intime  from m_AssysnD_t where ppid ='{0}'", sn)).Tables[0];


                    if (dt.Rows.Count > 0)
                    {
                        txtLaserCode.Text = dt.Rows[0]["ppid"].ToString();
                        lblEslId.Text = dt.Rows[0]["ppid"].ToString();
                        time = dt.Rows[0]["intime"].ToString().Trim();

                        txtMSG.Text = txtLaserCode.Text + "已过镭雕工站 、过站时间：" + time;
                        txtMSG.ForeColor = Color.Blue;
                        txtScreenCode.Enabled = true;
                    }
                    else
                    {

                        txtMSG.Text = txtLaserCode.Text + "没有过镭雕工站";
                        txtScreenCode.Enabled = false;
                        txtMSG.ForeColor = Color.Red;
                    }

                    txtLaserCode.Enabled = false;

                    txtScreenCode.Focus();
                }


            }
            catch (Exception ex)
            {
                // XP1PubServices.setlistBoxMsg(ex.Message, clstMsg);
            }
        
    }
    }
}
