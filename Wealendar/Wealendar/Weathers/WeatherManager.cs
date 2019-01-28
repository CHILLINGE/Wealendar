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
        public string weather = "";


        public WeatherManager()
        {
            webclient = new WebManager();

        }



        public void LoadWeather()
        {
            XmlDocument docX = new XmlDocument();

            try
            {
                //docX.Load();//url xml 파일 로드
            }
            catch
            {
                return;
            }
            XmlNodeList hourList = docX.GetElementsByTagName("hour");
            XmlNodeList tempList = docX.GetElementsByTagName("temp");
            XmlNodeList weatherList = docX.GetElementsByTagName("weather");

            weather = " = 지역 날씨 =\n";
            weather += hourList[0].InnerText + "시 : " + tempList[0].InnerText + "<" + weatherList[0].InnerText + ">\n";
            weather += hourList[3].InnerText + "시 : " + tempList[3].InnerText + "<" + weatherList[3].InnerText + ">\n";
            weather += hourList[6].InnerText + "시 : " + tempList[6].InnerText + "<" + weatherList[6].InnerText + ">\n";
            weather += hourList[9].InnerText + "시 : " + tempList[9].InnerText + "<" + weatherList[9].InnerText + ">\n";
            
        }


    }
}
