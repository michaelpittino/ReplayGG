using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using ReplayGG.Replays;
using ReplayGG.Replays.Data;
using ReplayGG.Replays.Network;

namespace ReplayGG
{

    public partial class MainForm : Form
    {

        private ReplayServer replayServer;

        public MainForm()
        {
            this.replayServer = null;

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        { 
            ReplayManager.Initialize();

            this.LoadReplays();
        }

        private void DownloadReplayButton_Click(object sender, EventArgs e)
        {
            ReplayDownloader replayDownloader = null;
            Metadata metadata = null;
            int chunksDownloaded = 0;
            int keyFramesDownloaded = 0;

            try
            {
                replayDownloader = new ReplayDownloader(DownloadReplayUrlText.Text);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Please enter a valid replay.gg link.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            this.ToggleDownloadReplayUI();

            DownloadReplayStatusLabel.Text = "Status: Downloading server version..";

            replayDownloader.OnServerVersionDownloaded += (senderLocal, serverVersion) => { this.SetDownloadReplayStatus("Downloading metadata.."); };

            replayDownloader.OnMetadataDownloaded += (senderLocal, metadataLocal) =>
            {
                metadata = metadataLocal;

                this.SetDownloadReplayProgressMaximumValue(metadata.LastChunkId + metadata.LastKeyFrameId);

                this.SetDownloadReplayStatus("Downloading chunk 1/{0}..", metadata.LastChunkId);
            };

            replayDownloader.OnChunkDownloaded += (replayDownloaderLocal, chunk) =>
            {
                if (chunk.Id != metadata.LastChunkId)
                    this.SetDownloadReplayStatus("Downloading chunk {0}/{1}..", chunk.Id + 1, metadata.LastChunkId);
                else
                    this.SetDownloadReplayStatus("Downloading key frame 1/{0}..", metadata.LastKeyFrameId);

                chunksDownloaded++;

                this.IncreaseDownloadProgressValue();
            };

            replayDownloader.OnKeyFrameDownloaded += (replayDownloaderLoacal, keyFrame) =>
            {

                if (keyFrame.Id != metadata.LastKeyFrameId)
                    this.SetDownloadReplayStatus("Downloading key frame {0}/{1}..", keyFrame.Id, metadata.LastKeyFrameId);

                keyFramesDownloaded++;

                this.IncreaseDownloadProgressValue();
            };

            replayDownloader.OnDownloadFinished += (replayDownloaderLocal, replayData) =>
            {
                DateTime creationDate = DateTime.Now;

                replayData.Filename = creationDate.ToString("dd-MM-yyyy-HH-mm-ss");
                replayData.CreationDate = creationDate;

                this.SetDownloadReplayStatus("Finished download, saving replay..", chunksDownloaded);

                ReplayManager.SaveReplay(creationDate.ToString("dd-MM-yyyy-HH-mm-ss"), replayData);

                this.SetDownloadReplayStatus("Idle");

                this.ToggleDownloadReplayUI();
                this.ResetDownloadReplayUI();

                this.LoadReplays();
            };

            replayDownloader.Download();
        }

        private void ManageReplaysRefreshList_Click(object sender, EventArgs e)
        {
            this.LoadReplays();
        }

        private void ManageReplaysList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ManageReplaysList.SelectedIndices.Count != 0)
            {
                this.SetManageReplaysUI(true);
            }
            else
                this.SetManageReplaysUI(false);
        }

        private void ManageReplaysDeleteButton_Click(object sender, EventArgs e)
        {
            ReplayData replayData = (ReplayData) ManageReplaysList.SelectedItems[0].Tag;

            ReplayManager.DeleteReplay(replayData.Filename);

            this.LoadReplays();
        }

        private void ManageReplaysLaunchReplayButton_Click(object sender, EventArgs e)
        {
            ReplayData replayData = (ReplayData) ManageReplaysList.SelectedItems[0].Tag;
            Process process = new Process();

            this.replayServer = new ReplayServer(replayData);

            this.replayServer.Start();

            process.StartInfo.FileName = Path.Combine(Program.LeagueDir, Program.LeagueExecutable);
            process.StartInfo.Arguments = String.Format(@"""8394"" ""LoLLauncher.exe"" """" ""replay localhost:8080 {0} {1} {2}""", replayData.EncryptionKey, replayData.Metadata.GameKey.GameId, replayData.Metadata.GameKey.PlatformId);
            process.StartInfo.WorkingDirectory = Program.LeagueDir;

            process.Start();

            ToggleManageReplaysLaunchUI();
        }

        private void ManageReplaysStopLaunchButton_Click(object sender, EventArgs e)
        {
            this.replayServer.Stop();

            ToggleManageReplaysLaunchUI();
        }

