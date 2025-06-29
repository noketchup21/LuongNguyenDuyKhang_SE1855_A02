using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;

namespace Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private static CustomersRepository instance;
        public static CustomersRepository Instance => instance ??= new CustomersRepository();

        private CustomersDAO customersDAO = CustomersDAO.Instance;
        public void AddCustomer(Customer customer)
        {
            customersDAO.AddCustomer(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            customersDAO.DeleteCustomer(customerId);
        }


        public List<Customer> GetAllCustomers()
        {
            return customersDAO.GetAllCustomers();
        }

        public string SearchCustomerByName(string name)
        {
            return customersDAO.SearchCustomerByName(name);
        }

        public void UpdateCustomer(Customer customer)
        {
            customersDAO.UpdateCustomer(customer);
        }
    }
}
