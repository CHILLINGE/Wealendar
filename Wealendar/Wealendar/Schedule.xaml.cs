using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;


namespace Wealendar
{
    /// <summary>
    /// Schedule.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Schedule : Window
    {
        public Schedule()
        {
            InitializeComponent();
            string url = @".\일정모음.xml";
            
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(url);
                XmlNodeList conList = xml.SelectNodes("Schedule/Day");
                foreach(XmlNode xn in conList)
                {
                    string part1 = xn["date"].InnerText;
                    if (part1 == "190103")
                    {
                        string part2 = xn["Content"].InnerText;
                        sc.AppendText(part2 + "\n");
                    }
                }
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show("XML 문제 발생\n" + ex);
            }
           
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            string url = @".\일정모음.xml";
            string text = sc.Text;
      
            XDocument xdoc = new XDocument(new XDeclaration("1.0", "UTF-8", null));
            XElement xroot = new XElement("Schedule");
            xdoc.Add(xroot);

            XElement xe1 = new XElement("Day",
                //new XAttribute("ID", "190103"),
                new XElement("date", "190101"),
                new XElement("Content", text)
                );
           
            XElement xe2 = new XElement("Day",
                //new XAttribute("ID", "190103"),
                new XElement("date","190106"),
                new XElement("Content", "hey")
                );

            xroot.Add(xe1);
            xroot.Add(xe2);
            xdoc.Save(url);
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            /*
            string url = @".\190103.xml";
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(url);
                XmlNodeList xnList = xml.SelectNodes("Employees/Employee");
                foreach(XmlNode xn in xnList)
                {
                    string part = xn["Content"].InnerText;
                    sc.AppendText(part + "\n");
                }
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show("XML 문제 발생\n" + ex);
            }
            */
        }
    }
}
