using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using ReplayGG.Replays.Data;

namespace ReplayGG.Replays.Network
{

    public class KeyFrameRequestHandler : RequestHandler
    {

        private ReplayData replayData;

        public KeyFrameRequestHandler(ReplayData replayData)
        {
            this.replayData = replayData;
        }

        public override void Handle(HttpListenerContext context)
        {
            int keyFrameId = Convert.ToInt32(context.Request.RawUrl.Split('/')[7]);
            byte[] buffer = this.replayData.KeyFrames.Where(k => k.Id == keyFrameId).First().Data;

            context.Response.ContentLength64 = buffer.Length;
            context.Response.ContentType = "application/octet-stream";
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);

            context.Response.OutputStream.Close();
        }

    }

}
