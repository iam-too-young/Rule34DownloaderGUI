using System.Net;
using HtmlAgilityPack;

namespace Rule34XXXGUI
{
    internal class Rule34Tools
    {
        public List<List<T>> DivideObjects<T>(List<T> ObjectsList, int HowManyInOneGroup)
        {
            List<List<T>> DividedObjects = new List<List<T>>();
            List<T> Temp = new List<T>();
            for (int i = 0; i < ObjectsList.Count; i += HowManyInOneGroup)
            {
                for (int j = i; (j - i) < HowManyInOneGroup; j++)
                {
                    try
                    {

                        Temp.Add(ObjectsList[j]);

                    }
                    catch
                    {
                        // do sth.
                    }

                }
                DividedObjects.Add(Temp);
                Temp = new List<T>();
            }
            return DividedObjects;
        }
        public HttpClient GetHttpClient(string ProxyUrl = "", string HeadersUserAgent = "", string UserName = "", string Password = "", bool UseVerify = false, bool UseTimeoutToCancel = false)
        {
            if (ProxyUrl == "") return new HttpClient();

            HttpClientHandler handler = new HttpClientHandler();
            WebProxy proxy = new WebProxy();

            proxy.Address = new Uri(ProxyUrl);
            if (UserName != "" || Password != "")
            {
                handler.Credentials = new NetworkCredential(UserName, Password);
            }
            handler.Proxy = proxy;

            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            if (!UseVerify) handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            HttpClient httpClient = new HttpClient(handler);

            if (HeadersUserAgent != "")
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", HeadersUserAgent);
            }
            if (UseTimeoutToCancel) httpClient.Timeout = TimeSpan.FromSeconds(10);