        private void ToggleDownloadReplayUI()
        {
            if (DownloadReplayUrlText.InvokeRequired || DownloadReplayButton.InvokeRequired)
            {
                DownloadReplayUrlText.BeginInvoke((MethodInvoker) delegate () { DownloadReplayUrlText.Enabled = !DownloadReplayUrlText.Enabled; });
                DownloadReplayButton.BeginInvoke((MethodInvoker) delegate () { DownloadReplayButton.Enabled = !DownloadReplayButton.Enabled; });
            }
            else
            {
                DownloadReplayUrlText.Enabled = !DownloadReplayUrlText.Enabled;
                DownloadReplayButton.Enabled = !DownloadReplayButton.Enabled;
            }
        }

        private void ResetDownloadReplayUI()
        {
            this.SetDownloadReplayStatus("Idle");

            if (DownloadReplayUrlText.InvokeRequired || DownloadReplayProgress.InvokeRequired)
            {
                DownloadReplayUrlText.BeginInvoke((MethodInvoker) delegate () { DownloadReplayUrlText.Text = String.Empty; });
                DownloadReplayProgress.BeginInvoke((MethodInvoker) delegate ()
                {
                    DownloadReplayProgress.Value = 0;
                    DownloadReplayProgress.Maximum = 100;
                });
            }
            else
            {
                DownloadReplayUrlText.Text = String.Empty;
                DownloadReplayProgress.Value = 0;
                DownloadReplayProgress.Maximum = 100;
            }
        }

        private void SetManageReplaysUI(bool value)
        {
            if (ManageReplaysDeleteButton.InvokeRequired || ManageReplaysLaunchReplayButton.InvokeRequired)
            {
                ManageReplaysDeleteButton.BeginInvoke((MethodInvoker) delegate () { ManageReplaysDeleteButton.Enabled = value; });
                ManageReplaysLaunchReplayButton.BeginInvoke((MethodInvoker) delegate () { ManageReplaysLaunchReplayButton.Enabled = value; });
            }
            else
            {
                ManageReplaysDeleteButton.Enabled = value;
                ManageReplaysLaunchReplayButton.Enabled = value;
            }
        }

        private void SetDownloadReplayStatus(string text, params object[] args)
        {
            string formattedText = String.Format(text, args);

            if (DownloadReplayStatusLabel.InvokeRequired)
                DownloadReplayStatusLabel.BeginInvoke((MethodInvoker) delegate () { DownloadReplayStatusLabel.Text = String.Format("Status: {0}", formattedText); });
            else
                DownloadReplayStatusLabel.Text = String.Format("Status: {0}", formattedText);
        }

        private void SetDownloadReplayProgressMaximumValue(int maxProgress)
        {
            if (DownloadReplayProgress.InvokeRequired)
                DownloadReplayProgress.BeginInvoke((MethodInvoker) delegate () { DownloadReplayProgress.Maximum = maxProgress; });
            else
                DownloadReplayProgress.Maximum = maxProgress;
        }

        private void IncreaseDownloadProgressValue()
        {
            if (DownloadReplayProgress.InvokeRequired)
                DownloadReplayProgress.BeginInvoke((MethodInvoker) delegate () { DownloadReplayProgress.Value++; });
            else
                DownloadReplayProgress.Value++;
        }

        private void ClearManageReplaysList()
        {
            if (ManageReplaysList.InvokeRequired)
                ManageReplaysList.BeginInvoke((MethodInvoker) delegate () { ManageReplaysList.Items.Clear(); });
            else
                ManageReplaysList.Items.Clear();
        }

        private void AddReplayToReplaysList(ReplayData replayData)
        {
            ListViewItem listViewItem = new ListViewItem(new string[] { String.Format("{0}.replaygg", replayData.Filename), replayData.CreationDate.ToString("dd-MM-yyyy HH:mm") });

            listViewItem.Tag = replayData;

            if (ManageReplaysList.InvokeRequired)
                ManageReplaysList.BeginInvoke((MethodInvoker) delegate () { ManageReplaysList.Items.Add(listViewItem); });
            else
                ManageReplaysList.Items.Add(listViewItem);
        }

        private void ToggleManageReplaysLaunchUI()
        {
            if (ManageReplaysLaunchReplayButton.InvokeRequired || ManageReplaysStopLaunchButton.InvokeRequired)
            {
                ManageReplaysLaunchReplayButton.BeginInvoke((MethodInvoker) delegate () { ManageReplaysLaunchReplayButton.Enabled = !ManageReplaysLaunchReplayButton.Enabled; });
                ManageReplaysStopLaunchButton.BeginInvoke((MethodInvoker) delegate () { ManageReplaysStopLaunchButton.Enabled = !ManageReplaysStopLaunchButton.Enabled; });
            }
            else
            {
                ManageReplaysLaunchReplayButton.Enabled = !ManageReplaysLaunchReplayButton.Enabled;
                ManageReplaysStopLaunchButton.Enabled = !ManageReplaysStopLaunchButton.Enabled;
            }
        }

        private void LoadReplays()
        {
            List<ReplayData> replayDataList = ReplayManager.LoadReplays();

            this.ClearManageReplaysList();

            foreach (ReplayData replayData in replayDataList)
                this.AddReplayToReplaysList(replayData);
        }

    }

}
