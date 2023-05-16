using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMTModule
{
    public partial class FrmSolderPasteNumberSetting : Form
    {
        public FrmSolderPasteNumberSetting()
        {
            InitializeComponent();
        }

        private void FrmSolderPasteNumberSetting_Load(object sender, EventArgs e)
        {
            tsmiComboCondition.SelectedIndex = 1;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            FrmSolderPasteNumberAdd add = new FrmSolderPasteNumberAdd();
            DialogResult dr=add.ShowDialog();
            if (dr == DialogResult.OK)
            {
                DataLoad();
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataLoad()
        {
            string where = " where 1=1 ";
            if (tsmiComboCondition.SelectedIndex ==1)
                where += " and ENABLED='Y'";
            if (tsmiComboCondition.SelectedIndex == 2)
                where += " and ENABLED='N'";
            if (!string.IsNullOrEmpty(txtSPartID.Text.Trim()))
                where += " and PARTID like '%" + txtSPartID.Text.Trim() + "%'";
            if (!string.IsNullOrEmpty(txtSUserName.Text.Trim()))
                where += " and InputUserName=N'" + txtSUserName.Text.Trim() + "'";
            dgvData.AutoGenerateColumns = false;
            dgvData.DataSource = MainFrame.DbOperateUtils.GetDataTable("select * from m_SOLDER_PART"+where);
        }

        private void tsmiComboCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiExportOut_Click(object sender, EventArgs e)
        {
            DataTable dt = MainFrame.DbOperateUtils.GetDataTable("select PARTID,ENABLED,InputUserName,UPDATE_TIME from m_SOLDER_PART");
            string [] ay={"料号","是否可用","员工","更新时间"};
           VbCommClass.NPOIExcle.DataTableExportToExcle(dt,ay, "锡膏料号设定.xls");
        }

        /// <summary>
        /// 停用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiStop_Click(object sender, EventArgs e)
        {
            string PARTID = dgvData.CurrentRow.Cells["PARTID"].Value.ToString();
            if (MainFrame.SysCheckData.MessageUtils.ShowConfirm("确定要停用料号:" + PARTID, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                MainFrame.DbOperateUtils.ExecSQL("update m_SOLDER_PART set ENABLED='N' where PARTID='" + PARTID + "'");
                MainFrame.SysCheckData.MessageUtils.ShowInformation("料号:" + PARTID + "停用成功！");
                DataLoad();
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataLoad();
        }
    }
}
