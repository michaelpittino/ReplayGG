using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayGG.Replays.Data
{

    [Serializable]
    public class KeyFrame
    {

        public int Id { get; set; }
        public byte[] Data { get; set; }

        public KeyFrame()
        {
            this.Id = 0;
            this.Data = null;
        }

    }

}
