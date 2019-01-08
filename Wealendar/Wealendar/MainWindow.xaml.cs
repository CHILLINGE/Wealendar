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

        int _currentMonth;
        public int CurrentMonth
        {
            get
            {
                return _currentMonth;
            }
            set
            {
                _currentMonth = value;
                calendar.Month = _currentMonth;
                txt_month.Text = _currentMonth.ToString() + "월";
            }
        }

        int _currentYear;
        public int CurrentYear
        {
            get
            {
                return _currentYear;
            }
            set
            {
                _currentYear = value;
                calendar.Year = _currentYear;
                txt_year.Text = _currentYear.ToString() + "월";
            }
        }


        DateTime _currentDate;
        public DateTime CurrentDate
        {
            get
            {
                return _currentDate;
            }
            set
            {
                _currentDate = value;
                txt_datenow.Text = value.ToLongDateString();
            }
        }


        

        public MainWindow()
        {
            InitializeComponent();

            weather = new WeatherManager();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentMonth = DateTime.Now.Month;
            CurrentYear = DateTime.Now.Year;
            CurrentDate = DateTime.Now;

            weather.LoadWeather();
        }

        private void CalendarControl_Click(object sender, CalendarEventArgs e)
        {
            CurrentDate = e.TargetDate;
            
        }

        private void btn_month_up_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMonth < 12)
            {
                CurrentMonth++;
            }
            else
            {
                CurrentYear++;
                CurrentMonth = 1;
            }
                
        }

        private void btn_month_down_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMonth > 1)
            {
                CurrentMonth--;
            } 
            else
            {
                CurrentYear--;
                CurrentMonth = 12;
            }
                
        }
    }
}
