using System.ComponentModel.DataAnnotations;

namespace ZwiftyAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
    }
}
