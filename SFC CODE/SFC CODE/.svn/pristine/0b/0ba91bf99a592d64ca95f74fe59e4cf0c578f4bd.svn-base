using MainFrame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RouteManagement
{
    public partial class FrmCPTestReport : Form
    {
        public FrmCPTestReport()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            string sn = txtSN.Text;
            string mac = txtMAC.Text;
            string starttime = statetimetxt.Value.ToString("yyyy-MM-dd");
            string endtime = endtimetxt.Value.AddDays(1).ToString("yyyy-MM-dd");

            string sqlstr = "SELECT [SN],[MAC],[WiFiMAC],[SystemID],[Widevine],[HDCP1_4],[HDCP2_2],[Prpubkey],[Attestationkeybox],[TestResult],[MOID],[Userid],[QTY],CONVERT(varchar(100),[Intime], 20) AS Intime,[Version]  FROM [dbo].[ZT_TestStationResult] where 1=1";
            if (sn != null && sn.Trim() != "")
            {
                sqlstr += " and SN='" + sn + "'";
            }
            if (mac != null && mac.Trim() != "")
            {
                sqlstr += " and MAC='" + mac + "'";
            }
            if(starttime!=null && starttime.Trim()!="")
            {
                sqlstr += " and [Intime]>='" + starttime + "'";
            }
            if (starttime != null && starttime.Trim() != "")
            {
                sqlstr += " and [Intime]<'" + endtime + "'";
            }
            DataTable data = DbOperateUtils.GetDataTable(sqlstr);
            dataGridView1.DataSource = data;
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            string sn = txtSN.Text;
            string mac = txtMAC.Text;
            string starttime = statetimetxt.Value.ToString("yyyy-MM-dd");
            string endtime = endtimetxt.Value.AddDays(1).ToString("yyyy-MM-dd");

            string sqlstr = "SELECT [SN],[MAC],[WiFiMAC],[SystemID],[Widevine],[HDCP1_4],[HDCP2_2],[Prpubkey],[Attestationkeybox],[TestResult],[MOID],[Userid],[QTY],CONVERT(varchar(100),[Intime], 20) AS Intime,[Version]  FROM [dbo].[ZT_TestStationResult] where 1=1";
            if (sn != null && sn.Trim() != "")
            {
                sqlstr += " and SN='" + sn + "'";
            }
            if (mac != null && mac.Trim() != "")
            {
                sqlstr += " and MAC='" + mac + "'";
            }
            if (starttime != null && starttime.Trim() != "")
            {
                sqlstr += " and [Intime]>='" + starttime + "'";
            }
            if (starttime != null && starttime.Trim() != "")
            {
                sqlstr += " and [Intime]<'" + endtime + "'";
            }

            DataTable data = DbOperateUtils.GetDataTable(sqlstr);            //dataGridView1.DataSource = data;

            ExcelUtils.LoadDataToExcelFromDT(data, "沃尔玛成品测试数据");
        }
    }
}
