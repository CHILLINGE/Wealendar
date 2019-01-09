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
    public class ScheduleManager
    {
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
                new XAttribute("date", ""), //날짜로 ID구분해서 저장
                new XElement("Content", content)
                );
            xroot.Add(xe1);
            xdoc.Save(url);
        }
        */
    }
}
