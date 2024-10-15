using Microsoft.EntityFrameworkCore;
using ProductServiceAPI.Models;

namespace ProductServiceAPI.DAL
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            :base(options)
        {
              
        }
        public DbSet<Product> tbl_product { get; set; }
    }
}
