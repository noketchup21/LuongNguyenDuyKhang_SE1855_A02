using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class OrdersDAO
    {
        private static OrdersDAO instance;
        public static OrdersDAO Instance => instance ??= new OrdersDAO();
        List<Order> orders = new List<Order>();

        public List<Order> GetAllOrders()
        {
            return orders;
        }
        public void AddOrder(Order order)
        {
            if (order != null && !orders.Any(o => o.OrderId == order.OrderId))
            {
                orders.Add(order);
            }
        }
        public void UpdateOrder(Order order)
        {
            Order existingOrder = orders.FirstOrDefault(o => o.OrderId == order.OrderId);
            if (existingOrder != null)
            {
                existingOrder.CustomerId = order.CustomerId;
                existingOrder.EmployeeId = order.EmployeeId;
                existingOrder.OrderDate = order.OrderDate;
            }
        }
        public void DeleteOrder(int orderId)
        {
            Order existingOrder = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (existingOrder != null)
            {
                orders.Remove(existingOrder);
            }
        }
    }
}
