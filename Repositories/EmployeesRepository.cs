using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;

namespace Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        EmployeesDAO employeesDAO = new EmployeesDAO();
        public void AddEmployee(Employee employee)
        {
            employeesDAO.AddEmployee(employee);
        }

        public void DeleteEmployee(int employeeId)
        {
            employeesDAO.DeleteEmployee(employeeId);
        }


        public List<Employee> GetAllEmployees()
        {
            return employeesDAO.GetAllEmployees();
        }
        public void UpdateEmployee(Employee employee)
        {
            employeesDAO.UpdateEmployee(employee);
        }
    }
}
