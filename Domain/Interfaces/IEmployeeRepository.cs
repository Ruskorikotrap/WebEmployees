using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEmployees.Domain.Entities;

namespace WebEmployees.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        public Employee AddEmployeeRepository(Employee employee);
        public Employee GetEmployeeById(int employeeId);
        public IEnumerable<Employee> GetAllEmployyes();
        public void EditEmployes(Employee employee);
        public void RemoveEmployes(Employee employee);
        public Employee GetEmployees(Employee employee);
    }
}
