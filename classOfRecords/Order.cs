using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tableware
{
    public class Order
    {
        public int Id { get; set; }
        public int PointsOflssue {  get; set; }
        public int ReceinptCode { get; set; }
        public List<OrderComponent> OrderComponents { get; set; } = new List<OrderComponent>();
        public int Status { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public DateTime OrderData { get; set;}

    }
}
