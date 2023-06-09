using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Data;
//using System.Data.OracleClient;
using DDTek.Oracle;
using MainFrame;
namespace SysBasicClass
{

    #region Oracle 数据库
    public class OracleDb
    {
        
        private OracleConnection conOra;
        private OracleCommand cmdOra;
        private OracleTransaction tranOra;
        private string _Value;
        private bool _State = true;
        public static string connectionString;

        /// <summary>
        /// 连接SAP
        /// </summary>
        public OracleDb()
        {
            //Host = topscan.luxshare.com.cn; Port = 1521; Service Name = TOPPROD; User ID = MESDG; Password = DGMES;
            //connectionString = "Host=172.20.23.125; Port=1521; Service Name=sap.luxshare.com.cn; User ID=EDSAP; Password=SVycMWNb;";
            connectionString = SysBasicClass.OracleOperateUtils.connectionStringSap;
        }

        /// <summary>
        /// 连接TT
        /// </summary>
        /// <param name="conString"></param>
        public OracleDb(string conString)
        {
            //connectionString = "Data Source=TOPPROD;user=LX21;password=lux9988;";
            //switch (conString)
            //{
            //    case "LXXT":

            //        break;
            //    case "LXXT":

            //        break;
            //    case "LXXT":

            //        break;
            //    default:

            //        break;
            //}

            //connectionString = "Data Source=TOPPROD;user=MESDG;password=DGMES;";
            connectionString = DBUtility.DbOracleHelperSQL.connectionString;// "Host=topscan.luxshare.com.cn;Port=1521;Service Name=TOPPROD;User ID=MESDG;Password=DGMES;";
            //测试区
            //connectionString = "Data Source=test;user=LX11;password=l6644;";
            //connectionString = "Data Source=TOPDEV;user=LX11;password=l6644;";
            //connectionString = conString;

        }
        public string Value
        {
            get { return _Value; }
        }
        public bool State
        {
            get { return _State; }
        }

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
                _State = false;
                
                
                _Value = ex.Message.ToString();
                throw new Exception(ex.Message.ToString());
            }
        }


        public bool IsExsitRecord (string strSql)
        {
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
                cmdOra.Connection = conOra;
                cmdOra.CommandText = strSql;
                cmdOra.CommandType = CommandType.Text;
                OracleDataReader thisReader = cmdOra.ExecuteReader();   
                
                if (thisReader.HasRows)
                {
                    thisReader.Close();
                    return true;
                }
                thisReader.Close();
                return false;
            }
            catch (Exception ex)
            {
               
                _State = false;
                _Value = ex.Message.ToString(); 
                throw new Exception(ex.Message.ToString());
               // return false;
            }
            //        finally
            //        {
            //            conOra.Close();
            //        }

        }
      
        public DataView getDataView(string strSql)
        {
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
                cmdOra.Connection = conOra;
                cmdOra.CommandText = strSql;
                cmdOra.CommandType = CommandType.Text;
                OracleDataAdapter adr = new OracleDataAdapter(cmdOra);
                DataSet ds = new DataSet();
                adr.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dtv = new DataView(ds.Tables[0]);
                    return dtv;

                }
                return null;
            }
            catch (Exception ex)
            {
               
                _State = false;
                _Value = ex.Message.ToString();
                throw new Exception(ex.Message.ToString());
              //  return null;
            }
            finally
            {
                //写日志 
                DbOperateUtils.WriteLog(strSql);
            }
        }

        public Int32 getDataRows(string strSql)
        {
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
                
                cmdOra.Connection = conOra;
                cmdOra.CommandText = strSql;
                cmdOra.CommandType = CommandType.Text;
                OracleDataAdapter adr = new OracleDataAdapter(cmdOra);
                DataSet ds = new DataSet();
                adr.Fill(ds);
                return ds.Tables[0].Rows.Count;
            }
            catch (Exception ex)
            {
                _State = false;
                _Value = ex.Message.ToString();
                return -1;
            }
            finally
            {
                //写日志 
                DbOperateUtils.WriteLog(strSql);
            }
        }


