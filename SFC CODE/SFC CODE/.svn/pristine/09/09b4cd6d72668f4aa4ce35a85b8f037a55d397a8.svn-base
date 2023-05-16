using MainFrame.SysCheckData;
using MainFrame.SysDataHandle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RouteManagement
{
    public partial class FrmDbDictionary : Form
    {
        public FrmDbDictionary()
        {
            InitializeComponent();
        }

        SysDataBaseClass conn = new SysDataBaseClass();

        #region 退出
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
        #endregion

        private void FrmDbDictionary_Load(object sender, EventArgs e)
        {
            LoadTable();
            LoadDataToTableName(" ");
        }

        #region 加载表信息
        private void LoadTable()
        {
            //            string insertSql = @"insert into m_MesTable_t (tabName)
            //                        select  name from sysobjects a where xtype ='u'  and name not like '%[0-9]%' 
            //                        and name not in (select tabName from m_MesTable_t) ";
            //2018/1/25 帅选临时表 更新表
            string insertSql = @"insert into m_MesTable_t (tabName)
                           select  name from sysobjects a where xtype ='u'  and name not like '%[0-9]%' and name not like '%bak'
                           and name not in (select tabName from m_MesTable_t) 
                           delete  from m_MesTable_t 
                           where tabName not in (select  name from sysobjects a where xtype ='u'  and name not like '%[0-9]%' and name not like '%bak' )";
            try
            {
                conn.ExecSql(insertSql);
            }
            catch (Exception ex)
            {
                SysMessageClass.WriteErrLog(ex, "RouteManagement.FrmDbDictionary", "LoadTable", "sys");
            }
        }
        #endregion

        #region 显示表信息
        private void LoadDataToTableName(string sqlWhere)
        {
            string strSql;
            try
            {
                // strSql = @"select tabName,UpdateUserid ,UpdateTime  from m_MesTable_t " + sqlWhere;
                strSql = @"select  tabName  ,tabDetails,UpdateUserid ,UpdateTime from m_MesTable_t " + sqlWhere;
                DataTable dt = conn.GetDataTable(strSql);
                dgvTableName.DataSource = dt;
            }
            catch (Exception ex)
            {
                SysMessageClass.WriteErrLog(ex, "RouteManagement.FrmDbDictionary", "LoadDataToTableName", "sys");
            }
        }
        #endregion

        #region datagridView最前面一列显示为序号
        private void dgvTableName_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTableName.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(e.RowIndex.ToString(System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }
        #endregion

        #region 点击左方表名，右方显示表结构信息
        private void dgvTableName_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) return;
                if (this.dgvTableName.RowCount < 1) return;
                string tableName = this.dgvTableName.Rows[e.RowIndex].Cells[0].Value.ToString();
                LoadDataToTableStruc(e.RowIndex);
            }
            catch (Exception ex)
            {
                SysMessageClass.WriteErrLog(ex, "RouteManagement.FrmDbDictionary", "dgvTableName_CellClick", "sys");
            }
        }
        #endregion

        #region 加载表结构信息到右方datagridview
        private void LoadDataToTableStruc(int curRowIndex)
        {
            string strSql;
            string tableName = this.dgvTableName.Rows[curRowIndex].Cells[0].Value.ToString();
            try
            {
                if (dgvTableName.Rows.Count == 0) return;
                if (dgvTableStruc.Rows.Count > 0)
                {
                    dgvTableStruc.Rows.Clear();
                }

                SqlParameter[] paraValue = { new SqlParameter("@tabName", SqlDbType.NVarChar) };
                paraValue[0].Value = tableName;
                strSql = " exec  [Exec_DbDictionaryQuery]  '" + paraValue[0].Value.ToString() + "'";
                using (DataTable dt=conn.GetDataTable(strSql))
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dgvTableStruc.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
                                dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString());
                    }
                }
                
               // DataTable dt = conn.GetDataTable(strSql);
               // dgvTableStruc.DataSource = dt;
            }
            catch (Exception ex)
            {
                SysMessageClass.WriteErrLog(ex, "RouteManagement.FrmDbDictionary", "LoadDataToTableStruc", "sys");
            }
        }
        #endregion

        #region 根据表名进行模糊查询
        bool b = false;
        private void tsbQuery_Click(object sender, EventArgs e)
        {
            SqlLike();
        }

        //回车事件进行模糊查询
        private void txtTableName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                //txtTableName.Focus();
                SqlLike();
            }
        }

        private void txtDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                // txtDetails.Focus();
                SqlLike();
            }
        }
        private void SqlLike()
        {
            b = true;
            string strSql = " where 1=1";
            if (txtTableName.Text.Trim() != "")
            {
                strSql += " and tabName like N'%" + txtTableName.Text.Trim() + "%'";
            }

            if (txtDetails.Text.Trim() != "")
            {
                strSql += " and tabDetails like N'%" + txtDetails.Text.Trim() + "%'";
            }
            LoadDataToTableName(strSql);
            if (this.dgvTableName.RowCount < 1)
            {
                // dgvTableStruc.DataSource = null;
                if (dgvTableStruc.DataSource != null)
                {
                    DataTable dt = (DataTable)dgvTableStruc.DataSource;
                    dt.Rows.Clear();
                    dgvTableStruc.DataSource = dt;
                }
                //else
                //{
                //    dgvTableStruc.Rows.Clear();
                //}             
                return;
            }
            LoadDataToTableStruc(dgvTableName.CurrentRow.Index);
        }
        #endregion

        #region 说明字段按下回车事件
        //        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        //        {
        //            switch (keyData)
        //            {
        //                case System.Windows.Forms.Keys.Enter:
        //                    if (txtTableName.Focused == true)
        //                    {
        //                        SqlLike();
        //                        return true;
        //                    }
        //                    if (dgvTableStruc.CurrentCell == null ) return false;
        //                    if (dgvTableStruc.CurrentCell == dgvTableStruc.Rows[dgvTableStruc.CurrentCell.RowIndex].Cells[3])
        //                    {
        //                        string strSql;
        //                        string userId = VbCommClass.VbCommClass.UseId.ToUpper().ToString();

        //                        bool f=true;
        //                        string details="";
        //                        details = dgvTableStruc.Rows[dgvTableStruc.CurrentRow.Index].Cells[3].Value.ToString();
        //                        if (details=="")
        //                        {
        //                            f = false;
        //                        }
        //                        dgvTableStruc.EndEdit();
        //                        string tableName = dgvTableName.Rows[dgvTableName.CurrentRow.Index].Cells[0].Value.ToString();
        //                        string colName = dgvTableStruc.Rows[dgvTableStruc.CurrentRow.Index].Cells[1].Value.ToString();
        //                         details = dgvTableStruc.Rows[dgvTableStruc.CurrentRow.Index].Cells[3].Value.ToString();

        //                         strSql = @"update m_MesTable_t
        //                                    set UpdateUserid ='" + userId + "',UpdateTime=getdate()   where tabName='" + tableName + "'";

        //                        if (!f)
        //                        {
        //                            strSql+= @" EXECUTE sp_addextendedproperty N'MS_Description',N'" + details + "',N'user',N'dbo',N'table',N'" + tableName + "',N'column',N'" + colName + "'";
        //                        }
        //                        else
        //                        {
        //                            strSql+= @"EXECUTE sp_updateextendedproperty N'MS_Description',N'" + details + "',N'user',N'dbo',N'table',N'" + tableName + "',N'column',N'" + colName + "'";
        //                        }

        //                        try
        //                        {

        //                            conn.ExecSql(strSql);
        //                           // MessageBox.Show("修改列说明成功");
        //                            LoadDataToTableStruc(dgvTableName.CurrentRow.Index);
        //                           // SqlLike();

        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            SysMessageClass.WriteErrLog(ex, "RouteManagement.FrmDbDictionary", "ProcessCmdKey", "sys");
        //                        }

        //                    }


        //                    return true;
        //            }
        //            return base.ProcessCmdKey(ref msg, keyData);
        //        }
        #endregion

        #region 光标离开单元格保存说明修改 右侧
        private void dgvTableStruc_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvTableStruc.CellLeave -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTableStruc_CellLeave);
            try
            {
                if (b)
                {
                    b = false;
                    return;
                }
                if (dgvTableStruc.CurrentCell == dgvTableStruc.Rows[dgvTableStruc.CurrentCell.RowIndex].Cells[3])
                {
                    string strSql;
                    string updateSql;
                    string userId = VbCommClass.VbCommClass.UseId.ToUpper().ToString();

                    string details = "";
                    string detailsbefore = dgvTableStruc.Rows[dgvTableStruc.CurrentRow.Index].Cells[3].Value.ToString();//修改单元格之前的值
                    dgvTableStruc.EndEdit();
                    string tableName = dgvTableName.Rows[dgvTableName.CurrentRow.Index].Cells[0].Value.ToString();
                    string colName = dgvTableStruc.Rows[dgvTableStruc.CurrentRow.Index].Cells[1].Value.ToString();

                    if (dgvTableStruc.Rows[dgvTableStruc.CurrentRow.Index].Cells[3].Value == null || dgvTableStruc.Rows[dgvTableStruc.CurrentRow.Index].Cells[3].Value.ToString() == "")
                    {
                        dgvTableStruc.Rows[dgvTableStruc.CurrentRow.Index].Cells[3].Value = detailsbefore;
                        return;
                    }
                    else if (dgvTableStruc.Rows[dgvTableStruc.CurrentRow.Index].Cells[3].Value.ToString() == detailsbefore)
                    {
                        return;
                    }
                    else
                    {
                        details = dgvTableStruc.Rows[dgvTableStruc.CurrentRow.Index].Cells[3].Value.ToString();
                    }
                    try
                    {
                        strSql = @"update m_MesTable_t
                                    set UpdateUserid ='" + userId + "',UpdateTime=getdate()   where tabName=N'" + tableName + "'";

                        strSql += @" EXECUTE sp_addextendedproperty N'MS_Description',N'" + details + "',N'user',N'dbo',N'table',N'" + tableName + "',N'column',N'" + colName + "'";
                        conn.ExecSql(strSql);
                    }
                    catch
                    {
                        updateSql = @"update m_MesTable_t
                                    set UpdateUserid ='" + userId + "',UpdateTime=getdate()   where tabName=N'" + tableName + "'" + @"   EXECUTE sp_updateextendedproperty N'MS_Description',N'" + details + "',N'user',N'dbo',N'table',N'" + tableName + "',N'column',N'" + colName + "'";

                        try
                        {
                            conn.ExecSql(updateSql);
                        }
                        catch (Exception ex)
                        {
                            SysMessageClass.WriteErrLog(ex, "RouteManagement.FrmDbDictionary", "dgvTableStruc_CellLeave", "sys");
                        }
                    }

                    // try
                    // {            
                    // LoadDataToTableStruc(dgvTableName.CurrentRow.Index);
                    //}
                    //catch (Exception ex)
                    //{
                    //    SysMessageClass.WriteErrLog(ex, "RouteManagement.FrmDbDictionary", "dgvTableStruc", "sys");
                    //}

                }
            }
            finally
            {
                this.dgvTableStruc.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTableStruc_CellLeave);
            }
        }
        #endregion

        #region 修改表添加说明
        private void dgvTableName_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvTableName.CellLeave -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTableName_CellLeave);
            try
            {
                if (b)
                {
                    b = false;
                    return;
                }
                if (dgvTableName.CurrentCell.ColumnIndex == 1)
                {
                    string strSql;
                    string updateSql;
                    string userId = VbCommClass.VbCommClass.UseId.ToUpper().ToString();

                    string details = "";
                    string detailsbefore = dgvTableName.Rows[dgvTableName.CurrentRow.Index].Cells[1].Value.ToString();//修改单元格之前的值
                    dgvTableName.EndEdit();
                    string tableName = dgvTableName.Rows[dgvTableName.CurrentRow.Index].Cells[0].Value.ToString();

                    if (dgvTableName.Rows[dgvTableName.CurrentRow.Index].Cells[1].Value == null || dgvTableName.Rows[dgvTableName.CurrentRow.Index].Cells[1].Value.ToString() == "")
                    {
                        //details = "";
                        dgvTableName.Rows[dgvTableName.CurrentRow.Index].Cells[1].Value = detailsbefore;
                        return;
                    }
                    else if (dgvTableName.Rows[dgvTableName.CurrentRow.Index].Cells[1].Value.ToString() == detailsbefore)
                    {
                        return;
                    }
                    else
                    {
                        details = dgvTableName.Rows[dgvTableName.CurrentRow.Index].Cells[1].Value.ToString();
                    }
                    try
                    {
                        strSql = @"update m_MesTable_t
                                    set UpdateUserid ='" + userId + "',tabDetails =N'" + details + "',UpdateTime=getdate()   where tabName=N'" + tableName + "'";


                        strSql += @" EXECUTE sp_addextendedproperty   N'MS_Description',N'" + details + "',N'user',N'dbo',N'table',N'" + tableName + "',NULL,NULL";
                        conn.ExecSql(strSql);
                    }
                    catch
                    {
                        updateSql = @"update m_MesTable_t 
                                    set UpdateUserid ='" + userId + "',tabDetails =N'" + details + "',UpdateTime=getdate()   where tabName=N'" + tableName + "'" + @"  EXECUTE sp_updateextendedproperty   N'MS_Description',N'" + details + "',N'user',N'dbo',N'table',N'" + tableName + "',NULL,NULL";

                        try
                        {
                            conn.ExecSql(updateSql);
                        }
                        catch (Exception ex)
                        {
                            SysMessageClass.WriteErrLog(ex, "RouteManagement.FrmDbDictionary", "dgvTableName_CellLeave", "sys");
                        }
                    }

                    //  try
                    // {
                    // LoadDataToTableName(" ");
                    //LoadDataToTableStruc(dgvTableName.CurrentRow.Index);
                    // }
                    //catch (Exception ex)
                    //{
                    //    SysMessageClass.WriteErrLog(ex, "RouteManagement.FrmDbDictionary", "dgvTableStruc", "sys");
                    //}
                }
            }
            finally
            {
                this.dgvTableName.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTableName_CellLeave);
            }
        }
        #endregion
    }
}
