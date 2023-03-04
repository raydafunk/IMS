using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;
namespace IMS.UseCases.Products
{
    public class ViewProductByNameUserCase : IViewProductByNameUserCase
    {
        private readonly IProductRepository _productRepository;

        public ViewProductByNameUserCase(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> ExecuteAsync(string name = "")
        {
            return await _productRepository.GetProductsByNameAsync(name);
        }
    }
}
