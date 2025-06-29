using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using Repositories;

namespace Services
{
    public class EmployeesService : IEmployeesService
    {
        private static EmployeesService instance;
        public static EmployeesService Instance => instance ??= new EmployeesService();

        private readonly EmployeesRepository _employeesRepository = EmployeesRepository.Instance;
        public EmployeesService()
        {
        }
        public void AddEmployee(Employee employee)
        {
            _employeesRepository.AddEmployee(employee);
        }

        public void DeleteEmployee(int employeeId)
        {
            _employeesRepository.DeleteEmployee(employeeId);
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeesRepository.GetAllEmployees();
        }
        public void UpdateEmployee(Employee employee)
        {
            _employeesRepository.UpdateEmployee(employee);
        }
    }
}
