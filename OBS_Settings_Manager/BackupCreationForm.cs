using System;
using System.IO;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;

namespace OBS_Settings_Manager
{
    public partial class BackupCreationForm : Form
    {
        string encoder, backupDest;

        public BackupCreationForm()
        {
            InitializeComponent();
        }

        private void BackupCreationForm_Shown(object sender, EventArgs e)
        {
            FileIniDataParser parser = new FileIniDataParser();
            IniData basicSettings = parser.ReadFile(Path.Combine(MainForm.selectedProfilePath, "basic.ini"));

            encoder = basicSettings["AdvOut"]["Encoder"];
            int index = cmbEncoder.FindString(encoder);
            cmbEncoder.SelectedIndex = index;

            tbxName.Text = Path.GetFileName(MainForm.selectedProfilePath);
        }

        private void btnSaveBackup_Click(object sender, EventArgs e)
        {
            MetaData meta = new MetaData();
            meta.date = DateTime.Now;
            meta.encoder = cmbEncoder.Text;
            meta.name = tbxName.Text;
            meta.notes = tbxNotes.Text;

            backupDest = Path.Combine(MainForm.selectedProfileBackupPath, meta.name);

            if (!Directory.Exists(backupDest))
            {
                Directory.CreateDirectory(backupDest);
                if (meta.SaveData(backupDest))
                {
                    copyDir(MainForm.selectedProfilePath, Path.Combine(backupDest, "profileData"));
                    MessageBox.Show("Profile successfully saved!", "Success", MessageBoxButtons.OK);
                    this.Close();
                }
            }
            else
                MessageBox.Show("A backup by this name already exists.\nPlease choose a different name or delete the existing backup!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void copyDir(string sourcePath, string destPath)
        {
            if (!Directory.Exists(destPath))
            {
                Directory.CreateDirectory(destPath);
            }

            DirectoryInfo dirInfo = new DirectoryInfo(sourcePath);
            FileInfo[] files = dirInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(destPath, file.Name));
            }

            DirectoryInfo[] directories = dirInfo.GetDirectories();
            foreach (DirectoryInfo dir in directories)
            {
                copyDir(Path.Combine(sourcePath, dir.Name), Path.Combine(destPath, dir.Name));
            }
        }
    }
}
