using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wealendar
{
    /// <summary>
    /// API에서 받아온 데이터를 처리하는 클래스의 인터페이스
    /// </summary>
    public interface IApiParser
    {
        List<Weather> Parse(string data);
    }
}
