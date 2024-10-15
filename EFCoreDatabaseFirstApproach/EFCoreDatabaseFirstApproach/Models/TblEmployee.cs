using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreDatabaseFirstApproach.Models;

//[Table("tbl_employee")]
public partial class TblEmployee
{
    [Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Ecode { get; set; }

    //[Column("ename")]
    public string? Ename { get; set; }

    public int? Salary { get; set; }

    public int? Deptid { get; set; }
}
