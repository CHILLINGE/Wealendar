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
            set { SetValue(YearProperty, value); }
        }
        public static readonly DependencyProperty YearProperty =
            DependencyProperty.Register("Year", typeof(int), typeof(CalendarControl), new PropertyMetadata(DateTime.Now.Year));



        public int Month
        {
            get { return (int)GetValue(MonthProperty); }
            set { SetValue(MonthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Month.  This enables animation, styling, binding, etc...
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
                    int day = i*7 + j + 1;
                    if (day >= 30)
                    {
                        day = 1;
                    }

                    Button btn = new Button();

                    Grid.SetRow(btn, i + 1);
                    Grid.SetColumn(btn, j);

                    btn.Content = day.ToString();

                    btn.Click += (e, sender) => 
                    {
                        Click?.Invoke(this, new CalendarEventArgs(new DateTime(Year, Month, day)));
                    };

                    maingrid.Children.Add(btn);
                    
                    buttons[i,j] = btn;
                    
                    
                }
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
