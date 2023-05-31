using IMS.CoreBussiness.Entities;

namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IViewInventoryByIdUseCase
    {
        Task<Inventory> ExeuteAysnc(int inventoryid);
    }
}