using System.ComponentModel.DataAnnotations;

namespace ZwiftyAPI.Models
{
    public class IncomingShipment
    {
        [Key]
        public int IncomingShipmentID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public int SupplierID { get; set; }
        public string DateRecieved { get; set; }
        public string OrderNumber { get; set; }
    }
}
