using MainFrame.SysCheckData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RouteManagement
{
    public partial class H_IDCheck : Form
    {
        public H_IDCheck()
        {
            InitializeComponent();
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string wo = "";
        private void txtLaserCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    string sn = txtLaserCode.Text.Trim();
                    //         DataTable dt = new DataTable();
                    //              dt = DbHelperSQL.Query(string.Format(@"select  a.Barcode,a.EslId,a.WorkOrder as workorder_id from HANSHOW.HsDBServer.dbo.ID_ParaCfg a,HANSHOW.ReportDB.dbo.M_SN_HanShow b 
                    //              where b.SN collate Chinese_Taiwan_Stroke_CI_AS=a.Barcode
                    //and a.Barcode='{0}'", sn)).Tables[0];

                    DataTable dt = new DataTable();
                    dt = DbHelperSQL.Query(string.Format(@"	 select  a.Barcode,a.EslId,a.WorkOrder as workorder_id from HANSHOW.HsDBServer.dbo.ID_ParaCfg a
                    where  a.Barcode='{0}'", sn)).Tables[0];


                    if (dt.Rows.Count > 0)
                    {
                        txtLaserCode.Text = dt.Rows[0]["Barcode"].ToString();
                        lblEslId.Text = dt.Rows[0]["EslId"].ToString();
                        wo = dt.Rows[0]["workorder_id"].ToString().Trim();
                    }
                    else
                    {
                        XP1PubServices.setlistBoxMsg(txtLaserCode.Text + " 请进客户系统重新检查条码生产信息", clstMsg);
                        //    dt = DbHelperSQL.Query(string.Format(@"SELECT barcode,eslid,workorder_id from factory_eslidinfo 
                        //where barcode='{0}'", sn)).Tables[0];
                        //    if (dt.Rows.Count > 0)
                        //    {
                        //        txtLaserCode.Text = dt.Rows[0]["Barcode"].ToString();
                        //        lblEslId.Text = dt.Rows[0]["EslId"].ToString();
                        //        wo = dt.Rows[0]["workorder_id"].ToString().Trim();
                        //    }
                    }

                    txtLaserCode.Enabled = false;
                    txtScreenCode.Focus();
                }


            }
            catch (Exception ex)
            {
                XP1PubServices.setlistBoxMsg(ex.Message, clstMsg);
            }
        }

        private void btnReSet_Click(object sender, EventArgs e)
        {
            txtLaserCode.Enabled = true;
            txtLaserCode.Clear();
            txtScreenCode.Clear();
            txtLaserCode.Focus();
            lblEslId.Text = string.Empty;
        }

        private void txtScreenCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                if (txtScreenCode.Text.Trim() == lblEslId.Text)
                {
                    string LaserID = txtLaserCode.Text.Trim();
                    List<string> sqlList = new List<string>();
                    sqlList.Add("delete m_OQCCheckLog_t where Ppid='" + LaserID + "' and Stationid='T00323'");
                    sqlList.Add(string.Format("INSERT INTO m_OQCCheckLog_t(Ppid,UserId,MoId,Stationid,CheckStatu,Codeid) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", txtLaserCode.Text.Trim(), SysMessageClass.UseId, wo, "T00323", "1", ""));                   
                    DbHelperSQL.ExecuteSqlTran(sqlList);
                    XP1PubServices.setlistBoxMsg(txtLaserCode.Text + " ID核对成功", clstMsg);
                    btnReSet_Click(null, null);
                }
                else
                {
                    string msg=txtLaserCode.Text + " ID核对失败";
                    //fIDCheckError iderror = new fIDCheckError(msg);
                    //iderror.ShowDialog();
                    XP1PubServices.setlistBoxMsg(msg, clstMsg);
                    btnReSet_Click(null, null);
                }
            }
        }
    }
}
