using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using Repositories;

namespace Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        IOrderDetailsRepository _orderDetailsRepository;
        public OrderDetailsService()
        {
            _orderDetailsRepository = new OrderDetailsRepository();
        }
        public void AddOrderDetails(OrderDetail orderDetails)
        {
            _orderDetailsRepository.AddOrderDetails(orderDetails);
        }

        public void DeleteOrderDetails(int orderDetailsId)
        {
            _orderDetailsRepository.DeleteOrderDetails(orderDetailsId);
        }


        public List<OrderDetail> GetAllOrderDetails()
        {
            return _orderDetailsRepository.GetAllOrderDetails();
        }
        public void UpdateOrderDetails(OrderDetail orderDetails)
        {
            _orderDetailsRepository.UpdateOrderDetails(orderDetails);
        }
    }
}
