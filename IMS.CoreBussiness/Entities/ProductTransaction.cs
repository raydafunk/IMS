using System.ComponentModel.DataAnnotations;
using IMS.CoreBussiness.Enums;

namespace IMS.CoreBussiness.Entities
{
    public class ProductTransaction
    {
        public int ProductTransactionId { get; set; }

        public string ProductionNumber { get; set; } = string.Empty;
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int QuantityBefore { get; set; }
        [Required]
        public ProductTransactionType ActivityType { get; set; }
        [Required]
        public int QuantityAfter { get; set; }
        public double? UnitPrice { get; set; }
        [Required]
        public DateTime TranasactionDate { get; set; }
        [Required]
        public string Doneby { get; set; } = string.Empty;
        public Product? Product { get; set; }
    }
}