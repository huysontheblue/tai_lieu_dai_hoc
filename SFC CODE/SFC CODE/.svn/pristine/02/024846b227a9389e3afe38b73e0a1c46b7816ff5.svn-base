using MainFrame.SysDataHandle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace RouteManagement
{
    public partial class FrmProduction : Form
    {
        string tag;
        public FrmProduction(string tagv)
        {
            tag = tagv;
            InitializeComponent();
        }
        #region 生产柱形图
        Bitmap image;
        //当天总产量
        int Total;
        int[] Count1 ;
        int[] Count1v;
        int[] Count2 ;
        int[] Count2v ;
        private void CreateImage(string Lineid)
        {
            Count1 = new int[5];
            Count1v = new int[5];
            Count2  = new int[5];
            Count2v = new int[5];
            int height = 430, width = 11560;
            image = new Bitmap(width, height);
            //创建Graphics类对象
            Graphics g = Graphics.FromImage(image);

            try
            {
                //清空图片背景色
                g.Clear(Color.White);

                Font font = new Font("Arial", 10, FontStyle.Regular);
                Font font1 = new Font("宋体", 20, FontStyle.Bold);

                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                Color.Blue, Color.BlueViolet, 1.2f, true);
                g.FillRectangle(Brushes.WhiteSmoke, 0, 0, width, height);
                // Brush brush1 = new SolidBrush(Color.Blue);

                g.DrawString(Lineid + " " + "生产" +
                " 统计柱状图", font1, brush, new PointF(70, 30));
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Blue), 0, 0, image.Width - 1, image.Height - 1);


                Pen mypen = new Pen(brush, 1);
                //绘制线条
                //绘制横向线条
                int x = 100;
                //for (int i = 0; i < 8; i++)
                //{
                //    g.DrawLine(mypen, x, 80, x, 340);
                //    x = x + 40;
                //}
                Pen mypen1 = new Pen(Color.Blue, 2);
                x = 60;
                g.DrawLine(mypen1, x, 80, x, 340);

                //绘制纵向线条
                int y = 106;
                for (int i = 0; i < 9; i++)
                {
                    g.DrawLine(mypen, 60, y, 500, y);
                    y = y + 26;
                }
                g.DrawLine(mypen1, 60, y, 500, y);

                //x轴
                String[] n = { "第一节", "第二节", "第三节", "第四节", "第五节" };
                x = 78;
                for (int i = 0; i < 5; i++)
                {
                    g.DrawString(n[i].ToString(), font, Brushes.Blue, x, 348); //设置文字内容及输出位置
                    x = x + 78;
                }
                //y轴
                String[] m = {"%100","%90", "%80", "%70", "%60", "%50", "%40", "%30",
" %20", "%10", "0"};
                y = 72;
                for (int i = 0; i < 10; i++)
                {
                    g.DrawString(m[i].ToString(), font, Brushes.Blue, 25, y); //设置文字内容及输出位置
                    y = y + 26;
                }
                List<int> amount = new List<int>();
                SysDataBaseClass V = new SysDataBaseClass();
                DataSet ds = new DataSet();
                ds = V.GetDataSet("exec UspGetKanbanData '" + Lineid + "' ,'" + datatim.Value.ToString("yyyy-MM-dd") + "'");
                double than = 1;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        amount.Add(Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString()));
                    }
                    amount.Sort();
                    than = (double)amount[ds.Tables[0].Rows.Count - 1] / (double)250;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Count1v[int.Parse(ds.Tables[0].Rows[i][2].ToString()) - 1] = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                        Count1[int.Parse(ds.Tables[0].Rows[i][2].ToString()) - 1] = Convert.ToInt32(double.Parse(ds.Tables[0].Rows[i][1].ToString()) / than);
                        Count2[int.Parse(ds.Tables[0].Rows[i][2].ToString()) - 1] = Convert.ToInt32(double.Parse(ds.Tables[0].Rows[i][1].ToString()) / than);
                        Count2v[int.Parse(ds.Tables[0].Rows[i][2].ToString()) - 1] = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                    }
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        Count2v[int.Parse(ds.Tables[1].Rows[i][2].ToString()) - 1] = Count2v[int.Parse(ds.Tables[1].Rows[i][2].ToString()) - 1] - int.Parse(ds.Tables[1].Rows[i][1].ToString());
                        Count2[int.Parse(ds.Tables[1].Rows[i][2].ToString()) - 1] = Count2[int.Parse(ds.Tables[1].Rows[i][2].ToString()) - 1] - Convert.ToInt32(double.Parse(ds.Tables[1].Rows[i][1].ToString()) / than);
                    }
                }
                //绘制柱状图.
                x = 20;
                Font font2 = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                SolidBrush mybrush = new SolidBrush(Color.Red);
                SolidBrush mybrush2 = new SolidBrush(Color.Green);
                //if (amount.Count>0 && amount[ds.Tables[0].Rows.Count - 1].ToString().Length > 3)
                //{
                for (int i = 0; i < 5; i++)
                {
                    if (Count1v[i] > 999)
                    {
                        x = x + 60;
                        //当数位大于三位数时上下显示
                        g.FillRectangle(mybrush, x, 340 - Count1[i], 20, Count1[i]);
                        g.DrawString(Count1v[i].ToString(), font2, Brushes.Red, x, 330 - Count1[i] - 15);

                        x = x + 20;
                        g.FillRectangle(mybrush2, x, 340 - Count2[i], 20, Count2[i]);
                        g.DrawString(Count2v[i].ToString(), font2, Brushes.Green, x, 340 - Count2[i] - 15);
                    }
                    else
                    {
                        x = x + 60;
                        //小于3位平齐显示
                        g.FillRectangle(mybrush, x, 340 - Count1[i], 20, Count1[i]);
                        g.DrawString(Count1v[i].ToString(), font2, Brushes.Red, x, 340 - Count1[i] - 15);

                        x = x + 20;
                        g.FillRectangle(mybrush2, x, 340 - Count2[i], 20, Count2[i]);
                        g.DrawString(Count2v[i].ToString(), font2, Brushes.Green, x, 340 - Count2[i] - 15);
                    }

                }
                //绘制标识
                Font font3 = new System.Drawing.Font("Arial", 10, FontStyle.Regular);
                g.DrawRectangle(new Pen(Brushes.Blue), 170, 390, 250, 50); //绘制范围框
                g.FillRectangle(Brushes.Red, 190, 400, 20, 10); //绘制小矩形
                g.DrawString("计划完成", font3, Brushes.Red, 212, 398);

                g.FillRectangle(Brushes.Green, 310, 400, 20, 10);
                g.DrawString("实际完成", font3, Brushes.Green, 332, 398);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Total = 0;
                for (int i = 0; i < 5; i++)
                {
                    Total = Total + Count2v[i];
                }
                try
                {
                    //实例化创建对象item
                    ListViewItem item = new ListViewItem();
                    listView1.Items.Clear();
                    for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                    {
                        //向listView控件的项中添加第一个元素ID  
                        item = listView1.Items.Add(ds.Tables[2].Rows[i][1].ToString()); //个人认为这句类似于数据库的添加主键元素,为了标明到底是哪一行,为后续操作做铺垫  
                        //在子项中继续添加第二个元素User  
                        item.SubItems.Add(ds.Tables[2].Rows[i][2].ToString());         //这句操作会跟随上句类似添加主键操作后面,作为主键那行的第二个元素  
                        //同理添加第三个元素  
                        item.SubItems.Add(ds.Tables[2].Rows[i][3].ToString());         //原理同上,后面可以继续添加元素，如果你有需求且在winform中已设计好属性列个数  
                        //清空上次添加的数据,方便这次添加新数据  
                        item.SubItems.Add(ds.Tables[2].Rows[i][4].ToString());
                        item.SubItems.Add(ds.Tables[2].Rows[i][5].ToString());
                        if (Total != 0)
                        {
                            item.SubItems.Add(((double.Parse(ds.Tables[2].Rows[i][3].ToString()) / (double)Total)*100.00).ToString("#0.00 ") + "%");
                        }
                    }
                    listView2.Items.Clear();
                    for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                    {
                        //向listView控件的项中添加第一个元素ID  
                        item = listView2.Items.Add(ds.Tables[3].Rows[i][1].ToString());
                        item.SubItems.Add(ds.Tables[3].Rows[i][2].ToString());
                        item.SubItems.Add(ds.Tables[3].Rows[i][3].ToString());
                        if (Total != 0)
                        {
                            item.SubItems.Add(((double.Parse(ds.Tables[3].Rows[i][3].ToString()) / (double)Total) * 100.00).ToString("#0.00 ") + "%");
                        }
                    }
                }
                catch
                { }
                pictureBox1.Image = image;
            }
            catch
            {
            }
        }
        #endregion
        #region 控件
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProduction));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ToolBt = new System.Windows.Forms.ToolStrip();
            this.ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSearch = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.datatim = new System.Windows.Forms.DateTimePicker();
            this.BtnQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboQueryLine = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUL1 = new TextBoxUL.TextBoxUL();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUL2 = new TextBoxUL.TextBoxUL();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxUL3 = new TextBoxUL.TextBoxUL();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxUL4 = new TextBoxUL.TextBoxUL();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxUL5 = new TextBoxUL.TextBoxUL();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.报废率 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.打印PToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ToolBt.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(642, 434);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ToolBt
            // 
            this.ToolBt.AutoSize = false;
            this.ToolBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
            this.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolBt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSeparator6,
            this.toolSearch,
            this.ToolStripSeparator3,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripSeparator4,
            this.toolStripButton3,
            this.ToolStripSeparator1,
            this.toolExit});
            this.ToolBt.Location = new System.Drawing.Point(0, 0);
            this.ToolBt.Name = "ToolBt";
            this.ToolBt.Size = new System.Drawing.Size(1350, 23);
            this.ToolBt.TabIndex = 48;
            this.ToolBt.TabStop = true;
            this.ToolBt.Text = "ToolStrip1";
            // 
            // ToolStripSeparator6
            // 
            this.ToolStripSeparator6.Name = "ToolStripSeparator6";
            this.ToolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // toolSearch
            // 
            this.toolSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolSearch.Image")));
            this.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSearch.Name = "toolSearch";
            this.toolSearch.Size = new System.Drawing.Size(78, 20);
            this.toolSearch.Text = "统计图(&F)";
            this.toolSearch.ToolTipText = "查找";
            this.toolSearch.Click += new System.EventHandler(this.toolSearch_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(76, 20);
            this.toolStripButton2.Text = "明细查询";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 20);
            this.toolStripButton1.Text = "汇出";
            this.toolStripButton1.ToolTipText = "汇出图表";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(76, 20);
            this.toolStripButton3.Text = "汇出数据";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolExit
            // 
            this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
            this.toolExit.ImageTransparentColor = System.Drawing.Color.White;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(72, 20);
            this.toolExit.Text = "退 出(&X)";
            this.toolExit.ToolTipText = "退出";
            this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 49;
            this.label1.Text = "线别:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.datatim);
            this.groupBox1.Controls.Add(this.BtnQuery);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboQueryLine);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 67);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // datatim
            // 
            this.datatim.Location = new System.Drawing.Point(218, 25);
            this.datatim.Name = "datatim";
            this.datatim.Size = new System.Drawing.Size(124, 21);
            this.datatim.TabIndex = 66;
            // 
            // BtnQuery
            // 
            this.BtnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnQuery.Image = ((System.Drawing.Image)(resources.GetObject("BtnQuery.Image")));
            this.BtnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnQuery.Location = new System.Drawing.Point(373, 22);
            this.BtnQuery.Name = "BtnQuery";
            this.BtnQuery.Size = new System.Drawing.Size(72, 24);
            this.BtnQuery.TabIndex = 53;
            this.BtnQuery.Text = "查 詢";
            this.BtnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnQuery.UseVisualStyleBackColor = true;
            this.BtnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 52;
            this.label2.Text = "日期:";
            // 
            // cboQueryLine
            // 
            this.cboQueryLine.DropDownHeight = 80;
            this.cboQueryLine.IntegralHeight = false;
            this.cboQueryLine.ItemHeight = 12;
            this.cboQueryLine.Location = new System.Drawing.Point(54, 26);
            this.cboQueryLine.Name = "cboQueryLine";
            this.cboQueryLine.Size = new System.Drawing.Size(107, 20);
            this.cboQueryLine.TabIndex = 50;
            this.cboQueryLine.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(625, 110);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(828, 434);
            this.pictureBox2.TabIndex = 52;
            this.pictureBox2.TabStop = false;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(89)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.EnableHeadersVisualStyles = false;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(211)))), ((int)(((byte)(217)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 170);
            this.dataGridViewX1.Name = "dataGridViewX1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(1350, 536);
            this.dataGridViewX1.TabIndex = 53;
            this.dataGridViewX1.Visible = false;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "序号";
            this.Column7.FillWeight = 35.53299F;
            this.Column7.HeaderText = "序号";
            this.Column7.Name = "Column7";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Moid";
            this.Column1.FillWeight = 110.7445F;
            this.Column1.HeaderText = "工单";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Ppid";
            this.Column2.FillWeight = 110.7445F;
            this.Column2.HeaderText = "条码";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Stationid";
            this.Column3.FillWeight = 110.7445F;
            this.Column3.HeaderText = "工站";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Teamid";
            this.Column4.FillWeight = 110.7445F;
            this.Column4.HeaderText = "线别";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Userid";
            this.Column5.FillWeight = 110.7445F;
            this.Column5.HeaderText = "扫描人员";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Intime";
            this.Column6.FillWeight = 110.7445F;
            this.Column6.HeaderText = "扫描时间";
            this.Column6.Name = "Column6";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "序号";
            this.dataGridViewTextBoxColumn1.FillWeight = 35.53299F;
            this.dataGridViewTextBoxColumn1.HeaderText = "序号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 66;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Moid";
            this.dataGridViewTextBoxColumn2.FillWeight = 110.7445F;
            this.dataGridViewTextBoxColumn2.HeaderText = "工单";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 207;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Ppid";
            this.dataGridViewTextBoxColumn3.FillWeight = 110.7445F;
            this.dataGridViewTextBoxColumn3.HeaderText = "条码";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 207;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Stationid";
            this.dataGridViewTextBoxColumn4.FillWeight = 110.7445F;
            this.dataGridViewTextBoxColumn4.HeaderText = "工站";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 207;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Teamid";
            this.dataGridViewTextBoxColumn5.FillWeight = 110.7445F;
            this.dataGridViewTextBoxColumn5.HeaderText = "线别";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 206;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Userid";
            this.dataGridViewTextBoxColumn6.FillWeight = 110.7445F;
            this.dataGridViewTextBoxColumn6.HeaderText = "扫描人员";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 207;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Intime";
            this.dataGridViewTextBoxColumn7.FillWeight = 110.7445F;
            this.dataGridViewTextBoxColumn7.HeaderText = "扫描时间";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 207;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(1060, 571);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 21);
            this.label3.TabIndex = 54;
            this.label3.Text = "线别";
            // 
            // textBoxUL1
            // 
            this.textBoxUL1.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxUL1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.textBoxUL1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUL1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxUL1.Location = new System.Drawing.Point(1118, 571);
            this.textBoxUL1.Multiline = true;
            this.textBoxUL1.Name = "textBoxUL1";
            this.textBoxUL1.Size = new System.Drawing.Size(190, 21);
            this.textBoxUL1.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(1060, 619);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 21);
            this.label4.TabIndex = 56;
            this.label4.Text = "线长";
            // 
            // textBoxUL2
            // 
            this.textBoxUL2.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxUL2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.textBoxUL2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUL2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxUL2.Location = new System.Drawing.Point(1118, 619);
            this.textBoxUL2.Multiline = true;
            this.textBoxUL2.Name = "textBoxUL2";
            this.textBoxUL2.Size = new System.Drawing.Size(190, 21);
            this.textBoxUL2.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(1062, 667);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 12);
            this.label5.TabIndex = 58;
            this.label5.Text = "PIE";
            // 
            // textBoxUL3
            // 
            this.textBoxUL3.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxUL3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.textBoxUL3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUL3.Location = new System.Drawing.Point(1091, 667);
            this.textBoxUL3.Name = "textBoxUL3";
            this.textBoxUL3.Size = new System.Drawing.Size(47, 14);
            this.textBoxUL3.TabIndex = 59;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(1144, 667);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 60;
            this.label6.Text = "PQE";
            // 
            // textBoxUL4
            // 
            this.textBoxUL4.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxUL4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.textBoxUL4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUL4.Location = new System.Drawing.Point(1173, 667);
            this.textBoxUL4.Name = "textBoxUL4";
            this.textBoxUL4.Size = new System.Drawing.Size(47, 14);
            this.textBoxUL4.TabIndex = 61;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(1226, 667);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 62;
            this.label7.Text = "生技";
            // 
            // textBoxUL5
            // 
            this.textBoxUL5.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxUL5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.textBoxUL5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUL5.Location = new System.Drawing.Point(1261, 667);
            this.textBoxUL5.Name = "textBoxUL5";
            this.textBoxUL5.Size = new System.Drawing.Size(47, 14);
            this.textBoxUL5.TabIndex = 63;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 550);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(688, 156);
            this.listView1.TabIndex = 64;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "种类";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "不良类型";
            this.columnHeader2.Width = 78;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "不良数";
            this.columnHeader3.Width = 66;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "工单";
            this.columnHeader4.Width = 245;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "扫描人员";
            this.columnHeader5.Width = 141;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "不良率";
            this.columnHeader6.Width = 94;
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.报废率});
            this.listView2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(713, 550);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(315, 156);
            this.listView2.TabIndex = 65;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "报废大类";
            this.columnHeader8.Width = 78;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "报废类型";
            this.columnHeader9.Width = 66;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "报废数";
            this.columnHeader10.Width = 80;
            // 
            // 报废率
            // 
            this.报废率.Text = "报废率";
            this.报废率.Width = 87;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.打印PToolStripButton});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 708);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1350, 25);
            this.bindingNavigator1.TabIndex = 66;
            this.bindingNavigator1.Text = "bindingNavigator1";
            this.bindingNavigator1.Visible = false;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(32, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到第一条记录";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一条记录";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "移到下一条记录";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "移到最后一条记录";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // 打印PToolStripButton
            // 
            this.打印PToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.打印PToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("打印PToolStripButton.Image")));
            this.打印PToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打印PToolStripButton.Name = "打印PToolStripButton";
            this.打印PToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.打印PToolStripButton.Text = "打印(&P)";
            this.打印PToolStripButton.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(12, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1338, 65);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "筛选条件";
            this.groupBox2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(276, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 21);
            this.textBox1.TabIndex = 54;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(454, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 24);
            this.button1.TabIndex = 53;
            this.button1.Text = "查 詢";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(234, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 52;
            this.label8.Text = "条码:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownHeight = 80;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.ItemHeight = 12;
            this.comboBox1.Items.AddRange(new object[] {
            ""});
            this.comboBox1.Location = new System.Drawing.Point(54, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(149, 20);
            this.comboBox1.TabIndex = 50;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 49;
            this.label9.Text = "工单:";
            // 
            // FrmProduction
            // 
            this.ClientSize = new System.Drawing.Size(1350, 733);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.textBoxUL5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxUL4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxUL3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxUL2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxUL1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ToolBt);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProduction";
            this.Text = "生产数据汇总";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmProduction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ToolBt.ResumeLayout(false);
            this.ToolBt.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        SysDataBaseClass Vn = new SysDataBaseClass();
        DataTable dsn = new DataTable();
        #region 线别模糊查询
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboQueryLine.DroppedDown == false)
                {
                    if (cboQueryLine.Text.Length == 5)
                    {
                        return;
                    }
                    else
                    {
                        cboQueryLine.Items.Clear();
                        cboQueryLine.DroppedDown = true;
                        cboQueryLine.SelectionStart = cboQueryLine.Text.Length;
                        string sql = "select distinct(lineid) FROM deptline_t where factoryid='LXXT'AND lineid like '%" + cboQueryLine.Text + "%'";
                        dsn = Vn.GetDataTable(sql);
                        for (int i = 0; i < dsn.Rows.Count; i++)
                        {
                            cboQueryLine.Items.Add(dsn.Rows[i][0]);
                        }
                        if (cboQueryLine.Items.Count < 12)
                        {
                            cboQueryLine.ItemHeight = cboQueryLine.Items.Count;
                            cboQueryLine.DroppedDown = true;
                        }
                        else
                        {
                            cboQueryLine.DroppedDown = true;
                        }
                    }
                }
            }
            catch
            { }
        }
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Visible)
            {
                toolStripButton2_Click(sender, e);
            }
            else
            {
                dataGridViewX1.Visible = false;
                bindingNavigator1.Visible = false;
                groupBox2.Visible = false;
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                CreateImage(cboQueryLine.Text);
                CreateImage();
                data();
            }
        }
        List<int> max = new List<int>();
        #endregion
        #region 周折线图
        int[] Counts1 = new int[7];
        int[] Counts2 = new int[7];
        List<string> datatime = new List<string>();
        private void CreateImage()
        {
            int height = 430, width = 720;
            Bitmap image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);

            try
            {
                //清空图片背景色
                g.Clear(Color.White);

                Font font = new System.Drawing.Font("Arial", 9, FontStyle.Regular);
                Font font1 = new System.Drawing.Font("宋体", 20, FontStyle.Regular);
                Font font2 = new System.Drawing.Font("Arial", 8, FontStyle.Regular);
                LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.Blue, 1.2f, true);
                g.FillRectangle(Brushes.WhiteSmoke, 0, 0, width, height);
                Brush brush1 = new SolidBrush(Color.Blue);
                Brush brush2 = new SolidBrush(Color.SaddleBrown);
                g.DrawString(cboQueryLine.Text + " " + "周" +
                " 生产统计折线图", font1, brush1, new PointF(70, 30));
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Blue), 0, 0, image.Width - 1, image.Height - 1);

                Pen mypen = new Pen(brush, 1);
                Pen mypen2 = new Pen(Color.Red, 2);
                //绘制线条
                //绘制纵向线条
                int x = 60;
                for (int i = 0; i < 8; i++)
                {
                    g.DrawLine(mypen, x, 80, x, 340);
                    x = x + 80;
                }
                Pen mypen1 = new Pen(Color.Blue, 3);
                x = 60;
                g.DrawLine(mypen1, x, 82, x, 340);

                //绘制横向线条
                int y = 106;
                for (int i = 0; i < 10; i++)
                {
                    g.DrawLine(mypen, 60, y, 620, y);
                    y = y + 26;
                }
                // y = 106;
                g.DrawLine(mypen1, 60, y - 26, 620, y - 26);

                //x轴
                String[] n = { "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日" };
                x = 45;
                for (int i = 0; i < 7; i++)
                {
                    g.DrawString(n[i].ToString(), font, Brushes.Red, x, 348); //设置文字内容及输出位置
                    x = x + 77;
                }

                //y轴




                string tim = datatim.Value.ToString();
                char[] chs = { '/' };
                string[] date = tim.Split(chs, StringSplitOptions.RemoveEmptyEntries);
                DateTime someDay = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2].Substring(0, 2).Trim())); //此处换成你实际的日期        
                int wd = (int)someDay.DayOfWeek;
                datatime.Clear();
                for (int i = 1 - wd; i < 8 - wd; i++)
                {
                    DateTime currentDay = someDay.AddDays(i);
                    datatime.Add(currentDay.ToShortDateString());
                    //MessageBox.Show(currentDay.ToShortDateString());
                    //MessageBox.Show(currentDay.DayOfWeek.ToString());
                }
                String[] v = { datatime[0], datatime[1], datatime[2], datatime[3], datatime[4], datatime[5], datatime[6] };
                x = 30;
                for (int i = 0; i < 7; i++)
                {
                    g.DrawString(v[i].ToString(), font, Brushes.Red, x, 370); //设置文字内容及输出位置
                    x = x + 79;
                }
                string sql = string.Format(@"SELECT SUM(ProdQty) FROM  dbo.fun_GetKanbanData('{0}','{1}')
                                            UNION ALL
                                            SELECT SUM(ProdQty) FROM  dbo.fun_GetKanbanData('{0}','{2}')
                                            UNION ALL
                                            SELECT SUM(ProdQty)  FROM  dbo.fun_GetKanbanData('{0}','{3}')
                                            UNION ALL
                                            SELECT SUM(ProdQty)  FROM  dbo.fun_GetKanbanData('{0}','{4}')
                                            UNION ALL
                                            SELECT SUM(ProdQty)  FROM  dbo.fun_GetKanbanData('{0}','{5}')
                                            UNION ALL
                                            SELECT SUM(ProdQty)  FROM  dbo.fun_GetKanbanData('{0}','{6}')
                                            UNION ALL
                                            SELECT SUM(ProdQty)  FROM  dbo.fun_GetKanbanData('{0}','{7}')", cboQueryLine.Text.Trim(), datatime[0], datatime[1], datatime[2], datatime[3], datatime[4], datatime[5], datatime[6]);
                DataTable ds = new DataTable();
                ds = Vn.GetDataTable(sql);
                //报名人数
                max.Clear();
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(ds.Rows[i][0].ToString()))
                    {
                        max.Add(0);
                    }
                    else
                    {
                        max.Add(Convert.ToInt32(ds.Rows[i][0].ToString()));
                    }
                }
                max.Sort();
                double maxx;
                if (max[6] <= 250)
                {
                    maxx = 1;
                }
                else
                {
                    maxx = max[6] / (double)250;
                }
                String[] m = { ((int)(220*maxx)).ToString(), ((int)(200*maxx)).ToString(), ((int)(175*maxx)).ToString(), ((int)(150*maxx)).ToString(), ((int)(125*maxx)).ToString(), ((int)(100*maxx)).ToString(), ((int)(75*maxx)).ToString(), ((int)(50*maxx)).ToString(),
((int)(25*maxx)).ToString()};
                y = 100;
                for (int i = 0; i < 9; i++)
                {
                    g.DrawString(m[i].ToString(), font, Brushes.Red, 10, y); //设置文字内容及输出位置
                    y = y + 26;
                }
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(ds.Rows[i][0].ToString()))
                    {
                        Counts1[i] = 0;
                        Counts2[i] = 0;
                    }
                    else
                    {
                        Counts1[i] = Convert.ToInt32((double.Parse(ds.Rows[i][0].ToString()) / maxx));
                        Counts2[i] = Convert.ToInt32(ds.Rows[i][0].ToString());
                    }
                }
                //显示折线效果
                Font font3 = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                SolidBrush mybrush = new SolidBrush(Color.Red);
                Point[] points1 = new Point[7];
                points1[0].X = 60; points1[0].Y = 340 - Counts1[0]; //从106纵坐标开始, 到(0, 0)坐标时
                points1[1].X = 140; points1[1].Y = 340 - Counts1[1];
                points1[2].X = 220; points1[2].Y = 340 - Counts1[2];
                points1[3].X = 300; points1[3].Y = 340 - Counts1[3];

                points1[4].X = 380; points1[4].Y = 340 - Counts1[4];
                points1[5].X = 460; points1[5].Y = 340 - Counts1[5];

                points1[6].X = 540; points1[6].Y = 340 - Counts1[6];
                g.DrawLines(mypen2, points1); //绘制折线

                //绘制数字
                g.DrawString(Counts2[0].ToString(), font3, Brushes.Red, 58, points1[0].Y - 20);
                g.DrawString(Counts2[1].ToString(), font3, Brushes.Red, 138, points1[1].Y - 20);
                g.DrawString(Counts2[2].ToString(), font3, Brushes.Red, 218, points1[2].Y - 20);
                g.DrawString(Counts2[3].ToString(), font3, Brushes.Red, 298, points1[3].Y - 20);

                g.DrawString(Counts2[4].ToString(), font3, Brushes.Red, 378, points1[4].Y - 20);
                g.DrawString(Counts2[5].ToString(), font3, Brushes.Red, 458, points1[5].Y - 20);

                g.DrawString(Counts2[6].ToString(), font3, Brushes.Red, 538, points1[6].Y - 20);

                Pen mypen3 = new Pen(Color.Green, 2);
                Point[] points2 = new Point[7];
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                pictureBox2.Image = image;
            }
            catch
            { }
        }
        #endregion
        #region 导出统计图
        private void outPutExcel(string saveFilepath)
        {
            bool isShowExcel = false;
            Missing miss = Missing.Value;
            Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("请确保您的电脑已经安装Excel！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //xlApp.UserControl = true;
            Excel.Workbooks workBooks = xlApp.Workbooks;
            //Excel.Workbook workBook = workBooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);//创建新的
            //System.AppDomain.CurrentDomain.BaseDirectory 
            Excel.Workbook workBook;
            try
            {
                workBook = workBooks.Add(@"\\192.168.20.123\FuJianCall\生产统计\" + "production.xlsx");//根据现有excel模板产生新的Workbook
                Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets["Sheet2"];//获取sheet1
                xlApp.DisplayAlerts = false;//保存Excel的时候，不弹出是否保存的窗口直接进行保存
                //workSheet.get_Range("A3", "B3").Merge(workSheet.get_Range("A3", "B3").MergeCells);//合并单元格
                if (workSheet == null)
                {
                    MessageBox.Show("请确保您的电脑已经安装Excel！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
         
            for (int i = 0; i < 5; i++)
            {
                workSheet.Cells[i + 2, "B"] = Count1v[i];
                workSheet.Cells[i + 2, "C"] = Count2v[i];
            }
            for (int i = 0; i < 7; i++)
            {
                workSheet.Cells[i + 11, "A"] = datatime[i];
                workSheet.Cells[i + 11, "C"] = Counts2[i];
            }
            workSheet.Cells[1, "D"] = cboQueryLine.Text + " 生产统计柱状图";
            workSheet.Cells[1, "K"] = cboQueryLine.Text + " 周生产统计折线图";
            }
            catch
            {
                MessageBox.Show("请确保您的电脑可以访问“\\192.168.20.123”服务器！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                xlApp.Visible = isShowExcel;//若是true,则在导出的时候会显示excel界面
                workBook.SaveAs(saveFilepath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                workBooks.Close();
                MessageBox.Show("导出成功");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel导出失败，错误：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                xlApp.Quit();
                //regExpre.KillExcelProcess();
            }
            finally
            {
                xlApp.Quit();
                //regExpre.KillExcelProcess();
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string fileName = "";//要保存的excel文件名
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "导出1997-2003版本Excel(*.xls)|*.xls,导出2007版本Excel(*.xlsx)|*.xlsx";

            //扩展名 
            sfd.FileName = "生产统计图";//  
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fileName = sfd.FileName; //导入 
                outPutExcel(fileName);
            }
        }
        #endregion
        #region 明细查询
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dataGridViewX1.Visible = true;
            bindingNavigator1.Visible = true;
            groupBox2.Visible = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            dataGridViewX1.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleTurquoise;
            string sql = @"SELECT ROW_NUMBER() OVER (ORDER BY Moid DESC) AS 序号,Moid,Ppid,Stationid,Teamid,Userid,Intime FROM ReportDB.dbo.m_AssysnDReport_t 
WHERE Teamid='" + cboQueryLine.Text.Trim() + "' AND CONVERT(varchar(10),Intime, 23)='"+ datatim.Value.ToString("yyyy-MM-dd") +"' AND Estateid='Y' ORDER BY Moid DESC";
            dsn = Vn.GetDataTable(sql);
            bs = new BindingSource();//BindingSource对象，用来转换datatable数据源的
            bs.DataSource = dsn;
            //bs.DataSource = t.SearchDb;//t.SearchDb是一个有数据的datatable，把/t.SearchDb绑定到bs上
            bindingNavigator1.BindingSource = bs;//把数据源绑定在bindingNavigator1上
            dataGridViewX1.DataSource = bs;//把数据源绑定在dataGridView1上
            sql = @"SELECT distinct(Moid) FROM ReportDB.dbo.m_AssysnDReport_t 
WHERE Teamid='" + cboQueryLine.Text.Trim() + "' AND CONVERT(varchar(10),Intime, 23)='" + datatim.Value.ToString("yyyy-MM-dd") + "' AND Estateid='Y' ORDER BY Moid DESC";
            dsn = Vn.GetDataTable(sql);
            comboBox1.Items.Clear();
            for (int i = 0; i < dsn.Rows.Count; i++)
            {
                comboBox1.Items.Add(dsn.Rows[i][0]);
            }
            comboBox1.Items.Add("");
        }
        #endregion
        #region 窗体加载事件
        BindingSource bs;
        private void FrmProduction_Load(object sender, EventArgs e)
        {
            if (tag != "")
            {
                cboQueryLine.Text = tag;
                BtnQuery_Click(sender, e);
            } 
        }
        #endregion
        #region 导出生产数据
        private void data()
        {
            if (cboQueryLine.Text == "")
            {
                return;
            }
            else
            {
                string sql = "EXEC UspGetKanbanPlan '" + cboQueryLine.Text + "'";
                dsn = Vn.GetDataTable(sql);
                if (dsn.Rows.Count > 0)
                {
                    textBoxUL1.Text = dsn.Rows[0][0].ToString();
                    textBoxUL2.Text = dsn.Rows[0][2].ToString();
                    textBoxUL3.Text = dsn.Rows[0][4].ToString();
                    textBoxUL4.Text = dsn.Rows[0][6].ToString();
                    textBoxUL5.Text = dsn.Rows[0][8].ToString();
                }
                else
                {
                    textBoxUL1.Text = "";
                    textBoxUL2.Text = "";
                    textBoxUL3.Text = "";
                    textBoxUL4.Text = "";
                    textBoxUL5.Text = "";
                }
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
            if (dataGridViewX1.Rows.Count==0)
            {
                toolStripButton2_Click(sender, e);
            }
            if (dataGridViewX1.Rows.Count == 0)
            {
                MessageBox.Show(cboQueryLine.Text + "线" + datatim.Value.ToString("yyyy-MM-dd") + "无生产数据");
                return;
            }
            string fileName = "";

            string saveFileName = "";

            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.DefaultExt = "xlsx";

            saveDialog.Filter = "Excel文件|*.xlsx";

            saveDialog.FileName = fileName;

            saveDialog.ShowDialog();

            saveFileName = saveDialog.FileName;

            if (saveFileName.IndexOf(":") < 0) return; //被点了取消

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {

                MessageBox.Show("无法创建Excel对象，您的电脑可能未安装Excel");

                return;

            }

            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;

            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);

            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 

            //写入标题             

            for (int i = 0; i < dataGridViewX1.ColumnCount; i++)

            { worksheet.Cells[1, i + 1] = dataGridViewX1.Columns[i].HeaderText; }

            //写入数值

            for (int r = 0; r < dataGridViewX1.Rows.Count; r++)
            {
                for (int i = 0; i < dataGridViewX1.ColumnCount; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = dataGridViewX1.Rows[r].Cells[i].Value;
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应

            MessageBox.Show(fileName + "资料保存成功", "提示", MessageBoxButtons.OK);

            if (saveFileName != "")
            {

                try
                {
                    workbook.Saved = true;

                    workbook.SaveCopyAs(saveFileName);  //fileSaved = true;                 

                }

                catch (Exception ex)
                {//fileSaved = false;                      

                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);

                }

            }

            xlApp.Quit();

            GC.Collect();//强行销毁           }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridViewX1.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleTurquoise;
            string sql = @"SELECT ROW_NUMBER() OVER (ORDER BY Moid DESC) AS 序号,Moid,Ppid,Stationid,Teamid,Userid,Intime FROM ReportDB.dbo.m_AssysnDReport_t 
WHERE Teamid='" + cboQueryLine.Text.Trim() + "' AND CONVERT(varchar(10),Intime, 23)='" + datatim.Value.ToString("yyyy-MM-dd") + "' AND Estateid='Y'";
            if (comboBox1.Text.Length!=0)
            {
                sql += "and Moid ='"+comboBox1.Text+"'";
            }
            if (textBox1.Text.Length!=0)
            {
                sql += "and Ppid ='" + textBox1.Text + "'";
            }
            sql += "ORDER BY Moid DESC";
            dsn = Vn.GetDataTable(sql);
            bs = new BindingSource();//BindingSource对象，用来转换datatable数据源的
            bs.DataSource = dsn;
            //bs.DataSource = t.SearchDb;//t.SearchDb是一个有数据的datatable，把/t.SearchDb绑定到bs上
            bindingNavigator1.BindingSource = bs;//把数据源绑定在bindingNavigator1上
            dataGridViewX1.DataSource = bs;//把数据源绑定在dataGridView1上
        }

        private void toolSearch_Click(object sender, EventArgs e)
        {
            dataGridViewX1.Visible = false;
            bindingNavigator1.Visible = false;
            groupBox2.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            CreateImage(cboQueryLine.Text);
            CreateImage();
            data();
        }
        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
