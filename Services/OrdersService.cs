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
        private static OrdersService instance;
        public static OrdersService Instance => instance ??= new OrdersService();

        private OrdersRepository _ordersRepository = OrdersRepository.Instance;
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
