using System.Diagnostics;
using System.Windows.Forms;

namespace OBS_Settings_Manager
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void lnk1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/rickyah/ini-parser/blob/development/LICENSE");
        }

        private void lnk2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md");
        }
    }
}
