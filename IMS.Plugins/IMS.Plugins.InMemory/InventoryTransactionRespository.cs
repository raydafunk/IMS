using IMS.CoreBussiness.Entities;
using IMS.CoreBussiness.Enums;
using IMS.UseCases.PluginInterfaces;
using Microsoft.VisualBasic;

namespace IMS.Plugins.InMemory
{
    public class InventoryTransactionRespository : IInVentoryTransactionRespository
    {
        private readonly IInVentoryRespository _inVentoryRespository;
        public List<InventoryTransaction> _inventoryTransactions = new();
        public InventoryTransactionRespository(IInVentoryRespository inVentoryRespository)
        {
            this._inVentoryRespository = inVentoryRespository;
        }
        public async Task<IEnumerable<InventoryTransaction>> GetInventoryTranscationAsync(string inventoryName, DateTime? datefrom, DateTime? dateto, InventoryTransactionTYpe? transactionTYpe)
        {
           var inventories =  (await _inVentoryRespository.GetInvetoriesByNameAsync(string.Empty)).ToList();

            var query = from it in this._inventoryTransactions
                        join inv in inventories on it.InventoryId equals inv.InventoryId
                        where
                            (string.IsNullOrWhiteSpace(inventoryName) || inv.InventoryName.ToLower().IndexOf(inventoryName.ToLower()) >= 0)
                            &&
                            (!datefrom.HasValue || it.TranasactionDate >= datefrom.Value.Date) &&
                            (!dateto.HasValue || it.TranasactionDate <= dateto.Value.Date) &&
                            (!transactionTYpe.HasValue || it. ActivityType == transactionTYpe)
                            select  new InventoryTransaction 
                            { 
                                Inventory = inv,
                                InventoryTransactionId = it.InventoryTransactionId,
                                PONumber = it.PONumber,
                                ProductionNumber = it.ProductionNumber,
                                InventoryId = it.InventoryId,
                                QuantityBefore = it.QuantityBefore,
                                ActivityType = it.ActivityType,
                                QuantityAfter = it.QuantityAfter,
                                TranasactionDate = it.TranasactionDate,
                                Doneby = it.Doneby,
                                UnitPrice = it.UnitPrice,
                            };

            return query;
                           
        }

        public void ProduceInventoryAsync(string productionNumber, Inventory inventory, int quantitytoCosume, string doneby, double price)
        {
            this._inventoryTransactions.Add(new InventoryTransaction
            {
                ProductionNumber= productionNumber,
                InventoryId = inventory.InventoryId,
                QuantityBefore = inventory.Quantity,
                ActivityType = InventoryTransactionTYpe.ProduceProduct,
                QuantityAfter = inventory.Quantity - quantitytoCosume,
                TranasactionDate = DateTime.Now,
                Doneby = doneby,
                UnitPrice = price
            });

        }

        public void PurchaseAsync(string poNumber, Inventory inventory, int quantity, string doneby, double price)
        {
            this._inventoryTransactions.Add(new InventoryTransaction
            {
                PONumber = poNumber,
                InventoryId = inventory.InventoryId,
                QuantityBefore = inventory.Quantity,
                ActivityType = InventoryTransactionTYpe.PurchaseInventory,
                QuantityAfter = inventory.Quantity + quantity,
                TranasactionDate= DateTime.Now,
                Doneby= doneby,
                UnitPrice = price   
            });

        }
    }
}
