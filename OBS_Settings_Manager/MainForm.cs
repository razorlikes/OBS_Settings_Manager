using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace OBS_Settings_Manager
{
    public partial class MainForm : Form
    {
        public static string selectedProfilePath, selectedProfileBackupPath, selectedBackupPath;

        string backupPath, mainPath;

        public MainForm()
        {
            InitializeComponent();
            
            backupPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "obs-studio", "SettingsManager", "backups");
            mainPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "obs-studio", "SettingsManager");
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            string[] profilePaths, backupProfilePaths;

            if (!Directory.Exists(backupPath))
            {
                DialogResult diagres = MessageBox.Show("Since this seems to be your first run of this program it will now create all needed files. Those files are located under " + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\obs-studio.\n\n" +
                                                       "None of your initial config files will be altered during this process.\n" +
                                                       "I am NOT responsible if any of your files become corrupt or go missing by using my program. This software is still a WIP project!\n" +
                                                       "If you aren't fine with this please click the Cancel button below."
                                                       , "Welcome", MessageBoxButtons.OKCancel);
                if (diagres == DialogResult.Cancel)
                    Application.Exit();

                Directory.CreateDirectory(mainPath);
                Directory.CreateDirectory(backupPath);
            }

            try
            {
                profilePaths = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\obs-studio\\basic\\profiles");
            }
            catch (Exception exc)
            {
                MessageBox.Show("OBS profile directory couldn't be opened!\n\nError: " + exc.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
                profilePaths = new string[0];  //workaround
            }

            try
            {
                backupProfilePaths = Directory.GetDirectories(backupPath);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Backup directory couldn't be opened!\n\nError: " + exc.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
                backupProfilePaths = new string[0];  //workaround
            }

            foreach (string profile in profilePaths)
            {
                cmbProfiles.Items.Add(Path.GetFileName(profile));
                Directory.CreateDirectory(Path.Combine(backupPath, Path.GetFileName(profile)));
            }

            foreach (string backup in backupProfilePaths)
            {
                if (!cmbProfiles.Items.Contains(Path.GetFileName(backup)))
                    cmbProfiles.Items.Add(Path.GetFileName(backup));
            }

            try
            {
                cmbProfiles.SelectedIndex = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("You don't seem to have any profiles created in OBS.\nPlease create a profile in OBS and try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }

            BuildBackupList(selectedProfileBackupPath);
        }

        void BuildBackupList(string path)
        {
            string[] backupPaths = Directory.GetDirectories(path);
            string[] backupNames = new string[backupPaths.Length];

            int i = 0;
            foreach (string backup in backupPaths)
            {
                backupNames[i] = Path.GetFileName(backup);
                i++;
            }

            if (backupNames == null)
                return;

            lsvBackups.Items.Clear();
            lsvBackups.Groups.Clear();
            foreach (string name in backupNames)
            {
                MetaData meta = new MetaData().LoadData(Path.Combine(path, name));
                ListViewItem lvi = lsvBackups.Items.Add(meta.name);
                lvi.SubItems.Add(meta.date.ToString());
                lvi.SubItems.Add(meta.encoder);
                lvi.Tag = meta.date.ToFileTime();

            }
            lsvBackups.Sort();
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
                file.CopyTo(Path.Combine(destPath, file.Name), true);
            }

            DirectoryInfo[] directories = dirInfo.GetDirectories();
            foreach (DirectoryInfo dir in directories)
            {
                copyDir(Path.Combine(sourcePath, dir.Name), Path.Combine(destPath, dir.Name));
            }
        }

        private void cmbProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProfile = cmbProfiles.SelectedItem.ToString();
            selectedProfilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "obs-studio", "basic", "profiles", selectedProfile);
            selectedProfileBackupPath = Path.Combine(backupPath, selectedProfile);

            Debug.Print("DEBUG: Current profile: " + selectedProfile);
            Debug.Print("DEBUG: selectedProfilePath: " + selectedProfilePath);
            Debug.Print("DEBUG: selectedProfileBackupPath: " + selectedProfileBackupPath);
        }

        private void btnCreateBackup_Click(object sender, EventArgs e)
        {
            BackupCreationForm backupForm = new BackupCreationForm();
            backupForm.FormClosed += new FormClosedEventHandler(backupForm_FormClosed);
            backupForm.Show();
        }

        private void backupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BuildBackupList(selectedProfileBackupPath);
        }

        private void btnOpenDetails_Click(object sender, EventArgs e)
        {
            new DetailForm().Show();
        }

        private void lsvBackups_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemName = "";
            foreach (ListViewItem lvi in lsvBackups.SelectedItems)
                itemName = lvi.Text;

            selectedBackupPath = Path.Combine(selectedProfileBackupPath, itemName);
            Debug.Print("DEBUG: selectedBackupPath: " + selectedBackupPath);

            if (itemName != "")
            {
                btnDeleteBackup.Enabled = true;
                btnOpenDetails.Enabled = true;
                btnRestoreBackup.Enabled = true;

                MetaData meta = new MetaData().LoadData(selectedBackupPath);
                lblName.Text = meta.name;
                lblDate.Text = meta.date.ToString();
                lblNotes.Text = meta.notes;
            }
            else
            {
                btnDeleteBackup.Enabled = false;
                btnOpenDetails.Enabled = false;
                btnRestoreBackup.Enabled = false;

                lblName.Text = "";
                lblDate.Text = "";
                lblNotes.Text = "";
            }

            Debug.Print("DEBUG: lsv index change: " + itemName);
        }

        private void btnRestoreBackup_Click(object sender, EventArgs e)
        {
            DialogResult diagres = MessageBox.Show("Your current settings will be overwritten by the backup!\nYou have been warned.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (diagres == DialogResult.OK)
            {
                copyDir(Path.Combine(selectedBackupPath, "profileData"), selectedProfilePath);
            }
        }

        private void btnDeleteBackup_Click(object sender, EventArgs e)
        {
            DialogResult diagres = MessageBox.Show("The selected backup will be deleted and its data will be permanently lost!\nYou have been warned.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (diagres == DialogResult.OK)
            {
                Directory.Delete(selectedBackupPath, true);
                BuildBackupList(selectedProfileBackupPath);
            }
        }
    }
}
