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
    /// CalendarControlItemUpg.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CalendarControlItemUpg : UserControl
    {

        public event EventHandler<RoutedEventArgs> Click;

        public CalendarControlItemUpg()
        {
            InitializeComponent();
            
        }

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
                this.InnerText = targetdate.Day.ToString();
            }
        }

        public Brush InnerBackground
        {
            get { return (Brush)GetValue(InnerBackgroundProperty); }
            set { SetValue(InnerBackgroundProperty, value); }
        }
        public static readonly DependencyProperty InnerBackgroundProperty =
            DependencyProperty.Register("InnerBackground", typeof(Brush), typeof(CalendarControlItemUpg), new PropertyMetadata(Brushes.Transparent));





        public Brush InnerBorderBrush
        {
            get { return (Brush)GetValue(InnerBorderBrushProperty); }
            set { SetValue(InnerBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty InnerBorderBrushProperty =
            DependencyProperty.Register("InnerBorderBrush", typeof(Brush), typeof(CalendarControlItemUpg), new PropertyMetadata(Brushes.Black));



        public string InnerText
        {
            get { return (string)GetValue(InnerTextProperty); }
            set { SetValue(InnerTextProperty, value); }
        }
        public static readonly DependencyProperty InnerTextProperty =
            DependencyProperty.Register("InnerText", typeof(string), typeof(CalendarControlItemUpg), new PropertyMetadata("0"));

        private void mainborder_Click(object sender, RoutedEventArgs e)
        {
            Click?.Invoke(this, e);
        }
    }
}
