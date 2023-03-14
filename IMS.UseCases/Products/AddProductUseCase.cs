using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Products
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductRepository _productRepository;
        public async Task ExecuteAsync(Product product)
        {
            if (product == null) return;

            await this._productRepository.AddProductAsync(product);
        }
    }
}
