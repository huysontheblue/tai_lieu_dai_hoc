using CallSystem;
using MainFrame;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace RouteManagement
{
    public partial class frmSNtoMAC : Form
    {
        public frmSNtoMAC()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            string sn = txtSN.Text;
            string mac = txtMAC.Text;

            string sqlstr = "SELECT top 100 [ID] as 序列号,[SN],[MAC]  FROM [dbo].[ZT_SN_MAC] where 1=1";
            if (sn != null && sn.Trim() != "")
            {
                sqlstr += " and SN='" + sn + "'";
            }
            if (mac != null && mac.Trim() != "")
            {
                sqlstr += " and MAC='" + mac + "'";
            }
            sqlstr += " order by id desc";
            DataTable data = DbOperateUtils.GetDataTable(sqlstr);
            dataGridView1.DataSource = data;
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                //openFileDialog.InitialDirectory="c:\\";//注意这里写路径时要用c:\而不是c:
                openFileDialog.Filter = "Microsoft Excel files(*.xls)|*.xls;*.xlsx";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //OleDbConnection conn = null;
                    //string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source='" + openFileDialog.FileName + "';Extended Properties='Excel 8.0;HDR=Yes;'";
                    ////string strConn = "Provider=Microsoft.Ace.OleDb.12.0;Data Source='" + openFileDialog.FileName + "'";
                    //conn = new OleDbConnection(strConn);
                    //conn.Open();
                    //string strExcel = "";
                    //OleDbDataAdapter myCommand = null;
                    //DataSet ds = null;
                    //strExcel = "select * from [Sheet1$]";
                    //myCommand = new OleDbDataAdapter(strExcel, strConn);
                    //ds = new DataSet();
                    //myCommand.Fill(ds, "Sheet1");
                    //conn.Close();             
                    String errorMsg = "";
                    DataTable dt1 = ExcelUtils.ExportFromExcelByAs(openFileDialog.FileName, 1, 0, 2, ref errorMsg);
                    for (int i = 0; i < dt1.Rows.Count-1; i++)
                    {
                        DataRow dr= dt1.Rows[i];
                        string sn = dr[0].ToString();
                        string mac = dr[1].ToString();
                        string sqlstr = "SELECT [ID] as 序列号,[SN],[MAC]  FROM [dbo].[ZT_SN_MAC] where [SN]='" + sn + "'";
                        DataTable dt= DbOperateUtils.GetDataTable(sqlstr);
                        if (dt != null && dt.Rows.Count > 0)
                        {                            
                           string  sqlstr1 = "update [dbo].[ZT_SN_MAC] set [MAC]='" + mac + "' where [SN]='" + sn + "'";
                            DbOperateUtils.ExecSQL(sqlstr1);
                        }
                        else
                        {
                           string  sqlstr2 = "insert [dbo].[ZT_SN_MAC]([SN],[MAC]) values ('" + sn + "','" + mac + "')";
                            DbOperateUtils.ExecSQL(sqlstr2);
                        }
                    }
                    string sqlstr3 = "SELECT top 100 [ID] as 序列号,[SN],[MAC]  FROM [dbo].[ZT_SN_MAC] order by [ID]  desc";
                    MessageBox.Show("导入成功!");
                    DataTable data1 = DbOperateUtils.GetDataTable(sqlstr3);
                    dataGridView1.DataSource = data1;             
                }
            }
            catch (Exception)
            {
               MessageBox.Show("系统异常,请联系管理员!");
            }
        }
    }
}
