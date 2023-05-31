using IMS.CoreBussiness.Entities;

namespace IMS.UseCases.Products.Interfaces
{
    public interface IEditProdcutUserCase
    {
        Task ExectueAsync(Product product);
    }
}