using System;
using System.Windows.Forms;

namespace CPU_Simulator
{
    public class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ProgramForm());
        }
    }
}