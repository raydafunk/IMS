using IMS.CoreBussiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInVentoryTransactionRespository
    {
        void PurchaseAsync(string poNumber, Inventory inventory, int quantity, string doneby, double price);
    }
}