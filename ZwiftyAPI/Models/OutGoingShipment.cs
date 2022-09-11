using System.ComponentModel.DataAnnotations;

namespace ZwiftyAPI.Models
{
    public class OutGoingShipment
    {
        [Key]
        public int OutGoingShipmentID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public string ShipmentDate { get; set; }
    }
}
