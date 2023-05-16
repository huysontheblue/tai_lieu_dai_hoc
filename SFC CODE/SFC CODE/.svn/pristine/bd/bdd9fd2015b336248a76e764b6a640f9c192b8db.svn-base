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
    public partial class FrmSolderPasteManage_bak : Form
    {
        public FrmSolderPasteManage_bak()
        {
            InitializeComponent();
        }

        OP _OP = OP.None;

        #region 窗体加载
        private void FrmSolderPasteManage_Load(object sender, EventArgs e)
        {
            getUpdateTypeName();
            BindComboBox(cmbWait_Option);
            BindComboBox(cmbMixt_Option);
            BindComboBox(cmbMount_Option);
            BindComboBox(cmbUnmount_Option);
            BindComboBox(cmbReturn_Option);
            SetViewMode();
            ControlDetailIsEnable(false);
            DataLoad();
        }
        #endregion

        #region 数据操作状态
        /// <summary>
        /// 数据操作状态
        /// </summary>
        private void  getUpdateTypeName()
        {

            if (_OP == OP.Add) lblOperationSate.Text="新增模式";
            else if (_OP ==OP.Modify) lblOperationSate.Text="编辑模式";
            else lblOperationSate.Text="查看模式";
        }
        #endregion

        #region 查看模式
        /// <summary>
        /// 查看模式
        /// </summary>
        private void SetViewMode()
        {
            toolNew.Enabled = true;
            toolModify.Enabled = true;
            toolDelete.Enabled = true;
            toolSave.Enabled = false;
            toolUndo.Enabled = false;
        }
        #endregion

        #region 编辑模式
        /// <summary>
        /// 编辑模式
        /// </summary>
        private void SetEditMode()
        {
            toolNew.Enabled = false;
            toolModify.Enabled = false;
            toolDelete.Enabled = false;
            toolSave.Enabled = true;
            toolUndo.Enabled = true;
        }
        #endregion

        #region 绑定ComboBox
        /// <summary>
        /// 绑定ComboBox
        /// </summary>
        /// <param name="obj"></param>
        private void BindComboBox(ComboBox obj)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            DataRow dr = dt.NewRow();
            dr[0] = "W";
            dr[1] = "警告";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "U";
            dr[1] = "强制停止执行";
            dt.Rows.Add(dr);
            obj.DataSource = dt;
            obj.ValueMember = "ID";
            obj.DisplayMember = "Name";
            obj.SelectedIndex = 0;
        }
        #endregion

        #region 清空DataGridView数据绑定的文本控件
        /// <summary>
        /// 清空DataGridView数据绑定的文本控件
        /// </summary>
        private void ClearBindText()
        {
            txtSolderNO.Text = string.Empty;
            txtSolderPartNO.Text = string.Empty;
            numWait_Time.Value =1;
            cmbWait_Option.SelectedIndex = 0;
            numMix_Time.Value = 1;
            cmbMixt_Option.SelectedIndex = 0;
            numMount_Time.Value = 1;
            cmbMount_Option.SelectedIndex = 0;
            numUnmount_Time.Value = 1;
            cmbUnmount_Option.SelectedIndex = 0;
            numReturn_Count.Value = 1;
            cmbReturn_Option.SelectedIndex = 0;
        }
        #endregion

        #region 明细控件是否可用
        /// <summary>
        /// 明细控件是否可用
        /// </summary>
        /// <param name="yy"></param>
        private void ControlDetailIsEnable(bool yy)
        {
            txtSolderNO.Enabled = yy;
            txtSolderPartNO.Enabled = yy;
            numWait_Time.Enabled = yy;
            cmbWait_Option.Enabled = yy;
            numMix_Time.Enabled = yy;
            cmbMixt_Option.Enabled = yy;
            numMount_Time.Enabled = yy;
            cmbMount_Option.Enabled = yy;
            numUnmount_Time.Enabled = yy;
            cmbUnmount_Option.Enabled = yy;
            numReturn_Count.Enabled = yy;
            cmbReturn_Option.Enabled = yy;
        }
        #endregion

        #region 显示资料明细
        /// <summary>
        /// 显示资料明细
        /// </summary>
        /// <param name="r"></param>
        private void ShowMaterialDetail(DataGridViewRow r)
        {
            ClearBindText();
            if (r != null)
            {
                txtSolderNO.Text = r.Cells["SolderNO"].Value.ToString();
                txtSolderPartNO.Text = r.Cells["SolderPartNO"].Value.ToString();
                numWait_Time.Value = Convert.ToDecimal(r.Cells["Wait_Time"].Value);
                cmbWait_Option.Text = r.Cells["Wait_OptionN"].Value.ToString();
                numMix_Time.Value = Convert.ToDecimal(r.Cells["Mix_Time"].Value);
                cmbMixt_Option.Text = r.Cells["Mixt_OptionN"].Value.ToString();
                numMount_Time.Value = Convert.ToDecimal(r.Cells["Mount_Time"].Value);
                cmbMount_Option.Text = r.Cells["Mount_OptionN"].Value.ToString();
                numUnmount_Time.Value = Convert.ToDecimal(r.Cells["Unmount_Time"].Value);
                cmbUnmount_Option.Text = r.Cells["Unmount_OptionN"].Value.ToString();
                numReturn_Count.Value = Convert.ToDecimal(r.Cells["Return_Count"].Value);
                cmbReturn_Option.Text = r.Cells["Return_OptionN"].Value.ToString();
            }
        }
        #endregion

        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolNew_Click(object sender, EventArgs e)
        {
            _OP = OP.Add;
            getUpdateTypeName();
            ClearBindText();
            SetEditMode();
            ControlDetailIsEnable(true);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolModify_Click(object sender, EventArgs e)
        {
            _OP = OP.Modify;
            getUpdateTypeName();
            SetEditMode();
            ControlDetailIsEnable(true);
            ShowMaterialDetail(dgvData.CurrentRow);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolDelete_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 提交之前验验证数据的有效性
        /// <summary>
        /// 提交之前验验证数据的有效性
        /// </summary>
        /// <returns></returns>
        private bool CheckValidateData()
        {
            bool yy = true;
            if (string.IsNullOrEmpty(txtSolderNO.Text.Trim()))
            {
                MessageUtils.ShowError("请输入锡膏编号!");
                yy = false;
            }
            else if (string.IsNullOrEmpty(txtSolderPartNO.Text.Trim()))
            {
                MessageUtils.ShowError("请输入锡膏料号");
                yy = false;
            }
            else if (string.IsNullOrEmpty(((UpDownBase)numWait_Time).Text.Trim()))
            {
                MessageUtils.ShowError("请输入回温时间");
                yy = false;
            }
            else if (string.IsNullOrEmpty(((UpDownBase)numMix_Time).Text.Trim()))
            {
                MessageUtils.ShowError("请输入搅拌时间");
                yy = false;
            }
            else if (string.IsNullOrEmpty(((UpDownBase)numMount_Time).Text.Trim()))
            {
                MessageUtils.ShowError("请输入已开封期限时间");
                yy = false;
            }
            else if (string.IsNullOrEmpty(((UpDownBase)numUnmount_Time).Text.Trim()))
            {
                MessageUtils.ShowError("请输入未开封期限时间");
                yy = false;
            }
            else if (string.IsNullOrEmpty(((UpDownBase)numReturn_Count).Text.Trim()))
            {
                MessageUtils.ShowError("请输入回冰时间");
                yy = false;
            }
            return yy;
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSave_Click(object sender, EventArgs e)
        {
            if (CheckValidateData() == false) return;
            try
            {
                string sql = "";
                string SolderNO=txtSolderNO.Text.Trim();
                string SolderPartNO = txtSolderPartNO.Text.Trim();
                decimal  Wait_Time = numWait_Time.Value;
                string Wait_Option = cmbWait_Option.SelectedValue.ToString();
                decimal Mix_Time = numMix_Time.Value;
                string Mixt_Option = cmbMixt_Option.SelectedValue.ToString();
                decimal Mount_Time = numMount_Time.Value;
                string Mount_Option = cmbMount_Option.SelectedValue.ToString();
                decimal Unmount_Time = numUnmount_Time.Value;
                string Unmount_Option = cmbUnmount_Option.SelectedValue.ToString();
                decimal Return_Count = numReturn_Count.Value;
                string Return_Option = cmbReturn_Option.SelectedValue.ToString();
                string UserID = VbCommClass.VbCommClass.UseId;
                string UserName=VbCommClass.VbCommClass.UseName;
                if (_OP == OP.Add)
                {
                    sql =string.Format(@"insert into m_SolderSetUp_t (SolderNO,SolderPartNO,Wait_Time,Wait_Option,
                    Mix_Time,Mixt_Option,Mount_Time,Mount_Option,Unmount_Time,Unmount_Option,
                    Return_Count,Return_Option,InCode,InName,InTime) 
                    values('{0}','{1}',{2},'{3}',{4},'{5}',{6},'{7}'
                    ,{8},'{9}',{10},'{11}','{12}',N'{13}',getdate())"
                    ,SolderNO,SolderPartNO,Wait_Time,Wait_Option,Mix_Time,Mixt_Option
                    ,Mount_Time,Mount_Option,Unmount_Time,Unmount_Option,Return_Count
                    ,Return_Option,UserID,UserName);
                }
                else
                { 
                    
                }
                DbOperateUtils.ExecSQL(sql);
                MessageUtils.ShowInformation("保存成功!");
                DataLoad();
                _OP = OP.None;
                getUpdateTypeName();
                ControlDetailIsEnable(false);
                ShowMaterialDetail(dgvData.CurrentRow);
            }
            catch (Exception ex)
            {
                MessageUtils.ShowError("保存失败:\n"+ex.Message);
            }
        }
        #endregion

        #region 返回或者取消
        /// <summary>
        /// 返回或者取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolUndo_Click(object sender, EventArgs e)
        {
            _OP = OP.None;
            getUpdateTypeName();
            SetViewMode();
            ControlDetailIsEnable(false);
            ShowMaterialDetail(dgvData.CurrentRow);
        }
        #endregion

        #region 清空查询条件
        /// <summary>
        /// 清空查询条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSolderPasteSNO.Text = string.Empty;
            txtSolderPasteSPartNO.Text = string.Empty;
        }
        #endregion

        #region 查询数据
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataLoad();
        }
        #endregion

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataLoad()
        {
            dgvData.AutoGenerateColumns = false;
            string where = " where 1=1 ";
            if (string.IsNullOrEmpty(txtSolderPasteSNO.Text.Trim()) == false)
                where += " and SolderNO like '%" + txtSolderPasteSNO.Text.Trim() + "%'";
            if (string.IsNullOrEmpty(txtSolderPasteSPartNO.Text.Trim()) == false)
                where += " and SolderPartNO like '%" + txtSolderPasteSPartNO.Text.Trim() + "%'";
            where += " order by isnull(UpdateTime,InTime) desc";
            dgvData.DataSource = DbOperateUtils.GetDataTable("select top 200 * from V_m_SolderSetUp_t"+where);
        }
        #endregion

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            ShowMaterialDetail(dgvData.CurrentRow);
        }
    }
}
