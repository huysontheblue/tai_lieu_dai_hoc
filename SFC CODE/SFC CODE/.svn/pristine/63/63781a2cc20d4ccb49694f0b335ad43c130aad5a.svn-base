using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MainFrame;
using MainFrame.SysCheckData;
using System.Data.SqlClient;

namespace SMTModule
{
    public partial class FrmSolderPasteSetting : Form
    {
        string g_sExeName, g_sProgram, g_sFunction;
        string g_sParam, g_sUserID;
        string sSQL;
        DataSet dsTemp;
        string part_id;
        public FrmSolderPasteSetting()
        {
            InitializeComponent();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            //g_sUserID = ClientUtils.UserPara1;
            //g_sExeName = ClientUtils.fCurrentProject;
            //g_sFunction = ClientUtils.fFunctionName;
            //g_sProgram = ClientUtils.fProgramName;
            part_id = "";

            comboWait.SelectedIndex = 0;
            combomount.SelectedIndex = 0;
            combounmount.SelectedIndex = 0;
            comboDate.SelectedIndex = 0;
            combocount.SelectedIndex = 0;
            combFilter.Items.Clear();
            sSQL = "  SELECT  DISTINCT PARTID FROM m_SOLDER_PART where ENABLED='Y'";
            DataSet dstemp =DbOperateUtils.GetDataSet(sSQL);
            for (int i = 0; i < dstemp.Tables[0].Rows.Count; i++)
            {
                combFilter.Items.Add(dstemp.Tables[0].Rows[i][0].ToString());
            }
            if (combFilter.Items.Count > 0)
                combFilter.SelectedIndex = 0;
                //check_privilege();
        }

        //public void check_privilege()
        //{
        //    int iPrivilege = ClientUtils.GetPrivilege(g_sUserID, g_sFunction, g_sProgram);
        //    btnOK.Enabled = (iPrivilege >= 1);
        //}

        
        public void show_data(string Part_Id)
        {

            sSQL = @"Select * from m_SolderSetUp_t  where PART_ID ='" + Part_Id + "'";
            dsTemp =DbOperateUtils.GetDataSet(sSQL);
            if (dsTemp.Tables[0].Rows.Count > 0)
            {
                editWait.Text = dsTemp.Tables[0].Rows[0]["WAIT_TIME"].ToString();
                editmount.Text = dsTemp.Tables[0].Rows[0]["MOUNT_TIME"].ToString();
                editunmount.Text = dsTemp.Tables[0].Rows[0]["UNMOUNT_TIME"].ToString();
                editcount.Text = dsTemp.Tables[0].Rows[0]["RETURN_COUNT"].ToString();
                editMixTime.Text = dsTemp.Tables[0].Rows[0]["MIX_MIN"].ToString();
                if (dsTemp.Tables[0].Rows[0]["WAIT_OPTION"].ToString() == "U")
                {
                    comboWait.SelectedIndex = 1;
                }
                else
                {
                    comboWait.SelectedIndex = 0;
                }
                if (dsTemp.Tables[0].Rows[0]["MOUNT_OPTION"].ToString() == "U")
                {
                    combomount.SelectedIndex = 1;
                }
                else
                {
                    combomount.SelectedIndex = 0;
                }
                if (dsTemp.Tables[0].Rows[0]["UNMOUNT_OPTION"].ToString() == "U")
                {
                    combounmount.SelectedIndex = 1;
                }
                else
                {
                    combounmount.SelectedIndex = 0;
                }
                if (dsTemp.Tables[0].Rows[0]["RETURN_OPTION"].ToString() == "U")
                {
                    combocount.SelectedIndex = 1;
                }
                else
                {
                    combocount.SelectedIndex = 0;
                }
                if (dsTemp.Tables[0].Rows[0]["DATECODE_OPTION"].ToString() == "U")
                {
                    comboDate.SelectedIndex = 1;
                }
                else
                {
                    comboDate.SelectedIndex = 0;
                }
                if (dsTemp.Tables[0].Rows[0]["MIX_OPTION"].ToString() == "U")
                {
                    comboMixTime.SelectedIndex = 1;
                }
                else
                {
                    comboMixTime.SelectedIndex = 0;
                }
            }
            else
            {
                editWait.Text = "0";
                editmount.Text = "0";
                editunmount.Text = "0";
                editcount.Text = "0";
                editMixTime.Text = "0";
                comboWait.SelectedIndex = 0;
                comboMixTime.SelectedIndex = 0;
                combomount.SelectedIndex = 0;
                combounmount.SelectedIndex = 0;
                combocount.SelectedIndex = 0;
                comboDate.SelectedIndex = 0;
            }


        }

