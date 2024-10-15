using DepartmentServiceAPI.Models;

namespace DepartmentServiceAPI.Repository
{
    public interface IDepartmentDataAccessLayer
    {
        List<Department> GetDepts();
        void AddDepartment(Department department);
    }
}
