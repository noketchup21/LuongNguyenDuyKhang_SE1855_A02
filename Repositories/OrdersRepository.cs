﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;

namespace Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        OrdersDAO ordersDAO = new OrdersDAO();
        public void AddOrder(Order order)
        {
            ordersDAO.AddOrder(order);
        }

        public void DeleteOrder(int orderId)
        {
            ordersDAO.DeleteOrder(orderId);
        }


        public List<Order> GetAllOrders()
        {
            return ordersDAO.GetAllOrders();
        }

        public void UpdateOrder(Order order)
        {
            ordersDAO.UpdateOrder(order);
        }
    }
}
