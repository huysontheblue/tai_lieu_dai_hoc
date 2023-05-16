using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MainFrame;
using MainFrame.SysCheckData;

namespace SMTModule
{
    public partial class FrmSolderList : Form
    {
        public FrmSolderList()
        {
            InitializeComponent();
        }

        private void ToolReflsh_Click(System.Object sender, System.EventArgs e)
        {
            //string StartDT = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss");
            //string EndDT = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss");
            string strSolderNo = string.Empty;
            string strStatus= string.Empty;
            string PPartID = string.Empty;
            string PackBarcode = string.Empty;
            string ChildBarcode = string.Empty;
            string ChildPartID = string.Empty;
            string strLineID = string.Empty;

            DataGridView1.DataSource = null; // Add by cq 20160701
            string strSql = "";

            strSolderNo = this.txtSolderNO.Text.Trim();

            if (CobStatus.Text != "" & CobStatus.Text != "ALL")
            {
                strStatus = CobStatus.Text.Trim();
            }

            if (CobLineID.Text != "" & CobLineID.Text != "ALL")
            {
                strLineID = CobLineID.Text.Trim();
            }
            // @begintime   varchar(25),  --起始時間  
            // @endtime     varchar(25),  --終止時間  
            // @moid        varchar(30),   --工單編號   
            // @PartID     varchar(20) --线别  
            strSql = "EXEC m_QuerySolderData_p '" + strSolderNo + "','" + strStatus + "'," + "'" + strLineID + "'";
            DataTable dt = DbOperateReportUtils.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                ToolCount.Text = Convert.ToString(dt.Rows.Count);
                DataGridView1.DataSource = dt;
            }
            else
            {
               // Interaction.MsgBox("未查询到相关信息！", MsgBoxStyle.DefaultButton1, "提示信息");

                MessageUtils.ShowInformation("未查询到相关信息！");
            }
        }

    }
}
