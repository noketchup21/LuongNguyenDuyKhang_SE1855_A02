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
        private static EmployeesRepository instance;
        public static EmployeesRepository Instance => instance ??= new EmployeesRepository();

        private EmployeesDAO employeesDAO = EmployeesDAO.Instance;
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