        private void btnapprove_Click(object sender, EventArgs e)
        {
            if (combFilter.SelectedItem.ToString()=="")
            {
                MessageUtils.ShowError("请选择锡膏料号!");
                return;
            }
            if (string.IsNullOrEmpty(editWait.Text))
            {
                MessageUtils.ShowError("请输入回温时间!");
               
                return;
            }
            if (string.IsNullOrEmpty(editMixTime.Text))
            {
                MessageUtils.ShowError("请输入搅拌时间!");

                return;
            }
            if (string.IsNullOrEmpty(editmount.Text))
            {
                MessageUtils.ShowError("请输入已开封期限时间!");
                return;
            }
            if (string.IsNullOrEmpty(editunmount.Text))
            {
                MessageUtils.ShowError("请输入未开封期限时间!");
                return;
            }
            if (string.IsNullOrEmpty(editcount.Text))
            {
                MessageUtils.ShowError("请输入回冰次数!");
                return;
            }
            if (comboWait.SelectedItem.ToString() == "")
            {
                MessageUtils.ShowError("请输入回温选项!");
                return;
            }
            if (combomount.SelectedItem.ToString() == "")
            {
                MessageUtils.ShowError("请输入已开封期限选项!");
                return;
            }
            if (combounmount.SelectedItem.ToString() == "")
            {
                MessageUtils.ShowError("请输入未开封期限选项!");
                return;
            }
            if (combocount.SelectedItem.ToString() == "")
            {
                MessageUtils.ShowError("请输入回冰次数选项!");
                return;
            }
            if (comboDate.SelectedItem.ToString() == "")
            {
                MessageUtils.ShowError("请输入日期代码选项!");
                return;
            }
            if(comboMixTime.SelectedItem.ToString()=="")
            {
                MessageUtils.ShowError("请输入搅拌选项!");
                return;
            }
            sSQL = "select part_id from m_SolderSetUp_t where part_id='"+part_id+"'";
            DataSet dstemp =DbOperateUtils.GetDataSet(sSQL);
            if (dsTemp.Tables[0].Rows.Count > 0)
            {
                ModifyData(part_id);
            }
            else
            {
                AppendData(part_id);
            }

            MessageUtils.ShowInformation("数据保存成功!");
            show_data(part_id);
        }
        private void AppendData(string Part)
        {
            string sDateOption = "W";
            string sCountOption = "W";
            string sMountOption = "W";
            string sUnMountOption = "W";
            string sWaitOption = "W";
            string sMixOption = "W";
            if (comboDate.SelectedIndex == 1)
            {
                sDateOption = "U";
            }
            if (combocount.SelectedIndex == 1)
            {
                sCountOption = "U";
            }
            if (combomount.SelectedIndex == 1)
            {
                sMountOption = "U";
            }
            if (combounmount.SelectedIndex == 1)
            {
                sUnMountOption = "U";
            }
            if (comboWait.SelectedIndex == 1)
            {
                sWaitOption = "U";
            }
            if (comboMixTime.SelectedIndex == 1)
            {
                sMixOption = "U";
            }


            
            sSQL = " Insert into m_SolderSetUp_t "
                 + " (part_id,WAIT_TIME,WAIT_OPTION,DATECODE_OPTION,RETURN_COUNT,RETURN_OPTION,MOUNT_TIME,MOUNT_OPTION"
                 + " ,UNMOUNT_TIME,UNMOUNT_OPTION,UPDATE_TIME,UPDATE_USERID,MIX_MIN,MIX_OPTION) "
                 + " Values "
                 + " (@part_id,@WAIT_TIME,@WAIT_OPTION,@DATECODE_OPTION,@RETURN_COUNT,@RETURN_OPTION,@MOUNT_TIME,@MOUNT_OPTION"
                 + " ,@UNMOUNT_TIME,@UNMOUNT_OPTION,getdate(),@UPDATE_USERID,@MIX_MIN,@MIX_OPTION) ";


            SqlParameter [] Params ={
                new SqlParameter("@part_id",Part),
                new SqlParameter("@WAIT_TIME",editWait.Text.Trim()),
                new SqlParameter("@WAIT_OPTION",sWaitOption),
                new SqlParameter("@DATECODE_OPTION",sDateOption),
                new SqlParameter("@RETURN_COUNT",editcount.Text.Trim()),
                new SqlParameter("@RETURN_OPTION",sCountOption),
                new SqlParameter("@MOUNT_TIME",editmount.Text.Trim()),
                new SqlParameter("@MOUNT_OPTION",sMountOption),
                new SqlParameter("@UNMOUNT_TIME",editunmount.Text.Trim()),
                new SqlParameter("@UNMOUNT_OPTION",sUnMountOption),
                new SqlParameter("@UPDATE_USERID",VbCommClass.VbCommClass.UseId),
                new SqlParameter("@MIX_MIN",editMixTime.Text),
                new SqlParameter("@MIX_OPTION",sMixOption)
            };
            string result=DbOperateUtils.ExecSqlAddParameter(sSQL, Params);
        }
        private void  ModifyData(string Part)
        {
            string sDateOption = "W";
            string sCountOption = "W";
            string sMountOption = "W";
            string sUnMountOption = "W";
            string sWaitOption = "W";
            string sMixOption = "W";
            if (comboDate.SelectedIndex == 1)
            {
                sDateOption = "U";
            }
            if (combocount.SelectedIndex == 1)
            {
                sCountOption = "U";
            }
            if (combomount.SelectedIndex == 1)
            {
                sMountOption = "U";
            }
            if (combounmount.SelectedIndex == 1)
            {
                sUnMountOption = "U";
            }
            if (comboWait.SelectedIndex == 1)
            {
                sWaitOption = "U";
            }
            if (comboMixTime.SelectedIndex == 1)
            {
                sMixOption = "U";
            }

            sSQL = " Update m_SolderSetUp_t "
                 + " set WAIT_TIME = @WAIT_TIME "
                 + "    ,WAIT_OPTION = @WAIT_OPTION "
                 + "    ,DATECODE_OPTION =@DATECODE_OPTION "
                 + "    ,RETURN_COUNT = @RETURN_COUNT "
                 + "    ,RETURN_OPTION =@RETURN_OPTION "
                 + "    ,MOUNT_TIME =@MOUNT_TIME "
                 + "    ,MOUNT_OPTION =@MOUNT_OPTION "
                 + "    ,UNMOUNT_TIME =@UNMOUNT_TIME "
                 + "    ,UNMOUNT_OPTION =@UNMOUNT_OPTION "
                 + "    ,UPDATE_TIME =getdate()"
                 + "    ,UPDATE_USERID =@UPDATE_USERID "
                 + "    ,MIX_MIN =@MIX_MIN"
                 + "    ,MIX_OPTION =@MIX_OPTION"
                 +"    where part_id=@part_id";

            SqlParameter [] Params ={
                 new SqlParameter("@WAIT_TIME",editWait.Text.Trim()),
                 new SqlParameter("@WAIT_OPTION",sWaitOption),
                 new SqlParameter("@DATECODE_OPTION",sDateOption),
                 new SqlParameter("@RETURN_COUNT",editcount.Text.Trim()),
                 new SqlParameter("@RETURN_OPTION",sCountOption),
                 new SqlParameter("@MOUNT_TIME",editmount.Text.Trim()),
                 new SqlParameter("@MOUNT_OPTION",sMountOption),
                 new SqlParameter("@UNMOUNT_TIME",editunmount.Text.Trim()),
                 new SqlParameter("@UNMOUNT_OPTION",sUnMountOption),
                 new SqlParameter("@UPDATE_USERID",VbCommClass.VbCommClass.UseId),
                 new SqlParameter("@MIX_MIN",editMixTime.Text.Trim()),
                 new SqlParameter("@MIX_OPTION",sMixOption),
                 new SqlParameter("@part_id",Part)
            };
            DbOperateUtils.ExecSqlAddParameter(sSQL, Params);

            //CopyToHistory();

        }
        //private void CopyToHistory()
        //{
        //    sSQL = "select part_id from sajet.sys_part where part_no='" + combFilter.SelectedItem.ToString() + "'";
        //    DataSet dstemp = ClientUtils.ExecuteSQL(sSQL);
        //    string part_id = dstemp.Tables[0].Rows[0][0].ToString();
        //    sSQL = " Insert into SAJET.SYS_HT_SOLDER_SETUP "
        //         + " Select * from SAJET.SYS_SOLDER_SETUP  where part_id="+part_id;
        //    DataSet dsTemp = ClientUtils.ExecuteSQL(sSQL);

        //}

        private void btncancel_Click(object sender, EventArgs e)
        {
            show_data(part_id);
            return;
        }

        private void combFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (combFilter.SelectedIndex > -1)
            {
                string select = combFilter.SelectedItem.ToString();
                sSQL = "select PARTID from m_SOLDER_PART where PARTID='" + combFilter.SelectedItem.ToString() + "'";
                DataSet dstemp=DbOperateUtils.GetDataSet(sSQL);
                part_id = dstemp.Tables[0].Rows[0][0].ToString();
                show_data(part_id);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}