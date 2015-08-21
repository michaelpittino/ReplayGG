using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayGG.Data
{

    [Serializable]
    public class Config
    {

        public string LeagueDir { get; set; }

        public Config()
        {
            this.LeagueDir = @"C:\Riot Games\League of Legends\RADS\solutions\lol_game_client_sln\releases\0.0.1.101\deploy";
        }

    }

}
