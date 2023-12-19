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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ManageFrame.Frame = frame;
            ManageFrame.Menu = menu;
            ManageFrame.MainWindow = this;
        }

        private void menu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string selected = (string)menu.SelectedValue;
            MessageBox.Show(selected);
        }

        

        private void menu_Selected(object sender, RoutedEventArgs e)
        {
            
        }

        private void menu_Selected_1(object sender, RoutedEventArgs e)
        {

        }

        private void menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = (string)menu.SelectedValue;
            switch(selected)
            {
                case "Главная":
                    ManageFrame.Frame.Navigate(new MainPage());
                    break;
                case "Продукты":
                    ManageFrame.Frame.Navigate(new ProductСatalogPage1());
                    break;
                case "Заказы":
                    ManageFrame.Frame.Navigate(new Orders());
                    break;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManageFrame.Frame.Navigate(new Entrance());
        }
    }
}
