using IMS.CoreBussiness.Entities;

namespace IMS.UseCases.Products.Interfaces
{
    public interface IViewProductByIdUseCase
    {
        Task<Product> ExeuteAysnc(int productId);
    }
}