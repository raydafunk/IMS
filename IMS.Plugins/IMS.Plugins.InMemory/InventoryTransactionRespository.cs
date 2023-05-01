using IMS.CoreBussiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryTransactionRespository : IInVentoryTransactionRespository
    {
        public List<InventoryTransaction> _inventoryTransactions = new List<InventoryTransaction>();

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
