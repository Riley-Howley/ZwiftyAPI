using System.ComponentModel.DataAnnotations;

namespace ZwiftyAPI.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public decimal SupplierContact { get; set; }
        public string SupplierAddress { get; set; }
    }
}
