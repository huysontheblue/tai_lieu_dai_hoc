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
    public partial class FrmScraperManage : Form
    {
        public FrmScraperManage()
        {
            InitializeComponent();
        }

        private void FrmScraperManage_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void DataLoad()
        {
            string sql =@"select a.[SCRAPER_ID],a.[SCRAPER_CODE],a.[SCRAPER_DESC]
            ,a.[USED_COUNT],a.[UPDATE_USERID],a.[UPDATE_TIME]
            ,a.[ENABLED],a.[STATUS],case 
            when [STATUS]='I' then N'初始'
            when [STATUS]='P' then N'领用'
            when [STATUS]='S' then N'报废'
            end STATUSN,[UPDATE_User] from m_Scraper_t a";
           DataTable dt=DbOperateUtils.GetDataTable(sql);
           dgvData.AutoGenerateColumns = false;
           dgvData.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void toolNew_Click(object sender, EventArgs e)
        {
            FrmScraperAdd add = new FrmScraperAdd("新增刮刀");
            add._OP = OP.Add;
           DialogResult dr=add.ShowDialog();
           if (dr == DialogResult.OK)
           {
               DataLoad();
           }
        }

        private void toolModify_Click(object sender, EventArgs e)
        {
            FrmScraperAdd add = new FrmScraperAdd("编辑刮刀");
            add._OP = OP.Modify;
            add.SCRAPER_ID = Convert.ToInt32(dgvData.CurrentRow.Cells["SCRAPER_ID"].Value);
           DialogResult dr=add.ShowDialog();
           if (dr == DialogResult.OK)
           {
               DataLoad();
           }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            int SCRAPER_ID = Convert.ToInt32(dgvData.CurrentRow.Cells["SCRAPER_ID"].Value);
            DbOperateUtils.ExecSQL("update m_Scraper_t set ENABLED='N' where SCRAPER_ID=" + SCRAPER_ID);
            DataLoad();
        }

        private void toolExport_Click(object sender, EventArgs e)
        {
             string sql =@"select a.[SCRAPER_CODE],a.[SCRAPER_DESC]
            ,a.[USED_COUNT],a.[UPDATE_USERID],a.[UPDATE_TIME]
            ,a.[ENABLED],case 
            when [STATUS]='I' then N'初始'
            when [STATUS]='P' then N'领用'
            when [STATUS]='S' then N'报废'
            end STATUSN,[UPDATE_User] from m_Scraper_t a";
           DataTable dt=DbOperateUtils.GetDataTable(sql);
           string[] ay = {"刮刀编号","描述","使用次数","工号","时间","有效否","状态","姓名"};
           VbCommClass.NPOIExcle.DataTableExportToExcle(dt,ay, "刮刀.xls");
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
