using DepartmentServiceAPI.Models;

namespace DepartmentServiceAPI.Repository
{
    public class DepartmentDataAccessLayer : IDepartmentDataAccessLayer
    {
        private readonly DepartmentDbContext dbCtx;
        public DepartmentDataAccessLayer(DepartmentDbContext dbCtx)
        {
            this.dbCtx= dbCtx;
        }
        public void AddDepartment(Department department)
        {
            dbCtx.tbl_departments.Add(department);
            dbCtx.SaveChanges();
        }

        public List<Department> GetDepts()
        {
            return dbCtx.tbl_departments.ToList();
        }
    }
}
