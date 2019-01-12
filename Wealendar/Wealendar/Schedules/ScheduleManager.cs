using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace Wealendar
{
    public class ScheduleManager : IScheduleManager
    {
        private Dictionary<string, string> Data { get; set; }

        /// <summary>
        /// 쓰고 읽을 파일의 경로를 지정하는 변수
        /// </summary>
        private string filepath;

        public ScheduleManager(string path)
        {
            filepath = path;
        }

        /// <summary>
        /// 스케쥴 정보 디스크에서 로딩
        /// </summary>
        public void Load()
        {
            string url = filepath;

            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(url);
                XmlNodeList sList = xml.SelectNodes("Schedule/Day");

                foreach (XmlNode xn in sList)
                {
                    string d = xn["date"].InnerText;
                    string c = xn["Content"].InnerText;
                    Data[d] = c;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("XML 문제 발생\n" + ex);
            }


        }

        /// <summary>
        ///  전체 데이터를 파일에 저장
        /// </summary>
        public void Save()
        {
            string url = filepath;

            XDocument xdoc = new XDocument(new XDeclaration("1.0", "UTF-8", null));
            XElement xroot = new XElement("Schedule");
            xdoc.Add(xroot);

            List<string> list = new List<string>(Data.Keys);

            foreach (string k in list) {
                XElement xe1 = new XElement("Day",
                    new XElement("date", k),
                    new XElement("Content", Data[k])
                    );
                xroot.Add(xe1);
                xdoc.Save(url);
            }

        }

        /// <summary>
        /// "메모리에 로딩된" 데이터를 쏴주기
        /// </summary>
        /// <param name="target"></param>
        /// <returns>"그날의 일정"</returns>
        public string GetData(DateTime target)
        {
            string Mydateschedule = target.ToString("yy-MM-dd");

            if (Data.ContainsKey(Mydateschedule)) //일정이 있는지 구분
                return Data[Mydateschedule]; //그 날의 일정데이터
            else
                return null; // 없으면 null 반환
        }


        /// <summary>
        /// 원하는 날짜에 데이터 넣기
        /// </summary>
        /// <param name="target">원하는 날짜</param>
        /// <param name="data">넣을 데이터</param>
        public void SetData(DateTime target, string data)
        {
            string Mydateschedule = target.ToString("yy-MM-dd");

            Data[Mydateschedule] = data;
        }

        /// <summary>
        /// 일정이 있는지 없는지 확인
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool DataExists(DateTime target)
        {
            string Mydateschedule = target.ToString("yy-MM-dd");

            return Data.ContainsKey(Mydateschedule);
        }
    }
}
