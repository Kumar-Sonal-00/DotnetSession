using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDatabaseFirstApproach.Models;

public partial class EmpDbContext : DbContext
{ 

    public EmpDbContext(DbContextOptions<EmpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblEmployee> tbl_employee { get; set; }
    
}
