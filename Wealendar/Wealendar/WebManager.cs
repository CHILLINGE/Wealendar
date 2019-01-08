using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Collections.Specialized;
using System.Web;

namespace Wealendar
{
    /// <summary>
    /// HTTP 접속 클래스
    /// </summary>
    public class WebManager
    {
        

        public WebManager()
        {
            
        }

        /// <summary>
        /// GET 메서드로 내용을 가져온다.
        /// </summary>
        /// <param name="url">가져올 사이트의 주소</param>
        /// <returns>가져온 내용</returns>
        public string GetContent(string url)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            return client.DownloadString(url);
        }

        /// <summary>
        /// GET 메서드로 내용을 가져온다. 매개변수를 설정할 수 있다.
        /// </summary>
        /// <param name="url">가져올 사이트의 주소</param>
        /// <param name="param">매개변수들</param>
        /// <returns>가져온 내용</returns>
        public string GetContent(string url, Dictionary<string, string> param)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;

            NameValueCollection nvdata = new NameValueCollection();
            foreach (var i in param)
            {
                nvdata.Add(i.Key, i.Value);
            }
            client.QueryString = nvdata;

            return client.DownloadString(url);

        }

        /// <summary>
        /// POST 메서드로 내용을 가져온다. 매개변수를 설정할 수 있다.
        /// </summary>
        /// <param name="url">가져올 사이트의 주소</param>
        /// <param name="data">매개변수들</param>
        /// <returns>가져온 내용</returns>
        public string PostContent(string url, Dictionary<string, string> data)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;

            NameValueCollection nvdata = new NameValueCollection();

            foreach (var i in data)
            {
                nvdata.Add(i.Key, i.Value);
            }

            byte[] response = client.UploadValues(url, nvdata);

            return Encoding.UTF8.GetString(response);
            
        }

        
    }
}
