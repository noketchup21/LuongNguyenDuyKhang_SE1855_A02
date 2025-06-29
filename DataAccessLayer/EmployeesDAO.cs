using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeesDAO
    {
        private static EmployeesDAO instance;
        public static EmployeesDAO Instance => instance ??= new EmployeesDAO();
        List<Employee> employees = new List<Employee>();


        public List<Employee> GetAllEmployees()
        {
            return employees;
        }
        public void AddEmployee(Employee employee)
        {
            if (employee != null && !employees.Any(e => e.EmployeeId == employee.EmployeeId))
            {
                employees.Add(employee);
            }
        }
        public void UpdateEmployee(Employee employee)
        {
            Employee existingEmployee = employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.UserName = employee.UserName;
                existingEmployee.Password = employee.Password;
                existingEmployee.JobTitle = employee.JobTitle;
                existingEmployee.BirthDate = employee.BirthDate;
                existingEmployee.HireDate = employee.HireDate;
                existingEmployee.Address = employee.Address;
            }
        }
        public void DeleteEmployee(int employeeId)
        {
            Employee existingEmployee = employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (existingEmployee != null)
            {
                employees.Remove(existingEmployee);
            }
        }
    }
}
