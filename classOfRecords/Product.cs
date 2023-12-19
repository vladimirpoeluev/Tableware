using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Tableware
{
    public class Product
    {
        public string ProductArticleNumberId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public string ProductPhoto { get; set; }
        public BitmapImage Photo { get 
            {
                if(ProductPhoto == null)
                {
                    ProductPhoto = "picture.png";
                }
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri($"/Resurce/{this.ProductPhoto}", UriKind.Relative);
                src.EndInit();
                
                return src;
            }
        }
        public string ProductManufacturer { get; set; }
        public double ProductCost { get; set; }
        public int ProductDiscountAmount { get; set; }
        public int ProductQuantityInStock { get; set; }
        public string ProductStatus { get; set; }
        public string Status { 
            get
            {
                return (ProductStatus == "1")? "Нету":"Есть";
            }
        }

        public override string ToString()
        {
            return $"{ProductArticleNumberId} {ProductCost} {ProductName}";
        }
    }
}
