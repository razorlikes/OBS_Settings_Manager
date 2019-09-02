using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using IniParser;
using IniParser.Model;

namespace OBS_Settings_Manager
{
    public partial class MainForm : Form
    {
        public static string selectedProfilePath, selectedProfileBackupPath, selectedBackupPath;

        string backupPath;
        IniData iniData;
        FileIniDataParser iniParser = new FileIniDataParser();

        public MainForm()
        {
            InitializeComponent();

            lsvBackups.ListViewItemSorter = new ListViewItemComparer();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            string[] profilePaths, backupProfilePaths;

            cmbProfiles.Items.Clear(); //clear items when settings were changed

            if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "settings.ini")))
            {
                DialogResult diagres = MessageBox.Show("Since this seems to be your first run of this program you will have to select a backup folder in the settings. \n\n" +
                                                       "I am NOT responsible if any of your files become corrupt or go missing by using my program. This software is still a WIP project!"
                                                       , "Welcome", MessageBoxButtons.OKCancel);

                if (diagres == DialogResult.OK)
                    new SettingsForm().ShowDialog();
                else
                {
                    Application.Exit();
                    return;
                }
            }

            iniData = iniParser.ReadFile(Path.Combine(Environment.CurrentDirectory, "settings.ini"));
            backupPath = iniData["General"]["backupFolder"];
            Directory.CreateDirectory(backupPath);

            try
            {
                profilePaths = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\obs-studio\\basic\\profiles");
            }
            catch (Exception exc)
            {
                MessageBox.Show("OBS profile directory couldn't be opened! Make sure you have OBS Studio installed!\n\n" + exc.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                profilePaths = new string[0];  //workaround
            }

            try
            {
                backupProfilePaths = Directory.GetDirectories(backupPath);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Backup directory couldn't be opened!\n\n" + exc.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("You don't seem to have any profiles created in OBS.\nPlease create a profile in OBS and try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cmbProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProfile = cmbProfiles.SelectedItem.ToString();
            selectedProfilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "obs-studio", "basic", "profiles", selectedProfile);
            selectedProfileBackupPath = Path.Combine(backupPath, selectedProfile);

            if (!Directory.Exists(selectedProfilePath))
                btnCreateBackup.Enabled = false;
            else if (Directory.Exists(selectedProfilePath))
                btnCreateBackup.Enabled = true;

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
                catch (NullReferenceException)
                {
                    MessageBox.Show(this, "The selected file is not a backup or is corrupt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    ZipFile.ExtractToDirectory(ofdImport.FileName, Path.Combine(selectedProfileBackupPath, "backup_" + data.date.ToString("yyyyMMddTHHmmss")));    //TODO  import/export exceptions
                }
                catch (IOException)
                {
                    DialogResult diagres = MessageBox.Show(this, "It seems that a backup with the same name already exists.\nOverwrite it?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (diagres == DialogResult.Yes)
                    {
                        Directory.Delete(Path.Combine(selectedProfileBackupPath, data.name), true);
                        Directory.CreateDirectory(Path.Combine(selectedProfileBackupPath, data.name));
                        ZipFile.ExtractToDirectory(ofdImport.FileName, Path.Combine(selectedProfileBackupPath, data.name));
                    }
                }
                catch (Exception)
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
                try
                {
                    ZipFile.CreateFromDirectory(selectedBackupPath, sfdExport.FileName);
                }
                catch (IOException)
                {
                    File.Delete(sfdExport.FileName);
                    ZipFile.CreateFromDirectory(selectedBackupPath, sfdExport.FileName);
                }
            }
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

                btnOpenDetails.Enabled = true;
                btnDeleteBackup.Enabled = true;
                btnRestoreBackup.Enabled = true;
                tsmiOpenDetails.Enabled = true;
                tsmiDeleteBackup.Enabled = true;
                tsmiRestoreBackup.Enabled = true;
                tsmiExport.Enabled = true;

                MetaData meta = new MetaData().LoadData(selectedBackupPath);
                lblName.Text = meta.name;
                lblDate.Text = meta.date.ToString();
                tbxNotes.Text = meta.notes;

                if (meta.videopath != "" && meta.videopath != null)
                {
                    btnOpenVideo.Enabled = true;
                    tsmiOpenVideo.Enabled = true;
                }
            }
            else
            {
                btnOpenDetails.Enabled = false;
                btnOpenVideo.Enabled = false;
                btnDeleteBackup.Enabled = false;
                btnRestoreBackup.Enabled = false;
                tsmiOpenDetails.Enabled = false;
                tsmiOpenVideo.Enabled = false;
                tsmiDeleteBackup.Enabled = false;
                tsmiRestoreBackup.Enabled = false;
                tsmiExport.Enabled = false;

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
                Helper.copyDir(Path.Combine(selectedBackupPath, "profileData"), selectedProfilePath);
            }
        }

        private void btnDeleteBackup_Click(object sender, EventArgs e)
        {
            DialogResult diagres = MessageBox.Show("The selected backup will be deleted and its data will be permanently lost!\nYou have been warned.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (diagres == DialogResult.OK)
            {
                Directory.Delete(selectedBackupPath, true);
                BuildBackupList(selectedProfileBackupPath);

                btnOpenDetails.Enabled = false;
                btnOpenVideo.Enabled = false;
                btnDeleteBackup.Enabled = false;
                btnRestoreBackup.Enabled = false;
                tsmiOpenDetails.Enabled = false;
                tsmiOpenVideo.Enabled = false;
                tsmiDeleteBackup.Enabled = false;
                tsmiRestoreBackup.Enabled = false;
                tsmiExport.Enabled = false;

                lblName.Text = "";
                lblDate.Text = "";
                tbxNotes.Text = "";
            }
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();

            MainForm_Shown(sender, e);
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiGithubIssue_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/razorlikes/OBS_Settings_Manager/issues/new");
        }

        private void tsmiGithubPage_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/razorlikes/OBS_Settings_Manager");
        }

        private void tsmiGithubUpdate_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/razorlikes/OBS_Settings_Manager/releases/latest");
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().Show();
        }
    }
}
