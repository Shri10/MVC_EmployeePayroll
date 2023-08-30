using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer;
using RepositoryLayer.Interface;

namespace BusinessLayer.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        IEmployeeRepo employeeRepo;
        public EmployeeServices(IEmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        public Employee AddEmployeeService(Employee employee)
        {
            return this.employeeRepo.AddEmployee(employee);
        }

        public void DeleteEmployeeService(int id)
        {
            this.employeeRepo.DeleteEmployee(id);
        }

        public IEnumerable<Employee> GetAllEmployeeService()
        {
            return this.employeeRepo.GetAllEmployee();
        }

        public Employee GetEmployeeByIdService(int id)
        {
            return this.employeeRepo.GetEmployeeById(id);
        }

        public Employee UpdateEmployeeService(Employee employee)
        {
            return this.employeeRepo.UpdateEmployee(employee);
        }
    }
}
