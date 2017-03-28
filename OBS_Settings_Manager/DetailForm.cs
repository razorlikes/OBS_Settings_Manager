using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using Newtonsoft.Json;

namespace OBS_Settings_Manager
{
    public partial class DetailForm : Form
    {
        Hashtable streamSettings = new Hashtable();
        Hashtable recordSettings = new Hashtable();
        IniData basicSettings = new IniData();

        public DetailForm()
        {
            InitializeComponent();

            readSettings(Path.Combine(MainForm.selectedBackupPath, "profileData"));
        }

        void readSettings(string path)
        {
            StreamReader readerS = new StreamReader(Path.Combine(path, "streamEncoder.json"));
            string settingsJsonS = readerS.ReadToEnd();
            readerS.Close();
            streamSettings = JsonConvert.DeserializeObject<Hashtable>(settingsJsonS);

            try
            {
                StreamReader readerR = new StreamReader(Path.Combine(path, "recordEncoder.json"));
                string settingsJsonR = readerR.ReadToEnd();
                readerR.Close();
                recordSettings = JsonConvert.DeserializeObject<Hashtable>(settingsJsonR);
            }
            catch (FileNotFoundException)
            {
                rbtnRecording.Enabled = false;
            }

            FileIniDataParser parser = new FileIniDataParser();
            basicSettings = parser.ReadFile(Path.Combine(path, "basic.ini"));

            if (rbtnStreaming.Checked)
                buildList(streamSettings);

            else if (rbtnRecording.Checked)
                buildList(recordSettings);

            else if (rbtnBasic.Checked)
                buildIniList(basicSettings);
        }

        void buildList(Hashtable settings)
        {
            lsvDetails.Items.Clear();
            lsvDetails.Groups.Clear();
            ListViewGroup def = lsvDetails.Groups.Add("groupDefault", "Default x264 settings");
            ListViewGroup amf = lsvDetails.Groups.Add("groupAMF", "AMF settings");
            foreach (DictionaryEntry val in settings)
            {
                ListViewItem lvi = lsvDetails.Items.Add(val.Key.ToString());
                if (val.Value != null)
                    lvi.SubItems.Add(val.Value.ToString());

                if (lvi.Text.Contains("AMF"))
                    lvi.Group = amf;
                else
                    lvi.Group = def;
            }
        }

        void buildIniList(IniData data)
        {
            lsvDetails.Items.Clear();
            lsvDetails.Groups.Clear();
            foreach (SectionData section in data.Sections)
            {
                ListViewGroup grp = lsvDetails.Groups.Add("group" + section.SectionName, section.SectionName);

                foreach (KeyData key in section.Keys)
                {
                    ListViewItem lvi = lsvDetails.Items.Add(key.KeyName);
                    lvi.SubItems.Add(key.Value.ToString());
                    lvi.Group = grp;
                }
            }
        }

        private void rbtnStreaming_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnStreaming.Checked)
                buildList(streamSettings);

            else if (rbtnRecording.Checked)
                buildList(recordSettings);

            else if (rbtnBasic.Checked)
                buildIniList(basicSettings);
        }

        private void rbtnRecording_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnStreaming.Checked)
                buildList(streamSettings);

            else if (rbtnRecording.Checked)
                buildList(recordSettings);

            else if (rbtnBasic.Checked)
                buildIniList(basicSettings);
        }

        private void rbtnBasic_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnStreaming.Checked)
                buildList(streamSettings);

            else if (rbtnRecording.Checked)
                buildList(recordSettings);

            else if (rbtnBasic.Checked)
                buildIniList(basicSettings);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            readSettings(Path.Combine(MainForm.selectedBackupPath, "profileData"));
        }
    }
}
