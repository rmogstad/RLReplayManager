using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO.Compression;

namespace RLReplayManager
{
    public partial class ReplayManagerForm : Form
    {
        public ReplayManagerForm()
        {
            InitializeComponent();
        }

        FileSystemWatcher replayWatcher;

        BindingList<ReplayHeader> replays = new BindingList<ReplayHeader>();
        private void ReplayManagerForm_Load(object sender, EventArgs e)
        {
            var replayDir = Properties.Settings.Default.ReplayDirectory;
            replayDir = replayDir.Replace("%MYDOCUMENTS%", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            var replayFiles = Directory.GetFiles(replayDir, "*.replay");

            while (replayFiles.Length == 0)
            {
                var folderBrowser = new FolderBrowserDialog();
                if (folderBrowser.ShowDialog() != DialogResult.OK)
                {
                    Application.Exit();
                    return;
                }

                replayDir = folderBrowser.SelectedPath;
                replayFiles = Directory.GetFiles(replayDir, "*.replay");
                if (replayFiles.Length > 0)
                {
                    Properties.Settings.Default.ReplayDirectory = folderBrowser.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }
            

            foreach (var file in replayFiles.OrderByDescending(o => new FileInfo(o).CreationTime).ToList())
            {
                try
                {
                    var replayInfo = ReplayHeader.DeserializeHeader(file);
                    replays.Add(replayInfo);
                } catch(Exception ex)
                {
                    if(ErrorTextBox.Text != String.Empty)
                    {
                        ErrorTextBox.Text += System.Environment.NewLine;
                    }

                    ErrorTextBox.Text += "Error loading '" + file + "': " + ex.Message;
                }                
            }

            ReplayGridView.AutoGenerateColumns = true;
            OrangeGridView.AutoGenerateColumns = true;
            BlueGridView.AutoGenerateColumns = true;

            ReplayGridView.DataSource = replays;

            APIKeyTextBox.Text = Properties.Settings.Default.APIKey;
            autoUploadNewReplaysToolStripMenuItem.Checked = Properties.Settings.Default.AutoUpload;

            replayWatcher = new FileSystemWatcher(replayDir, "*.replay");
            replayWatcher.Created += ReplayWatcher_FileCreated;
            replayWatcher.EnableRaisingEvents = true;
        }

        

        private void ReplayWatcher_FileCreated(object sender, FileSystemEventArgs e)
        {
            if(Properties.Settings.Default.AutoUpload)
            {
                System.Threading.Thread.Sleep(500); //HACK
                var replayInfo = ReplayHeader.DeserializeHeader(e.FullPath);
                ReplayGridView.Invoke((MethodInvoker) delegate { replays.Insert(0, replayInfo); });
                UploadReplayFile(e.FullPath);

                notifyIcon1.BalloonTipTitle = "Replay Uploaded";
                notifyIcon1.BalloonTipText = (replayInfo.ReplayName == String.Empty ? replayInfo.ReplayFile : replayInfo.ReplayName) + " uploaded.";
                notifyIcon1.ShowBalloonTip(500);
            }
        }

        private void ReplayGridView_SelectionChanged(object sender, EventArgs e)
        {
            UpdateTeamInfo();
        }

        private void UpdateTeamInfo()
        {
            if (ReplayGridView.SelectedRows.Count > 0)
            {
                BlueGridView.DataSource = ((ReplayHeader)ReplayGridView.SelectedRows[0].DataBoundItem).BlueTeamPlayers;
                OrangeGridView.DataSource = ((ReplayHeader)ReplayGridView.SelectedRows[0].DataBoundItem).OrangeTeamPlayers;
            }
        }

        private void APIKeyTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.APIKey = APIKeyTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void autoUploadNewReplaysToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoUpload = autoUploadNewReplaysToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private  void UploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                UploadProgressBar.Value = 0;
                UploadProgressBar.Visible = true;
                UploadStatusLabel.Text = "";
                UploadStatusLabel.Visible = true;
                double i = 0.0;
                foreach (DataGridViewRow row in ReplayGridView.SelectedRows)
                {
                    var replay = (ReplayHeader)row.DataBoundItem;
                    UploadStatusLabel.Text = "Uploading '" + (replay.ReplayName == String.Empty ? replay.ReplayFile : replay.ReplayName) + "'";
                    UploadReplayFile(replay.ReplayFile);
                    i++;
                    UploadProgressBar.Value = (int)Math.Round(i / ReplayGridView.SelectedRows.Count);
                }

                ReplayGridView.ClearSelection();

                UploadStatusLabel.Text = "Done uploading.";
            } catch(Exception ex)
            {
                MessageBox.Show("An error occurred while uploading replay: " + ex.Message);
                UploadStatusLabel.Text = "Error uploading.";
            }
            
            UploadProgressBar.Visible = false;


        }
        
        private void UploadReplayFile(string replayFile)
        {
            string key = Properties.Settings.Default.APIKey;

            if (key == "")
            {
                MessageBox.Show("Must enter API key before you can upload!", "Enter API Key", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var UploadClient = new HttpClient())
            {
                UploadClient.DefaultRequestHeaders.Add("Authorization", "Token " + Properties.Settings.Default.APIKey);

                string filename = Path.GetFileName(replayFile);


                ByteArrayContent fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(replayFile));
                MultipartFormDataContent content = new MultipartFormDataContent();
                content.Add(fileContent, "file", filename);
                
                
                var response = UploadClient.PostAsync("https://www.rocketleaguereplays.com/api/replays/", content);
                response.Wait();
                if(!(response.Result.IsSuccessStatusCode || (response.Result.StatusCode == HttpStatusCode.BadRequest && response.Result.Content.ReadAsStringAsync().Result.Contains("already been uploaded")) ))
                {
                    throw new Exception("Unable to upload replay '" + replayFile + "': " + response.Result.Content.ReadAsStringAsync().Result);
                }
            }

        }

        private void ReplayManagerForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Zip files (*.zip) | *.zip";
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);

            foreach (DataGridViewRow row in ReplayGridView.SelectedRows)
            {
                var replay = (ReplayHeader)row.DataBoundItem;
                File.Copy(replay.ReplayFile, Path.Combine(tempDirectory, Path.GetFileName(replay.ReplayFile)));
            }
            
        }
    }
}
 