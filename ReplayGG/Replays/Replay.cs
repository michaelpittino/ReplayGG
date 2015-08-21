using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReplayGG.Replays.Data;

namespace ReplayGG.Replays
{

    public enum PlatformId { NA1, EUW1, EUN1, BR1, LA1, LA2, RU, TR1, OC1, KR, TW, SG, PBE1 }

    public class Replay
    {

        private const string URL_BASE = "http://replay.gg:8080";
        private const string URL_SERVERVERSION = "/observer-mode/rest/consumer/version";
        private const string URL_METADATA = "/observer-mode/rest/consumer/getGameMetaData/[0]/[1]/0/token";
        private const string URL_LASTCHUNKINFO = "/observer-mode/rest/consumer/getLastChunkInfo/[0]/[1]/0/token";
        private const string URL_DATACHUNK = "/observer-mode/rest/consumer/getGameDataChunk/[0]/[1]/[2]/token";
        private const string URL_KEYFRAME = "/observer-mode/rest/consumer/getKeyFrame/[0]/[1]/[2]/token";

        private static readonly string _serverVersionUrl = String.Format("{0}{1}", URL_BASE, URL_SERVERVERSION);
        private static readonly string _metaDataUrl = String.Format("{0}{1}", URL_BASE, URL_METADATA);
        private static readonly string _lastChunkInfoUrl = String.Format("{0}{1}", URL_BASE, URL_LASTCHUNKINFO);
        private static readonly string _dataChunkUrl = String.Format("{0}{1}", URL_BASE, URL_DATACHUNK);
        private static readonly string _keyFrameUrl = String.Format("{0}{1}", URL_BASE, URL_KEYFRAME);

        private PlatformId platformId;
        private long gameId;

        private ReplayWebRequest replayWebRequest;

        public Replay(PlatformId platformId, long gameId)
        {
            this.platformId = platformId;
            this.gameId = gameId;

            this.replayWebRequest = new ReplayWebRequest();
        }

        public Version GetServerVersion()
        {
            Uri serverVersionUri = new Uri(_serverVersionUrl);

            return new Version(this.replayWebRequest.GetPlainResponse(serverVersionUri));
        }

        public Metadata GetMetadata()
        {
            Uri metaDataUri = GenerateMetaDataUri(this.platformId, this.gameId);

            return this.replayWebRequest.GetJsonResponse<Metadata>(metaDataUri);
        }

        public LastChunkInfo GetLastChunkInfo()
        {
            Uri lastChunkInfoUri = GenerateLastChunkInfoUri(this.platformId, this.gameId);

            return this.replayWebRequest.GetJsonResponse<LastChunkInfo>(lastChunkInfoUri);
        }

        public byte[] GetChunkData(int chunkId)
        {
            Uri dataChunkUri = GenerateDataChunkUri(this.platformId, this.gameId, chunkId);

            return this.replayWebRequest.GetByteArrayResponse(dataChunkUri);
        }

        public byte[] GetKeyFrameData(int keyFrameId)
        {
            Uri keyFrameUri = GenerateKeyFrameUri(this.platformId, this.gameId, keyFrameId);

            return this.replayWebRequest.GetByteArrayResponse(keyFrameUri);
        }

        private static Uri GenerateMetaDataUri(PlatformId platformId, long gameId)
        {
            string metaDataUrl = _metaDataUrl;

            metaDataUrl = metaDataUrl.Replace("[0]", platformId.ToString());
            metaDataUrl = metaDataUrl.Replace("[1]", gameId.ToString());

            return new Uri(metaDataUrl);
        }

        private static Uri GenerateLastChunkInfoUri(PlatformId platformId, long gameId)
        {
            string lastChunkInfoUrl = _lastChunkInfoUrl;

            lastChunkInfoUrl = lastChunkInfoUrl.Replace("[0]", platformId.ToString());
            lastChunkInfoUrl = lastChunkInfoUrl.Replace("[1]", gameId.ToString());

            return new Uri(lastChunkInfoUrl);
        }

        private static Uri GenerateDataChunkUri(PlatformId platformId, long gameId, int chunkId)
        {
            string dataChunkUrl = _dataChunkUrl;

            dataChunkUrl = dataChunkUrl.Replace("[0]", platformId.ToString());
            dataChunkUrl = dataChunkUrl.Replace("[1]", gameId.ToString());
            dataChunkUrl = dataChunkUrl.Replace("[2]", chunkId.ToString());

            return new Uri(dataChunkUrl);
        }

        private static Uri GenerateKeyFrameUri(PlatformId platformId, long gameId, int keyFrameId)
        {
            string keyFrameUrl = _keyFrameUrl;

            keyFrameUrl = keyFrameUrl.Replace("[0]", platformId.ToString());
            keyFrameUrl = keyFrameUrl.Replace("[1]", gameId.ToString());
            keyFrameUrl = keyFrameUrl.Replace("[2]", keyFrameId.ToString());

            return new Uri(keyFrameUrl);
        }

    }

}
