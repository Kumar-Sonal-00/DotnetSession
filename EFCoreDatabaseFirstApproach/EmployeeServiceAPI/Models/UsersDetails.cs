using System.ComponentModel.DataAnnotations;

namespace EmployeeServiceAPI.Models
{
    public class UsersDetails
    {
        [Key]
        public string UserName { get; set; }
        public string Password {  get; set; }
        public string Role {  get; set; }
    }
}
