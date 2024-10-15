using EmployeeServiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeServiceAPI.Repository
{
    public class EmpDbContext : DbContext
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<Employee> tbl_employees { get; set; } 

    }
}