            return httpClient;

        }
        public HttpClient GetHttpClientFromConnectionInformation(Dictionary<string, string> ConnectionInformation)
        {
            return GetHttpClient(
            ProxyUrl: ConnectionInformation["ProxyAddress"],
            HeadersUserAgent: ConnectionInformation["HeadersUserAgent"],
            UserName: ConnectionInformation["ProxyUserName"],
            Password: ConnectionInformation["ProxyPassword"],
            UseVerify: bool.Parse(ConnectionInformation["UseVerify"]),
            UseTimeoutToCancel: bool.Parse(ConnectionInformation["UseTimeoutToCancel"])
            );
        }
        public string GetTagsStringFromTagsList(List<string> TagList)
        {
            string TagsString = "";
            for (int i = 0; i < TagList.Count; i++)
            {
                if (i == TagList.Count - 1)
                {
                    TagsString += TagList[i];
                    break;
                }

                TagsString = TagsString + TagList[i];
                TagsString = TagsString + "+";
            }
            return TagsString;
        }
        public List<string> GetTagListFromTextString(string TagsString)
        {
            List<string> Tags = new List<string>();
            for (int i = 0; i < TagsString.Split("\r\n").Length; i++)
            {
                if (TagsString.Split("\r\n")[i] == "")
                {
                    return new List<string>();
                }
                if (TagsString.Split("\r\n")[i].Contains(" "))
                {
                    return new List<string>();
                }
                Tags.Add(TagsString.Split("\r\n")[i]);
            }
            return Tags;
        }
        public async Task<bool> Rule34CheckIfTagsValidAsync(string TagsText, HttpClient httpClient)
        {
            if (TagsText == String.Empty)
            {
                return false;
            }
            List<string>? Tags = GetTagListFromTextString(TagsText);
            if (Tags == null)  return false;
            if (Tags.Count <= 0) return false;
            string TagsString = GetTagsStringFromTagsList(Tags);
            HttpResponseMessage Response = await httpClient.GetAsync("https://rule34.xxx/index.php?page=post&s=list&tags=" + TagsString);

            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(await Response.Content.ReadAsStringAsync());
            HtmlNodeCollection htmlNodes = htmlDocument.DocumentNode.SelectNodes(@"//div/h1");
            if (htmlNodes != null)
            {
                return false;
            }

            return true;
        }
        public async Task<int> Rule34GetPageNumberOfTagsFromUrlAsync(string url, HttpClient httpClient)
        {
            
            HttpResponseMessage Response = await httpClient.GetAsync(url);

            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(await Response.Content.ReadAsStringAsync());
            HtmlNodeCollection htmlNodes = htmlDocument.DocumentNode.SelectNodes(@"//div/a");
            for (int i = 0; i < htmlNodes.Count; i++)
            {
                if (htmlNodes[i].GetAttributeValue("alt", "") == "last page")
                {
                    string PidString = htmlNodes[i].GetAttributeValue("href", "").Split("=")[htmlNodes[i].GetAttributeValue("href", "").Split("=").Length - 1];
                    return int.Parse(PidString) / 42 + 1;
                }
            }
            return 1;
        }
        public List<string> Rule34GetSubPagesUrlsFromMainPageUrl(string url, HttpClient httpClient) {
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();

            HttpResponseMessage Response;
            int RetryTimes = 0;
            while (true)
            {
                try
                {
                    Response = httpClient.GetAsync(url).Result;
                } catch { RetryTimes++; continue; }
                if (Response.StatusCode == HttpStatusCode.OK)
                {
                    break;
                }
                RetryTimes++;
                if (RetryTimes > 5)
                {
                    return new List<string>();
                }
            }
            
            string HtmlString = Response.Content.ReadAsStringAsync().Result;
            htmlDocument.LoadHtml(HtmlString);
            HtmlNodeCollection Nodes = htmlDocument.DocumentNode.SelectNodes("//span/a");
            List<string> SubPagesUrls = new List<string>();
            for (int i = 0; i < Nodes.Count; i++)
            {
                if (Nodes[i].GetAttributeValue("id", "").StartsWith("p"))
                {
                    if (!string.IsNullOrEmpty(Nodes[i].GetAttributeValue("href", String.Empty)))
                    {
                        SubPagesUrls.Add(Nodes[i].GetAttributeValue("href", String.Empty));
                    }
                }
            }
            return SubPagesUrls;
        }
        public string Rule34GetMediaUrlFromSubPageUrl(string url, HttpClient httpClient)
        {
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            HttpResponseMessage Response;
            int RetryTimes = 0;
            while (true)
            {
                try
                {
                    Response = httpClient.GetAsync(url).Result;
                } catch { RetryTimes++; continue; }
                if (Response.StatusCode == HttpStatusCode.ServiceUnavailable) continue;
                if (Response.StatusCode == HttpStatusCode.OK) break;
                if (Response.StatusCode == HttpStatusCode.Forbidden) return "";
                RetryTimes++;
                if (RetryTimes == 20000)
                {
                    return "";
                }
            }
            htmlDocument.LoadHtml(Response.Content.ReadAsStringAsync().Result);
            HtmlNodeCollection? VideoNodes = htmlDocument.DocumentNode.SelectNodes("//video/source");
            if (VideoNodes is null)
            {
                // Get the image
                HtmlNodeCollection ImageNodes = htmlDocument.DocumentNode.SelectNodes("//img");
                for (int i = 0;i < ImageNodes.Count;i++)
                {
                    if (ImageNodes[i].GetAttributeValue("id", "") == "image")
                    {
                        if (ImageNodes[i].GetAttributeValue("src", "") == "") continue;
                        return ImageNodes[i].GetAttributeValue("src", "");
                    }
                }
                return "";
            }
            for (int i = 0; i < VideoNodes.Count;i++)
            {
                if (VideoNodes[i].GetAttributeValue("type", String.Empty) != String.Empty)
                {
                    return VideoNodes[i].GetAttributeValue("src", "");
                }
            }
            return "";
            // Get the video
        }
        
    }
}
