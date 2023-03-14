using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;

namespace IMS.UseCases.Products
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductRepository? _productRepository;
        public async Task ExecuteAsync(Product product)
        {
            if (product == null) return;

            if (!await _productRepository!.ExistAsync(product))
            {
                await this._productRepository.AddProductAsync(product);
            }
        }
    }
}
