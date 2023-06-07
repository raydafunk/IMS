using IMS.WebApp.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModlesValidations
{
    public class Produce_EnsureEnoughInventoryQuanity : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var produceViewModel = validationContext.ObjectInstance as ProductVM;
            if (produceViewModel != null && produceViewModel.Product != null && produceViewModel.Product.ProductInventories != null)
            {
                foreach (var pi in produceViewModel.Product.ProductInventories)
                {
                    if (pi.Inventory != null &&
                        pi.InventoryQuantity * produceViewModel.QuantityToProduct > pi.InventoryQuantity)
                    {
                        return new ValidationResult($"The Inventory ({pi.Inventory.InventoryName}) is not enough to produce {produceViewModel.QuantityToProduct} produts",
                            new[] { validationContext.MemberName }!);

                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
