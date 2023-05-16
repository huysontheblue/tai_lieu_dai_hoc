using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.IO.Ports;

namespace UIHandler
{
    public static class UIFunction
    {
        /// <summary>
        /// 设置Lable控件显示内容
        /// </summary>
        /// <param name="messageText">要显示的内容</param>
        /// <param name="lbl">Lable控件</param>
        /// <param name="isWaring">是否是警告或错误信息，若是则为true</param>
        /// <param name="isOK">若为true,则控件的文字颜色显示为绿色</param>
        public static void SetMessage(string messageText, Label lbl, bool isWaring,bool isOK)
        {
            if (isWaring)
            {
                lbl.ForeColor = Color.Red;
            }
            if (isOK)
            {
                lbl.ForeColor = Color.Green;
            }
            lbl.Text = ReplaceServerMessage(messageText);
        }
        /// <summary>
        /// 弹出提示框
        /// </summary>
        /// <param name="messageText">提示内容</param>
        public static void ShowMessage(string messageText)
        {
            MessageBox.Show(ReplaceServerMessage(messageText));
        }
        /// <summary>
        /// 弹出确认框
        /// </summary>
        /// <param name="messageText">提示内容</param>
        /// <returns></returns>
        public static bool ShowConfirmMessage(string messageText)
        {
            DialogResult result = MessageBox.Show(ReplaceServerMessage(messageText), "提示", MessageBoxButtons.YesNo);
            if (result==DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 处理数据库返回信息
        /// </summary>
        /// <param name="ServerMessage"></param>
        /// <returns></returns>
        public static string ReplaceServerMessage(string ServerMessage)
        {
            return ServerMessage.Replace("ServerMessage:", "").Replace("/r/n", "\r\n");
        }
        #region "样式和数据填充"

        /// <summary>
        /// 生成ListView样式控制
        /// </summary>
        /// <param name="lvwName"></param>
        public static void CreateListViewColumnStyle(ListView LvwName)
        {
            LvwName.View = View.List;
            //显示各个记录的分隔线
            LvwName.FullRowSelect = true;
            //要选择就是一行
            LvwName.View = View.Details;
            //需要时候显示滚动条
            LvwName.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            //LvwName.Height = this.ClientRectangle.Height;
        }

        public static void CreateListViewColumn(string[] StrArr, ListView LvwName)
        {
            //LvwName.Clear();
            LvwName.Items.Clear();
            foreach (string StrCol in StrArr)
            {
                ColumnHeader ColHeader = new ColumnHeader();
                ColHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                ColHeader.Text = StrCol.Trim();

                if (ColHeader.Text.Trim().Length > 1)
                {
                    if (ColHeader.Text.Trim().Substring(ColHeader.Text.Length - 2, 2).ToUpper() == "ID")
                    {
                        ColHeader.Width = 0;
                    }
                    else
                    {
                        ColHeader.Width = 80;
                    }
                }
                else
                {
                    ColHeader.Width = 80;
                }
                LvwName.Columns.Add(ColHeader);
            }

        }

        public static void CreateListViewColumn(string[] StrArr, string[] StrLenght, ListView LvwName)
        {
            //LvwName.Clear();
            LvwName.Items.Clear();
            for (int i = 0; i < StrArr.Length; i++)
            {
                ColumnHeader ColHeader = new ColumnHeader();
                ColHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                ColHeader.Text = StrArr[i].ToString().Trim();

                if (ColHeader.Text.Trim().Length > 1)
                {
                    if (ColHeader.Text.Trim().Substring(ColHeader.Text.Length - 2, 2).ToUpper() == "ID")
                    {
                        ColHeader.Width = 0;
                    }
                    else
                    {
                        if (i <= StrLenght.Length)
                        {
                            ColHeader.Width = Convert.ToInt32(StrLenght[i].ToString());
                        }
                        else
                        {
                            ColHeader.Width = 80;
                        }
                    }
                }
                else
                {
                    ColHeader.Width = 80;
                }
                LvwName.Columns.Add(ColHeader);
            }

        }

        /// <summary>
        /// 填充数据集到ListView和生成列名称
        /// </summary>
        /// <param name="DstName"></param>
        /// <param name="LvwName"></param>
        /// <param name="ColName"></param>
        public static void Fill_ListView(DataSet dsName, ListView LvwName, string[] ColName)
        {
            if (dsName.Tables[0].Rows.Count > 0)
            {
                int ICol = 0;
                DataTable Dt = new DataTable();
                Dt = dsName.Tables[0];

                //填充前清空ListView
                LvwName.Columns.Clear();
                LvwName.Items.Clear();

                foreach (DataColumn Col in Dt.Columns)
                {
                    ColumnHeader ColHeader = new ColumnHeader();
                    ColHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                    //ColHeader.Text = Col.Caption;
                    ColHeader.Text = ColName[ICol].Trim();
                    if (ColHeader.Text.Trim().Length > 1)
                    {
                        if (ColHeader.Text.Trim().Substring(ColHeader.Text.Length - 2, 2).ToUpper() == "ID")
                        {
                            ColHeader.Width = 0;
                        }
                        else
                        {
                            ColHeader.Width = 100;
                        }
                    }
                    else
                    {
                        ColHeader.Width = 100;
                    }
                    ICol++;
                    LvwName.Columns.Add(ColHeader);
                }

                foreach (DataRow dr in Dt.Rows)
                {
                    string[] StrArr = new string[Dt.Columns.Count];
                    for (int i = 0; i < Dt.Columns.Count; i++)
                    {
                        StrArr[i] = dr[i].ToString().Trim();
                    }
                    ListViewItem LvwItem = new ListViewItem(StrArr);
                    LvwName.Items.Add(LvwItem);
                }
                LvwName.Columns[LvwName.Columns.Count - 1].Width -= 50;
            }
        }

        /// <summary>
        /// 填充数据集到ListView
        /// </summary>
        /// <param name="DstName"></param>
        /// <param name="LvwName"></param>
        public static void Fill_ListView(DataSet dsName, ListView LvwName)
        {
            if (dsName.Tables[0].Rows.Count > 0)
            {
                int ICol = 0;
                DataTable Dt = new DataTable();
                Dt = dsName.Tables[0];
                LvwName.Items.Clear();

                //填充前清空ListView
                if (LvwName.Columns.Count <= 0)
                {
                    LvwName.Columns.Clear();

                    foreach (DataColumn Col in Dt.Columns)
                    {
                        ColumnHeader ColHeader = new ColumnHeader();
                        ColHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                        ColHeader.Text = Col.Caption.Trim();

                        if (ColHeader.Text.Trim().Length > 1)
                        {
                            if (ColHeader.Text.Trim().Substring(ColHeader.Text.Length - 2, 2).ToUpper() == "ID")
                            {
                                ColHeader.Width = 0;
                            }
                            else
                            {
                                ColHeader.Width = 80;
                            }
                        }
                        else
                        {
                            ColHeader.Width = 80;
                        }
                        ICol++;
                        LvwName.Columns.Add(ColHeader);
                    }
                }
                foreach (DataRow dr in Dt.Rows)
                {
                    string[] StrArr = new string[Dt.Columns.Count];
                    for (int i = 0; i < Dt.Columns.Count; i++)
                    {
                        StrArr[i] = dr[i].ToString().Trim();
                    }
                    ListViewItem LvwItem = new ListViewItem(StrArr);
                    LvwName.Items.Add(LvwItem);
                }
                //LvwName.Columns[LvwName.Columns.Count - 1].Width -= 50;
            }
        }

        public static void Fill_Combobox(DataSet dsName, ComboBox cbxName)
        {
            cbxName.Items.Clear();
            if (dsName.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsName.Tables[0].Rows)
                {
                    cbxName.Items.Add(dr[0].ToString());
                }
            }
        }

        public static void Fill_Combobox(DataSet dsName, string colName, ComboBox cbxName)
        {
            cbxName.Items.Clear();
            if (dsName.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsName.Tables[0].Rows)
                {
                    cbxName.Items.Add(dr[colName].ToString());
                }
            }
        }

