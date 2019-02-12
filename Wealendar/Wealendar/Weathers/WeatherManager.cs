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

        public WeatherManager()
        {
            webclient = new WebManager();
            
            

        }

        public string getAPIString(DateTime time, int position)
        {
            string basedate = time.ToString("yyyyMMdd")+"0600"; // 인자로 받은 날을 
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["ServiceKey"] = "yW0fFl3x75%2Fc%2FC1jrkPKbqvt49hJS%2FHnk97M2euq1U3cpz%2FB6PyGwLPndqhOVFspMOXaI%2Fnsv0fQZCTQL2xyXw%3D%3D";
            data["tmFc"] = basedate;
            data["stnId"] = position.ToString();
            //data["numOfRows"] = "10";
            //data["pageNo"] = "2";

            path = webclient.GetContent("http://newsky2.kma.go.kr/service/MiddleFrcstInfoService/getMiddleForecast", data);

            return path;
        }

        public Weather GetWeather(DateTime time, int position)
        {
            string output = getAPIString(time, position);


            Weather weather = new Weather();

            // 여기에 xml 해석해서 Weather 클래스에 채워넣기

            return weather;



            
            XmlDocument docx = new XmlDocument();
            Dictionary<string, string> Result = new Dictionary<string, string>();
            try
            {
                docx.Load(path);
                XmlNodeList xmlNodeList = docx.SelectNodes("weather");

                foreach (XmlNode xml in xmlNodeList)
                {
                    string Date = xml["baseDate"].InnerText.ToString();
                    string Time = xml["baseTime"].InnerText.ToString();
                    string Weather = xml["fcstValue"].InnerText.ToString();

                    /*
                    Result[date] = time;
                    Result[time] = weather;
                    */
                }
            }

            catch (ArgumentException ex)
            {
                MessageBox.Show("XML 문제 발생\n" + ex);
            }
            

        }

        public void LoadWeather()
        {
            



        }


    }
}
