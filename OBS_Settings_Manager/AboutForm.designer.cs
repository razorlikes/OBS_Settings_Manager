namespace OBS_Settings_Manager
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lnk1 = new System.Windows.Forms.LinkLabel();
            this.lnk2 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 78);
            this.label1.TabIndex = 0;
            this.label1.Text = "OBS Settings Manager v1.2.0\r\n \r\nCopyright (c) 2019 by Jeremy \"razorlikes\" Nieth.\r" +
    "\nReleased under the MIT License.\r\n\r\nOpen source licenses:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "ini-parser by Ricardo Hernández:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Json.NET by James Newton-King:";
            // 
            // lnk1
            // 
            this.lnk1.AutoSize = true;
            this.lnk1.Location = new System.Drawing.Point(210, 87);
            this.lnk1.Name = "lnk1";
            this.lnk1.Size = new System.Drawing.Size(66, 13);
            this.lnk1.TabIndex = 5;
            this.lnk1.TabStop = true;
            this.lnk1.Text = "MIT License";
            this.lnk1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk1_LinkClicked);
            // 
            // lnk2
            // 
            this.lnk2.AutoSize = true;
            this.lnk2.Location = new System.Drawing.Point(217, 100);
            this.lnk2.Name = "lnk2";
            this.lnk2.Size = new System.Drawing.Size(66, 13);
            this.lnk2.TabIndex = 6;
            this.lnk2.TabStop = true;
            this.lnk2.Text = "MIT License";
            this.lnk2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk2_LinkClicked);
            // 
            // label2
            // 
            this.label2.Image = global::OBS_Settings_Manager.Properties.Resources.OSM;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 42);
            this.label2.TabIndex = 1;
            this.label2.Text = "     ";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 124);
            this.Controls.Add(this.lnk2);
            this.Controls.Add(this.lnk1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel lnk1;
        private System.Windows.Forms.LinkLabel lnk2;
    }
}