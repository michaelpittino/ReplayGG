using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReplayGG
{

    public static class Program
    {

        // temporary
        public static readonly string LeagueDir = @"D:\Spiele\League of Legends\RADS\solutions\lol_game_client_sln\releases\0.0.1.101\deploy";
        public static readonly string LeagueExecutable = "League of Legends.exe";

        public static readonly string ReplaysDir = "replays";

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

    }

}
