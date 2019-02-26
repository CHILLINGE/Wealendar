using System;
using System.Windows;
using System.Windows.Input;

namespace Wealendar
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        WeatherManager weather;
        ScheduleManager schedule;
        WeatherList weatherlist;

      

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
                txt_month.Text = _currentMonth.ToString() + ""; // 달력 위의 글자 변경
                
                if (IsLoaded)
                {
                    calendar.SetMonthColors(schedule.GetColors(value));
                }
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
                txt_year.Text = _currentYear.ToString() + ""; // 달력 위의 글자 변경
            }
        }
        


        

        public MainWindow()
        {
            InitializeComponent();

            weather = new WeatherManager();
            schedule = new ScheduleManager("schedule.xml"); // 스케쥴 매니저 초기화

            // 프로퍼티 초기값 설정
            CurrentMonth = DateTime.Now.Month;
            CurrentYear = DateTime.Now.Year;
        }

        // MainWindow 로드 완료 시
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            schedule.Load(); // 스케쥴 정보 로드




            if (DateTime.Now.Hour>=6) weatherlist = weather.GetWeather(DateTime.Now,"서울"); // 현재 날짜에서 3일전 제공된 api 정보
            else weatherlist = weather.GetWeather(DateTime.Now.AddDays(-1), "서울");


            calendar.SelectedDate = DateTime.Now;
            UpdateDetails();

            calendar.SetMonthColors(schedule.GetColors(DateTime.Now.Month));
        }

        // 달력의 날짜를 누를 때 이벤트
        private void CalendarControl_SelectionChanged(object sender, CalendarEventArgs e)
        {
            UpdateDetails();

        }

        void UpdateDetails()
        {
            txt_datenow.Text = calendar.SelectedDate.ToLongDateString(); // 현재 날짜 텍스트 변경
            detail.IsEditMode = false; // 수정중이었으면 취소
            detail.InnerText = schedule.GetData(calendar.SelectedDate); // 불러온 날짜의 데이터 표시하기

            bool flag = false;
            for (int i = 0; i < weatherlist.Count; i++)
            {
                if (weatherlist[i].Time.Date == calendar.SelectedDate.Date)
                {
                    flag = true;
                    txt_weather.Text = string.Format("최고 {0}˚ / 최저 {1}˚ {2}", weatherlist[i].MaxTemperature, weatherlist[i].MinTemperature, weatherlist[i].Cloud);
                }
            }
            if (!flag) txt_weather.Text = "";
        }


        // 월 변경 버튼 클릭
        private void btn_month_up_Click(object sender, RoutedEventArgs e)
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
        // 월 변경 버튼 클릭
        private void btn_month_down_Click(object sender, RoutedEventArgs e)
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

        // 수정 후 저장버튼 클릭
        private void DetailControl_Modified(object sender, DetailModifiedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewValue))
            {
                schedule.SetData(calendar.SelectedDate, e.NewValue, "");
                
            } 
            else
            {

                schedule.SetData(calendar.SelectedDate, e.NewValue, "yellow");
            }
            
            schedule.Save(); // 고칠때마다 저장

            calendar.SetMonthColors(schedule.GetColors(calendar.SelectedDate.Month));
        }


        private void Load_Weather(object sender, MouseEventArgs e)
        {
            weather.LoadWeather();
        }

        private void Calendar_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
