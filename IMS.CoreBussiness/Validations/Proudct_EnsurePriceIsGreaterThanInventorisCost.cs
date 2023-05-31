using IMS.CoreBussiness.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBussiness.Validations
{
    public class Proudct_EnsurePriceIsGreaterThanInventorisCost : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance is Product product && !VaildatePricing(product))
                return new ValidationResult($"The product's price is less than the inventories cost:{TotalInventorisCost(product):c}!",
                    new List<string>() { validationContext.MemberName! });

            return ValidationResult.Success;
        }
        private  static double TotalInventorisCost(Product product)
        {
            if(product == null || product.ProductInventories == null) return 0;

            return product.ProductInventories.Sum(x => x.Inventory?.Price * x.InventoryQuantity ?? 0);
        }

        private static bool VaildatePricing(Product product)
        {
            if(product.ProductInventories == null || product.ProductInventories.Count <= 0) return true;

            if(TotalInventorisCost(product) >= product.Price) return false;

            return true;
        }
    }
}
