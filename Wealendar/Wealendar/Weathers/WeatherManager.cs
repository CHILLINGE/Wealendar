using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Xml;
using System.Xml.Linq;
using System.Web;
using System.Diagnostics;

namespace Wealendar
{
    /// <summary>
    /// 날씨 정보를 가져오는 매니저 클래스
    /// </summary>
    public class WeatherManager
    {
 
        /// <summary>
        /// 웹에 접근하는 클래스
        /// </summary>
        private readonly WebManager webclient;
        private string path;
        private string path2;

        public WeatherManager()
        {
            webclient = new WebManager();
            
            


        }

        public string getweatherString(DateTime time, string position)
        {
            string basedate = time.ToString("yyyyMMdd")+"0600"; // 인자로 받은 날을 
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["ServiceKey"] = "yW0fFl3x75%2Fc%2FC1jrkPKbqvt49hJS%2FHnk97M2euq1U3cpz%2FB6PyGwLPndqhOVFspMOXaI%2Fnsv0fQZCTQL2xyXw%3D%3D";
            data["tmFc"] = basedate;
            data["regId"] = position;
            //data["numOfRows"] = "10";
            //data["pageNo"] = "2";

            path = webclient.GetContent("http://newsky2.kma.go.kr/service/MiddleFrcstInfoService/getMiddleLandWeather", data);

            return path;
        }

        public string gettemString(DateTime time, string position)
        {
            string basedate = time.ToString("yyyyMMdd") + "0600"; // 인자로 받은 날을 
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["ServiceKey"] = "yW0fFl3x75%2Fc%2FC1jrkPKbqvt49hJS%2FHnk97M2euq1U3cpz%2FB6PyGwLPndqhOVFspMOXaI%2Fnsv0fQZCTQL2xyXw%3D%3D";
            data["tmFc"] = basedate;
            data["regId"] = position;
            //data["numOfRows"] = "10";
            //data["pageNo"] = "2";

            path2 = webclient.GetContent("http://newsky2.kma.go.kr/service/MiddleFrcstInfoService/getMiddleTemperature", data);

            return path2;
        }

        public Weather GetWeather(DateTime time, string position)
        {
            string output = getweatherString(time, position);
            string output2 = gettemString(time, position);

            string tmpoutput = "<?xml version=\"1.0\" encoding=\"UTF - 8\" standalone=\"yes\"?><response><header><resultCode>0000</resultCode><resultMsg>OK</resultMsg></header><body><items><item><regId>11B20201</regId><taMax10>7</taMax10><taMax3>2</taMax3><taMax4>2</taMax4><taMax5>4</taMax5><taMax6>5</taMax6><taMax7>5</taMax7><taMax8>6</taMax8><taMax9>7</taMax9><taMin10>2</taMin10><taMin3>-2</taMin3><taMin4>-4</taMin4><taMin5>-5</taMin5><taMin6>-2</taMin6><taMin7>-1</taMin7><taMin8>0</taMin8><taMin9>1</taMin9></item></items><numOfRows>10</numOfRows><pageNo>1</pageNo><totalCount>1</totalCount></body></response>";

            Weather weather = new Weather();
            
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(tmpoutput); // suppose that myXmlString contains "<Names>...</Names>"
            Console.WriteLine(tmpoutput);
            XmlNodeList xnList = xml.SelectNodes("/response/header");
            //foreach (XmlNode xn in xnList)
            //{
            //    string firstName = xn["FirstName"].InnerText;
            //    string lastName = xn["LastName"].InnerText;
            //    Console.WriteLine("Name: {0} {1}", firstName, lastName);
            //}

            // 여기에 xml 해석해서 Weather 클래스에 채워넣기

            return weather;



            
            //XmlDocument docx = new XmlDocument();
            //Dictionary<string, string> Result = new Dictionary<string, string>();
            //try
            //{
            //    docx.Load(path);
            //    XmlNodeList xmlNodeList = docx.SelectNodes("weather");

            //    foreach (XmlNode xml in xmlNodeList)
            //    {
            //        string Date = xml["baseDate"].InnerText.ToString();
            //        string Time = xml["baseTime"].InnerText.ToString();
            //        string Weather = xml["fcstValue"].InnerText.ToString();

            //        /*
            //        Result[date] = time;
            //        Result[time] = weather;
            //        */
            //    }
            //}

            //catch (ArgumentException ex)
            //{
            //    MessageBox.Show("XML 문제 발생\n" + ex);
            //}
            

        }

        public void LoadWeather()
        {
            



        }


    }
}
