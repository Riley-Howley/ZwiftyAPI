using System.ComponentModel.DataAnnotations;

namespace ZwiftyAPI.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
