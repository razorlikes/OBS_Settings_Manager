namespace OBS_Settings_Manager
{
    partial class DetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailForm));
            this.rbtnRecording = new System.Windows.Forms.RadioButton();
            this.rbtnStreaming = new System.Windows.Forms.RadioButton();
            this.rbtnBasic = new System.Windows.Forms.RadioButton();
            this.lsvDetails = new System.Windows.Forms.ListView();
            this.headerSetting = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerBackupValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerCurrentValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ckbCompare = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // rbtnRecording
            // 
            this.rbtnRecording.AutoSize = true;
            this.rbtnRecording.Location = new System.Drawing.Point(186, 9);
            this.rbtnRecording.Name = "rbtnRecording";
            this.rbtnRecording.Size = new System.Drawing.Size(74, 17);
            this.rbtnRecording.TabIndex = 10;
            this.rbtnRecording.Text = "Recording";
            this.rbtnRecording.UseVisualStyleBackColor = true;
            this.rbtnRecording.CheckedChanged += new System.EventHandler(this.rbtnCheckedChanged);
            // 
            // rbtnStreaming
            // 
            this.rbtnStreaming.AutoSize = true;
            this.rbtnStreaming.Location = new System.Drawing.Point(108, 9);
            this.rbtnStreaming.Name = "rbtnStreaming";
            this.rbtnStreaming.Size = new System.Drawing.Size(72, 17);
            this.rbtnStreaming.TabIndex = 9;
            this.rbtnStreaming.Text = "Streaming";
            this.rbtnStreaming.UseVisualStyleBackColor = true;
            this.rbtnStreaming.CheckedChanged += new System.EventHandler(this.rbtnCheckedChanged);
            // 
            // rbtnBasic
            // 
            this.rbtnBasic.AutoSize = true;
            this.rbtnBasic.Checked = true;
            this.rbtnBasic.Location = new System.Drawing.Point(12, 9);
            this.rbtnBasic.Name = "rbtnBasic";
            this.rbtnBasic.Size = new System.Drawing.Size(92, 17);
            this.rbtnBasic.TabIndex = 11;
            this.rbtnBasic.TabStop = true;
            this.rbtnBasic.Text = "Basic Settings";
            this.rbtnBasic.UseVisualStyleBackColor = true;
            this.rbtnBasic.CheckedChanged += new System.EventHandler(this.rbtnCheckedChanged);
            // 
            // lsvDetails
            // 
            this.lsvDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerSetting,
            this.headerBackupValue,
            this.headerCurrentValue});
            this.lsvDetails.FullRowSelect = true;
            this.lsvDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvDetails.HideSelection = false;
            this.lsvDetails.Location = new System.Drawing.Point(12, 38);
            this.lsvDetails.Name = "lsvDetails";
            this.lsvDetails.Size = new System.Drawing.Size(500, 342);
            this.lsvDetails.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvDetails.TabIndex = 8;
            this.lsvDetails.UseCompatibleStateImageBehavior = false;
            this.lsvDetails.View = System.Windows.Forms.View.Details;
            // 
            // headerSetting
            // 
            this.headerSetting.Text = "Setting";
            this.headerSetting.Width = 155;
            // 
            // headerBackupValue
            // 
            this.headerBackupValue.Text = "Backup Value";
            this.headerBackupValue.Width = 160;
            // 
            // headerCurrentValue
            // 
            this.headerCurrentValue.Text = "Current Value";
            this.headerCurrentValue.Width = 160;
            // 
            // ckbCompare
            // 
            this.ckbCompare.AutoSize = true;
            this.ckbCompare.Checked = true;
            this.ckbCompare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbCompare.Location = new System.Drawing.Point(395, 10);
            this.ckbCompare.Name = "ckbCompare";
            this.ckbCompare.Size = new System.Drawing.Size(117, 17);
            this.ckbCompare.TabIndex = 13;
            this.ckbCompare.Text = "Enable Comparison";
            this.ckbCompare.UseVisualStyleBackColor = true;
            this.ckbCompare.CheckedChanged += new System.EventHandler(this.ckbCompare_CheckedChanged);
            // 
            // DetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 392);
            this.Controls.Add(this.ckbCompare);
            this.Controls.Add(this.rbtnBasic);
            this.Controls.Add(this.rbtnRecording);
            this.Controls.Add(this.rbtnStreaming);
            this.Controls.Add(this.lsvDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DetailForm";
            this.Text = "Detailed Profile View";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnRecording;
        private System.Windows.Forms.RadioButton rbtnStreaming;
        private System.Windows.Forms.RadioButton rbtnBasic;
        private System.Windows.Forms.ListView lsvDetails;
        private System.Windows.Forms.ColumnHeader headerSetting;
        private System.Windows.Forms.ColumnHeader headerBackupValue;
        private System.Windows.Forms.ColumnHeader headerCurrentValue;
        private System.Windows.Forms.CheckBox ckbCompare;
    }
}