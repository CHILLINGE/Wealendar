using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Wealendar
{
    public class CalendarControlItem : Button
    {


        //public int Day
        //{
        //    get { return (int)GetValue(DayProperty); }
        //    set { SetValue(DayProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Day.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty DayProperty =
        //    DependencyProperty.Register("Day", typeof(int), typeof(CalendarControlItem), new PropertyMetadata(0));

        //static void OnDayChanged(DependencyObject dpobj, DependencyPropertyChangedEventArgs e)
        //{
        //    CalendarControlItem ctl = dpobj as CalendarControlItem;
        //    ctl.Content = e.NewValue.ToString();
        //}

        private DateTime targetdate;
        public DateTime TargetDate
        {
            get
            {
                return targetdate;
            }
            set
            {
                targetdate = value;
                this.Content = targetdate.Day.ToString();
            }
        }


    }
}
