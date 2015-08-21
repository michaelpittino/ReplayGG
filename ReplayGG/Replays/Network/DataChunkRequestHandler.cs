using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using ReplayGG.Replays.Data;

namespace ReplayGG.Replays.Network
{

    public class DataChunkRequestHandler : RequestHandler
    {

        private ReplayData replayData;

        public DataChunkRequestHandler(ReplayData replayData)
        {
            this.replayData = replayData;
        }

        public override void Handle(HttpListenerContext context)
        {
            int chunkId = Convert.ToInt32(context.Request.RawUrl.Split('/')[7]);
            byte[] buffer = this.replayData.Chunks.Where(c => c.Id == chunkId).First().Data;

            context.Response.ContentLength64 = buffer.Length;
            context.Response.ContentType = "application/octet-stream";
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);

            context.Response.OutputStream.Close();
        }

    }

}
