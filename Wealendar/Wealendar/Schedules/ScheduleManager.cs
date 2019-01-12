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
        public Dictionary<string, string> Data { get; set; }


        /// <summary>
        /// 스케쥴 정보 디스크에서 로딩
        /// </summary>
        public void Load()
        {
            
        }

        /// <summary>
        ///  전체 데이터를 파일에서 저장
        /// </summary>
        public void Save()
        {

        }

        /// <summary>
        /// "메모리에 로딩된" 데이터를 쏴주기
        /// </summary>
        /// <param name="target"></param>
        /// <returns>"그날의 일정"</returns>
        public string GetData(DateTime target)
        {



            return "그 날의 일정데이터";
        }


        /// <summary>
        /// 원하는 날짜에 데이터 넣기
        /// </summary>
        /// <param name="target">원하는 날짜</param>
        /// <param name="data">넣을 데이터</param>
        void SetData(DateTime target, string data)
        {

        }


        /*
        /// <summary>
        /// 저장된 일정 불러오기
        /// </summary>
        /// <returns></returns>
        public List<string> LoadSchedule(string year, string month, string day)
        {
            string filename = year + month + day;
            string url = @".\" + filename + ".xml";

            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(url);
                XmlNodeList conList = xml.SelectNodes("Schedule/Day");
                List<string> reList;
                foreach (XmlNode xn in conList)
                {
                    string part = xn["Content"].InnerText;
                    reList.Add(part);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("XML 문제 발생\n" + ex);
            }
            return reList;
            
        }
        public void SaveSchedule(string year, string month, string day, List<string> content)
        {
            string filename = year + month + day;
            string url = @".\" + filename + ".xml";

            XDocument xdoc = new XDocument(new XDeclaration("1.0", "UTF-8", null));
            XElement xroot = new XElement("Schedule");
            xdoc.Add(xroot);

            XElement xe1 = new XElement("Day",
                new XAttribute("date", ""), 
                new XElement("Content", content)
                );
            xroot.Add(xe1);
            xdoc.Save(url);
        }
        */
    }
}
