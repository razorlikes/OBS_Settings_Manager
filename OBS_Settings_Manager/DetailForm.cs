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
        Hashtable streamSettings;
        Hashtable recordSettings;
        IniData basicSettings;
        Hashtable streamSettingsCurrent;
        Hashtable recordSettingsCurrent;
        IniData basicSettingsCurrent;

        public DetailForm()
        {
            InitializeComponent();

            readSettings(Path.Combine(MainForm.selectedBackupPath, "profileData"));
        }

        void readSettings(string path)
        {
            streamSettings = new Hashtable();
            recordSettings = new Hashtable();
            basicSettings = new IniData();
            streamSettingsCurrent = new Hashtable();
            recordSettingsCurrent = new Hashtable();
            basicSettingsCurrent = new IniData();

            try
            {
                StreamReader readerS = new StreamReader(Path.Combine(path, "streamEncoder.json"));
                string settingsJsonS = readerS.ReadToEnd();
                readerS.Close();
                streamSettings = JsonConvert.DeserializeObject<Hashtable>(settingsJsonS);

                if (File.Exists(Path.Combine(MainForm.selectedProfilePath, "streamEncoder.json")) && ckbCompare.Checked)
                {
                    StreamReader readerSC = new StreamReader(Path.Combine(MainForm.selectedProfilePath, "streamEncoder.json"));
                    string settingsJsonSC = readerSC.ReadToEnd();
                    readerSC.Close();
                    streamSettingsCurrent = JsonConvert.DeserializeObject<Hashtable>(settingsJsonS);
                }
            }
            catch (FileNotFoundException)
            {
                rbtnStreaming.Enabled = false;
            }

            try
            {
                StreamReader readerR = new StreamReader(Path.Combine(path, "recordEncoder.json"));
                string settingsJsonR = readerR.ReadToEnd();
                readerR.Close();
                recordSettings = JsonConvert.DeserializeObject<Hashtable>(settingsJsonR);

                if (File.Exists(Path.Combine(MainForm.selectedProfilePath, "recordEncoder.json")) && ckbCompare.Checked)
                {
                    StreamReader readerRC = new StreamReader(Path.Combine(MainForm.selectedProfilePath, "recordEncoder.json"));
                    string settingsJsonRC = readerRC.ReadToEnd();
                    readerRC.Close();
                    recordSettingsCurrent = JsonConvert.DeserializeObject<Hashtable>(settingsJsonR);
                }
            }
            catch (FileNotFoundException)
            {
                rbtnRecording.Enabled = false;
            }

            FileIniDataParser parser = new FileIniDataParser();
            basicSettings = parser.ReadFile(Path.Combine(path, "basic.ini"));

            if (ckbCompare.Checked)
            {
                FileIniDataParser parserC = new FileIniDataParser();
                basicSettingsCurrent = parserC.ReadFile(Path.Combine(MainForm.selectedProfilePath, "basic.ini"));
            }

            if (rbtnStreaming.Checked)
                buildList(streamSettings, streamSettingsCurrent);

            else if (rbtnRecording.Checked)
                buildList(recordSettings, recordSettingsCurrent);

            else if (rbtnBasic.Checked)
                buildIniList(basicSettings, basicSettingsCurrent);
        }

        void buildList(Hashtable settings, Hashtable current)
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

                foreach(DictionaryEntry valc in current)
                {
                    if (valc.Key == val.Key)
                        lvi.SubItems.Add(valc.Value.ToString());
                }
            }
        }

        void buildIniList(IniData data, IniData current)
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

                    foreach (SectionData sectionc in current.Sections)
                    {
                        foreach (KeyData keyc in sectionc.Keys)
                        {
                            if (keyc.KeyName == key.KeyName)
                                lvi.SubItems.Add(keyc.Value.ToString());
                        }
                    }
                }
            }
        }

        private void rbtnCheckedChanged(object sender, EventArgs e)
        {
            if (rbtnStreaming.Checked)
                buildList(streamSettings, streamSettingsCurrent);

            else if (rbtnRecording.Checked)
                buildList(recordSettings, recordSettingsCurrent);

            else if (rbtnBasic.Checked)
                buildIniList(basicSettings, basicSettingsCurrent);
        }

        private void ckbCompare_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbCompare.Checked)
            {
                headerSetting.Width = 155;
                headerBackupValue.Width = 160;
                headerCurrentValue.Width = 160;
            }
            else if (!ckbCompare.Checked)
            {
                headerSetting.Width = 200;
                headerBackupValue.Width = 275;
                headerCurrentValue.Width = 0;
            }

            readSettings(Path.Combine(MainForm.selectedBackupPath, "profileData"));
        }
    }
}
