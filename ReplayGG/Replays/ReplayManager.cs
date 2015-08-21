using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using ReplayGG.Replays.Data;

namespace ReplayGG.Replays
{

    public static class ReplayManager
    {

        public static void Initialize()
        {
            if (!Directory.Exists(Program.ReplaysDir))
                Directory.CreateDirectory(Program.ReplaysDir);
        }

        public static void SaveReplay(string filename, ReplayData replayData)
        {
            string filePath = Path.Combine(Program.ReplaysDir, String.Format("{0}.replaygg", filename));

            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
            using (GZipStream gzipStream = new GZipStream(fileStream, CompressionMode.Compress))
                new BinaryFormatter().Serialize(gzipStream, replayData);
        }

        public static ReplayData LoadReplay(string filename)
        {
            string filePath = Path.Combine(Program.ReplaysDir, String.Format("{0}.replaygg", filename));

            if (!File.Exists(filePath))
                return null;

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (GZipStream gzipStream = new GZipStream(fileStream, CompressionMode.Decompress))
                return (ReplayData) new BinaryFormatter().Deserialize(gzipStream);
        }

        public static void DeleteReplay(string filename)
        {
            string filePath = Path.Combine(Program.ReplaysDir, String.Format("{0}.replaygg", filename));

            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        public static List<ReplayData> LoadReplays()
        {
            List<ReplayData> replayDataList = new List<ReplayData>();

            foreach (string file in Directory.GetFiles(Program.ReplaysDir))
            {
                FileInfo fileInfo = new FileInfo(file);

                if (fileInfo.Extension != ".replaygg")
                    continue;

                replayDataList.Add(LoadReplay(Path.GetFileNameWithoutExtension(file)));
            }

            return replayDataList;
        }

    }

}
