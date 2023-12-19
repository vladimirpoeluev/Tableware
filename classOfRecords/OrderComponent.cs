using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tableware
{
    public class OrderComponent
    {
        public Product Product { get; set; }
        public int NumberOfProducts {  get; set; }
        public override string ToString()
        {
            return $"Название: {Product.ProductName} Количество: {NumberOfProducts}";
        }
    }
}
