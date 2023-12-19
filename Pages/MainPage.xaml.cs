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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            ManageFrame.Menu.Items.Clear();
            ManageFrame.Menu.Items.Add("Главная");
            ManageFrame.Menu.Items.Add("Продукты");
            ManageFrame.Menu.Items.Add("Заказы");
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            lbName.Content = UserInput.User.UserName;
            lbSurname.Content = UserInput.User.UserSurname;
            lbPatronymic.Content = UserInput.User.UserPatronymic;
        }
    }
}
