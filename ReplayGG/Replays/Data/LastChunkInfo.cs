using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReplayGG.Replays.Data
{

    [Serializable]
    public class LastChunkInfo
    {

        [JsonProperty("startGameChunkId")]
        public int StartGameChunkId { get; set; }

        [JsonProperty("endStartupChunkId")]
        public int EndStartupChunkId { get; set; }

        [JsonProperty("endGameChunkId")]
        public int EndGameChunkId { get; set; }

        [JsonProperty("nextChunkId")]
        public int NextChunkId { get; set; }

        [JsonProperty("keyFrameId")]
        public int KeyFrameId { get; set; }

        [JsonProperty("nextAvailableChunk")]
        public int NextAvailableChunk { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("availableSince")]
        public int AvailableSince { get; set; }

        [JsonProperty("chunkId")]
        public int ChunkId { get; set; }

        public LastChunkInfo()
        {
            this.StartGameChunkId = 0;
            this.EndStartupChunkId = 0;
            this.EndGameChunkId = 0;
            this.NextChunkId = 0;
            this.KeyFrameId = 0;
            this.NextAvailableChunk = 0;
            this.Duration = 0;
            this.AvailableSince = 0;
            this.ChunkId = 0;
        }

    }

}
