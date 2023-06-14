using IMS.CoreBussiness.Entities;
using IMS.CoreBussiness.Enums;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInVentoryTransactionRespository
    {
        Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, string doneby, double price);

        Task ProduceInventoryAsync(string productionNumber, Inventory inventory, int quantitytoCosume, string doneby, double price);
        Task<IEnumerable<InventoryTransaction>> GetInventoryTranscationAsync(string inventoryName, DateTime? datefrom, DateTime? dateto, InventoryTransactionType? transactionTYpe);
    }
}