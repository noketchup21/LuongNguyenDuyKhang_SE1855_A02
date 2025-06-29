using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class CustomersDAO
    {
        private static CustomersDAO instance;
        public static CustomersDAO Instance => instance ??= new CustomersDAO();
        List<Customer> customers = new List<Customer>();
        private CustomersDAO() {
        }
        public List<Customer> GetAllCustomers()
        {
            return customers;
        }
        public void AddCustomer(Customer customer)
        {
            if (customer != null && !customers.Any(c => c.CustomerId == customer.CustomerId))
            {
                customers.Add(customer);
            }
        }
        public void UpdateCustomer(Customer customer)
        {
            Customer existingCustomer = customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            if (existingCustomer != null)
            {
                existingCustomer.CompanyName = customer.CompanyName;
                existingCustomer.ContactName = customer.ContactName;
                existingCustomer.ContactTitle = customer.ContactTitle;
                existingCustomer.Address = customer.Address;
                existingCustomer.Phone = customer.Phone;
            }
        }
        public void DeleteCustomer(int customerId)
        {
            Customer existingCustomer = customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (existingCustomer != null)
            {
                customers.Remove(existingCustomer);
            }
        }
        public string SearchCustomerByName(string name)
        {
            var customer = customers.FirstOrDefault(c => c.CompanyName.Contains(name, StringComparison.OrdinalIgnoreCase));
            return customer != null ? $"Found: {customer.CompanyName}, Contact: {customer.ContactName}" : "Customer not found";
        }
    }
}
