using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OBS_Settings_Manager
{
    [Serializable]
    class MetaData
    {
        public DateTime date { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public string encoder { get; set; }
        public string videopath { get; set; }

        public bool SaveData(string path)
        {
            FileStream fs = new FileStream(Path.Combine(path, "metaINF.dat"), FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                formatter.Serialize(fs, this);
            }
            catch (Exception exc)
            {
                Debug.Print("ERROR: Serialization failed: " + exc.ToString());
                fs.Close();
                return false;
            }

            fs.Close();
            return true;
        }

        public MetaData LoadData(string path)
        {
            FileStream fs;
            BinaryFormatter formatter = new BinaryFormatter();
            MetaData data = new MetaData();

            try
            {
                fs = new FileStream(Path.Combine(path, "metaINF.dat"), FileMode.Open);
            }
            catch (FileNotFoundException exc)
            {
                Debug.Print("ERROR: File not found: " + exc.ToString());
                return new MetaData();
            }

            try
            {
                data = (MetaData)formatter.Deserialize(fs);
            }
            catch (Exception exc)
            {
                Debug.Print("ERROR: Deserialization failed: " + exc.ToString());
                fs.Close();
                return data;
            }

            fs.Close();
            return data;
        }
    }
}
