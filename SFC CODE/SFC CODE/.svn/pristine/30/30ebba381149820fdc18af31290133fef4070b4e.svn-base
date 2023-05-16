using DevComponents.AdvTree;
using MainFrame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RouteManagement
{
    public partial class HelpSOP : Form
    {
        #region 定义变量
        //打开项目
        string Tag;
        //存储下载的内容
        List<string> xzname = new List<string>();
        //存储下载索引
        List<int> Indexes = new List<int>();
        //当前下载索引
        int xzindexes = -1;
        //获取lmagelist中的数据
        Hashtable ht = new Hashtable();
        private int WriterByetNub = 80;//100M复制速度
        //源目标
        private FileStream FileToRead;
        //复制到文件
        private FileStream FileToWrite;
        //保存文件的地址
        private string SaveFile_Add;
        //源文件的名字
        private string File_Add;
        //设置正常写入字节
        private Byte[] byteToWrite;
        //设置剩余写入字节
        private Byte[] byteToLastWrite;
        //循环次数
        private long WriteTimes;
        //循环后的剩余字节
        private int L_Size;
        //判断后台是否有下载任务
        bool Whether = true;
        public HelpSOP(string tag)
        {
            Tag=tag;
            if (tag == "Maximization")
            {
                this.WindowState = FormWindowState.Maximized;
                dyc = 1;
            }
            InitializeComponent();
        }
        public void ShowMessage(string msg)
        {
            this.Invoke(new MessageBoxShow(MessageBoxShow_F), new object[] { msg });
        }
        delegate void MessageBoxShow(string msg);
        void MessageBoxShow_F(string msg)
        {
            MessageBox.Show(msg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
        #region Dag下载方法
        /// <summary>
        /// 下载方法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private void DagCpy(string a, string b, int c)
        {
            try
            {
                //label_Add.Text = @"源地址:";
                DevComponents.DotNetBar.Controls.DataGridViewProgressBarXColumn cbo = (DevComponents.DotNetBar.Controls.DataGridViewProgressBarXColumn)this.dataGridViewX1.Columns["Column6"];
                //label_Cpy_Add.Text = @"复制到:";
                cbo.Maximum = 100;
                progressBar.Maximum = 100;
                process.Text = "下载进程:";
                label_Downloaded.Text = "已下载";
                label_total.Text = "源文件大小";
                File_Add = a;
                SaveFile_Add = b;
                FileToRead = new FileStream(File_Add, FileMode.Open, FileAccess.Read);
                FileToWrite = new FileStream(@SaveFile_Add + "\\" + Path.GetFileName(a), FileMode.OpenOrCreate, FileAccess.ReadWrite);
                label_total.Text = "源文件大小" + decimal.Round(decimal.Parse((double.Parse(FileToRead.Length.ToString()) / 1000000).ToString()), 2) + "MB";
                if (FileToRead.Length > WriterByetNub)
                //设置写入字节数组
                {
                    byteToWrite = new byte[WriterByetNub];
                    //循环次数
                    WriteTimes = FileToRead.Length / WriterByetNub;
                    //多次循环后剩余字节
                    L_Size = Convert.ToInt32(FileToRead.Length % WriterByetNub);
                    //多次循环后字节数组
                    byteToLastWrite = new byte[L_Size];

                    for (long i = 0; i <= WriteTimes; i++)
                    {
                        //读源文件
                        FileToRead.Read(byteToWrite, 0, WriterByetNub);

                        //写数据到目标文件
                        FileToWrite.Write(byteToWrite, 0, WriterByetNub);

                        //设置进度条的值
                        dataGridViewX1.Rows[c].Cells["Column6"].Value = Convert.ToInt32(i * 100 / WriteTimes);
                        progressBar.Value = Convert.ToInt32(i * 100 / WriteTimes);
                        Application.DoEvents();

                        //设置Lable上的进度值
                        process.Text = "下载进程:" + Convert.ToInt32((i * 100) / WriteTimes).ToString() + "%";

                        //设置写入值
                        label_Downloaded.Text = "已下载" + decimal.Round(decimal.Parse((decimal.Parse(FileToRead.Position.ToString()) / 1000000).ToString()), 2) + "MB";
                    }

                    //剩余字节的读和写
                    if (L_Size != 0)
                    {
                        FileToRead.Read(byteToLastWrite, 0, L_Size);
                        FileToWrite.Write(byteToLastWrite, 0, L_Size);
                    }
                }
                else //当写于分割的字节大小时 直接复制吧
                {
                    //设置字节
                    byteToWrite = new byte[FileToRead.Length];
                    //读取到字节中
                    FileToRead.Read(byteToWrite, 0, (int)FileToRead.Length);
                    try
                    {
                        //计算进程
                        process.Text = "下载进程:" + Convert.ToInt32(FileToRead.Position / FileToRead.Length * 100).ToString() + "%";
                    }
                    catch
                    {
                        return;
                    }
                    //设置写入值
                    label_Downloaded.Text = "已下载" + decimal.Round(decimal.Parse((double.Parse(FileToRead.Position.ToString()) / 1000000).ToString()), 2) + "MB";
                    //计算进度条的进度
                    dataGridViewX1.Rows[c].Cells["Column6"].Value = (int)FileToRead.Position;
                    progressBar.Value = (int)FileToRead.Position;
                    //写入完成
                    FileToWrite.Write(byteToWrite, 0, (int)FileToRead.Length);
                }
                FileToRead.Flush();
                FileToWrite.Flush();
                FileToRead.Close();
                FileToWrite.Close();
                if ((xzindexes + 1).ToString() == (xzname.Count).ToString())
                {
                    Whether = true;
                    yingcang();
                    ShowMessage("下载的文件已全部保存在《C\\:MES操作SOP》");
                    ProcessStartInfo psiv = new ProcessStartInfo(@"C:\MES操作SOP\" + Path.GetFileName(a));
                    Process pv = new Process();
                    pv.StartInfo = psiv;
                    pv.Start();
                }
            }
            catch
            {
                try
                {
                    FileToRead.Flush();
                    FileToWrite.Flush();
                    FileToRead.Close();
                    FileToWrite.Close();
                    MessageBox.Show("下载的文件已被删除");
                    xiazai = "等待中";
                }
                catch
                {
                }
            }
        }
        #endregion
        #region 将已上传的SOP以树形结构显示出来-方法
        private void Bind_Tv(DataTable dt, TreeNodeCollection tnc, string pid_val, string id, string pid, string text, bool isFirst, bool IsMultiple)
        {
            //DataView tempView;
            //DataView tableView = new DataView(treeDt);
            //tempView = tableView;
            DataView dv = new DataView(dt);
            TreeNode tn;
            string filter;
            if (isFirst)
            {
                if (string.IsNullOrEmpty(pid_val))
                {
                    filter = "Tkey id null or Tkey=''";
                }
                else
                {
                    filter = string.Format("Tkey='{0}'", pid_val);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(pid_val))
                {
                    filter = pid + "is null or" + pid + " = ''";
                }
                else
                {
                    filter = string.Format("(" + pid + "='{0}' ) ", pid_val);
                }
            }

            dv.RowFilter = filter;
            // DataRowView drv;
            foreach (DataRowView drv in dv)
            {
                tn = new TreeNode();
                tn.Name = drv[id].ToString();
                string a = drv[text].ToString();
                if (a == "上传SOP")
                {
                    a = "MES";
                }
                tn.Text = a;
                if (IsMultiple)
                {
                    //tn.Cells.Add(New AdvTree.Cell(drv[id].ToString()));

                }
                tn.Expand();
                tnc.Add(tn);

                if (ht.ContainsKey(tn.Text.Trim()))
                {
                    tn.ImageIndex = int.Parse(ht[tn.Text.Trim()].ToString());//表示其图片为图片列表中的第一个图片，若用第二个图片
                    //则tn.ImageIndex = 1;依次类推
                }

                Bind_Tv(dt, tn.Nodes, tn.Name, id, pid, text, false, IsMultiple);
            }
        }
        #endregion
        #region 窗体的Load方法
        private void HelpSOP_Load(object sender, EventArgs e)
        {
            //将imagelist中的图片保存到键值对集合中
            int jishu = 0;
            foreach (string key in imageList2.Images.Keys)
            {
                ht.Add(key, jishu++);
            }
            Control.CheckForIllegalCrossThreadCalls = false;
            tvFood.Nodes.Clear();
            DataTable dt = DbOperateUtils.GetDataTable("select * from m_MainSop where Usey ='Y'");
            //将上次过的sop模块显示出来
            Bind_Tv(dt, tvFood.Nodes, "h0_", "Tkey", "Tparent", "Ttext", true, false);
            this.tvFood.Nodes[0].Expand();
        }
        #endregion
        #region 窗体移动
        int _X, _Y;
        private void toolStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _X + _Y != 0)
            {
                this.Left += e.X - _X;
                this.Top += e.Y - _Y;
            }
            else
            {
                _X = e.X;
                _Y = e.Y;
            }
        }

        private void toolStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _X = 0;
                _Y = 0;
            }
        }
        #endregion
        #region 判断选择的是那层节点
        //第一次启动不执行
        int dyc = 0;
        private void tvFood_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Whether)
            {
            if (dyc == 0)
            {
                string foodname2 = tvFood.SelectedNode.Text;
                string sql2 = " SELECT Name,FileType,Ttext FROM m_HelpSop  where Ttext=N'" + Tag + "'";
                DataTable h2 = DbOperateUtils.GetDataTable(sql2);
                try
                {
                    for (int i = 0; i < h2.Rows.Count; i++)
                    {
                        //listView1.Items.Add(h2.Rows[i][0].ToString(), int.Parse(h2.Rows[i][1].ToString()));
                        string sql = "SELECT m_HelpSop.Name, m_DutyUsers_t.UserID ,m_DutyUsers_t.UserName,m_DutyUsers_t.Mobile,m_HelpSop.UpTime,m_HelpSop.Ttext,m_HelpSop.FileType,m_HelpSop.Download,m_HelpSop.Consult,m_HelpSop.Remark AS MajorName FROM m_HelpSop LEFT JOIN m_DutyUsers_t ON m_DutyUsers_t.UserID = m_HelpSop.UserId WHERE Name=N'" + h2.Rows[i][0].ToString() + "'";
                        DataTable h = DbOperateUtils.GetDataTable(sql);
                        label_name.Text = h.Rows[0][0].ToString();
                        label_Modular.Text = h.Rows[0][5].ToString();
                        label_Download.Text = "下载次数:" + h.Rows[0][7].ToString()+"次";
                        label_Consult.Text = "查阅次数:" + h.Rows[0][8].ToString()+"次";
                        switch (h.Rows[0][6].ToString())
                        {
                            case "0": label_type.Text = "未知类型";
                                break;
                            case "1": label_type.Text = "视频";
                                break;
                            case "2": label_type.Text = "PowerPoint PPT";
                                break;
                            case "3": label_type.Text = "Word 文档";
                                break;
                        }
                        label_Explain.Text = h.Rows[0][9].ToString();
                        dataGridViewX1.Rows.Add(h.Rows[0][0].ToString(), h.Rows[0][1].ToString(), h.Rows[0][2].ToString(), h.Rows[0][3].ToString(), h.Rows[0][4].ToString());
                        int a = dataGridViewX1.Rows.Count;
                    }
                }
                catch
                {
                }

                dyc = 1;
                try
                {
                    //遍历Tree中的所有根节点
                    foreach (TreeNode node in this.tvFood.Nodes)
                    {
                        //将每个根节点代入方法进行查找
                        TreeNode temp = FindNode(node, h2.Rows[0][2].ToString());
                        //找到输出结果
                        if (temp != null)
                        {
                            //MessageBox.Show(string.Format("找到，深度{0},索引{1}", temp.Level, temp.Index));
                            tvFood.SelectedNode = tvFood.Nodes[0].Nodes[temp.Parent.Index].Nodes[temp.Index];//选中
                            tvFood.Focus();
                            return;
                        }
                        else
                        {
                            ShowMessage("目前系统没有维护该模块的SOP请联系相关人员进行制作");
                            return;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("没有相关该模块的SOP请联系相关人员进行维护");
                    return;
                }
            }
            //listView1.Items.Clear();
            int hh = tvFood.SelectedNode.Level;
            dataGridViewX1.Rows.Clear();
            if (hh == 0)
            {
                string foodname1 = tvFood.SelectedNode.Text;
                string sql1 = " SELECT Name,FileType FROM m_HelpSop ORDER BY FileType DESC ";
                DataTable h1 = DbOperateUtils.GetDataTable(sql1);
                try
                {
                    for (int i = 0; i < h1.Rows.Count; i++)
                    {
                        string sql4 = "SELECT m_HelpSop.Name, m_DutyUsers_t.UserID ,m_DutyUsers_t.UserName,m_DutyUsers_t.Mobile,m_HelpSop.UpTime,m_HelpSop.Ttext,m_HelpSop.FileType,m_HelpSop.Download,m_HelpSop.Consult,m_HelpSop.Remark AS MajorName FROM m_HelpSop LEFT JOIN m_DutyUsers_t ON m_DutyUsers_t.UserID = m_HelpSop.UserId WHERE Name=N'" + h1.Rows[i][0].ToString() + "'";
                        DataTable h4 = DbOperateUtils.GetDataTable(sql4);
                        //listView1.Items.Add(h1.Rows[i][0].ToString(), int.Parse(h1.Rows[i][1].ToString()));
                        label_Explain.Text = h4.Rows[0][9].ToString();
                        dataGridViewX1.Rows.Add(h4.Rows[0][0].ToString(), h4.Rows[0][1].ToString(), h4.Rows[0][2].ToString(), h4.Rows[0][3].ToString(), h4.Rows[0][4].ToString());
                    }
                }
                catch
                {
                }
            }
            else if (hh == 1)
            {
                string foodname2 = tvFood.SelectedNode.Text;
                string sql2 = " SELECT Name,FileType FROM m_HelpSop  where PreviousTtext=N'" + foodname2 + "'";
                DataTable h2 = DbOperateUtils.GetDataTable(sql2);
                try
                {
                    for (int i = 0; i < h2.Rows.Count; i++)
                    {
                        string sql3 = "SELECT m_HelpSop.Name, m_DutyUsers_t.UserID ,m_DutyUsers_t.UserName,m_DutyUsers_t.Mobile,m_HelpSop.UpTime,m_HelpSop.Ttext,m_HelpSop.FileType,m_HelpSop.Download,m_HelpSop.Consult,m_HelpSop.Remark AS MajorName FROM m_HelpSop LEFT JOIN m_DutyUsers_t ON m_DutyUsers_t.UserID = m_HelpSop.UserId WHERE Name=N'" + h2.Rows[i][0].ToString() + "'";
                        DataTable h3 = DbOperateUtils.GetDataTable(sql3);
                        //listView1.Items.Add(h2.Rows[i][0].ToString(), int.Parse(h2.Rows[i][1].ToString()));
                        label_Explain.Text = h3.Rows[0][9].ToString();
                        dataGridViewX1.Rows.Add(h3.Rows[0][0].ToString(), h3.Rows[0][1].ToString(), h3.Rows[0][2].ToString(), h3.Rows[0][3].ToString(), h3.Rows[0][4].ToString());
                    }
                }
                catch
                {
                }
            }
            else
            {
                string foodname = tvFood.SelectedNode.Text;
                string sql = " SELECT Name,FileType FROM m_HelpSop  where Ttext=N'" + foodname + "'";
                DataTable h = DbOperateUtils.GetDataTable(sql);
                try
                {
                    for (int i = 0; i < h.Rows.Count; i++)
                    {
                        string sql1 = "SELECT m_HelpSop.Name, m_DutyUsers_t.UserID ,m_DutyUsers_t.UserName,m_DutyUsers_t.Mobile,m_HelpSop.UpTime,m_HelpSop.Ttext,m_HelpSop.FileType,m_HelpSop.Download,m_HelpSop.Consult,m_HelpSop.Remark AS MajorName FROM m_HelpSop LEFT JOIN m_DutyUsers_t ON m_DutyUsers_t.UserID = m_HelpSop.UserId WHERE Name=N'" + h.Rows[i][0].ToString() + "'";
                        DataTable h1 = DbOperateUtils.GetDataTable(sql1);
                        //listView1.Items.Add(h.Rows[i][0].ToString(), int.Parse(h.Rows[i][1].ToString()));
                        label_Explain.Text = h1.Rows[0][9].ToString();
                        dataGridViewX1.Rows.Add(h1.Rows[0][0].ToString(), h1.Rows[0][1].ToString(), h1.Rows[0][2].ToString(), h1.Rows[0][3].ToString(), h1.Rows[0][4].ToString());
                    }
                }
                catch
                {
                }
            }
            }
            else
            {
                if (MessageBox.Show("该界面有下载任务正在执行是否停止下载（停止将删除已经下载的部分）", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation).ToString() == "Yes")
                {
                    th.Abort();
                    Whether = true;
                    tvFood_AfterSelect("", e);
                }
            }
        }
        #endregion
        #region 显示隐藏下载控件
        /// <summary>
        /// 显示下载控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void xianshi()
        {
            Downloaded.Visible = true;
            panel2.Visible = true;
        }
        public void yingcang()
        {
            Downloaded.Visible = false;
            panel2.Visible = false;
        }
        string xiazai = "等待中";
        #endregion
        #region 批量下载-方法
        //**********批量下载方法*********
        public void Piliangxiazai()
        {
            //int a = 0;
            //int b = -1;
            //listView1.CheckBoxes = false;
            //多选ToolStripMenuItem.Text = "批量下载";
            //toolStripButton2.Text = "批量选择";
            //pictureBox1.Visible = false;
            //foreach (ListViewItem item in listView1.Items)
            //{
            //    if (item.Checked == true)
            //    {
            //        a++;
            //    }
            //}
            //foreach (ListViewItem item in listView1.Items)
            //{
            //    if (item.Checked == true)
            //    {
            //        b++;
            //        Update(item.Text,1);
            //        Downloaded.Text = "文件个数:" + (b + 1).ToString() + "/" + a.ToString();
            //        string names = item.Text;
            //        file_name.Text = "正在下载：" + names;
            //        string sql = "select FilePath FROM m_HelpSop where Name=N'" + names + "'";
            //        DataTable h = DbOperateUtils.GetDataTable(sql);
            //        string strDestination = @"C:\MES操作SOP\";
            //        string strPath = Path.GetDirectoryName(strDestination);
            //        if (!Directory.Exists(strPath))
            //        {
            //            Directory.CreateDirectory(strPath);
            //        }
            //        Cpy(@h.Rows[0][0].ToString(), strDestination);
            //    }
            //}
            //yingcang();
            //Whether = true;
            //gaibian(out xiazai);
            //checkBox1.Checked = false;
            //checkBox1.Visible = false;
            //MessageBox.Show("下载的文件已全部保存在《C\\:MES操作SOP》");
        }
        #endregion
        #region 下载等待
        public void gaibian(out string xiazai)
        {
            xiazai = "等待中";
        }
        Thread th;
        #endregion
        #region 关闭窗口
        private void label8_Click(object sender, EventArgs e)
        {
            if (Whether)
            {
                this.Close();
            }
            else
            {
                if (MessageBox.Show("后台有下载任务正在执行是否确认退出（退出将导致部分PPT无法正常打开）", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation).ToString() == "Yes")
                {
                    this.Close();
                }
            }
        }
        #endregion
        #region 记录下载或查看的次数
        public void Update(string name,int Type)
        {
            if (Type == 1)
            {
                string sql = "select Download FROM m_HelpSop WHERE Name=N'" + name + "'";
                DataTable h = DbOperateUtils.GetDataTable(sql);
                int Download = (int)h.Rows[0][0]+1;
                label_Download.Text = "下载次数:" + Download+"次";
                string sql_upbate="UPDATE m_HelpSop SET Download ='"+ Download +"' WHERE  Name=N'"+ name +"'";
                DbOperateUtils.ExecSQL(sql_upbate);
            }
            else if (Type == 2)
            {
                string sql = "select Consult FROM m_HelpSop WHERE Name=N'" + name + "'";
                DataTable h = DbOperateUtils.GetDataTable(sql);
                int Consult = (int)h.Rows[0][0] + 1;
                label_Consult.Text = "查阅次数:" + Consult+"次";
                string sql_upbate = "UPDATE m_HelpSop SET Consult ='" + Consult + "' WHERE  Name=N'" + name + "'";
                DbOperateUtils.ExecSQL(sql_upbate);
            }
        }
        #endregion
        #region 将选择的文件详细信息添加到data中
        private void listView1_Click(object sender, EventArgs e)
        {
                int rows = dataGridViewX1.CurrentCell.RowIndex;//获得选种行的索引
                string name = dataGridViewX1.Rows[rows].Cells[0].Value.ToString();//获取第rows行的索引为num列的值
                if (name != "")
                {
                    string sql = "SELECT m_HelpSop.Name, m_DutyUsers_t.UserID ,m_DutyUsers_t.UserName,m_DutyUsers_t.Mobile,m_HelpSop.UpTime,m_HelpSop.Ttext,m_HelpSop.FileType,m_HelpSop.Download,m_HelpSop.Consult,m_HelpSop.Remark AS MajorName FROM m_HelpSop LEFT JOIN m_DutyUsers_t ON m_DutyUsers_t.UserID = m_HelpSop.UserId WHERE Name=N'" + name + "'";
                    DataTable h = DbOperateUtils.GetDataTable(sql);
                    label_name.Text = h.Rows[0][0].ToString();
                    label_Modular.Text = h.Rows[0][5].ToString();
                    label_Download.Text = "下载次数:" + h.Rows[0][7].ToString()+"次";
                    label_Consult.Text = "查阅次数:" + h.Rows[0][8].ToString()+"次";
                    switch (h.Rows[0][6].ToString())
                    {
                        case "0": label_type.Text = "未知类型";
                            break;
                        case "1": label_type.Text = "视频";
                            break;
                        case "2": label_type.Text = "PowerPoint PPT";
                            break;
                        case "3": label_type.Text = "Word 文档";
                            break;
                    }
                    int a = dataGridViewX1.Rows.Count;
            }
        }
        #endregion
        #region 用进程下载-方法
        public void data()
        {
            int i = Indexes[xzindexes];
            string names = xzname[xzindexes];
            string sql = "select FilePath FROM m_HelpSop where Name=N'" + names + "'";
            DataTable h = DbOperateUtils.GetDataTable(sql);
            string strDestination = @"C:\MES操作SOP\";
            string strPath = Path.GetDirectoryName(strDestination);
            if (!Directory.Exists(strPath))
            {
                Directory.CreateDirectory(strPath);
            }
            DagCpy(@h.Rows[0][0].ToString(), strPath, i);
            xiazai = "等待中";
        }
        #endregion
        #region 判断是否点击DataX中的下载或打开按钮
        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!Directory.Exists(@"\\192.168.20.123\FuJianCall\上传SOP\"))
                {
                    MessageBox.Show("无法访问“192.168.20.123”服务器请联系值班人员进行处理");
                    return;
                }
                if (dataGridViewX1.Columns[e.ColumnIndex].Name == "Column7")
                {
                    Update(dataGridViewX1.Rows[dataGridViewX1.CurrentCell.RowIndex].Cells["Column1"].Value.ToString(), 1);
                    Whether = false;
                    xzname.Add(dataGridViewX1.Rows[dataGridViewX1.CurrentCell.RowIndex].Cells["Column1"].Value.ToString());
                    dataGridViewX1.Rows[dataGridViewX1.CurrentCell.RowIndex].Cells["Column7"].ErrorText = "已添加";
                    Indexes.Add(dataGridViewX1.CurrentCell.RowIndex);
                    timer1.Enabled = true;
                }
                else if (dataGridViewX1.Columns[e.ColumnIndex].Name == "Column8")
                {
                    string names = dataGridViewX1.Rows[dataGridViewX1.CurrentCell.RowIndex].Cells["Column1"].Value.ToString();
                    Update(names, 2);
                    try
                    {
                        dataGridViewX1.Rows[dataGridViewX1.CurrentCell.RowIndex].Cells["Column6"].Value = 100;
                        ProcessStartInfo psiv = new ProcessStartInfo(@"C:\MES操作SOP\" + names);
                        Process pv = new Process();
                        pv.StartInfo = psiv;
                        pv.Start();
                    }
                    catch
                    {
                        Update(dataGridViewX1.Rows[dataGridViewX1.CurrentCell.RowIndex].Cells["Column1"].Value.ToString(), 1);
                        Whether = false;
                        xzname.Add(dataGridViewX1.Rows[dataGridViewX1.CurrentCell.RowIndex].Cells["Column1"].Value.ToString());
                        Indexes.Add(dataGridViewX1.CurrentCell.RowIndex);
                        timer1.Enabled = true;
                    }
                }
            }
            catch
            { 
            }
        }
        #endregion
        #region 依次下载等待中的任务
        private void timer1_Tick(object sender, EventArgs e)
        {
            int vv = 0;
            try
            {
                xianshi();
                for (int i = xzindexes; i < xzname.Count; i++)
                {
                    vv = xzindexes + 1;
                    Downloaded.Text = "下载个数：" + (xzindexes + 1).ToString() + "/" + (xzname.Count).ToString();
                    file_name.Text = "文件名：" + xzname[xzindexes + 1];
                    if (xiazai == "等待中")
                    {
                        xiazai = "下载中";
                        xianshi();
                        th = new Thread(data);
                        th.IsBackground = true;
                        th.Start();
                        xzindexes++;
                    }
                }

            }
            catch
            {

                timer1.Enabled = false;
            }
        }
        #endregion
        #region 默认选择给定的节点
        //递归查询,找到返回该节点
        private TreeNode FindNode(TreeNode node, string name)
        {
            //接受返回的节点
            TreeNode ret = null;
            //循环查找
            foreach (TreeNode temp in node.Nodes)
            {
                //是否有子节点
                if (temp.Nodes.Count != 0)
                {
                    //如果找到
                    if ((ret = FindNode(temp, name)) != null)
                    {
                        return ret;
                    }
                }
                //如果找到
                if (string.Equals(temp.Text, name))
                {
                    return temp;
                }
            }
            return ret;
        }
        #endregion
        #region 窗体最大化
        //最大化窗体
        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            try
            {
                dataGridViewX1.FirstDisplayedScrollingRowIndex = dataGridViewX1.Rows[dataGridViewX1.Rows.Count - 1].Index;
            }
            catch
            {
            }
        }
        //还原窗体
        private void label7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            try
            {
                dataGridViewX1.FirstDisplayedScrollingRowIndex = dataGridViewX1.Rows[dataGridViewX1.Rows.Count - 1].Index;
            }
            catch
            {
            }
        }
        #endregion

        private void toolStripButton5_Click(object sender, EventArgs e) 
        {
             try
            {
                if (!Directory.Exists(@"\\192.168.20.123\FuJianCall\上传SOP\"))
                {
                    MessageBox.Show("无法访问“192.168.20.123”服务器请联系值班人员进行处理");
                    return;
                }
                ProcessStartInfo psiv = new ProcessStartInfo(@"\\192.168.20.123\FuJianCall\上传SOP\SOP\HelpSOP.PPT");
                Process pv = new Process();
                pv.StartInfo = psiv;
                pv.Start();
            }
            catch { }
        }

        private void dataGridViewX1_Click(object sender, EventArgs e)
        {
            try
            {
            int rows = dataGridViewX1.CurrentCell.RowIndex;//获得选种行的索引
            string name = dataGridViewX1.Rows[rows].Cells[0].Value.ToString();//获取第rows行的索引为num列的值
            if (name != "")
            {
                string sql = "SELECT m_HelpSop.Name, m_DutyUsers_t.UserID ,m_DutyUsers_t.UserName,m_DutyUsers_t.Mobile,m_HelpSop.UpTime,m_HelpSop.Ttext,m_HelpSop.FileType,m_HelpSop.Download,m_HelpSop.Consult,m_HelpSop.Remark AS MajorName FROM m_HelpSop LEFT JOIN m_DutyUsers_t ON m_DutyUsers_t.UserID = m_HelpSop.UserId WHERE Name=N'" + name + "'";
                DataTable h = DbOperateUtils.GetDataTable(sql);
                label_name.Text = h.Rows[0][0].ToString();
                label_Modular.Text = h.Rows[0][5].ToString();
                label_Download.Text = "下载次数:" + h.Rows[0][7].ToString() + "次";
                label_Consult.Text = "查阅次数:" + h.Rows[0][8].ToString() + "次";
                switch (h.Rows[0][6].ToString())
                {
                    case "0": label_type.Text = "未知类型";
                        break;
                    case "1": label_type.Text = "视频";
                        break;
                    case "2": label_type.Text = "PowerPoint PPT";
                        break;
                    case "3": label_type.Text = "Word 文档";
                        break;
                }
                label_Explain.Text = h.Rows[0][9].ToString();
            }
            }
            catch
            {
            }
        }
    }
}
