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
            string output = getweatherString(time, position);
            string output2 = gettemString(time, position);

            WeatherList weatherlst = new WeatherList();
            
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(output2); // suppose that myXmlString contains "<Names>...</Names>"
            XmlNode xnList = xml.SelectSingleNode("response/body/items/item");

            for (int i = 3; i <= 10; i++)
            {
                Weather tmpWeather = new Weather();
                tmpWeather.Time = time.AddDays(i);
                tmpWeather.MaxTemperature =int.Parse( xnList["taMax" + i.ToString()].InnerText);//int.Parse 는 string을 int로 바꿔준다 
                tmpWeather.MinTemperature = int.Parse(xnList["taMin" + i.ToString()].InnerText);
                weatherlst.Add(tmpWeather);

            }

            return weatherlst;



            
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
