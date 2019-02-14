using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wealendar
{
    public interface IScheduleManager
    {

        
        /// <summary>
        /// 전체 데이터를 파일에서 로드
        /// </summary>
        void Load();

        
        /// <summary>
        /// 전체 데이터를 파일에 저장
        /// </summary>
        void Save();

        
        /// <summary>
        /// 원하는 날짜의 데이터 가져오기
        /// </summary>
        /// <param name="target">원하는 날짜</param>
        /// <returns></returns>
        string GetData(DateTime target);


        /// <summary>
        /// 원하는 날짜에 데이터 넣기
        /// </summary>
        /// <param name="target">원하는 날짜</param>
        /// <param name="data">넣을 데이터</param>
        void SetData(DateTime target, string data, string color);
    }
}
