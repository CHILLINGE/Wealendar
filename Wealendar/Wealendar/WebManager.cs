using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Collections.Specialized;

namespace Wealendar
{
    /// <summary>
    /// HTTP 접속 클래스
    /// </summary>
    public class WebManager
    {
        private readonly WebClient client;

        public WebManager()
        {
            client = new WebClient();
            client.Encoding = Encoding.UTF8;
        }

        public string GetContent(string url)
        {
            return client.DownloadString(url);
        }

        public string PostContent(string url, Dictionary<string, string> data)
        {
            NameValueCollection nvdata = new NameValueCollection();

            byte[] response = client.UploadValues(url, nvdata);

            return Encoding.UTF8.GetString(response);
            
        }
    }
}
