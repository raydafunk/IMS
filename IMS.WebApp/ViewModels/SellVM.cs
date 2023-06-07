using IMS.CoreBussiness.Entities;
using IMS.WebApp.ViewModlesValidations;
using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModels
{
    public class SellVM
    {
        [Required]
        public string? SalesOrderNumber { get; set; } = string.Empty;
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantity must be greater then or equal to 1")]

        [Sell_EnsureEnoughProductQuanity]
        public int QuanityToSell { get; set; }

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Price has to be greater or equal to 0")]
        public  double UnitPrice { get; set; }

        public Product? Product { get; set; } = null;
    }
}
