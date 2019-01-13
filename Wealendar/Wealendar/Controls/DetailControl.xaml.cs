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
    /// DetailControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DetailControl : UserControl
    {
        /// <summary>
        /// 수정 될 때의 이벤트
        /// </summary>
        public event EventHandler Modified;
        
        /// <summary>
        /// 현재 표시하는 내용
        /// </summary>
        public string InnerText
        {
            get { return (string)GetValue(InnerTextProperty); }
            set { SetValue(InnerTextProperty, value); }
        }
        public static readonly DependencyProperty InnerTextProperty =
            DependencyProperty.Register("InnerText", typeof(string), typeof(DetailControl), new PropertyMetadata("", new PropertyChangedCallback(OnInnerTextChanged)));

        static void OnInnerTextChanged(DependencyObject dpobj, DependencyPropertyChangedEventArgs e)
        {
            DetailControl ctl = dpobj as DetailControl;
            
        }



        /// <summary>
        /// 현재 편집중인지 아닌지 나타내는 프로퍼티
        /// </summary>
        public bool IsEditMode
        {
            get { return (bool)GetValue(IsEditModeProperty); }
            set { SetValue(IsEditModeProperty, value); }
        }
        
        public static readonly DependencyProperty IsEditModeProperty =
            DependencyProperty.Register("IsEditMode", typeof(bool), typeof(DetailControl), new PropertyMetadata(false, new PropertyChangedCallback(OnIsEditModeChanged)));

        static void OnIsEditModeChanged(DependencyObject dpobj, DependencyPropertyChangedEventArgs e)
        {
            DetailControl ctl = dpobj as DetailControl;



            if (e.NewValue.Equals(true))
            {
                ctl.txt_edit.Text = ctl.InnerText;

                ctl.txt_show.Visibility = Visibility.Hidden;
                ctl.txt_edit.Visibility = Visibility.Visible;
                ctl.btn_cancel.Visibility = Visibility.Visible;
                ctl.btn_save.Visibility = Visibility.Visible;
                ctl.btn_edit.Visibility = Visibility.Hidden;
            }
            else
            {
                ctl.txt_show.Visibility = Visibility.Visible;
                ctl.txt_edit.Visibility = Visibility.Hidden;
                ctl.btn_cancel.Visibility = Visibility.Hidden;
                ctl.btn_save.Visibility = Visibility.Hidden;
                ctl.btn_edit.Visibility = Visibility.Visible;
            }
            
        }






        public DetailControl()
        {
            InitializeComponent();
        }
        

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            IsEditMode = true;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            IsEditMode = false;
        }

        // 저장을 누르면
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            IsEditMode = false; // 편집모드를 해제하고
            InnerText = txt_edit.Text; // 수정된 사항을 반영하고
            Modified?.Invoke(this, new EventArgs()); // Modified 이벤트 호출
        }
    }
}
