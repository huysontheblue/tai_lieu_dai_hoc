using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Net;
using MainFrame.SysCheckData;
using System.Text.RegularExpressions; 
using MainFrame;
using System.Drawing; 

namespace RouteManagement
{
   public abstract class XP1PubServices
    {


        #region 线程 listBox新增item
        /// <summary>
        /// 线程 listBox新增item
        /// </summary>
        /// <param name="msg"></param>
       public static void setlistBoxMsg(string msg, ListBox lstBoxMsg)
        {

            if (lstBoxMsg.Items.Count >= 500)
            {
                lstBoxMsg.Items.Clear();
            }
            if (lstBoxMsg.InvokeRequired)
            {
               
                Action<string> ac = delegate(string txt) { lstBoxMsg.Items.Insert(0, txt + " " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff")); };
                lstBoxMsg.Invoke(ac, msg);
            }
            else
            {
               
                lstBoxMsg.Items.Insert(0, msg + " " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff"));
                lstBoxMsg.Update();
            }
        }
        #endregion

       #region 信息设置
       /// <summary>
       /// 信息设置
       /// </summary>
       /// <param name="msg"></param>
       /// <param name="flag"></param>
       public static void setMsg(string msg, bool flag, Label lblMsg)
       {

           if (lblMsg.InvokeRequired)
           {
               Action<string> ac = delegate(string txt) { lblMsg.Text = txt; };
               lblMsg.Invoke(ac, msg);
           }
           else
           {
               lblMsg.Text = msg;
               lblMsg.Update();
           }
           lblMsg.ForeColor = flag ? System.Drawing.Color.Green : Color.Red;

       }
       #endregion

       private static void setlableThread(string text,Label lbl)
       {
           if (lbl.InvokeRequired)
           {
               Action<string> ac = delegate(string txt) { lbl.Text = txt; };
               lbl.Invoke(ac, text);
           }
           else
           {
               lbl.Text = text;
               lbl.Update();
           }
       }

       #region 判断是否符合规范的SN
       /// <summary>
       /// 判断是否符合规范的SN
       /// </summary>
       /// <param name="sn">SN</param>
       /// <param name="RegexStr">正侧表达式</param>
       /// <returns></returns>
       public static bool SNIsOK(string sn, string RegexStr)
       {
           bool yy = true;
           try
           {
               Regex re = new Regex(RegexStr);
               yy = re.IsMatch(sn);
           }
           catch (Exception)
           {
               yy = false;
           }
           return yy;
       }
       #endregion

       #region 获取料号正则表达式
       /// <summary>
       /// 获取料号正则表达式
       /// </summary>
       /// <param name="partid"></param>
       /// <returns></returns>
       public static string getPartStyleFormat(string partid)
       {
           string result = "";
           DataTable dt = DbHelperSQL.Query("select Style_Format_JiaMi  from m_PartStyleFormat where partid='" + partid + "'").Tables[0];
           if (dt.Rows.Count > 0)
           {
               result = dt.Rows[0]["Style_Format_JiaMi"].ToString();
           }
           return result;
       }
       #endregion

       public static bool ChkFun(string Funid)
       {
           int cn = DbHelperSQL.Query("select 1 from dbo.m_UserRight_t where UserID='" + SysMessageClass.UseId + "' and Tkey='" + Funid + "'").Tables[0].Rows.Count;
         return cn > 0 ? true : false;
       }

       private static void setDataGridView(object obj ,DataGridView dgvData)
       {
           dgvData.AutoGenerateColumns = false;
           if (dgvData.InvokeRequired)
           {
               Action<object> ac = delegate(object txt) { dgvData.DataSource = txt; };
               dgvData.Invoke(ac, obj);
           }
           else
           {
               dgvData.DataSource =obj; 
           }
       }

       /// <summary>
       /// 获取当前工单工站过站数量和工单数量
       /// </summary>
       /// <param name="mo">工单</param>
       /// <param name="Stationid">工站</param>
       /// <param name="lblOne"></param>
       /// <param name="lblTwo"></param>
       public static void GetMoQtyAndGoSNQty(string mo, string Stationid, Label lblOne, Label lblTwo)
       {
           try
           {
               string sql = string.Format(@"select a.Moid,a.Moqty,isnull(sum(b.ppidqty),0) AlreadyScanedQty  from dbo.m_Mainmo_t a
			left join m_AssysnD_t  b on b.Moid=a.Moid and b.Stationid='{1}'
			and B.Estateid<>'F' and A.EstateID<>'N' 
			where a.Moid='{0}'
			group by A.Moid,A.Moqty", mo, Stationid);
               DataTable dt = DbHelperSQL.Query(sql).Tables[0];
               if (dt.Rows.Count > 0)
               {
                  // lblOne.Text = dt.Rows[0]["AlreadyScanedQty"].ToString();
                   if(lblTwo!=null)
                   {
                       setlableThread(dt.Rows[0]["Moqty"].ToString(), lblTwo);
                   }
                   int total = Convert.ToInt32(dt.Rows[0]["AlreadyScanedQty"].ToString());
                   
                   if(lblOne!=null)
                   {
                       setlableThread(total.ToString(), lblOne);
                   }
                   
               }
           }
           catch (Exception)
           {

           }
           
       }

       /// <summary>
       /// 过站成功,自动累加,减轻服务器负荷
       /// </summary>
       /// <param name="LabCartonQty"></param>
       /// <param name="dgvData"></param>
       public static void AutoClacNum(Label LabCartonQty, DataGridView dgvData)
       {
           try
           {
               int AlreadyScanedQty=0;
               if (LabCartonQty != null)
               {
                   int CartonQty = Convert.ToInt32(LabCartonQty.Text) + 1;
                   LabCartonQty.Text = CartonQty.ToString();
                   LabCartonQty.Update();
               }
               if (dgvData.DataSource != null)
               {
                   object ds = dgvData.DataSource;
                   if (ds != null)
                   {
                       DataTable dt = ds as DataTable;
                       if (dt.Rows.Count > 0)
                       {
                           DataRow dr = dt.Rows[0];
                           AlreadyScanedQty = Convert.ToInt32(dr["AlreadyScanedQty"]) + 1;
                           dr["AlreadyScanedQty"] = AlreadyScanedQty;
                       }
                   }
               }
           }
           catch (Exception)
           {

           }
           
       }

       /// <summary>
       /// 每日生产明细
       /// </summary>
       /// <param name="mo"></param>
       /// <param name="Stationid"></param>
       /// <param name="dgvData"></param>
       public static void GetMoQtyAndGoSNQtyDetails(string mo, string Stationid, DataGridView dgvData)
       {
           try
           {
               if (dgvData != null)
               {
                   string sql = string.Format(@"select a.Moid,isnull(sum(b.ppidqty),0) AlreadyScanedQty,isnull(b.Spoint,'{2}') Spoint
                    ,convert(varchar(10),isnull(b.Intime,getdate()),120) Intime  from dbo.m_Mainmo_t a
			        left join m_AssysnD_t  b on b.Moid=a.Moid and b.Stationid='{1}'
			        and B.Estateid<>'F' and A.EstateID<>'N' and  b.Spoint='{2}'
			        where a.Moid='{0}' 
			     group by A.Moid,b.Spoint,convert(varchar(10),isnull(b.Intime,getdate()),120) 
                  order by convert(varchar(10),isnull(b.Intime,getdate()),120) desc", mo, Stationid, Dns.GetHostName());
                   DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                   string dtime = Convert.ToDateTime(DbHelperSQL.GetSingle("select getdate()")).ToString("yyyy-MM-dd");
                   if (dt.Select("Intime='" + dtime + "'").Length == 0)
                   {
                       DataRow dr = dt.NewRow();
                       dr["Moid"] = mo;
                       dr["AlreadyScanedQty"] = 0;
                       dr["Intime"] = dtime;
                       dt.Rows.InsertAt(dr, 0);
                   }
                   setDataGridView(dt, dgvData);
               }

           }
           catch (Exception)
           {
               
           }
           
       }

       /// <summary>
       /// 文件是否被占用
       /// <param name="file"></param>
       /// <returns></returns>
       public static bool IsFileUse(string file)
       {
           bool yy = true;
           try
           {
               using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None))
               {
                   yy = false;
               }
           }
           catch
           {
               yy = true;
           }

           return yy;
       }

       ///// <summary>
       ///// 播放资源文件的wav
       ///// </summary>
       ///// <param name="IsPass"></param>
       //public static void PlaySimpleSound(bool IsPass)
       //{ 
       //    SoundPlayer sdp=null;
       //    if (IsPass)
       //    {
       //        sdp = new SoundPlayer(Resource1.ok_zhcn);//播放成功的声音
       //    }
       //    else
       //    {
       //        sdp = new SoundPlayer(Resource1.fail_zhcn);//播放失败的声音
       //    }
              
       //    sdp.Play();
       //}

       //#region 过站
       ///// <summary>
       ///// SFC 过站
       ///// </summary>
       ///// <param name="SN">过站SN</param>
       ///// <param name="ErrorMsg">过站失败抛出异常信息</param>
       ///// <returns></returns>
       //public static bool GoStation(string SN,ref string ErrorMsg,ListBox lsb)
       //{
       //    bool result = true;
       //    string Sqlstr = "";
       //    try
       //    {
       //        string temp = WorkStantOption.vmReplaceArray[WorkStantOption.vCurrentStandIndex, 1];
       //        temp = string.IsNullOrEmpty(temp) ? "" : temp;
       //        WorkStantOption.vCurrentStandIndex = WorkStantOption.vCurrentStandIndex == 0 ? 1 : WorkStantOption.vCurrentStandIndex;
       //        temp = temp.IndexOf('|') > 0 ? temp.Split('|')[1] : temp;
       //        temp = string.IsNullOrEmpty(temp) ? WorkStantOption.PartidStr : temp;

       //        Sqlstr = Sqlstr + " DECLARE @strmsgid varchar(10),@strmsgText nvarchar(100),@currqty int, @NewSBarCode nvarchar(100),@CompleteFlag int ";
       //        Sqlstr = Sqlstr + " execute [m_CheckPallMulletAssemblyPPID_P_BU4] '" + SN + "', ";
       //        Sqlstr = Sqlstr + " '" + WorkStantOption.MoidStr.Trim() + "','" + WorkStantOption.LineStr.Trim() + "','" + Dns.GetHostName() + "','" + SysMessageClass.UseId + "',";
       //        Sqlstr = Sqlstr + "'" + WorkStantOption.PartidStr.Trim() + "','" + temp + "','" + SN + "',";
       //        Sqlstr = Sqlstr + " '" + WorkStantOption.vStandId + "' ,'" + WorkStantOption.vStandIndex + "','" + WorkStantOption.vCurrentStandIndex + "',";
       //        Sqlstr = Sqlstr + " '" + WorkStantOption.vPreStation + "','" + WorkStantOption.vStandMaxStaIndex + "','0', '" + WorkStantOption.vProductSame + "',  'N',";
       //        Sqlstr = Sqlstr + "@strmsgid output,@strmsgText output,@currqty output,@NewSBarCode output,@CompleteFlag output  ";
       //        Sqlstr = Sqlstr + " select @strmsgid,@strmsgText,isnull(@currqty,1),@NewSBarCode AS NewBarCode, ISNULL(@CompleteFlag,0) AS CompleteFlag";

       //        DataTable dt = DbOperateUtils.GetDataTable(Sqlstr);
       //        if (dt.Rows.Count > 0)
       //        {
       //            string ReturnFlag = dt.Rows[0][0].ToString();
       //            string strmsgText = dt.Rows[0][1].ToString();
       //            if ("0,1,2,3,5".Contains(ReturnFlag))
       //            {
       //                 result =false;
       //                ErrorMsg ="SN:" + SN + "," + WorkStantOption.vStandName.Trim() + "过站异常:" + dt.Rows[0][1].ToString();
       //                XP1PubServices.PlaySimpleSound(false);
       //                setlistBoxMsg(ErrorMsg, lsb);
       //            }
       //            else if (ReturnFlag == "10")
       //            {
       //                 result =false;
       //                 ErrorMsg =WorkStantOption.vStandName.Trim()+"过站异常,MES已经有一笔过站记录,工单:" + "SN:" + SN + ",工单:" + WorkStantOption.MoidStr.Trim();
       //                XP1PubServices.PlaySimpleSound(false);
       //                setlistBoxMsg(ErrorMsg, lsb);
       //            }
       //            else
       //            {
       //                ErrorMsg=WorkStantOption.vStandName.Trim()+"过站成功,SN:" + SN + ";工单:" + WorkStantOption.MoidStr + "";
       //                XP1PubServices.PlaySimpleSound(true);
       //                setlistBoxMsg(ErrorMsg, lsb);
       //            }
       //        }
       //    }
       //    catch (Exception ex)
       //    {
       //        result = false;
       //        ErrorMsg="过站异常:" + ex.Message + "SN:" + SN + ",工单:" + WorkStantOption.MoidStr.Trim();
       //        XP1PubServices.PlaySimpleSound(false);
       //        setlistBoxMsg(ErrorMsg, lsb);
       //    }
       //    finally
       //    {
       //        System.GC.Collect();
       //    }
       //    return result;
       //}
       //#endregion

    }
}
