using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using ReplayGG.Replays.Data;

namespace ReplayGG.Replays.Network
{

    public class RequestManager
    {

        private ReplayData replayData;

        private Dictionary<string, RequestHandler> requestHandlers;

        public RequestManager(ReplayData replayData)
        {
            this.replayData = replayData;

            this.requestHandlers = new Dictionary<string, RequestHandler>()
            {
                { "version", new VersionRequestHandler(replayData) },
                { "getGameMetaData", new MetadataRequestHandler(replayData) },
                { "getGameDataChunk", new DataChunkRequestHandler(replayData) },
                { "getLastChunkInfo", new LastChunkInfoRequestHandler(replayData) },
                { "getKeyFrame", new KeyFrameRequestHandler(replayData) }
            }; 
        }

        public void Handle(HttpListenerContext context)
        {
            System.Diagnostics.Debug.WriteLine(context.Request.RawUrl);

            if (!context.Request.RawUrl.StartsWith("/observer-mode/rest/consumer/"))
                return;

            string methodName = context.Request.RawUrl.Split('/')[4];
            RequestHandler requestHandler = this.requestHandlers.Where(r => r.Key == methodName).First().Value;

            requestHandler.Handle(context);
        }

    }

}
