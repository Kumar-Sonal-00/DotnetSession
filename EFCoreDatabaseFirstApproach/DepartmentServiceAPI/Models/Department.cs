using System.ComponentModel.DataAnnotations;

namespace DepartmentServiceAPI.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string Dname {  get; set; }
        public int Dhead {  get; set; }
    }
}
