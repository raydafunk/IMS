using IMS.UseCases.Products;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task<bool> ExistAsync(Product product);
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
    }
}