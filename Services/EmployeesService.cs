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
        IEmployeesRepository _employeesRepository;
        public EmployeesService()
        {
            _employeesRepository = new EmployeesRepository();
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
