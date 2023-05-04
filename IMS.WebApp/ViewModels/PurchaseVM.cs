using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModels
{
    public class PurchaseVM
    {
        [Required]
        public string? PONumber { get; set; }
        [Required]
        [Range(minimum:1,maximum:int.MaxValue, ErrorMessage = "You Must provide and invetnory please")]
        public int InvenrtoryId{ get; set; }
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quanity has to be greater then 1")]

        public int QuantityToPurchase { get; set; }
        public double InventoryPrice { get; set; }
    }
}
