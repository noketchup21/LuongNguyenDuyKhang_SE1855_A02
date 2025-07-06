using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Repositories;

namespace Services
{
    public class OrdersService : IOrdersService
    {
        IOrdersRepository _ordersRepository;
        public OrdersService()
        {
            _ordersRepository = new OrdersRepository();
        }
        public void AddOrder(Order order)
        {
            _ordersRepository.AddOrder(order);
        }

        public void DeleteOrder(int orderId)
        {
            _ordersRepository.DeleteOrder(orderId);
        }


        public List<Order> GetAllOrders()
        {
            return _ordersRepository.GetAllOrders();
        }
        public void UpdateOrder(Order order)
        {
            _ordersRepository.UpdateOrder(order);
        }
    }
}
