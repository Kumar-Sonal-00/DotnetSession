using EmployeeServiceAPI.Models;

namespace EmployeeServiceAPI.Repository
{
    public class EmpDataAccessLayer : IEmpDataAccessLayer
    {
        private readonly EmpDbContext dbCtx;
        public EmpDataAccessLayer(EmpDbContext dbCtx)
        {
            this.dbCtx=dbCtx;
        }
        public void AddEmployee(Employee employee)
        {
            dbCtx.tbl_employees.Add(employee);
            dbCtx.SaveChanges();
        }

        public Employee GetEmployeeById(int id)
        {
            return dbCtx.tbl_employees.Find(id);
        }

        public List<Employee> GetEmps()
        {
            return dbCtx.tbl_employees.ToList();
        }
    }
}
