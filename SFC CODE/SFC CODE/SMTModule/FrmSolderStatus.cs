using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SMTFilter;

namespace SMTModule
{
    public partial class FrmSolderStatus : Form
    {
        public FrmSolderStatus()
        {
            InitializeComponent();
        }

        public FrmSolderStatus(string str)
        {        
            InitializeComponent();
            LabStatus.Text = str;//这句必须放在InitializeComponent();的后面，否则会引起“空引用异常”

            
        }

#region "变量定义"
        String SOLDERREEL, Dacode, part;
        String[] aryStatus = new String[7];
        string sSQL;
        public static String g_sUserID= VbCommClass.VbCommClass.UseId;
        public String g_sProgram, g_sFunction;
        String g_sProgramStatus, g_sSQLStatus;
        String g_sProgramStatus_English;
        //g_sProgramStatus為程式上判斷用的status，g_sSQLStatus為實際存在DB的status
        //程式上面有多一個回冰(R)
        string pickupUser;
        double dSetWaitTime, dSetMixMin, dSetMountTime, dSetUnmountTime;
        int iSetReturnCnt;
        string sSetWaitOption, sSetMixOption, sSetMountOption, sSetUnmountOption, sSetDateCodeOption, sFifoOption;
        string sDefaultDateCode, sSolderPart, sTakeOutTime, sOpenTime;
        DataSet dsTemp;
        string PickUpUserId;
        bool bMemo = false, bWarn = false, bDateWarn = false, g_bReelCheck = false;


#endregion
       

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sPDLineID = "0", sPDLineMsg = "", sTempReel = "";


            if (string.IsNullOrEmpty(SOLDERREEL))
            {
                MainFrame.SysCheckData.MessageUtils.ShowError("请输入锡膏编号！");
                editReelNo.SelectAll();
                editReelNo.Focus();
                return;
            }

            if (!g_bReelCheck)
            {
                KeyPressEventArgs Key = new KeyPressEventArgs((char)Keys.Return);
                editReelNo_KeyPress(sender, Key);
            }
            if (!g_bReelCheck)
                return;

            if (g_sProgramStatus_English == "U" || g_sProgramStatus_English == "P")  //U, P
            {
                if (string.IsNullOrEmpty(combPDLineID.Text))
                {
                    MainFrame.SysCheckData.MessageUtils.ShowError("请输入线别编号！");
                    return;
                }
                sPDLineID = combPDLineID.Text.Trim();  // combPDLineID.Items[combPDLine.SelectedIndex].ToString();
            }

