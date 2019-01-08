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
