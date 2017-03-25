namespace OBS_Settings_Manager
{
    partial class BackupCreationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tbxNotes = new System.Windows.Forms.TextBox();
            this.btnSaveBackup = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEncoder = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddVideo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxVideoPath = new System.Windows.Forms.TextBox();
            this.ofd_Video = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Notes";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(69, 12);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(333, 20);
            this.tbxName.TabIndex = 3;
            // 
            // tbxNotes
            // 
            this.tbxNotes.Location = new System.Drawing.Point(69, 65);
            this.tbxNotes.Multiline = true;
            this.tbxNotes.Name = "tbxNotes";
            this.tbxNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxNotes.Size = new System.Drawing.Size(333, 73);
            this.tbxNotes.TabIndex = 4;
            // 
            // btnSaveBackup
            // 
            this.btnSaveBackup.Location = new System.Drawing.Point(234, 179);
            this.btnSaveBackup.Name = "btnSaveBackup";
            this.btnSaveBackup.Size = new System.Drawing.Size(81, 23);
            this.btnSaveBackup.TabIndex = 5;
            this.btnSaveBackup.Text = "Save backup";
            this.btnSaveBackup.UseVisualStyleBackColor = true;
            this.btnSaveBackup.Click += new System.EventHandler(this.btnSaveBackup_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Encoder";
            // 
            // cmbEncoder
            // 
            this.cmbEncoder.FormattingEnabled = true;
            this.cmbEncoder.Items.AddRange(new object[] {
            "obs_x264",
            "amd_amf_h264",
            "ffmpeg_nvenc",
            "obs_qsv11"});
            this.cmbEncoder.Location = new System.Drawing.Point(69, 38);
            this.cmbEncoder.Name = "cmbEncoder";
            this.cmbEncoder.Size = new System.Drawing.Size(333, 21);
            this.cmbEncoder.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(321, 179);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddVideo
            // 
            this.btnAddVideo.Location = new System.Drawing.Point(321, 144);
            this.btnAddVideo.Name = "btnAddVideo";
            this.btnAddVideo.Size = new System.Drawing.Size(81, 22);
            this.btnAddVideo.TabIndex = 9;
            this.btnAddVideo.Text = "Add video";
            this.btnAddVideo.UseVisualStyleBackColor = true;
            this.btnAddVideo.Click += new System.EventHandler(this.btnAddVideo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Video path";
            // 
            // tbxVideoPath
            // 
            this.tbxVideoPath.Location = new System.Drawing.Point(69, 145);
            this.tbxVideoPath.Name = "tbxVideoPath";
            this.tbxVideoPath.Size = new System.Drawing.Size(246, 20);
            this.tbxVideoPath.TabIndex = 11;
            // 
            // ofd_Video
            // 
            this.ofd_Video.Filter = "Video files|*.avi;*.mp4;*.mkv;*.flv;*.mov;*.ts;*.m3u8|All files|*.*";
            this.ofd_Video.FileOk += new System.ComponentModel.CancelEventHandler(this.ofd_Video_FileOk);
            // 
            // BackupCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 213);
            this.Controls.Add(this.tbxVideoPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddVideo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbEncoder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSaveBackup);
            this.Controls.Add(this.tbxNotes);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BackupCreationForm";
            this.Text = "Create New Backup";
            this.Shown += new System.EventHandler(this.BackupCreationForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.TextBox tbxNotes;
        private System.Windows.Forms.Button btnSaveBackup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEncoder;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddVideo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxVideoPath;
        private System.Windows.Forms.OpenFileDialog ofd_Video;
    }
}