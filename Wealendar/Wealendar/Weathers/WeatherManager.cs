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
        /// API를 해석하는데 사용할 파서
        /// </summary>
        private readonly IApiParser parser;

        /// <summary>
        /// 웹에 접근하는 클래스
        /// </summary>
        private readonly WebManager webclient;



        public WeatherManager()
        {
            webclient = new WebManager();
            parser = new KMAAPI(); // 기상청 API 파서 활용

            Weather w = new Weather();
            
        }



        public void LoadWeather()
        {
            
                
        }


    }
}
