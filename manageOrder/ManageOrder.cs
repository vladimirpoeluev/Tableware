using DataManagementTools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tableware
{
    static class ManageOrder
    {
        public static Order Order { get; set; }

        static ManageOrder()
        {
            Order = new Order();
        }

        public static void AddProduct(OrderComponent product)
        {
            for (int i = 0; i < Order.OrderComponents.Count; i++)
            {
                if (Order.OrderComponents[i].Product.ProductArticleNumberId == product.Product.ProductArticleNumberId)
                {
                    Order.OrderComponents[i] = product;
                    return;
                }
            }
            Order.OrderComponents.Add(product);
        }

        public static void RemoveProduct(OrderComponent orderComponent)
        {
            Order.OrderComponents.Remove(orderComponent);
        }

        public static OrderComponent[] GetProduct()
        {
            return Order.OrderComponents.ToArray();
        }
        public static OrderComponent[] GetProduct(string substring)
        {
            List<OrderComponent> list = new List<OrderComponent>();
            foreach (var component in Order.OrderComponents)
            {
                if(component.Product.ProductName.Contains(substring))
                    list.Add(component);
            }
            return list.ToArray();
        }
        private static void GetOrderComponent(Order order)
        {
            ManageData manageData = new ManageData();
            SqlDataReader sqlDataReader = manageData.SqlRequestReader($"select * from [OrderComposition] where IdOrder = {order.Id}");
            while (sqlDataReader.Read())
            {
                order.OrderComponents.Add(new OrderComponent
                {
                    Product = ManageProduct.GetProduct((string)sqlDataReader["ArticleNumber"]),
                    NumberOfProducts = (int)sqlDataReader["Coint"]
                });

            }
        }
        public static Order[] GetOrders()
        {
            List<Order> orders = new List<Order>();

            ManageData manageData = new ManageData();
            SqlDataReader sqlDataReader = manageData.SqlRequestReader("select * from [Order]");
            while (sqlDataReader.Read())
            {
                Order order = new Order();
                order.Id = (int)sqlDataReader["Id"];
                order.Status = (int)sqlDataReader["Status"];
                order.ReceinptCode = (int)sqlDataReader["ReceinptCode"];
                order.OrderDeliveryDate = (DateTime)sqlDataReader["OrderDeliveryDate"];
                order.OrderData = (DateTime)sqlDataReader["OrderData"];
                order.PointsOflssue = (int)sqlDataReader["PointsOflssue"];

                GetOrderComponent(order);
                orders.Add(order);

            }
            sqlDataReader.Close();
            return orders.ToArray();
        }

        public static void CompleteTheOrder()
        {
            
        }
    }
}
