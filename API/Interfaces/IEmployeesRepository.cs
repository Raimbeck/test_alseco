using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using API.Persistence;

namespace API.Interfaces
{
    public interface IEmployeesRepository
    {
         Task<List<Employee>> GetEmployees(Filter filter);
         Task<Employee> GetEmployee(int id);
         Task<int> GetEmployeesCount();
         Task<Employee> CreateEmployee(EmployeeDto dto);
         Task<bool> UpdateEmployee(int id, EmployeeDto dto);
         Task<bool> DeleteEmployee(int id);
    }
}