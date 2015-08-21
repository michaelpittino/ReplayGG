using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using ReplayGG.Replays.Data;

namespace ReplayGG.Replays.Network
{

    public class ReplayServer
    {

        private ReplayData replayData;

        private HttpListener httpListener;
        private RequestManager requestManager;

        private Task listenTask;

        public ReplayServer(ReplayData replayData)
        {
            this.replayData = replayData;

            this.httpListener = new HttpListener();
            this.requestManager = new RequestManager(replayData);

            this.listenTask = new Task(() => this.Listen());

            this.httpListener.Prefixes.Add("http://localhost:8080/");
        }

        public void Start()
        {
            this.httpListener.Start();

            this.listenTask.Start();
        }

        public void Stop()
        {
            this.httpListener.Stop();
            this.httpListener.Close();
        }

        private void Listen()
        {
            while (true)
            {
                try
                {
                    this.requestManager.Handle(this.httpListener.GetContext());
                }
                catch { break; }
            } 
        }

    }

}
