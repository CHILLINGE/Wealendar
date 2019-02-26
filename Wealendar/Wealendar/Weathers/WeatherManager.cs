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

        public WeatherList GetWeather(DateTime time, string position)
        {


            string output = getweatherString(time, getweatherLocation(position));
            string output2 = gettemString(time, gettemLocation(position));

            WeatherList weatherlst = new WeatherList();
            
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(output2); // suppose that myXmlString contains "<Names>...</Names>"
            XmlNode xnList = xml.SelectSingleNode("response/body/items/item");

            XmlDocument xml2 = new XmlDocument();
            xml2.LoadXml(output); // hi2yeoni는 여기에 xml.LoadXml 이라 써서 안됐었다
            XmlNode xn2List = xml2.SelectSingleNode("response/body/items/item");  // hi2yeoni는 여기에 itmes 라 써서 안됐었다

            for (int i = 3; i <= 10; i++)
            {
                Weather tmpWeather = new Weather();


                tmpWeather.Time = time.AddDays(i);


                tmpWeather.MaxTemperature =int.Parse( xnList["taMax" + i.ToString()].InnerText);//int.Parse 는 string을 int로 바꿔준다 
                tmpWeather.MinTemperature = int.Parse(xnList["taMin" + i.ToString()].InnerText);

                tmpWeather.Cloud = xn2List["wf" + i.ToString() + (i <= 7 ? "Pm" : "")].InnerText;

       
                weatherlst.Add(tmpWeather);

            }

            return weatherlst;

        }


        private string gettemLocation(string location)
        {
            switch (location)
            {
                case "서울":
                    return "11B10101";

                case "인천":
                    return "11B20201";

                case "경기":
                    return "11B20601";

                default:
                    return "";
            }
        }

        private string getweatherLocation(string location)
        {
            switch (location)
            {
                case "서울":
                case "인천":
                case "경기":
                    return "11B00000";
                default:
                    return "";
            }
        }

        public void LoadWeather()
        {
            



        }


    }
}
