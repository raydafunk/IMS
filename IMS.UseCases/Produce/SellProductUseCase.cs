
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Produce.Interface;

namespace IMS.UseCases.Produce
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTransactionRepository _productTransactionRepository;

        public SellProductUseCase(IProductRepository productRepository, IProductTransactionRepository productTransactionRepository)
        {
            this._productRepository = productRepository;
            this._productTransactionRepository = productTransactionRepository;
        }
        public async Task ExecuteAsync(string salesOrderNumber, CoreBussiness.Entities.Product product, int quantiy, string doneBy)
        {
            await this._productTransactionRepository.SellProductAsync(salesOrderNumber, product, quantiy, doneBy);

            product.Quantity -= quantiy;
            await this._productRepository.UpdateProductAsync(product);
        }
    }
}
