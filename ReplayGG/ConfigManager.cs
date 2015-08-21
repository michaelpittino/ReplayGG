using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using ReplayGG.Data;

namespace ReplayGG
{

    public static class ConfigManager
    {

        public static void Initialize()
        {
            if (!File.Exists(Program.ConfigFile))
                SaveConfig(Program.ConfigFile, new Config());

            Program.Config = LoadConfig(Program.ConfigFile);
        }

        public static void SaveConfig(string filePath, Config config)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Config));

                xmlSerializer.Serialize(fileStream, config);
            }
        }

        public static Config LoadConfig(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Config));

                return (Config) xmlSerializer.Deserialize(fileStream);
            }
        }

    }

}
