﻿using System;
using System.IO;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;

namespace OBS_Settings_Manager
{
    public partial class BackupCreationForm : Form
    {
        public BackupCreationForm()
        {
            InitializeComponent();
        }

        private void BackupCreationForm_Shown(object sender, EventArgs e)
        {
            tbxName.Text = Path.GetFileName(MainForm.selectedProfilePath);
        }

        private void btnSaveBackup_Click(object sender, EventArgs e)
        {
            if (tbxName.TextLength == 0)
            {
                MessageBox.Show("Please enter a backup name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MetaData meta = new MetaData();
            meta.date = DateTime.Now;
            meta.name = tbxName.Text;
            meta.notes = tbxNotes.Text;
            meta.videopath = tbxVideoPath.Text;

            FileIniDataParser parser = new FileIniDataParser();
            IniData basicSettings = parser.ReadFile(Path.Combine(MainForm.selectedProfilePath, "basic.ini"));
            if (basicSettings["AdvOut"]["Encoder"] != String.Empty)
                meta.encoder = basicSettings["AdvOut"]["Encoder"];
            else
                meta.encoder = basicSettings["SimpleOutput"]["StreamEncoder"];

            string backupDest = Path.Combine(MainForm.selectedProfileBackupPath, "backup_" + DateTime.Now.ToString("yyyyMMddTHHmmss"));

            if (!Directory.Exists(backupDest))
            {
                Directory.CreateDirectory(backupDest);
                if (meta.SaveData(backupDest))
                {
                    Helper.copyDir(MainForm.selectedProfilePath, Path.Combine(backupDest, "profileData"));
                    MessageBox.Show("Profile successfully saved!", "Success", MessageBoxButtons.OK);
                    this.Close();
                }
            }
            else
                MessageBox.Show("A backup by this name already exists.\nPlease choose a different name or delete the existing backup!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddVideo_Click(object sender, EventArgs e)
        {
            ofd_Video.ShowDialog();
        }

        private void ofd_Video_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tbxVideoPath.Text = ofd_Video.FileName;
        }
    }
}
