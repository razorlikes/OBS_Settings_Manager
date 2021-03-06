﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using System.IO;

namespace OBS_Settings_Manager
{
    public partial class SettingsForm : Form
    {
        IniData iniData;
        bool firstRun = false;

        public SettingsForm()
        {
            InitializeComponent();

            if (File.Exists(Path.Combine(Environment.CurrentDirectory, "settings.ini")))
            {
                FileIniDataParser parser = new FileIniDataParser();
                iniData = parser.ReadFile(Path.Combine(Environment.CurrentDirectory, "settings.ini"));

                tbxBackupFolder.Text = iniData["General"]["backupFolder"];
            }
            else
            {
                iniData = new IniData();

                tbxBackupFolder.Text = Path.Combine(Environment.CurrentDirectory, "backups");

                iniData["General"]["backupFolder"] = tbxBackupFolder.Text;

                FileIniDataParser parser = new FileIniDataParser();
                parser.WriteFile(Path.Combine(Environment.CurrentDirectory, "settings.ini"), iniData);

                btnCancel.Enabled = false;
                firstRun = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxBackupFolder.Text != iniData["General"]["backupFolder"] && !firstRun)
            {
                DialogResult diagres = MessageBox.Show("You changed the backup folder.\nDo you want to copy existing backups to the new folder?", "Copy Folder", MessageBoxButtons.YesNo);
                if (diagres == DialogResult.Yes && Directory.Exists(iniData["General"]["backupFolder"]))
                    Helper.copyDir(iniData["General"]["backupFolder"], tbxBackupFolder.Text);
            }

            iniData["General"]["backupFolder"] = tbxBackupFolder.Text;

            FileIniDataParser parser = new FileIniDataParser();
            parser.WriteFile(Path.Combine(Environment.CurrentDirectory, "settings.ini"), iniData);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChooseBackupFolder_Click(object sender, EventArgs e)
        {
            fbdBackupFolder.ShowDialog();
            tbxBackupFolder.Text = fbdBackupFolder.SelectedPath;
        }
    }
}
