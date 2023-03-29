using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    internal class OrderDetails
    {
        public Commodity Commodity { get; set; }
        public int Quantity { get; set; }

        public OrderDetails(Commodity commodity, int quantity)
        {
            Commodity = commodity;
            Quantity = quantity;
        }
    }

    public class Commodity
    {
        public Commodity(string commodityName, double price)
        {
            CommodityName = commodityName;
            Price = price;
        }

        public string CommodityName { get; }
        public double Price { get; }
    }
}
