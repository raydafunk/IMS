using IMS.CoreBussiness.Entities;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInVentoryTransactionRespository
    {
        void PurchaseAsync(string poNumber, Inventory inventory, int quantity, string doneby, double price);

        void ProduceInventoryAsync(string productionNumber, Inventory inventory, int quantitytoCosume, string doneby, double price);
    }
}