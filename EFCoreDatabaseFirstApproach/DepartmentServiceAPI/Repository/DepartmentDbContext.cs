using DepartmentServiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DepartmentServiceAPI.Repository
{
    public class DepartmentDbContext : DbContext
    {
        public DepartmentDbContext(DbContextOptions<DepartmentDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<Department> tbl_departments { get; set; }
    }
}
