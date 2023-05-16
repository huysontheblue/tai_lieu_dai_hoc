using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMTModule
{
    public partial class FrmSolderPasteNumberAdd : Form
    {
        public FrmSolderPasteNumberAdd()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string UserID = VbCommClass.VbCommClass.UseId;
            string UserName = VbCommClass.VbCommClass.UseName;
            try
            {
                if (string.IsNullOrEmpty(txtPartID.Text.Trim()))
                {
                    MainFrame.SysCheckData.MessageUtils.ShowError("请输入料号!");
                    return;
                }
                string sql = string.Format("insert into m_SOLDER_PART (PARTID,INPUT_EMP_ID,InputUserName,UPDATE_TIME) values ('{0}','{1}',N'{2}',getdate())"
                ,txtPartID.Text.Trim(),UserID,UserName);
                MainFrame.DbOperateUtils.ExecSQL(sql);
                MainFrame.SysCheckData.MessageUtils.ShowInformation("保存成功!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MainFrame.SysCheckData.MessageUtils.ShowError("保存失败:\n"+ex.Message);
            }
        }
    }
}
