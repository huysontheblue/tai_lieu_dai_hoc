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
    public partial class FrmScraperAdd : Form
    {
        public FrmScraperAdd()
        {
            InitializeComponent();
        }

        public  OP _OP = OP.None;

        public int SCRAPER_ID { get; set; }

        public FrmScraperAdd(string text)
        {
            InitializeComponent();
            this.Text = text;
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                int a = 1;
                if (string.IsNullOrEmpty(txtSCRAPER_CODE.Text.Trim()))
                {
                    MessageUtils.ShowError("请输入刮刀编号!");
                    return;
                }
                else if (string.IsNullOrEmpty(txtUSED_COUNT.Text.Trim()))
                {
                    MessageUtils.ShowError("请输入使用次数!");
                    return;
                }
                else if (!int.TryParse(txtUSED_COUNT.Text.Trim(),out a))
                {
                    MessageUtils.ShowError("使用次数必须是数字类型");
                    return;
                }
                string SCRAPER_CODE=txtSCRAPER_CODE.Text.Trim();
                string SCRAPER_DESC = txtSCRAPER_DESC.Text.Trim();
                int USED_COUNT = int.Parse(txtUSED_COUNT.Text.Trim());
                string UPDATE_USERID = VbCommClass.VbCommClass.UseId;
                string UPDATE_User = VbCommClass.VbCommClass.UseName;
                if (_OP ==OP.Add)
                {
                    sql = string.Format(@"insert into m_Scraper_t 
                    (SCRAPER_CODE,SCRAPER_DESC,USED_COUNT,UPDATE_USERID,UPDATE_User,UPDATE_TIME) 
                    values('{0}',N'{1}','{2}','{3}',N'{4}',getdate())"
                    ,SCRAPER_CODE,SCRAPER_DESC,USED_COUNT,UPDATE_USERID,UPDATE_User);
                }
                else if (_OP == OP.Modify)
                {
                    sql = string.Format(@"update m_Scraper_t  set SCRAPER_CODE='{1}'
                    , SCRAPER_DESC=N'{2}',USED_COUNT='{3}',UPDATE_USERID='{4}'
                    ,UPDATE_User=N'{5}',UPDATE_TIME=getdate() where SCRAPER_ID={0}"
                    , SCRAPER_ID, SCRAPER_CODE, SCRAPER_DESC, USED_COUNT, UPDATE_USERID, UPDATE_User);
                }
                DbOperateUtils.ExecSQL(sql);
                MessageUtils.ShowInformation("提交成功!");
                this.DialogResult=DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageUtils.ShowError("出现异常:\n"+ex.Message);
            }
        }

        private void FrmScraperAdd_Load(object sender, EventArgs e)
        {
            if (_OP == OP.Modify)
            {
                DataTable dt = DbOperateUtils.GetDataTable("select * from m_Scraper_t where SCRAPER_ID="+this.SCRAPER_ID);
                if (dt.Rows.Count > 0)
                {
                    txtSCRAPER_CODE.Text = dt.Rows[0]["SCRAPER_CODE"].ToString();
                    txtSCRAPER_DESC.Text = dt.Rows[0]["SCRAPER_DESC"].ToString();
                    txtUSED_COUNT.Text = dt.Rows[0]["USED_COUNT"].ToString();
                }
            }
        }
    }
}
