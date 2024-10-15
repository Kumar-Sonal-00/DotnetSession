using EmployeeServiceAPI.Models;

namespace EmployeeServiceAPI.Repository
{
    public interface IEmpDataAccessLayer
    {
        List<Employee> GetEmps();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
    }
}
