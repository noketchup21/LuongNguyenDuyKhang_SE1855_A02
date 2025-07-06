using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class OrderDetailsDAO
    {
        LucySalesDataContext context = new LucySalesDataContext();
        List<OrderDetail> orderDetails = new List<OrderDetail>();

        public List<OrderDetail> GetAllOrderDetails()
        {
            return context.OrderDetails.ToList();
        }
        public void AddOrderDetails(OrderDetail orderDetails)
        {
            if (orderDetails != null && !this.orderDetails.Any(od => od.OrderId == orderDetails.OrderId && od.ProductId == orderDetails.ProductId))
            {
                context.Add(orderDetails);
                context.SaveChanges();
            }
        }
        public void UpdateOrderDetails(OrderDetail orderDetails)
        {
            OrderDetail existingOrderDetails = this.orderDetails.FirstOrDefault(od => od.OrderId == orderDetails.OrderId && od.ProductId == orderDetails.ProductId);
            if (existingOrderDetails != null)
            {
                existingOrderDetails.UnitPrice = orderDetails.UnitPrice;
                existingOrderDetails.Quantity = orderDetails.Quantity;
                existingOrderDetails.Discount = orderDetails.Discount;
                context.SaveChanges();
            }
        }
        public void DeleteOrderDetails(int orderDetailsId)
        {
            OrderDetail existingOrderDetails = orderDetails.FirstOrDefault(od => od.OrderId == orderDetailsId);
            if (existingOrderDetails != null)
            {
                context.Remove(existingOrderDetails);
                context.SaveChanges();
            }
        }
    }
}
