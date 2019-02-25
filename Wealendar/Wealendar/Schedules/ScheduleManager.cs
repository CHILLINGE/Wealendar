using System;
using System.Collections.Generic;
using System.IO;
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
        private Dictionary<string, datapluscolor> Data { get; set; }
        //private Dictionary<string, string> ScheduleColors { get; set; }
        
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
            Data = new Dictionary<string, datapluscolor>();


            string url = filepath;

            if (File.Exists(url)) // 파일이 존재하면
            {
                try
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load(url);
                    XmlNodeList sList = xml.SelectNodes("Schedule/Day");

                    foreach (XmlNode xn in sList)
                    {
                        string d = xn["date"].InnerText;
                        string c = xn["Content"].InnerText;
                        Data[d] = new datapluscolor();
                        Data[d].Contentdata = c;

                        if (xn["Color"] != null)
                        {
                            string e = xn["Color"].InnerText;
                            Data[d].Colorcode = e;
                        }
                        
                        
                        
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("XML 문제 발생\n" + ex);
                }
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
                    new XElement("Content", Data[k].Contentdata),
                    new XElement("Color", Data[k].Colorcode)
                    );
                xroot.Add(xe1);
                xdoc.Save(url);
            }

        }


        public Dictionary<int, string> GetColors(int month)
        {
            Dictionary<int,string> colors = new Dictionary<int,string>();
            
            foreach (var i in Data)
            {
                if (int.Parse(i.Key.Substring(3,2)) == month)
                {
                    int dd = int.Parse(i.Key.Substring(6, 2));
                    string s = i.Value.Colorcode;
                    colors[dd] = s;
                }
            }

            return colors;
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
                return Data[Mydateschedule].Contentdata; //그 날의 일정데이터
            else
                return null; // 없으면 null 반환
        }


        /// <summary>
        /// 원하는 날짜에 데이터 넣기
        /// </summary>
        /// <param name="target">원하는 날짜</param>
        /// <param name="data">넣을 데이터</param>
        /// <param name="color">컬러</param>
        public void SetData(DateTime target, string data, string color)
        {
            string Mydateschedule = target.ToString("yy-MM-dd");
            Data[Mydateschedule] = new datapluscolor();

            Data[Mydateschedule].Contentdata = data;
            Data[Mydateschedule].Colorcode = color;
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
