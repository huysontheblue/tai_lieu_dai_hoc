using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MainFrame.SysCheckData;

namespace SMTModule
{
    public partial class FrmSteel : Form
    {
        public FrmSteel()
        {
            InitializeComponent();
        }

        private Int16 opflag;


        private void Form1_Load(object sender, EventArgs e)
        {
             //  Erightbutton() '
       // 'LoadDataToCombox()
        LoadDataToDatagridview(" ");
        ToolbtnState(opflag);
        dgvSteel.Enabled = true;
        }


        private void LoadDataToDatagridview(string SqlWhere)
        {
            MainFrame.SysDataHandle.SysDataBaseClass Conn = new MainFrame.SysDataHandle.SysDataBaseClass();
            SqlDataReader Dreader;
            string SqlStr = "";
            try
            {
                dgvSteel.Rows.Clear();
                SqlStr = @"SELECT STENCIL_ID,STATUS " +
                          " ,(a.UserID+'/'+b.UserName)UserID,a.Intime "+
                           " FROM m_STENCIL_t a " +
                           " LEFT JOIN m_users_t  b on a.userid = b.userid  WHERE 1=1 ";

        Dreader = Conn.GetDataReader(SqlStr + SqlWhere + " ORDER BY intime desc");
      //  DbOperateUtils.ExecSQL()
        while (Dreader.Read())
        {
            dgvSteel.Rows.Add(
                          Dreader["STENCIL_ID"].ToString(),
                            Dreader["STATUS"].ToString(),
                             Dreader["UserID"].ToString(),
                             Dreader["Intime"].ToString()
                             );
        }
        Dreader.Close();
        toolStripStatusLabel3.Text = Convert.ToString(this.dgvSteel.Rows.Count);
        Conn = null;
    }
    catch (Exception ex)
    {
        SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmPartPick", "LoadDataToDatagridview", "BasicM");
    }
}

        private void ToolbtnState(Int16 flag)
        {
            switch (flag)
            {
                case 0 :
                    {
                        this.toolAdd.Enabled = true;
                        this.toolEdit.Enabled = true;
                        this.toolAbandon.Enabled = true;
                        this.toolBack.Enabled = false;
                        this.toolSave.Enabled = false;
                        this.toolQuery.Enabled = true;
                        this.txtSTENCIL_ID.Enabled = false;
                       // this.txtPartID.Enabled = false;

                        this.ActiveControl = this.txtSTENCIL_ID;
                        break;
                    }

                case 1:
                case 2:
                    {
                        this.toolAdd.Enabled = false;
                        this.toolEdit.Enabled = false;
                        this.toolAbandon.Enabled = false;
                        this.toolBack.Enabled = true;
                        this.toolSave.Enabled = true;
                        this.toolQuery.Enabled = false;
                        // GroupBox
                       // this.txtPartID.Enabled = true;
                        break;
                    }

                case 3:
                    {
                        this.toolAdd.Enabled = false;
                        this.toolEdit.Enabled = false;
                        this.toolAbandon.Enabled = false;
                        this.toolBack.Enabled = false;
                        this.toolSave.Enabled = false;
                        this.toolQuery.Enabled = true;
                        this.dgvSteel.Enabled = true;
                     //   this.ActiveControl = this.txtPartID;
                        break;
                    }
            }
        }

        private void FileRefresh_Click(object sender, EventArgs e)
        {
            string SqlStr = "";
            if (this.txtSTENCIL_ID.Text != "")
                SqlStr = " AND txtSTENCIL_ID LIKE N'%" + txtSTENCIL_ID.Text.Trim() + "%'";

            if (this.cobStatus.Text != "")
            {
                SqlStr = " AND  Status LIKE '%" + cobStatus.Text.Trim().Substring(0,1) + "%'";
            }

            LoadDataToDatagridview(SqlStr);
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            txtSTENCIL_ID.Text = "";
           // txtPartID.Text = "";
            opflag = 1;
            ToolbtnState(1);
            txtSTENCIL_ID.Enabled = true;
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolBack_Click(object sender, EventArgs e)
        {
            this.txtSTENCIL_ID.Text = "";
          //  txtPartID.Text = "";
            opflag = 0;
            ToolbtnState(0);
        }

        private void toolQuery_Click(object sender, EventArgs e)
        {

        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            MainFrame.SysDataHandle.SysDataBaseClass Conn = new MainFrame.SysDataHandle.SysDataBaseClass();
            StringBuilder SqlStr = new StringBuilder();
            string TreeCount = "";

            //if (false == false)  //Checkdata
            //{
            //    return;
            //}

            if (opflag == 1)
            {
                SqlDataReader mCheckCodeRead = Conn.GetDataReader("SELECT STENCIL_ID FROM m_STENCIL_t WHERE STENCIL_ID='" + this.txtSTENCIL_ID.Text.Trim() + "'");
                if (mCheckCodeRead.HasRows)
                {
                    mCheckCodeRead.Close();
                    MessageBox.Show("该程序名称已经存在！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                mCheckCodeRead.Close();

                //默认为初始状态
                SqlStr.Append(" INSERT into m_STENCIL_t(STENCIL_ID,STATUS ,UserID,Intime,");
                SqlStr.Append(" [FactoryID],[profitcenter],useY) ");
                SqlStr.Append(" VALUES('" + txtSTENCIL_ID.Text.Trim() + "',N'I',  '" + VbCommClass.VbCommClass.UseId + "',getdate(), ");
                SqlStr.Append(" '" + VbCommClass.VbCommClass.Factory + "','" + VbCommClass.VbCommClass.profitcenter + "',1 )");
            }
            else if (opflag == 2)
            {
                //SqlStr.Append(" UPDATE m_STENCIL_t SET PartID =N'" + txtPartID.Text.Trim() + "',Qty =N'1' ");
                //SqlStr.Append(" WHERE STENCIL_ID = '" + txtSTENCIL_ID.Text.Trim() + "'");
            }

            try
            {
                Conn.ExecSql(SqlStr.ToString());
                LoadDataToDatagridview(" ");

                // txtPartID.Text = "";
                opflag = 0;
                ToolbtnState(0);
            }
            catch (Exception ex)
            {
                SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmSteel", "toolSave_Click", "BasicM");
                return;
            }
            finally
            {
                Conn = null;
            }
        }

        private void btnPartEdit_Click(object sender, EventArgs e)
        {

            string strCurrStencilID = dgvSteel.CurrentRow.Cells["SteelNo"].Value.ToString();
            FrmSteelPart frm = new FrmSteelPart(strCurrStencilID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

            //FrmSolderStatus frm = new FrmSolderStatus(btnIceStorage.Text);
            //frm.StartPosition = FormStartPosition.CenterScreen;
            //frm.ShowDialog();
        }

        private void dgvSteel_Click(object sender, EventArgs e)
        {

            string o_strSQL;
            string strSteelNo = "";

            strSteelNo = dgvSteel.CurrentRow.Cells["SteelNo"].Value.ToString();

            o_strSQL = " SELECT PartID FROM m_STENCILPart_t WHERE STENCIL_ID='" + strSteelNo + "'";

            DataTable dt = MainFrame.DbOperateUtils.GetDataTable(o_strSQL);

            if (this.dgvPartList.Rows.Count > 0)
            {
                this.dgvPartList.Rows.Clear();
            }

            //  dgvPartList.DataSource = dt;
            foreach (DataRow datarow in dt.Rows)
            {
              //  ((DataTable)dgvPartList.DataSource).Rows.Add(datarow);
                dgvPartList.Rows.Add(datarow["PartID"]);

            }

        }
    }
}
