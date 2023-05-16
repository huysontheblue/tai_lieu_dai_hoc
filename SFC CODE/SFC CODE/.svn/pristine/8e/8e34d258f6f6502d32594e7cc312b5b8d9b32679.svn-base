//using SysBasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SysBasicClass
{
    public static class OracleOperateUtils
    {
        public static string connectionStringSap;
        public static string FactoryID;

        /// <summary>
        /// 取得VIEW数据
        /// SAP连接
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static DataView getDataViewSap(string strSQL)
        {
            OracleDb TiptopConn = new OracleDb();

            try
            {
                DataView dv = TiptopConn.getDataView(strSQL);
                if (dv == null)
                {
                    dv = new DataView();
                }
                return dv;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                TiptopConn = null;
            }
        }

        /// <summary>
        /// 取得VIEW数据
        /// TT数据取得
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static DataView getDataView(string strSQL)
        {
            OracleDb TiptopConn = new OracleDb(FactoryID);

            try
            {
                DataView dv = TiptopConn.getDataView(strSQL);
                return dv;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                TiptopConn = null;
            }
        }

        /// <summary>
        /// 取得TABLE数据
        /// SAP数据取得
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static DataTable GetDataTableSap(string strSQL)
        {
            OracleDb TiptopConn = new OracleDb();
            try
            {
                DataTable dt = TiptopConn.ExecuteQuery(strSQL).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                TiptopConn = null;
            }
        }

        /// <summary>
        /// 取得VIEW数据
        /// TT数据取得
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static DataTable  GetDataTable(string strSQL)
        {
            OracleDb TiptopConn = new OracleDb(FactoryID);
            try
            {
                DataTable dt = TiptopConn.ExecuteQuery(strSQL).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                TiptopConn = null;
            }
        }

        /// <summary>
        /// 取得VIEW数据
        /// TT数据取得
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列
        public static string ExecuteScalarSap(string strSQL)
        {
            OracleDb TiptopConn = new OracleDb();
            try
            {
                string returnValue = TiptopConn.ExecuteScalar(strSQL).ToString();
                return returnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                TiptopConn = null;
            }
        }

        /// <summary>
        /// 取得VIEW数据
        /// TT数据取得
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列
        public static string ExecuteScalar(string strSQL)
        {
            OracleDb TiptopConn = new OracleDb(FactoryID);
            try
            {
                string returnValue = TiptopConn.ExecuteScalar(strSQL).ToString() ;
                return returnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                TiptopConn = null;
            }
        }

        /// <summary>
        /// TT更新
        /// </summary>
        /// <param name="strSQL"></param>
        public static void ExecuteNonQuery(string strSQL)
        {
            OracleDb TiptopConn = new OracleDb(FactoryID);
            try
            {
                TiptopConn.ExecuteNonQuery(strSQL).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                TiptopConn = null;
            }
        }

        /// <summary>
        /// SAP更新
        /// </summary>
        /// <param name="strSQL"></param>
        public static void ExecuteNonQuerySap(string strSQL)
        {
            OracleDb TiptopConn = new OracleDb();
            try
            {
                TiptopConn.ExecuteNonQuery(strSQL).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                TiptopConn = null;
            }
        }

    }
}
