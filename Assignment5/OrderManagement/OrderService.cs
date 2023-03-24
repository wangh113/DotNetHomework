using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    internal class OrderService
    {
        readonly List<Order> orderList = new List<Order>();

        // 添加订单
        public void AddOrder()
        {
            Console.Write("请输入订单号：");
            string orderId = Console.ReadLine();

            Console.Write("请输入客户名字：");
            string customerName = Console.ReadLine();

            Order order = new Order(orderId, new Customer(customerName));

            Console.WriteLine("请输入订单详细商品信息（输入end结束）");

            while (true)
            {
                Console.Write("请输入商品名字：");
                string commodityName = Console.ReadLine();

                if (commodityName == "end")
                {
                    break;
                }

                Console.Write("请输入商品价格：");
                double price = double.Parse(Console.ReadLine());

                Console.Write("请输入商品数量：");
                int quantity = int.Parse(Console.ReadLine());

                order.AddOrderDetails(new OrderDetails(new Commodity(commodityName, price), quantity));
            }

            try
            {
                orderList.Add(order);
            }
            catch (Exception e)
            {
                Console.WriteLine($"添加订单失败：{e.Message}");
            }
        }

        // 删除订单
        public void RemoveOrder()
        {
            Console.Write("请输入要删除的订单的订单号：");
            string orderId = Console.ReadLine();

            Order orderToRemove = orderList.SingleOrDefault(o => o.OrderId == orderId);

            if (orderToRemove != null)
            {
                orderList.Remove(orderToRemove);
            }
            else
            {
                throw new Exception($"要删除的订单不存在，订单号为：{orderId}");
            }
        }

        // 修改订单
        public void ModifyOrder()
        {
            Console.Write("请输入要修改的订单的订单号：");
            string orderId = Console.ReadLine();

            Order orderToModify = orderList.SingleOrDefault(o => o.OrderId == orderId);

            if (orderToModify != null)
            {
                Console.WriteLine("请输入新的客户名字（不修改请直接回车）：");
                string newCustomerName = Console.ReadLine();

                if (!string.IsNullOrEmpty(newCustomerName))
                {
                    orderToModify.Customer.CustomerName = newCustomerName;
                }

                Console.WriteLine("请输入订单详细商品信息（输入end结束）");

                // 先将原有订单明细删除
                orderToModify.ClearOrderDetails();

                while (true)
                {
                    Console.Write("请输入商品名字：");
                    string commodityName = Console.ReadLine();

                    if (commodityName == "end")
                    {
                        break;
                    }

                    Console.Write("请输入商品价格：");
                    double price = double.Parse(Console.ReadLine());

                    Console.Write("请输入商品数量：");
                    int quantity = int.Parse(Console.ReadLine());

                    orderToModify.AddOrderDetails(new OrderDetails(new Commodity(commodityName, price), quantity));
                }
            }
            else
            {
                throw new Exception($"要修改的订单不存在，订单号为：{orderId}");
            }
        }

        // 查询订单
        public void QueryOrder()
        {
            Console.WriteLine("请选择查询方式：");
            Console.WriteLine("1.按照订单号查询");
            Console.WriteLine("2.按照商品名称查询");
            Console.WriteLine("3.按照客户查询");
            Console.WriteLine("4.按照订单金额查询");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("请输入要查询的订单的订单号：");
                    string orderId = Console.ReadLine();

                    Order order = orderList.SingleOrDefault(o => o.OrderId == orderId);

                    if (order != null)
                    {
                        Console.WriteLine(order);
                        break;
                    }
                    throw new Exception($"要查询的订单不存在，订单号为：{orderId}");
                case "2":
                    Console.Write("请输入要查询的商品名称：");
                    string commodityName = Console.ReadLine();

                    var ordersWithCommodity = from o in orderList
                                              where o.OrderDetailsList.Exists(od => od.Commodity.CommodityName == commodityName)
                                              orderby o.TotalAmount
                                              select o;

                    foreach (var orderWithCommodity in ordersWithCommodity)
                    {
                        Console.WriteLine(orderWithCommodity);
                    }
                    break;
                case "3":
                    Console.Write("请输入要查询的客户名字：");
                    string customerName = Console.ReadLine();

                    var ordersWithCustomer = from o in orderList
                                             where o.Customer.CustomerName == customerName
                                             orderby o.TotalAmount
                                             select o;

                    foreach (var orderWithCustomer in ordersWithCustomer)
                    {
                        Console.WriteLine(orderWithCustomer);
                    }
                    break;
                case "4":
                    Console.Write("请输入要查询的订单的金额范围（如1000,2000）：");
                    string[] range = Console.ReadLine().Split(',');

                    double minAmount = double.Parse(range[0]);
                    double maxAmount = double.Parse(range[1]);

                    var ordersWithAmount = from o in orderList
                                           where o.TotalAmount >= minAmount && o.TotalAmount <= maxAmount
                                           orderby o.TotalAmount
                                           select o;

                    foreach (var orderWithAmount in ordersWithAmount)
                    {
                        Console.WriteLine(orderWithAmount);
                    }
                    break;
                default:
                    Console.WriteLine("输入的选项不存在，请重新输入");
                    break;
            }
        }

        // 显示所有订单
        public void DisplayAllOrders()
        {
            Console.WriteLine("所有订单如下：");

            foreach (var order in orderList)
            {
                Console.WriteLine(order);
            }
        }

        // 按照订单金额排序显示所有订单
        public void DisplayAllOrdersSortedByTotalAmount()
        {
            var sortedOrders = from o in orderList
                               orderby o.TotalAmount
                               select o;

            Console.WriteLine("按照订单金额排序显示所有订单：");

            foreach (var order in sortedOrders)
            {
                Console.WriteLine(order);
            }
        }
    }
}
