using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ReplayGG.Replays.Network
{

    public abstract class RequestHandler
    {

        public RequestHandler() { }

        public abstract void Handle(HttpListenerContext context);

    }

}
