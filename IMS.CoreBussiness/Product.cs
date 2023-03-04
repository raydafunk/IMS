using System.ComponentModel.DataAnnotations;

namespace IMS.UseCases.Products
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}