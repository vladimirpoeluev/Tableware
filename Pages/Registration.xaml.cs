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

namespace Tableware
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }
        private bool CheckEmpty()
        {
           

            if (name.Text == String.Empty)
            {
                errLablName.Content += "Поле не заполнено";
                errLablName.Visibility = Visibility.Visible;
                return false;
            }

            if (surname.Text == String.Empty)
            {
                errLablSurn.Content += "Поле не заполнено";
                errLablSurn.Visibility = Visibility.Visible;
                return false;
            }

            if (UserPatronymic.Text == String.Empty)
            {
                errLablPatro.Content += "Поле не заполнено";
                errLablPatro.Visibility = Visibility.Visible;
                return false;
            }

            if (login.Text == String.Empty)
            {
                errLablLog.Content += "Поле не заполнено";
                errLablLog.Visibility = Visibility.Visible;
                return false;
            }
            if (password.Password == String.Empty)
            {
                errLablPass.Content += "Поле не заполнено";
                errLablPass.Visibility = Visibility.Visible;
                return false;
            }

            if (password2.Password == String.Empty)
            {
                errLablPass2.Content += "Поле не заполнено";
                errLablPass2.Visibility = Visibility.Visible;
                return false;
            }
            return true;
        }
        private void ClearErr()
        {
            errLablName.Content = String.Empty;
            errLablName.Visibility = Visibility.Collapsed;
            
            errLablSurn.Content = String.Empty;
            errLablSurn.Visibility = Visibility.Collapsed;

            errLablPatro.Content = String.Empty;
            errLablPatro.Visibility = Visibility.Collapsed;

            errLablPatro.Content = String.Empty;
            errLablPatro.Visibility = Visibility.Collapsed;

            errLablLog.Content = String.Empty;
            errLablLog.Visibility = Visibility.Collapsed;

            errLablPass.Content = String.Empty;
            errLablPass.Visibility = Visibility.Collapsed;

            errLablPass2.Content = String.Empty;
            errLablPass2.Visibility = Visibility.Visible;
        }

        private bool CheckPassword(string password)
        {
            if (password.Length > 50)
            {
                errLablPass.Content += "Пароль должен быть меньше 50 символов";
                errLablPass.Visibility = Visibility.Visible;
                return false;
            }
            
            if (password.Length < 8)
            {
                errLablPass.Content += "Пароль должен быть больше 7 символов";
                errLablPass.Visibility = Visibility.Visible;
                return false;
            }
                
            if (!password.Any(char.IsLower))
            {
                errLablPass.Content += "В пароле нету букв нижнего регистра";
                errLablPass.Visibility = Visibility.Visible;
                return false;
            }
                
            if (!password.Any(char.IsDigit))
            {
                errLablPass.Content += "В пароле нету цифр";
                errLablPass.Visibility = Visibility.Visible;
                return false;
            }
                
            if (!password.Any(char.IsUpper))
            {
                errLablPass.Content += "В пароле нету букв верхнего регистра";
                errLablPass.Visibility = Visibility.Visible;
                return false;
            }
                
            if (password.Intersect("*&%$#^").Count() == 0)
            {
                errLablPass.Content += "В пароле нету спец.символов";
                errLablPass.Visibility = Visibility.Visible;
                return false;
            }
                
            if (password != password2.Password)
            {
                errLablPass.Content += "Пароли не совпадают";
                errLablPass.Visibility = Visibility.Visible;
                return false;
            }
            return true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            ClearErr();
            if (!CheckEmpty())
                return;

            if (!CheckPassword(password.Password))
                return;
           
            User user = new User();
            user.UserName = name.Text;
            user.IDRole = 3;
            user.UserPatronymic = UserPatronymic.Text;
            user.UserSurname = surname.Text;
            try
            {
                if (UserRegistration.Registration(user, login.Text, password.Password))
                {
                    MessageBox.Show("Учетная запись успешно сделана");
                    if (UserInput.UserAuthentication(login.Text, password.Password))
                    {
                        ManageFrame.Frame.Navigate(new MainPage());
                    }
                    else
                    {
                        ManageFrame.Frame.Navigate(new Entrance());
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Что то пошло не так");
            }
            
        }
    }
}