///</summary> 　
///<paramname="sql">查询语句</param> 　
        ///<returns>OracleDataReader</returns>　
  #region"oraclereader"
        public OracleDataReader ExecuteReader(string strSql) 　
{ 　
          OracleDataReader myReader; 
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

                OracleCommand cmd = new OracleCommand(strSql, conOra); 　
                myReader=cmd.ExecuteReader(CommandBehavior.CloseConnection); 　
                return myReader; 
             }
       catch (Exception ex)
        {
            _State = false;
            _Value = ex.Message.ToString();
            return null;
        }
       finally
       {
           //写日志 
           DbOperateUtils.WriteLog(strSql);
       }
}
#endregion


  public DataSet ExecuteQuery(string strSql)
        {
            try
            {
                //写日志 
                DbOperateUtils.WriteLog(strSql);

                if (conOra == null)
                {
                    CreateConnection();
                }
                else if (conOra.State == ConnectionState.Closed)
                {
                    conOra.Open();
                }
                DataSet oDs = new DataSet();
                OracleDataAdapter darSql;
                cmdOra.Connection = conOra;
                cmdOra.CommandText = strSql;
                cmdOra.CommandType = CommandType.Text;
                if (tranOra != null)
                {
                    cmdOra.Transaction = tranOra;
                }
                darSql = new OracleDataAdapter(cmdOra);
                darSql.Fill(oDs);
                return oDs;
            }
            catch (Exception ex)
            {
               
                _State = false;
                _Value = ex.Message.ToString();
                throw new Exception(ex.Message.ToString());
               // return null;
            }
            finally
            {
                //写日志 
                DbOperateUtils.WriteLog(strSql);
            }
        }

        //public DataSet ExecuteNonQuery(string strSql) 
        public int ExecuteNonQuery(string strSql)
        {
            int n = 0;
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
                //DataSet oDs = new DataSet();

                //oDs.Tables.Add();
                //oDs.Tables[0].Columns.Add("Result");
                //oDs.Tables[0].Columns.Add("Sql");
                //oDs.Tables[0].Columns.Add("Raw Msg");
                //DataRow oDr = oDs.Tables[0].NewRow();

                cmdOra.Connection = conOra;
                cmdOra.CommandText = strSql;
                cmdOra.CommandType = CommandType.Text;
                if (tranOra != null)
                {
                    cmdOra.Transaction = tranOra;
                }
                //oDr[0] = cmdOra.ExecuteNonQuery();
                n = cmdOra.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                n = -9999;
                RollBack();
                _State = false;
                _Value = ex.Message.ToString();
                throw new Exception(ex.Message.ToString());
            }
            finally 
            {
                //写日志 
                DbOperateUtils.WriteLog(strSql);
            }
            //oDs.Tables[0].Rows.Add(oDr);
            //return oDs;

            //        finally
            //        {
            //            conOra.Close();
            //        }
            return n;
        }
        //执行带参数的SQL
        public int ExecuteNonQuery(string strSql, params OracleParameter[] commandParameters)
        {
            int n = 0;
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
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conOra;
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;      
                if (tranOra != null)
                {
                    cmd.Transaction = tranOra;
                }
                PrepareCommand(cmd,ref commandParameters);
                n = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return n;
            }
            catch (Exception ex)
            {
                
                n = -9999;
                RollBack();
                _State = false;
                _Value = ex.Message.ToString();
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                //写日志 
                DbOperateUtils.WriteLog(strSql);
            }
           // return n;
        }
        //执行返回单值的SQL
        public object ExecuteScalar(string strSql)
        {
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

                cmdOra.Connection = conOra;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conOra;
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                object val = cmd.ExecuteScalar();
                return val;

            }
            catch (Exception ex)
            {
               
                _State = false;
                _Value = ex.Message.ToString();
                 throw new Exception(ex.Message.ToString());
                //return ex.Message.ToString();

            }
            finally
            {
                //写日志 
                DbOperateUtils.WriteLog(strSql);
            }
        }
        // 执行带参数存储过程并返回数据集合
        public DataSet ExecuteProcedures(string procName, ref OracleParameter[] commandParameters)
        {
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

                cmdOra = new OracleCommand();
                cmdOra.Connection = conOra;
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter();

                cmdOra.CommandType = CommandType.StoredProcedure;
                cmdOra.CommandText = procName;
                PrepareCommand(cmdOra, ref commandParameters);

                da.SelectCommand = cmdOra;
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            { _State = false;
               
               
                _Value = ex.Message.ToString();
                //return null;
 throw new Exception(ex.Message.ToString());
            }
            finally
            {
                //写日志 
                DbOperateUtils.WriteLog(procName);
            }
        }
        //带参数的SQL_返回参数
        private void PrepareCommand(OracleCommand cmd, ref OracleParameter[] cmdParms)
        {
            //if (conn.State != ConnectionState.Open)
            //    conn.Open();
            //cmd.Connection = conn;
            //cmd.CommandText = cmdText;

            //if (trans != null)
            //    cmd.Transaction = trans;

            //cmd.CommandType = cmdText;
            if (cmdParms != null)
            {
                foreach (OracleParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        public void BeginTransaxtion()
        {
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
                if (tranOra == null)
                {
                    tranOra = conOra.BeginTransaction();
                }
            }
            catch (Exception ex)
            {
                _State = false;
                _Value = ex.Message.ToString();

            }
        }

        public void EndTransaction()
        {
            if (tranOra != null)
            {
                tranOra.Commit();
                tranOra = null;
            }
        }

        public void RollBack()
        {
            if (tranOra != null)
            {
                tranOra.Rollback();
                tranOra = null;
            }
        }

    }
    #endregion


    public class CryptoMemoryStream
    {
        public static string Encrypt(string pToEncrypt, string sKey)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Convert.ToBase64String(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        public static string Decrypt(string pToDecrypt, string sKey)
        {
            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return str;
            }
        }
    }
}