using CallSystem;
using MainFrame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RouteManagement
{
    public partial class Result : Form
    {  //接受主窗体传过来的数据库连接信息
        DataTable DBDATA;
        #region 查询结果
        /// <summary>
        /// 查询结果
        /// </summary>
        /// <param name="PPID"> 主条码</param>
        /// <param name="stationid"> 站点</param>
        /// <param name="DB"> 数据库连接信息</param>
        public Result(string PPID, string stationid, DataTable DB, ArrayList extend, string StationName)
        {
            InitializeComponent();
            DBDATA = DB;
            string SQL = "select  ppid,stationid,result,TestCount,intime  from MESDataCenter.dbo.m_TestResult_t WHERE 1=1 and ppid = '" + PPID + "' and stationid='" + stationid + "'";
            string  surface_testResuit = "SELECT A.name AS table_name,B.name AS column_name,C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name = 'm_TestResult_t' and B.name in (N'intime',N'ppid',N'result',N'stationid',N'TestCount') ORDER BY B.name ";
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
            Resultdata.DataSource = QueryResult(data, stationid, extend,StationName);
           if (!bool.Parse(extend[0].ToString()))
            {
                Resultdata.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleTurquoise;
                //固定主表列
                for (int i = 0; i < Dfixed; i++)
                {
                    Resultdata.Columns[i].Frozen = true;
                }
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
            try
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
            catch (Exception)
            {

                return Master_table;
            }
         
        }
        #endregion
        #region 传入 m_testResult 表数据，返回完整测试数据
        ///// <summary>
        ///// 传入 m_testResult 表数据，返回完整测试数据
        ///// </summary>
        ///// <param name="data">m_testResult表查询数据</param>
        ///// <returns></returns>
        private DataTable QueryResult(DataTable data, string site, ArrayList extend,string stationName)
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
                            SQL = " select N'" + stationName + "' as StationID,* from " + table_data.Rows[0][0] + " where   Collecttime > '" + extend[2].ToString() + "' AND Collecttime<'" + extend[3].ToString() + "'";
                            data = new DataTable();
                            testresult = DBUtiles.GetDataTable(SQL);

                            string sql1 = " SELECT '" + table_data.Rows[0][0] + "' AS table_name, 'StationID', N'测试站点' union all ";
                             sql1 += " SELECT A.name AS table_name, B.name AS column_name, C.value AS column_description FROM sys.tables A INNER JOIN sys.columns B ON B.object_id = A.object_id LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id WHERE A.name = '" + table_data.Rows[0][0] + "'";
                           
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

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Resultdata.DataSource;

            ExcelUtils.LoadDataToExcelFromDT(dt, "测试数据报表-明细");
        }

        private void Result_Load(object sender, EventArgs e)
        {
           
        }
    }
}
