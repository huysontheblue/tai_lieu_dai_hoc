using MainFrame;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace RouteManagement
{
    class Help
    {
        public static void a(string name, int suoying)
        {
            string sql = "select FilePath from m_HelpSop where Name=N'" + name + "'";
            DataTable h = DbOperateUtils.GetDataTable(sql); //Sql.chaxun(sql);
            if (h.Rows.Count == 0)
            {

            }
            else
            {
                if (suoying == 1000)
                {
                    for (int ii = 0; ii < h.Rows.Count; ii++)
                    {
                        ProcessStartInfo psiv = new ProcessStartInfo(h.Rows[ii][0].ToString());
                        Process pv = new Process();
                        pv.StartInfo = psiv;
                        pv.Start();
                    }
                }
                else
                {
                    ProcessStartInfo psi = new ProcessStartInfo(h.Rows[0][0].ToString());
                    Process p = new Process();
                    p.StartInfo = psi;
                    p.Start();
                }
            }
        }
    }
}
