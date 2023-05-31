using IMS.CoreBussiness.Entities;
using IMS.CoreBussiness.Enums;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryTransactionRespository : IInVentoryTransactionRespository
    {
        public List<InventoryTransaction> _inventoryTransactions = new();

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
