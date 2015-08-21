using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using ReplayGG.Replays.Data;

namespace ReplayGG.Replays.Network
{

    public class VersionRequestHandler : RequestHandler
    {

        private ReplayData replayData;

        public VersionRequestHandler(ReplayData replayData)
        {
            this.replayData = replayData;
        }

        public override void Handle(HttpListenerContext context)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(this.replayData.ServerVersion.ToString());

            context.Response.ContentLength64 = buffer.Length;
            context.Response.ContentType = "application/json";
            context.Response.KeepAlive = false;
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);

            context.Response.OutputStream.Close();
        }

    }

}
