using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tableware
{
    /// <summary>
    /// Логика взаимодействия для ProductСatalogPage1.xaml
    /// </summary>
    public partial class ProductСatalogPage1 : Page
    {
        public List<Product> _products = new List<Product>();
        public ProductСatalogPage1()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ManageFrame.Frame.Navigate(new Description(((Product)listOfProducts.SelectedValue).ProductArticleNumberId));
        }
        
        private void LoadManufacture()
        {
            foreach (string m in ManageManufacturer.Manufacturer())
                maufacture.Items.Add(m);
        }
        private void LoadProduct()
        {

            List<Product> list = new List<Product>();
            Thread thread = new Thread(() =>
            {
                list = ManageProduct.GetProducts();
            });
            Application.Current.Dispatcher.BeginInvoke(
            DispatcherPriority.Background, new Action(() => {
                listOfProducts.ItemsSource = list;
                
            }));
            
            thread.Start();
        }
        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            LoadManufacture();
            LoadProduct();
            
        }

        
        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Product> list = new List<Product>();
            string searchText = search.Text;
            Thread thread = new Thread(() =>
            {
                
                list = ManageProduct.GetProducts(searchText);

                Application.Current.Dispatcher.BeginInvoke(
            DispatcherPriority.Background, new Action(() => {
                listOfProducts.ItemsSource = list;
            }));
            });
            

            thread.Start();
        }

       

        private void maufacture_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (maufacture.SelectedIndex == 0)
            {
                LoadProduct();
                return;
            }
            string selectText = maufacture.SelectedValue.ToString();
            List<Product> list = new List<Product>();
            
            

            Thread thread = new Thread(() =>
            {

                list = ManageProduct.GetProductsMan(selectText);

                Application.Current.Dispatcher.BeginInvoke(
            DispatcherPriority.Background, new Action(() => {
                listOfProducts.ItemsSource = list;
            }));
            });


            thread.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManageProduct.Sorting = Sorting.Asc;
            List<Product> list = new List<Product>();
            
            Thread thread = new Thread(() =>
            {
                list = list = ManageProduct.GetProducts(); 
                Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Background, new Action(() => {
                listOfProducts.ItemsSource = list;
            }));
            });
            
            thread.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ManageProduct.Sorting = Sorting.Desc;
            List<Product> list = new List<Product>();
            Thread thread = new Thread(() =>
            {
                list = list = ManageProduct.GetProducts();
                Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Background, new Action(() => {
                listOfProducts.ItemsSource = list;
            }));
            });
            
            thread.Start();
        }
    }
}
