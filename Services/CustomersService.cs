using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Repositories;

namespace Services
{
    public class CustomersService : ICustomersService
    {
        ICustomersRepository _customersRepository;
        public CustomersService()
        {
            _customersRepository = new CustomersRepository();
        }
        public void AddCustomer(Customer customer)
        {
            _customersRepository.AddCustomer(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            _customersRepository.DeleteCustomer(customerId);
        }


        public List<Customer> GetAllCustomers()
        {
            return _customersRepository.GetAllCustomers();
        }

        public string SearchCustomerByName(string name)
        {
            return _customersRepository.SearchCustomerByName(name);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customersRepository.UpdateCustomer(customer);
        }
    }
}
