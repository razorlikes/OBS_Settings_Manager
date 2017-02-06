using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace OBS_Settings_Manager
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /*DialogResult diagres = MessageBox.Show("Since this seems to be your first run of this program it will now create all needed files. Those files are located under " + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\obs-studio.\n\n" +
                                       "None of your initial config files will be altered during this process.\n" +
                                       "I am NOT responsible if any of your files become corrupt or go missing by using my program. This software is still a WIP project!\n" +
                                       "If you aren't fine with this please click the Cancel button below."
                                       , "Welcome", MessageBoxButtons.OKCancel);
            if (diagres == DialogResult.OK)
            {
                Debug.Print("OK");
                Application.Run(new MainForm());
            }
            else
            {
                Application.Exit();
                return;
            }*/

            Application.Run(new MainForm());
        }
    }
}
