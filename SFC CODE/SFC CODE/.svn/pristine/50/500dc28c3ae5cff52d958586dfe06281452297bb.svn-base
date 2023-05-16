using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MainFrame;
using MainFrame.SysCheckData;


namespace SMTModule
{
    public partial class FrmSteelPart : Form
    {
        public FrmSteelPart()
        {
            InitializeComponent();
        }

        public FrmSteelPart(string str)
        {
            InitializeComponent();
            txtSteelNo.Text = str;//这句必须放在InitializeComponent();的后面，否则会引起“空引用异常”       
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string TreeCount = "";
            StringBuilder SqlStr = new StringBuilder();
            int i;

            SqlStr.Append(" Delete from m_STENCILPart_t WHERE STENCIL_ID='" + this.txtSteelNo.Text.Trim() + "'");
            foreach (DataGridViewRow row in dgvPartList.Rows)
            {
         
                SqlStr.Append(" INSERT into m_STENCILPart_t(STENCIL_ID,PartID,Intime,UserID) ");
                SqlStr.Append(" VALUES('" + txtSteelNo.Text.Trim() + "',  '" + row.Cells[0].Value.ToString() + "',getdate(), '" + VbCommClass.VbCommClass.Factory + "')");

            }

            try
            {
                DbOperateUtils.ExecSQL(SqlStr.ToString());
                this.Close();

            }
            catch (Exception ex)
            {
                SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmSteel", "toolSave_Click", "BasicM");
                return;
            }
            finally
            {
                //Conn = null;
            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //string[] com = new string[dgvPartList.RowCount];
            //for (int i = 0; i < dgvPartList.RowCount; i++)
            //{
            //    com[i] = dgvPartList.Rows[i].Cells[0].Value.ToString();
            //}
            //if (com.Distinct().Count() != com.Length)
            //{
            //    MessageBox.Show("不允许有相同号类！", "提示");
            //    return;
            //}

            if (dgvPartList.Rows.Count >0)
            {
                if (IsRepet())
                {
                    return;
                }
            }
       
            int index = this.dgvPartList.Rows.Add();
            this.dgvPartList.Rows[index].Cells[0].Value = this.txtPartID.Text.Trim();

        }



        private bool DuplicateCheck()
        {
            bool duplicate = false;
            int count = this.dgvPartList.Rows.Count;

            if (count > 1 && dgvPartList.CurrentCell.RowIndex > 0)
            {

                if (this.dgvPartList.CurrentCell.ColumnIndex == 1)
                {
                    for (int i = 0; i < this.dgvPartList.CurrentCell.RowIndex; i++)
                    {
                        if (this.dgvPartList.Rows[i].Cells[1].Value.ToString() == this.dgvPartList.Rows[this.dgvPartList.CurrentCell.RowIndex].Cells[1].Value.ToString())
                        {
                            duplicate = true;
                            MessageBox.Show("此值重复了！！！", "提示");
                            break;
                        }
                    }
                }
            }
            return duplicate;
        }


        private bool IsRepet()
        {
            bool blnIsRepet = false;
            int i;
            string[] com = new string[dgvPartList.RowCount + 1];
            for ( i = 0; i < dgvPartList.RowCount; i++)
            {
                com[i] = dgvPartList.Rows[i].Cells[0].Value.ToString();
            }
            com[i] = this.txtPartID.Text.ToString();

            List<string> listString = new List<string>();
            foreach (string eachString in com) 
            {
                if (!listString.Contains(eachString))
                    listString.Add(eachString);
            }


                //直接 mylist.Distinct();不就有了
            if (listString.ToArray().Length != com.Length)
            {
                blnIsRepet =true;
                MessageBox.Show("不允许有相同号类！", "提示");
                return true ;
            }

            return blnIsRepet;

        }

//        string[] stringArray = { "aaa", "bbb", "aaa", "ccc", "bbb", "ddd", "ccc", "aaa", "bbb", "ddd" };
////List用于存储从数组里取出来的不相同的元素
//List<string> listString =new List<string>();
//foreach (string eachString in stringArray) 
//{
//    if (!listString.Contains(eachString))
//    listString.Add(eachString);
//}
////最后从List里取出各个字符串进行操作         
//foreach (string eachString in listString)
//{
//    Console.Write(eachString); //打印每个字符串
//}
 


        //private void Input(string param1)
        //{
        //    if (dgvPartList.DataSource == null)
        //    {
        //        DataGridViewRow row = dgvPartList.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Cells[0].EditedFormattedValue.Equals(param1));
        //        if (row != null) dgvPartList.Rows.Remove(row);
        //        dgvPartList.Rows.Add(param1);
        //    }
        //    else


        private void FrmSteelPart_Load(object sender, EventArgs e)
        {

            // 
            string o_strSQL;

            o_strSQL = " SELECT PartID FROM m_STENCILPart_t WHERE STENCIL_ID='" + this.txtSteelNo.Text.Trim() + "'";

            DataTable dt = MainFrame.DbOperateUtils.GetDataTable(o_strSQL);

            if (this.dgvPartList.Rows.Count > 0)
            {
                this.dgvPartList.Rows.Clear();
            }

            //  dgvPartList.DataSource = dt;
            foreach (DataRow datarow in dt.Rows)
            {
                dgvPartList.Rows.Add(datarow[0]);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

           // MainFrame.SysCheckData.MessageUtils.ShowConfirm("你确定要")
            int index = this.dgvPartList.CurrentRow.Index;
            dgvPartList.Rows.Remove(dgvPartList.Rows[index]);
    
        }
    }
}
