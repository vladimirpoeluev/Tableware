using DataManagementTools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace Tableware
{
    public enum Sorting
    {
        Desc,
        Asc
    }
    static class ManageProduct
    {
        public static Sorting Sorting { get; set; }
        static ManageProduct()
        {
            Sorting = Sorting.Asc;
        }
        private static Product ConvertAReaderIntoAProduct(SqlDataReader reader)
        {
           
            
            Product product = new Product();
            try
            {
                product.ProductArticleNumberId = (string)reader["ArticleNumber"];
                product.ProductName = (string)reader["Name"];
                product.ProductDescription = (string)reader["Description"];
                product.ProductCategory = (string)reader["Category"];
                
                product.ProductManufacturer = (string)reader["Manufacturer"];
                string cost = reader["Cost"].ToString();
                product.ProductCost = double.Parse(cost);
                string amount = reader["DiscountAmount"].ToString();
                product.ProductDiscountAmount = int.Parse(amount);
                string stock = reader["QuantityInStock"].ToString();
                product.ProductQuantityInStock = int.Parse(amount);
                product.ProductStatus = (string)reader["Status"];
                product.ProductPhoto = (string)reader["Photo"];
            }
            catch(Exception ex)
            {
                
            }
            
            return product; 
        }

        private static List<Product> ConvertAReaderIntoAProducts(SqlDataReader reader)
        {
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product();
                product = ConvertAReaderIntoAProduct(reader);
                products.Add(product);
            }

            return products;

        }
        
        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            ManageData data = new ManageData();

            SqlDataReader reader = data.SqlRequestReader("select * from [Product]" + $"order by Cost {Sorting}");
            products = ConvertAReaderIntoAProducts(reader);

            return products;
        }

        public static Product GetProduct(string id)
        {
            Product product = new Product();

            ManageData data = new ManageData();
            
            SqlDataReader reader = data.SqlRequestReader($"select * from [Product] where ArticleNumber = '{id}'");
            reader.Read();
            product = ConvertAReaderIntoAProduct(reader);
            return product;
            
        }
        public static List<Product> GetProductsMan(string manufacturer)
        {
            List<Product> products = new List<Product>();

            ManageData data = new ManageData();

            SqlDataReader reader = data.SqlRequestReader($"select * from [Product] where Manufacturer = N'{manufacturer}'" + $"order by Cost {Sorting}");
            products = ConvertAReaderIntoAProducts(reader);

            return products;
        }

        
        public static List<Product> GetProducts(string beginning)
        {
            ManageData data = new ManageData();
            List<Product> products = new List<Product>();

            SqlDataReader reader = data.SqlRequestReader($"select * from [Product] where Name like N'%{beginning}%'or " +
                $"Category like N'%{beginning}%' or " +
                $"Description like N'%{beginning}%' or " +
                $"ArticleNumber like N'%{beginning}%' or " +
                $"Manufacturer like N'%{beginning}%'" + $"order by Cost {Sorting}"); ; ;
            products = ConvertAReaderIntoAProducts(reader);
            return products;
        }
    }
}
