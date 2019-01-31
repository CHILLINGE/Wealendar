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

namespace Wealendar
{
    /// <summary>
    /// CalendarControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CalendarControl : UserControl
    {
        private CalendarControlItemUpg[,] buttons;

        public event EventHandler<CalendarEventArgs> SelectionChanged;




        public int Year
        {
            get { return (int)GetValue(YearProperty); }
            set { SetValue(YearProperty, value); }
        }
        public static readonly DependencyProperty YearProperty =
            DependencyProperty.Register("Year", typeof(int), typeof(CalendarControl), new PropertyMetadata(DateTime.Now.Year, new PropertyChangedCallback(OnMonthChanged)));



        public int Month
        {
            get { return (int)GetValue(MonthProperty); }
            set { SetValue(MonthProperty, value); }
        }
        public static readonly DependencyProperty MonthProperty =
            DependencyProperty.Register("Month", typeof(int), typeof(CalendarControl), new PropertyMetadata(DateTime.Now.Month, new PropertyChangedCallback(OnMonthChanged) ));

        static void OnMonthChanged(DependencyObject dpobj, DependencyPropertyChangedEventArgs e)
        {
            CalendarControl ctl = dpobj as CalendarControl;
            ctl.ChangePage(ctl.Year, ctl.Month);
        }




        public DateTime SelectedDate
        {
            get { return (DateTime)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }
        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register("SelectedDate", typeof(DateTime), typeof(CalendarControl), new PropertyMetadata(DateTime.Now, new PropertyChangedCallback(OnDateChanged)));

        static void OnDateChanged(DependencyObject dpobj, DependencyPropertyChangedEventArgs e)
        {
            CalendarControl ctl = dpobj as CalendarControl;
            
        }




        public CalendarControl()
        {
            InitializeComponent();

            //buttons = new CalendarControlItem[6,7];
            buttons = new CalendarControlItemUpg[6, 7];

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {


                    //CalendarControlItem btn = new CalendarControlItem();



                    //Grid.SetRow(btn, i + 1);
                    //Grid.SetColumn(btn, j);



                    //btn.Click += (sender, e) =>
                    //{
                    //    CalendarControlItem ctl = sender as CalendarControlItem;

                    //    SelectedDate = ctl.TargetDate;
                    //    SelectionChanged?.Invoke(this, new CalendarEventArgs(ctl.TargetDate));
                    //};

                    //maingrid.Children.Add(btn);

                    //buttons[i,j] = btn;

                    CalendarControlItemUpg btn = new CalendarControlItemUpg();
                    btn.InnerBorderBrush = Brushes.Black;
                    btn.Margin = new Thickness(5);

                    Grid.SetRow(btn, i + 1);
                    Grid.SetColumn(btn, j);

                    btn.Click += (sender, e) =>
                    {
                        CalendarControlItemUpg ctl = sender as CalendarControlItemUpg;

                        SelectedDate = ctl.TargetDate;
                        SelectionChanged?.Invoke(this, new CalendarEventArgs(ctl.TargetDate));
                    };

                    maingrid.Children.Add(btn);

                    buttons[i,j] = btn;

                }
            }


            SelectedDate = DateTime.Now;
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ChangePage(Year, Month);
        }


        private void ChangePage(int year, int month)
        {
            int days = DateTime.DaysInMonth(year, month);
            int startday = (int)new DateTime(year, month, 1).DayOfWeek;

            int cnt = 1;
            for (int i = startday; i < startday + days; i++)
            {
                
                buttons[i / 7, i % 7].TargetDate = new DateTime(year, month, cnt++);
            }

            cnt = 0;
            for (int i = startday + days; i < buttons.Length; i++)
            {
                buttons[i / 7, i % 7].TargetDate = new DateTime(year,month, 1).AddMonths(1).AddDays(cnt++);
            }

            cnt = (int)new DateTime(year, month, 1).Subtract(new TimeSpan(startday, 0, 0, 0)).Day - 1;
            for (int i = 0; i < startday; i++)
            {
                buttons[i / 7, i % 7].TargetDate = new DateTime(year, month, 1).AddMonths(-1).AddDays(cnt++);
            }

        }

        
    }

    public class CalendarEventArgs : EventArgs
    {
        public DateTime TargetDate { get; set; }

        public CalendarEventArgs(DateTime targetdate)
        {
            this.TargetDate = targetdate;
        }


    }

}
