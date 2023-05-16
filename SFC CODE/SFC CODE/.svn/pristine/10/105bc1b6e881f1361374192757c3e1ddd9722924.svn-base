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
    public partial class Frmfeeder : Form
    {
        public Frmfeeder()
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

              //  I(Initial入庫),P(Pick Up領用),U(Up上？),D(Down下？),R(Repair維修),M(Maintenance保養),B(Back歸還),S(Scrap報廢)

                dgvSteel.Rows.Clear();
                SqlStr = @"SELECT FEEDER_ID,(Case STATUS When 'I' then N'I.入库' when 'P' then N'领用' when 'U' then N'U.上线' When 'D' then 'D.下线' when 'R' then N'R.维修' when 'M'then N'M.保养' when 'B' then N'归还' when 'S' then N'报废' End) STATUS  " +
                          " ,(a.UserID+'/'+b.UserName)UserID,a.Intime,FeederType, WarnCount, MaxUseCount, WarnDays, MaxUseDays, MaxKeepCount  " +
                           " FROM m_FEEDER_t a " +
                           " LEFT JOIN m_users_t  b on a.userid = b.userid  WHERE 1=1 ";

        Dreader = Conn.GetDataReader(SqlStr + SqlWhere + " ORDER BY intime desc");
      //  DbOperateUtils.ExecSQL()
        while (Dreader.Read())
        {
            dgvSteel.Rows.Add(
                          Dreader["FEEDER_ID"].ToString(),
                            Dreader["STATUS"].ToString(),
                               Dreader["FeederType"].ToString(),
                                  Dreader["WarnCount"].ToString(),
                                   Dreader["MaxUseCount"].ToString(),
                                Dreader["WarnDays"].ToString(),
                                 Dreader["MaxUseDays"].ToString(),
                                     Dreader["MaxKeepCount"].ToString(),
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
                        this.txtFeeder_ID.Enabled = false;
                       // this.txtPartID.Enabled = false;

                        this.ActiveControl = this.txtFeeder_ID;
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
            if (this.txtFeeder_ID.Text != "")
                SqlStr = " AND FEEDER_ID LIKE N'%" + txtFeeder_ID.Text.Trim() + "%'";

            if (this.cobStatus.Text != "")
            {
                SqlStr = " AND  Status LIKE '%" + cobStatus.Text.Trim().Substring(0,1) + "%'";
            }

            LoadDataToDatagridview(SqlStr);
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            txtFeeder_ID.Text = "";
           // txtPartID.Text = "";
            opflag = 1;
            ToolbtnState(1);
            txtFeeder_ID.Enabled = true;
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolBack_Click(object sender, EventArgs e)
        {
            this.txtFeeder_ID.Text = "";
          //  txtPartID.Text = "";
            opflag = 0;
            ToolbtnState(0);
        }

        private void toolQuery_Click(object sender, EventArgs e)
        {
            this.txtFeeder_ID.Text = "";
            this.txtFeeder_ID.Enabled = true;
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
                SqlDataReader mCheckCodeRead = Conn.GetDataReader("SELECT FEEDER_ID FROM m_FEEDER_t WHERE FEEDER_ID='" + this.txtFeeder_ID.Text.Trim() + "'");
                if (mCheckCodeRead.HasRows)
                {
                    mCheckCodeRead.Close();
                    MessageBox.Show("该飞达编号已经存在！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                mCheckCodeRead.Close();

                //默认为初始状态
                SqlStr.Append(" INSERT into m_FEEDER_t(FEEDER_ID,STATUS ,UserID,Intime,");
                SqlStr.Append(" FactoryID,profitcenter,useY, FeederType, WarnCount, MaxUseCount,WarnDays, MaxUseDays, MaxKeepCount ) ");
                SqlStr.Append(" VALUES('" + txtFeeder_ID.Text.Trim() + "',N'I',  '" + VbCommClass.VbCommClass.UseId + "',getdate(), ");
                SqlStr.Append(" '" + VbCommClass.VbCommClass.Factory + "','" + VbCommClass.VbCommClass.profitcenter + "',1, ");
                SqlStr.Append("  '"+ txtFeederType.Text.Trim() +"','"+ txtWarnCount.Text.Trim() +"','"+ txtMaxUseCount.Text.Trim() +"','"+ txtWarnDays.Text.Trim() +"','"+ txtMaxUseDays.Text.Trim() +"','"+txtMaxKeepCount.Text.Trim() +"')");
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
                SysMessageClass.WriteErrLog(ex, "BasicManagement.Frmfeeder", "toolSave_Click", "BasicM");
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


    }
}
