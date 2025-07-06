using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class OrdersDAO
    {
        LucySalesDataContext context = new LucySalesDataContext();
        List<Order> orders = new List<Order>();

        public List<Order> GetAllOrders()
        {
            return context.Orders.ToList();
        }
        public void AddOrder(Order order)
        {
            if (order != null && !orders.Any(o => o.OrderId == order.OrderId))
            {
                context.Add(order);
                context.SaveChanges();
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
                context.SaveChanges();
            }
        }
        public void DeleteOrder(int orderId)
        {
            Order existingOrder = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (existingOrder != null)
            {
                context.Remove(existingOrder);
                context.SaveChanges();
            }
        }
    }
}
