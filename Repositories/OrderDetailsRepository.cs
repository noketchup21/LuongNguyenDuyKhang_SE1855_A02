using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;

namespace Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        OrderDetailsDAO orderDetailsDAO = new OrderDetailsDAO();
        public void AddOrderDetails(OrderDetail orderDetails)
        {
            orderDetailsDAO.AddOrderDetails(orderDetails);
        }

        public void DeleteOrderDetails(int orderDetailsId)
        {
            orderDetailsDAO.DeleteOrderDetails(orderDetailsId);
        }


        public List<OrderDetail> GetAllOrderDetails()
        {
            return orderDetailsDAO.GetAllOrderDetails();
        }

        public void UpdateOrderDetails(OrderDetail orderDetails)
        {
            orderDetailsDAO.UpdateOrderDetails(orderDetails);
        }
    }
}
