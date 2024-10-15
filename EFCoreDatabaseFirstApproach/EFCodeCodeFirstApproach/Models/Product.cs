using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeCodeFirstApproach.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