        public static void Fill_Combobox(DataTable dtName, ComboBox cbxName)
        {
            cbxName.Items.Clear();
            if (dtName.Rows.Count > 0)
            {
                foreach (DataRow dr in dtName.Rows)
                {
                    cbxName.Items.Add(dr[0].ToString());
                }
            }
        }

        public static void Fill_Combobox(DataTable dtName, string colName, ComboBox cbxName)
        {
            cbxName.Items.Clear();
            if (dtName.Rows.Count > 0)
            {
                foreach (DataRow dr in dtName.Rows)
                {
                    cbxName.Items.Add(dr[colName].ToString());
                }
            }
        }

        public static void Fill_ComboboxBlank(DataTable dtName, ComboBox cbxName)
        {
            cbxName.Items.Clear();
            if (dtName.Rows.Count > 0)
            {
                cbxName.Items.Add("");
                foreach (DataRow dr in dtName.Rows)
                {
                    cbxName.Items.Add(dr[0].ToString());
                }
            }
        }

        public static void Fill_ComboboxBlank(DataTable dtName, string colName, ComboBox cbxName)
        {
            cbxName.Items.Clear();
            if (dtName.Rows.Count > 0)
            {
                cbxName.Items.Add("");
                foreach (DataRow dr in dtName.Rows)
                {
                    cbxName.Items.Add(dr[colName].ToString());
                }
            }
        }

