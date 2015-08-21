using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReplayGG.Replays.Data
{

    [Serializable]
    public class Metadata
    {

        [Serializable]
        public class JsonGameKey
        {

            [JsonProperty("gameId")]
            public long GameId { get; set; }

            [JsonProperty("platformId")]
            public string PlatformId { get; set; }

        }

        [Serializable]
        public class JsonPendingAvailableChunkInfo
        {

            [JsonProperty("duration")]
            public int Duration { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("receivedTime")]
            public string ReceivedDate { get; set; }

        }

        [Serializable]
        public class JsonPendingAvailableKeyFrameInfo
        {

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("receivedTime")]
            public string ReceivedDate { get; set; }

            [JsonProperty("nextChunkId")]
            public int NextChunkId { get; set; }

        }

        [JsonProperty("gameKey")]
        public JsonGameKey GameKey { get; set; }

        [JsonProperty("gameServerAddress")]
        public string GameServerAddress { get; set; }

        [JsonProperty("port")]
        public int Port { get; set; }

        [JsonProperty("encryptionKey")]
        public string EncryptionKey { get; set; }

        [JsonProperty("chunkTimeInterval")]
        public int ChunkTimeInterval { get; set; }

        [JsonProperty("startTime")]
        public string GameStartDate { get; set; }

        [JsonProperty("gameEnded")]
        public bool GameEnded { get; set; }

        [JsonProperty("lastChunkId")]
        public int LastChunkId { get; set; }

        [JsonProperty("lastKeyFrameId")]
        public int LastKeyFrameId { get; set; }

        [JsonProperty("endStartupChunkId")]
        public int EndStartupChunkId { get; set; }

        [JsonProperty("delayTime")]
        public int DelayTime { get; set; }

        [JsonProperty("pendingAvailableChunkInfo")]
        List<JsonPendingAvailableChunkInfo> PendingAvailableChunkInfo { get; set; }

        [JsonProperty("pendingAvailableKeyFrameInfo")]
        List<JsonPendingAvailableKeyFrameInfo> PendingAvailableKeyFrameInfo { get; set; }

        [JsonProperty("keyFrameTimeInterval")]
        public int KeyFrameTimeInterval { get; set; }

        [JsonProperty("decodedEncryptionKey")]
        public string DecodedEncryptionKey { get; set; }

        [JsonProperty("startGameChunkId")]
        public int StartGameChunkId { get; set; }

        [JsonProperty("gameLength")]
        public int GameLength { get; set; }

        [JsonProperty("clientAddedLag")]
        public int ClientAddedLag { get; set; }

        [JsonProperty("clientBackFetchingEnabled")]
        public bool ClientBackFetchingEnabled { get; set; }

        [JsonProperty("clientBackFetchingFreq")]
        public int ClientBackFetchingFreq { get; set; }

        [JsonProperty("interestScore")]
        public int InterestScore { get; set; }

        [JsonProperty("featuredGame")]
        public bool FeaturedGame { get; set; }

        [JsonProperty("createTime")]
        public string CreateDate { get; set; }

        [JsonProperty("endGameChunkId")]
        public int EndGameChunkId { get; set; }

        [JsonProperty("endGameKeyFrameId")]
        public int EndGameKeyFrameId { get; set; }

        [JsonProperty("firstChunkId")]
        public int FirstChunkId { get; set; }

        public Metadata()
        {
            this.GameKey = null;
            this.GameServerAddress = null;
            this.Port = 0;
            this.EncryptionKey = null;
            this.ChunkTimeInterval = 0;
            this.GameStartDate = null;
            this.GameEnded = false;
            this.LastChunkId = 0;
            this.LastKeyFrameId = 0;
            this.EndStartupChunkId = 0;
            this.DelayTime = 0;
            this.PendingAvailableChunkInfo = null;
            this.PendingAvailableKeyFrameInfo = null;
            this.KeyFrameTimeInterval = 0;
            this.DecodedEncryptionKey = null;
            this.StartGameChunkId = 0;
            this.GameLength = 0;
            this.ClientAddedLag = 0;
            this.ClientBackFetchingEnabled = false;
            this.ClientBackFetchingFreq = 0;
            this.InterestScore = 0;
            this.FeaturedGame = false;
            this.CreateDate = null;
            this.EndGameChunkId = 0;
            this.EndGameKeyFrameId = 0;
            this.FirstChunkId = 0;
        }

    }

}
