using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFCodeCodeFirstApproach.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {

        }
        public DbSet<Product> tbl_products { get; set; }
    }
}
