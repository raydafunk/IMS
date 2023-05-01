using IMS.CoreBussiness;

namespace IMS.UseCases.Purchase.Interface
{
    public interface IPurchaseInventoryUseCase
    {
        Task ExecuteAsync(string poNumber, Inventory inventory, int quantity, string doneby);
    }
}