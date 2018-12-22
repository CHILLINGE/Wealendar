using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Weather> Parse(string data) // IApiParser 인터페이스의 메서드
        {
            List<Weather> lst = new List<Weather>();


            return lst;
        }
    }
}