            if (g_sProgramStatus_English == "P")
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MainFrame.SysCheckData.MessageUtils.ShowError("请输入领用人工号");
                    return;
                }
                bool s = CheckEmp(textBox1.Text.ToString());
                if (s == false)
                {
                    MainFrame.SysCheckData.MessageUtils.ShowError("工号错误！");
                    textBox1.Focus();
                    textBox1.SelectAll();
                    return;
                }
                sSQL = "select UserID,UserName  from m_Users_t where UserID='" + textBox1.Text.ToString().Trim() + "'";
                pickupUser = MainFrame.DbOperateUtils.GetDataSet(sSQL).Tables[0].Rows[0][0].ToString();
                PickUpUserId = pickupUser;   //Convert.ToInt32(pickupUser);

            }
            if (bMemo && string.IsNullOrEmpty(editMemo.Text))
            {
                MainFrame.SysCheckData.MessageUtils.ShowError("请输入备注！");
                editMemo.SelectAll();
                editMemo.Focus();
                return;
            }

            string sMsg = "";
            if (g_sProgramStatus_English != "F")
            {
                sMsg = "你要把状态变更为" + LabStatus.Text + "?" ;
                if (MainFrame.SysCheckData.MessageUtils.ShowConfirm(sMsg, MessageBoxButtons.YesNo) != DialogResult.Yes) // 'SajetCommon.Show_Message(sMsg, 2) != DialogResult.Yes'
                {
                    return;
                }
            }

            #region 上料(U)：確認選擇的生產線是否有其他錫膏已上料，如果有，要先把舊的錫膏資料清除
            if (g_sProgramStatus_English == "U")
            {
                sTempReel = CheckPDLine(sPDLineID, g_sProgramStatus);
                sMsg = sMsg + System.Environment.NewLine + "它将会被上料" + ",";
                sMsg = sMsg + "确定要继续？";
                if (MainFrame.SysCheckData.MessageUtils.ShowConfirm(sMsg,MessageBoxButtons.YesNo) == DialogResult.Yes)  //SajetCommon.Show_Message(sMsg, 2) == DialogResult.Yes
                {
                    CopyToHistory(sTempReel);

                    string sUpdateSQL = "UPDATE m_MATERIAL_SOLDER_t "
                               + "SET PDLINE_ID = NULL, LAST_STATUS = CURRENT_STATUS, LAST_TIME = CURRENT_TIMEs, LAST_USERID = CURRENT_USERID, "
                               + "CURRENT_STATUS = 'O', CURRENT_TIMEs = getdate(), CURRENT_USERID = '" + g_sUserID + "' "
                               + "WHERE REEL_NO = '" + sTempReel + "'";
                   // DataSet dsUpdate = ClientUtils.ExecuteSQL(sUpdateSQL);
                    MainFrame.DbOperateUtils.ExecSQL(sUpdateSQL);
                   // sPDLineMsg = SajetCommon.SetLanguage("Solder No", 1) + ": " + sTempReel + " " + SajetCommon.SetLanguage("have been unmounted", 1);
                }
                else
                {
                    sTempReel = "";
                    sPDLineMsg = "";
                    combPDLineID.SelectedIndex = 0;
                    editMemo.Text = "";
                    ClearData();
                    editReelNo.SelectAll();
                    editReelNo.Focus();

                    return;
                }

            }
            #endregion "上料-- end"

            
            if (g_sProgramStatus_English == "S" || g_sProgramStatus_English == "T")
            {
                if (GetCurrentStatus(SOLDERREEL) == "Use")
                {
                    sMsg = "锡膏正在使用" + sTempReel + ", ";
                    sMsg = sMsg + "确定要继续吗？";
                    if ( MainFrame.SysCheckData.MessageUtils.ShowConfirm(sMsg,MessageBoxButtons.YesNo) != DialogResult.Yes) //SajetCommon.Show_Message(sMsg, 2) != DialogResult.Yes
                    {
                        editMemo.Text = "";
                        ClearData();
                        editReelNo.SelectAll();
                        editReelNo.Focus();
                        return;
                    }
                }
            }

            try
            {
                object[][] Params;
                if (g_sProgramStatus_English == "F")   //F
                {
                    string sPartID = part; // GetPartID(SOLDERREEL);
                    sSQL = @"INSERT INTO m_MATERIAL_SOLDER_t 
                             (REEL_NO, PART_ID, CURRENT_STATUS, CURRENT_USERID, CREATE_TIME, CREATE_USERID, DATE_CODE, MEMO)
                             VALUES
                             ('" + SOLDERREEL + "', '" + sPartID + "', 'F', '" + g_sUserID + "', getdate(), '" + g_sUserID + "','" + Dacode + "', '" + editMemo.Text + "') ";

                    //Params = new object[6][];
                    //Params[0] = new object[] { ParameterDirection.Input, SqlDbType.VarChar, "REEL_NO", SOLDERREEL };
                    //Params[1] = new object[] { ParameterDirection.Input, SqlDbType.VarChar, "PART_ID", sPartID };
                    //Params[2] = new object[] { ParameterDirection.Input, SqlDbType.VarChar, "CURRENT_USERID", g_sUserID };
                    //Params[3] = new object[] { ParameterDirection.Input, SqlDbType.VarChar, "CREATE_USERID", g_sUserID };
                    //Params[4] = new object[] { ParameterDirection.Input, SqlDbType.VarChar, "DATE_CODE", Dacode };
                    //Params[5] = new object[] { ParameterDirection.Input, SqlDbType.VarChar, "MEMO", editMemo.Text };

                }
                else
                {
                    CopyToHistory(SOLDERREEL);
                    g_sSQLStatus = g_sProgramStatus_English;
                    sSQL = @"UPDATE m_MATERIAL_SOLDER_t
                             SET LAST_STATUS = CURRENT_STATUS, LAST_TIME = CURRENT_TIMEs, LAST_USERID = CURRENT_USERID,
                             CURRENT_STATUS = '" + g_sSQLStatus + "', CURRENT_TIMEs = getdate(), CURRENT_USERID = '" + g_sUserID + "', MEMO = '" + editMemo.Text + "' ,PICK_EMP_ID='"+ PickUpUserId +"'";


                    switch (g_sProgramStatus_English)
                    {
                        case "W":   //从回温开始算锡膏取出的时间
                            sSQL = sSQL + ", TAKEOUT_TIME = getdate(), TAKEOUT_USERID = '" + g_sUserID + "' ";
                            break;
                        case "M":
                            sSQL = sSQL + ", MIX_MIN = '" + dSetMixMin + "' ";
                            break;
                        case "P":
                            sSQL = sSQL + ", PDLINE_ID = '" + sPDLineID + "' ";
                            break;
                        case "O":
                            sSQL = sSQL + ", OPENED = 'Y', OPEN_TIME = getdate(), OPEN_USERID = '" + g_sUserID + "' ";
                            break;
                        case "R":
                            sSQL = sSQL + ", RETURN_COUNT = " + (int.Parse(LabFreezeCntValue.Text) + 1) + " " + " ,PDLINE_ID='' ";
                            //add by wisher.xiong 20150911 回冰之后取出时间，开封时间清空，开封状态更新为N
                            sSQL = sSQL + ", TAKEOUT_TIME ='',TAKEOUT_USERID ='',OPENED ='N',OPEN_TIME='',OPEN_USERID='' ";
                            //end
                            break;
                        case "U":
                            sSQL = sSQL + ", PDLINE_ID = '" + sPDLineID + "' ";
                            break;
                        case "S":
                            sSQL = sSQL + ", PDLINE_ID = '' ";
                            break;
                        case "T":
                            sSQL = sSQL + ", PDLINE_ID = '' ";
                            break;
                        default:
                            break;
                    }

                    sSQL = sSQL + " WHERE REEL_NO ='" + SOLDERREEL + "' ";
                }

               // dsTemp = MainFrame.DbOperateUtils.GetDataSet(sSQL);   //ClientUtils.ExecuteSQL(sSQL, Params);
                MainFrame.DbOperateUtils.ExecSQL(sSQL);
                sMsg= SOLDERREEL + " " + "锡膏状态已经变成 " + "" + LabStatus.Text;
                if (!string.IsNullOrEmpty(sPDLineMsg))
                {
                    sMsg = sMsg + System.Environment.NewLine + sPDLineMsg;
                }

                lablMsg.Text = sMsg;
                ClearData();

                dSetWaitTime = 0;
                iSetReturnCnt = 0;
                dSetMixMin = 0;
                sSetWaitOption = "";
                sSetMixOption = "";
                editMemo.Text = "";
                bMemo = false;
                bDateWarn = false;
                g_bReelCheck = false;

                if (combPDLineID.Items.Count != 0)
                    combPDLineID.SelectedIndex = 0;

                SOLDERREEL = null;
                // add by catherine 2015.02.11 16:35 更新wo输入栏为空
                tbWO.Text = null;
                // end by catherine 2015.02.11 16:44
                editReelNo.Focus();
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MainFrame.SysCheckData.MessageUtils.ShowError(ex.Message);
                return;
            }
            editReelNo.Focus();
            editReelNo.SelectAll();
        }

        private string GetPartID(string sReelNo)
        {
            sSQL = " SELECT PART_ID FROM SAJET.G_MATERIAL "
                 + " WHERE REEL_NO = '" + sReelNo + "'";
            dsTemp = MainFrame.DbOperateUtils.GetDataSet(sSQL);   //ClientUtils.ExecuteSQL(sSQL);
            if (dsTemp.Tables[0].Rows.Count > 0)
            {
                return dsTemp.Tables[0].Rows[0]["PART_ID"].ToString();
            }
            else
                return "0";
        }


        private bool CheckEmp(string emp)
        {
            sSQL = "select * from m_Users_t where UserID='" + emp + "'";
            DataSet dsTemp = MainFrame.DbOperateUtils.GetDataSet(sSQL);
            if (dsTemp.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        private string CheckPDLine(string sPDLine, string Prograss_status)
        {

            sSQL = "SELECT REEL_NO FROM M_MATERIAL_SOLDER_T "
                 + "WHERE PDLINE_ID = '" + sPDLine + "'  and current_status='" + Prograss_status + "'";

            dsTemp = MainFrame.DbOperateUtils.GetDataSet(sSQL);

            if (dsTemp.Tables[0].Rows.Count > 0)
            {
                return dsTemp.Tables[0].Rows[0]["REEL_NO"].ToString();
            }
            else
                return "";

        }


        #region "获取当前的状态"
        private string GetCurrentStatus(string sReel)
        {

            sSQL =  " SELECT (CASE CURRENT_STATUS when 'F' THEN 'Freeze'  when 'W' THEN 'Wait' when 'M' THEN 'Mix'" +
                     " WHEN 'O' then 'Open'" +
                     " when 'U' THEN 'Use'" +
                     " WHEN 'T' THEN  'Terminate'" +
                     " WHEN  'S' THEN 'Scrap'" +
                     " WHEN 'P' THEN 'Pick' END ) CURRENT_STATUS " +
                     " FROM m_MATERIAL_SOLDER_t " +
                     " WHERE REEL_NO =  '" + sReel + "'";

            dsTemp = MainFrame.DbOperateUtils.GetDataSet(sSQL);
            if (dsTemp.Tables[0].Rows.Count > 0)
            {
                return dsTemp.Tables[0].Rows[0]["CURRENT_STATUS"].ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region "获取下一步的状态"
        private string GetNextStatus(string sCurrent_Status_ID)
        {

            sSQL = " SELECT (CASE Next_Status_ID when 'F' THEN N'入冰库'  when 'W' THEN N'回温' when 'M' THEN N'搅拌'" +
                     " WHEN 'O' then N'开封'" +
                     " when 'U' THEN N'上料'" +
                     " WHEN 'T' THEN  N'用完'" +
                     " WHEN  'S' THEN N'报废'" +
                     " WHEN 'P' THEN N'领用' END ) Next_Status_ID " +
                     " FROM m_SOLDER_STATUS_MOVE_t " +
                     " WHERE Current_Status_ID =  '" + sCurrent_Status_ID.Substring(0, 1) + "'  AND Next_Status_ID <> 'S'";

            dsTemp = MainFrame.DbOperateUtils.GetDataSet(sSQL);
            if (dsTemp.Tables[0].Rows.Count > 0)
            {
                return dsTemp.Tables[0].Rows[0]["Next_Status_ID"].ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region "清除界面数据"
        private void ClearData()
        {
            LabPartValue.Text = "";
            LabCurrentStatusValue.Text = "";
            LabFreezeCntValue.Text = "";
            LabDateCodeValue.Text = "";
            LabPDLineValue.Text = "";
            LabCreateTimeValue.Text = "";
            LabCurrentTimeValue.Text = "";
            LabMixMinValue.Text = "";

            g_bReelCheck = false;
            dgvTravel.Rows.Clear();
        }
        #endregion

        #region "保存当前资料到历史资料库中"
        private void CopyToHistory(string sReelNo)
        {
            try
            {
                sSQL = " INSERT INTO M_MATERIAL_SOLDER_HT_T "
                     + " SELECT * FROM m_MATERIAL_SOLDER_t "
                     + " WHERE REEL_NO = '" + sReelNo + "'";
                dsTemp = MainFrame.DbOperateUtils.GetDataSet(sSQL);
            }
            catch (Exception ex)
            {
               // SajetCommon.Show_Message(ex.Message, 0);
                MainFrame.SysCheckData.MessageUtils.ShowError(ex.Message);
                return;
            }
        }
#endregion

        private void btnSearchReel_Click(object sender, EventArgs e)
        {
            sSQL = "";
            if (g_sProgramStatus_English == "F")
            {
                sSQL = @"SELECT REEL_NO,DATECODE FROM SAJET.G_MATERIAL 
                         WHERE STATUS = 0 
                         AND REEL_NO NOT IN (SELECT REEL_NO FROM SAJET.G_MATERIAL_SOLDER)
                         AND PART_ID IN (SELECT PART_ID FROM SAJET.SYS_SOLDER_PART WHERE ENABLED='Y') "
                     + "ORDER BY REEL_NO";
                //END BY NICOLE
            }
            else
            {             //MODIFY BY NICOLE 20161201 增加查询DATECODE
                sSQL = @"SELECT REEL_NO,DATE_CODE FROM SAJET.G_MATERIAL_SOLDER
                         WHERE CURRENT_STATUS IN
                         (SELECT CURRENT_STATUS_ID FROM SAJET.SYS_SOLDER_STATUS_MOVE
                          WHERE NEXT_STATUS_ID = '" + g_sSQLStatus + "') ORDER BY REEL_NO";
                //END BY NICOLE
            }

            fFilter f = new fFilter();
            f.sSQL = sSQL;
            if (f.ShowDialog() == DialogResult.OK)
            {
                SOLDERREEL = f.dgvData.CurrentRow.Cells["REEL_NO"].Value.ToString();
                KeyPressEventArgs Key = new KeyPressEventArgs((char)Keys.Return);
                editReelNo_KeyPress(sender, Key);
            }       
        }

        private void editReelNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            lablMsg.Text = "";

            if (e.KeyChar != (char)Keys.Return)
            {
                return;
            }

            string sMsg = "";
            string sCurrentStatus = "";
            //直接在入冰库的时候解析扫描的二维码吗  跳过入库动作 检查料号 ADD BY CHRIS 2018-12-03

            string str = editReelNo.Text.Trim();
            string[] sArray = str.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
            part = sArray[0];
            string CNUM = sArray[1];
           // string c = sArray[2];
            //string d = sArray[3];
            //string h = sArray[4];
            //string f = sArray[5];
            //string de = CNUM;
            int start = 1, length = 6;
            Dacode = CNUM.Substring(start - 1, length);
            SOLDERREEL = part + CNUM;
            string PARTID = part;   //GetNEWPartID(part);
            g_sProgramStatus = LabStatus.Text.Trim();
            g_sProgramStatus_English = GetEngLishStatusName(LabStatus.Text.Trim());

            //界面显示控制
            if (g_sProgramStatus_English == "U")
            {
                this.combPDLineID.Visible = true;

            }


            if (g_sProgramStatus_English == "W")  //回温W
            {
                string SOLDER_TIME;
                string MIXsoldertime;
                string sssql = "SELECT CREATE_TIME FROM m_material_solder_t WHERE REEL_NO = '" + SOLDERREEL + "' AND PART_ID = '" + PARTID + "'";
                DataSet ddsb = MainFrame.DbOperateUtils.GetDataSet(sssql);
                if (ddsb.Tables[0].Rows.Count > 0)
                {
                    SOLDER_TIME = ddsb.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    MainFrame.SysCheckData.MessageUtils.ShowError("锡膏信息不存在，请检查!");
                    editReelNo.SelectAll();
                    editReelNo.Focus();
                    return;
                }

                string SsQL = "SELECT MIN(CREATE_TIME) FROM m_material_solder_t WHERE CURRENT_STATUS = 'F' AND PART_ID = '" + PARTID + "'";
                DataSet ddsa = MainFrame.DbOperateUtils.GetDataSet(SsQL);
                if (ddsa.Tables[0].Rows.Count > 0)
                {
                    MIXsoldertime = ddsa.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    MainFrame.SysCheckData.MessageUtils.ShowError("锡膏信息不存在，请确认已入库!");
                    editReelNo.SelectAll();
                    editReelNo.Focus();
                    return;
                }
                //string MIXsoldertime = ddsa.Tables[0].Rows[0][0].ToString();
                //string reelno = ddsa.Tables[0].Rows[0][1].ToString();
                if (SOLDER_TIME != MIXsoldertime)
                {
                    //MainFrame.SysCheckData.MessageUtils.ShowError("冰库有更早锡膏,请确认!");
                    //editReelNo.SelectAll();
                    //editReelNo.Focus();
                    //return;
                }
            }

            if (g_sProgramStatus_English == "R") //R; 回冰
            {
                string SsQL = "SELECT CURRENT_STATUS  FROM m_material_solder_t WHERE  PART_ID = '" + PARTID + "'";
                DataSet ddsa = MainFrame.DbOperateUtils.GetDataSet(SsQL);
                if (ddsa.Tables[0].Rows.Count > 0)
                {
                    if (ddsa.Tables[0].Rows[0][0].ToString() == "T")
                    {
                        MainFrame.SysCheckData.MessageUtils.ShowError("锡膏已用完，不可回冰!");
                        editReelNo.SelectAll();
                        editReelNo.Focus();
                        return;
                    }
                }
            }

            #region "F：入冰库  Freeze" 
            if (g_sProgramStatus_English == "F") //F
            {
                //if (!CheckPart(part))
                //{
                //    sMsg = SajetCommon.SetLanguage("Solder part no error", 1);
                //    SajetCommon.Show_Message(sMsg, 0);
                //    editReelNo.SelectAll();
                //    editReelNo.Focus();
                //    return;
                //}

                //try
                //{
                //    string sql = "insert into sajet.G_MATERIAL(RT_ID,PART_ID,DATECODE,REEL_NO,REEL_QTY,UPDATE_USERID,RT_RECEIVE_TIME) " +
                //           " values ('0','" + PARTID + "','" + Dacode + "','" + SOLDERREEL + "','1','" + g_sUserID + "',getdate())";
                //  //  DataSet ds = ClientUtils.ExecuteSQL(sql);
                //    MainFrame.DbOperateUtils.ExecSQL(sql);
                //}
                //catch (Exception EX)
                //{
                //    throw;
                //}
                //end 入冰库时卡仓库中的锡膏的datecode和流水号
            }
            #endregion

            int iCheckStatus = CheckReelStatus(SOLDERREEL);
            //0: 狀態OK
            //1: 已經進到錫膏管裡，但狀態不對
            //2: 還在G_MATERIAL，但狀態不對(入冰庫狀態才會碰到)
            if (iCheckStatus == 1)
            {
                sCurrentStatus = GetCurrentStatus(SOLDERREEL); //如果錯誤抓一下它現在狀態是什麼
                if (!string.IsNullOrEmpty(sCurrentStatus))
                {

                    if (sCurrentStatus == "Scrap" )
                    {
                        sMsg = sMsg + " 已经报废，不允许变使用,请检查!";
                        MainFrame.SysCheckData.MessageUtils.ShowError(sMsg);
                        editReelNo.SelectAll();
                        editReelNo.Focus();
                        return;
                    }

                    labNextStatus.Text = GetNextStatus(sCurrentStatus);

                    if (labNextStatus.Text.Trim() !=g_sProgramStatus.Trim()  && g_sProgramStatus_English!="S")
                    {
                        sMsg = sMsg + " 请先完成:  '" + labNextStatus.Text + "'";
                        MainFrame.SysCheckData.MessageUtils.ShowError(sMsg);
                        editReelNo.SelectAll();
                        editReelNo.Focus();
                        return;
                    }

                }
                else
                {
                    if (g_sProgramStatus_English!="F")
                    {
                        sMsg = sMsg + " 请先做入冰库的动作!";
                        MainFrame.SysCheckData.MessageUtils.ShowError(sMsg);
                        editReelNo.SelectAll();
                        editReelNo.Focus();
                        return;
                    }
                }

            }
            else if (iCheckStatus == 2)
            {
                sMsg = "锡膏编号错误！";
                MainFrame.SysCheckData.MessageUtils.ShowError(sMsg);
                editReelNo.SelectAll();
                editReelNo.Focus();
                return;
            }

            GetInfo(SOLDERREEL);        //获取当前锡膏状态信息，显示在textbox里面
            GetTravel(SOLDERREEL);     //获取到锡膏经历过的操作
            GetSetupTime();      //获取锡膏设定的值

            //End --Added by Buson  2014-12-05 for RukingEmerson  提示中显示Datacode
            string sSQL;
            DataSet dsTemp;
            string dateCode;
            string time;

            //sSQL = "select a.datecode,a.INVENTORY_TIME from g_material a where a.reel_no='" + SOLDERREEL + "'";
            //dsTemp = MainFrame.DbOperateUtils.GetDataSet(sSQL);


            //此锡膏在入库时候的datecode
           // dateCode = dsTemp.Tables[0].Rows[0][0].ToString();
            //time = dsTemp.Tables[0].Rows[0][1].ToString();
            //End --Added by Buson  2014-12-05 for RukingEmerson  提示中显示Datacode

            double dOpenHrs;
            bool bIsOpened = false;

            #region 檢查 (1)DateCode期限 (2)開封保存期限(按照SetUp)  不是F-入冰库、T-用完、S-报废 的狀態才要檢查, add !="W",add !="M", cq 20190507
            if (g_sProgramStatus_English != "F" && g_sProgramStatus_English != "T" && g_sProgramStatus_English != "S" && g_sProgramStatus_English !="W" ) // && !bDateWarn
            {

                //檢查DateCode期限
                //int iDateCode = ClientUtils.GetSysDate().CompareTo(DateTime.Parse(LabDateCodeValue.Text));
                if (!string.IsNullOrEmpty(LabDateCodeValue.Text))
                {
                    int iDateCode = Convert.ToInt32(LabDateCodeValue.Text);
                }
              
                //檢查開封保存期限
                //狀態正好為上料(U)的，因為travel裡面也許沒有資料所以要在主檔找
                sSQL = @"SELECT OPENED FROM m_MATERIAL_SOLDER_t
                            WHERE REEL_NO = '" + SOLDERREEL + "' ";
                dsTemp = MainFrame.DbOperateUtils.GetDataSet(sSQL);

                #region 先检查是否开封，比较是否超过开封限制时间，如果没有超过，就比较是否超过了拿出时间设定
                if (dsTemp.Tables[0].Rows[0]["OPENED"].ToString() == "Y")
                {
                    dOpenHrs = SMTClass.SMTCommon.GetSysDate().Subtract(DateTime.Parse(sOpenTime)).TotalHours;
                    if (dOpenHrs > dSetMountTime)
                    {
                        if (sSetMountOption == "U")
                        {
                          //  SajetCommon.Show_Message(SajetCommon.SetLanguage("Solder opened over", 1) + " " + dSetMountTime + " " + SajetCommon.SetLanguage("hr(s)", 1), 1);
                            sMsg = "锡膏开封时间超过" + " " + dSetMountTime + " " + "hr(s)";
                            MainFrame.SysCheckData.MessageUtils.ShowError("");
                            ClearData();
                            editMemo.Text = "";
                            editReelNo.SelectAll();
                            editReelNo.Focus();
                            return;
                        }
                        else
                        {
                            //sMsg = SajetCommon.SetLanguage("Solder opened over", 1) + " " + dSetMountTime + " " + SajetCommon.SetLanguage("hr(s)", 1) + ", ";
                            //sMsg = sMsg + System.Environment.NewLine + SajetCommon.SetLanguage("sure to continue", 1) + "?";
                            sMsg = "锡膏开封超过" + " " + dSetMountTime + " " + "hr(s)" + ", ";
                            sMsg = sMsg + System.Environment.NewLine + "确定继续吗?";
                            if (MainFrame.SysCheckData.MessageUtils.ShowConfirm(sMsg, MessageBoxButtons.YesNo) != DialogResult.Yes) //SajetCommon.Show_Message(sMsg, 2) != DialogResult.Yes
                            {
                                //bDateWarn = false;
                                bMemo = false;
                                ClearData();
                                editMemo.Text = "";
                                editReelNo.SelectAll();
                                editReelNo.Focus();
                                return;
                            }
                            else
                            {
                                //bDateWarn = true;
                                bMemo = true;
                            }
                        }
                    }
                }
                #endregion

                #region 比较是否超过了拿出时间设定
                else
                {
                    dOpenHrs = SMTClass.SMTCommon.GetSysDate().Subtract(DateTime.Parse(sTakeOutTime)).TotalHours;
                    if (dOpenHrs > dSetUnmountTime)
                    {
                        if (sSetUnmountOption == "U")  //强制停止
                        {
                           // SajetCommon.Show_Message(SajetCommon.SetLanguage("Solder has been took out over", 1) + " " + dSetUnmountTime + " " + SajetCommon.SetLanguage("hr(s)", 1), 1);
                            sMsg = "锡膏已经被取出超过" + " " + dSetUnmountTime + " " + "hr(s)";
                            MainFrame.SysCheckData.MessageUtils.ShowError(sMsg);
                            ClearData();
                            editMemo.Text = "";
                            editReelNo.SelectAll();
                            editReelNo.Focus();
                            return;
                        }
                        else
                        {

                            sMsg = "锡膏已经被取出超过" + dSetUnmountTime + "hr(s)" + ", ";
                            sMsg = sMsg + System.Environment.NewLine +"确认继续吗?";

                            if (MainFrame.SysCheckData.MessageUtils.ShowConfirm(sMsg,MessageBoxButtons.YesNo) != DialogResult.Yes) //SajetCommon.Show_Message(sMsg, 2) != DialogResult.Yes
                            {
                                //bDateWarn = false;
                                bMemo = false;
                                ClearData();
                                editMemo.Text = "";
                                editReelNo.SelectAll();
                                editReelNo.Focus();
                                return;
                            }
                            else
                            {
                                //bDateWarn = true;
                                bMemo = true;
                            }
                        }
                    }
                }
                #endregion
            }
            #endregion

            #region"攪拌(M): 檢查回溫時間 && !bWarn"
            if (g_sProgramStatus_English == "M")
            {
                double dWaitMins = SMTClass.SMTCommon.GetSysDate().Subtract(DateTime.Parse(sTakeOutTime)).TotalMinutes;

                if (dWaitMins < dSetWaitTime)
                {
                    if (sSetWaitOption == "U")
                    {
                       // SajetCommon.Show_Message(SajetCommon.SetLanguage("Solder must be wait for", 1) + " " + dSetWaitTime + " " + SajetCommon.SetLanguage("minute(s)", 1), 0);
                        sMsg = "锡膏必须等待" + " " + " " + dSetWaitTime + " " + "minute(s)" + ", ";
                        MainFrame.SysCheckData.MessageUtils.ShowError(sMsg);
                        ClearData();
                        editMemo.Text = "";
                        editReelNo.SelectAll();
                        editReelNo.Focus();
                        return;
                    }
                    else
                    {
                       // sMsg = SajetCommon.SetLanguage("Solder must be wait for", 1) + " " + dSetWaitTime + " " + SajetCommon.SetLanguage("minute(s)", 1) + ", ";
                      //  sMsg = sMsg + System.Environment.NewLine + SajetCommon.SetLanguage("sure to continue", 1) + "?";
                        sMsg = "锡膏必须等待" + " " + " " + dSetWaitTime + " " + "minute(s)" + ", ";
                        sMsg = sMsg + System.Environment.NewLine + " 确定要继续吗?";

                        if (MainFrame.SysCheckData.MessageUtils.ShowConfirm(sMsg, MessageBoxButtons.YesNo)!= DialogResult.Yes) //SajetCommon.Show_Message(sMsg, 2) != DialogResult.Yes
                        {
                            bWarn = false;
                            //bMemo = false;
                            ClearData();
                            editMemo.Text = "";
                            editReelNo.SelectAll();
                            editReelNo.Focus();
                            return;
                        }
                        else
                        {
                            //bWarn = true;
                            bMemo = true;
                        }
                    }
                }
            }
            #endregion 

            #region 開封(O)：檢查開封時間>攪拌時間+攪拌分鐘 && !bWarn
            if (g_sProgramStatus_English == "O")
            {
                //dMixMin = GetMixMin(SOLDERREEL);
              //  int iMixTime = ClientUtils.GetSysDate().CompareTo(DateTime.Parse(LabCurrentTimeValue.Text).AddMinutes(dSetMixMin));
                int iMixTime = SMTClass.SMTCommon.GetSysDate().CompareTo(DateTime.Parse(LabCurrentTimeValue.Text).AddMinutes(dSetMixMin));
                if (iMixTime < 0)
                {
                    if (sSetMixOption == "U")
                    {
                       // SajetCommon.Show_Message(SajetCommon.SetLanguage("Solder must be mix for" + " " + dSetMixMin + " " + SajetCommon.SetLanguage("minute(s)", 1), 1), 0);
                        sMsg = "锡膏必须搅拌" + "" + dSetMixMin + "";
                        MainFrame.SysCheckData.MessageUtils.ShowError(sMsg);
                        ClearData();
                        editMemo.Text = "";
                        editReelNo.SelectAll();
                        editReelNo.Focus();
                        return;
                    }
                    else
                    {
                      //  sMsg = SajetCommon.SetLanguage("Solder must be mix for", 1) + " " + dSetMixMin + " " + SajetCommon.SetLanguage("minute(s)", 1) + ", ";
                       // sMsg = sMsg + System.Environment.NewLine + SajetCommon.SetLanguage("sure to continue", 1) + "?";
                        sMsg = "锡膏必须搅拌" + "" + dSetMixMin + "" + "minute(s)" + ", ";
                        sMsg = sMsg + System.Environment.NewLine + "确定继续吗?";

                        if (MainFrame.SysCheckData.MessageUtils.ShowConfirm(sMsg,MessageBoxButtons.YesNo) != DialogResult.Yes) //SajetCommon.Show_Message(sMsg, 2) != DialogResult.Yes
                        {
                            //bWarn = false;
                            bMemo = false;
                            ClearData();
                            editMemo.Text = "";
                            editReelNo.SelectAll();
                            editReelNo.Focus();
                            return;
                        }
                        else
                        {
                            //bWarn = true;
                            bMemo = true;
                        }
                    }
                }
            }
            #endregion

            # region"领用时卡搅拌时间"
            if (g_sProgramStatus_English == "P")
            {
                int iMixTime = SMTClass.SMTCommon.GetSysDate().CompareTo(DateTime.Parse(LabCurrentTimeValue.Text).AddMinutes(dSetMixMin));
                if (iMixTime < 0)
                {
                    if (sSetMixOption == "U")
                    {
                       // SajetCommon.Show_Message(SajetCommon.SetLanguage("Solder must be mix for" + " " + dSetMixMin + " " + SajetCommon.SetLanguage("minute(s)", 1), 1), 0);
                        sMsg = "锡膏必须搅拌" + "" + dSetMixMin + "" + "minute(s)";
                        MainFrame.SysCheckData.MessageUtils.ShowError(sMsg);
                        ClearData();
                        editMemo.Text = "";
                        editReelNo.SelectAll();
                        editReelNo.Focus();
                        return;
                    }
                    else
                    {
                      //  sMsg = SajetCommon.SetLanguage("Solder must be mix for", 1) + " " + dSetMixMin + " " + SajetCommon.SetLanguage("minute(s)", 1) + ", ";
                       // sMsg = sMsg + System.Environment.NewLine + SajetCommon.SetLanguage("sure to continue", 1) + "?";
                        sMsg = "锡膏必须搅拌" + "" + dSetMixMin + "minute(s)" + ", ";
                        sMsg = sMsg + System.Environment.NewLine + "确定要继续吗?";
                        if (MainFrame.SysCheckData.MessageUtils.ShowConfirm(sMsg, MessageBoxButtons.YesNo) != DialogResult.Yes) //SajetCommon.Show_Message(sMsg, 2) != DialogResult.Yes
                        {
                            //bWarn = false;
                            bMemo = false;
                            ClearData();
                            editMemo.Text = "";
                            editReelNo.SelectAll();
                            editReelNo.Focus();
                            return;
                        }
                        else
                        {
                            //bWarn = true;
                            bMemo = true;
                        }
                    }
                }
            }
            #endregion"领用检查"

            #region "回冰(R)：要檢查是否已開封過、回冰次數"
            if (g_sProgramStatus_English == "R")
            {

                sSQL = @"SELECT OPENED FROM m_MATERIAL_SOLDER_t
                            WHERE REEL_NO = '" + SOLDERREEL + "' ";

                dsTemp = MainFrame.DbOperateUtils.GetDataSet(sSQL); //ClientUtils.ExecuteSQL(sSQL);
                //begin  ADD BY CFY 2015-01-30 如果开封且回冰次数没有超过，则可以回冰
                if (dsTemp.Tables[0].Rows[0]["OPENED"].ToString() == "Y")
                {

                  //  SajetCommon.Show_Message(SajetCommon.SetLanguage("This solder can't be re-freezed over", 1) + " " + iSetReturnCnt + " " + SajetCommon.SetLanguage("times"), 0);
                    MainFrame.SysCheckData.MessageUtils.ShowError("这个锡膏不能回冰，已经超过次数！");
                    ClearData();
                    editMemo.Text = "";
                    editReelNo.SelectAll();
                    editReelNo.Focus();
                    return;
                    //end   ADD BY CFY 2015-01-30 如果开封且回冰次数没有超过，则可以回
                }
                if (int.Parse(LabFreezeCntValue.Text) > iSetReturnCnt)
                {
                  //  SajetCommon.Show_Message(SajetCommon.SetLanguage("This solder can't be re-freezed over", 1) + " " + iSetReturnCnt + " " + SajetCommon.SetLanguage("times"), 0);
                    sMsg = "这个锡膏不能回冰，已经超过使用次数";
                    ClearData();
                    editMemo.Text = "";
                    editReelNo.SelectAll();
                    editReelNo.Focus();
                    return;
                }
            }
            #endregion"回冰检查--end"

            g_bReelCheck = true;
            if (chkbInputMemo.Checked)
            {

                editMemo.SelectAll();

                tbWO.Focus();
            }
            else
            {
                // cancel by catherine 2015.02.08 11:32
                //btnSave_Click(sender, e);
                // end by catherine 2015.02.08 11:32
                return;
            }
        }

        private string GetNEWPartID(string part)
        {
            sSQL = " SELECT PART_ID FROM SAJET.SYS_PART "
                 + " WHERE PART_NO = '" + part + "'";
            dsTemp = MainFrame.DbOperateUtils.GetDataSet(sSQL);
            if (dsTemp.Tables[0].Rows.Count > 0)
            {
                return dsTemp.Tables[0].Rows[0]["PART_ID"].ToString();
            }
            else
            {
                return "0";
            }
        }

        private void GetTravel(string sReelNo)
        {
            try
            {
//                sSQL = @"SELECT A.REEL_NO, C.PDLINE_NAME, A.CURRENT_TIMEs, D.EMP_NAME, A.MEMO,
//                         DECODE(A.CURRENT_STATUS, 'F','Freeze', 'W', 'Wait', 'M', 'Mix', 'O', 'Open', 'U', 'Use', 'T', 'Terminate', 'S', 'Scrap','P','Pick') CURRENT_STATUS 
//                         FROM SAJET.G_HT_MATERIAL_SOLDER A, SAJET.SYS_PDLINE C, SAJET.SYS_EMP D
//                         WHERE A.PDLINE_ID = C.PDLINE_ID(+) AND A.CURRENT_USERID = D.EMP_ID  
//                         AND A.REEL_NO = '" + sReelNo + "' "
//                     + "UNION "
//                     + @"SELECT A.REEL_NO, C.PDLINE_NAME, A.CURRENT_TIMEs, D.EMP_NAME, A.MEMO,
//                         DECODE(A.CURRENT_STATUS, 'F','Freeze', 'W', 'Wait', 'M', 'Mix', 'O', 'Open', 'U', 'Use', 'T', 'Terminate', 'S', 'Scrap','P','Pick') CURRENT_STATUS 
//                         FROM SAJET.G_MATERIAL_SOLDER A, SAJET.SYS_PDLINE C, SAJET.SYS_EMP D
//                         WHERE A.PDLINE_ID = C.PDLINE_ID(+) AND A.CURRENT_USERID = D.EMP_ID   
//                         AND A.REEL_NO = '" + sReelNo + "' ORDER BY REEL_NO, CURRENT_TIMEs";
                sSQL = @"SELECT A.REEL_NO, a.PDLINE_ID, A.CURRENT_TIMEs, a.CREATE_USERID, A.MEMO,
                        ( CASE A.CURRENT_STATUS when 'F' THEN 'Freeze' WHEN 'W' THEN 'Wait' 
						 when 'M' then 'Mix' WHEN 'O' then 'Open'
						  when 'U' THEN 'Use' WHEN 'T' THEN 'Terminate'
						  when 'S' THEN 'Scrap' WHEN 'P'THEN 'Pick' END) CURRENT_STATUS 
                         FROM m_MATERIAL_SOLDER_ht_t A
                         WHERE   A.REEL_NO ='" + sReelNo + "'"
                          + " UNION "
                        + @"SELECT A.REEL_NO, a.PDLINE_ID, A.CURRENT_TIMEs, a.CREATE_USERID, A.MEMO,
                         (CASE A.CURRENT_STATUS when 'F' THEN 'Freeze'
						 when 'W' THEN 'Wait' 
						 WHEN 'M' then 'Mix' WHEN 'O' THEN 'Open' 
						 WHEN 'U' THEN 'Use'
						 when 'T' then 'Terminate' 
						 WHEN 'S' then 'Scrap' WHEN 'P'THEN 'Pick' END)  CURRENT_STATUS 
                         FROM m_MATERIAL_SOLDER_t A 
                         WHERE  A.REEL_NO = '" + sReelNo + "' ORDER BY REEL_NO, CURRENT_TIMEs";


                dsTemp = MainFrame.DbOperateUtils.GetDataSet(sSQL);
                for (int i = 0; i <= dsTemp.Tables[0].Rows.Count - 1; i++)
                {
                    DataRow dr = dsTemp.Tables[0].Rows[i];
                    dgvTravel.Rows.Add();
                    dgvTravel.Rows[dgvTravel.Rows.Count - 1].Cells["REEL_NO"].Value = dr["REEL_NO"].ToString();
                    dgvTravel.Rows[dgvTravel.Rows.Count - 1].Cells["PDLINE_ID"].Value = dr["PDLINE_ID"].ToString();
                    dgvTravel.Rows[dgvTravel.Rows.Count - 1].Cells["CURRENT_STATUS"].Value = dr["CURRENT_STATUS"].ToString();
                    dgvTravel.Rows[dgvTravel.Rows.Count - 1].Cells["CURRENT_TIMEs"].Value = dr["CURRENT_TIMEs"].ToString();
                    dgvTravel.Rows[dgvTravel.Rows.Count - 1].Cells["CREATE_USERID"].Value = dr["CREATE_USERID"].ToString();
                    dgvTravel.Rows[dgvTravel.Rows.Count - 1].Cells["MEMO"].Value = dr["MEMO"].ToString();
                    //dgvTravel.Rows[dgvTravel.Rows.Count - 1].Cells["Pick_Up"].Value = dr["EMP_NAME1"];
                }

            }
            catch (Exception ex)
            {
               // SajetCommon.Show_Message(ex.Message, 0);
                MainFrame.SysCheckData.MessageUtils.ShowError(ex.Message);
                return;
            }
        }


        private int CheckReelStatus(string sReel)
        {
            //0: 狀態OK
            //1: 已經進到錫膏管裡，但狀態不對
            //2: 還在G_MATERIAL，但狀態不對(入冰庫狀態才會碰到)

            if (g_sProgramStatus_English == "F")
            {   
                sSQL = @"SELECT REEL_NO FROM m_MATERIAL_SOLDER_t WHERE REEL_NO = '" + sReel + "' ";
                DataSet dsSearch = MainFrame.DbOperateUtils.GetDataSet(sSQL);
                if (dsSearch.Tables[0].Rows.Count == 0)  //
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                sSQL = @"SELECT REEL_NO FROM m_MATERIAL_SOLDER_t "
                     + " WHERE CURRENT_STATUS IN "
                     + " (SELECT CURRENT_STATUS_ID FROM m_SOLDER_STATUS_MOVE_t"
                     + "  WHERE NEXT_STATUS_ID = '" + g_sSQLStatus + "') "
                     + "  AND REEL_NO = '" + sReel + "' ";

                dsTemp = MainFrame.DbOperateUtils.GetDataSet(sSQL);
                if (dsTemp.Tables[0].Rows.Count > 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        #region "获取基础信息"
        private void GetInfo(string sReel)
        {
            ClearData();
            GetSetupTime();

            if (g_sProgramStatus_English == "F") //入冰库--F
            {
//                sSQL = @"SELECT B.PART_NO
//                      FROM SAJET.G_MATERIAL A, SAJET.SYS_PART B
//                     WHERE A.PART_ID = B.PART_ID(+) AND REEL_NO = '" + sReel + "' ";

//                dsTemp = MainFrame.DbOperateUtils.GetDataSet(sSQL);
//                if (dsTemp.Tables[0].Rows.Count > 0)
//                {
//                    LabPartValue.Text = dsTemp.Tables[0].Rows[0]["PART_NO"].ToString();
//                }
                LabPartValue.Text = part.Trim();
            }
            else
            {
//                sSQL = @"SELECT B.PART_NO, C.PDLINE_NAME, A.RETURN_COUNT, A.DATE_CODE,
//                     DECODE(A.CURRENT_STATUS, 'F','Freeze', 'W', 'Wait', 'M', 'Mix', 'O', 'Open', 'U', 'Use', 'T', 'Terminate', 'S', 'Scrap') CURRENT_STATUS,                                       
//                     A.CURRENT_TIMEs, A.LAST_TIME, A.CREATE_TIME, NVL(TAKEOUT_TIME,SYSDATE) TAKEOUT_TIME, NVL(OPEN_TIME,SYSDATE) OPEN_TIME 
//                     FROM m_MATERIAL_SOLDER_t A, SAJET.SYS_PART B, SAJET.SYS_PDLINE C
//                     WHERE A.PART_ID = B.PART_ID(+) AND A.PDLINE_ID = C.PDLINE_ID(+) 
//                     AND REEL_NO = '" + sReel + "' ";

                sSQL = @"SELECT PART_ID  as PART_NO, PDLINE_ID as PDLINE_NAME, A.RETURN_COUNT, A.DATE_CODE,
                    ( CASE A.CURRENT_STATUS WHEN  'F' THEN 'Freeze'
					 when 'W' THEN  'Wait'
					 WHEN  'M' then 'Mix' when 'O' then 'Open' when 'U' then 'Use' when 'T' THEN 'Terminate' when 'S' then 'Scrap' END) CURRENT_STATUS,                                       
                     A.CURRENT_TIMEs, A.LAST_TIME, 
					 A.CREATE_TIME, isnull(TAKEOUT_TIME,GETDATE()) TAKEOUT_TIME, 
					 isnull(OPEN_TIME,GETDATE()) OPEN_TIME 
                     FROM m_MATERIAL_SOLDER_t A WHERE  REEL_NO ='" + sReel + "' ";
                dsTemp = MainFrame.DbOperateUtils.GetDataSet(sSQL);
                if (dsTemp.Tables[0].Rows.Count > 0)
                {
                    LabPartValue.Text = dsTemp.Tables[0].Rows[0]["PART_NO"].ToString();
                    LabCurrentStatusValue.Text = dsTemp.Tables[0].Rows[0]["CURRENT_STATUS"].ToString();//SajetCommon.SetLanguage(dsTemp.Tables[0].Rows[0]["CURRENT_STATUS"].ToString(), 1);
                    LabFreezeCntValue.Text = (Convert.ToInt32(dsTemp.Tables[0].Rows[0]["RETURN_COUNT"].ToString())).ToString();
                    //LabDateCodeValue.Text = DateTime.Parse(dsTemp.Tables[0].Rows[0]["DATE_CODE"].ToString()).ToString("yyyy/MM/dd");
                    LabDateCodeValue.Text = dsTemp.Tables[0].Rows[0]["DATE_CODE"].ToString();
                    LabPDLineValue.Text = dsTemp.Tables[0].Rows[0]["PDLINE_NAME"].ToString();
                    LabCreateTimeValue.Text = dsTemp.Tables[0].Rows[0]["CREATE_TIME"].ToString();
                    LabCurrentTimeValue.Text = dsTemp.Tables[0].Rows[0]["CURRENT_TIMEs"].ToString();
                    LabMixMinValue.Text = dSetMixMin.ToString();
                    sTakeOutTime = dsTemp.Tables[0].Rows[0]["TAKEOUT_TIME"].ToString();
                    sOpenTime = dsTemp.Tables[0].Rows[0]["OPEN_TIME"].ToString();
                }
            }


        }
        #endregion "end 获取基础信息"

        #region 检查锡膏在冰箱里超过3个月提醒
        private bool checkInTime(string reel_no)
        {
            sSQL = "select create_time from m_MATERIAL_SOLDER_t  where reel_no='" + reel_no + "'";
            DataSet dstemp = MainFrame.DbOperateUtils.GetDataSet(sSQL);


            string in_time = dstemp.Tables[0].Rows[0][0].ToString();
            double dIn_time = SMTClass.SMTCommon.GetSysDate().Subtract(DateTime.Parse(in_time)).TotalDays;
            if (dIn_time >= 90)
            {

                return false;
            }
            else
            { return true; }
        }
        #endregion

        private void GetSetupTime()
        {
            string Reel_no = this.SOLDERREEL.ToString().Trim();
            // add by catherine 2015.03.20 18:53 读取这个锡膏料号所设定的时间管控
//            sSQL = @"SELECT WAIT_TIME, WAIT_OPTION, RETURN_COUNT, MIX_MIN, MIX_OPTION,
//                            MOUNT_TIME, MOUNT_OPTION, UNMOUNT_TIME, UNMOUNT_OPTION, DATECODE_OPTION ,FIFO_OPTION
//                     FROM m_SolderSetUp_t   WHERE PART_ID IN (SELECT PART_ID FROM m_MATERIAL_SOLDER_t WHERE REEL_NO='" + Reel_no + "'  AND ROWNUM=1" + ")";

            sSQL = @"SELECT WAIT_TIME, WAIT_OPTION, RETURN_COUNT, MIX_MIN, MIX_OPTION, 
                   MOUNT_TIME, MOUNT_OPTION, UNMOUNT_TIME, UNMOUNT_OPTION, DATECODE_OPTION ,FIFO_OPTION  
                   FROM m_SolderSetUp_t   WHERE PART_ID = '"+ part +"'";
            dsTemp = MainFrame.DbOperateUtils.GetDataSet(sSQL);
            if (dsTemp.Tables[0].Rows.Count > 0)
            {
                dSetWaitTime = double.Parse(dsTemp.Tables[0].Rows[0]["WAIT_TIME"].ToString());
                iSetReturnCnt = int.Parse(dsTemp.Tables[0].Rows[0]["RETURN_COUNT"].ToString());
                dSetMixMin = double.Parse(dsTemp.Tables[0].Rows[0]["MIX_MIN"].ToString());
                dSetMountTime = double.Parse(dsTemp.Tables[0].Rows[0]["MOUNT_TIME"].ToString());
                dSetUnmountTime = double.Parse(dsTemp.Tables[0].Rows[0]["UNMOUNT_TIME"].ToString());
                sSetWaitOption = dsTemp.Tables[0].Rows[0]["WAIT_OPTION"].ToString();
                sSetMixOption = dsTemp.Tables[0].Rows[0]["MIX_OPTION"].ToString();
                sSetMountOption = dsTemp.Tables[0].Rows[0]["MIX_OPTION"].ToString();
                sSetUnmountOption = dsTemp.Tables[0].Rows[0]["UNMOUNT_OPTION"].ToString();
                sSetDateCodeOption = dsTemp.Tables[0].Rows[0]["DATECODE_OPTION"].ToString();
                //Add By LinYao IN Rucking For 回温FIFO
                sFifoOption = dsTemp.Tables[0].Rows[0]["FIFO_OPTION"].ToString();
                //End By LinYao IN Rucking For 回温FIFO
            }
            else
            {
                dSetWaitTime = 0;
                iSetReturnCnt = 0;
            }
        }

        private void editReelNo_TextChanged(object sender, EventArgs e)
        {
            ClearData();
            editMemo.Text = "";
            bMemo = false;
            g_bReelCheck = false;
        }

        private string GetEngLishStatusName(string strChineseStatusName)
        {
            string strEngLishStatusName=""; 
            switch (strChineseStatusName)
            {
                case "报废":
                    strEngLishStatusName = "S";
                    break;
                case  "搅拌":
                    strEngLishStatusName = "M";
                    break;
                case "回温":
                     strEngLishStatusName = "W";
                     break;
                case "上料":
                     strEngLishStatusName = "U";
                     break;
                case "回冰":
                     strEngLishStatusName = "R";
                     break;
                case "用完":
                     strEngLishStatusName = "T";
                     break;
                case "开封":
                     strEngLishStatusName = "O";
                     break;
                case "入冰库":
                     strEngLishStatusName = "F";
                     break;
                case "领用":
                    strEngLishStatusName = "P";
                    break;
		        default:
                    strEngLishStatusName = "F";
                    break;
            }
            return strEngLishStatusName;
        }

        private string GetChinesStatusName(string strEnglishStatusName)
        {
            string strChinesStatusName = "";
            switch (strEnglishStatusName)
            {
                case "M":
                    strChinesStatusName = "搅拌";
                    break;
                case "S":
                    strChinesStatusName = "报废";
                    break;
                case "W":
                    strChinesStatusName = "回温";
                    break;
                case "U":
                    strChinesStatusName = "上料";
                    break;
                case "R":
                    strChinesStatusName = "回冰";
                    break;
                case "T":
                    strChinesStatusName = "用完";
                    break;
                case "O":
                    strChinesStatusName = "开封";
                    break;
                case "F":
                    strChinesStatusName = "入冰库";
                    break;
                case "P":
                    strChinesStatusName = "领用";
                    break;
                default:
                    strChinesStatusName = "入冰库";
                    break;
            }
            return strChinesStatusName;
        }
    }
}
