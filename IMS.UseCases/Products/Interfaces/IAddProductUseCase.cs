using IMS.CoreBussiness.Entities;

namespace IMS.UseCases.Products.Interfaces
{
    public interface IAddProductUseCase
    {
        Task ExecuteAsync(Product product);
    }
}