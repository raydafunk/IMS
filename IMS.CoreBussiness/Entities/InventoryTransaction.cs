using IMS.CoreBussiness;
using IMS.CoreBussiness.Enums;
using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBussiness.Entities
{
    public class InventoryTransaction
    {
        public int InventoryTransactionId { get; set; }
        public string PONumber { get; set; } = string.Empty;
        public string ProductionNumber { get; set; } = string.Empty;
        [Required]
        public int InventoryId { get; set; }
        [Required]
        public int QuantityBefore { get; set; }
        [Required]
        public InventoryTransactionType ActivityType { get; set; }
        [Required]
        public int QuantityAfter { get; set; }
        public double UnitPrice { get; set; }
        [Required]
        public DateTime TranasactionDate { get; set; }
        [Required]
        public string Doneby { get; set; } = string.Empty;

        public Inventory? Inventory { get; set; }

    }
}