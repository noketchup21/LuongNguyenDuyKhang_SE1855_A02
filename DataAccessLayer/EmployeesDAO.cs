using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeesDAO
    {
        LucySalesDataContext context = new LucySalesDataContext();
        List<Employee> employees = new List<Employee>();


        public List<Employee> GetAllEmployees()
        {
            return context.Employees.ToList();
        }
        public void AddEmployee(Employee employee)
        {
            if (employee != null)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }
        public void UpdateEmployee(Employee employee)
        {
            Employee existingEmployee = context.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.UserName = employee.UserName;
                existingEmployee.Password = employee.Password;
                existingEmployee.JobTitle = employee.JobTitle;
                existingEmployee.BirthDate = employee.BirthDate;
                existingEmployee.HireDate = employee.HireDate;
                existingEmployee.Address = employee.Address;
                context.SaveChanges();
            }
        }
        public void DeleteEmployee(int employeeId)
        {
            Employee employee = context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
        }

    }
}
