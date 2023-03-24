using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    internal class Order
    {

        public string OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetails> OrderDetailsList { get; set; }

        // 订单总金额
        public double TotalAmount
        {
            get
            {
                return OrderDetailsList.Sum(od => od.Commodity.Price * od.Quantity);
            }
        }

        public Order(string orderId, Customer customer) : this(orderId, customer, new List<OrderDetails>())
        {
        }

        public Order(string orderId, Customer customer, List<OrderDetails> orderDetailsList)
        {
            OrderId = orderId;
            Customer = customer;
            OrderDetailsList = orderDetailsList;
        }

        public void AddOrderDetails(OrderDetails orderDetails)
        {
            if (OrderDetailsList.Contains(orderDetails))
            {
                throw new Exception("订单明细已存在");
            }

            OrderDetailsList.Add(orderDetails);
        }

        public void RemoveOrderDetails(OrderDetails orderDetails)
        {
            OrderDetailsList.Remove(orderDetails);
        }

        public void ClearOrderDetails()
        {
            OrderDetailsList.Clear();
        }

        // 重写Equals方法
        public override bool Equals(object obj)
        {
            if (obj is Order order)
            {
                return OrderId == order.OrderId;
            }

            return false;
        }

        // 重写ToString方法
        public override string ToString()
        {
            string result = $"订单号：{OrderId}, 客户：{Customer}, 订单总金额：{TotalAmount}\n";

            foreach (var orderDetails in OrderDetailsList)
            {
                result += orderDetails + "\n";
            }

            return result;
        }
    }

    public class Customer
    {
        public Customer(string customerName)
        {
            CustomerName = customerName;
        }

        public string CustomerName { get; set; }
    }
}
