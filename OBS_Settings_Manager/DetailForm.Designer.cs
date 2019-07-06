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
            this.lsvDetails = new System.Windows.Forms.ListView();
            this.headerSetting = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rbtnBasic = new System.Windows.Forms.RadioButton();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbtnRecording
            // 
            this.rbtnRecording.AutoSize = true;
            this.rbtnRecording.Location = new System.Drawing.Point(90, 12);
            this.rbtnRecording.Name = "rbtnRecording";
            this.rbtnRecording.Size = new System.Drawing.Size(74, 17);
            this.rbtnRecording.TabIndex = 10;
            this.rbtnRecording.Text = "Recording";
            this.rbtnRecording.UseVisualStyleBackColor = true;
            this.rbtnRecording.CheckedChanged += new System.EventHandler(this.rbtnRecording_CheckedChanged);
            // 
            // rbtnStreaming
            // 
            this.rbtnStreaming.AutoSize = true;
            this.rbtnStreaming.Checked = true;
            this.rbtnStreaming.Location = new System.Drawing.Point(12, 12);
            this.rbtnStreaming.Name = "rbtnStreaming";
            this.rbtnStreaming.Size = new System.Drawing.Size(72, 17);
            this.rbtnStreaming.TabIndex = 9;
            this.rbtnStreaming.TabStop = true;
            this.rbtnStreaming.Text = "Streaming";
            this.rbtnStreaming.UseVisualStyleBackColor = true;
            this.rbtnStreaming.CheckedChanged += new System.EventHandler(this.rbtnStreaming_CheckedChanged);
            // 
            // lsvDetails
            // 
            this.lsvDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerSetting,
            this.headerValue});
            this.lsvDetails.FullRowSelect = true;
            this.lsvDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvDetails.HideSelection = false;
            this.lsvDetails.Location = new System.Drawing.Point(12, 38);
            this.lsvDetails.Name = "lsvDetails";
            this.lsvDetails.Size = new System.Drawing.Size(433, 342);
            this.lsvDetails.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvDetails.TabIndex = 8;
            this.lsvDetails.UseCompatibleStateImageBehavior = false;
            this.lsvDetails.View = System.Windows.Forms.View.Details;
            // 
            // headerSetting
            // 
            this.headerSetting.Text = "Setting";
            this.headerSetting.Width = 205;
            // 
            // headerValue
            // 
            this.headerValue.Text = "Value";
            this.headerValue.Width = 205;
            // 
            // rbtnBasic
            // 
            this.rbtnBasic.AutoSize = true;
            this.rbtnBasic.Location = new System.Drawing.Point(170, 12);
            this.rbtnBasic.Name = "rbtnBasic";
            this.rbtnBasic.Size = new System.Drawing.Size(90, 17);
            this.rbtnBasic.TabIndex = 11;
            this.rbtnBasic.TabStop = true;
            this.rbtnBasic.Text = "Basic settings";
            this.rbtnBasic.UseVisualStyleBackColor = true;
            this.rbtnBasic.CheckedChanged += new System.EventHandler(this.rbtnBasic_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(370, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // DetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 392);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.rbtnBasic);
            this.Controls.Add(this.rbtnRecording);
            this.Controls.Add(this.rbtnStreaming);
            this.Controls.Add(this.lsvDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DetailForm";
            this.Text = "Detailed Profile View";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnRecording;
        private System.Windows.Forms.RadioButton rbtnStreaming;
        private System.Windows.Forms.ListView lsvDetails;
        private System.Windows.Forms.ColumnHeader headerSetting;
        private System.Windows.Forms.ColumnHeader headerValue;
        private System.Windows.Forms.RadioButton rbtnBasic;
        private System.Windows.Forms.Button btnRefresh;
    }
}