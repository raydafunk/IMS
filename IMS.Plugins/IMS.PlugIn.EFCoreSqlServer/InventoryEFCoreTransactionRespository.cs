using IMS.CoreBussiness.Entities;
using IMS.CoreBussiness.Enums;
using IMS.PlugIn.EFCoreSqlServer;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace IMS.Plugins.InMemory
{
    public class InventoryEFCoreTransactionRespository : IInVentoryTransactionRespository
    {
        private readonly IMSDbContext _db;

        public InventoryEFCoreTransactionRespository(IMSDbContext db)
        {
            this._db = db;
        }
        public async Task<IEnumerable<InventoryTransaction>> GetInventoryTranscationAsync(string inventoryName, DateTime? datefrom, DateTime? dateto, InventoryTransactionType? transactionTYpe)
        {

            var query = from it in this._db.InventoryTransactions
                        join inv in this._db.Inventories on it.InventoryId equals inv.InventoryId
                        where
                            (string.IsNullOrWhiteSpace(inventoryName) || inv.InventoryName.ToLower().IndexOf(inventoryName.ToLower()) >= 0)
                            &&
                            (!datefrom.HasValue || it.TranasactionDate >= datefrom.Value.Date) &&
                            (!dateto.HasValue || it.TranasactionDate <= dateto.Value.Date) &&
                            (!transactionTYpe.HasValue || it.ActivityType == transactionTYpe)
                        select it;

            return  await query.Include(x => x.Inventory).ToListAsync();
                           
        }

        public async Task ProduceInventoryAsync(string productionNumber, Inventory inventory, int quantitytoCosume, string doneby, double price)
        {
            this._db.InventoryTransactions.Add(new InventoryTransaction
            {
                ProductionNumber= productionNumber,
                InventoryId = inventory.InventoryId,
                QuantityBefore = inventory.Quantity,
                ActivityType = InventoryTransactionType.ProduceProduct,
                QuantityAfter = inventory.Quantity - quantitytoCosume,
                TranasactionDate = DateTime.Now,
                Doneby = doneby,
                UnitPrice = price
            });
            await _db.SaveChangesAsync();

        }

        public async Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, string doneby, double price)
        {
            this._db.InventoryTransactions.Add(new InventoryTransaction
            {
                PONumber = poNumber,
                InventoryId = inventory.InventoryId,
                QuantityBefore = inventory.Quantity,
                ActivityType = InventoryTransactionType.PurchaseInventory,
                QuantityAfter = inventory.Quantity + quantity,
                TranasactionDate= DateTime.Now,
                Doneby= doneby,
                UnitPrice = price   
            });
            await _db.SaveChangesAsync();
        }
    }
}
