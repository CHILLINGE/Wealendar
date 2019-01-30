using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Xml.Linq;
using System.Windows.Threading;

namespace Wealendar
{
    /// <summary>
    /// 기상청 API 해석기
    /// </summary>
    public class KMAAPI : IApiParser
    {
        public KMAAPI() : base()
        {
           
        }
        /// <summary>
        /// 날씨 정보 파스
        /// </summary>
        
        /// <param name="data">xml 데이터</param>
        /// <returns>날씨 리스트</returns>
        public WeatherList Parse(string data) // IApiParser 인터페이스의 메서드
        {
            
        }

        private void GetResponse()
        {

        }
    }
}
