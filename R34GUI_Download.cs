
using System.Diagnostics;

namespace Rule34XXXGUI
{
    public partial class R34GUI_Download : Form
    {
        private string UrlToScan;
        //private bool UseMultiThread;
        private Dictionary<string, string> ConnectionInformation;
        private int PageNumber;
        private string DownloadToPath;

        // Task Groups
        private List<Task> MainPageScanTaskGroup = new List<Task>();
        private List<Task> SubPageScanTaskGroup = new List<Task>();
        private List<Task> DownloadTaskGroup = new List<Task>();

        // Global lock
        private object _Variable_Lock = new object();

        // Stop All Tasks
        private bool StopAllTasks = false;

        public R34GUI_Download(string urlToScan, bool useMultiThread, Dictionary<string, string> connectionInformation, int pagenumber, string downloadtopath)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            // Not finish yet.
            //this.UseMultiThread = useMultiThread; 
            this.ConnectionInformation = connectionInformation;
            this.UrlToScan = urlToScan;
            this.PageNumber = pagenumber;
            this.DownloadToPath = downloadtopath;
            ControlBox = false;
        }

        private async void R34GUI_Download_Load(object sender, EventArgs e)
        {



            HttpClient httpClient = new Rule34Tools().GetHttpClientFromConnectionInformation(this.ConnectionInformation);

            List<string> MainPageUrls = new List<string>();
            for (int i = 0; i < PageNumber; i++)
            {
                MainPageUrls.Add(UrlToScan + "&pid=" + (42 * i));
            }

            Progressbar_ScanAndDownload.Maximum = MainPageUrls.Count;
            Textlabel_NowStatus.Text = "Scanning main pages to get sub pages";
            Textlabel_Progress.Text = $"[0/{MainPageUrls.Count}]";



            List<List<string>> Divided_MainPageUrls = new Rule34Tools().DivideObjects(MainPageUrls, (int)Math.Ceiling(MainPageUrls.Count * 0.1));

            List<List<string>> SubPageUrlsListInList = new List<List<string>>();


            int PageScanProgress = 0;

            for (int i = 0; i < Divided_MainPageUrls.Count; i++)
            {
                int _i = i;
                MainPageScanTaskGroup.Add(
                    new Task(() =>
                    {

                        for (int j = 0; j < Divided_MainPageUrls[_i].Count; j++)
                        {
                            if (StopAllTasks) return;
                            SubPageUrlsListInList.Add(new Rule34Tools().Rule34GetSubPagesUrlsFromMainPageUrl(Divided_MainPageUrls[_i][j], httpClient));

                            lock (_Variable_Lock)
                            {
                                Progressbar_ScanAndDownload.Value++;
                                PageScanProgress++;
                                Textlabel_Progress.Text = $"[{PageScanProgress}/{MainPageUrls.Count}]";
                            }

                        }
                    }
                ));
            }
            for (int i = 0; i < MainPageScanTaskGroup.Count; i++) MainPageScanTaskGroup[i].Start();
            await Task.WhenAll(MainPageScanTaskGroup);

            Progressbar_ScanAndDownload.Value = 0;
            Progressbar_ScanAndDownload.Maximum = 1;
            Textlabel_NowStatus.Text = "Finished scanning main pages";
            Textlabel_Progress.Text = "";

            await Task.Delay(1000);

            Textlabel_NowStatus.Text = "Getting media urls from sub pages";

            List<string> SubPageUrls = new List<string>();
            for (int i = 0; i < SubPageUrlsListInList.Count; i++)
            {
                for (int j = 0; j < SubPageUrlsListInList[i].Count; j++)
                {
                    SubPageUrls.Add("https://rule34.xxx" + SubPageUrlsListInList[i][j]);
                }
            }

            Progressbar_ScanAndDownload.Maximum = SubPageUrls.Count;
            Textlabel_Progress.Text = $"[0/{SubPageUrls.Count}]";


            Dictionary<string, string> MediaInformations = new Dictionary<string, string>();

            List<List<string>> Divided_SubPageUrls = new Rule34Tools().DivideObjects(SubPageUrls, (int)Math.Ceiling(SubPageUrls.Count * 0.1f));
            for (int i = 0; i < Divided_SubPageUrls.Count; i++)
            {
                int _i = i;
                SubPageScanTaskGroup.Add(
                    new Task(() =>
                    {
                        for (int j = 0; j < Divided_SubPageUrls[_i].Count; j++)
                        {
                            if (StopAllTasks) return;
                            string SubPageUrl = Divided_SubPageUrls[_i][j];
                            string MediaUrl = new Rule34Tools().Rule34GetMediaUrlFromSubPageUrl(SubPageUrl, httpClient);
                            if (MediaUrl == "")
                            {
                                Textlabel_NowStatus.Text = "You are blocked by server or cancel the tasks.";
                                continue;
                            }
                            string MediaFileIdAsFileStart = SubPageUrl.Split("&")[SubPageUrl.Split("&").Length - 1].Split("=")[1];

                            string MediaFileEnd;
                            if (MediaUrl.Contains("?")) MediaFileEnd = MediaUrl.Split("/")[MediaUrl.Split("/").Length - 1].Split("?")[0].Split(".")[1];
                            else MediaFileEnd = MediaUrl.Split("/")[MediaUrl.Split("/").Length - 1].Split(".")[1];
                            string MediaFileName = MediaFileIdAsFileStart + "." + MediaFileEnd;

                            lock (_Variable_Lock)
                            {
                                MediaInformations[MediaFileName] = MediaUrl;
                                Progressbar_ScanAndDownload.Value++;
                                Textlabel_Progress.Text = $"[{Progressbar_ScanAndDownload.Value}/{SubPageUrls.Count}]";
                            }
                        }
                    })
                    );
            }

            for (int i = 0; i < SubPageScanTaskGroup.Count; i++) SubPageScanTaskGroup[i].Start();

            await Task.WhenAll(SubPageScanTaskGroup.ToArray());

            if (MediaInformations.Count <= 0)
            {
                MessageBox.Show("Scan Failed, you are blocked or cancel all tasks", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            Textlabel_NowStatus.Text = "Finished scanning sub pages";
            Textlabel_Progress.Text = "";
            Progressbar_ScanAndDownload.Value = 0;
            Progressbar_ScanAndDownload.Maximum = 1;

            await Task.Delay(1000);

            Textlabel_NowStatus.Text = "Downloading media";
            Progressbar_ScanAndDownload.Maximum = MediaInformations.Count;


            int RepeatTimes = 1;
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            foreach (KeyValuePair<string, string> MediaInformation in MediaInformations)
            {

                string MediaFileName = DownloadToPath + "\\" + MediaInformation.Key;
                string MediaUrl = MediaInformation.Value;
                HttpClient DownloadHttpClient = new Rule34Tools().GetHttpClientFromConnectionInformation(ConnectionInformation);
                DownloadTaskGroup.Add(new Task(
                    () =>
                    {
                        Stream ResponseStream;
                        while (true)
                        {
                            if (StopAllTasks) return;
                            try
                            {
                                DownloadHttpClient.SendAsync(new HttpRequestMessage { Method = new HttpMethod("HEAD"), RequestUri = new Uri(MediaUrl) }).Result.EnsureSuccessStatusCode();
                                ResponseStream = DownloadHttpClient.GetStreamAsync(MediaUrl).Result;
                                using (FileStream fs = File.Create(MediaFileName))
                                {
                                    ResponseStream.CopyTo(fs);
                                }
                                break;
                            }
                            catch
                            {

                                if (StopAllTasks) return;
                                continue;

                            }
                        }
                        ResponseStream.Close();
                        lock (_Variable_Lock)
                        {
                            Progressbar_ScanAndDownload.Value++;
                            Textlabel_Progress.Text = $"[{Progressbar_ScanAndDownload.Value}/{Progressbar_ScanAndDownload.Maximum}]";
                        }
                    }
                    ));
                if (RepeatTimes == (int)Math.Ceiling(MediaInformations.Count * 0.01f))
                {
                    RepeatTimes = 1;
                    for (int i = 0; i < DownloadTaskGroup.Count; i++)
                    {
                        DownloadTaskGroup[i].Start();
                    }
                    await Task.WhenAll(DownloadTaskGroup);
                    DownloadTaskGroup = new List<Task>();
                    continue;
                }
                RepeatTimes++;



            }
            if (DownloadTaskGroup.Count > 0)
            {
                for (int i = 0; i < DownloadTaskGroup.Count; i++)
                {
                    if (!DownloadTaskGroup[i].IsCompleted)
                    {
                        DownloadTaskGroup[i].Start();
                    }
                }
            }
            sw.Stop();

            Textlabel_NowStatus.Text = $"All done, time used {sw.Elapsed}";
            Textlabel_Progress.Text = "";
            Progressbar_ScanAndDownload.Visible = false;
            await Task.Delay(2000);
            Close();
        }

        private void Button_CancelDownload_Click(object sender, EventArgs e)
        {
            StopAllTasks = true;
            Textlabel_NowStatus.Text = "Stopping all tasks, this may take a while";
            Textlabel_Progress.Text = "";
            Progressbar_ScanAndDownload.Visible = false;
            Button_CancelDownload.Enabled = false;
        }
    }
}
