using EmployeeServiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeServiceAPI.Repository
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions<UserDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<UsersDetails> tbl_users { get; set; }
    }
}
