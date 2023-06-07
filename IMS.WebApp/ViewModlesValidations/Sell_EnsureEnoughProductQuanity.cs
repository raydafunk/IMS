using IMS.WebApp.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModlesValidations
{
    public class Sell_EnsureEnoughProductQuanity : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var sellViewModel = validationContext.ObjectInstance as SellVM;
            if (sellViewModel != null) 
            {
                if (sellViewModel.Product != null)
                {
                    if(sellViewModel.Product.Quantity < sellViewModel.QuanityToSell)
                    {
                        return new ValidationResult($"there is not enought produces. there is only {sellViewModel.Product.Quantity} in the warehouse"
                            ,new[] {validationContext.MemberName!});
                    }
                }
               
            }
            return ValidationResult.Success;
        }
    }
}
