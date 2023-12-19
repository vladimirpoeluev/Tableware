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
using System.Xml.Linq;

namespace Tableware
{
    /// <summary>
    /// Логика взаимодействия для Entrance.xaml
    /// </summary>
    public partial class Entrance : Page
    {
        public Entrance()
        {
            InitializeComponent();
            ManageFrame.Menu.Items.Clear();
            txbLogin.Text = SavePassword.GetLogin();
            pbxPassword.Password = SavePassword.GetPassword();
        }
        private bool CheckEmpty()
        {
            if (txbLogin.Text == String.Empty)
            {
                errLog.Content += "Поле не заполнено";
                errLog.Visibility = Visibility.Visible;
                return false;
            }
            if (pbxPassword.Password == String.Empty)
            {
                errPass.Content += "Поле не заполнено";
                errPass.Visibility = Visibility.Visible;
                return false;
            }
            return true;
        }
        private void ClearErr()
        {
            errLog.Content = String.Empty;
            errLog.Visibility = Visibility.Collapsed;

            errPass.Content = String.Empty;
            errPass.Visibility = Visibility.Collapsed;
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (new Captcha(ManageFrame.MainWindow)).Show();
            ClearErr();
            if (!CheckEmpty())
            {
                return;
            }
            try
            {
                if (UserInput.UserAuthentication(txbLogin.Text, pbxPassword.Password))
                {
                    if ((bool)remember.IsChecked)
                    {
                        SavePassword.Save(txbLogin.Text, pbxPassword.Password);
                    }
                    ManageFrame.Frame.Navigate(new MainPage());
                }
                else
                {
                    errPass.Content += "Данные введены неверно";
                    errPass.Visibility = Visibility.Visible;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Что то пошло не так");
            }
            
                
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            (new Captcha(ManageFrame.MainWindow)).Show();
            ManageFrame.Frame.Navigate(new Registration());
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            Label lable = (Label)sender;
            lable.Foreground = Brushes.LightBlue;

        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            Label lable = (Label)sender;
            lable.Foreground = Brushes.Black;

        }
    }
}
