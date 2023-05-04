using IMS.CoreBussiness.Entities;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Produce.Interface;

namespace IMS.UseCases.Produce
{
    public class ProduceProductUseCase : IProduceProductUseCase
    {
        private readonly IProductTransactionRepository _productTransactionRepo;
        private readonly IProductRepository _productRepo;

        public ProduceProductUseCase(IProductTransactionRepository productTransactionRepository,
            IProductRepository product)
        {
            this._productTransactionRepo = productTransactionRepository;
            this._productRepo = product;
        }
        public async Task ExecuteAsync(string productionNumber, Product product, int quantity, string doneby)
        {
            // add transaction record
            await this._productTransactionRepo.ProduceProductAsync(productionNumber, product, quantity,  doneby);
            //decrease the quanity inventories

            //update the quantity of product
            product.Quantity += quantity;
            await this._productRepo.UpdateProductAsync(product);
        }
    }

}
