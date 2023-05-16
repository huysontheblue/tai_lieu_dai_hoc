using CallSystem;
using MainFrame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RouteManagement
{
    public partial class TestResult : Form
    {
        public TestResult()
        {
            InitializeComponent();
        }
        DataTable DBDATA;
        string SQL;
        string surface_testResuit;
        #region 窗体加载事件-加载可选数据库
        private void TestResult_Load(object sender, EventArgs e)
        {
            string SQL = "SELECT * FROM MESDataCenter.dbo.m_DBConnect ORDER BY time ";
            DBDATA = DbOperateUtils.GetDataTable(SQL);
            for (int i = 0; i < DBDATA.Rows.Count; i++)
            {
                DB.Items.Add(DBDATA.Rows[i]["DBname"]);
            }
            DB.Text = DBDATA.Rows[0]["DBname"].ToString();
            DB_SelectedIndexChanged(sender, e);
            cboGroup_SelectedIndexChanged(sender, e);
            Begin.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(-7);
            junction.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
        }
        #endregion
        #region 站点组选择事件
        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT TestTypeID +'-'+ TestTypeName AS TestTypeID FROM " + DBDATA.Rows[0]["TestTypesurface"] + " WHERE  ProductGroup ='" + cboGroup.Text.Trim() + "'";
                DataTable date = DBUtiles.GetDataTable(sql);
                if (date.Rows.Count == 0)
                {
                    sql = "SELECT TestTypeID +'-'+ TestTypeName AS TestTypeID FROM " + DBDATA.Rows[0]["TestTypesurface"] + "";
                    date = DBUtiles.GetDataTable(sql);
                }

                DataRow dr = date.NewRow();
                dr["TestTypeID"] = "0";

                dr["TestTypeID"] = "请选择";

                date.Rows.InsertAt(dr, 0);

                CboStation.DataSource = date;
                CboStation.DisplayMember = "TestTypeID";
                CboStation.Text = date.Rows[0]["TestTypeID"].ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region 异常处理方法
        private void error(string Result, string information)
        {
            if (Result == "PASS")
            {
                ERR.Visible = false;
            }
            else
            {
                ERR.Visible = true;
                ERR.ForeColor = Color.Red;
                ERR.Text = information;
            }
        }
        #endregion
        #region 将主副表合并成一个表，有相同字段取主表
        /// <summary>
        /// 将主副表合并成一个表，有相同字段取主表
        /// </summary>
        /// <param name="Master_table">主表数据</param>
        /// <param name="Auxiliary_table">附表数据</param>
        /// <returns></returns>
        public DataTable merge(DataTable Master_table, DataTable Auxiliary_table)
        {

            for (int i = 0; i < Auxiliary_table.Rows.Count; i++)
            {
                if (!Master_table.Columns.Contains(Auxiliary_table.Rows[i][2].ToString()) && Auxiliary_table.Rows[i][2].ToString() != "总测试数据")
                {
                    if (!Master_table.Columns.Contains(Auxiliary_table.Rows[i][1].ToString()))
                    {
                        Master_table.Columns.Add(Auxiliary_table.Rows[i][1].ToString());
                    }

                }
            }
            return Master_table;
        }
        #endregion
        //#region 传入 m_testResult 表数据，返回完整测试数据
        ///// <summary>
        ///// 传入 m_testResult 表数据，返回完整测试数据
        ///// </summary>
        ///// <param name="data">m_testResult表查询数据</param>
        ///// <returns></returns>
        //private DataTable QueryResult(DataTable data)
        //{
        //    try
        //    {
        //        //获取SN对应结果表名
        //        string table = "use MESDataCenter select SaveTableName from m_TestType_t where TestTypeID ='" + data.Rows[0][3] + "'";
        //        DataTable table_data = DbOperateUtils.GetDataTable(table);
        //        if (table_data.Rows.Count == 0)
        //        {
        //            return data;
        //        }
        //        //获取测试结果表是否有测试主键标记
        //        string sql = "use MESDataCenter  SELECT A.name AS table_name,B.name AS column_name,C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name IN (select SaveTableName from  MESDataCenter.dbo.m_TestType_t where TestTypeID in ('" + data.Rows[0][3].ToString().Trim() + "')) and C.value=N'主条码'";
        //        DataTable surface = DbOperateUtils.GetDataTable(sql);
        //        //判断表是否设置主条码
        //        if (surface.Rows.Count > 0)
        //        {
        //            sql = "use MESDataCenter   SELECT A.name AS table_name,B.name AS column_name,C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name IN (select SaveTableName from  MESDataCenter.dbo.m_TestType_t where TestTypeID in ('" + data.Rows[0][3].ToString().Trim() + "')) and C.value=N'总测试数据'";
        //            DataTable da = DbOperateUtils.GetDataTable(sql);
        //            //测试数据在一个栏位里
        //            if (da.Rows.Count > 0)
        //            {
        //                string sql1 = "use MESDataCenter SELECT A.name AS table_name, B.name AS column_name, C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name = '" + table_data.Rows[0][0] + "'";
        //                DataTable Auxiliary_table = DbOperateUtils.GetDataTable(sql1);
        //                for (int Ri = 0; Ri < data.Rows.Count; Ri++)
        //                {
        //                    //degree.Value = 30 + int.Parse((double.Parse("70") / double.Parse(data.Rows.Count.ToString()) * Ri).ToString("0"));
        //                    // 根据SN查询出测试表的数据
        //                    string SQL = "use MESDataCenter  select * from " + surface.Rows[0][0] + " where " + surface.Rows[0][1] + " ='" + data.Rows[Ri]["主条码"] + "'";
        //                    DataTable testresult = DbOperateUtils.GetDataTable(SQL);
        //                    data = merge(data, Auxiliary_table);
        //                    if (Ri == data.Rows.Count - 1)
        //                    {
        //                        for (int i = 0; i < testresult.Columns.Count; i++)
        //                        {
        //                            if (data.Columns.Contains(testresult.Columns[i].ColumnName))
        //                            {
        //                                data.Rows[Ri][testresult.Columns[i].ColumnName] = testresult.Rows[0][i].ToString();
        //                            }
        //                            for (int ii = 0; ii < Auxiliary_table.Rows.Count; ii++)
        //                            {
        //                                if (Auxiliary_table.Rows[i][1].ToString() == testresult.Columns[i].ColumnName.ToString() && Auxiliary_table.Rows[i][2].ToString().Trim() != "")
        //                                {
        //                                    if (data.Columns.Contains(testresult.Columns[i].ColumnName))
        //                                    {
        //                                        data.Columns[testresult.Columns[i].ColumnName].ColumnName = Auxiliary_table.Rows[i][2].ToString().Trim();
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                    if (testresult.Rows.Count == 0)
        //                    {
        //                        if (Ri == data.Rows.Count - 1)
        //                        {
        //                            for (int i = 0; i < testresult.Columns.Count; i++)
        //                            {
        //                                if (data.Columns.Contains(testresult.Columns[i].ColumnName))
        //                                {
        //                                    data.Rows[Ri][testresult.Columns[i].ColumnName] = testresult.Rows[0][i].ToString();
        //                                }
        //                                for (int ii = 0; ii < Auxiliary_table.Rows.Count; ii++)
        //                                {
        //                                    if (Auxiliary_table.Rows[i][1].ToString() == testresult.Columns[i].ColumnName.ToString() && Auxiliary_table.Rows[i][2].ToString().Trim() != "")
        //                                    {
        //                                        if (data.Columns.Contains(testresult.Columns[i].ColumnName))
        //                                        {
        //                                            data.Columns[testresult.Columns[i].ColumnName].ColumnName = Auxiliary_table.Rows[i][2].ToString().Trim();
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        continue;
        //                    }
        //                    for (int i = 0; i < testresult.Columns.Count; i++)
        //                    {
        //                        if (data.Columns.Contains(testresult.Columns[i].ColumnName))
        //                        {
        //                            data.Rows[Ri][testresult.Columns[i].ColumnName] = testresult.Rows[0][i].ToString();
        //                        }
        //                    }
        //                    string s = testresult.Rows[0][da.Rows[0][1].ToString()].ToString();
        //                    if (s.Length > 4)
        //                    {
        //                        char[] chs = { '#' };
        //                        string[] date = s.Split(chs, StringSplitOptions.RemoveEmptyEntries);
        //                        char[] chs1 = { '=' };
        //                        string[] date1 = date[0].Split(chs1, StringSplitOptions.RemoveEmptyEntries);
        //                        if (!data.Columns.Contains("测试结果"))
        //                        {
        //                            data.Columns.Add("测试结果", typeof(string));
        //                        }
        //                        data.Rows[Ri]["测试结果"] = date1[0];
        //                        //足个将其他测试数据单独分开
        //                        for (int i = 1; i < date.Length; i++)
        //                        {
        //                            date1 = date[i].Split(chs1, StringSplitOptions.RemoveEmptyEntries);

        //                            if (!data.Columns.Contains(date1[0]))
        //                            {
        //                                data.Columns.Add(date1[0], typeof(string));
        //                            }
        //                            if (date1.Length == 2)
        //                            {
        //                                data.Rows[Ri][date1[0]] = date1[1];
        //                            }

        //                        }
        //                    }
        //                }

        //            }
        //            //测试数据单个栏位保存
        //            else
        //            {
        //                string sql1 = "use MESDataCenter SELECT A.name AS table_name, B.name AS column_name, C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name = '" + table_data.Rows[0][0] + "'";
        //                DataTable Auxiliary_table = DbOperateUtils.GetDataTable(sql1);
        //                for (int Ri = 0; Ri < data.Rows.Count; Ri++)
        //                {
        //                    //degree.Value = 30 + int.Parse((double.Parse("70") / double.Parse(data.Rows.Count.ToString()) * Ri).ToString());
        //                    string SQL = "use MESDataCenter  select * from " + table_data.Rows[0][0] + " where " + surface.Rows[0][1] + " ='" + data.Rows[Ri]["主条码"] + "' order by ID desc";
        //                    DataTable testresult = DbOperateUtils.GetDataTable(SQL);
        //                    data = merge(data, Auxiliary_table);
        //                    if (Ri == data.Rows.Count - 1)
        //                    {
        //                        for (int i = 0; i < testresult.Columns.Count; i++)
        //                        {
        //                            if (data.Columns.Contains(testresult.Columns[i].ColumnName))
        //                            {
        //                                data.Rows[Ri][testresult.Columns[i].ColumnName] = testresult.Rows[0][i].ToString();
        //                            }
        //                            for (int ii = 0; ii < Auxiliary_table.Rows.Count; ii++)
        //                            {
        //                                if (Auxiliary_table.Rows[i][1].ToString() == testresult.Columns[i].ColumnName.ToString() && Auxiliary_table.Rows[i][2].ToString().Trim() != "")
        //                                {
        //                                    if (data.Columns.Contains(testresult.Columns[i].ColumnName))
        //                                    {
        //                                        data.Columns[testresult.Columns[i].ColumnName].ColumnName = Auxiliary_table.Rows[i][2].ToString().Trim();
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                    if (testresult.Rows.Count == 0)
        //                    {
        //                        continue;
        //                    }
        //                    for (int i = 0; i < testresult.Columns.Count; i++)
        //                    {
        //                        if (data.Columns.Contains(testresult.Columns[i].ColumnName))
        //                        {
        //                            data.Rows[Ri][testresult.Columns[i].ColumnName] = testresult.Rows[0][i].ToString();
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //        }
        //        return data;
        //    }
        //    catch (Exception)
        //    {

        //        return data;
        //    }
        //}

        //#endregion
        #region 查询按钮点击事件
        /// <summary>
        /// 查询按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolScanSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (Record.Checked)
                {
                    if (CboStation.Text == "")
                    {
                        MessageBox.Show("勾选查询单站记录必须选择站点");
                        return;
                    }
                    string st = CboStation.Text;
                    string[] sArray = st.Split('-');
                    ArrayList extend = new ArrayList();
                    extend.Add(true);
                    extend.Add(sArray[0]);
                    extend.Add(Begin.Text);
                    extend.Add(junction.Text);
                    Result form = new Result("", sArray[0], DBDATA, extend,sArray[1]);
                    form.ShowDialog();
                    return;
                }
                int query = 0;
                error("PASS", "");
                if (barcode.Text.Trim() != "" || moid.Text.Trim() != "" || Partid.Text.Trim() != "" || CboStation.Text != "请选择")
                {
                    error("PASS", "");
                    SQL = " SELECT top " + numericUpDown1.Value + "  ppid,stationid, B.TestTypeName AS N'站点名称',result,TestCount,A.intime  from " + DBDATA.Rows[0]["TestResultsurface"] + " A LEFT JOIN m_TestType_t B ON A.stationid=B.TestTypeID WHERE 1=1";
                    surface_testResuit = "SELECT A.name AS table_name,B.name AS column_name,C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name = '" + DBDATA.Rows[0]["TestResultsurface"] + "' and B.name in (N'intime',N'ppid',N'result',N'stationid',N'TestCount') ORDER BY B.name ";
                    if (barcode.Text.Trim() != "")
                    {
                        query += 1;
                        string sqlt = "EXEC MESDataCenter.dbo.p_GETMainbarcode '" + barcode.Text + "','" + cboGroup.Text.Trim() + "'";
                        DataTable dt = DbOperateUtils.GetDataTable(sqlt);
                        SQL += " AND ppid='" + dt.Rows[0][0].ToString() + "'";
                    }
                    if (moid.Text.Trim() != "")
                    {
                        query += 1;
                        SQL += " AND Moid='" + moid.Text.Trim() + "'";
                    }
                    if (Partid.Text.Trim() != "")
                    {
                        query += 1;
                        SQL += " AND Material='" + Partid.Text.Trim() + "'";
                    }
                    if (moid.Text.Trim() != "" || Partid.Text.Trim() != "" || CboStation.Text != "请选择")
                    {
                        SQL += " and A.intime between  '" + Begin.Value + "' and  '" + junction.Value + "'";
                    }
                    if (state.Text.Trim() != "")
                    {
                        SQL += " and result='" + state.Text.Trim() + "'";
                    }
                    if (CboStation.Text != "请选择")
                    {
                        query += 1;
                        //if (query == 0)
                        //{
                        //    string insertStr = " top 100 ";
                        //    SQL = SQL.Insert(SQL.LastIndexOf("select") + 6, insertStr);
                        //}
                        //query += 1;
                        char[] chs = { '-' };
                        string[] date = CboStation.Text.Split(chs, StringSplitOptions.RemoveEmptyEntries);
                        SQL += " AND stationid=N'" + date[0] + "'";
                    }
                    if (query == 0)
                    {
                        error("FAIL", "工单，料号，产品条码，站点 ，条件必须选择其一");
                        return;
                    }
                    SQL += "ORDER BY A.intime DESC";
                    DataTable data = DBUtiles.GetDataTable(SQL);
                    DataTable m_testresult = DBUtiles.GetDataTable(surface_testResuit);
                    for (int i = 0; i < m_testresult.Rows.Count; i++)
                    {
                        if (m_testresult.Rows[i][2].ToString() != "" && !data.Columns.Contains(m_testresult.Rows[i][2].ToString()))
                        {
                            data.Columns[m_testresult.Rows[i][1].ToString()].ColumnName = m_testresult.Rows[i][2].ToString();
                        }

                    }
                    Resultdata.DataSource = data;
                    Resultdata.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleTurquoise;
                }
                else
                {
                    error("FAIL", "请输入查询条件");
                }
            }
            catch
            {
                MessageBox.Show("表时间字段不为Collecttime请联系开发人员");
            }
        }
        #endregion
        #region 双击查看测试结果
        private void Resultdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ArrayList extend = new ArrayList();
            extend.Add(false);
            extend.Add("");
            extend.Add("");
            if (Resultdata.Columns.Contains("主条码"))
            {
                try
                {
                    Result form = new Result(Resultdata.Rows[e.RowIndex].Cells["主条码"].Value.ToString(), Resultdata.Rows[e.RowIndex].Cells["站点"].Value.ToString(), DBDATA, extend, Resultdata.Rows[e.RowIndex].Cells["站点名称"].Value.ToString());
                    form.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("主条码和站点必须同时备注");
                }
            }
            else
            {
                try
                {
                    Result form = new Result(Resultdata.Rows[e.RowIndex].Cells["ppid"].Value.ToString(), Resultdata.Rows[e.RowIndex].Cells["stationid"].Value.ToString(), DBDATA, extend, Resultdata.Rows[e.RowIndex].Cells["stationName"].Value.ToString());
                    form.ShowDialog();
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
        #endregion
        #region 数据库选择事件
        /// <summary>
        /// 数据库选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SQL = "SELECT * FROM MESDataCenter.dbo.m_DBConnect where DBname =N'" + DB.Text.Trim() + "'";
            DBDATA = DbOperateUtils.GetDataTable(SQL);
            moid.Text = "";
            Partid.Text = "";
            moid.Enabled = false;
            Partid.Enabled = false;
            DBUtiles.Loginname = DBDATA.Rows[0]["Loginname"].ToString();
            DBUtiles.DBPassword = DBDATA.Rows[0]["DBPassword"].ToString();
            DBUtiles.library = DBDATA.Rows[0]["library"].ToString();
            DBUtiles.DBAccount = DBDATA.Rows[0]["DBAccount"].ToString();
            SQL = "SELECT distinct(ProductGroup) FROM  " + DBDATA.Rows[0]["library"].ToString().Trim() + ".dbo." + DBDATA.Rows[0]["TestTypesurface"].ToString().Trim() + "  WHERE  ProductGroup  IS NOT NULL";
            DataTable DATA = DBUtiles.GetDataTable(SQL);
            if (DATA.Rows.Count > 0)
            {
                cboGroup.Text = DATA.Rows[0]["ProductGroup"].ToString();
            }
            cboGroup.DataSource = DATA;
            cboGroup.DisplayMember = "ProductGroup";
            cboGroup_SelectedIndexChanged(sender, e);
            SQL = "select  ppid,stationid,result,TestCount,intime  from dbo.m_TestResult_t WHERE 1=1";
            surface_testResuit = "SELECT A.name AS table_name,B.name AS column_name,C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name = 'm_TestResult_t' and B.name in (N'intime',N'ppid',N'result',N'stationid',N'TestCount') ORDER BY B.name ";
            if (DBDATA.Rows[0]["Partidexistence"].ToString().Trim() == "Y" && DBDATA.Rows[0]["MOIDexistence"].ToString().Trim() == "Y")
            {
                SQL = "select  Moid,Material,ppid,stationid,result,TestCount,intime  from dbo.m_TestResult_t WHERE 1=1";
                surface_testResuit = "SELECT A.name AS table_name,B.name AS column_name,C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name = 'm_TestResult_t' and B.name in (N'intime',N'Material',N'Moid',N'ppid',N'result',N'stationid',N'TestCount') ORDER BY B.name ";
                moid.Enabled = true;
                Partid.Enabled = true;
            }
            else if (DBDATA.Rows[0]["MOIDexistence"].ToString().Trim() == "N" && DBDATA.Rows[0]["Partidexistence"].ToString().Trim() == "Y")
            {
                SQL = "select  Material,ppid,stationid,result,TestCount,intime  from dbo.m_TestResult_t WHERE 1=1";
                surface_testResuit = "SELECT A.name AS table_name,B.name AS column_name,C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name = 'm_TestResult_t' and B.name in (N'intime',N'Material',N'ppid',N'result',N'stationid',N'TestCount') ORDER BY B.name ";
                Partid.Enabled = true;
            }
            else if (DBDATA.Rows[0]["Partidexistence"].ToString().Trim() == "N" && DBDATA.Rows[0]["MOIDexistence"].ToString().Trim() == "Y")
            {
                surface_testResuit = "SELECT A.name AS table_name,B.name AS column_name,C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name = 'm_TestResult_t' and B.name in (N'intime',N'Moid',N'ppid',N'result',N'stationid',N'TestCount') ORDER BY B.name ";
                SQL = "select  Moid,ppid,stationid,result,TestCount,intime  from dbo.m_TestResult_t WHERE 1=1";
                moid.Enabled = true;
            }

        }
        #endregion

        private void ToolExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Resultdata.DataSource;
            ExcelUtils.LoadDataToExcelFromDT(dt, "测试数据报表");
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int Dfixed = 0;
        private void Resultdata_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            ArrayList extend = new ArrayList();
            extend.Add(false);
            extend.Add("");
            extend.Add("");
            if (Resultdata.Columns.Contains("主条码"))
            {
                try
                {
                    ResultdataX1.DataSource = Resulthk(Resultdata.Rows[e.RowIndex].Cells["主条码"].Value.ToString(), Resultdata.Rows[e.RowIndex].Cells["站点"].Value.ToString(), DBDATA, extend);

                    if (!bool.Parse(extend[0].ToString()))
                    {
                        ResultdataX1.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleTurquoise;
                        //固定主表列
                        for (int i = 0; i < Dfixed; i++)
                        {
                            ResultdataX1.Columns[i].Frozen = true;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("主条码和站点必须同时备注");
                }
            }
            else
            {
                try
                {
                    ResultdataX1.DataSource = Resulthk(Resultdata.Rows[e.RowIndex].Cells["ppid"].Value.ToString(), Resultdata.Rows[e.RowIndex].Cells["stationid"].Value.ToString(), DBDATA, extend);
                    if (!bool.Parse(extend[0].ToString()))
                    {
                        ResultdataX1.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleTurquoise;
                        //固定主表列
                        for (int i = 0; i < Dfixed; i++)
                        {
                            ResultdataX1.Columns[i].Frozen = true;
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
        #region 查询结果
        /// <summary>
        /// 查询结果
        /// </summary>
        /// <param name="PPID"> 主条码</param>
        /// <param name="stationid"> 站点</param>
        /// <param name="DB"> 数据库连接信息</param>
        public DataTable Resulthk(string PPID, string stationid, DataTable DB, ArrayList extend)
        {
            DBDATA = DB;
            string SQL = "select  ppid,stationid,result,TestCount,intime  from MESDataCenter.dbo.m_TestResult_t WHERE 1=1 and ppid = '" + PPID + "' and stationid='" + stationid + "'";
            string surface_testResuit = "SELECT A.name AS table_name,B.name AS column_name,C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name = 'm_TestResult_t' and B.name in (N'intime',N'ppid',N'result',N'stationid',N'TestCount') ORDER BY B.name ";
            if (DB.Rows[0]["Partidexistence"].ToString().Trim() == "Y" && DB.Rows[0]["MOIDexistence"].ToString().Trim() == "Y")
            {
                SQL = "select  Moid,Material,ppid,stationid,result,TestCount,intime  from MESDataCenter.dbo.m_TestResult_t WHERE 1=1 and ppid = '" + PPID + "' and stationid='" + stationid + "'";
                surface_testResuit = "SELECT A.name AS table_name,B.name AS column_name,C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name = 'm_TestResult_t' and B.name in (N'intime',N'Material',N'Moid',N'ppid',N'result',N'stationid',N'TestCount') ORDER BY B.name ";
            }
            else if (DB.Rows[0]["MOIDexistence"].ToString().Trim() == "N" && DB.Rows[0]["Partidexistence"].ToString().Trim() == "Y")
            {
                SQL = "select  Material,ppid,stationid,result,TestCount,intime  from MESDataCenter.dbo.m_TestResult_t WHERE 1=1 and ppid = '" + PPID + "' and stationid='" + stationid + "'";
                surface_testResuit = "SELECT A.name AS table_name,B.name AS column_name,C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name = 'm_TestResult_t' and B.name in (N'intime',N'Material',N'ppid',N'result',N'stationid',N'TestCount') ORDER BY B.name ";
            }
            else if (DB.Rows[0]["Partidexistence"].ToString().Trim() == "N" && DB.Rows[0]["MOIDexistence"].ToString().Trim() == "Y")
            {
                surface_testResuit = "SELECT A.name AS table_name,B.name AS column_name,C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name = 'm_TestResult_t' and B.name in (N'intime',N'Moid',N'ppid',N'result',N'stationid',N'TestCount') ORDER BY B.name ";
                SQL = "select  Moid,ppid,stationid,result,TestCount,intime  from MESDataCenter.dbo.m_TestResult_t WHERE 1=1 and ppid = '" + PPID + "' and stationid='" + stationid + "'";
            }
            SQL += "ORDER BY ppid,stationid";
            //m_testRrsult表字段备注添加与标题
            DataTable data = DBUtiles.GetDataTable(SQL);

            DataTable m_testresult = DBUtiles.GetDataTable(surface_testResuit);
            for (int i = 0; i < m_testresult.Rows.Count; i++)
            {
                if (m_testresult.Rows[i][2].ToString() != "" && !data.Columns.Contains(m_testresult.Rows[i][2].ToString()))
                {
                    data.Columns[m_testresult.Rows[i][1].ToString()].ColumnName = m_testresult.Rows[i][2].ToString();
                }
            }
            int Dfixed = data.Columns.Count;
            return QueryResult(data, stationid, extend);

        }
        #endregion

        #region 传入 m_testResult 表数据，返回完整测试数据
        /// <summary>
        /// 传入 m_testResult 表数据，返回完整测试数据
        /// </summary>
        /// <param name="data">m_testResult表查询数据</param>
        /// <returns></returns>
        private DataTable QueryResult(DataTable data, string site, ArrayList extend)
        {
            //获取SN对应结果表名
            if (!data.Columns.Contains("主条码"))
            {
                return data;
            }
            string table = "select SaveTableName,KeyFileld from " + DBDATA.Rows[0]["TestTypesurface"] + " where TestTypeID ='" + site + "'";
            DataTable table_data = DBUtiles.GetDataTable(table);
            if (table_data.Rows.Count == 0)
            {
                return data;
            }
            // 根据SN查询出测试表的数据
            DataTable testresult = null;
            //判断是否为非本厂服务器
            string sqlw = "select SaveTableName from  " + DBDATA.Rows[0]["TestTypesurface"] + " where TestTypeID in ('" + site + "')";
            DataTable surfacev = DBUtiles.GetDataTable(sqlw);
            string sql = "SELECT A.name AS table_name,B.name AS column_name,C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name IN (select SaveTableName from " + DBDATA.Rows[0]["TestTypesurface"] + " where TestTypeID in ('" + site + "'))";
            if (surfacev.Rows.Count > 0)
            {
                if (surfacev.Rows[0][0].ToString().Substring(0, 1) == "[")
                {
                    string str = surfacev.Rows[0][0].ToString();
                    string[] sArray = str.Split(new char[1] { '.' });
                    string ip = sArray[0] + "." + sArray[1] + "." + sArray[2] + "." + sArray[3] + "." + sArray[4] + ".";
                    sql = "SELECT A.name AS table_name,B.name AS column_name,C.value AS column_description FROM  " + ip + "sys.tables A INNER JOIN  " + ip + "sys.columns B ON B.object_id = A.object_id LEFT JOIN  " + ip + "sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name IN ('" + sArray[sArray.Length - 1] + "')";
                }
                else
                {
                    sql = "SELECT A.name AS table_name,B.name AS column_name,C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name IN (select SaveTableName from " + DBDATA.Rows[0]["TestTypesurface"] + " where TestTypeID in ('" + site + "'))";
                }
            }

            {
                //获取测试结果表是否有测试主键标记
                // sql += " and C.value=N'主条码'";
                //DataTable surface = DBUtiles.GetDataTable(sql);
                //判断表是否设置主条码
                if (table_data.Rows.Count > 0)
                {
                    string sqlt = sql + " and C.value=N'总测试数据'";
                    DataTable da = DBUtiles.GetDataTable(sqlt);
                    DataTable Auxiliary_table = null;
                    //测试数据在一个栏位里
                    if (da.Rows.Count > 0)
                    {
                        string SQL;

                        if (bool.Parse(extend[0].ToString()))
                        {
                            SQL = " select * from " + table_data.Rows[0][0] + " where   Collecttime > '" + extend[2].ToString() + "' AND Collecttime<'" + extend[3].ToString() + "'";
                            data = new DataTable();
                            testresult = DBUtiles.GetDataTable(SQL);
                            string sql1 = " SELECT A.name AS table_name, B.name AS column_name, C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name = '" + table_data.Rows[0][0] + "'";
                            Auxiliary_table = DBUtiles.GetDataTable(sql1);
                            for (int i = 0; i < Auxiliary_table.Rows.Count; i++)
                            {
                                if (Auxiliary_table.Rows[i][2].ToString() != "" && !testresult.Columns.Contains(Auxiliary_table.Rows[i][2].ToString()))
                                {
                                    testresult.Columns[Auxiliary_table.Rows[i][1].ToString()].ColumnName = Auxiliary_table.Rows[i][2].ToString();
                                }
                            }
                        }
                        else
                        {
                            SQL = " select * from " + table_data.Rows[0][0] + " where " + table_data.Rows[0][1] + " ='" + data.Rows[0]["主条码"] + "'";
                            testresult = DBUtiles.GetDataTable(SQL);

                            string sql1 = " SELECT A.name AS table_name, B.name AS column_name, C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name = '" + table_data.Rows[0][0] + "'";
                            Auxiliary_table = DBUtiles.GetDataTable(sql1);
                            data = merge(data, Auxiliary_table);
                        }
                        for (int ri = 0; ri < testresult.Rows.Count; ri++)
                        {
                            string s;
                            if (bool.Parse(extend[0].ToString()))
                            {
                                s = testresult.Rows[ri]["总测试数据"].ToString();
                                if (s.Length > 4)
                                {
                                    char[] chs = { '#' };
                                    string[] date = s.Split(chs, StringSplitOptions.RemoveEmptyEntries);
                                    char[] chs1 = { '=' };
                                    string[] date1 = date[0].Split(chs1, StringSplitOptions.RemoveEmptyEntries);
                                    if (!testresult.Columns.Contains("测试结果"))
                                    {
                                        testresult.Columns.Add("测试结果", typeof(string));
                                    }
                                    testresult.Rows[ri]["测试结果"] = date1[0];
                                    //足个将其他测试数据单独分开
                                    for (int i = 1; i < date.Length; i++)
                                    {
                                        date1 = date[i].Split(chs1, StringSplitOptions.RemoveEmptyEntries);

                                        if (!testresult.Columns.Contains(date1[0]))
                                        {
                                            testresult.Columns.Add(date1[0], typeof(string));
                                        }
                                        try
                                        {
                                            testresult.Rows[ri][date1[0]] = date1[1];
                                        }
                                        catch
                                        {

                                        }

                                    }
                                }
                                else
                                {
                                    if (!testresult.Columns.Contains("测试结果"))
                                    {
                                        testresult.Columns.Add("测试结果", typeof(string));
                                    }
                                    testresult.Rows[ri]["测试结果"] = s;
                                }
                                continue;
                            }
                            if (ri == testresult.Rows.Count - 1)
                            {
                                if (ri > 0)
                                {
                                    data.Rows.Add(data.Rows[0][0], data.Rows[0][1], data.Rows[0][2], data.Rows[0][3], data.Rows[0][4], data.Rows[0][5], data.Rows[0][6]);
                                }
                                for (int i = 0; i < testresult.Columns.Count; i++)
                                {
                                    if (data.Columns.Contains(testresult.Columns[i].ColumnName))
                                    {
                                        data.Rows[ri][testresult.Columns[i].ColumnName] = testresult.Rows[ri][i].ToString();
                                        for (int ii = 0; ii < Auxiliary_table.Rows.Count; ii++)
                                        {
                                            if (Auxiliary_table.Rows[i][1].ToString() == testresult.Columns[i].ColumnName.ToString() && Auxiliary_table.Rows[i][2].ToString().Trim() != "")
                                            {
                                                data.Columns[testresult.Columns[i].ColumnName].ColumnName = Auxiliary_table.Rows[i][2].ToString().Trim();
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (ri > 0)
                                {
                                    data.Rows.Add(data.Rows[0][0], data.Rows[0][1], data.Rows[0][2], data.Rows[0][3], data.Rows[0][4], data.Rows[0][5], data.Rows[0][6]);
                                }
                                for (int i = 0; i < testresult.Columns.Count; i++)
                                {
                                    if (data.Columns.Contains(testresult.Columns[i].ColumnName))
                                    {
                                        data.Rows[ri][testresult.Columns[i].ColumnName] = testresult.Rows[ri][i].ToString();
                                    }
                                }
                            }
                            s = testresult.Rows[ri][da.Rows[0][1].ToString()].ToString();
                            if (s.Length > 4)
                            {
                                char[] chs = { '#' };
                                string[] date = s.Split(chs, StringSplitOptions.RemoveEmptyEntries);
                                char[] chs1 = { '=' };
                                string[] date1 = date[0].Split(chs1, StringSplitOptions.RemoveEmptyEntries);
                                if (!data.Columns.Contains("测试结果"))
                                {
                                    data.Columns.Add("测试结果", typeof(string));
                                }
                                data.Rows[ri]["测试结果"] = date1[0];
                                //足个将其他测试数据单独分开
                                for (int i = 1; i < date.Length; i++)
                                {
                                    date1 = date[i].Split(chs1, StringSplitOptions.RemoveEmptyEntries);

                                    if (!data.Columns.Contains(date1[0]))
                                    {
                                        data.Columns.Add(date1[0], typeof(string));
                                    }
                                    try
                                    {
                                        data.Rows[ri][date1[0]] = date1[1];
                                    }
                                    catch
                                    {

                                    }

                                }
                            }
                            else
                            {
                                if (!data.Columns.Contains("测试结果"))
                                {
                                    data.Columns.Add("测试结果", typeof(string));
                                }
                                data.Rows[ri]["测试结果"] = s;
                            }
                        }


                    }
                    //测试数据单个栏位保存
                    else
                    {
                        string SQL = " select * from " + table_data.Rows[0][0] + " where " + table_data.Rows[0][1] + " ='" + data.Rows[0]["主条码"] + "'";
                        testresult = DBUtiles.GetDataTable(SQL);
                        string sql1;
                        if (surfacev.Rows[0][0].ToString().Substring(0, 1) == "[")
                        {
                           
                            sql1 = sql ;
                        }
                        else
                        {
                            sql1 = sql + " and A.name = '" + table_data.Rows[0][0] + "'";
                        }


                        
                        Auxiliary_table = DBUtiles.GetDataTable(sql1);
                        if (testresult.Rows.Count > 1)
                        {

                            for (int i = 0; i < testresult.Rows.Count - 1; i++)
                            {
                                data.Rows.Add();
                                for (int j = 0; j < data.Columns.Count; j++)
                                {
                                    data.Rows[i + 1][j] = data.Rows[i][j];
                                }

                            }
                        }
                        data = merge(data, Auxiliary_table);
                        for (int Ri = 0; Ri < testresult.Rows.Count; Ri++)
                        {
                            if (testresult.Rows.Count == 0)
                            {
                                return data;
                            }

                            if (Ri == data.Rows.Count)
                            {
                                for (int i = 0; i < testresult.Columns.Count; i++)
                                {
                                    if (data.Columns.Contains(testresult.Columns[i].ColumnName))
                                    {
                                        try
                                        {
                                            data.Rows[Ri][testresult.Columns[i].ColumnName] = testresult.Rows[Ri][i].ToString();
                                        }
                                        catch
                                        {
                                        }

                                    }
                                    for (int ii = 0; ii < Auxiliary_table.Rows.Count; ii++)
                                    {
                                        if (Auxiliary_table.Rows[i][1].ToString() == testresult.Columns[i].ColumnName.ToString() && Auxiliary_table.Rows[i][2].ToString().Trim() != "")
                                        {
                                            if (data.Columns.Contains(testresult.Columns[i].ColumnName))
                                            {
                                                data.Columns[testresult.Columns[i].ColumnName].ColumnName = Auxiliary_table.Rows[i][2].ToString().Trim();
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < testresult.Columns.Count; i++)
                                {
                                    if (data.Columns.Contains(testresult.Columns[i].ColumnName))
                                    {
                                        try
                                        {
                                            data.Rows[Ri][testresult.Columns[i].ColumnName] = testresult.Rows[Ri][i].ToString();
                                        }
                                        catch
                                        {
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (bool.Parse(extend[0].ToString()))
                {
                    return testresult;
                }
                else
                {
                    return data;
                }
            }
        #endregion
        }

        private void barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue==13)
            {
                toolScanSet_Click(sender, e);
            }
        }
    }
}
