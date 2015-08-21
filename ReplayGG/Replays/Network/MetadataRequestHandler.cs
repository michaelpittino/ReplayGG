using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using ReplayGG.Replays.Data;
using Newtonsoft.Json;

namespace ReplayGG.Replays.Network
{

    public class MetadataRequestHandler : RequestHandler
    {

        private ReplayData replayData;

        public MetadataRequestHandler(ReplayData replayData)
        {
            this.replayData = replayData;
        }

        public override void Handle(HttpListenerContext context)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this.replayData.Metadata));

            context.Response.ContentLength64 = buffer.Length;
            context.Response.ContentType = "application/json";
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);

            context.Response.OutputStream.Close();
        }

    }

}
