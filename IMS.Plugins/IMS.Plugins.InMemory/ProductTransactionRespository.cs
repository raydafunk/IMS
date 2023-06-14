﻿using IMS.CoreBussiness.Entities;
using IMS.CoreBussiness.Enums;
using IMS.PlugIn.EFCoreSqlServer;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EFCoreSqlServer
{
    public class ProductTransactionRespository : IProductTransactionRepository
    {
      

        private readonly IProductRepository _productRepository;
        private readonly IInVentoryTransactionRespository _inventoryTranscationRepo;
        private readonly IInVentoryRespository _inVentoryRespository;
        private readonly IMSDbContext _db;

        public ProductTransactionRespository(IProductRepository productRepository,
              IInVentoryTransactionRespository inventoryRepository,
              IInVentoryRespository inVentoryRespository,
              IMSDbContext db  )
        {
            this._productRepository = productRepository;
            this._inventoryTranscationRepo = inventoryRepository;
            this._inVentoryRespository = inVentoryRespository;
            this._db = db;
        }

        public async Task<IEnumerable<ProductTransaction>> GetProductTranscationAsync(string productName, DateTime? dateFrom, DateTime? dateTo, ProductTransactionType? transactionTYpe)
        {

            var query = from pt in this._db.ProductTransactions
                        join prod in this._db.Products on pt.ProductId equals prod.ProductId
                        where
                            (string.IsNullOrWhiteSpace(productName) || prod.ProductName.ToLower().IndexOf(productName.ToLower()) >= 0)
                            &&
                            (!dateFrom.HasValue || pt.TranasactionDate >= dateFrom.Value.Date) &&
                            (!dateTo.HasValue || pt.TranasactionDate <= dateTo.Value.Date) &&
                            (!transactionTYpe.HasValue || pt.ActivityType == transactionTYpe)
                        select pt;

            return await query.Include(x => x.Product).ToListAsync();
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

        public  async Task SellProductAsync(string salesOrderNumber, Product product, int quantiy, double unitPrice, string doneBy)
        {
            this._db.ProductTransactions.Add(new ProductTransaction
            {
                ActivityType = ProductTransactionType.SellProduct,
                SONumber = salesOrderNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                QuantityAfter = product.Quantity - quantiy,
                TranasactionDate = DateTime.Now,
                Doneby = doneBy,
                UnitPrice = unitPrice


            });
            await this._db.SaveChangesAsync();
        }

        private void addproducetranscations(string productionNumber, Product product, int quantity, string doneby)
        {
            //// add produce  transcations
            this._db.ProductTransactions.Add(new ProductTransaction
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
                    await this._inventoryTranscationRepo.ProduceInventoryAsync(productionNumber,
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
