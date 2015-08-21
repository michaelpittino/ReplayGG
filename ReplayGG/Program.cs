using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReplayGG.Data;

namespace ReplayGG
{

    public static class Program
    {

        public static readonly string ConfigFile = "config.xml";
        public static readonly string ReplaysDir = "replays";

        public static readonly string LeagueExecutable = "League of Legends.exe";

        public static Config Config { get; set; }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

    }

}
