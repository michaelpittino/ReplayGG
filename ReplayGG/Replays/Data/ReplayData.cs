using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayGG.Replays.Data
{

    [Serializable]
    public class ReplayData
    {

        public Version ServerVersion { get; set; }
        public Metadata Metadata { get; set; }
        public List<Chunk> Chunks { get; set; }
        public List<KeyFrame> KeyFrames { get; set; }
        public LastChunkInfo LastChunkInfo { get; set; }

        public string Filename { get; set; }
        public DateTime CreationDate { get; set; }

        public string EncryptionKey { get; set; }

        public ReplayData()
        {
            this.ServerVersion = null;
            this.Metadata = null;
            this.Chunks = new List<Chunk>();
            this.KeyFrames = new List<KeyFrame>();
            this.LastChunkInfo = null;

            this.Filename = null;
            this.CreationDate = new DateTime();
        }

    }

}
