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
    /// Логика взаимодействия для Description.xaml
    /// </summary>
    public partial class Description : Page
    {
        Product Product { get; set; }
        public Description(string id)
        {
            Product = ManageProduct.GetProduct(id);
            InitializeComponent();
            
            
        }
        private void CheckAdmin()
        {
            
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
            if(Product.ProductPhoto != null)
            {

                Image i = image;
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri($"/Resurce/{Product.ProductPhoto}", UriKind.Relative);
                src.EndInit();
                i.Source = src;
               
                //int q = src.PixelHeight;        // Image loads here
                

            }
            description1.Content = "Название: " + Product.ProductName + "\n";
            description1.Content += "Номер товара: " + Product.ProductArticleNumberId + "\n";
            description1.Content += "Категория товара: " + Product.ProductCategory + "\n";
            description1.Content += "Производитель товара: " + Product.ProductManufacturer + "\n";
            description1.Content += "Цена товара: " + Product.ProductCost + "\n";
            description1.Content += "Количество на скаладе: " + Product.ProductQuantityInStock + "\n";
            description2.Content = Product.ProductDescription;
        }


        uint value = 0;
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            uint newValue = 0;
            if (uint.TryParse(tbxNumber.Text, out newValue))
            {
                if(Product.ProductQuantityInStock >= newValue)
                value = newValue;
            }
            tbxNumber.Text = value.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Product.ProductQuantityInStock > value)
                tbxNumber.Text = (++value).ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(uint.Parse(tbxNumber.Text) != 0)
            tbxNumber.Text = (--value).ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(value != 0)
            {
                ManageOrder.AddProduct(new OrderComponent()
                {
                    Product = Product,
                    NumberOfProducts = (int)value
                });
                ((Button)sender).Background = Brushes.White;
            }
            
        }
    }
}
