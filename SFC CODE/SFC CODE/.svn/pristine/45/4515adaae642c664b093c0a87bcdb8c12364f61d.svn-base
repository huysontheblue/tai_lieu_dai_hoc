using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Reflection;
//using System.Data.OracleClient;
using System.Xml;
using System.Drawing;

namespace SMTClass
{
    class SMTCommon
    {
        public static string g_sFileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion.ToString();  //郎セ 
        public static string g_sFileName = Path.GetFileName(FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileName); //郎嘿          
       // public static string g_sExeName = ClientUtils.fCurrentProject;
  

        //public static DialogResult Show_Message(string sKeyMsg, int iType)
        //{
        //    string sXMLFile = Path.GetFileNameWithoutExtension(g_sFileName);
        //     return nothing  ;  // ClientUtils.ShowMessage(sKeyMsg, iType, g_sExeName, sXMLFile);
        //}



        public static string SetLanguage(string sSearchText, string sDefaultTxt, int iTransType)
        {
            string sText = SetLanguage(sSearchText, iTransType);
            if (sText != sSearchText)
                return sText;
            else
                return sDefaultTxt;
        }
        public static string SetLanguage(string sSearchText)
        {
            string sXMLFile = "";
            string sText = "";

            sXMLFile = Path.GetFileNameWithoutExtension(g_sFileName); //Dll.xml
           // sText = ClientUtils.SetLanguage(sSearchText, g_sExeName, sXMLFile);
            if (sSearchText == sText)
            {
                sXMLFile = ""; //g_sExeName; //Program.xml
              //  sText = ClientUtils.SetLanguage(sSearchText, g_sExeName, sXMLFile);
            }           
            return sText;
        }
        public static string SetLanguage(string sSearchText, int iTransType)
        {
            string sXMLFile = "";
            switch (iTransType)
            {
                case 1:  //Dll.xml
                    sXMLFile = Path.GetFileNameWithoutExtension(g_sFileName);
                    break;
                case 2:  //Program.xml
                    sXMLFile = "" ; //g_sExeName;
                    break;
            }
           string sText =""; // ClientUtils.SetLanguage(sSearchText, g_sExeName, sXMLFile);
            return sText;
        }
        public static void SetLanguageControl(Control c)
        {
            string sXMLFile = Path.GetFileNameWithoutExtension(g_sFileName);
           // ClientUtils.SetLanguage(c, g_sExeName, sXMLFile);
          //  ClientUtils.SetLanguage(c, g_sExeName, g_sExeName);
        }

        public static string GetSysBaseData(string sProgram, string sParamName, ref string sErrorMsg)
        {
            //弄SYS_BASE砞﹚
            string sSQL = "";
            sSQL = " SELECT PARAM_VALUE "
                 + "   FROM SAJET.SYS_BASE "
                 + "  WHERE Upper(PROGRAM) = '" + sProgram.ToUpper() + "' "
                 + "    and Upper(PARAM_NAME) = '" + sParamName.ToUpper() + "' ";
            DataSet dsTemp = MainFrame.DbOperateUtils.GetDataSet(sSQL);
            if (dsTemp.Tables[0].Rows.Count > 0)
                return dsTemp.Tables[0].Rows[0]["PARAM_VALUE"].ToString();
            else
            {
                sErrorMsg = sErrorMsg + sParamName + Environment.NewLine;
                return "";
            }
        }

        public static string GetID(string sTable, string sFieldID, string sFieldName, string sValue)
        {
            return GetID(sTable, sFieldID, sFieldName, sValue, "");
        }
        public static string GetID(string sTable, string sFieldID, string sFieldName, string sValue,string sEnabled)
        {
            //т逆ID
            if (string.IsNullOrEmpty(sValue))
                return "0";
            string sSQL = "select " + sFieldID + " from " + sTable + " "
                        + "where " + sFieldName + " = '" + sValue + "' ";
            if (!string.IsNullOrEmpty(sEnabled))
                sSQL = sSQL + " and ENABLED = '" + sEnabled + "' ";
            sSQL = sSQL + " and Rownum = 1 ";

            DataSet dsTemp = MainFrame.DbOperateUtils.GetDataSet(sSQL);
            if (dsTemp.Tables[0].Rows.Count > 0)
                return dsTemp.Tables[0].Rows[0][sFieldID].ToString();
            else
                return "0";
        }

        public static bool CheckEnabled(string sType, string sPrivilege)
        {
            try
            {
                string sSQL = " SELECT SAJET.SJ_PRIVILEGE_DEFINE('" + sType + "','" + sPrivilege + "') TENABLED from DUAL ";
              //  DataSet dsTemp = ClientUtils.ExecuteSQL(sSQL);
                DataSet dsTemp = MainFrame.DbOperateReportUtils.GetDataSet(sSQL);

                string sRes = dsTemp.Tables[0].Rows[0]["TENABLED"].ToString();
                return (sRes == "Y");
            }
            catch (Exception ex)
            {
               // SajetCommon.Show_Message("Function:SAJET.SJ_PRIVILEGE_DEFINE" + Environment.NewLine + ex.Message, 0);

                return false;
            }
        }

        public static DateTime GetSysDate()
        {
            string sSQL = " SELECT GETDATE() ";
            DataTable o_dt =  MainFrame.DbOperateUtils.GetDataTable(sSQL);
            return Convert.ToDateTime(o_dt.Rows[0][0]);
        }

    }
}
