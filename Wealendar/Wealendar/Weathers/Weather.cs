using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wealendar
{
    /// <summary>
    /// 날씨 데이터를 저장하는 클래스
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// 날씨의 지역 (서울, 경기도 등)
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 날씨의 도시
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 날씨의 시간
        /// </summary>
        public DateTime Time { get; set; }

        public CloudStatus Cloud { get; set; }

        public int MaxTemperature { get; set; }

        public int MinTemperature { get; set; }

        public int Reliability { get; set; }
    }
}
