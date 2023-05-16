using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CallSystem
{
    public static class DBUtiles
    {


        public static string DBAccount, Loginname, DBPassword, library;
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <returns></returns>
        public static SqlConnection CallCon()
        {
           //return new SqlConnection("server=" + ChuanZhi.GetIP() + ";database=CALL;uid=cs;pwd=dg'songyy");
            return new SqlConnection("data source=" + DBAccount + ";initial catalog=" + library + ";user id=" + Loginname + ";password=" + DBPassword + "");
        }
        /// <summary>
        /// 执行'查'返回DataTable数据集
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string strSQL)
        {
            DataTable dt = new DataTable();
            SqlConnection con = CallCon();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(strSQL, con);
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
                con.Close();
            }
            catch 
            {
            }
            return dt;
        }
        /// <summary>
        /// 执行'增删改'
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static void ExecSQL(string strSQL)
        {
            SqlConnection con = CallCon();
            SqlCommand cmd = new SqlCommand(strSQL, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
