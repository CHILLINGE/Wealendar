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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.ServiceModel.Syndication;

namespace Wealendar
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        WeatherManager weather;


        public MainWindow()
        {
            InitializeComponent();

            weather = new WeatherManager();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            weather.LoadWeather();
        }

        private void CalendarControl_Click(object sender, CalendarEventArgs e)
        {
            MessageBox.Show(e.TargetDate.Day.ToString() + "일 클릭함");
        }
    }
}
