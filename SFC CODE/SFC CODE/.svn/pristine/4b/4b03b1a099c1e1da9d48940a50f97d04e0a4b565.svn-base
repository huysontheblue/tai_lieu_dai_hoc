using MainFrame.SysDataHandle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RouteManagement
{
    public partial class Exclude : Form
    {
        public Exclude()
        {
            InitializeComponent();
        }
        SysDataBaseClass DB = new SysDataBaseClass();
        string judge;
        //新增
        public void add()
        {
            ToolQuery.Enabled = false;
            ToolNew.Enabled = false;
            ToolCancel.Enabled = true;
            ToolSave.Enabled = true;
            ToolEdit.Enabled = false;
            ToolAbandon.Enabled = false;
        }
        //修改
        public void update()
        {
            ToolQuery.Enabled = false;
            ToolNew.Enabled = false;
            ToolCancel.Enabled = true;
            ToolSave.Enabled = true;
            ToolEdit.Enabled = false;
            ToolAbandon.Enabled = false;
        }
        //查询
        public void query()
        {
            ToolQuery.Enabled = true;
            ToolNew.Enabled = true;
            ToolCancel.Enabled = false;
            ToolSave.Enabled = false;
            ToolEdit.Enabled = true;
            ToolAbandon.Enabled = true;
        }
        //新增按钮
        private void ToolNew_Click(object sender, EventArgs e)
        {
            Addbutton();
            DgMoData.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleTurquoise;
            judge = "add";
        }

        private void Addbutton()
        {
            add();
            foreach (var item in dataPanel.Controls)
            {
                if (item is TextBox)
                {
                    TextBox textbox = (TextBox)item;
                    textbox.Text = "";
                }
                if (item is ComboBox)
                {
                    ComboBox combox = (ComboBox)item;
                    combox.Text = "";
                }
            }
        }

        private void ToolSave_Click(object sender, EventArgs e)
        {
            foreach (var item in dataPanel.Controls)
            {
                if (item is TextBox)
                {
                    TextBox textbox = (TextBox)item;
                    if (textbox.Text.Trim() == "")
                    {
                        MessageBox.Show("请将资料填写完整");
                        return;
                    }
                }
                if (item is ComboBox)
                {
                    ComboBox combox = (ComboBox)item;
                    if (combox.Text.Trim() == "")
                    {
                        MessageBox.Show("请将资料填写完整");
                        return;
                    }
                }
            }
            string TxtItmnb = TxtItmnbr.Text.Trim();
            if (judge == "add")
            {
                string sql = "select * from M_sample_G where [TxtItmnbr]='" + TxtItmnbr.Text.Trim() + "'";
                DataTable dt = DB.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("当前料号已存在不允许重复录入");
                    return;
                }

                sql = "INSERT INTO M_sample_G([Receipttime],[Customer],[TxtItmnbr],[SNID],[describe],[responsibility],[demandQTY],[statetime],[state],[Remarks],[data],[materiel],[Jip],[mould],[quality],USID,department)VALUES(N'" + Receipttime.Value + "',N'" + Customer.Text + "',N'" + TxtItmnbr.Text + "',N'" + SNID.Text + "',N'" + describe.Text + "',N'" + responsibility.Text + "',N'" + demandQTY.Text + "',N'" + statetime.Value + "',N'" + state.Text + "',N'" + Remarks.Text + "',N'" + data.Text + "',N'" + materiel.Text + "',N'" + Jip.Text + "',N'" + mould.Text + "',N'" + quality.Text + "',N'" + VbCommClass.VbCommClass.UseId + "',N'" + department.Text.Trim() + "')";
                dt = DB.GetDataTable(sql);
                MessageBox.Show("保存成功");
                Addbutton();
                sql = "SELECT [Receipttime],[Customer],[TxtItmnbr],[SNID],[describe],[responsibility],[demandQTY],[statetime],[state],[Remarks],[data],[materiel],[Jip],[mould],[quality],[time],USID,department FROM M_sample_G where  TxtItmnbr='" + TxtItmnb + "'";
                dt = DB.GetDataTable(sql);
                DgMoData.DataSource = dt;
            }
            else
            {
              string sqls = "INSERT [dbo].[M_sample_Record] SELECT * FROM [dbo].[M_sample_G]  where [TxtItmnbr]='" + TxtItmnb + "'";
              DataTable dt1 = DB.GetDataTable(sqls);
              string sql = "update  M_sample_G set [Receipttime]='" + Receipttime.Value + "',[Customer]=N'" + Customer.Text + "',[SNID]=N'" + SNID.Text + "',[describe]=N'" + describe.Text + "',[responsibility]=N'" + responsibility.Text + "',[demandQTY]=N'" + demandQTY.Text + "',[statetime]=N'" + statetime.Value + "',[state]=N'" + state.Text + "',[Remarks]=N'" + Remarks.Text + "',[data]=N'" + data.Text + "',[materiel]=N'" + materiel.Text + "',[Jip]=N'" + Jip.Text + "',[mould]=N'" + mould.Text + "',[quality]=N'" + quality.Text + "',time='" + DateTime.Now + "',USID=N'" + VbCommClass.VbCommClass.UseId + "',department=N'" + department.Text.Trim() + "' where [TxtItmnbr]='" + TxtItmnb + "'";
              DataTable dt = DB.GetDataTable(sql);
              Addbutton();
              sql = "SELECT [Receipttime],[Customer],[TxtItmnbr],[SNID],[describe],[responsibility],[demandQTY],[statetime],[state],[Remarks],[data],[materiel],[Jip],[mould],[quality],[time],USID,department FROM M_sample_G where  TxtItmnbr='" + TxtItmnb + "'";
              dt = DB.GetDataTable(sql);
              DgMoData.DataSource = dt;
              TxtItmnbr.Enabled = true;
              ToolSave.Enabled = false;
            }
        }

        private void ToolQuery_Click(object sender, EventArgs e)
        {
            query();
            string sql = "SELECT [Receipttime],[Customer],[TxtItmnbr],[SNID],[describe],[responsibility],[demandQTY],[statetime],[state],[Remarks],[data],[materiel],[Jip],[mould],[quality],[time],USID,department FROM M_sample_G where 1=1";
            if (TxtItmnbr.Text.Trim() != "")
            {
                sql += "and TxtItmnbr=N'" + TxtItmnbr.Text.Trim() + "'";
            }
            if (responsibility.Text.Trim() != "")
            {
                sql += "and responsibility=N'" + responsibility.Text.Trim() + "'";
            }
            DataTable dt = DB.GetDataTable(sql);
            DgMoData.DataSource = dt;
        }

        private void ToolEdit_Click(object sender, EventArgs e)
        {
            update();
            if (DgMoData.CurrentRow == null)
            {
                MessageBox.Show("请选择需要修改的行");
                return;
            };
            int number = DgMoData.CurrentCell.RowIndex;
            Receipttime.Value = DateTime.Parse(DgMoData.Rows[number].Cells["Receipttime1"].Value.ToString());
            Customer.Text = DgMoData.Rows[number].Cells["Customer1"].Value.ToString();
            TxtItmnbr.Text = DgMoData.Rows[number].Cells["TxtItmnbr1"].Value.ToString();
            SNID.Text = DgMoData.Rows[number].Cells["SNID1"].Value.ToString();
            describe.Text = DgMoData.Rows[number].Cells["describe1"].Value.ToString();
            responsibility.Text = DgMoData.Rows[number].Cells["responsibility1"].Value.ToString();
            department.Text = DgMoData.Rows[number].Cells["department1"].Value.ToString();
            demandQTY.Text = DgMoData.Rows[number].Cells["demandQTY1"].Value.ToString();
            statetime.Text = DgMoData.Rows[number].Cells["statetime1"].Value.ToString();
            state.Text = DgMoData.Rows[number].Cells["state1"].Value.ToString();
            Remarks.Text = DgMoData.Rows[number].Cells["Remarks1"].Value.ToString();
            data.Text = DgMoData.Rows[number].Cells["data1"].Value.ToString();
            materiel.Text = DgMoData.Rows[number].Cells["materiel1"].Value.ToString();
            Jip.Text = DgMoData.Rows[number].Cells["Jip1"].Value.ToString();
            mould.Text = DgMoData.Rows[number].Cells["mould1"].Value.ToString();
            quality.Text = DgMoData.Rows[number].Cells["quality1"].Value.ToString();
            judge = "update1";
            TxtItmnbr.Enabled = false;
        }

        private void ToolCancel_Click(object sender, EventArgs e)
        {
            foreach (var item in dataPanel.Controls)
            {
                if (item is TextBox)
                {
                    TextBox textbox = (TextBox)item;
                    textbox.Text = "";
                }
                if (item is ComboBox)
                {
                    ComboBox combox = (ComboBox)item;
                    combox.Text = "";
                }
            }
            ToolQuery.Enabled = true;
            ToolNew.Enabled = true;
            ToolCancel.Enabled = false;
            ToolSave.Enabled = false;
            ToolEdit.Enabled = false;
            ToolAbandon.Enabled = false;
            TxtItmnbr.Enabled = true;
        }

        private void ToolAbandon_Click(object sender, EventArgs e)
        {
            if (DgMoData.CurrentRow == null)
            {
                MessageBox.Show("请选择需要删除的行");
                return;
            };
            int number = DgMoData.CurrentCell.RowIndex;

            if (MessageBox.Show("确定要删除‘" + DgMoData.Rows[number].Cells[2].Value + "’删除后将不可恢复", "删除提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Error).ToString() == "Yes")
            {
                //try
                //{
                    string Sqls = "update M_sample_G set time='" + DateTime.Now + "',USID='" + VbCommClass.VbCommClass.UseId + "' where TxtItmnbr=N'" + DgMoData.Rows[number].Cells[2].Value + "'";
                    DataTable dt1 = DB.GetDataTable(Sqls);
                    Sqls = "INSERT [dbo].[M_sample_Record] SELECT * FROM [dbo].[M_sample_G]  where [TxtItmnbr]=N'" + DgMoData.Rows[number].Cells[2].Value + "'";
                    dt1 = DB.GetDataTable(Sqls);
                    string sql = "delete M_sample_G where TxtItmnbr=N'" + DgMoData.Rows[number].Cells[2].Value + "'";
                    DataTable dt = DB.GetDataTable(sql);
                    MessageBox.Show("删除成功");
                    this.DgMoData.Rows.Remove(this.DgMoData.Rows[number]);
                //}
                //catch (Exception)
                //{

                //    throw;
                //}
            }

        }

        private void responsibility_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue==13)
            {
                string sql = "SELECT department FROM M_sample_G  WHERE responsibility=N'" + responsibility.Text + "'";
                DataTable dt = DB.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    department.Text = dt.Rows[0][0].ToString();
                    department.Focus();
                }
                else
                {
                    department.Text = "";
                    department.Focus();
                }
            }
        }
    }
}
