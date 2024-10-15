using Microsoft.EntityFrameworkCore;

namespace OrderServiceAPI.Models
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            :base(options) 
        {

        }

        public DbSet<Order> tbl_orders {  get; set; } 
    }
}