        public static void BindComboxBlank(DataTable dtName, ComboBox cbxName, string Text, string value)
        {
            DataRow dr = dtName.NewRow ();
            dr[Text] = "";
            dr[value] = "";
            dtName.Rows.InsertAt(dr, 0);

            cbxName.DataSource = dtName;
            cbxName.DisplayMember = Text;
            cbxName.ValueMember = value;
        }

        public static void BindComboxNoBlank(DataTable dtName, ComboBox cbxName, string Text, string value)
        {
            cbxName.DataSource = dtName;
            cbxName.DisplayMember = Text;
            cbxName.ValueMember = value;
        }


        #endregion

        #region 文件操作
        /// <summary>
        /// 根据文件路径获取文件的版本信息
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileVersion(string filePath)
        {
            try
            {
                FileVersionInfo file = FileVersionInfo.GetVersionInfo(filePath);
                return file.FileVersion;
                
            }
            catch (Exception ex)
            {
               
                return "";
                throw ex;
            }
            

        }
        /// <summary>
        /// 将文件二进制流保存成文件
        /// </summary>
        /// <param name="?"></param>
        /// <param name="destinationFilePath"></param>
        public static void ByteSaveAsFile(byte[] fileByte,string destinationFilePath)
        {
            byte[] fileCopy=null;
            bool flag = false;   
            try
            {
                if (File.Exists(destinationFilePath))
                {
                    FileStream fsCopy = new FileStream(destinationFilePath, FileMode.Open, FileAccess.Read);
                    fileCopy = new byte[fsCopy.Length];
                    fsCopy.Read(fileCopy, 0, fileCopy.Length);
                    fsCopy.Dispose();
                    fsCopy.Close();
                    FileInfo fileInfo = new FileInfo(destinationFilePath);
                    if (!IsUsed(destinationFilePath))
                    {
                        File.Delete(destinationFilePath);
                    }
                    else
                    {
                        string updateNeedFilePath = Application.StartupPath+@"\updatePragramNeedFiles\";
                        if (!Directory.Exists(updateNeedFilePath))
                        {
                            Directory.CreateDirectory(updateNeedFilePath);
                        }
                        else
                        {
                            string [] fileName = Directory.GetFiles(updateNeedFilePath);
                            foreach (var item in fileName)
                            {
                                File.Delete(item);                                
                            }
                        }
                        FileStream fsUp = new FileStream(updateNeedFilePath+Path.GetFileName(destinationFilePath), FileMode.CreateNew, FileAccess.ReadWrite);
                        fsUp.Write(fileByte, 0, fileByte.Length);
                        fsUp.Dispose();
                        fsUp.Close();
                        return;
                    }
                    flag = true;
                }
                FileStream fs = new FileStream(destinationFilePath, FileMode.CreateNew, FileAccess.ReadWrite);
                fs.Write(fileByte, 0, fileByte.Length);
                fs.Dispose();
                fs.Close();
            }
            catch (Exception ex)
            {
                if (flag)
                {
                    using (FileStream fs = new FileStream(destinationFilePath, FileMode.CreateNew, FileAccess.ReadWrite))
                    {
                        fs.Write(fileCopy, 0, fileCopy.Length);
                    }
                }
                else
                {
                    throw ex;
                }
                       
            }
        }
        public static bool IsUsed(string filePath)
        {
            bool result = false;
         
             try
             {
                 FileStream fs = File.OpenWrite(filePath);
                 fs.Close();
             }
             catch
             {
                 result = true;
             }
         
            return result;
        }
        /// <summary>
        /// 文件版本号判断
        /// </summary>
        /// <param name="historyVersion">历史版本号</param>
        /// <param name="newVersion">新版本号</param>
        /// <returns></returns>
        public static bool FileVersionCompare(string historyVersion, string newVersion)
        {
            if (string.IsNullOrEmpty(historyVersion) || string.IsNullOrEmpty(newVersion))
            {
                return false;
            }
            historyVersion = historyVersion.Replace(".", "");
            newVersion = newVersion.Replace(".", "");
            if (int.Parse(newVersion) > int.Parse(historyVersion))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region MESDataServices接口服务
        public static string GetSystemAddress(string FactoryId,string ProfitCenter,string UpdateType,out string rtValue, out string rtMsg)
        {
            MESDataService.MESDataServices mesService = new MESDataService.MESDataServices();
            return mesService.GetSystemAddress(FactoryId, ProfitCenter, UpdateType,out rtValue, out rtMsg);
        }
        #endregion
        #region 弹出自动关闭MessageBox窗口
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public const int WM_CLOSE = 0x10;
        public static void AlertAotuCloseMeessageBox(string msgContent, int interval)
        {
            StartKiller(interval);
            MessageBox.Show(msgContent, "提示");
        }
        private static void StartKiller(int interval)
        {
            Timer timer = new Timer();
            timer.Interval = interval; //3秒启动
            timer.Tick += timer_Tick;
            timer.Start();
        }

        static void timer_Tick(object sender, EventArgs e)
        {
            KillMessageBox();
            //停止Timer
            ((Timer)sender).Stop();
        }
        private static void KillMessageBox()
        {
            //按照MessageBox的标题，找到MessageBox的窗口
            IntPtr ptr = FindWindow(null, "提示");
            if (ptr != IntPtr.Zero)
            {
                //找到则关闭MessageBox窗口
                PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }
        }
        #endregion
        #region 注册表操作
        public static void InsertRegeditValue(string keyName, string keyValue)
        {
            RegistryKey regWrite;
            regWrite = Registry.LocalMachine.CreateSubKey("Software\\DGMesAutoUpdate\\" + keyName);
            regWrite.SetValue(keyName, keyValue);
            regWrite.Close();
        }
        public static string ReadRegistValue(string keyName)
        {
            RegistryKey regRead;
            regRead = Registry.LocalMachine.OpenSubKey("Software\\DGMesAutoUpdate\\" + keyName);
            if (regRead == null)
            {
                return "1";
            }
            else
            {
                string value = regRead.GetValue(keyName) == null ? "" : regRead.GetValue(keyName).ToString();
                regRead.Close();
                return value;
            }
        }
        #endregion
        #region "转换信息"
        public static void TranferHexValue(string message, ref  List<byte> buf)
        {
            //定义一个变量，记录发送了几个字节
            int n = 0;
            //16进制发送
            //我们不管规则了。如果写错了一些，我们允许的，只用正则得到有效的十六进制数
            MatchCollection mc = Regex.Matches(message, @"(?i)[\da-f]{2}");
            //List<byte> buf = new List<byte>();//填充到这个临时列表中
            //依次添加到列表中
            foreach (Match m in mc)
            {
                buf.Add(byte.Parse(m.Value));
            }
            //转换列表为数组后发送
            //comm.Write(buf.ToArray(), 0, buf.Count);
            //记录发送的字节数
            n = buf.Count;
        }

        #endregion

    }
}
