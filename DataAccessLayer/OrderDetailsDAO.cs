using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class OrderDetailsDAO
    {
        private static OrderDetailsDAO instance;
        public static OrderDetailsDAO Instance => instance ??= new OrderDetailsDAO();
        List<OrderDetail> orderDetails = new List<OrderDetail>();

        public List<OrderDetail> GetAllOrderDetails()
        {
            return orderDetails;
        }
        public void AddOrderDetails(OrderDetail orderDetails)
        {
            if (orderDetails != null && !this.orderDetails.Any(od => od.OrderId == orderDetails.OrderId && od.ProductId == orderDetails.ProductId))
            {
                this.orderDetails.Add(orderDetails);
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
            }
        }
        public void DeleteOrderDetails(int orderDetailsId)
        {
            OrderDetail existingOrderDetails = orderDetails.FirstOrDefault(od => od.OrderId == orderDetailsId);
            if (existingOrderDetails != null)
            {
                orderDetails.Remove(existingOrderDetails);
            }
        }
    }
}
