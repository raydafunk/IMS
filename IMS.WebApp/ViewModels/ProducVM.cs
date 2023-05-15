using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModels
{
    public class ProductVM
    {
        [Required]
        public string? ProductNumber { get; set; }
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "You must to select a product")]
        public int ProductId { get; set; }
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quanity has to be greater then 1")]

        public int QuantityToProduct { get; set; }
    }
}
