using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



        public WeatherManager()
        {
            webclient = new WebManager();
            Weather w = new Weather();

            Dictionary<string, string> data = new Dictionary<string, string>();
            data["ServiceKey"] = "yW0fFl3x75%2Fc%2FC1jrkPKbqvt49hJS%2FHnk97M2euq1U3cpz%2FB6PyGwLPndqhOVFspMOXaI%2Fnsv0fQZCTQL2xyXw%3D%3D";
            data["base_date"] = 20190128.ToString();
            data["base_time"] = 0500.ToString();
            data["nx"] = 59.ToString();
            data["ny"] = 126.ToString();


            webclient.GetContent("http://newsky2.kma.go.kr/service/SecndSrtpdFrcstInfoService2", data);
        }



        public void LoadWeather(string location,DateTime target)
        {
            
                
        }


    }
}
