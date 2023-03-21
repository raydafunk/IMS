using IMS.CoreBussiness;
using System.ComponentModel.DataAnnotations;

namespace IMS.UseCases.Products
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(150)]
        public string ProductName { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Quantitiy must be greater then or equal to 0")]
        public int Quantity { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater then or equal to 0")]
        public double Price { get; set; }

        public List<ProductInventory>? ProductInventories { get; set; }
    }
}