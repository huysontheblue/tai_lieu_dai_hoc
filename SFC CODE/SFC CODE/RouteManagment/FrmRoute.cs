
//--工艺流程设置
//--Create by :　马锋
//--Create date :　2015/03/31
//--Update date :  
//--
//--Ver : V01

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MainFrame.SysDataHandle;
using MainFrame.SysCheckData;

namespace RouteManagement
{
    public partial class FrmRoute : Form
    {
        public int opFlag = 0;
        public string routeId = string.Empty;

        public FrmRoute()
        {
            InitializeComponent();
        }

        #region "窗体事件"

        private void FrmRoute_Load(object sender, EventArgs e)
        {
            try
            {
                SetStatus(opFlag);
                LoadControlData();
            }
            catch
            {
                MessageBox.Show("工艺流程载入异常");
            }
        }

        #endregion

        #region "菜单事件"

        private void ToolNew_Click(object sender, EventArgs e)
        {

        }

        private void ToolEdit_Click(object sender, EventArgs e)
        {

        }

        private void ToolCommit_Click(object sender, EventArgs e)
        {

        }

        private void ToolBack_Click(object sender, EventArgs e)
        {

        }

        private void ToolQuery_Click(object sender, EventArgs e)
        {

        }

        private void ToolComfire_Click(object sender, EventArgs e)
        {

        }

        private void ToolAbandon_Click(object sender, EventArgs e)
        {

        }

        private void ToolRecovery_Click(object sender, EventArgs e)
        {

        }

        private void ToolExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch
            {
                MessageBox.Show("关闭流程设置异常!");
            }
        }

        #endregion

        #region "控件事件"

        private void btnStationQuery_Click(object sender, EventArgs e)
        {
            LoadData(SQLScript.GetRouteQuery(this.txtStationName.Text.Trim(), ""), this.dgvRouteList);
        }

        #endregion

        #region "方法"

        private void LoadControlData()
        {
            LoadComboxData(SQLScript.GetSortSetQuery("StationType"), this.cbbStationType, "SORTNAME", "SortID", true);
            LoadData(SQLScript.GetRouteQuery("", ""), this.dgvRouteList);
            LoadData(SQLScript.GetStationQuery("", ""), this.dgvStationList);
        }

        private void LoadComboxData(string strSQL, ComboBox cbbControl, string DisplayColumn, string ValueColumn, bool bAll)
        {
            MainFrame.SysDataHandle.SysDataBaseClass connSQL = new SysDataBaseClass();
            DataTable dtTemp = null;
            try
            {
                if (string.IsNullOrEmpty(strSQL))
                {
                    return;
                }
                dtTemp = connSQL.GetDataTable(strSQL);
                cbbControl.Items.Clear();

                if (dtTemp != null)
                {
                    if (bAll)
                    {
                        DataRow drTemp = dtTemp.NewRow();
                        drTemp[0] = "ALL";
                        drTemp[1] = "ALL";
                        dtTemp.Rows.InsertAt(drTemp, 0);
                    }

                    cbbControl.DataSource = dtTemp;
                    cbbControl.DisplayMember = DisplayColumn;
                    cbbControl.ValueMember = ValueColumn;
                }

                connSQL.PubConnection.Close();
            }
            catch
            {
                connSQL.PubConnection.Close();
            }
        }

        private void LoadData(string strSQL, DataGridView dgvControl)
        {
            MainFrame.SysDataHandle.SysDataBaseClass connSQL = new SysDataBaseClass();
            SqlDataReader DReader = null;
            try
            {
                //dtStation = connSQL.GetDataTable(GetStationQuery("", ""));
                dgvControl.Rows.Clear();
                DReader = connSQL.GetDataReader(strSQL);

                while (DReader.Read())
                {
                    if (dgvControl.Name=="dgvStationList")
                    {
                        dgvControl.Rows.Add(DReader["STATIONID"].ToString(), DReader["STATIONNAME"].ToString(), DReader["STATIONTYPE"].ToString(), DReader["STATIONDEST"].ToString());
                    }

                    if (dgvControl.Name=="dgvRouteList")
                    {
                        dgvControl.Rows.Add(DReader["RouteID"].ToString(), DReader["RouteName"].ToString(), DReader["RouteTypeID"].ToString(), DReader["Descr"].ToString(), DReader["UpdateTime"].ToString(), DReader["ActiveFlag"].ToString(), DReader["ActiveFlag"].ToString());
                    }
                }

                DReader.Close();
                connSQL.PubConnection.Close();
            }
            catch
            {
                if (DReader.IsClosed)
                {
                    DReader.Close();
                }
                connSQL.PubConnection.Close();
            }
        }

         //狀態顯示
        private void SetStatus(int Flag)
        {
            switch (Flag)
            {
                case 0:    //初始
                    this.ToolNew.Enabled = true;
                    this.ToolEdit.Enabled = true;
                    this.ToolCommit.Enabled = false;
                    this.ToolBack.Enabled = false;
                    this.ToolQuery.Enabled = true;
                    this.ToolComfire.Enabled = true;
                    this.ToolAbandon.Enabled = true;
                    this.ToolRecovery.Enabled = true;                    

                    this.txtRouteName.Text = "";
                    this.cbbRouteVersion.Text = "";
                    this.txtDescr.Text = "";
                    this.txtActiveFlag.Text = "";

                    this.txtRouteName.Enabled = false;
                    this.cbbRouteVersion.Enabled = false;
                    this.txtDescr.Enabled = false;
                    break;
                case 1:    //修改
                    this.ToolNew.Enabled = false;
                    this.ToolEdit.Enabled = false;
                    this.ToolCommit.Enabled = true;
                    this.ToolBack.Enabled = true;
                    this.ToolQuery.Enabled = false;
                    this.ToolComfire.Enabled = false;
                    this.ToolAbandon.Enabled = false;
                    this.ToolRecovery.Enabled = false;

                    this.txtRouteName.Enabled = true;
                    this.cbbRouteVersion.Enabled = true;
                    this.txtDescr.Enabled = true;
                    break;
                default:  //缺省
                    this.ToolNew.Enabled = false;
                    this.ToolEdit.Enabled = false;
                    this.ToolCommit.Enabled = false;
                    this.ToolBack.Enabled = false;
                    this.ToolQuery.Enabled = false;
                    this.ToolComfire.Enabled = false;
                    this.ToolAbandon.Enabled = false;
                    this.ToolRecovery.Enabled = false;

                    break;
            }
        }

        #endregion

    }
}
