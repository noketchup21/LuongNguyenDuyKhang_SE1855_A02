using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;


namespace Repositories
{
    public interface IOrderDetailsRepository
    {

        List<OrderDetail> GetAllOrderDetails();
        void AddOrderDetails(OrderDetail orderDetails);
        void UpdateOrderDetails(OrderDetail orderDetails);
        void DeleteOrderDetails(int orderDetailsId);
    }
}
