namespace OBS_Settings_Manager
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cmbProfiles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvBackups = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEncoder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVideo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOpenDetails = new System.Windows.Forms.Button();
            this.btnCreateBackup = new System.Windows.Forms.Button();
            this.btnRestoreBackup = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxNotes = new System.Windows.Forms.RichTextBox();
            this.btnOpenVideo = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnDeleteBackup = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ofdImport = new System.Windows.Forms.OpenFileDialog();
            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.backupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreateBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiOpenDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenVideo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRestoreBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGithubPage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGithubIssue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGithubUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbProfiles
            // 
            this.cmbProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfiles.FormattingEnabled = true;
            this.cmbProfiles.Location = new System.Drawing.Point(12, 46);
            this.cmbProfiles.Name = "cmbProfiles";
            this.cmbProfiles.Size = new System.Drawing.Size(121, 21);
            this.cmbProfiles.TabIndex = 0;
            this.cmbProfiles.SelectedIndexChanged += new System.EventHandler(this.cmbProfiles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose your profile:";
            // 
            // lsvBackups
            // 
            this.lsvBackups.AllowColumnReorder = true;
            this.lsvBackups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvBackups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colDate,
            this.colEncoder,
            this.colVideo});
            this.lsvBackups.FullRowSelect = true;
            this.lsvBackups.HideSelection = false;
            this.lsvBackups.Location = new System.Drawing.Point(12, 73);
            this.lsvBackups.MultiSelect = false;
            this.lsvBackups.Name = "lsvBackups";
            this.lsvBackups.Size = new System.Drawing.Size(560, 287);
            this.lsvBackups.TabIndex = 4;
            this.lsvBackups.UseCompatibleStateImageBehavior = false;
            this.lsvBackups.View = System.Windows.Forms.View.Details;
            this.lsvBackups.SelectedIndexChanged += new System.EventHandler(this.lsvBackups_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 208;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 134;
            // 
            // colEncoder
            // 
            this.colEncoder.Text = "Encoder";
            this.colEncoder.Width = 118;
            // 
            // colVideo
            // 
            this.colVideo.Text = "Video";
            this.colVideo.Width = 78;
            // 
            // btnOpenDetails
            // 
            this.btnOpenDetails.Enabled = false;
            this.btnOpenDetails.Location = new System.Drawing.Point(459, 11);
            this.btnOpenDetails.Name = "btnOpenDetails";
            this.btnOpenDetails.Size = new System.Drawing.Size(95, 23);
            this.btnOpenDetails.TabIndex = 6;
            this.btnOpenDetails.Text = "Open Details";
            this.btnOpenDetails.UseVisualStyleBackColor = true;
            this.btnOpenDetails.Click += new System.EventHandler(this.btnOpenDetails_Click);
            // 
            // btnCreateBackup
            // 
            this.btnCreateBackup.AutoSize = true;
            this.btnCreateBackup.Location = new System.Drawing.Point(139, 45);
            this.btnCreateBackup.Name = "btnCreateBackup";
            this.btnCreateBackup.Size = new System.Drawing.Size(95, 23);
            this.btnCreateBackup.TabIndex = 7;
            this.btnCreateBackup.Text = "Create Backup";
            this.btnCreateBackup.UseVisualStyleBackColor = true;
            this.btnCreateBackup.Click += new System.EventHandler(this.btnCreateBackup_Click);
            // 
            // btnRestoreBackup
            // 
            this.btnRestoreBackup.Enabled = false;
            this.btnRestoreBackup.Location = new System.Drawing.Point(459, 69);
            this.btnRestoreBackup.Name = "btnRestoreBackup";
            this.btnRestoreBackup.Size = new System.Drawing.Size(95, 23);
            this.btnRestoreBackup.TabIndex = 8;
            this.btnRestoreBackup.Text = "Restore Backup";
            this.btnRestoreBackup.UseVisualStyleBackColor = true;
            this.btnRestoreBackup.Click += new System.EventHandler(this.btnRestoreBackup_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxNotes);
            this.groupBox1.Controls.Add(this.btnOpenVideo);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.btnDeleteBackup);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnOpenDetails);
            this.groupBox1.Controls.Add(this.btnRestoreBackup);
            this.groupBox1.Location = new System.Drawing.Point(12, 366);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 129);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Backup info";
            // 
            // tbxNotes
            // 
            this.tbxNotes.BackColor = System.Drawing.SystemColors.Menu;
            this.tbxNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxNotes.Location = new System.Drawing.Point(46, 46);
            this.tbxNotes.Name = "tbxNotes";
            this.tbxNotes.ReadOnly = true;
            this.tbxNotes.Size = new System.Drawing.Size(404, 75);
            this.tbxNotes.TabIndex = 19;
            this.tbxNotes.Text = "";
            // 
            // btnOpenVideo
            // 
            this.btnOpenVideo.Enabled = false;
            this.btnOpenVideo.Location = new System.Drawing.Point(459, 40);
            this.btnOpenVideo.Name = "btnOpenVideo";
            this.btnOpenVideo.Size = new System.Drawing.Size(95, 23);
            this.btnOpenVideo.TabIndex = 16;
            this.btnOpenVideo.Text = "Open Video";
            this.btnOpenVideo.UseVisualStyleBackColor = true;
            this.btnOpenVideo.Click += new System.EventHandler(this.btnOpenVideo_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(43, 31);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(16, 13);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "   ";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(43, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(410, 13);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "   ";
            // 
            // btnDeleteBackup
            // 
            this.btnDeleteBackup.Enabled = false;
            this.btnDeleteBackup.Location = new System.Drawing.Point(459, 98);
            this.btnDeleteBackup.Name = "btnDeleteBackup";
            this.btnDeleteBackup.Size = new System.Drawing.Size(95, 23);
            this.btnDeleteBackup.TabIndex = 12;
            this.btnDeleteBackup.Text = "Delete Backup";
            this.btnDeleteBackup.UseVisualStyleBackColor = true;
            this.btnDeleteBackup.Click += new System.EventHandler(this.btnDeleteBackup_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Notes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Name:";
            // 
            // ofdImport
            // 
            this.ofdImport.Filter = "ZIP files|*.zip|All files|*.*";
            // 
            // sfdExport
            // 
            this.sfdExport.Filter = "ZIP files|*.zip|All files|*.*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.backupsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSettings,
            this.toolStripSeparator3,
            this.tsmiExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(116, 22);
            this.tsmiSettings.Text = "Settings";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(113, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(116, 22);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // backupsToolStripMenuItem
            // 
            this.backupsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreateBackup,
            this.tsmiImport,
            this.tsmiExport,
            this.toolStripSeparator2,
            this.tsmiOpenDetails,
            this.tsmiOpenVideo,
            this.toolStripSeparator4,
            this.tsmiRestoreBackup,
            this.tsmiDeleteBackup});
            this.backupsToolStripMenuItem.Name = "backupsToolStripMenuItem";
            this.backupsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.backupsToolStripMenuItem.Text = "Backups";
            // 
            // tsmiCreateBackup
            // 
            this.tsmiCreateBackup.Name = "tsmiCreateBackup";
            this.tsmiCreateBackup.Size = new System.Drawing.Size(155, 22);
            this.tsmiCreateBackup.Text = "Create Backup";
            this.tsmiCreateBackup.Click += new System.EventHandler(this.btnCreateBackup_Click);
            // 
            // tsmiImport
            // 
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.Size = new System.Drawing.Size(155, 22);
            this.tsmiImport.Text = "Import Backup";
            this.tsmiImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // tsmiExport
            // 
            this.tsmiExport.Enabled = false;
            this.tsmiExport.Name = "tsmiExport";
            this.tsmiExport.Size = new System.Drawing.Size(155, 22);
            this.tsmiExport.Text = "Export Backup";
            this.tsmiExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // tsmiOpenDetails
            // 
            this.tsmiOpenDetails.Enabled = false;
            this.tsmiOpenDetails.Name = "tsmiOpenDetails";
            this.tsmiOpenDetails.Size = new System.Drawing.Size(155, 22);
            this.tsmiOpenDetails.Text = "Open Details";
            this.tsmiOpenDetails.Click += new System.EventHandler(this.btnOpenDetails_Click);
            // 
            // tsmiOpenVideo
            // 
            this.tsmiOpenVideo.Enabled = false;
            this.tsmiOpenVideo.Name = "tsmiOpenVideo";
            this.tsmiOpenVideo.Size = new System.Drawing.Size(155, 22);
            this.tsmiOpenVideo.Text = "Open Video";
            this.tsmiOpenVideo.Click += new System.EventHandler(this.btnOpenVideo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(152, 6);
            // 
            // tsmiRestoreBackup
            // 
            this.tsmiRestoreBackup.Enabled = false;
            this.tsmiRestoreBackup.Name = "tsmiRestoreBackup";
            this.tsmiRestoreBackup.Size = new System.Drawing.Size(155, 22);
            this.tsmiRestoreBackup.Text = "Restore Backup";
            this.tsmiRestoreBackup.Click += new System.EventHandler(this.btnRestoreBackup_Click);
            // 
            // tsmiDeleteBackup
            // 
            this.tsmiDeleteBackup.Enabled = false;
            this.tsmiDeleteBackup.Name = "tsmiDeleteBackup";
            this.tsmiDeleteBackup.Size = new System.Drawing.Size(155, 22);
            this.tsmiDeleteBackup.Text = "Delete Backup";
            this.tsmiDeleteBackup.Click += new System.EventHandler(this.btnDeleteBackup_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGithubPage,
            this.tsmiGithubIssue,
            this.tsmiGithubUpdate,
            this.toolStripSeparator1,
            this.tsmiAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // tsmiGithubPage
            // 
            this.tsmiGithubPage.Name = "tsmiGithubPage";
            this.tsmiGithubPage.Size = new System.Drawing.Size(184, 22);
            this.tsmiGithubPage.Text = "View on GitHub.com";
            this.tsmiGithubPage.Click += new System.EventHandler(this.tsmiGithubPage_Click);
            // 
            // tsmiGithubIssue
            // 
            this.tsmiGithubIssue.Name = "tsmiGithubIssue";
            this.tsmiGithubIssue.Size = new System.Drawing.Size(184, 22);
            this.tsmiGithubIssue.Text = "Report a bug...";
            this.tsmiGithubIssue.Click += new System.EventHandler(this.tsmiGithubIssue_Click);
            // 
            // tsmiGithubUpdate
            // 
            this.tsmiGithubUpdate.Name = "tsmiGithubUpdate";
            this.tsmiGithubUpdate.Size = new System.Drawing.Size(184, 22);
            this.tsmiGithubUpdate.Text = "Check for updates...";
            this.tsmiGithubUpdate.Click += new System.EventHandler(this.tsmiGithubUpdate_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(184, 22);
            this.tsmiAbout.Text = "About";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 507);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCreateBackup);
            this.Controls.Add(this.lsvBackups);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProfiles);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "OBS Settings Manager";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProfiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsvBackups;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.Button btnOpenDetails;
        private System.Windows.Forms.Button btnCreateBackup;
        private System.Windows.Forms.Button btnRestoreBackup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteBackup;
        private System.Windows.Forms.ColumnHeader colEncoder;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnOpenVideo;
        private System.Windows.Forms.ColumnHeader colVideo;
        private System.Windows.Forms.OpenFileDialog ofdImport;
        private System.Windows.Forms.SaveFileDialog sfdExport;
        private System.Windows.Forms.RichTextBox tbxNotes;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateBackup;
        private System.Windows.Forms.ToolStripMenuItem tsmiImport;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiGithubPage;
        private System.Windows.Forms.ToolStripMenuItem tsmiGithubUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenVideo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiRestoreBackup;
        private System.Windows.Forms.ToolStripMenuItem tsmiExport;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteBackup;
        private System.Windows.Forms.ToolStripMenuItem tsmiGithubIssue;
    }
}

