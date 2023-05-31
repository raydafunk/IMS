using IMS.CoreBussiness.Entities;
using IMS.CoreBussiness.Enums;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class ProductTransactionRespository : IProductTransactionRepository
    {
        private readonly List<ProductTransaction> _productTransactions = new();

        private readonly IProductRepository _productRepository;
        private readonly IInVentoryTransactionRespository _inventoryTranscationRepo;
        private readonly IInVentoryRespository _inVentoryRespository;

        public ProductTransactionRespository(IProductRepository productRepository,
              IInVentoryTransactionRespository inventoryRepository,
              IInVentoryRespository inVentoryRespository)
        {
            this._productRepository = productRepository;
            this._inventoryTranscationRepo = inventoryRepository;
            this._inVentoryRespository = inVentoryRespository;
        }

        /// <summary>
        /// Mehtod for producing Products first we get the product id then we add the inventories and the transcations
        /// </summary>
        /// <param name="productionNumber"></param>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <param name="doneby"></param>
        /// <returns></returns>
        public async Task ProduceProductAsync(string productionNumber, Product product, int quantity, string doneby)
        {
            var prod = await this._productRepository.GetProductsByIdAsync(product.ProductId);
            await AddProductInventories(productionNumber, quantity, doneby, prod);
            addproducetranscations(productionNumber, product, quantity, doneby);
        }

        public Task SellProductAsync(string salesOrderNumber, Product product, int quantiy, string doneBy)
        {
            this._productTransactions.Add(new ProductTransaction
            {
                ActivityType = ProductTransactionType.SellProduct,
                SONumber = salesOrderNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                QuantityAfter = product.Quantity - quantiy,
                TranasactionDate = DateTime.Now,
                Doneby = doneBy,
                UnitPrice = product.Price
                

            });
            return Task.CompletedTask;
        }

        private void addproducetranscations(string productionNumber, Product product, int quantity, string doneby)
        {
            //// add produce  transcations
            this._productTransactions.Add(new ProductTransaction
            {
                ProductionNumber = productionNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                ActivityType = ProductTransactionType.ProduceProduct,
                QuantityAfter = product.Quantity + quantity,
                TranasactionDate = DateTime.Now,
                Doneby = doneby
            }); ;
        }

        private async Task AddProductInventories(string productionNumber, int quantity, string doneby, Product prod)
        {
            if (prod != null)
            {
                foreach (var pi in prod.ProductInventories)
                {
                    //adding inventories transcations
                    this._inventoryTranscationRepo.ProduceInventoryAsync(productionNumber,
                        pi.Inventory!,
                        pi.InventoryQuantity * quantity,
                        doneby,
                        -1);
                    // decrease the inventories
                    var inv = await this._inVentoryRespository.GetInvetoriesByIdAsync(pi.ProductId);
                    inv.Quantity -= pi.InventoryQuantity * quantity;
                    await this._inVentoryRespository.UpdateInventoryAsync(inv);
                }
            }
        }
    }
}
