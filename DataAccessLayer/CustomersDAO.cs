using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class CustomersDAO
    {
        LucySalesDataContext context = new LucySalesDataContext();
        public List<Customer> GetAllCustomers()
        {
            return context.Customers.ToList();
        }
        public void AddCustomer(Customer customer)
        {
            if (customer != null && !GetAllCustomers().Any(c => c.CustomerId == customer.CustomerId))
            {
                context.Add(customer);
                context.SaveChanges();
            }
        }
        public void UpdateCustomer(Customer customer)
        {
            Customer existingCustomer = GetAllCustomers().FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            if (existingCustomer != null)
            {
                existingCustomer.CompanyName = customer.CompanyName;
                existingCustomer.ContactName = customer.ContactName;
                existingCustomer.ContactTitle = customer.ContactTitle;
                existingCustomer.Address = customer.Address;
                existingCustomer.Phone = customer.Phone;
                context.SaveChanges();
            }
        }
        public void DeleteCustomer(int customerId)
        {
            Customer existingCustomer = GetAllCustomers().FirstOrDefault(c => c.CustomerId == customerId);
            if (existingCustomer != null)
            {
                context.Remove(existingCustomer);
                context.SaveChanges();  
            }
        }
        public string SearchCustomerByName(string name)
        {
            var customer = GetAllCustomers().FirstOrDefault(c => c.CompanyName.Contains(name, StringComparison.OrdinalIgnoreCase));
            return customer != null ? $"Found: {customer.CompanyName}, Contact: {customer.ContactName}" : "Customer not found";
        }
    }
}
