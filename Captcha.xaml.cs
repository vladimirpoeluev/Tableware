using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tableware
{
    /// <summary>
    /// Логика взаимодействия для Captcha.xaml
    /// </summary>
    public partial class Captcha : Window
    {
        Window _window;
        public Captcha(Window window)
        {
            _window = window;
            _window.IsEnabled = false;
            InitializeComponent();
            
        }
        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        private void Block()
        {
            sec = 30;
            answer.IsEnabled = false;
            buttNext.IsEnabled = false;
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            
        }
        int sec = 30;
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            lbTimer.Content = --sec;
            if(sec == 0)
            {
                dispatcherTimer.Stop();
                answer.IsEnabled = true;
                buttNext.IsEnabled = true;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CaptchaGeneration.CheckCode(answer.Text))
            {
                this.Close();
                _window.IsEnabled = true;
            }
            else
            {
                Block();
                drawing.Source = CaptchaGeneration.GetBitmap();
            }

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            drawing.Source = CaptchaGeneration.GetBitmap();
        }
    }
}
