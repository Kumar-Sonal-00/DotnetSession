using System.ComponentModel.DataAnnotations.Schema;

namespace ProductServiceAPI.Models
{
    [Table("tbl_orders")]
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Pid { get; set; }
        public int Order_Quantity {  get; set; }
    }
}
