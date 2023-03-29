using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    class Program
    {
        static void Main()
        {
            OrderService orderService = new OrderService();

            while (true)
            {
                Console.WriteLine("1.添加订单");
                 Console.WriteLine("2.删除订单");
                Console.WriteLine("3.修改订单");
                Console.WriteLine("4.查询订单");
                Console.WriteLine("5.显示所有订单");
                Console.WriteLine("6.按照订单金额排序显示所有订单");
                Console.WriteLine("0.退出程序");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        orderService.AddOrder();
                        break;
                    case "2":
                        orderService.RemoveOrder();
                        break;
                    case "3":
                        orderService.ModifyOrder();
                        break;
                    case "4":
                        orderService.QueryOrder();
                        break;
                    case "5":
                        orderService.DisplayAllOrders();
                        break;
                    case "6":
                        orderService.DisplayAllOrdersSortedByTotalAmount();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("输入的选项不存在，请重新输入");
                        break;
                }
            }
        }
    }
}