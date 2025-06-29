using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;


namespace Services
{
    public interface ICustomersService
    {
        List<Customer> GetAllCustomers();

        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        string SearchCustomerByName(string name);
    }
}
