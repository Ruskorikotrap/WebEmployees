using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEmployees.Domain.Entities;
using WebEmployees.Domain.Interfaces;

namespace WebEmployees.Domain.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Employee AddEmployeeRepository(Employee employee)
        {
            try
            {
               
                if (!employee.StaffMember)
                    employee.PersonnelNumber = 0;
                appDbContext.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                appDbContext.SaveChanges();
                return employee;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void EditEmployes(Employee employee)
        {
            try
            {
                
                if(employee.Id==0)
                {
                    Employee tempEmployee = null;
                    if(employee.PersonnelNumber==0)
                        tempEmployee = appDbContext.Employees.FirstOrDefault(w => w.PersonnelNumber == employee.PersonnelNumber && !w.StaffMember && w.FullName.Equals(employee.FullName));
                    else
                        tempEmployee = appDbContext.Employees.FirstOrDefault(w => w.PersonnelNumber == employee.PersonnelNumber);

                    tempEmployee.GenderId = employee.GenderId;
                    tempEmployee.FullName = employee.FullName;
                    tempEmployee.DateOfBirth = employee.DateOfBirth;

                    appDbContext.Employees.Update(tempEmployee);
                }else
                    appDbContext.Employees.Update(employee);

                appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Employee> GetAllEmployyes()
        {
            try
            {
                return appDbContext.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employee GetEmployeeById(int employeeId)
        {
            try
            {
                return appDbContext.Employees.Where(w=>w.Id==employeeId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employee GetEmployees(Employee employee)
        {
            try
            {
                if(employee.PersonnelNumber==0)
                {
                    return appDbContext.Employees.FirstOrDefault(w => w.PersonnelNumber == employee.PersonnelNumber && !w.StaffMember && w.FullName.Equals(employee.FullName));
                }
                return appDbContext.Employees.FirstOrDefault(w => w.PersonnelNumber == employee.PersonnelNumber);
               
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveEmployes(Employee employee)
        {
            try
            {
                var data = appDbContext.Employees.FirstOrDefault(f => f.Id == employee.Id);
                appDbContext.Employees.Remove(data);
                appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
