using System.Windows.Forms;

namespace CPU_Simulator
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Close();
        }
    }
}