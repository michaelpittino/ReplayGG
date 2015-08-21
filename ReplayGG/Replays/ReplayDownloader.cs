using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ReplayGG.Replays.Data;

namespace ReplayGG.Replays
{

    public delegate void OnServerVersionDownloadedHandler(object sender, Version serverVersion);
    public delegate void OnMetadataDownloadedHandler(object sender, Metadata metadata);
    public delegate void OnChunkDownloadedHandler(object sender, Chunk chunk);
    public delegate void OnKeyFrameDownloadedHandler(object sender, KeyFrame keyFrame);
    public delegate void OnDownloadFinishedHandler(object sender, ReplayData replayData);

    public class ReplayDownloader
    {

        public event OnServerVersionDownloadedHandler OnServerVersionDownloaded;
        public event OnMetadataDownloadedHandler OnMetadataDownloaded;
        public event OnChunkDownloadedHandler OnChunkDownloaded;
        public event OnKeyFrameDownloadedHandler OnKeyFrameDownloaded;
        public event OnDownloadFinishedHandler OnDownloadFinished;

        private Replay replay;

        private string encryptionKey;

        public ReplayDownloader(string replayUrl)
        {
            this.replay = null;

            this.encryptionKey = null;

            var urlQuery = HttpUtility.ParseQueryString(replayUrl.Substring(new[] { 0, replayUrl.IndexOf('?') }.Max()));

            string platformIdValue = urlQuery.Get("r");
            string gameIdValue = urlQuery.Get("id");
            string encryptionKeyValue = urlQuery.Get("key");

            if (platformIdValue == null || gameIdValue == null || encryptionKeyValue == null)
                throw new ArgumentException("replayUrl is not valid");

            PlatformId platformId = (PlatformId) Enum.Parse(typeof(PlatformId), platformIdValue, true);
            long gameId = Convert.ToInt64(gameIdValue);

            this.replay = new Replay(platformId, gameId);

            this.encryptionKey = encryptionKeyValue;
        }

        public void Download()
        {
            new Task(() =>
            {
                ReplayData replayData = new ReplayData();

                replayData.ServerVersion = this.replay.GetServerVersion();

                if (this.OnServerVersionDownloaded != null)
                    this.OnServerVersionDownloaded(this, replayData.ServerVersion);

                replayData.Metadata = this.replay.GetMetadata();

                if (this.OnMetadataDownloaded != null)
                    this.OnMetadataDownloaded(this, replayData.Metadata);

                for (int i = 1; i <= replayData.Metadata.LastChunkId; i++)
                {
                    Chunk chunk = new Chunk();

                    chunk.Id = i;
                    chunk.Data = this.replay.GetChunkData(i); 

                    replayData.Chunks.Add(chunk);

                    if (this.OnChunkDownloaded != null)
                        this.OnChunkDownloaded(this, chunk);
                }

                for (int i = 1; i <= replayData.Metadata.LastKeyFrameId; i++)
                {
                    KeyFrame keyFrame = new KeyFrame();

                    keyFrame.Id = i;
                    keyFrame.Data = this.replay.GetKeyFrameData(i);

                    replayData.KeyFrames.Add(keyFrame);

                    if (this.OnKeyFrameDownloaded != null)
                        this.OnKeyFrameDownloaded(this, keyFrame);
                }

                replayData.LastChunkInfo = this.replay.GetLastChunkInfo();

                replayData.EncryptionKey = this.encryptionKey;

                if (this.OnDownloadFinished != null)
                    this.OnDownloadFinished(this, replayData);
            }).Start();
        }

    }

}
