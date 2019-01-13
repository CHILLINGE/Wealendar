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
        /// <summary>
        /// 현재 달력에 표시되는 달
        /// </summary>
        public int CurrentMonth
        {
            get
            {
                return _currentMonth;
            }
            set
            {
                _currentMonth = value;
                calendar.Month = _currentMonth; // 달력의 월을 실제로 변경
                txt_month.Text = _currentMonth.ToString() + "월"; // 달력 위의 글자 변경
            }
        }

        int _currentYear;
        /// <summary>
        /// 현재 달력의 표시되는 년도
        /// </summary>
        public int CurrentYear
        {
            get
            {
                return _currentYear;
            }
            set
            {
                _currentYear = value;
                calendar.Year = _currentYear; // 달력의 년을 실제로 변경
                txt_year.Text = _currentYear.ToString() + "월"; // 달력 위의 글자 변경
            }
        }
        


        

        public MainWindow()
        {
            InitializeComponent();

            weather = new WeatherManager();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 프로퍼티 초기값 설정
            CurrentMonth = DateTime.Now.Month;
            CurrentYear = DateTime.Now.Year;
            

            weather.LoadWeather();
        }

        // 달력의 날짜를 누를 때 이벤트
        private void CalendarControl_SelectionChanged(object sender, CalendarEventArgs e)
        {
            txt_datenow.Text = e.TargetDate.ToLongDateString();

        }

        // 월 변경 버튼 클릭
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
        // 월 변경 버튼 클릭
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

        // 수정 후 저장 클릭
        private void DetailControl_Modified(object sender, EventArgs e)
        {

        }
    }
}
