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
        private Button[,] buttons;

        public event EventHandler<CalendarEventArgs> Click;




        public int Year
        {
            get { return (int)GetValue(YearProperty); }
            set { SetValue(YearProperty, value);
                ChangePage(Year, value);
            }
        }
        public static readonly DependencyProperty YearProperty =
            DependencyProperty.Register("Year", typeof(int), typeof(CalendarControl), new PropertyMetadata(DateTime.Now.Year));



        public int Month
        {
            get { return (int)GetValue(MonthProperty); }
            set { SetValue(MonthProperty, value);
                ChangePage(Year, value);
            }
        }
        public static readonly DependencyProperty MonthProperty =
            DependencyProperty.Register("Month", typeof(int), typeof(CalendarControl), new PropertyMetadata(DateTime.Now.Month));

        

        


        public CalendarControl()
        {
            InitializeComponent();

            buttons = new Button[6,7];

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    
                    
                    CalendarControlItem btn = new CalendarControlItem();

                    Grid.SetRow(btn, i + 1);
                    Grid.SetColumn(btn, j);

                    

                    btn.Click += (e, sender) => 
                    {
                        Click?.Invoke(this, new CalendarEventArgs(new DateTime(Year, Month, 1)));
                    };

                    maingrid.Children.Add(btn);
                    
                    buttons[i,j] = btn;
                    
                    
                }
            }
        }


        private void ChangePage(int year, int month)
        {
            int days = DateTime.DaysInMonth(year, month);
            int startday = (int)new DateTime(year, month, 1).DayOfWeek;

            //for (int i = 0; i < days; i++)
            //{
            //    buttons[(startday + i) / 7, (startday + i) % 7].Content = i+1;
            //}

            int cnt = 1;
            for (int i = startday; i < startday + days; i++)
            {
                buttons[i / 7, i % 7].Content = cnt++;
            }

            cnt = 1;
            for (int i = startday + days; i < buttons.Length; i++)
            {
                buttons[i / 7, i % 7].Content = cnt++;
            }

            cnt = (int)new DateTime(year, month, 1).Subtract(new TimeSpan(startday,0,0,0)).Day;
            for (int i = 0; i < startday; i++)
            {
                buttons[i / 7, i % 7].Content = cnt++;
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
