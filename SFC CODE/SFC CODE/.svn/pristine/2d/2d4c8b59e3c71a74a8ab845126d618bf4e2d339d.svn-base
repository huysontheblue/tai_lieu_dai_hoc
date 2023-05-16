using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DDTek.Oracle;

namespace LXWarehouseManage
{
    public class OracleDataBaseHelper
    {
        const string connectionString = "Host=topscan.luxshare.com.cn;Port=1521;Service Name=TOPPROD;User ID=MESDG;password=DGMES;";
        private OracleConnection conOra;
        private OracleCommand cmdOra;

        private void CreateConnection()
        {
            conOra = new OracleConnection();
            cmdOra = new OracleCommand();
            conOra.ConnectionString = connectionString;
            try
            {
                conOra.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public DataTable GetDataTable(string strsql)
        {
            OracleDataAdapter darSql = null;
            try
            {
                if (conOra == null)
                {
                    CreateConnection();
                }
                else if (conOra.State == ConnectionState.Closed)
                {
                    conOra.Open();
                }
                DataSet oDs = new DataSet();
                cmdOra.Connection = conOra;
                cmdOra.CommandText = strsql;
                cmdOra.CommandType = CommandType.Text;
                darSql = new OracleDataAdapter(cmdOra);
                darSql.Fill(oDs);
                return oDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (darSql != null)
                {
                    darSql.Dispose();
                }
                if (conOra != null)
                {
                    if (conOra.State == ConnectionState.Open) conOra.Close();
                    conOra.Dispose();
                }
                if (cmdOra != null)
                {
                    cmdOra.Dispose();
                }
            }
        }
    }
}
