using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

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

            lsvBackups.ListViewItemSorter = new ListViewItemComparer();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            string[] profilePaths, backupProfilePaths;

            if (!Directory.Exists(backupPath))
            {
                DialogResult diagres = MessageBox.Show("Since this seems to be your first run of this program it will now create all needed files. Those files are located under \"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\obs-studio\"\n\n" +
                                                       "None of your initial config files will be altered during this process.\n" +
                                                       "I am NOT responsible if any of your files become corrupt or go missing by using my program. This software is still a WIP project!\n" +
                                                       "If you aren't fine with this please click the Cancel button below."
                                                       , "Welcome", MessageBoxButtons.OKCancel);

                if (diagres == DialogResult.Cancel)
                    Application.Exit();
                else if (diagres == DialogResult.OK)
                {
                    Directory.CreateDirectory(mainPath);
                    Directory.CreateDirectory(backupPath);
                }
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
 
            lsvBackups.Items.Clear();
            lsvBackups.Groups.Clear();
            ListViewItem[] lviList = new ListViewItem[backupPaths.Length];
            int i = 0;
            foreach (string backup in backupPaths)
            {
                MetaData meta = new MetaData().LoadData(Path.Combine(path, Path.GetFileName(backup)));
                ListViewItem lvi = new ListViewItem(meta.name);

                lvi.SubItems.Add(meta.date.ToString());
                lvi.SubItems.Add(meta.encoder);
                if (meta.videopath != "")
                    lvi.SubItems.Add("Yes");
                else
                    lvi.SubItems.Add("No");
                lvi.Tag = backup;

                lviList[i] = lvi;
                i++;
            }
            lsvBackups.Items.AddRange(lviList);
             
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
            BuildBackupList(selectedProfileBackupPath);

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

        private void btnOpenVideo_Click(object sender, EventArgs e)
        {
            MetaData meta = new MetaData().LoadData(selectedBackupPath);
            Process.Start(meta.videopath);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (ofdImport.ShowDialog() == DialogResult.OK)
            {
                ZipArchive archive = ZipFile.OpenRead(ofdImport.FileName);
                ZipArchiveEntry entry = archive.GetEntry("metaINF.dat");
                BinaryFormatter formatter = new BinaryFormatter();
                MetaData data = new MetaData();

                try
                {
                    data = (MetaData)formatter.Deserialize(entry.Open());
                }
                catch (NullReferenceException exc)
                {
                    MessageBox.Show(this, "The selected file is not a backup or is corrupt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                try
                {
                    ZipFile.ExtractToDirectory(ofdImport.FileName, Path.Combine(selectedProfileBackupPath, "backup_" + data.date.ToString("yyyyMMddTHHmmss")));    //TODO  import/export exceptions
                }
                catch (IOException IOexc)
                {
                    DialogResult diagres = MessageBox.Show(this, "It seems that a backup with the same name already exists.\nOverwrite it?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (diagres == DialogResult.Yes)
                    {
                        Directory.Delete(Path.Combine(selectedProfileBackupPath, data.name), true);
                        Directory.CreateDirectory(Path.Combine(selectedProfileBackupPath, data.name));
                        ZipFile.ExtractToDirectory(ofdImport.FileName, Path.Combine(selectedProfileBackupPath, data.name));
                    }
                        

                }
                catch (Exception exc)
                {

                }
                BuildBackupList(selectedProfileBackupPath);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            sfdExport.FileName = Path.GetFileName(selectedBackupPath) + ".zip";
            if (sfdExport.ShowDialog() == DialogResult.OK)
            {
                ZipFile.CreateFromDirectory(selectedBackupPath, sfdExport.FileName);
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }

        private void lsvBackups_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemName = "";
            foreach (ListViewItem lvi in lsvBackups.SelectedItems)
                itemName = lvi.Text;

            if (itemName != "")
            {
                selectedBackupPath = lsvBackups.SelectedItems[0].Tag.ToString();
                Debug.Print("DEBUG: selectedBackupPath: " + selectedBackupPath);
                Debug.Print("DEBUG: lsv index change: " + itemName);

                btnDeleteBackup.Enabled = true;
                btnOpenDetails.Enabled = true;
                btnRestoreBackup.Enabled = true;
                btnExport.Enabled = true;

                MetaData meta = new MetaData().LoadData(selectedBackupPath);
                lblName.Text = meta.name;
                lblDate.Text = meta.date.ToString();
                tbxNotes.Text = meta.notes;

                if (meta.videopath != "" && meta.videopath != null)
                    btnOpenVideo.Enabled = true;
            }
            else
            {
                btnDeleteBackup.Enabled = false;
                btnOpenDetails.Enabled = false;
                btnRestoreBackup.Enabled = false;
                btnOpenVideo.Enabled = false;
                btnExport.Enabled = false;

                lblName.Text = "";
                lblDate.Text = "";
                tbxNotes.Text = "";
            }
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

                btnDeleteBackup.Enabled = false;
                btnOpenDetails.Enabled = false;
                btnRestoreBackup.Enabled = false;
                btnOpenVideo.Enabled = false;
                btnExport.Enabled = false;

                lblName.Text = "";
                lblDate.Text = "";
                tbxNotes.Text = "";
            }
        }
    }
}
