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
            int date = 20190128;
            int time = 1800;
            int nx = 59;
            int ny = 126;
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["ServiceKey"] = "yW0fFl3x75%2Fc%2FC1jrkPKbqvt49hJS%2FHnk97M2euq1U3cpz%2FB6PyGwLPndqhOVFspMOXaI%2Fnsv0fQZCTQL2xyXw%3D%3D";
            data["base_date"]= date.ToString();
            data["base_time"] = time.ToString();
            data["nx"] = nx.ToString();
            data["ny"] = ny.ToString();

            path = webclient.GetContent("http://newsky2.kma.go.kr/service/SecndSrtpdFrcstInfoService2/getForecastTimeData", data);
            

        }

        public void LoadWeather()
        {
            XmlDocument docx = new XmlDocument();
            Dictionary<string, string> Result = new Dictionary<string, string>();
            try
            {
                docx.Load(path);
                XmlNodeList xmlNodeList = docx.SelectNodes("weather");

                foreach(XmlNode xml in xmlNodeList)
                {
                    string date = xml["base_date"].InnerText.ToString();
                    string time = xml["base_time"].InnerText.ToString();
                    string weather = xml["fcstValue"].InnerText.ToString();

                    Result[date] = time;
                    Result[time] = weather;
                }
            }

            catch (ArgumentException ex)
            {
                MessageBox.Show("XML 문제 발생\n" + ex);
            }



        }


    }
}
