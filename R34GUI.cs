

namespace Rule34XXXGUI
{
    public partial class R34GUI : Form
    {

        public R34GUI()
        {
            InitializeComponent();
        }


        private void Tool_Button_DisableAllButtons()
        {
            Button_CheckPageNumberOfTags.Enabled = false;
            Button_CheckIfTagsValid.Enabled = false;
            Button_StartDownload.Enabled = false;
        }

        private void Tool_Button_EnableAllButtons()
        {
            Button_StartDownload.Enabled = true;
            Button_CheckIfTagsValid.Enabled = true;
            Button_CheckPageNumberOfTags.Enabled = true;
        }

        //private int Tool_TextLabelTagStatus_NotCheck = -1;
        private int Tool_TextLabelTagStatus_Checking = 0;
        private int Tool_TextLabelTagStatus_ConnectFailed = 1;
        private int Tool_TextLabelTagStatus_NotValid = 2;
        private int Tool_TextLabelTagStatus_Valid = 3;

        private void Tool_SetTextLabelTagStatus(int status)
        {
            switch (status)
            {
                case -1:
                    {
                        Textlabel_tagStatus.Text = "Not Check";
                        Textlabel_tagStatus.ForeColor = Color.Black;
                        break;
                    }
                case 0:
                    {
                        Textlabel_tagStatus.Text = "Checking";
                        Textlabel_tagStatus.ForeColor = Color.Black;
                        break;
                    };
                case 1:
                    {
                        Textlabel_tagStatus.Text = "Connect Failed";
                        Textlabel_tagStatus.ForeColor = Color.Red;
                        break;
                    };
                case 2:
                    {
                        Textlabel_tagStatus.Text = "Not Valid";
                        Textlabel_tagStatus.ForeColor = Color.Red;
                        break;
                    };
                case 3:
                    {
                        Textlabel_tagStatus.Text = "Valid";
                        Textlabel_tagStatus.ForeColor = Color.Green;
                        break;
                    };
                case 4:
                    {
                        Textlabel_tagStatus.Text = "Need to Recheck";
                        Textlabel_tagStatus.ForeColor = Color.Black;
                        break;
                    }
                default:
                    {

                        break;
                    }
            }
        }

        private Dictionary<string, string> Tool_GetConnectionInformation()
        {
            return new Dictionary<string, string>
            {
                { "ProxyAddress", Textbox_Proxy_Address.Text },
                { "HeadersUserAgent", Textbox_RequestsHeaders_UserAgent.Text },
                { "ProxyUserName", Textbox_Proxy_Account.Text },
                { "ProxyPassword", Textbox_Proxy_Password.Text },
                { "UseVerify", Checkbox_Proxy_EnableVerify.Checked.ToString() },
                { "UseTimeoutToCancel", Checkbox_EnableTimeoutToCancel.Checked.ToString() }
            };
        }

        private async void Button_CheckIfTagsValid_ClickAsync(object sender, EventArgs e)
        {

            Tool_Button_DisableAllButtons();

            Tool_SetTextLabelTagStatus(Tool_TextLabelTagStatus_Checking);

            bool TagsIsValid = false;

            Dictionary<string, string> ConnectionInformation = Tool_GetConnectionInformation();
            HttpClient httpClient;
            try
            {
                httpClient = new Rule34Tools().GetHttpClientFromConnectionInformation(ConnectionInformation);
            }
            catch { MessageBox.Show("Proxy Address not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Button_CheckIfTagsValid.Enabled = true; return; }
            try
            {
                TagsIsValid = await new Rule34Tools().Rule34CheckIfTagsValidAsync(Textbox_tagList.Text, httpClient);
            }
            catch
            {


                Tool_SetTextLabelTagStatus(Tool_TextLabelTagStatus_ConnectFailed);
                Tool_Button_DisableAllButtons();
                MessageBox.Show("Connect Failed, check your network configuration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Button_CheckIfTagsValid.Enabled = true;
                return;
            }

            if (!TagsIsValid)
            {
                Tool_SetTextLabelTagStatus(Tool_TextLabelTagStatus_NotValid);
                Tool_Button_DisableAllButtons();
                MessageBox.Show("Tags are not valid or empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Button_CheckIfTagsValid.Enabled = true;
                return;
            }
            Tool_SetTextLabelTagStatus(Tool_TextLabelTagStatus_Valid);
            MessageBox.Show("Tags are valid.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Tool_Button_EnableAllButtons();
            return;
        }

        private async void Button_CheckPageNumberOfTags_ClickAsync(object sender, EventArgs e)
        {
            Button_CheckPageNumberOfTags.Enabled = false;
            List<string> Tags = new Rule34Tools().GetTagListFromTextString(Textbox_tagList.Text);
            string FullUrl = "https://rule34.xxx/index.php?page=post&s=list&tags=" + new Rule34Tools().GetTagsStringFromTagsList(Tags);
            int PageNumber;
            Dictionary<string, string> ConnectionInformation = Tool_GetConnectionInformation();
            HttpClient httpClient = new Rule34Tools().GetHttpClientFromConnectionInformation(ConnectionInformation);
            try
            {
                PageNumber = await new Rule34Tools().Rule34GetPageNumberOfTagsFromUrlAsync(FullUrl, httpClient);
            }
            catch
            {
                MessageBox.Show("An error occurred while getting main pages, please check your network configuration.", "Connect Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Textbox_PageNumber.Text = PageNumber.ToString();
            Button_CheckPageNumberOfTags.Enabled = true;
        }

        private void Textbox_tagList_TextChanged(object sender, EventArgs e)
        {

            Button_CheckPageNumberOfTags.Enabled = false;
            Button_StartDownload.Enabled = false;
            Tool_SetTextLabelTagStatus(-1);
        }

        private void R34GUI_Load(object sender, EventArgs e)
        {
            return;
        }

        private void Button_StartDownload_Click(object sender, EventArgs e)
        {

            Hide();

            int PageNumber;
            try { PageNumber = int.Parse(Textbox_PageNumber.Text); } catch { Show(); MessageBox.Show("Page you input not a integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (PageNumber <= 0)
            {
                Show();
                MessageBox.Show("Are you serious about page number?", "Page Number Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string DownloadToPath;
            // For select folder
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Choose the folder to download to";
                if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                {
                    Show();
                    MessageBox.Show("Not download this time?", "You don't choose a folder", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                DownloadToPath = folderBrowserDialog.SelectedPath;
            }

            string TagsString = new Rule34Tools().GetTagsStringFromTagsList(new Rule34Tools().GetTagListFromTextString(Textbox_tagList.Text));
            string BasicUrl = "https://rule34.xxx/index.php?page=post&s=list&tags=" + TagsString;
            bool UseMultiThread = Checkbox_EnableMultiThread.Checked;
            Dictionary<string, string> ConnectionInformation = Tool_GetConnectionInformation();
            if (ConnectionInformation["HeadersUserAgent"] == "")
            {
                DialogResult dialogResult = MessageBox.Show("You didn't input the User Agent, you might be blocked by server!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                
                if (dialogResult != DialogResult.OK) { Show(); return; }
            }
            
            new R34GUI_Download(BasicUrl, UseMultiThread, ConnectionInformation, PageNumber, DownloadToPath).ShowDialog();


            Show();

        }

    }
}