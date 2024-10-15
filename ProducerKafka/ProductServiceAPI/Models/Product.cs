using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductServiceAPI.Models
{
    [Table("tbl_product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
