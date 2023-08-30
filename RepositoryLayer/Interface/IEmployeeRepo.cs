using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRepo
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
        Employee GetEmployeeById(int id);
    }
}
