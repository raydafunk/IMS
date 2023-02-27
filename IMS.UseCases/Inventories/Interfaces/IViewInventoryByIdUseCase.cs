using IMS.CoreBussiness;

namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IViewInventoryByIdUseCase
    {
        Task<Inventory> ExeuteAysnc(int inventoryid);
    }
}